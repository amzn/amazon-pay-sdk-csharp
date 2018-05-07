using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AmazonPay.Responses
{
    /// <summary>
    /// Documentation Source https://pay.amazon.com/documentation/apireference/201752740
    /// </summary>

    public class RefundResponse : AbstractResponse
    {
        private string amazonRefundId;
        private string refundReferenceId;
        private string sellerNote;
        private string sellerRefundNote;

        private decimal refundAmount;
        private string refundCurrencyCode;
        private string refundType;
        private decimal feeRefunded;
        private string feeRefundedCurrencyCode;

        private decimal convertedAmount;
        private string convertedAmountCurrencyCode;
        private decimal conversionRate;

        private string refundState;

        private DateTime lastUpdateTimestamp;
        private DateTime creationTimestamp;

        private string reasonCode;
        private string reasonDescription;
        private string softDescriptor;

        private List<string> providerCreditReversalId = new List<string>();
        private List<string> providerId = new List<string>();

        private string parentKey;

        /// <summary>
        /// Get the RefundResponse
        /// </summary>
        public RefundResponse(string xml)
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
                                case Operator.AmazonRefundId:
                                    amazonRefundId = obj.ToString();
                                    break;
                                case Operator.RequestId:
                                    requestId = obj.ToString();
                                    break;
                                case Operator.SellerRefundNote:
                                    sellerRefundNote = obj.ToString();
                                    break;
                                case Operator.RefundReferenceId:
                                    refundReferenceId = obj.ToString();
                                    break;
                                case Operator.Amount:
                                    if (parentKey.Equals(Operator.RefundAmount.ToString()))
                                    {
                                        refundAmount = decimal.Parse(obj.ToString(), Constants.USNumberFormat);
                                    }
                                    else if (parentKey.Equals(Operator.FeeRefunded.ToString()))
                                    {
                                        feeRefunded = decimal.Parse(obj.ToString(), Constants.USNumberFormat);
                                    }
                                    else if (parentKey.Equals(Operator.ConvertedAmount.ToString()))
                                    {
                                        convertedAmount = decimal.Parse(obj.ToString(), Constants.USNumberFormat);
                                    }
                                    break;
                                case Operator.CurrencyCode:
                                    if (parentKey.Equals(Operator.RefundAmount.ToString()))
                                    {
                                        refundCurrencyCode = obj.ToString();
                                    }
                                    else if (parentKey.Equals(Operator.FeeRefunded.ToString()))
                                    {
                                        feeRefundedCurrencyCode = obj.ToString();
                                    }
                                    else if (parentKey.Equals(Operator.ConvertedAmount.ToString()))
                                    {
                                        convertedAmountCurrencyCode = obj.ToString();
                                    }
                                    break;
                                case Operator.RefundType:
                                    refundType = obj.ToString();
                                    break;
                                case Operator.ReasonCode:
                                    reasonCode = obj.ToString();
                                    break;
                                case Operator.ConversionRate:
                                    conversionRate = decimal.Parse(obj.ToString(), Constants.USNumberFormat);
                                    break;
                                case Operator.ReasonDescription:
                                    reasonDescription = obj.ToString();
                                    break;
                                case Operator.State:
                                    refundState = obj.ToString();
                                    break;
                                case Operator.SoftDescriptor:
                                    softDescriptor = obj.ToString();
                                    break;
                                case Operator.LastUpdateTimestamp:
                                    lastUpdateTimestamp = DateTime.Parse(obj.ToString());
                                    break;
                                case Operator.CreationTimestamp:
                                    creationTimestamp = DateTime.Parse(obj.ToString());
                                    break;
                                case Operator.member:
                                    if (parentKey.Equals(Operator.ProviderCreditReversalSummaryList.ToString()))
                                    {
                                        JArray providerCreditArray = JArray.Parse(obj.ToString());
                                        foreach (JObject item in providerCreditArray.Children<JObject>())
                                        {
                                            foreach (JProperty property in item.Properties())
                                            {
                                                string key = property.Name;
                                                string value = property.Value.ToString();
                                                if (key.Equals(Operator.ProviderId.ToString()) ||
                                                    key.Equals(Operator.ProviderSellerId.ToString()))
                                                {
                                                    providerId.Add(value);
                                                }
                                                if (key.Equals(Operator.ProviderCreditReversalId.ToString()))
                                                {
                                                    providerCreditReversalId.Add(value);
                                                }
                                            }
                                        }
                                    }
                                    break;

                                case Operator.ProviderId:
                                    providerId.Add(obj.ToString());
                                    break;
                                case Operator.ProviderSellerId:
                                    providerId.Add(obj.ToString());
                                    break;
                                case Operator.ProviderCreditReversalId:
                                    providerCreditReversalId.Add(obj.ToString());
                                    break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get the Amazon RefundID 
        /// </summary>
        /// <returns>string amazonRefundId</returns>
        public string GetAmazonRefundId()
        {
            return this.amazonRefundId;
        }

        /// <summary>
        /// Get the RefundReferenceId 
        /// </summary>
        /// <returns>string RefundReferenceId</returns>
        public string GetRefundReferenceId()
        {
            return this.refundReferenceId;
        }

        /// <summary>
        /// Get the Seller Refund Note
        /// </summary>
        /// <returns>string SellerRefundNote</returns>
        public string GetSellerRefundNote()
        {
            return this.sellerRefundNote;
        }

        /// <summary>
        /// Get the Refund Amount
        /// </summary>
        /// <returns>decimal refundAmount</returns>
        public decimal GetRefundAmount()
        {
            return this.refundAmount;
        }

        /// <summary>
        /// Get the Refund Amount Currency Code
        /// </summary>
        /// <returns>string refundCurrencyCode</returns>
        public string GetRefundAmountCurrencyCode()
        {
            return this.refundCurrencyCode;
        }

        /// <summary>
        /// Get the Refund Fee
        /// </summary>
        /// <returns>decimal feeRefunded</returns>
        public decimal GetRefundFee()
        {
            return this.feeRefunded;
        }

        /// <summary>
        /// Get the Refund Fee CurrencyCode Amount
        /// </summary>
        /// <returns>string feeRefundCurrencyCode</returns>
        public string GetRefundFeeCurrencyCode()
        {
            return this.feeRefundedCurrencyCode;
        }

        /// <summary>
        /// Get the Converted Amount
        /// </summary>
        /// <returns>decimal convertedAmount</returns>
        public decimal GetConvertedAmount()
        {
            return this.convertedAmount;
        }

        /// <summary>
        /// Get the ConvertedAmount Currency Code
        /// </summary>
        /// <returns>string convertedAmountCurrencyCode</returns>
        public string GetConvertedAmountCurrencyCode()
        {
            return this.convertedAmountCurrencyCode;
        }

        /// <summary>
        /// Get the Conversion Rate
        /// </summary>
        /// <returns>decimal captureFeeAmount</returns>
        public decimal GetConversionRate()
        {
            return this.conversionRate;
        }

        /// <summary>
        /// Get the Refund Type 
        /// </summary>
        /// <returns>string refundType</returns>
        public string GetRefundType()
        {
            return this.refundType;
        }

        /// <summary>
        /// Get the Refund State
        /// </summary>
        /// <returns>string refundState</returns>
        public string GetRefundState()
        {
            return this.refundState;
        }

        /// <summary>
        /// Get the ProviderCreditReversalIdList
        /// </summary>
        /// <returns>IList<String> providerCreditReversalId</returns>
        public IList<string> GetProviderCreditReversalIdList()
        {
            return this.providerCreditReversalId.AsReadOnly();
        }

        /// <summary>
        /// Get the ProviderIDList
        /// </summary>
        /// <returns>IList<String> providerId</returns>
        public IList<string> GetProviderIdList()
        {
            return this.providerId.AsReadOnly();
        }

        /// <summary>
        /// Get the LastUpdateTimestamp
        /// </summary>
        /// <returns>DateTime lastUpdateTimestamp</returns>
        public DateTime GetLastUpdateTimestamp()
        {
            return this.lastUpdateTimestamp;
        }

        /// <summary>
        /// Get the CreationTimestamp
        /// </summary>
        /// <returns>DateTime creationTimestamp</returns>
        public DateTime GetCreationTimestamp()
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

        /// <summary>
        /// Get the SoftDescriptor
        /// </summary>
        /// <returns>string softDescriptor</returns>
        public string GetSoftDescriptor()
        {
            return this.softDescriptor;
        }
    }
}
