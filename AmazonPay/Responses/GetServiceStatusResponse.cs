using System;
using System.Collections;

namespace AmazonPay.Responses
{
    /// <summary>
    /// Documentation Source https://pay.amazon.com/documentation/apireference/201752740#201752110
    /// </summary>

    public class GetServiceStatusResponse : IResponse
    {
        private string xml;
        private string json;
        private IDictionary dictionary;
        private string requestId;
        private string status;
        private DateTime timestamp;
        private string errorCode;
        private string errorMessage;
        private bool success = false;


        /// <summary>
        /// ServiceStatusResponse 
        /// </summary>
        public GetServiceStatusResponse(string xml)
        {
            this.xml = xml;
            ResponseParser.SetXml(xml);
            this.json = ResponseParser.ToJson();
            this.dictionary = ResponseParser.ToDict();

            ErrorResponse errorResponse = new ErrorResponse(this.dictionary);
            if (errorResponse.IsSetErrorCode() && errorResponse.IsSetErrorMessage())
            {
                success = false;
                this.errorCode = errorResponse.GetErrorCode();
                this.errorMessage = errorResponse.GetErrorMessage();
                this.requestId = errorResponse.GetRequestId();
            }
            else
            {
                success = true;
                ParseDictionaryToVariables(this.dictionary);
            }
        }

        public enum Operator
        {
            RequestId, Status, Timestamp
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
        private void ParseDictionaryToVariables(IDictionary dictionary)
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
                        ParseDictionaryToVariables((IDictionary)obj);
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
        /// Get the RequestId 
        /// </summary>
        /// <returns>string requestId</returns>
        public string GetRequestId()
        {
            return requestId;
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

        /// <summary>
        /// Get the ErrorCode 
        /// </summary>
        /// <returns>string errorCode</returns>
        public string GetErrorCode()
        {
            return errorCode;
        }

        /// <summary>
        /// Get the ErrorMessage 
        /// </summary>
        /// <returns>string errorMessage</returns>
        public string GetErrorMessage()
        {
            return errorMessage;
        }

        /// <summary>
        /// Get the Success 
        /// </summary>
        /// <returns>bool success</returns>
        public bool GetSuccess()
        {
            return success;
        }

        /// <summary>
        /// Get the Json 
        /// </summary>
        /// <returns>string json</returns>
        public string GetJson()
        {
            return json;
        }

        /// <summary>
        /// Get the XML 
        /// </summary>
        /// <returns>string xml</returns>
        public string GetXml()
        {
            return xml;
        }

        /// <summary>
        /// Get the Dictionary 
        /// </summary>
        /// <returns>IDictionary dictionary</returns>
        public IDictionary GetDictionary()
        {
            return dictionary;
        }

    }
}
