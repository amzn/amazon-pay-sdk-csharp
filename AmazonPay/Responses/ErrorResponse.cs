using System;
using System.Collections;

namespace AmazonPay.Responses
{
    /// <summary>
    /// Documentation Source https://pay.amazon.com/documentation/apireference/201752580#201753060
    /// </summary>

    public class ErrorResponse
    {
        private string errorCode = null;
        private string errorMessage = null;
        private string requestId = null;

        public ErrorResponse(IDictionary dictionary)
        {
            ParseDictionaryToVariables(dictionary);
        }

        private enum Operator
        {
            Code, Message, RequestId
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
                                case Operator.Code:
                                    errorCode = obj.ToString();
                                    break;
                                case Operator.Message:
                                    errorMessage = obj.ToString();
                                    break;
                                case Operator.RequestId:
                                    requestId = obj.ToString();
                                    break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get the ErrorCode when te API call failed
        /// </summary>
        /// <returns>string errorCode</returns>
        public string GetErrorCode()
        {
            return this.errorCode;
        }

        /// <summary>
        /// Get the ErrorMessage when the API call failed
        /// </summary>
        /// <returns>string errorMesage</returns>
        public string GetErrorMessage()
        {
            return this.errorMessage;
        }

        /// <summary>
        /// Return true or false if the ErrorCode is set 
        /// </summary>
        /// <returns>boolean errorCode</returns>
        public bool IsSetErrorCode()
        {
            return errorCode != null;
        }

        /// <summary>
        /// Return true or false if the ErrorMessage is set 
        /// </summary>
        /// <returns>boolean errorMessage</returns>
        public bool IsSetErrorMessage()
        {
            return errorMessage != null;
        }

        /// <summary>
        /// Get the requestId
        /// </summary>
        /// <returns>string requestId</returns>
        public string GetRequestId()
        {
            return this.requestId;
        }
    }
}
