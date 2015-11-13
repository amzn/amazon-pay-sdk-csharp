using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.Responses
{
    /// <summary>
    /// Documentation Source https://payments.amazon.com/documentation/apireference/201752740#201752110
    /// </summary>

    public class GetServiceStatusResponse : IResponse
    {
        public string xml;
        public string json;
        public IDictionary dictionary;
        public string requestId;
        public string status;
        public DateTime timestamp;
        public string errorCode;
        public string errorMessage;
        public bool success = false;

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

        public string GetRequestId()
        {
            return this.requestId;
        }
        public string GetStatus()
        {
            return status;
        }
        public DateTime GetTimestamp()
        {
            return timestamp;
        }
        public string GetErrorCode()
        {
            return errorCode;
        }
        public string GetErrorMessage()
        {
            return errorMessage;
        }
        public bool GetSuccess()
        {
            return success;
        }
        public string GetJson()
        {
            return this.json;
        }
        public string GetXml()
        {
            return this.xml;
        }
        public IDictionary GetDictionary()
        {
            return this.dictionary;
        }

    }
}
