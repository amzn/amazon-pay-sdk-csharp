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
using Newtonsoft.Json;
using PayWithAmazon;
using System.Xml;


namespace PayWithAmazon
{
    public class IpnHandler
    {
        private JObject parsedMessage;
        private X509Certificate2 x509Cert;
        private const string CertCN = "sns.amazonaws.com";

        // Cache key format string to avoid conflicts with other items in the application cache
        private const string CacheKey = "PayWithAmazonNotification";

        // Format string for ipn timestamps, in ISO8601 format with millseconds, in UTC
        private const string Iso8601UTCDateWithMillisecondsFormatString = @"yyyy-MM-ddTHH:mm:ss.fffZ";

        public IpnHandler(string json, NameValueCollection headers)
        {
            try
            {

                if (!string.IsNullOrEmpty(json))
                {
                    ParseRawMessage(headers, json);
                }
            }
            catch (Exception ex)
            {
                throw new HttpParseException("Error Parsing the IPN notification", ex);
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
        }

        /* Parse a json string in an sns format and convert it
         * into a message object that stores key/value pairs
         * <param name="headers">Sns headers</param>
         * <param name="snsJson">Sns json string</param>
         * <returns>Message</returns>
         */

        public void ParseNotification(NameValueCollection headers, string snsJson)
        {
            ValidateHeader(headers);
            parseMessage(snsJson);
            ValidateMessageType();
        }

        /* Check the sns headers to ensure that the notification is valid */

        private static void ValidateHeader(NameValueCollection headers)
        {
            string messageType = null;

            try
            {
                messageType = headers["x-amz-sns-message-type"];
            }
            catch (NullReferenceException nre)
            {
                throw new Exception("Expected headers to be passed, null value received", nre);
            }

            if (messageType == null)
            {
                throw new Exception("Error with message - header does not contain x-amz-sns-message-type");
            }

            if (!messageType.Equals("Notification", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new Exception(String.Format("Error with sns message - header x-amz-sns-message-type is invalid", messageType));
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
                throw new Exception(String.Format("Error with sns notification - unexpected message with Type of ", notificatonType));
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
                throw new Exception("Error with message - content is not in json format", ex);
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

        /* Return the value of the field as a timestamp
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
                throw new Exception(String.Format("Error with message - expected field should be of type DateTime object", fieldName), fe);
            }
        }

        /* Return the JToken associated with this field,
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
                throw new Exception(String.Format("Error with message - mandatory field cannot be found", fieldName));
            }
            return value;
        }

        /* Get the value associated with this field,
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
                    throw new Exception(String.Format("Error with sns message verification - message is signed with unknown signature specification", signatureVersion));
            }
        }

        /* Invoke the version 1 signature algorithm and throw an exception if it fails
         * <param name="snsMessage">Sns message to verify</param>
         */

        private void VerifySnsMessageWithVersion1SignatureAlgorithm()
        {
            bool isValid = VerifyMsgMatchesSignatureV1WithCert();
            if (!isValid)
            {
                throw new Exception(String.Format("Error with sns message - signature verification failed", "1"));
            }
        }



        /* Perform the comparison of the message data with the signature,
         * as described on http://docs.aws.amazon.com/sns/latest/dg/SendMessageToHttp.verify.signature.html,
         * for version 1 of the signature algorithm
         * <param name="snsMessage">Sns message with metadata</param>
         * <returns>true if verified, otherwise false</returns>
         */

        public bool VerifyMsgMatchesSignatureV1WithCert()
        {
            if (!GetMandatoryField("Type").Equals("Notification"))
            {
                throw new Exception("Error with sns message verification - message is not of type Notification, no implementation of signing algorithm is present for other notification types");
            }

            string certPath = GetMandatoryField("SigningCertURL");
            x509Cert = GetCertificate(certPath);
            if (!VerifyCertIsIssuedByAmazon())
            {
                throw new Exception("Error with sns message verification - certificate in Notification is not a valid certificate issued to Amazon");
            }

            UTF8Encoding encoding = new UTF8Encoding();
            string msg = GetMessageToSign();
            byte[] data = encoding.GetBytes(msg);

            // Server signature uses base 64 encoding, must desconstruct
            byte[] decodedSignature = Convert.FromBase64String(GetMandatoryField("Signature"));

            return VerifyMsgMatchesSignatureWithPublicCert(data, decodedSignature);
        }

        /* Extract the contents of the message and build a string to hash in order to verify the signature
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

        /* Verify that certificate is valid and issued by Amazon.
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

        /* Perform the comparison of the message data with the signature,
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

        /* Check the application cache for the certificate, and use this if still valid
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
                throw new Exception("Error requesting certificate", ex);
            }

            if (cert == null)
            {
                cert = GetCertificateFromURI(certPath);
                HttpRuntime.Cache.Insert(String.Format(CacheKey, certPath), cert, null, DateTime.UtcNow.AddDays(1.0), System.Web.Caching.Cache.NoSlidingExpiration);
            }

            return cert;
        }

        /* Request the certifcate from the given URI
         * <param name="certPath">URI path to certificate</param>
         * <returns>Instance of the x508 certificate</returns>
         */

        private X509Certificate2 GetCertificateFromURI(string certPath)
        {
            WebClient wc = new WebClient();
            byte[] raw = wc.DownloadData(certPath);
            return new X509Certificate2(raw);
        }

        /*  Performs certificate chain validation using basic validation policy */

        public bool VerifyCertificateChain()
        {
            return x509Cert.Verify();
        }

        /* Gets certificate's subject information */

        public String GetSubject()
        {
            return x509Cert.Subject;
        }

        /* Gets AsymmetricAlgorithm representing the certificate's public key */

        public AsymmetricAlgorithm GetPublicKey()
        {
            return x509Cert.PublicKey.Key;
        }

        public string ToJson()
        {
            string xmlResponse;
            string json;

            Dictionary<string, string> remainingFields = GetRemainingIpnFields();
            string remFieldsAsJson = JsonConvert.SerializeObject(remainingFields, Newtonsoft.Json.Formatting.Indented);

            remFieldsAsJson = remFieldsAsJson.Replace("{", "").Replace(System.Environment.NewLine + "}", "");

            JObject message = JObject.Parse(this.parsedMessage.GetValue("Message").ToString());
            xmlResponse = message.GetValue("NotificationData").ToString().Trim();

            var xml = new XmlDocument();
            xml.LoadXml(xmlResponse);

            json = JsonConvert.SerializeObject(xml, Newtonsoft.Json.Formatting.Indented);

            int index = json.IndexOf("{");
            json = json.Insert(index + "{".Length, remFieldsAsJson + ",");
            return json;
        }

        public string ToXml()
        {
            Dictionary<string, string> remainingFields = GetRemainingIpnFields();
            string remFieldsAsJson = JsonConvert.SerializeObject(remainingFields, Newtonsoft.Json.Formatting.Indented);

            XmlDocument doc = (XmlDocument)JsonConvert.DeserializeXmlNode(remFieldsAsJson, "root");

            JObject message = JObject.Parse(this.parsedMessage.GetValue("Message").ToString());
            string xmlResponse = message.GetValue("NotificationData").ToString().Trim();

            string remFields = doc.OuterXml.ToString();
            remFields = remFields.Replace("<root>", "").Replace("</root>", "");
            int index = xmlResponse.LastIndexOf("</");
            xmlResponse = xmlResponse.Insert(index - 2 + "</".Length, remFields);
            return xmlResponse;
        }

        public Dictionary<string, object> ToDict()
        {
            Dictionary<string, string> remainingFields = GetRemainingIpnFields();
            string json = ToJson();
            Dictionary<string, object> dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(
          json, new JsonConverter[] { new PayWithAmazon.JsonParser() });

            foreach (KeyValuePair<string, string> item in remainingFields)
            {
                dict.Add(item.Key, item.Value);
            }

            return dict;
        }

        /* getRemainingIpnFields()
         * Gets the remaining fields of the IPN to be later appended to the return message
         */

        public Dictionary<string, string> GetRemainingIpnFields()
        {
            JObject message = JObject.Parse(this.parsedMessage.GetValue("Message").ToString());

            Dictionary<string, string> remainingFields = new Dictionary<string, string>()
            {
                {"NotificationReferenceId",message.GetValue("NotificationReferenceId").ToString()},
                {"NotificationType" ,message.GetValue("NotificationType").ToString()},
                {"SellerId" ,message.GetValue("SellerId").ToString()},
                {"ReleaseEnvironment" ,message.GetValue("ReleaseEnvironment").ToString()}
            };

            return remainingFields;
        }
    }
}