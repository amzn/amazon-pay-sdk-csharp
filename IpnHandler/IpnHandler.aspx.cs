using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Net;
using Newtonsoft.Json.Linq;

namespace IpnHandler
{
    public partial class _Default : System.Web.UI.Page
    {
        private JObject parsedMessage;
        private X509Certificate2 x509Cert;
        private const string CertCN = "sns.amazonaws.com";

        // Cache key format string to avoid conflicts with other items in the application cache
        private const string CacheKey = "OffAmazonPaymentNotifciations:{0}";

        // Error string for unknown notificaton type
        private const string UnexpectedMessageErrStr = "Error with sns notification - unexpected message with Type of {0}";

        // Error string for missing sns header
        private const string MissingSnsHeaderErrStr = "Error with message - header does not contain x-amz-sns-message-type";

        // Error string for invalid sns header
        private const string InvalidSnsHeaderErrStr = "Error with sns message - header x-amz-sns-message-type is invalid";

        // Error string for null header object
        private const string MissingHeadersErrStr = "Expected headers to be passed, null value received";

        // Format string for ipn timestamps, in ISO8601 format with millseconds, in UTC
        private const string Iso8601UTCDateWithMillisecondsFormatString = @"yyyy-MM-ddTHH:mm:ss.fffZ";

        // Error string for unknown notification type
        private const string UnknownNotificationError
            = "Error with sns message verification - message is not of type Notification, no implementation of signing algorithm is present for other notification types";

        // Error string for unknown notification type
        private const string InvalidCertificateError
            = "Error with sns message verification - certificate in Notification is not a valid certificate issued to Amazon";

        // Error message for invalid json string
        private const string InvalidJsonErrMsg = "Error with message - content is not in json format";

        // Error message for a missing mandatory field
        private const string MissingMandatoryFieldErrMsg = "Error with message - mandatory field {0} cannot be found";

        // Error message for invalid cast to a date time object for a field value
        private const string FieldNotDateTimeErrMsgFormatString = "Error with message - expected field {0} to be DateTime object";

        // Error format string for unknown signature verification message
        private const string UnknownSignatureVerificationVersionErrStr
            = "Error with sns message verification - message is signed with unknown signature specification {0}";

        // Error format string for failing signature verification
        private const string SignatureVerificationFailedErrString
            = "Error with sns message - signature verification failed for message id {1}, topicArn {2}";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Stream s = Request.InputStream;
                StreamReader sr = new StreamReader(s);
                string json = sr.ReadToEnd();
                NameValueCollection headers = Request.Headers;
                if (json != null)
                {
                    //   File.AppendAllText(@"C:\Users\shrakuma\Desktop\file.txt", json + Environment.NewLine);
                    ParseRawMessage(headers, json);
                }
            }
            catch (Exception ex)
            {
                //  this.Response.StatusCode = 503;
                // Response.StatusDescription = "Service Unavailable";
                string fileName = @"C:\file.txt";
                using (StreamWriter sw = File.AppendText(fileName))
                {
                    sw.WriteLine(ex.Message);
                }
                Console.WriteLine(ex.Message);
            }
        }

        /*
         * Convert a raw http POST request that contains an IPN and
         * convert to an object
         * 
         * Will throw a Exception if the content is not a valid IPN
         * 
         * Callers are expected to return a 503 http code an exception is
         * thrown by this method, otherwise reply with a HTTP OK status
         * 
         * <param name="headers">HTTP request headers</param>
         * <param name="body">HTTP POST body content</param>
         * <returns>Instance of an INotification that matches the notification type</returns>
         */

        public void ParseRawMessage(NameValueCollection headers, string body)
        {
            ParseNotification(headers, body);
            ValidateMessageIsTrusted();
            //ParseSnsMessage(snsMessage);
        }

        /*
         * Parse a json string in an sns format and convert it
         * into a message object that stores key/value pairs
         * <param name="headers">Sns headers</param>
         * <param name="snsJson">Sns json string</param>
         * <returns>Message</returns>
         */

        public void ParseNotification(NameValueCollection headers, string snsJson)
        {
            //  ValidateHeader(headers);
            parseMessage(snsJson);
            ValidateMessageType();
        }

        /*
         * Check the sns headers to ensure that the notification
         * is valid
         * </summary>
         * <param name="headers">Sns header collection</param>
         */

        private static void ValidateHeader(NameValueCollection headers)
        {
            string messageType = null;

            try
            {
                messageType = headers["x-amz-sns-message-type"];
            }
            catch (NullReferenceException nre)
            {
                File.AppendAllText(@"c:\file.txt", MissingHeadersErrStr + Environment.NewLine);
                throw new Exception(MissingHeadersErrStr, nre);

            }

            if (messageType == null)
            {
                File.AppendAllText(@"c:\file.txt", MissingHeadersErrStr + Environment.NewLine);
                throw new Exception(MissingSnsHeaderErrStr);
            }

            if (!messageType.Equals("Notification", StringComparison.InvariantCultureIgnoreCase))
            {
                File.AppendAllText(@"c:\file.txt", InvalidSnsHeaderErrStr + Environment.NewLine);
                throw new Exception(String.Format(InvalidSnsHeaderErrStr, messageType));
            }
        }

        /*
         * Ensure that the sns message is the valid notificaton type
         * <param name="msg">SNS message</param>
         */

        private void ValidateMessageType()
        {
            string notificatonType = GetMandatoryField("Type");
            if (!notificatonType.Equals("Notification", StringComparison.InvariantCultureIgnoreCase))
            {
                File.AppendAllText(@"c:\file.txt", UnexpectedMessageErrStr + Environment.NewLine);
                throw new Exception(String.Format(UnexpectedMessageErrStr, notificatonType));
            }
        }


        /*
         * Create a new message the acts as a wrapper
         * around the json string
         * </summary>
         * <throws>NotificationException if the string is not valid json</throws>
         * <param name="json">A valid json string</param>
         */

        public void parseMessage(string json)
        {
            try
            {
                this.parsedMessage = JObject.Parse(json);
            }
            catch (Exception ex)
            {
                File.AppendAllText(@"c:\file.txt", InvalidJsonErrMsg + Environment.NewLine);
                throw new Exception(InvalidJsonErrMsg, ex);
            }
        }


        /*
         * Return the value associated with the field name,
         * throws an exception if it cannot be found
         * <param name="fieldName">Name of the field to retrieve</param>
         * <returns>value of the field</returns>
         */
        public string GetMandatoryField(string fieldName)
        {
            JToken value = GetValueAsToken(fieldName);
            return value.ToString();
        }

        /*
         * Return the value of the field as a timestamp
         * <param name="fieldName">Field name containing timestamp data</param>
         * <returns>DateTime representation of the object</returns>
         */
        public DateTime GetMandatoryFieldAsDateTime(string fieldName)
        {
            try
            {
                return (DateTime)GetValueAsToken(fieldName);
            }
            catch (FormatException fe)
            {
                File.AppendAllText(@"c:\file.txt", FieldNotDateTimeErrMsgFormatString + Environment.NewLine);
                throw new Exception(String.Format(FieldNotDateTimeErrMsgFormatString, fieldName), fe);
            }
        }

        /*
         * Return the JToken associated with this field,
         * otherwise throw an exception
         * </summary>
         * <param name="fieldName">Name of the field to retrieve</param>
         * <returns>Filed as JToken</returns>
         */
        private JToken GetValueAsToken(string fieldName)
        {
            JToken value = this.parsedMessage.GetValue(fieldName);

            if (value == null)
            {
                File.AppendAllText(@"c:\file.txt", MissingMandatoryFieldErrMsg + Environment.NewLine);
                throw new Exception(String.Format(MissingMandatoryFieldErrMsg, fieldName));
            }
            return value;
        }

        /*
         * Get the value associated with this field,
         * or return null if not present
         * </summary>
         * <param name="fieldName">Name of the field to retrieve</param>
         * <returns>String or null if not defined</returns>
         */

        public String GetField(string fieldName)
        {
            JToken value = this.parsedMessage.GetValue(fieldName);
            if (value != null)
            {
                return value.ToString();
            }
            else
            {
                return null;
            }
        }

        public void ValidateMessageIsTrusted()
        {
            string signatureVersion = GetMandatoryField("SignatureVersion");
            switch (signatureVersion)
            {
                case "1":
                    VerifySnsMessageWithVersion1SignatureAlgorithm();
                    break;
                default:
                    File.AppendAllText(@"c:\file.txt", UnknownSignatureVerificationVersionErrStr + Environment.NewLine);
                    throw new Exception(String.Format(UnknownSignatureVerificationVersionErrStr, signatureVersion));
            }
        }

        /*
         * Invoke the version 1 signature algorithm and throw an exception if it fails
         * <param name="snsMessage">Sns message to verify</param>
         */

        private void VerifySnsMessageWithVersion1SignatureAlgorithm()
        {
            bool isValid = VerifyMsgMatchesSignatureV1WithCert();
            if (!isValid)
            {
                File.AppendAllText(@"c:\file.txt", SignatureVerificationFailedErrString + Environment.NewLine);
                throw new Exception(String.Format(SignatureVerificationFailedErrString, "1"));
            }
        }



        /* 
         * Perform the comparison of the message data with the signature,
         * as described on http://docs.aws.amazon.com/sns/latest/dg/SendMessageToHttp.verify.signature.html,
         * for version 1 of the signature algorithm
         * <param name="snsMessage">Sns message with metadata</param>
         * <returns>true if verified, otherwise false</returns>
         */

        public bool VerifyMsgMatchesSignatureV1WithCert()
        {
            if (!GetMandatoryField("Type").Equals("Notification"))
            {
                File.AppendAllText(@"c:\file.txt", UnknownNotificationError + Environment.NewLine);
                throw new Exception(UnknownNotificationError);
            }

            string certPath = GetMandatoryField("SigningCertURL");
            x509Cert = GetCertificate(certPath);
            if (!VerifyCertIsIssuedByAmazon())
            {
                File.AppendAllText(@"c:\file.txt", InvalidCertificateError + Environment.NewLine);
                throw new Exception(InvalidCertificateError);
            }

            UTF8Encoding encoding = new UTF8Encoding();
            string msg = GetMessageToSign();
            byte[] data = encoding.GetBytes(msg);

            // Server signature uses base 64 encoding, must desconstruct
            byte[] decodedSignature = Convert.FromBase64String(GetMandatoryField("Signature"));

            return VerifyMsgMatchesSignatureWithPublicCert(data, decodedSignature);
        }

        /* 
         * Extract the contents of the message and build a string to hash in order to verify the signature
         * 
         * Expected string is a single string in format field name\n field value\n, with the field names in alphabetical byte order (e.g. A-Za-z)
         * notification use the Message, MessageId, Subject if provided, Timestamp, TopicArn & Type fields
         * <param name="snsMessage">Sns message with metadata</param>
         * <returns>Signature comparison string, unhashed</returns>
         */

        private string GetMessageToSign()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("Message\n");
            builder.Append(GetMandatoryField("Message"));
            builder.Append("\n");
            builder.Append("MessageId\n");
            builder.Append(GetMandatoryField("MessageId"));
            builder.Append("\n");
            String subject = GetField("Subject");
            if (subject != null)
            {
                builder.Append("Subject\n");
                builder.Append(subject);
                builder.Append("\n");
            }
            builder.Append("Timestamp\n");
            builder.Append(GetMandatoryFieldAsDateTime("Timestamp")
                .ToString(Iso8601UTCDateWithMillisecondsFormatString, System.Globalization.CultureInfo.InvariantCulture));
            builder.Append("\n");
            builder.Append("TopicArn\n");
            builder.Append(GetMandatoryField("TopicArn"));
            builder.Append("\n");
            builder.Append("Type\n");
            builder.Append(GetMandatoryField("Type"));
            builder.Append("\n");

            return builder.ToString();
        }

        /* <summary>
         * Verify that certificate is valid and issued by Amazon.
         * </summary>
         * <param name="snsMessage">URI path to public key certificate to hash the constructed data</param>
         */
        public bool VerifyCertIsIssuedByAmazon()
        {
            return VerifyCertificateChain() && VerifyCertificateSubject(GetSubject());
        }

        private bool VerifyCertificateSubject(String subject)
        {
            string[] subjectAttributeDelimiters = new string[] { ", " };
            string[] subjectAttributesArr = subject.Split(subjectAttributeDelimiters, StringSplitOptions.None);
            List<string> subjectAttributesList = convertSubjectAttributesArr(subjectAttributesArr);

            Dictionary<string, string> subjectAttributes = new Dictionary<string, string>();
            char[] keyValueDelimiter = { '=' };
            foreach (string subjectAttribute in subjectAttributesList)
            {

                string[] keyValuePair = subjectAttribute.Split(keyValueDelimiter, 2);
                string key = keyValuePair[0];
                string value = keyValuePair[1];

                if (subjectAttributes.ContainsKey(key))
                {
                    // indicates certificate tampering, as we have an invalid subject with duplicate key types
                    return false;
                }
                else
                {
                    subjectAttributes.Add(key, value);
                }
            }
            return ContainsAttribute(subjectAttributes, "CN", CertCN);
        }

        private List<string> convertSubjectAttributesArr(string[] subjectAttributesArr)
        {
            // Because ', ' is the delimiter, the value "Amazon.com, Inc." will get delimited when splitting the string.
            // This algorithm will merge the two delimited strings "Amazon.com" and "Inc." back into "Amazon.com, Inc.".
            List<string> subjectAttributes = new List<string>();
            for (int i = 0; i < subjectAttributesArr.Length; i++)
            {
                string subjectAttribute = subjectAttributesArr[i];
                if (!subjectAttribute.Contains("="))
                {
                    subjectAttributes[i - 1] = subjectAttributes[i - 1] + ", " + subjectAttribute;
                }
                else
                {
                    subjectAttributes.Add(subjectAttribute);
                }
            }

            return subjectAttributes;
        }

        private bool ContainsAttribute(Dictionary<string, string> subjectAttributes, string attributeKey, string attributeValue)
        {
            string actualValue;
            if (!subjectAttributes.TryGetValue(attributeKey, out actualValue))
            {
                return false;
            }

            return actualValue == attributeValue;
        }

        /*
         * Perform the comparison of the message data with the signature,
         * as described on http://docs.aws.amazon.com/sns/latest/dg/SendMessageToHttp.verify.signature.html,
         * for version 1 of the signature algorithm
         * <param name="data">Byte data to compare using a SHA1 hash</param>
         * <param name="signature">Decoded signature byte array</param>
         * <param name="certPath">URI path to public key certificate to hash the constructed data</param>
         * <returns>true if successful</returns>
         */

        public bool VerifyMsgMatchesSignatureWithPublicCert(byte[] data, byte[] signature)
        {
            RSACryptoServiceProvider csp = (RSACryptoServiceProvider)GetPublicKey();
            return csp.VerifyData(data, CryptoConfig.MapNameToOID("SHA1"), signature);
        }

        /*
         * Check the application cache for the certificate, and use this if still valid
         * If not found, request the cert and add to the cache with a timeout of 24 hours
         * <param name="certPath">URI path to certificate</param>
         * <returns>Instance of the x508 certificate</returns>
         */
        private X509Certificate2 GetCertificate(string certPath)
        {
            X509Certificate2 cert = null;
            try
            {
                cert = (X509Certificate2)HttpRuntime.Cache.Get(String.Format(CacheKey, certPath));
            }
            catch (HttpException ex)
            {
                File.AppendAllText(@"c:\file.txt", "Error requesting certificate" + Environment.NewLine);
                throw new Exception("Error requesting certificate", ex);
            }

            if (cert == null)
            {
                cert = GetCertificateFromURI(certPath);
                HttpRuntime.Cache.Insert(String.Format(CacheKey, certPath), cert, null, DateTime.UtcNow.AddDays(1.0), System.Web.Caching.Cache.NoSlidingExpiration);
            }

            return cert;
        }

        /*
         * Request the certifcate from the given URI
         * <param name="certPath">URI path to certificate</param>
         * <returns>Instance of the x508 certificate</returns>
         */

        private X509Certificate2 GetCertificateFromURI(string certPath)
        {
            WebClient wc = new WebClient();
            byte[] raw = wc.DownloadData(certPath);
            return new X509Certificate2(raw);
        }

        /*
         * Performs certificate chain validation using basic validation policy
         */

        public bool VerifyCertificateChain()
        {
            return x509Cert.Verify();
        }

        /*
         * Gets certificate's subject information
         */
        public String GetSubject()
        {
            return x509Cert.Subject;
        }

        /*
         * Gets AsymmetricAlgorithm representing the certificate's public key
         */

        public AsymmetricAlgorithm GetPublicKey()
        {
            return x509Cert.PublicKey.Key;
        }
    }
}