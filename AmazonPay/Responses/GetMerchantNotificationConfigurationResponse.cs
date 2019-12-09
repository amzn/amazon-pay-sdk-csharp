using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AmazonPay.Responses
{
    /// <summary>
    /// Request class to parse the GetMerchantNotificationConfiguration API call response
    /// </summary>

    public class GetMerchantNotificationConfigurationResponse : AbstractResponse
    {
        private string parentKey;
        private Dictionary<string, List<Constants.URLEventTypes>> notificationsUrls = new Dictionary<string, List<Constants.URLEventTypes>>();
        private string notificationUrl;
        private string requestId;
        /// <summary>
        /// Get the GetMerchantNotificationConfigurationResponse
        /// </summary>
        public GetMerchantNotificationConfigurationResponse(string xml)
        {
            SetDictionaryAndErrorResponse(xml);
            if (success)
            {
                ParseDictionaryToNewVariables(this.dictionary);
            }
        }

        /// <summary>
        /// Flattening the Dictionary
        /// The input dictionary contains key value pairs in the below format
        /// Type 1. Key (string) , Value (string)
        /// Type 2. Key (string) , Value (Dictionary)
        /// The function will parse the dictionary values into respective class variables by directly jumping to to the switch case for Type 1 
        /// else it will recursively parse the inner dictionary for Type 2
        /// </summary>
        /// <param name="dictionary"></param>
        private void ParseDictionaryToNewVariables(IDictionary dictionary)
        {
            foreach (string strKey in dictionary.Keys)
            {
                // Obj is the value of the dictionary key. this could either be a string or a nested inner dictionary.
                object obj = dictionary[strKey];
                if (obj != null)
                {
                    // If obj is dictionary recursively parse it
                    if (obj is IDictionary)
                    {
                        parentKey = strKey;
                        ParseDictionaryToNewVariables((IDictionary)obj);
                    }
                    else
                    {
                        if (Enum.IsDefined(typeof(Operator), strKey))
                        {
                            switch ((Operator)Enum.Parse(typeof(Operator), strKey))
                            {
                                case Operator.RequestId:
                                    requestId = obj.ToString();
                                    break;
                                case Operator.member:
                                    if (parentKey == "NotificationConfigurationList")
                                    {
                                        JArray array = JArray.Parse(obj.ToString());
                                        foreach (JObject notificationUrlsJSON in array.Children<JObject>())
                                        {
                                            List<Constants.URLEventTypes> eventTypes = new List<Constants.URLEventTypes>();

                                            foreach (JProperty notificationUrlJSON in notificationUrlsJSON.Properties())
                                            {
                                                if (notificationUrlJSON.Name.Equals( "NotificationUrl" ))
                                                {
                                                    notificationUrl = notificationUrlJSON.Value.ToString();
                                                }
                                                if (notificationUrlJSON.Name.Equals( "EventTypes" ))
                                                {
                                                    JToken eventTypeObject = notificationUrlJSON.Value;
                                                    JToken eTO = eventTypeObject.First.First.ToString();
                                                    string[] eventTypesString = eTO.ToString().Split(',');
                                                    foreach (string eventType in eventTypesString)
                                                    {
                                                        if( Enum.IsDefined(typeof(Constants.URLEventTypes), eventType))
                                                        {
                                                            Constants.URLEventTypes thisEventType = (Constants.URLEventTypes)Enum.Parse(typeof(Constants.URLEventTypes), eventType, true);
                                                            eventTypes.Add(thisEventType);
                                                        }
                                                    }
                                                }
                                            }
                                            notificationsUrls.Add(notificationUrl, eventTypes);
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get the Notification URLs 
        /// </summary>
        /// <returns>string orderLanguage</returns>
        public Dictionary<string, List<Constants.URLEventTypes>> GetNotificationUrls()
        {
            return this.notificationsUrls;
        }

    }
}
