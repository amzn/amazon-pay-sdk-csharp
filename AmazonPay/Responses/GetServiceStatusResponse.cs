using System;
using System.Collections;

namespace AmazonPay.Responses
{
    /// <summary>
    /// Documentation Source https://pay.amazon.com/documentation/apireference/201752740#201752110
    /// </summary>

    public class GetServiceStatusResponse : AbstractResponse
    {
        private string status;
        private DateTime timestamp;

        /// <summary>
        /// ServiceStatusResponse 
        /// </summary>
        public GetServiceStatusResponse(string xml)
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
                                case Operator.Status:
                                    status = obj.ToString();
                                    break;
                                case Operator.Timestamp:
                                    timestamp = DateTime.Parse(obj.ToString());
                                    break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get the Status 
        /// </summary>
        /// <returns>string status</returns>
        public string GetStatus()
        {
            return status;
        }

        /// <summary>
        /// Get the timestamp 
        /// </summary>
        /// <returns>DateTime timestamp</returns>
        public DateTime GetTimestamp()
        {
            return timestamp;
        }
    }
}
