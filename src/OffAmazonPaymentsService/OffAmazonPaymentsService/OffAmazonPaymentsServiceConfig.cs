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
using System.Text;
using System.Text.RegularExpressions;

namespace OffAmazonPaymentsService
{

    /// <summary>
    /// Configuration for accessing Off Amazon Payments Service  service
    /// </summary>
    public class OffAmazonPaymentsServiceConfig
    {

        private String serviceVersion = "2013-01-01";
        private String serviceURL = null;
        private String userAgent = null;
        private String signatureVersion = "2";
        private String signatureMethod = "HmacSHA256";
        private String proxyHost = null;
        private int proxyPort = -1;
        private int maxErrorRetry = 3;

        // Client Library User-Agent 
        private String mwsClientVersion = "2013-01-01";
        private String applicationLibraryVersion = "1.0.0.9";

        /// <summary>
        /// Gets Service Version
        /// </summary>
        public String ServiceVersion
        {
            get { return this.serviceVersion; }
        }
        /// <summary>
        /// Gets and sets of the signatureMethod property.
        /// </summary>
        public String SignatureMethod
        {
            get { return this.signatureMethod; }
            set { this.signatureMethod = value; }
        }

        /// <summary>
        /// Sets the SignatureMethod property
        /// </summary>
        /// <param name="signatureMethod">SignatureMethod property</param>
        /// <returns>this instance</returns>
        public OffAmazonPaymentsServiceConfig WithSignatureMethod(String signatureMethod)
        {
            this.signatureMethod = signatureMethod;
            return this;
        }


        /// <summary>
        /// Checks if SignatureMethod property is set
        /// </summary>
        /// <returns>true if SignatureMethod property is set</returns>
        public Boolean IsSetSignatureMethod()
        {
            return this.signatureMethod != null;
        }
        /// <summary>
        /// Gets and sets of the SignatureVersion property.
        /// </summary>
        public String SignatureVersion
        {
            get { return this.signatureVersion; }
            set { this.signatureVersion = value; }
        }

        /// <summary>
        /// Sets the SignatureVersion property
        /// </summary>
        /// <param name="signatureVersion">SignatureVersion property</param>
        /// <returns>this instance</returns>
        public OffAmazonPaymentsServiceConfig WithSignatureVersion(String signatureVersion)
        {
            this.signatureVersion = signatureVersion;
            return this;
        }

        /// <summary>
        /// Checks if SignatureVersion property is set
        /// </summary>
        /// <returns>true if SignatureVersion property is set</returns>
        public Boolean IsSetSignatureVersion()
        {
            return this.signatureVersion != null;
        }

        /// <summary>
        /// Gets the UserAgent property.
        /// </summary>
        public String UserAgent
        {
            get { return this.userAgent; }
        }

        /// <summary>
        /// Sets the UserAgent property
        /// </summary>
        /// <param name="applicationName">Your application's name, e.g. "MyMWSApp"</param>
        /// <param name="applicationVersion">Your application's version, e.g. "1.0"</param>
        /// <returns>this instance</returns>
        public OffAmazonPaymentsServiceConfig WithUserAgent(String applicationName, String applicationVersion)
        {
            this.ConfigureUserAgentHeader(applicationName, applicationVersion);
            return this;
        }

        public void SetUserAgent(String applicationName, String applicationVersion)
        {
            this.ConfigureUserAgentHeader(applicationName, applicationVersion);
        }

        /// <summary>
        /// Checks if UserAgent property is set
        /// </summary>
        /// <returns>true if UserAgent property is set</returns>
        public Boolean IsSetUserAgent()
        {
            return this.userAgent != null;
        }

        /// <summary>
        /// Gets and sets of the ServiceURL property.
        /// </summary>
        public String ServiceURL
        {
            get { return this.serviceURL; }
            set { this.serviceURL = value; }
        }

        /// <summary>
        /// Sets the ServiceURL property
        /// </summary>
        /// <param name="serviceURL">ServiceURL property</param>
        /// <returns>this instance</returns>
        public OffAmazonPaymentsServiceConfig WithServiceURL(String serviceURL)
        {
            this.serviceURL = serviceURL;
            return this;
        }

        /// <summary>
        /// Checks if ServiceURL property is set
        /// </summary>
        /// <returns>true if ServiceURL property is set</returns>
        public Boolean IsSetServiceURL()
        {
            return this.serviceURL != null;
        }

        /// <summary>
        /// Gets and sets of the ProxyHost property.
        /// </summary>
        public String ProxyHost
        {
            get { return this.proxyHost; }
            set { this.proxyHost = value; }
        }

        /// <summary>
        /// Sets the ProxyHost property
        /// </summary>
        /// <param name="proxyHost">ProxyHost property</param>
        /// <returns>this instance</returns>
        public OffAmazonPaymentsServiceConfig WithProxyHost(String proxyHost)
        {
            this.proxyHost = proxyHost;
            return this;
        }

        /// <summary>
        /// Checks if ProxyHost property is set
        /// </summary>
        /// <returns>true if ProxyHost property is set</returns>
        public Boolean IsSetProxyHost()
        {
            return this.proxyHost != null;
        }

        /// <summary>
        /// Gets and sets of the ProxyPort property.
        /// </summary>
        public int ProxyPort
        {
            get { return this.proxyPort; }
            set { this.proxyPort = value; }
        }

        /// <summary>
        /// Sets the ProxyPort property
        /// </summary>
        /// <param name="proxyPort">ProxyPort property</param>
        /// <returns>this instance</returns>
        public OffAmazonPaymentsServiceConfig WithProxyPort(int proxyPort)
        {
            this.proxyPort = proxyPort;
            return this;
        }

        /// <summary>
        /// Checks if ProxyPort property is set
        /// </summary>
        /// <returns>true if ProxyPort property is set</returns>
        public Boolean IsSetProxyPort()
        {
            return this.proxyPort != -1;
        }

        /// <summary>
        /// Gets and sets of the MaxErrorRetry property.
        /// </summary>
        public int MaxErrorRetry
        {
            get { return this.maxErrorRetry; }
            set { this.maxErrorRetry = value; }
        }

        /// <summary>
        /// Sets the MaxErrorRetry property
        /// </summary>
        /// <param name="maxErrorRetry">MaxErrorRetry property</param>
        /// <returns>this instance</returns>
        public OffAmazonPaymentsServiceConfig WithMaxErrorRetry(int maxErrorRetry)
        {
            this.maxErrorRetry = maxErrorRetry;
            return this;
        }

        /// <summary>
        /// Checks if MaxErrorRetry property is set
        /// </summary>
        /// <returns>true if MaxErrorRetry property is set</returns>
        public Boolean IsSetMaxErrorRetry()
        {
            return this.maxErrorRetry != -1;
        }

        private void ConfigureUserAgentHeader(String applicationName, String applicationVersion)
        {
            SetUserAgentHeader(
                applicationName,
                applicationVersion,
                "C#",
                "CLI", Environment.Version.ToString(),
                "Platform", Environment.OSVersion.Platform + "/" + Environment.OSVersion.Version,
                "MWSClientVersion", mwsClientVersion,
                "ApplicationLibraryVersion", applicationLibraryVersion);
        }

        private void SetUserAgentHeader(
            string applicationName,
            string applicationVersion,
            string programmingLanguage,
            params string[] additionalNameValuePairs)
        {
            if (applicationName == null)
            {
                throw new ArgumentNullException("applicationName", "Value cannot be null.");
            }

            if (applicationVersion == null)
            {
                throw new ArgumentNullException("applicationVersion", "Value cannot be null.");
            }

            if (programmingLanguage == null)
            {
                throw new ArgumentNullException("programmingLanguage", "Value cannot be null.");
            }

            if (additionalNameValuePairs.Length % 2 != 0)
            {
                throw new ArgumentException("additionalNameValuePairs", "Every name must have a corresponding value.");
            }

            StringBuilder sb = new StringBuilder();

            sb.Append(QuoteApplicationName(applicationName));
            sb.Append("/");
            sb.Append(QuoteApplicationVersion(applicationVersion));
            sb.Append(" (");
            sb.Append("Language=");
            sb.Append(QuoteAttributeValue(programmingLanguage));

            int i = 0;
            while (i < additionalNameValuePairs.Length)
            {
                string name = additionalNameValuePairs[i];
                string value = additionalNameValuePairs[++i];
                sb.Append("; ");
                sb.Append(QuoteAttributeName(name));
                sb.Append("=");
                sb.Append(QuoteAttributeValue(value));

                i++;
            }

            sb.Append(")");

            this.userAgent = sb.ToString();
        }

        /// <summary>
        /// Replace all whitespace characters by a single space.
        /// </summary>
        private static string Clean(string s)
        {
            // matched character sequences are passed to a MatchEvaluator
            // delegate. The returned string from the delegate replaces
            // the matched sequence.
            return Regex.Replace(s, @" {2,}|\s", delegate(Match m)
            {
                return " ";
            });
        }

        /// <summary>
        /// Collapse whitespace, and escape the following characters are escaped:
        /// '\', and '/'.
        /// </summary>
        private static string QuoteApplicationName(string s)
        {
            return Clean(s).Replace(@"\", @"\\").Replace("@/", @"\/");
        }

        /// <summary>
        /// Collapse whitespace, and escape the following characters are escaped:
        /// '\', and '('.
        /// </summary>
        private static string QuoteApplicationVersion(string s)
        {
            return Clean(s).Replace(@"\", @"\\").Replace(@"(", @"\(");
        }

        /// <summary>
        /// Collapse whitespace, and escape the following characters are escaped:
        /// '\', and '='.
        /// </summary>
        private static string QuoteAttributeName(string s)
        {
            return Clean(s).Replace(@"\", @"\\").Replace(@"=", @"\=");
        }

        /// <summary>
        /// Collapse whitespace, and escape the following characters are escaped:
        /// ')', '\', and ';'.
        /// </summary>
        private static string QuoteAttributeValue(string s)
        {
            return Clean(s).Replace(@"\", @"\\").Replace(@";", @"\;").Replace(@")", @"\)");
        }

    }
}
