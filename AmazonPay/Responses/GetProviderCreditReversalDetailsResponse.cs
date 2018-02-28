using System;
using System.Collections;

namespace AmazonPay.Responses
{
    public class GetProviderCreditReversalDetailsResponse : IResponse
    {
        private string xml;
        private string json;
        private IDictionary dictionary;
        private string amazonProviderCreditReversalId;
        private string requestId;
        private string sellerId;
        private string providerId;
        private string creditReversalReferenceId;
        private string creditReversalNote;

        private decimal creditReversalAmount;
        private string creditReversalAmountCurrencyCode;
        private string creditReversalStatus;
        private string lastUpdateTimestamp;
        private string creationTimestamp;

        private string reasonCode;
        private string reasonDescription;

        private string errorCode;
        private string errorMessage;
        private bool success = false;
        private string parentKey;


        /// <summary>
        /// ProviderCreditReversalDetailsResponse 
        /// </summary>
        public GetProviderCreditReversalDetailsResponse(string xml)
        {
            this.xml = xml;
            json = ResponseParser.ToJson(xml);
            dictionary = ResponseParser.ToDict(xml);


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
            AmazonProviderCreditReversalId, RequestId, CreditReversalNote, CreditReversalReferenceId,
            Amount, CurrencyCode, ReasonCode, ReasonDescription, State, LastUpdateTimestamp
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
                        parentKey = strKey;
                        ParseDictionaryToVariables((IDictionary)obj);
                    }
                    else
                    {
                        if (Enum.IsDefined(typeof(Operator), strKey))
                        {
                            switch ((Operator)Enum.Parse(typeof(Operator), strKey))
                            {
                                case Operator.AmazonProviderCreditReversalId:
                                    amazonProviderCreditReversalId = obj.ToString();
                                    break;
                                case Operator.RequestId:
                                    requestId = obj.ToString();
                                    break;
                                case Operator.CreditReversalNote:
                                    creditReversalNote = obj.ToString();
                                    break;
                                case Operator.CreditReversalReferenceId:
                                    creditReversalReferenceId = obj.ToString();
                                    break;
                                case Operator.Amount:
                                    creditReversalAmount = decimal.Parse(obj.ToString());
                                    break;
                                case Operator.CurrencyCode:
                                    creditReversalAmountCurrencyCode = obj.ToString();
                                    break;
                                case Operator.ReasonCode:
                                    reasonCode = obj.ToString();
                                    break;
                                case Operator.ReasonDescription:
                                    reasonDescription = obj.ToString();
                                    break;
                                case Operator.State:
                                    creditReversalStatus = obj.ToString();
                                    break;
                                case Operator.LastUpdateTimestamp:
                                    lastUpdateTimestamp = obj.ToString();
                                    break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get the Amazon ProviderCreditReversalId 
        /// </summary>
        /// <returns>string amazonProviderCreditReversalId</returns>
        public string GetAmazonProviderCreditReversalId()
        {
            return amazonProviderCreditReversalId;
        }

        /// <summary>
        /// Get the Amazon RequestId 
        /// </summary>
        /// <returns>string requestId</returns>
        public string GetRequestId()
        {
            return requestId;
        }

        /// <summary>
        /// Get the CreditReversalReferenceId 
        /// </summary>
        /// <returns>string creditReversalReferenceId</returns>
        public string GetCreditReversalReferenceId()
        {
            return creditReversalReferenceId;
        }

        /// <summary>
        /// Get the CreditReversalNote 
        /// </summary>
        /// <returns>string creditReversalNote</returns>
        public string GetCreditReversalNote()
        {
            return creditReversalNote;
        }

        /// <summary>
        /// Get the CreditReversalAmount
        /// </summary>
        /// <returns>string creditReversalAmount</returns>
        public decimal GetCreditReversalAmount()
        {
            return creditReversalAmount;
        }

        /// <summary>
        /// Get the CreditReversalAmountCurrencyCode 
        /// </summary>
        /// <returns>string creditReversalAmountCurrencyCode</returns>
        public string GetCreditReversalAmountCurrencyCode()
        {
            return creditReversalAmountCurrencyCode;
        }

        /// <summary>
        /// Get the CreditReversalStatus 
        /// </summary>
        /// <returns>string creditReversalStatus</returns>
        public string GetCreditReversalStatus()
        {
            return creditReversalStatus;
        }

        /// <summary>
        /// Get the LastUpdateTimestamp 
        /// </summary>
        /// <returns>string lastUpdatetimestamp</returns>
        public string GetLastUpdateTimestamp()
        {
            return lastUpdateTimestamp;
        }

        /// <summary>
        /// Get the Creationtimestamp 
        /// </summary>
        /// <returns>string creationtimestamp</returns>
        public string GetCreationTimestamp()
        {
            return creationTimestamp;
        }

        /// <summary>
        /// Get the ReasonCode 
        /// </summary>
        /// <returns>string reasonCode</returns>
        public string GetReasonCode()
        {
            return reasonCode;
        }

        /// <summary>
        /// Get the ReasonDescription 
        /// </summary>
        /// <returns>string reasonDescription</returns>
        public string GetReasonDescription()
        {
            return reasonDescription;
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
