using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AmazonPay.Responses
{
    /// <summary>
    /// Documentation Source https://pay.amazon.com/documentation/apireference/201752580
    /// </summary>

    public class CaptureResponse : AbstractResponse
    {
        private string amazonCaptureId;
        private string captureReferenceId;
        private string sellerCaptureNote;

        private decimal captureAmount;
        private string captureCurrencyCode;

        private decimal refundedAmount;
        private string refundedAmountCurrencyCode;

        private decimal captureFeeAmount;
        private string captureFeeCurrencyCode;

        private decimal convertedAmount;
        private string convertedAmountCurrencyCode;
        private decimal conversionRate;

        private string captureState;
        private List<string> refundId = new List<string>();

        private DateTime lastUpdateTimestamp;
        private DateTime creationTimestamp;

        private string reasonCode;
        private string reasonDescription;
        private string softDescriptor;

        private List<string> providerId = new List<string>();
        private List<string> providerCreditId = new List<string>();

        private string parentKey;


        public CaptureResponse(string xml)
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
                                case Operator.AmazonCaptureId:
                                    this.amazonCaptureId = obj.ToString();
                                    break;
                                case Operator.RequestId:
                                    requestId = obj.ToString();
                                    break;
                                case Operator.SellerCaptureNote:
                                    sellerCaptureNote = obj.ToString();
                                    break;
                                case Operator.CaptureReferenceId:
                                    captureReferenceId = obj.ToString();
                                    break;
                                case Operator.Amount:
                                    if (parentKey.Equals(Operator.CaptureAmount.ToString()))
                                    {
                                        captureAmount = decimal.Parse(obj.ToString(), Constants.USNumberFormat);
                                    }
                                    else if (parentKey.Equals(Operator.RefundedAmount.ToString()))
                                    {
                                        refundedAmount = decimal.Parse(obj.ToString(), Constants.USNumberFormat);
                                    }
                                    else if (parentKey.Equals(Operator.CaptureFee.ToString()))
                                    {
                                        captureFeeAmount = decimal.Parse(obj.ToString(), Constants.USNumberFormat);
                                    }
                                    else if (parentKey.Equals(Operator.ConvertedAmount.ToString()))
                                    {
                                        convertedAmount = decimal.Parse(obj.ToString(), Constants.USNumberFormat);
                                    }
                                    break;
                                case Operator.CurrencyCode:
                                    if (parentKey.Equals(Operator.CaptureAmount.ToString()))
                                    {
                                        captureCurrencyCode = obj.ToString();
                                    }
                                    else if (parentKey.Equals(Operator.RefundedAmount.ToString()))
                                    {
                                        refundedAmountCurrencyCode = obj.ToString();
                                    }
                                    else if (parentKey.Equals(Operator.CaptureFee.ToString()))
                                    {
                                        captureFeeCurrencyCode = obj.ToString();
                                    }
                                    else if (parentKey.Equals(Operator.ConvertedAmount.ToString()))
                                    {
                                        convertedAmountCurrencyCode = obj.ToString();
                                    }
                                    break;
                                
                                case Operator.ConversionRate:
                                    conversionRate = decimal.Parse(obj.ToString(), Constants.USNumberFormat);
                                    break;
                                case Operator.ReasonCode:
                                    reasonCode = obj.ToString();
                                    break;
                                case Operator.ReasonDescription:
                                    reasonDescription = obj.ToString();
                                    break;
                                case Operator.State:
                                    captureState = obj.ToString();
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
                                    if (parentKey.Equals(Operator.IdList.ToString()))
                                    {
                                        if (obj.GetType() == typeof(JArray))
                                        {
                                            JArray refundIdArray = JArray.Parse(obj.ToString());
                                            foreach (string id in refundIdArray)
                                            {
                                                refundId.Add(id);
                                            }
                                        }
                                        else
                                        {
                                            refundId.Add(obj.ToString());
                                        }
                                    }
                                    if (parentKey.Equals(Operator.ProviderCreditSummaryList.ToString()))
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
                                                if (key.Equals(Operator.ProviderCreditId.ToString()))
                                                {
                                                    providerCreditId.Add(value);
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
                                case Operator.ProviderCreditId:
                                    providerCreditId.Add(obj.ToString());
                                    break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get the Amazon Capture ID
        /// </summary>
        /// <returns>string amazonCaptureId</returns>
        public string GetCaptureId()
        {
            return this.amazonCaptureId;
        }

        /// <summary>
        /// Get the unique Capture Reference Id
        /// </summary>
        /// <returns>string captureReferenceId</returns>
        public string GetCaptureReferenceId()
        {
            return this.captureReferenceId;
        }

        /// <summary>
        /// Get the last Update Timestamp of the Amazon Capture ID
        /// </summary>
        /// <returns>DateTime lastUpdateTimestamp</returns>
        public DateTime GetLastUpdatedTimestamp()
        {
            return this.lastUpdateTimestamp;
        }

        /// <summary>
        /// Get the Seller Capture Note provided 
        /// </summary>
        /// <returns>string sellerCaptureNote</returns>
        public string GetSellerCaptureNote()
        {
            return this.sellerCaptureNote;
        }

        /// <summary>
        /// Get the Captured Amount
        /// </summary>
        /// <returns>decimal captureAmount</returns>
        public decimal GetCaptureAmount()
        {
            return this.captureAmount;
        }

        /// <summary>
        /// Get the Currency Code of the amount Captured
        /// </summary>
        /// <returns>string captureCurrencyCode</returns>
        public string GetCaptureAmountCurrencyCode()
        {
            return this.captureCurrencyCode;
        }

        /// <summary>
        /// Get the Refunded Amount
        /// </summary>
        /// <returns>decimal refundedAmount</returns>
        public decimal GetRefundedAmount()
        {
            return this.refundedAmount;
        }

        /// <summary>
        /// Get the Currency Code of the amount Refunded
        /// </summary>
        /// <returns>string refundCurrencyCode</returns>
        public string GetRefundedAmountCurrencyCode()
        {
            return this.refundedAmountCurrencyCode;
        }

        /// <summary>
        /// Get the Capture Fee
        /// </summary>
        /// <returns>decimal captureFeeAmount</returns>
        public decimal GetCaptureFee()
        {
            return this.captureFeeAmount;
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
        /// Get teh ConvertedAmount Currency Code
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
        /// Get teh CaptureFee Currency Code
        /// </summary>
        /// <returns>string captureFeeCurrencyCode</returns>
        public string GetCaptureFeeCurrencyCode()
        {
            return this.captureFeeCurrencyCode;
        }

        /// <summary>
        /// Get the state of the Amazon Capture ID
        /// </summary>
        /// <returns>string captureState</returns>
        public string GetCaptureState()
        {
            return this.captureState;
        }

        /// <summary>
        /// Get the IList of the Refund IDS 
        /// </summary>
        /// <returns>IList refundId</returns>
        public IList<string> GetRefundIdList()
        {
            return this.refundId.AsReadOnly();
        }

        /// <summary>
        /// Get the List of Provider Credit IDS
        /// </summary>
        /// <returns>IList providerCreditId</returns>
        public IList<string> GetProviderCreditIdList()
        {
            return this.providerCreditId.AsReadOnly();
        }

        /// <summary>
        /// Get the List of the Provider ID(s)
        /// </summary>
        /// <returns>IList providerId</returns>
        public IList<string> GetProviderIdList()
        {
            return this.providerId.AsReadOnly();
        }

        /// <summary>
        /// Get the Creation Timestamp of the Amazon Capture ID
        /// </summary>
        /// <returns>DateTime creationTimestamp</returns>
        public DateTime GetCreationTimestamp()
        {
            return this.creationTimestamp;
        }

        /// <summary>
        /// Get the Reason code when the Amazon Capture ID is in a different state than Open
        /// </summary>
        /// <returns>string reasonCode</returns>
        public string GetReasonCode()
        {
            return this.reasonCode;
        }

        /// <summary>
        /// Get the Reason Description when the Amazon Capture ID is in a different state than Open
        /// </summary>
        /// 
        public string GetReasonDescription()
        {
            return this.reasonDescription;
        }

        /// <summary>
        /// Get the SoftDescriptor that appears on the buyer's payment instrument statement
        /// </summary>
        ///
        public string GetSoftDescriptor()
        {
            return this.softDescriptor;
        }
    }
}
