﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using AmazonPay.CommonRequests;
using Common.Logging;

namespace AmazonPay
{
    public class Signature
    {
        //pass only the required accesskey,secret key
        private readonly Configuration clientConfig;

        // Final URL to where the API parameters POST done,based off the config["region"] and respective mwsServiceUrls
        private string mwsServiceUrl;

        private string mwsEndpointUrl = string.Empty;
        private string mwsEndpointPath = string.Empty;

        // UserAgent to track the request and usage in the Logs
        private string userAgent = string.Empty;

        private readonly string parametersAsString = string.Empty;
        private readonly string serviceVersion = string.Empty;

        /// <summary>
        ///  Common Looger Property
        /// </summary>
        public ILog Logger { private get; set; }

        public Signature(Configuration configuration, string serviceVersion)
        {
            clientConfig = configuration;
            this.serviceVersion = serviceVersion;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="timeStamp"></param>
        /// <param name="mwsDevoUrl"></param>
        /// <returns></returns>
        public string CalculateSignatureAndReturnParametersAsString(IDictionary<string, string> parameters, string timeStamp = "", string mwsDevoUrl = "")
        {
            parameters.Add("AWSAccessKeyId", clientConfig.GetAccessKey());
            parameters.Add("Timestamp", string.IsNullOrEmpty(timeStamp) ? GetFormattedTimestamp() : timeStamp);
            parameters.Add("Version", serviceVersion);
            parameters.Add("SignatureVersion", "2");

            CreateServiceUrl(mwsDevoUrl);

            parameters.Add("Signature", SignParameters(parameters, clientConfig.GetSecretKey()));

            return GetParametersAsString(parameters);
        }

        /// <summary>
        /// Computes RFC 2104-compliant HMAC signature for request parameters
        /// Implements AWS Signature,as per following spec:
        ///
        /// If Signature Version is 0,it signs concatenated Action and Timestamp
        ///
        /// If Signature Version is 1,it performs the following:
        ///
        /// Sorts all  parameters (including SignatureVersion and excluding Signature,
        /// the value of which is being created),ignoring case.
        ///
        /// Iterate over the sorted list and append the parameter name (in original case)
        /// and then its value. It will not URL-encode the parameter values before
        /// constructing this string. There are no separators.
        ///
        /// If Signature Version is 2,string to sign is based on following:
        ///
        ///    1. The HTTP Request Method followed by an ASCII newline (%0A)
        ///    2. The HTTP Host header in the form of lowercase host,followed by an ASCII newline.
        ///    3. The URL encoded HTTP absolute path component of the URI
        ///       (up to but not including the query string parameters);
        ///       if this is empty use a forward "/". This parameter is followed by an ASCII newline.
        ///    4. The concatenation of all query string components (names and values)
        ///       as UTF-8 characters which are URL encoded as per RFC 3986
        ///       (hex characters MUST be uppercase),sorted using lexicographic byte ordering.
        ///       Parameter names are separated from their values by the "=" character
        ///       (ASCII character 61),even if the value is empty.
        ///       Pairs of parameter and values are separated by the "&" character (ASCII code 38).
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="key"></param>
        /// <returns>signature string</returns>
        private string SignParameters(IDictionary<string, string> parameters, string key)
        {
            string signatureVersion = parameters["SignatureVersion"];

            KeyedHashAlgorithm algorithm = new HMACSHA1();

            string stringToSign = null;

            if ("2".Equals(signatureVersion))
            {
                string signatureMethod = "HmacSHA256";
                algorithm = KeyedHashAlgorithm.Create(signatureMethod.ToUpper());
                parameters.Add("SignatureMethod", signatureMethod);
                stringToSign = CalculateStringToSignV2(parameters);
            }
            else
            {
                throw new InvalidDataException("Invalid Signature Version specified");
            }

            return Sign(stringToSign, key, algorithm);
        }

        /// <summary>
        /// compute the string signature as per the V2 specifications
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private string CalculateStringToSignV2(IDictionary<string, string> parameters)
        {
            StringBuilder data = new StringBuilder();
            IDictionary<string, string> sorted =
                  new SortedDictionary<string, string>(parameters, StringComparer.Ordinal);
            data.Append("POST");
            data.Append("\n");
            data.Append(mwsEndpointUrl);
            data.Append("\n");
            data.Append(mwsEndpointPath);
            data.Append("\n");
            foreach (KeyValuePair<string, string> pair in sorted)
            {
                if (pair.Value != null)
                {
                    data.Append(UrlEncode(pair.Key, false));
                    data.Append("=");
                    data.Append(UrlEncode(pair.Value, false));
                    data.Append("&");
                }

            }

            string result = data.ToString().Remove(data.Length - 1);

            LogMessage(result, SanitizeData.DataType.Request);

            return result;
        }

        private string UrlEncode(string data, bool path)
        {
            StringBuilder encoded = new StringBuilder();
            string unreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~" + (path ? "/" : "");

            foreach (char symbol in Encoding.UTF8.GetBytes(data))
            {
                if (unreservedChars.IndexOf(symbol) != -1)
                {
                    encoded.Append(symbol);
                }
                else
                {
                    encoded.Append("%" + string.Format("{0:X2}", (int)symbol));
                }
            }

            return encoded.ToString();

        }

        /// <summary>
        /// Computes RFC 2104-compliant HMAC signature.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <param name="algorithm"></param>
        /// <returns>string signature</returns>
        private string Sign(string data, string key, KeyedHashAlgorithm algorithm)
        {
            Encoding encoding = new UTF8Encoding();
            algorithm.Key = encoding.GetBytes(key);
            return Convert.ToBase64String(algorithm.ComputeHash(
                encoding.GetBytes(data.ToCharArray())));
        }

        /// <summary>
        /// Formats date as ISO 8601 timestamp
        /// </summary>
        /// <returns>DateTime object</returns>
        private string GetFormattedTimestamp()
        {
            DateTime dateTime = DateTime.Now;
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,
                                 dateTime.Hour, dateTime.Minute, dateTime.Second,
                                 dateTime.Millisecond
                                , DateTimeKind.Local
                               ).ToUniversalTime().ToString("yyyy-MM-dd\\THH:mm:ss.fff\\Z",
                                CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Create MWS service URL and the Endpoint path
        /// </summary>
        /// <param name="mwsTestUrl"></param>
        private void CreateServiceUrl(string mwsTestUrl)
        {
            string region = "";
            string mode = "";

            mode = Convert.ToBoolean(clientConfig.GetSandbox()) ? "OffAmazonPayments_Sandbox" : "OffAmazonPayments";

            if (!string.IsNullOrEmpty(clientConfig.GetRegion()))
            {
                region = clientConfig.GetRegion();
                if (Regions.regionMappings.ContainsKey(region))
                {
                    // Set the Endpoint for the internal development else get the value from the 
                    if (mwsTestUrl != null && mwsTestUrl.Trim() != "")
                    {
                        mwsServiceUrl = mwsTestUrl;
                        mwsEndpointPath = "";
                    }
                    else
                    {
                        mwsEndpointUrl = Regions.mwsServiceUrls[Regions.regionMappings[region]];
                        mwsServiceUrl = "https://" + mwsEndpointUrl + "/" + mode + "/" + serviceVersion;
                        mwsEndpointPath = "/" + mode + "/" + serviceVersion;
                    }
                }
                else
                {
                    throw new InvalidDataException(region + " is not a valid region");
                }
            }
            else
            {
                throw new NullReferenceException("region is a required parameter and is not set");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="additionalNameValuePairs"></param>
        public void SetUserAgentHeader(params string[] additionalNameValuePairs)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(Constants.SDKName + "/" + Constants.SDKClientVersion);

            sb.Append(" ( ");
            if (!string.IsNullOrEmpty(clientConfig.GetApplicationName()) && !string.IsNullOrEmpty(clientConfig.GetApplicationVersion()))
            {
                sb.Append(QuoteApplicationName(clientConfig.GetApplicationName()));
                sb.Append("/");
                sb.Append(QuoteApplicationVersion(clientConfig.GetApplicationVersion()));
                sb.Append("; ");
            }
            else if (!string.IsNullOrEmpty(clientConfig.GetApplicationName()))
            {
                sb.Append(QuoteApplicationName(clientConfig.GetApplicationName()));
                sb.Append("; ");
            }

            else if (!string.IsNullOrEmpty(clientConfig.GetApplicationVersion()))
            {
                sb.Append(QuoteApplicationVersion(clientConfig.GetApplicationVersion()));
                sb.Append("; ");
            }

            int i = 0;
            while (i < additionalNameValuePairs.Length)
            {
                string input = additionalNameValuePairs[i];

                sb.Append(QuoteAttributeValue(input));
                sb.Append("; ");
                i++;
            }

            sb.Append(")");

            userAgent = sb.ToString();
        }

        /// <summary>
        /// Convert Dictionary of parameters to Url encoded query string
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>string</returns>
        private string GetParametersAsString(IDictionary<string, string> parameters)
        {
            StringBuilder data = new StringBuilder();
            foreach (string key in parameters.Keys)
            {
                string input = parameters[key];
                if (input != null)
                {
                    data.Append(key);
                    data.Append("=");
                    data.Append(UrlEncode(input, false));
                    data.Append("&");
                }
            }
            string result = data.ToString();
            return result.Remove(result.Length - 1);
        }

        /// <summary>
        /// Replace all whitespace characters by a single space
        /// </summary>
        /// <param name="s"></param>
        /// <returns>string s</returns>
        private static string Clean(string s)
        {
            // matched character sequences are passed to a MatchEvaluator
            // delegate. The returned string from the delegate replaces
            // the matched sequence.
            return Regex.Replace(s, @" {2,}|\s", m => " ");
        }

        /// <summary>
        /// Collapse whitespace,and escape the following characters are escaped
        /// </summary>
        /// <param name="s"></param>
        /// <returns>string s</returns>
        private static string QuoteApplicationName(string s)
        {
            return Clean(s).Replace(@"\", @"\\").Replace("@/", @"\/");
        }

        /// <summary>
        /// Collapse whitespace,and escape the following characters are escaped
        /// </summary>
        /// <param name="s"></param>
        /// <returns>string s</returns>
        private static string QuoteApplicationVersion(string s)
        {
            return Clean(s).Replace(@"\", @"\\").Replace(@"(", @"\(");
        }

        /// <summary>
        /// Collapse whitespace,and escape the following characters are escaped
        /// </summary>
        /// <param name="s"></param>
        /// <returns>string s</returns>
        private static string QuoteAttributeName(string s)
        {
            return Clean(s).Replace(@"\", @"\\").Replace(@"=", @"\=");
        }

        /// <summary>
        /// Collapse whitespace,and escape the following characters are escaped 
        /// </summary>
        /// <param name="s"></param>
        /// <returns>string s</returns>
        private static string QuoteAttributeValue(string s)
        {
            return Clean(s).Replace(@"\", @"\\").Replace(@";", @"\;").Replace(@")", @"\)");
        }

        public string GetMwsServiceUrl()
        {
            return mwsServiceUrl;
        }

        public string GetMwsEndpointUrl()
        {
            return mwsEndpointUrl;
        }

        public string GetMwsEndpointPath()
        {
            return mwsEndpointPath;
        }

        public string GetUserAgent()
        {
            return userAgent;
        }

        public string GetParametersAsString()
        {
            return parametersAsString;
        }

        /// <summary>
        /// Helper method to log data within Signature 
        /// </summary>
        /// <param name="message">Data to be sanitized</param>
        /// <param name="type">Type of data</param>
        private void LogMessage(string message, SanitizeData.DataType type)
        {
            if (Logger != null && Logger.IsDebugEnabled)
            {
                Logger.Debug(SanitizeData.SanitizeGivenData(message, type));
            }
        }
    }
}
