using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.Responses
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
        public bool success = false;
        public string parentKey;
        

        public GetProviderCreditReversalDetailsResponse(string xml)
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
                                    this.amazonProviderCreditReversalId = obj.ToString();
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
            return this.amazonProviderCreditReversalId;
        }
        public string GetRequestId()
        {
            return this.requestId;
        }
        public string GetCreditReversalReferenceId()
        {
            return this.creditReversalReferenceId;
        }
        public string GetCreditReversalNote()
        {
            return this.creditReversalNote;
        }
        public decimal GetCreditReversalAmount()
        {
            return this.creditReversalAmount;
        }
        public string GetCreditReversalAmountCurrencyCode()
        {
            return this.creditReversalAmountCurrencyCode;
        }
        public string GetCreditReversalStatus()
        {
            return this.creditReversalStatus;
        }
        public string GetLastUpdateTimestamp()
        {
            return this.lastUpdateTimestamp;
        }
        public string GetCreationTimestamp()
        {
            return this.creationTimestamp;
        }
        public string GetReasonCode()
        {
            return this.reasonCode;
        }
        public string GetReasonDescription()
        {
            return this.reasonDescription;
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
