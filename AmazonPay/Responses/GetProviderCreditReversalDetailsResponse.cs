using System;
using System.Collections;

namespace AmazonPay.Responses
{
    public class GetProviderCreditReversalDetailsResponse : AbstractResponse
    {
        private string amazonProviderCreditReversalId;
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

        private string parentKey;

        /// <summary>
        /// ProviderCreditReversalDetailsResponse 
        /// </summary>
        public GetProviderCreditReversalDetailsResponse(string xml)
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

        /// <summary>
        /// Get the Amazon ProviderCreditReversalId 
        /// </summary>
        /// <returns>string amazonProviderCreditReversalId</returns>
        public string GetAmazonProviderCreditReversalId()
        {
            return this.amazonProviderCreditReversalId;
        }

        /// <summary>
        /// Get the CreditReversalReferenceId 
        /// </summary>
        /// <returns>string creditReversalReferenceId</returns>
        public string GetCreditReversalReferenceId()
        {
            return this.creditReversalReferenceId;
        }

        /// <summary>
        /// Get the CreditReversalNote 
        /// </summary>
        /// <returns>string creditReversalNote</returns>
        public string GetCreditReversalNote()
        {
            return this.creditReversalNote;
        }

        /// <summary>
        /// Get the CreditReversalAmount
        /// </summary>
        /// <returns>string creditReversalAmount</returns>
        public decimal GetCreditReversalAmount()
        {
            return this.creditReversalAmount;
        }

        /// <summary>
        /// Get the CreditReversalAmountCurrencyCode 
        /// </summary>
        /// <returns>string creditReversalAmountCurrencyCode</returns>
        public string GetCreditReversalAmountCurrencyCode()
        {
            return this.creditReversalAmountCurrencyCode;
        }

        /// <summary>
        /// Get the CreditReversalStatus 
        /// </summary>
        /// <returns>string creditReversalStatus</returns>
        public string GetCreditReversalStatus()
        {
            return this.creditReversalStatus;
        }

        /// <summary>
        /// Get the LastUpdateTimestamp 
        /// </summary>
        /// <returns>string lastUpdatetimestamp</returns>
        public string GetLastUpdateTimestamp()
        {
            return this.lastUpdateTimestamp;
        }

        /// <summary>
        /// Get the Creationtimestamp 
        /// </summary>
        /// <returns>string creationtimestamp</returns>
        public string GetCreationTimestamp()
        {
            return this.creationTimestamp;
        }

        /// <summary>
        /// Get the ReasonCode 
        /// </summary>
        /// <returns>string reasonCode</returns>
        public string GetReasonCode()
        {
            return this.reasonCode;
        }

        /// <summary>
        /// Get the ReasonDescription 
        /// </summary>
        /// <returns>string reasonDescription</returns>
        public string GetReasonDescription()
        {
            return this.reasonDescription;
        }
    }
}
