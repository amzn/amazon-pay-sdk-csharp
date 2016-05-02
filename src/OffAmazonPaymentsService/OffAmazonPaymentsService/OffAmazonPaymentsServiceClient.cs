/******************************************************************************* 
 *  Copyright 2008-2012 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  
 *  You may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 *  specific language governing permissions and limitations under the License.
 * ***************************************************************************** 
 * 
 *  Off Amazon Payments Service CSharp Library
 *  API Version: 2013-01-01
 * 
 */


using System;
using System.Reflection;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Globalization;
using System.Xml.Serialization;
using System.Collections.Generic;
using OffAmazonPaymentsService.Model;
using OffAmazonPaymentsService;


namespace OffAmazonPaymentsService
{
    /**
     *
     * OffAmazonPaymentsServiceClient is an implementation of IOffAmazonPaymentsService
     *
     */
    public class OffAmazonPaymentsServiceClient : IOffAmazonPaymentsService
    {

        private String awsAccessKeyId = null;
        private String awsSecretAccessKey = null;
        private OffAmazonPaymentsServiceConfig config = null;
        private const String REQUEST_THROTTLED_ERROR_CODE = "RequestThrottled";

        /// <summary>
        /// Constructs OffAmazonPaymentsServiceClient with AWS Access Key ID and AWS Secret Key
        /// </summary>
        /// <param name="applicationName">Your application's name, e.g. "MyMWSApp"</param>
        /// <param name="applicationVersion">Your application's version, e.g. "1.0"</param>
        /// <param name="awsAccessKeyId">AWS Access Key ID</param>
        /// <param name="awsSecretAccessKey">AWS Secret Access Key</param>
        /// <param name="config">configuration</param>
        public OffAmazonPaymentsServiceClient(
            String applicationName,
            String applicationVersion,
            String awsAccessKeyId,
            String awsSecretAccessKey,
            OffAmazonPaymentsServiceConfig config)
        {
            this.awsAccessKeyId = awsAccessKeyId;
            this.awsSecretAccessKey = awsSecretAccessKey;
            this.config = config;
            ServicePointManager.Expect100Continue = false;
            ServicePointManager.UseNagleAlgorithm = false;
            config.SetUserAgent(applicationName, applicationVersion);
        }

        public OffAmazonPaymentsServiceClient(OffAmazonPaymentsServicePropertyCollection property)
            : this(property.ApplicationName, property.ApplicationVersion, property.AccessKey,
                property.SecretKey, property.MPSConfig)
        {

        }
        // Public API ------------------------------------------------------------//


        /// <summary>
        /// Capture 
        /// </summary>
        /// <param name="request">Capture  request</param>
        /// <returns>Capture  Response from the service</returns>
        public CaptureResponse Capture(CaptureRequest request)
        {
            return Invoke<CaptureResponse>(ConvertCapture(request));
        }


        /// <summary>
        /// Refund 
        /// </summary>
        /// <param name="request">Refund  request</param>
        /// <returns>Refund  Response from the service</returns>
        public RefundResponse Refund(RefundRequest request)
        {
            return Invoke<RefundResponse>(ConvertRefund(request));
        }


        /// <summary>
        /// Close Authorization 
        /// </summary>
        /// <param name="request">Close Authorization  request</param>
        /// <returns>Close Authorization  Response from the service</returns>
        public CloseAuthorizationResponse CloseAuthorization(CloseAuthorizationRequest request)
        {
            return Invoke<CloseAuthorizationResponse>(ConvertCloseAuthorization(request));
        }


        /// <summary>
        /// Get Refund Details 
        /// </summary>
        /// <param name="request">Get Refund Details  request</param>
        /// <returns>Get Refund Details  Response from the service</returns>
        public GetRefundDetailsResponse GetRefundDetails(GetRefundDetailsRequest request)
        {
            return Invoke<GetRefundDetailsResponse>(ConvertGetRefundDetails(request));
        }


        /// <summary>
        /// Get Capture Details 
        /// </summary>
        /// <param name="request">Get Capture Details  request</param>
        /// <returns>Get Capture Details  Response from the service</returns>
        public GetCaptureDetailsResponse GetCaptureDetails(GetCaptureDetailsRequest request)
        {
            return Invoke<GetCaptureDetailsResponse>(ConvertGetCaptureDetails(request));
        }


        /// <summary>
        /// Close Order Reference 
        /// </summary>
        /// <param name="request">Close Order Reference  request</param>
        /// <returns>Close Order Reference  Response from the service</returns>
        public CloseOrderReferenceResponse CloseOrderReference(CloseOrderReferenceRequest request)
        {
            return Invoke<CloseOrderReferenceResponse>(ConvertCloseOrderReference(request));
        }


        /// <summary>
        /// Confirm Order Reference 
        /// </summary>
        /// <param name="request">Confirm Order Reference  request</param>
        /// <returns>Confirm Order Reference  Response from the service</returns>
        public ConfirmOrderReferenceResponse ConfirmOrderReference(ConfirmOrderReferenceRequest request)
        {
            return Invoke<ConfirmOrderReferenceResponse>(ConvertConfirmOrderReference(request));
        }


        /// <summary>
        /// Get Order Reference Details 
        /// </summary>
        /// <param name="request">Get Order Reference Details  request</param>
        /// <returns>Get Order Reference Details  Response from the service</returns>
        public GetOrderReferenceDetailsResponse GetOrderReferenceDetails(GetOrderReferenceDetailsRequest request)
        {
            return Invoke<GetOrderReferenceDetailsResponse>(ConvertGetOrderReferenceDetails(request));
        }


        /// <summary>
        /// Authorize 
        /// </summary>
        /// <param name="request">Authorize  request</param>
        /// <returns>Authorize  Response from the service</returns>
        public AuthorizeResponse Authorize(AuthorizeRequest request)
        {
            return Invoke<AuthorizeResponse>(ConvertAuthorize(request));
        }


        /// <summary>
        /// Set Order Reference Details 
        /// </summary>
        /// <param name="request">Set Order Reference Details  request</param>
        /// <returns>Set Order Reference Details  Response from the service</returns>
        public SetOrderReferenceDetailsResponse SetOrderReferenceDetails(SetOrderReferenceDetailsRequest request)
        {
            return Invoke<SetOrderReferenceDetailsResponse>(ConvertSetOrderReferenceDetails(request));
        }


        /// <summary>
        /// Get Authorization Details 
        /// </summary>
        /// <param name="request">Get Authorization Details  request</param>
        /// <returns>Get Authorization Details  Response from the service</returns>
        public GetAuthorizationDetailsResponse GetAuthorizationDetails(GetAuthorizationDetailsRequest request)
        {
            return Invoke<GetAuthorizationDetailsResponse>(ConvertGetAuthorizationDetails(request));
        }


        /// <summary>
        /// Cancel Order Reference 
        /// </summary>
        /// <param name="request">Cancel Order Reference  request</param>
        /// <returns>Cancel Order Reference  Response from the service</returns>
        public CancelOrderReferenceResponse CancelOrderReference(CancelOrderReferenceRequest request)
        {
            return Invoke<CancelOrderReferenceResponse>(ConvertCancelOrderReference(request));
        }


        /// <summary>
        /// Create Order Reference For Id 
        /// </summary>
        /// <param name="request">Create Order Reference For Id  request</param>
        /// <returns>Create Order Reference For Id  Response from the service</returns>
        public CreateOrderReferenceForIdResponse CreateOrderReferenceForId(CreateOrderReferenceForIdRequest request)
        {
            return Invoke<CreateOrderReferenceForIdResponse>(ConvertCreateOrderReferenceForId(request));
        }


        /// <summary>
        /// Get Billing Agreement Details 
        /// </summary>
        /// <param name="request">Get Billing Agreement Details  request</param>
        /// <returns>Get Billing Agreement Details  Response from the service</returns>
        public GetBillingAgreementDetailsResponse GetBillingAgreementDetails(GetBillingAgreementDetailsRequest request)
        {
            return Invoke<GetBillingAgreementDetailsResponse>(ConvertGetBillingAgreementDetails(request));
        }


        /// <summary>
        /// Set Billing Agreement Details 
        /// </summary>
        /// <param name="request">Set Billing Agreement Details  request</param>
        /// <returns>Set Billing Agreement Details  Response from the service</returns>
        public SetBillingAgreementDetailsResponse SetBillingAgreementDetails(SetBillingAgreementDetailsRequest request)
        {
            return Invoke<SetBillingAgreementDetailsResponse>(ConvertSetBillingAgreementDetails(request));
        }


        /// <summary>
        /// Confirm Billing Agreement 
        /// </summary>
        /// <param name="request">Confirm Billing Agreement  request</param>
        /// <returns>Confirm Billing Agreement  Response from the service</returns>
        public ConfirmBillingAgreementResponse ConfirmBillingAgreement(ConfirmBillingAgreementRequest request)
        {
            return Invoke<ConfirmBillingAgreementResponse>(ConvertConfirmBillingAgreement(request));
        }


        /// <summary>
        /// Validate Billing Agreement 
        /// </summary>
        /// <param name="request">Validate Billing Agreement  request</param>
        /// <returns>Validate Billing Agreement  Response from the service</returns>
        public ValidateBillingAgreementResponse ValidateBillingAgreement(ValidateBillingAgreementRequest request)
        {
            return Invoke<ValidateBillingAgreementResponse>(ConvertValidateBillingAgreement(request));
        }


        /// <summary>
        /// Authorize On Billing Agreement 
        /// </summary>
        /// <param name="request">Authorize On Billing Agreement  request</param>
        /// <returns>Authorize On Billing Agreement  Response from the service</returns>
        public AuthorizeOnBillingAgreementResponse AuthorizeOnBillingAgreement(AuthorizeOnBillingAgreementRequest request)
        {
            return Invoke<AuthorizeOnBillingAgreementResponse>(ConvertAuthorizeOnBillingAgreement(request));
        }


        /// <summary>
        /// Close Billing Agreement 
        /// </summary>
        /// <param name="request">Close Billing Agreement  request</param>
        /// <returns>Close Billing Agreement  Response from the service</returns>
        public CloseBillingAgreementResponse CloseBillingAgreement(CloseBillingAgreementRequest request)
        {
            return Invoke<CloseBillingAgreementResponse>(ConvertCloseBillingAgreement(request));
        }


        /// <summary>
        /// Get Provider Credit Details 
        /// </summary>
        /// <param name="request">Get Provider Credit Details  request</param>
        /// <returns>Get Provider Credit Details  Response from the service</returns>
        /// <remarks>
        /// A query API for ProviderCredits.  Both Provider and Seller sellerIds are authorized to call this API.
        /// 
        /// </remarks>
        public GetProviderCreditDetailsResponse GetProviderCreditDetails(GetProviderCreditDetailsRequest request)
        {
            return Invoke<GetProviderCreditDetailsResponse>(ConvertGetProviderCreditDetails(request));
        }


        /// <summary>
        /// Get Provider Credit Reversal Details 
        /// </summary>
        /// <param name="request">Get Provider Credit Reversal Details  request</param>
        /// <returns>Get Provider Credit Reversal Details  Response from the service</returns>
        /// <remarks>
        /// Activity to query the funds reversed against a given Provider Credit reversal.
        /// 
        /// </remarks>
        public GetProviderCreditReversalDetailsResponse GetProviderCreditReversalDetails(GetProviderCreditReversalDetailsRequest request)
        {
            return Invoke<GetProviderCreditReversalDetailsResponse>(ConvertGetProviderCreditReversalDetails(request));
        }



        /// <summary>
        /// Reverse Provider Credit 
        /// </summary>
        /// <param name="request">Reverse Provider Credit  request</param>
        /// <returns>Reverse Provider Credit  Response from the service</returns>
        /// <remarks>
        /// Activity to enable the Caller/Provider to reverse the funds credited to Provider.
        /// 
        /// </remarks>
        public ReverseProviderCreditResponse ReverseProviderCredit(ReverseProviderCreditRequest request)
        {
            return Invoke<ReverseProviderCreditResponse>(ConvertReverseProviderCredit(request));
        }


        // Private API ------------------------------------------------------------//

        /**
         * Configure HttpClient with set of defaults as well as configuration
         * from OffAmazonPaymentsServiceConfig instance
         */
        private HttpWebRequest ConfigureWebRequest(int contentLength)
        {
            HttpWebRequest request = WebRequest.Create(config.ServiceURL) as HttpWebRequest;

            if (config.IsSetProxyHost())
            {
                request.Proxy = new WebProxy(config.ProxyHost, config.ProxyPort);
            }
            request.UserAgent = config.UserAgent;
            request.Method = "POST";
            request.Timeout = 50000;
            request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
            request.ContentLength = contentLength;

            return request;
        }

        /**
         * Invoke request and return response
         */
        private T Invoke<T>(IDictionary<String, String> parameters)
        {
            String actionName = parameters["Action"];
            T response = default(T);
            String responseBody = null;
            HttpStatusCode statusCode = default(HttpStatusCode);
            ResponseHeaderMetadata rhm = null;
            if (String.IsNullOrEmpty(config.ServiceURL))
            {
                throw new OffAmazonPaymentsServiceException(
                    new ArgumentException(
                        "Missing serviceURL configuration value. You may obtain a list of valid MWS URLs by consulting the MWS Developer's Guide, or reviewing the sample code published along side this library."));
            }

            /* Add required request parameters */
            AddRequiredParameters(parameters);

            String queryString = GetParametersAsString(parameters);

            byte[] requestData = new UTF8Encoding().GetBytes(queryString);
            bool shouldRetry = true;
            int retries = 0;
            do
            {
                HttpWebRequest request = ConfigureWebRequest(requestData.Length);
                /* Submit the request and read response body */
                try
                {
                    using (Stream requestStream = request.GetRequestStream())
                    {
                        requestStream.Write(requestData, 0, requestData.Length);
                    }
                    using (HttpWebResponse httpResponse = request.GetResponse() as HttpWebResponse)
                    {
                        statusCode = httpResponse.StatusCode;


                        rhm = new ResponseHeaderMetadata(
                          httpResponse.GetResponseHeader("x-mws-request-id"),
                          httpResponse.GetResponseHeader("x-mws-response-context"),
                          httpResponse.GetResponseHeader("x-mws-timestamp"));

                        StreamReader reader = new StreamReader(httpResponse.GetResponseStream(), Encoding.UTF8);
                        responseBody = reader.ReadToEnd();
                    }
                    /* Attempt to deserialize response into <Action> Response type */
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    using (StringReader responseReader = new StringReader(responseBody))
                    {
                        response = (T)serializer.Deserialize(responseReader);

                        //                        PropertyInfo pi = typeof(T).GetProperty("ResponseHeaderMetadata");
                        //                        pi.SetValue(response, rhm, null);
                    }
                    shouldRetry = false;
                }
                /* Web exception is thrown on unsucessful responses */
                catch (WebException we)
                {
                    shouldRetry = false;
                    using (HttpWebResponse httpErrorResponse = (HttpWebResponse)we.Response as HttpWebResponse)
                    {
                        if (httpErrorResponse == null)
                        {
                            throw new OffAmazonPaymentsServiceException(we);
                        }
                        statusCode = httpErrorResponse.StatusCode;
                        using (StreamReader reader = new StreamReader(httpErrorResponse.GetResponseStream(), Encoding.UTF8))
                        {
                            responseBody = reader.ReadToEnd();
                        }
                    }

                    /* Attempt to deserialize response into ErrorResponse type */
                    using (StringReader responseReader = new StringReader(responseBody))
                    {
                        try
                        {
                            XmlSerializer serializer = new XmlSerializer(typeof(ErrorResponse));
                            ErrorResponse errorResponse = (ErrorResponse)serializer.Deserialize(responseReader);
                            Error error = errorResponse.Error[0];

                            bool retriableError =
                                (statusCode == HttpStatusCode.InternalServerError ||
                                 statusCode == HttpStatusCode.ServiceUnavailable);

                            retriableError = retriableError && !(REQUEST_THROTTLED_ERROR_CODE.Equals(error.Code));
                            if (retriableError && retries < config.MaxErrorRetry)
                            {
                                shouldRetry = true;
                                PauseOnRetry(++retries, statusCode, rhm);
                                continue;
                            }
                            else
                            {
                                shouldRetry = false;
                            }

                            /* Throw formatted exception with information available from the error response */
                            throw new OffAmazonPaymentsServiceException(
                                error.Message,
                                statusCode,
                                error.Code,
                                error.Type,
                                errorResponse.RequestId,
                                errorResponse.ToXML(),
                                rhm);
                        }
                        catch (OffAmazonPaymentsServiceException mwsErr)
                        {
                            throw mwsErr;
                        }
                        catch (Exception e)
                        {
                            throw ReportAnyErrors(responseBody, statusCode, rhm, e);
                        }
                    }
                }

                /* Catch other exceptions, attempt to convert to formatted exception,
                 * else rethrow wrapped exception */
                catch (Exception e)
                {
                    throw new OffAmazonPaymentsServiceException(e);
                }
            } while (shouldRetry);

            return response;
        }


        /**
         * Look for additional error strings in the response and return formatted exception
         */
        private OffAmazonPaymentsServiceException ReportAnyErrors(String responseBody, HttpStatusCode status, ResponseHeaderMetadata rhm, Exception e)
        {

            OffAmazonPaymentsServiceException ex = null;

            if (responseBody != null && responseBody.StartsWith("<"))
            {
                Match errorMatcherOne = Regex.Match(responseBody, "<RequestId>(.*)</RequestId>.*<Error>" +
                        "<Code>(.*)</Code><Message>(.*)</Message></Error>.*(<Error>)?", RegexOptions.Multiline);
                Match errorMatcherTwo = Regex.Match(responseBody, "<Error><Code>(.*)</Code><Message>(.*)" +
                        "</Message></Error>.*(<Error>)?.*<RequestID>(.*)</RequestID>", RegexOptions.Multiline);

                if (errorMatcherOne.Success)
                {
                    String requestId = errorMatcherOne.Groups[1].Value;
                    String code = errorMatcherOne.Groups[2].Value;
                    String message = errorMatcherOne.Groups[3].Value;

                    ex = new OffAmazonPaymentsServiceException(message, status, code, "Unknown", requestId, responseBody, rhm);

                }
                else if (errorMatcherTwo.Success)
                {
                    String code = errorMatcherTwo.Groups[1].Value;
                    String message = errorMatcherTwo.Groups[2].Value;
                    String requestId = errorMatcherTwo.Groups[4].Value;

                    ex = new OffAmazonPaymentsServiceException(message, status, code, "Unknown", requestId, responseBody, rhm);
                }
                else
                {
                    ex = new OffAmazonPaymentsServiceException("Internal Error", status, rhm);
                }
            }
            else
            {
                ex = new OffAmazonPaymentsServiceException("Internal Error", status, rhm);
            }
            return ex;
        }

        /**
         * Exponential sleep on failed request
         */
        private void PauseOnRetry(int retries, HttpStatusCode status, ResponseHeaderMetadata rhm)
        {
            if (retries <= config.MaxErrorRetry)
            {
                int delay = (int)Math.Pow(4, retries) * 100;
                System.Threading.Thread.Sleep(delay);
            }
            else
            {
                throw new OffAmazonPaymentsServiceException("Maximum number of retry attempts reached : " + (retries - 1), status, rhm);
            }
        }

        /**
         * Add authentication related and version parameters
         */
        private void AddRequiredParameters(IDictionary<String, String> parameters)
        {
            parameters.Add("AWSAccessKeyId", this.awsAccessKeyId);
            parameters.Add("Timestamp", GetFormattedTimestamp());
            parameters.Add("Version", config.ServiceVersion);
            parameters.Add("SignatureVersion", config.SignatureVersion);
            parameters.Add("Signature", SignParameters(parameters, this.awsSecretAccessKey));
        }

        /**
         * Convert Dictionary of paremeters to Url encoded query string
         */
        private string GetParametersAsString(IDictionary<String, String> parameters)
        {
            StringBuilder data = new StringBuilder();
            foreach (String key in (IEnumerable<String>)parameters.Keys)
            {
                String value = parameters[key];
                if (value != null)
                {
                    data.Append(key);
                    data.Append('=');
                    data.Append(UrlEncode(value, false));
                    data.Append('&');
                }
            }
            String result = data.ToString();
            return result.Remove(result.Length - 1);
        }

        /**
         * Computes RFC 2104-compliant HMAC signature for request parameters
         * Implements AWS Signature, as per following spec:
         *
         * If Signature Version is 0, it signs concatenated Action and Timestamp
         *
         * If Signature Version is 1, it performs the following:
         *
         * Sorts all  parameters (including SignatureVersion and excluding Signature,
         * the value of which is being created), ignoring case.
         *
         * Iterate over the sorted list and append the parameter name (in original case)
         * and then its value. It will not URL-encode the parameter values before
         * constructing this string. There are no separators.
         *
         * If Signature Version is 2, string to sign is based on following:
         *
         *    1. The HTTP Request Method followed by an ASCII newline (%0A)
         *    2. The HTTP Host header in the form of lowercase host, followed by an ASCII newline.
         *    3. The URL encoded HTTP absolute path component of the URI
         *       (up to but not including the query string parameters);
         *       if this is empty use a forward '/'. This parameter is followed by an ASCII newline.
         *    4. The concatenation of all query string components (names and values)
         *       as UTF-8 characters which are URL encoded as per RFC 3986
         *       (hex characters MUST be uppercase), sorted using lexicographic byte ordering.
         *       Parameter names are separated from their values by the '=' character
         *       (ASCII character 61), even if the value is empty.
         *       Pairs of parameter and values are separated by the '&' character (ASCII code 38).
         *
         */
        private String SignParameters(IDictionary<String, String> parameters, String key)
        {
            String signatureVersion = parameters["SignatureVersion"];

            KeyedHashAlgorithm algorithm = new HMACSHA1();

            String stringToSign = null;
            if ("0".Equals(signatureVersion))
            {
                stringToSign = CalculateStringToSignV0(parameters);
            }
            else if ("1".Equals(signatureVersion))
            {
                stringToSign = CalculateStringToSignV1(parameters);
            }
            else if ("2".Equals(signatureVersion))
            {
                String signatureMethod = config.SignatureMethod;
                algorithm = KeyedHashAlgorithm.Create(signatureMethod.ToUpper());
                parameters.Add("SignatureMethod", signatureMethod);
                stringToSign = CalculateStringToSignV2(parameters);
            }
            else
            {
                throw new Exception("Invalid Signature Version specified");
            }

            return Sign(stringToSign, key, algorithm);
        }

        private String CalculateStringToSignV0(IDictionary<String, String> parameters)
        {
            StringBuilder data = new StringBuilder();
            return data.Append(parameters["Action"]).Append(parameters["Timestamp"]).ToString();

        }

        private String CalculateStringToSignV1(IDictionary<String, String> parameters)
        {
            StringBuilder data = new StringBuilder();
            IDictionary<String, String> sorted =
              new SortedDictionary<String, String>(parameters, StringComparer.OrdinalIgnoreCase);
            foreach (KeyValuePair<String, String> pair in sorted)
            {
                if (pair.Value != null)
                {
                    data.Append(pair.Key);
                    data.Append(pair.Value);
                }
            }
            return data.ToString();
        }

        private String CalculateStringToSignV2(IDictionary<String, String> parameters)
        {
            StringBuilder data = new StringBuilder();
            IDictionary<String, String> sorted =
                  new SortedDictionary<String, String>(parameters, StringComparer.Ordinal);
            data.Append("POST");
            data.Append("\n");
            Uri endpoint = new Uri(config.ServiceURL);

            data.Append(endpoint.Host);
            if (endpoint.Port != 80 && endpoint.Port != 443)
            {
                data.Append(":");
                data.Append(endpoint.Port);
            }
            data.Append("\n");
            String uri = endpoint.AbsolutePath;
            if (String.IsNullOrEmpty(uri))
            {
                uri = "/";
            }
            data.Append(UrlEncode(uri, true));
            data.Append("\n");
            foreach (KeyValuePair<String, String> pair in sorted)
            {
                if (pair.Value != null)
                {
                    data.Append(UrlEncode(pair.Key, false));
                    data.Append("=");
                    data.Append(UrlEncode(pair.Value, false));
                    data.Append("&");
                }

            }

            String result = data.ToString();
            return result.Remove(result.Length - 1);
        }

        private String UrlEncode(String data, bool path)
        {
            StringBuilder encoded = new StringBuilder();
            String unreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~" + (path ? "/" : "");

            foreach (char symbol in System.Text.Encoding.UTF8.GetBytes(data))
            {
                if (unreservedChars.IndexOf(symbol) != -1)
                {
                    encoded.Append(symbol);
                }
                else
                {
                    encoded.Append("%" + String.Format("{0:X2}", (int)symbol));
                }
            }

            return encoded.ToString();

        }

        /**
         * Computes RFC 2104-compliant HMAC signature.
         */
        private String Sign(String data, String key, KeyedHashAlgorithm algorithm)
        {
            Encoding encoding = new UTF8Encoding();
            algorithm.Key = encoding.GetBytes(key);
            return Convert.ToBase64String(algorithm.ComputeHash(
                encoding.GetBytes(data.ToCharArray())));
        }


        /**
         * Formats date as ISO 8601 timestamp
         */
        private String GetFormattedTimestamp()
        {
            DateTime dateTime = DateTime.Now;
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,
                                 dateTime.Hour, dateTime.Minute, dateTime.Second,
                                 dateTime.Millisecond
                                 , DateTimeKind.Local
                               ).ToUniversalTime().ToString("yyyy-MM-dd\\THH:mm:ss.fff\\Z",
                                CultureInfo.InvariantCulture);
        }


        /**
         * Convert CaptureRequest to name value pairs
         */
        private IDictionary<String, String> ConvertCapture(CaptureRequest request)
        {

            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "Capture");
            if (request.IsSetSellerId())
            {
                parameters.Add("SellerId", request.SellerId + "");
            }
            if (request.IsSetAmazonAuthorizationId())
            {
                parameters.Add("AmazonAuthorizationId", request.AmazonAuthorizationId + "");
            }
            if (request.IsSetCaptureReferenceId())
            {
                parameters.Add("CaptureReferenceId", request.CaptureReferenceId + "");
            }
            if (request.IsSetCaptureAmount())
            {
                Price captureRequestCaptureAmount = request.CaptureAmount;
                if (captureRequestCaptureAmount.IsSetAmount())
                {
                    parameters.Add("CaptureAmount" + "." + "Amount", captureRequestCaptureAmount.Amount + "");
                }
                if (captureRequestCaptureAmount.IsSetCurrencyCode())
                {
                    parameters.Add("CaptureAmount" + "." + "CurrencyCode", captureRequestCaptureAmount.CurrencyCode);
                }
            }
            if (request.IsSetSellerCaptureNote())
            {
                parameters.Add("SellerCaptureNote", request.SellerCaptureNote + "");
            }
            if (request.IsSetSoftDescriptor())
            {
                parameters.Add("SoftDescriptor", request.SoftDescriptor + "");
            }
            if (request.IsSetMWSAuthToken())
            {
                parameters.Add("MWSAuthToken", request.MWSAuthToken + "");
            }
            if (request.IsSetProviderCreditList())
            {
                ProviderCreditList captureRequestProviderCreditList = request.ProviderCreditList;
                List<ProviderCredit> providerCreditListmemberList = captureRequestProviderCreditList.member;
                int providerCreditListmemberListIndex = 1;
                foreach (ProviderCredit providerCreditListmember in providerCreditListmemberList)
                {
                    if (providerCreditListmember.IsSetProviderId())
                    {
                        parameters.Add("ProviderCreditList" + "." + "member" + "." + providerCreditListmemberListIndex + "." + "ProviderId", providerCreditListmember.ProviderId + "");
                    }
                    if (providerCreditListmember.IsSetCreditAmount())
                    {
                        Price memberCreditAmount = providerCreditListmember.CreditAmount;
                        if (memberCreditAmount.IsSetAmount())
                        {
                            parameters.Add("ProviderCreditList" + "." + "member" + "." + providerCreditListmemberListIndex + "." + "CreditAmount" + "." + "Amount", memberCreditAmount.Amount + "");
                        }
                        if (memberCreditAmount.IsSetCurrencyCode())
                        {
                            parameters.Add("ProviderCreditList" + "." + "member" + "." + providerCreditListmemberListIndex + "." + "CreditAmount" + "." + "CurrencyCode", memberCreditAmount.CurrencyCode);
                        }
                    }

                    providerCreditListmemberListIndex++;
                }
            }

            return parameters;
        }


        /**
         * Convert RefundRequest to name value pairs
         */
        private IDictionary<String, String> ConvertRefund(RefundRequest request)
        {

            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "Refund");
            if (request.IsSetSellerId())
            {
                parameters.Add("SellerId", request.SellerId + "");
            }
            if (request.IsSetAmazonCaptureId())
            {
                parameters.Add("AmazonCaptureId", request.AmazonCaptureId + "");
            }
            if (request.IsSetRefundReferenceId())
            {
                parameters.Add("RefundReferenceId", request.RefundReferenceId + "");
            }
            if (request.IsSetRefundAmount())
            {
                Price refundRequestRefundAmount = request.RefundAmount;
                if (refundRequestRefundAmount.IsSetAmount())
                {
                    parameters.Add("RefundAmount" + "." + "Amount", refundRequestRefundAmount.Amount + "");
                }
                if (refundRequestRefundAmount.IsSetCurrencyCode())
                {
                    parameters.Add("RefundAmount" + "." + "CurrencyCode", refundRequestRefundAmount.CurrencyCode);
                }
            }
            if (request.IsSetSellerRefundNote())
            {
                parameters.Add("SellerRefundNote", request.SellerRefundNote + "");
            }
            if (request.IsSetSoftDescriptor())
            {
                parameters.Add("SoftDescriptor", request.SoftDescriptor + "");
            }
            if (request.IsSetMWSAuthToken())
            {
                parameters.Add("MWSAuthToken", request.MWSAuthToken + "");
            }
            if (request.IsSetProviderCreditReversalList())
            {
                ProviderCreditReversalList refundRequestProviderCreditReversalList = request.ProviderCreditReversalList;
                List<ProviderCreditReversal> providerCreditReversalListmemberList = refundRequestProviderCreditReversalList.member;
                int providerCreditReversalListmemberListIndex = 1;
                foreach (ProviderCreditReversal providerCreditReversalListmember in providerCreditReversalListmemberList)
                {
                    if (providerCreditReversalListmember.IsSetProviderId())
                    {
                        parameters.Add("ProviderCreditReversalList" + "." + "member" + "." + providerCreditReversalListmemberListIndex + "." + "ProviderId", providerCreditReversalListmember.ProviderId + "");
                    }
                    if (providerCreditReversalListmember.IsSetCreditReversalAmount())
                    {
                        Price memberCreditReversalAmount = providerCreditReversalListmember.CreditReversalAmount;
                        if (memberCreditReversalAmount.IsSetAmount())
                        {
                            parameters.Add("ProviderCreditReversalList" + "." + "member" + "." + providerCreditReversalListmemberListIndex + "." + "CreditReversalAmount" + "." + "Amount", memberCreditReversalAmount.Amount + "");
                        }
                        if (memberCreditReversalAmount.IsSetCurrencyCode())
                        {
                            parameters.Add("ProviderCreditReversalList" + "." + "member" + "." + providerCreditReversalListmemberListIndex + "." + "CreditReversalAmount" + "." + "CurrencyCode", memberCreditReversalAmount.CurrencyCode);
                        }
                    }

                    providerCreditReversalListmemberListIndex++;
                }
            }
            return parameters;
        }


        /**
         * Convert CloseAuthorizationRequest to name value pairs
         */
        private IDictionary<String, String> ConvertCloseAuthorization(CloseAuthorizationRequest request)
        {

            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "CloseAuthorization");
            if (request.IsSetSellerId())
            {
                parameters.Add("SellerId", request.SellerId + "");
            }
            if (request.IsSetAmazonAuthorizationId())
            {
                parameters.Add("AmazonAuthorizationId", request.AmazonAuthorizationId + "");
            }
            if (request.IsSetClosureReason())
            {
                parameters.Add("ClosureReason", request.ClosureReason + "");
            }
            if (request.IsSetMWSAuthToken())
            {
                parameters.Add("MWSAuthToken", request.MWSAuthToken + "");
            }

            return parameters;
        }


        /**
         * Convert GetRefundDetailsRequest to name value pairs
         */
        private IDictionary<String, String> ConvertGetRefundDetails(GetRefundDetailsRequest request)
        {

            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "GetRefundDetails");
            if (request.IsSetSellerId())
            {
                parameters.Add("SellerId", request.SellerId + "");
            }
            if (request.IsSetAmazonRefundId())
            {
                parameters.Add("AmazonRefundId", request.AmazonRefundId + "");
            }
            if (request.IsSetMWSAuthToken())
            {
                parameters.Add("MWSAuthToken", request.MWSAuthToken + "");
            }
            return parameters;
        }


        /**
         * Convert GetCaptureDetailsRequest to name value pairs
         */
        private IDictionary<String, String> ConvertGetCaptureDetails(GetCaptureDetailsRequest request)
        {

            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "GetCaptureDetails");
            if (request.IsSetSellerId())
            {
                parameters.Add("SellerId", request.SellerId + "");
            }
            if (request.IsSetAmazonCaptureId())
            {
                parameters.Add("AmazonCaptureId", request.AmazonCaptureId + "");
            }
            if (request.IsSetMWSAuthToken())
            {
                parameters.Add("MWSAuthToken", request.MWSAuthToken + "");
            }
            return parameters;
        }


        /**
         * Convert CloseOrderReferenceRequest to name value pairs
         */
        private IDictionary<String, String> ConvertCloseOrderReference(CloseOrderReferenceRequest request)
        {

            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "CloseOrderReference");
            if (request.IsSetSellerId())
            {
                parameters.Add("SellerId", request.SellerId + "");
            }
            if (request.IsSetAmazonOrderReferenceId())
            {
                parameters.Add("AmazonOrderReferenceId", request.AmazonOrderReferenceId);
            }
            if (request.IsSetClosureReason())
            {
                parameters.Add("ClosureReason", request.ClosureReason + "");
            }
            if (request.IsSetMWSAuthToken())
            {
                parameters.Add("MWSAuthToken", request.MWSAuthToken + "");
            }
            return parameters;
        }


        /**
         * Convert ConfirmOrderReferenceRequest to name value pairs
         */
        private IDictionary<String, String> ConvertConfirmOrderReference(ConfirmOrderReferenceRequest request)
        {

            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "ConfirmOrderReference");
            if (request.IsSetAmazonOrderReferenceId())
            {
                parameters.Add("AmazonOrderReferenceId", request.AmazonOrderReferenceId);
            }
            if (request.IsSetSellerId())
            {
                parameters.Add("SellerId", request.SellerId + "");
            }
            if (request.IsSetMWSAuthToken())
            {
                parameters.Add("MWSAuthToken", request.MWSAuthToken + "");
            }
            return parameters;
        }


        /**
         * Convert GetOrderReferenceDetailsRequest to name value pairs
         */
        private IDictionary<String, String> ConvertGetOrderReferenceDetails(GetOrderReferenceDetailsRequest request)
        {

            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "GetOrderReferenceDetails");
            if (request.IsSetAmazonOrderReferenceId())
            {
                parameters.Add("AmazonOrderReferenceId", request.AmazonOrderReferenceId);
            }
            if (request.IsSetSellerId())
            {
                parameters.Add("SellerId", request.SellerId + "");
            }
            if (request.IsSetAddressConsentToken())
            {
                parameters.Add("AddressConsentToken", request.AddressConsentToken);
            }
            if (request.IsSetMWSAuthToken())
            {
                parameters.Add("MWSAuthToken", request.MWSAuthToken + "");
            }
            return parameters;
        }


        /**
         * Convert AuthorizeRequest to name value pairs
         */
        private IDictionary<String, String> ConvertAuthorize(AuthorizeRequest request)
        {

            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "Authorize");
            if (request.IsSetSellerId())
            {
                parameters.Add("SellerId", request.SellerId + "");
            }
            if (request.IsSetAmazonOrderReferenceId())
            {
                parameters.Add("AmazonOrderReferenceId", request.AmazonOrderReferenceId);
            }
            if (request.IsSetAuthorizationReferenceId())
            {
                parameters.Add("AuthorizationReferenceId", request.AuthorizationReferenceId + "");
            }
            if (request.IsSetAuthorizationAmount())
            {
                Price authorizeRequestAuthorizationAmount = request.AuthorizationAmount;
                if (authorizeRequestAuthorizationAmount.IsSetAmount())
                {
                    parameters.Add("AuthorizationAmount" + "." + "Amount", authorizeRequestAuthorizationAmount.Amount + "");
                }
                if (authorizeRequestAuthorizationAmount.IsSetCurrencyCode())
                {
                    parameters.Add("AuthorizationAmount" + "." + "CurrencyCode", authorizeRequestAuthorizationAmount.CurrencyCode);
                }
            }
            if (request.IsSetSellerAuthorizationNote())
            {
                parameters.Add("SellerAuthorizationNote", request.SellerAuthorizationNote + "");
            }
            if (request.IsSetOrderItemCategories())
            {
                OrderItemCategories authorizeRequestOrderItemCategories = request.OrderItemCategories;
                List<String> orderItemCategoriesOrderItemCategoryList = authorizeRequestOrderItemCategories.OrderItemCategory;
                int orderItemCategoriesOrderItemCategoryListIndex = 1;
                foreach (String orderItemCategoriesOrderItemCategory in orderItemCategoriesOrderItemCategoryList)
                {
                    parameters.Add("OrderItemCategories" + "." + "OrderItemCategory" + "." + orderItemCategoriesOrderItemCategoryListIndex, orderItemCategoriesOrderItemCategory);
                    orderItemCategoriesOrderItemCategoryListIndex++;
                }
            }
            if (request.IsSetTransactionTimeout())
            {
                parameters.Add("TransactionTimeout", request.TransactionTimeout + "");
            }
            if (request.IsSetCaptureNow())
            {
                parameters.Add("CaptureNow", ConvertBooleanToString(request.CaptureNow) + "");
            }
            if (request.IsSetSoftDescriptor())
            {
                parameters.Add("SoftDescriptor", request.SoftDescriptor + "");
            }
            if (request.IsSetMWSAuthToken())
            {
                parameters.Add("MWSAuthToken", request.MWSAuthToken + "");
            }
            if (request.IsSetProviderCreditList())
            {
                ProviderCreditList authorizeRequestProviderCreditList = request.ProviderCreditList;
                List<ProviderCredit> providerCreditListmemberList = authorizeRequestProviderCreditList.member;
                int providerCreditListmemberListIndex = 1;
                foreach (ProviderCredit providerCreditListmember in providerCreditListmemberList)
                {
                    if (providerCreditListmember.IsSetProviderId())
                    {
                        parameters.Add("ProviderCreditList" + "." + "member" + "." + providerCreditListmemberListIndex + "." + "ProviderId", providerCreditListmember.ProviderId + "");
                    }
                    if (providerCreditListmember.IsSetCreditAmount())
                    {
                        Price memberCreditAmount = providerCreditListmember.CreditAmount;
                        if (memberCreditAmount.IsSetAmount())
                        {
                            parameters.Add("ProviderCreditList" + "." + "member" + "." + providerCreditListmemberListIndex + "." + "CreditAmount" + "." + "Amount", memberCreditAmount.Amount + "");
                        }
                        if (memberCreditAmount.IsSetCurrencyCode())
                        {
                            parameters.Add("ProviderCreditList" + "." + "member" + "." + providerCreditListmemberListIndex + "." + "CreditAmount" + "." + "CurrencyCode", memberCreditAmount.CurrencyCode);
                        }
                    }

                    providerCreditListmemberListIndex++;
                }
            }
            return parameters;
        }

        /// <summary>
        /// Convert a boolean value into a lower case string value
        /// </summary>
        /// <param name="input">boolean type input</param>
        public static string ConvertBooleanToString(Boolean input)
        {
            return input.ToString().ToLower();
        }

        /**
         * Convert SetOrderReferenceDetailsRequest to name value pairs
         */
        private IDictionary<String, String> ConvertSetOrderReferenceDetails(SetOrderReferenceDetailsRequest request)
        {

            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "SetOrderReferenceDetails");
            if (request.IsSetSellerId())
            {
                parameters.Add("SellerId", request.SellerId + "");
            }
            if (request.IsSetAmazonOrderReferenceId())
            {
                parameters.Add("AmazonOrderReferenceId", request.AmazonOrderReferenceId);
            }
            if (request.IsSetMWSAuthToken())
            {
                parameters.Add("MWSAuthToken", request.MWSAuthToken + "");
            }
            if (request.IsSetOrderReferenceAttributes())
            {
                OrderReferenceAttributes setOrderReferenceDetailsRequestOrderReferenceAttributes = request.OrderReferenceAttributes;
                if (setOrderReferenceDetailsRequestOrderReferenceAttributes.IsSetOrderTotal())
                {
                    OrderTotal orderReferenceAttributesOrderTotal = setOrderReferenceDetailsRequestOrderReferenceAttributes.OrderTotal;
                    if (orderReferenceAttributesOrderTotal.IsSetCurrencyCode())
                    {
                        parameters.Add("OrderReferenceAttributes" + "." + "OrderTotal" + "." + "CurrencyCode", orderReferenceAttributesOrderTotal.CurrencyCode);
                    }
                    if (orderReferenceAttributesOrderTotal.IsSetAmount())
                    {
                        parameters.Add("OrderReferenceAttributes" + "." + "OrderTotal" + "." + "Amount", orderReferenceAttributesOrderTotal.Amount);
                    }
                }
                if (setOrderReferenceDetailsRequestOrderReferenceAttributes.IsSetPlatformId())
                {
                    parameters.Add("OrderReferenceAttributes" + "." + "PlatformId", setOrderReferenceDetailsRequestOrderReferenceAttributes.PlatformId);
                }
                if (setOrderReferenceDetailsRequestOrderReferenceAttributes.IsSetSellerNote())
                {
                    parameters.Add("OrderReferenceAttributes" + "." + "SellerNote", setOrderReferenceDetailsRequestOrderReferenceAttributes.SellerNote + "");
                }
                if (setOrderReferenceDetailsRequestOrderReferenceAttributes.IsSetSellerOrderAttributes())
                {
                    SellerOrderAttributes orderReferenceAttributesSellerOrderAttributes = setOrderReferenceDetailsRequestOrderReferenceAttributes.SellerOrderAttributes;
                    if (orderReferenceAttributesSellerOrderAttributes.IsSetSellerOrderId())
                    {
                        parameters.Add("OrderReferenceAttributes" + "." + "SellerOrderAttributes" + "." + "SellerOrderId", orderReferenceAttributesSellerOrderAttributes.SellerOrderId);
                    }
                    if (orderReferenceAttributesSellerOrderAttributes.IsSetStoreName())
                    {
                        parameters.Add("OrderReferenceAttributes" + "." + "SellerOrderAttributes" + "." + "StoreName", orderReferenceAttributesSellerOrderAttributes.StoreName);
                    }
                    if (orderReferenceAttributesSellerOrderAttributes.IsSetOrderItemCategories())
                    {
                        OrderItemCategories sellerOrderAttributesOrderItemCategories = orderReferenceAttributesSellerOrderAttributes.OrderItemCategories;
                        List<String> orderItemCategoriesOrderItemCategoryList = sellerOrderAttributesOrderItemCategories.OrderItemCategory;
                        int orderItemCategoriesOrderItemCategoryListIndex = 1;
                        foreach (String orderItemCategoriesOrderItemCategory in orderItemCategoriesOrderItemCategoryList)
                        {
                            parameters.Add("OrderReferenceAttributes" + "." + "SellerOrderAttributes" + "." + "OrderItemCategories" + "." + "OrderItemCategory" + "." + orderItemCategoriesOrderItemCategoryListIndex, orderItemCategoriesOrderItemCategory);
                            orderItemCategoriesOrderItemCategoryListIndex++;
                        }
                    }
                    if (orderReferenceAttributesSellerOrderAttributes.IsSetCustomInformation())
                    {
                        parameters.Add("OrderReferenceAttributes" + "." + "SellerOrderAttributes" + "." + "CustomInformation", orderReferenceAttributesSellerOrderAttributes.CustomInformation);
                    }
                }
            }

            return parameters;
        }


        /**
         * Convert GetAuthorizationDetailsRequest to name value pairs
         */
        private IDictionary<String, String> ConvertGetAuthorizationDetails(GetAuthorizationDetailsRequest request)
        {

            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "GetAuthorizationDetails");
            if (request.IsSetSellerId())
            {
                parameters.Add("SellerId", request.SellerId + "");
            }
            if (request.IsSetAmazonAuthorizationId())
            {
                parameters.Add("AmazonAuthorizationId", request.AmazonAuthorizationId + "");
            }
            if (request.IsSetMWSAuthToken())
            {
                parameters.Add("MWSAuthToken", request.MWSAuthToken + "");
            }

            return parameters;
        }


        /**
         * Convert CancelOrderReferenceRequest to name value pairs
         */
        private IDictionary<String, String> ConvertCancelOrderReference(CancelOrderReferenceRequest request)
        {

            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "CancelOrderReference");
            if (request.IsSetSellerId())
            {
                parameters.Add("SellerId", request.SellerId + "");
            }
            if (request.IsSetAmazonOrderReferenceId())
            {
                parameters.Add("AmazonOrderReferenceId", request.AmazonOrderReferenceId);
            }
            if (request.IsSetCancelationReason())
            {
                parameters.Add("CancelationReason", request.CancelationReason + "");
            }
            if (request.IsSetMWSAuthToken())
            {
                parameters.Add("MWSAuthToken", request.MWSAuthToken + "");
            }

            return parameters;
        }


        /**
         * Convert CreateOrderReferenceForIdRequest to name value pairs
         */
        private IDictionary<String, String> ConvertCreateOrderReferenceForId(CreateOrderReferenceForIdRequest request)
        {

            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "CreateOrderReferenceForId");
            if (request.IsSetId())
            {
                parameters.Add("Id", request.Id);
            }
            if (request.IsSetSellerId())
            {
                parameters.Add("SellerId", request.SellerId);
            }
            if (request.IsSetIdType())
            {
                parameters.Add("IdType", request.IdType);
            }
            if (request.IsSetInheritShippingAddress())
            {
                parameters.Add("InheritShippingAddress", request.InheritShippingAddress + "");
            }
            if (request.IsSetConfirmNow())
            {
                parameters.Add("ConfirmNow", ConvertBooleanToString(request.ConfirmNow) + "");
            }
            if (request.IsSetMWSAuthToken())
            {
                parameters.Add("MWSAuthToken", request.MWSAuthToken + "");
            }
            if (request.IsSetOrderReferenceAttributes())
            {
                OrderReferenceAttributes createOrderReferenceForIdRequestOrderReferenceAttributes = request.OrderReferenceAttributes;
                if (createOrderReferenceForIdRequestOrderReferenceAttributes.IsSetOrderTotal())
                {
                    OrderTotal orderReferenceAttributesOrderTotal = createOrderReferenceForIdRequestOrderReferenceAttributes.OrderTotal;
                    if (orderReferenceAttributesOrderTotal.IsSetCurrencyCode())
                    {
                        parameters.Add("OrderReferenceAttributes" + "." + "OrderTotal" + "." + "CurrencyCode", orderReferenceAttributesOrderTotal.CurrencyCode);
                    }
                    if (orderReferenceAttributesOrderTotal.IsSetAmount())
                    {
                        parameters.Add("OrderReferenceAttributes" + "." + "OrderTotal" + "." + "Amount", orderReferenceAttributesOrderTotal.Amount);
                    }
                }
                if (createOrderReferenceForIdRequestOrderReferenceAttributes.IsSetPlatformId())
                {
                    parameters.Add("OrderReferenceAttributes" + "." + "PlatformId", createOrderReferenceForIdRequestOrderReferenceAttributes.PlatformId);
                }
                if (createOrderReferenceForIdRequestOrderReferenceAttributes.IsSetSellerNote())
                {
                    parameters.Add("OrderReferenceAttributes" + "." + "SellerNote", createOrderReferenceForIdRequestOrderReferenceAttributes.SellerNote);
                }
                if (createOrderReferenceForIdRequestOrderReferenceAttributes.IsSetSellerOrderAttributes())
                {
                    SellerOrderAttributes orderReferenceAttributesSellerOrderAttributes = createOrderReferenceForIdRequestOrderReferenceAttributes.SellerOrderAttributes;
                    if (orderReferenceAttributesSellerOrderAttributes.IsSetSellerOrderId())
                    {
                        parameters.Add("OrderReferenceAttributes" + "." + "SellerOrderAttributes" + "." + "SellerOrderId", orderReferenceAttributesSellerOrderAttributes.SellerOrderId);
                    }
                    if (orderReferenceAttributesSellerOrderAttributes.IsSetStoreName())
                    {
                        parameters.Add("OrderReferenceAttributes" + "." + "SellerOrderAttributes" + "." + "StoreName", orderReferenceAttributesSellerOrderAttributes.StoreName);
                    }
                    if (orderReferenceAttributesSellerOrderAttributes.IsSetOrderItemCategories())
                    {
                        OrderItemCategories sellerOrderAttributesOrderItemCategories = orderReferenceAttributesSellerOrderAttributes.OrderItemCategories;
                        List<String> orderItemCategoriesOrderItemCategoryList = sellerOrderAttributesOrderItemCategories.OrderItemCategory;
                        int orderItemCategoriesOrderItemCategoryListIndex = 1;
                        foreach (String orderItemCategoriesOrderItemCategory in orderItemCategoriesOrderItemCategoryList)
                        {
                            parameters.Add("OrderReferenceAttributes" + "." + "SellerOrderAttributes" + "." + "OrderItemCategories" + "." + "OrderItemCategory" + "." + orderItemCategoriesOrderItemCategoryListIndex, orderItemCategoriesOrderItemCategory);
                            orderItemCategoriesOrderItemCategoryListIndex++;
                        }
                    }
                    if (orderReferenceAttributesSellerOrderAttributes.IsSetCustomInformation())
                    {
                        parameters.Add("OrderReferenceAttributes" + "." + "SellerOrderAttributes" + "." + "CustomInformation", orderReferenceAttributesSellerOrderAttributes.CustomInformation);
                    }
                }
            }

            return parameters;
        }


        /**
         * Convert GetBillingAgreementDetailsRequest to name value pairs
         */
        private IDictionary<String, String> ConvertGetBillingAgreementDetails(GetBillingAgreementDetailsRequest request)
        {

            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "GetBillingAgreementDetails");
            if (request.IsSetAmazonBillingAgreementId())
            {
                parameters.Add("AmazonBillingAgreementId", request.AmazonBillingAgreementId);
            }
            if (request.IsSetSellerId())
            {
                parameters.Add("SellerId", request.SellerId);
            }
            if (request.IsSetAddressConsentToken())
            {
                parameters.Add("AddressConsentToken", request.AddressConsentToken);
            }
            if (request.IsSetMWSAuthToken())
            {
                parameters.Add("MWSAuthToken", request.MWSAuthToken + "");
            }

            return parameters;
        }


        /**
         * Convert SetBillingAgreementDetailsRequest to name value pairs
         */
        private IDictionary<String, String> ConvertSetBillingAgreementDetails(SetBillingAgreementDetailsRequest request)
        {

            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "SetBillingAgreementDetails");
            if (request.IsSetSellerId())
            {
                parameters.Add("SellerId", request.SellerId);
            }
            if (request.IsSetAmazonBillingAgreementId())
            {
                parameters.Add("AmazonBillingAgreementId", request.AmazonBillingAgreementId);
            }
            if (request.IsSetMWSAuthToken())
            {
                parameters.Add("MWSAuthToken", request.MWSAuthToken + "");
            }
            if (request.IsSetBillingAgreementAttributes())
            {
                BillingAgreementAttributes setBillingAgreementDetailsRequestBillingAgreementAttributes = request.BillingAgreementAttributes;
                if (setBillingAgreementDetailsRequestBillingAgreementAttributes.IsSetPlatformId())
                {
                    parameters.Add("BillingAgreementAttributes" + "." + "PlatformId", setBillingAgreementDetailsRequestBillingAgreementAttributes.PlatformId);
                }
                if (setBillingAgreementDetailsRequestBillingAgreementAttributes.IsSetSellerNote())
                {
                    parameters.Add("BillingAgreementAttributes" + "." + "SellerNote", setBillingAgreementDetailsRequestBillingAgreementAttributes.SellerNote);
                }
                if (setBillingAgreementDetailsRequestBillingAgreementAttributes.IsSetSellerBillingAgreementAttributes())
                {
                    SellerBillingAgreementAttributes billingAgreementAttributesSellerBillingAgreementAttributes = setBillingAgreementDetailsRequestBillingAgreementAttributes.SellerBillingAgreementAttributes;
                    if (billingAgreementAttributesSellerBillingAgreementAttributes.IsSetSellerBillingAgreementId())
                    {
                        parameters.Add("BillingAgreementAttributes" + "." + "SellerBillingAgreementAttributes" + "." + "SellerBillingAgreementId", billingAgreementAttributesSellerBillingAgreementAttributes.SellerBillingAgreementId);
                    }
                    if (billingAgreementAttributesSellerBillingAgreementAttributes.IsSetStoreName())
                    {
                        parameters.Add("BillingAgreementAttributes" + "." + "SellerBillingAgreementAttributes" + "." + "StoreName", billingAgreementAttributesSellerBillingAgreementAttributes.StoreName);
                    }
                    if (billingAgreementAttributesSellerBillingAgreementAttributes.IsSetCustomInformation())
                    {
                        parameters.Add("BillingAgreementAttributes" + "." + "SellerBillingAgreementAttributes" + "." + "CustomInformation", billingAgreementAttributesSellerBillingAgreementAttributes.CustomInformation);
                    }
                }
            }

            return parameters;
        }


        /**
         * Convert ConfirmBillingAgreementRequest to name value pairs
         */
        private IDictionary<String, String> ConvertConfirmBillingAgreement(ConfirmBillingAgreementRequest request)
        {

            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "ConfirmBillingAgreement");
            if (request.IsSetSellerId())
            {
                parameters.Add("SellerId", request.SellerId);
            }
            if (request.IsSetAmazonBillingAgreementId())
            {
                parameters.Add("AmazonBillingAgreementId", request.AmazonBillingAgreementId);
            }
            if (request.IsSetMWSAuthToken())
            {
                parameters.Add("MWSAuthToken", request.MWSAuthToken + "");
            }
            return parameters;
        }


        /**
         * Convert ValidateBillingAgreementRequest to name value pairs
         */
        private IDictionary<String, String> ConvertValidateBillingAgreement(ValidateBillingAgreementRequest request)
        {

            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "ValidateBillingAgreement");
            if (request.IsSetAmazonBillingAgreementId())
            {
                parameters.Add("AmazonBillingAgreementId", request.AmazonBillingAgreementId);
            }
            if (request.IsSetSellerId())
            {
                parameters.Add("SellerId", request.SellerId);
            }

            return parameters;
        }


        /**
         * Convert AuthorizeOnBillingAgreementRequest to name value pairs
         */
        private IDictionary<String, String> ConvertAuthorizeOnBillingAgreement(AuthorizeOnBillingAgreementRequest request)
        {

            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "AuthorizeOnBillingAgreement");
            if (request.IsSetSellerId())
            {
                parameters.Add("SellerId", request.SellerId);
            }
            if (request.IsSetAmazonBillingAgreementId())
            {
                parameters.Add("AmazonBillingAgreementId", request.AmazonBillingAgreementId);
            }
            if (request.IsSetAuthorizationReferenceId())
            {
                parameters.Add("AuthorizationReferenceId", request.AuthorizationReferenceId);
            }
            if (request.IsSetMWSAuthToken())
            {
                parameters.Add("MWSAuthToken", request.MWSAuthToken + "");
            }
            if (request.IsSetAuthorizationAmount())
            {
                Price authorizeOnBillingAgreementRequestAuthorizationAmount = request.AuthorizationAmount;
                if (authorizeOnBillingAgreementRequestAuthorizationAmount.IsSetAmount())
                {
                    parameters.Add("AuthorizationAmount" + "." + "Amount", authorizeOnBillingAgreementRequestAuthorizationAmount.Amount);
                }
                if (authorizeOnBillingAgreementRequestAuthorizationAmount.IsSetCurrencyCode())
                {
                    parameters.Add("AuthorizationAmount" + "." + "CurrencyCode", authorizeOnBillingAgreementRequestAuthorizationAmount.CurrencyCode);
                }
            }
            if (request.IsSetSellerAuthorizationNote())
            {
                parameters.Add("SellerAuthorizationNote", request.SellerAuthorizationNote);
            }
            if (request.IsSetTransactionTimeout())
            {
                parameters.Add("TransactionTimeout", request.TransactionTimeout + "");
            }
            if (request.IsSetCaptureNow())
            {
                parameters.Add("CaptureNow", ConvertBooleanToString(request.CaptureNow) + "");
            }
            if (request.IsSetSoftDescriptor())
            {
                parameters.Add("SoftDescriptor", request.SoftDescriptor);
            }
            if (request.IsSetSellerNote())
            {
                parameters.Add("SellerNote", request.SellerNote);
            }
            if (request.IsSetPlatformId())
            {
                parameters.Add("PlatformId", request.PlatformId);
            }
            if (request.IsSetSellerOrderAttributes())
            {
                SellerOrderAttributes authorizeOnBillingAgreementRequestSellerOrderAttributes = request.SellerOrderAttributes;
                if (authorizeOnBillingAgreementRequestSellerOrderAttributes.IsSetSellerOrderId())
                {
                    parameters.Add("SellerOrderAttributes" + "." + "SellerOrderId", authorizeOnBillingAgreementRequestSellerOrderAttributes.SellerOrderId);
                }
                if (authorizeOnBillingAgreementRequestSellerOrderAttributes.IsSetStoreName())
                {
                    parameters.Add("SellerOrderAttributes" + "." + "StoreName", authorizeOnBillingAgreementRequestSellerOrderAttributes.StoreName);
                }
                if (authorizeOnBillingAgreementRequestSellerOrderAttributes.IsSetOrderItemCategories())
                {
                    OrderItemCategories sellerOrderAttributesOrderItemCategories = authorizeOnBillingAgreementRequestSellerOrderAttributes.OrderItemCategories;
                    List<String> orderItemCategoriesOrderItemCategoryList = sellerOrderAttributesOrderItemCategories.OrderItemCategory;
                    int orderItemCategoriesOrderItemCategoryListIndex = 1;
                    foreach (String orderItemCategoriesOrderItemCategory in orderItemCategoriesOrderItemCategoryList)
                    {
                        parameters.Add("SellerOrderAttributes" + "." + "OrderItemCategories" + "." + "OrderItemCategory" + "." + orderItemCategoriesOrderItemCategoryListIndex, orderItemCategoriesOrderItemCategory);
                        orderItemCategoriesOrderItemCategoryListIndex++;
                    }
                }
                if (authorizeOnBillingAgreementRequestSellerOrderAttributes.IsSetCustomInformation())
                {
                    parameters.Add("SellerOrderAttributes" + "." + "CustomInformation", authorizeOnBillingAgreementRequestSellerOrderAttributes.CustomInformation);
                }
            }
            if (request.IsSetInheritShippingAddress())
            {
                parameters.Add("InheritShippingAddress", request.InheritShippingAddress + "");
            }

            return parameters;
        }


        /**
         * Convert CloseBillingAgreementRequest to name value pairs
         */
        private IDictionary<String, String> ConvertCloseBillingAgreement(CloseBillingAgreementRequest request)
        {

            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "CloseBillingAgreement");
            if (request.IsSetAmazonBillingAgreementId())
            {
                parameters.Add("AmazonBillingAgreementId", request.AmazonBillingAgreementId);
            }
            if (request.IsSetSellerId())
            {
                parameters.Add("SellerId", request.SellerId);
            }
            if (request.IsSetClosureReason())
            {
                parameters.Add("ClosureReason", request.ClosureReason);
            }
            if (request.IsSetMWSAuthToken())
            {
                parameters.Add("MWSAuthToken", request.MWSAuthToken + "");
            }

            return parameters;
        }

        /**
         * Convert GetProviderCreditDetailsRequest to name value pairs
         */
        private IDictionary<String, String> ConvertGetProviderCreditDetails(GetProviderCreditDetailsRequest request)
        {

            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "GetProviderCreditDetails");
            if (request.IsSetSellerId())
            {
                parameters.Add("SellerId", request.SellerId + "");
            }
            if (request.IsSetAmazonProviderCreditId())
            {
                parameters.Add("AmazonProviderCreditId", request.AmazonProviderCreditId + "");
            }
            if (request.IsSetMWSAuthToken())
            {
                parameters.Add("MWSAuthToken", request.MWSAuthToken + "");
            }
            return parameters;
        }

        /**
         * Convert ReverseProviderCreditRequest to name value pairs
         */
        private IDictionary<String, String> ConvertReverseProviderCredit(ReverseProviderCreditRequest request)
        {

            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "ReverseProviderCredit");
            if (request.IsSetSellerId())
            {
                parameters.Add("SellerId", request.SellerId + "");
            }
            if (request.IsSetAmazonProviderCreditId())
            {
                parameters.Add("AmazonProviderCreditId", request.AmazonProviderCreditId + "");
            }
            if (request.IsSetCreditReversalReferenceId())
            {
                parameters.Add("CreditReversalReferenceId", request.CreditReversalReferenceId + "");
            }
            if (request.IsSetCreditReversalAmount())
            {
                Price reverseProviderCreditRequestCreditReversalAmount = request.CreditReversalAmount;
                if (reverseProviderCreditRequestCreditReversalAmount.IsSetAmount())
                {
                    parameters.Add("CreditReversalAmount" + "." + "Amount", reverseProviderCreditRequestCreditReversalAmount.Amount + "");
                }
                if (reverseProviderCreditRequestCreditReversalAmount.IsSetCurrencyCode())
                {
                    parameters.Add("CreditReversalAmount" + "." + "CurrencyCode", reverseProviderCreditRequestCreditReversalAmount.CurrencyCode);
                }
            }
            if (request.IsSetCreditReversalNote())
            {
                parameters.Add("CreditReversalNote", request.CreditReversalNote);
            }
            if (request.IsSetMWSAuthToken())
            {
                parameters.Add("MWSAuthToken", request.MWSAuthToken + "");
            }
            return parameters;
        }

        /**
         * Convert GetProviderCreditReversalDetailsRequest to name value pairs
         */
        private IDictionary<String, String> ConvertGetProviderCreditReversalDetails(GetProviderCreditReversalDetailsRequest request)
        {

            IDictionary<String, String> parameters = new Dictionary<String, String>();
            parameters.Add("Action", "GetProviderCreditReversalDetails");
            if (request.IsSetSellerId())
            {
                parameters.Add("SellerId", request.SellerId + "");
            }
            if (request.IsSetAmazonProviderCreditReversalId())
            {
                parameters.Add("AmazonProviderCreditReversalId", request.AmazonProviderCreditReversalId + "");
            }
            if (request.IsSetMWSAuthToken())
            {
                parameters.Add("MWSAuthToken", request.MWSAuthToken + "");
            }
            return parameters;
        }



    }
}
