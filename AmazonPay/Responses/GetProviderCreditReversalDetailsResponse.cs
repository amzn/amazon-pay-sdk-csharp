using System;
using System.Collections;

namespace AmazonPay.Responses
{
    public class GetProviderCreditReversalDetailsResponse : IResponse
    {
        public string xml;
        public string json;
        public IDictionary dictionary;
        public string amazonProviderCreditReversalId;
        public string requestId;
        public string sellerId;
        public string providerId;
        public string creditReversalReferenceId;
        public string creditReversalNote;

        public decimal creditReversalAmount;
        public string creditReversalAmountCurrencyCode;
        public string creditReversalStatus;
        public string lastUpdateTimestamp;
        public string creationTimestamp;

        public string reasonCode;
        public string reasonDescription;

        public string errorCode;
        public string errorMessage;
        public bool success;
        public string parentKey;


        public GetProviderCreditReversalDetailsResponse(string xml)
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

        public string GetAmazonProviderCreditReversalId()
        {
            return amazonProviderCreditReversalId;
        }
        public string GetRequestId()
        {
            return requestId;
        }
        public string GetCreditReversalReferenceId()
        {
            return creditReversalReferenceId;
        }
        public string GetCreditReversalNote()
        {
            return creditReversalNote;
        }
        public decimal GetCreditReversalAmount()
        {
            return creditReversalAmount;
        }
        public string GetCreditReversalAmountCurrencyCode()
        {
            return creditReversalAmountCurrencyCode;
        }
        public string GetCreditReversalStatus()
        {
            return creditReversalStatus;
        }
        public string GetLastUpdateTimestamp()
        {
            return lastUpdateTimestamp;
        }
        public string GetCreationTimestamp()
        {
            return creationTimestamp;
        }
        public string GetReasonCode()
        {
            return reasonCode;
        }
        public string GetReasonDescription()
        {
            return reasonDescription;
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
            return json;
        }
        public string GetXml()
        {
            return xml;
        }
        public IDictionary GetDictionary()
        {
            return dictionary;
        }
    }
}
