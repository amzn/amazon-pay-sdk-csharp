using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.Responses
{
    public class GetProviderCreditDetailsResponse : IResponse
    {
        public string xml;
        public string json;
        public IDictionary dictionary;
        public string amazonProviderCreditId;
        public string providerId;
        public string sellerId;
        public string creditReferenceId;
        public string requestId;

        public decimal creditAmount;
        public string creditAmountCurrencyCode;

        public decimal creditReversalAmount;
        public string creditReversalAmountCurrencyCode;

        public string creditStatus;
        public List<string> creditReversalIdList = new List<string>();

        public DateTime lastUpdateTimestamp;
        public DateTime creationTimestamp;

        public string reasonCode;
        public string reasonDescription;
        public string softDescriptor;

        public string errorCode;
        public string errorMessage;
        public bool success = false;
        public string parentKey;


        public GetProviderCreditDetailsResponse(string xml)
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
            AmazonProviderCreditId, RequestId, ProviderId, ProviderSellerId, CreditReferenceId, Amount, CreditAmount, CreditReversalAmount, CurrencyCode, ReasonCode, ReasonDescription,
            State, SoftDescriptor, LastUpdateTimestamp, member, Id, SellerId
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
                                case Operator.AmazonProviderCreditId:
                                    this.amazonProviderCreditId = obj.ToString();
                                    break;
                                case Operator.RequestId:
                                    requestId = obj.ToString();
                                    break;
                                case Operator.ProviderId:
                                    providerId = obj.ToString();
                                    break;
                                case Operator.ProviderSellerId:
                                    providerId = obj.ToString();
                                    break;
                                case Operator.SellerId:
                                    sellerId = obj.ToString();
                                    break;
                                case Operator.CreditReferenceId:
                                    creditReferenceId = obj.ToString();
                                    break;
                                case Operator.Amount:
                                    if (parentKey.Equals(Operator.CreditAmount.ToString()))
                                    {
                                        creditAmount = decimal.Parse(obj.ToString());
                                    }
                                    else if (parentKey.Equals(Operator.CreditReversalAmount.ToString()))
                                    {
                                        creditReversalAmount = decimal.Parse(obj.ToString());
                                    }
                                    break;
                                case Operator.CurrencyCode:
                                    if (parentKey.Equals(Operator.CreditAmount.ToString()))
                                    {
                                        creditAmountCurrencyCode = obj.ToString();
                                    }
                                    else if (parentKey.Equals(Operator.CreditReversalAmount.ToString()))
                                    {
                                        creditReversalAmountCurrencyCode = obj.ToString();
                                    }
                                    break;
                                case Operator.ReasonCode:
                                    reasonCode = obj.ToString();
                                    break;
                                case Operator.ReasonDescription:
                                    reasonDescription = obj.ToString();
                                    break;
                                case Operator.State:
                                    creditStatus = obj.ToString();
                                    break;
                                case Operator.SoftDescriptor:
                                    softDescriptor = obj.ToString();
                                    break;
                                case Operator.LastUpdateTimestamp:
                                    lastUpdateTimestamp = DateTime.Parse(obj.ToString());
                                    break;
                                /* The below case parses two types of Amazon Provider Credit Reversal ID member fields. When the nested Dictionary is flattened
                                 * it contains JArray. JArray contains the member field which contains the Amazon Provider Credit Reversal ID. this is added to the List
                                 */
                                case Operator.member:
                                    if (obj.GetType() == typeof(JArray))
                                    {
                                        JArray array = JArray.Parse(obj.ToString());
                                        foreach (string creditReversalId in array)
                                        {
                                            creditReversalIdList.Add(creditReversalId);
                                        }
                                    }
                                    else
                                    {
                                        creditReversalIdList.Add(obj.ToString());
                                    }
                                    break;
                                /* The reason for below case is due to IPN key value discrepancy. In the API response XML 
                                 * the Amazon Credit Reversal ID'S have the attribute <member>Amazon Credit Reversal ID</member>
                                 * in the IPN it's returned as <Id>Amazon Credit Reversal ID</Id>
                                 */
                                case Operator.Id:
                                    if (obj.GetType() == typeof(JArray))
                                    {
                                        JArray array = JArray.Parse(obj.ToString());
                                        foreach (string creditReversalId in array)
                                        {
                                            creditReversalIdList.Add(creditReversalId);
                                        }
                                    }
                                    else
                                    {
                                        creditReversalIdList.Add(obj.ToString());
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
        }

        public string GetAmazonProviderCreditId()
        {
            return this.amazonProviderCreditId;
        }
        public string GetRequestId()
        {
            return this.requestId;
        }
        public DateTime GetCreationTimestamp()
        {
            return this.creationTimestamp;
        }
        public decimal GetCreditAmount()
        {
            return this.creditAmount;
        }
        public string GetCreditAmountCurrencyCode()
        {
            return this.creditAmountCurrencyCode;
        }
        public string GetCreditReferenceId()
        {
            return this.creditReferenceId;
        }
        public decimal GetCreditReversalAmount()
        {
            return this.creditReversalAmount;
        }
        public string GetCreditReversalAmountCurrencyCode()
        {
            return this.creditReversalAmountCurrencyCode;
        }
        public IList<string> GetCreditReversalIdList()
        {
            return this.creditReversalIdList.AsReadOnly();
        }
        public string GetCreditStatus()
        {
            return this.creditStatus;
        }
        public string GetReasonCode()
        {
            return this.reasonCode;
        }
        public string GetReasonDescription()
        {
            return this.reasonDescription;
        }
        public string GetSoftDescriptor()
        {
            return this.softDescriptor;
        }
        public string GetSellerId()
        {
            return this.sellerId;
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
            return this.success;
        }
        public string GetXml()
        {
            return this.xml;
        }
        public IDictionary GetDictionary()
        {
            return this.dictionary;
        }
        public string GetJson()
        {
            return this.json;
        }
    }
}
