using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AmazonPay.Responses
{
    /// <summary>
    /// Documentation Source https://pay.amazon.com/documentation/apireference/201752740
    /// </summary>

    public class RefundResponse : IResponse
    {
        public string xml;
        public string json;
        public IDictionary dictionary;
        public string amazonRefundId;
        public string requestId;
        public string refundReferenceId;
        public string sellerNote;
        public string sellerRefundNote;

        public decimal refundAmount;
        public string refundCurrencyCode;
        public string refundType;
        public decimal feeRefunded;
        public string feeRefundedCurrencyCode;

        public string refundState;

        public DateTime lastUpdateTimestamp;
        public DateTime creationTimestamp;

        public string reasonCode;
        public string reasonDescription;
        public string softDescriptor;

        public List<string> providerCreditReversalId = new List<string>();
        public List<string> providerId = new List<string>();

        public string errorCode;
        public string errorMessage;
        public string parentKey;
        public bool success;


        public RefundResponse(string xml)
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
            AmazonRefundId, RequestId, SellerRefundNote, RefundReferenceId, Amount, CurrencyCode, RefundAmount, FeeRefunded, ReasonCode, ReasonDescription, RefundType,
            SoftDescriptor, State, ProviderCreditReversalSummaryList, LastUpdateTimestamp, CreationTimestamp, member, ProviderId, ProviderSellerId, ProviderCreditReversalId
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
                                        refundAmount = decimal.Parse(obj.ToString());
                                    }
                                    else if (parentKey.Equals(Operator.FeeRefunded.ToString()))
                                    {
                                        feeRefunded = decimal.Parse(obj.ToString());
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
                                    break;
                                case Operator.RefundType:
                                    refundType = obj.ToString();
                                    break;
                                case Operator.ReasonCode:
                                    reasonCode = obj.ToString();
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

        public string GetRefundId()
        {
            return amazonRefundId;
        }
        public string GetRequestId()
        {
            return requestId;
        }
        public string GetRefundReferenceId()
        {
            return refundReferenceId;
        }
        public string GetSellerRefundNote()
        {
            return sellerRefundNote;
        }
        public decimal GetRefundAmount()
        {
            return refundAmount;
        }
        public string GetRefundAmountCurrencyCode()
        {
            return refundCurrencyCode;
        }
        public decimal GetRefundFee()
        {
            return feeRefunded;
        }
        public string GetRefundFeeCurrencyCode()
        {
            return feeRefundedCurrencyCode;
        }
        public string GetRefundType()
        {
            return refundType;
        }
        public string GetRefundState()
        {
            return refundState;
        }
        public IList<string> GetProviderCreditReversalIdList()
        {
            return providerCreditReversalId.AsReadOnly();
        }
        public IList<string> GetProviderIdList()
        {
            return providerId.AsReadOnly();
        }
        public DateTime GetLastUpdateTimestamp()
        {
            return lastUpdateTimestamp;
        }
        public DateTime GetCreationTimestamp()
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
        public string GetSoftDescriptor()
        {
            return softDescriptor;
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
        public string GetXml()
        {
            return xml;
        }
        public string GetJson()
        {
            return json;
        }
        public IDictionary GetDictionary()
        {
            return dictionary;
        }

    }
}
