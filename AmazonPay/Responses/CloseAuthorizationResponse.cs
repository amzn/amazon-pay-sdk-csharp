using System;
using System.Collections;

namespace AmazonPay.Responses
{
    public class CloseAuthorizationResponse : IResponse
    {
        public string xml;
        public string json;
        public IDictionary dictionary;
        public string requestId;
        public string errorCode;
        public string errorMessage;
        public bool success;

        public CloseAuthorizationResponse(string xml)
        {
            this.xml = xml;
            ResponseParser.SetXml(xml);
            json = ResponseParser.ToJson();
            dictionary = ResponseParser.ToDict();

            ErrorResponse errorResponse = new ErrorResponse(dictionary);
            if (errorResponse.IsSetErrorCode() && errorResponse.IsSetErrorMessage())
            {
                success = false;
                errorCode = errorResponse.GetErrorCode();
                errorMessage = errorResponse.GetErrorMessage();
                requestId = errorResponse.GetRequestId();
            }
            else
            {
                success = true;
                ParseDictionaryToVariables(dictionary);
            }
        }

        private enum Operator
        {
            RequestId
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
                                    success = true;
                                    break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get the requestId
        /// </summary>
        /// <returns>string requestId</returns>
        public string GetRequestId()
        {
            return requestId;
        }

        /// <summary>
        /// Get the bool value to know if the API call was a success(true) or a failure(false)
        /// </summary>
        /// <returns>success can be true or false</returns>
        public bool GetSuccess()
        {
            return success;
        }

        /// <summary>
        /// Get the ErrorCode when te API call failed
        /// </summary>
        /// <returns>string errorCode</returns>
        public string GetErrorCode()
        {
            return errorCode;
        }

        /// <summary>
        /// Get the ErrorMessage when the API call failed
        /// </summary>
        /// <returns>string errorMesage</returns>
        public string GetErrorMessage()
        {
            return errorMessage;
        }

        /// <summary>
        /// Response returned in JSON format
        /// </summary>
        /// <returns>JSON format Response</returns>
        public string GetJson()
        {
            return json;
        }

        /// <summary>
        /// Response returned in XML format
        /// </summary>
        /// <returns>XML format Response</returns>
        public string GetXml()
        {
            return xml;
        }

        /// <summary>
        /// Response in Dictionary Format
        /// </summary>
        /// <returns>Dictionary<string,object> type Response</returns>
        public IDictionary GetDictionary()
        {
            return dictionary;
        }
    }
}
