using Newtonsoft.Json.Linq;
using OffAmazonPaymentsNotifications;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Configuration;

namespace OffAmazonPaymentsNotificationsTest
{
    /// <summary>
    /// Text fixtures to help execute test code
    /// </summary>
    internal class Utilities
    {
        /// <summary>
        /// Given a dictionary of key value pairs, return a Message object that contains these fields
        /// </summary>
        /// <param name="msgContents">Contents of the message</param>
        /// <returns>Message object</returns>
        public static Message ConvertDictionaryToMessage(IDictionary<string, string> msgContents)
        {
            string jsonStr = ConvertDictionaryToJsonString(msgContents);
            return new Message(jsonStr);
        }

        /// <summary>
        /// Given a dictionary of key value pairs, return a Json string that contains these fields
        /// </summary>
        /// <param name="msgContents">Contents of the message</param>
        /// <returns>Json string</returns>
        public static string ConvertDictionaryToJsonString(IDictionary<string, string> msgContents)
        {
            JObject jsonMsg = ConvertDictionaryToJObject(msgContents);
            return jsonMsg.ToString();
        }

        /// <summary>
        /// Given a dictionary of key value pairs, return a JObject that contains these fields
        /// </summary>
        /// <param name="msgContents">Contents of the message</param>
        /// <returns>JObject</returns>
        private static JObject ConvertDictionaryToJObject(IDictionary<string, string> msgContents)
        {
            JObject jsonMsg = new JObject();
            foreach (KeyValuePair<string, string> fieldValue in msgContents)
            {
                jsonMsg.Add(new JProperty(fieldValue.Key, fieldValue.Value));
            }
            return jsonMsg;
        }

        /// <summary>
        /// Create a text notification metadata
        /// </summary>
        /// <returns>SnsNotificationMetadata</returns>
        public static INotificationMetadata CreateTestSnsNotificationMetadata()
        {
            return CreateTestSnsNotificationMetadata("dfdsfdsfwerw334", "fddfdsf");
        }

        /// <summary>
        /// Create a text notification metadata
        /// </summary>
        /// <param name="messageId">message id required</param>
        /// <param name="topicArn">topic arn required</param>
        /// <returns></returns>
        public static INotificationMetadata CreateTestSnsNotificationMetadata(string messageId, string topicArn)
        {
            IDictionary<string, string> snsMetadataFields = new Dictionary<string, string>();
            snsMetadataFields.Add("Type", "Notification");
            snsMetadataFields.Add("Message", "Test");
            snsMetadataFields.Add("Timestamp", "2013-05-03T10:45:27Z");
            snsMetadataFields.Add("TopicArn", topicArn);
            snsMetadataFields.Add("MessageId", messageId);
            return new SnsNotificationMetadata(ConvertDictionaryToMessage(snsMetadataFields));
        }

        /// <summary>
        /// Return a valid set of sns headers
        /// </summary>
        /// <returns>NamedValueCollection</returns>
        public static NameValueCollection GetSnsHeaderFields()
        {
            NameValueCollection headers = new NameValueCollection();
            headers.Add("x-amz-sns-message-type", "Notification");
            return headers;
        }

        public static void SetupConfigForTest()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("environment");
            config.AppSettings.Settings.Remove("region");
            config.AppSettings.Settings.Remove("widgetUrl");
            config.AppSettings.Settings.Remove("merchantID");
            config.AppSettings.Settings.Remove("certCN");
            config.AppSettings.Settings.Add("environment", "sandbox");
            config.AppSettings.Settings.Add("region", "us");
            config.AppSettings.Settings.Add("widgetUrl", "https://ostatic-payments-na.integ.amazon.com");
            config.AppSettings.Settings.Add("merchantID", "sellerid");
            config.AppSettings.Settings.Add("certCN", "sns.amazonaws.com");
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
