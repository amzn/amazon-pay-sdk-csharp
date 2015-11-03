using log4net;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.Responses
{
    /// <summary>
    /// Documentation Source https://payments.amazon.com/documentation/apireference/201752740
    /// </summary>

    public class RefundResponse
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
        public bool success = false;
        private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public RefundResponse(string xml)
        {
            log4net.Config.XmlConfigurator.Configure();
            this.xml = xml;
            ResponseParser.SetXml(xml);
            this.json = ResponseParser.ToJson();
            this.dictionary = ResponseParser.ToDict();

            ErrorResponse errorResponse = new ErrorResponse(this.dictionary);
            if (errorResponse.IsSetErrorCode() && errorResponse.IsSetErrorMessage())
            {
                success = false;
                log.Debug("METHOD__RefundResponse Constructor | MESSAGE__success:" + this.success);
                this.errorCode = errorResponse.GetErrorCode();
                log.Debug("METHOD__RefundResponse Constructor | MESSAGE__errorCode:" + this.errorCode);
                this.errorMessage = errorResponse.GetErrorMessage();
                log.Debug("METHOD__RefundResponse Constructor | MESSAGE__errorMessage:" + this.errorMessage);
                this.requestId = errorResponse.GetRequestId();
                log.Debug("METHOD__RefundResponse Constructor | MESSAGE__RequestId:" + this.requestId);
            }
            else
            {
                success = true;
                log.Debug("METHOD__RefundResponse Constructor | MESSAGE__success:" + this.success);
                ParseDictionaryToVariables(this.dictionary);
            }
        }

        private enum Operator
        {
            AmazonRefundId, RequestId, SellerRefundNote, RefundReferenceId, Amount, CurrencyCode, RefundAmount, FeeRefunded, ReasonCode, ReasonDescription, RefundType,
            SoftDescriptor, State, ProviderCreditReversalSummaryList, LastUpdateTimestamp, CreationTimestamp, member, ProviderId, ProviderCreditReversalId
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
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__AmazonRefundId:" + this.amazonRefundId);
                                    break;
                                case Operator.RequestId:
                                    requestId = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__RequestId:" + this.requestId);
                                    break;
                                case Operator.SellerRefundNote:
                                    sellerRefundNote = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__SellerRefundNote:" + this.sellerRefundNote);
                                    break;
                                case Operator.RefundReferenceId:
                                    refundReferenceId = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__RefundReferenceId:" + this.refundReferenceId);
                                    break;
                                case Operator.Amount:
                                    if (parentKey.Equals(Operator.RefundAmount.ToString()))
                                    {
                                        refundAmount = decimal.Parse(obj.ToString());
                                        log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__RefundAmount:" + this.refundAmount);
                                    }
                                    else if (parentKey.Equals(Operator.FeeRefunded.ToString()))
                                    {
                                        feeRefunded = decimal.Parse(obj.ToString());
                                        log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__FeeRefunded:" + this.feeRefunded);
                                    }
                                    break;
                                case Operator.CurrencyCode:
                                    if (parentKey.Equals(Operator.RefundAmount.ToString()))
                                    {
                                        refundCurrencyCode = obj.ToString();
                                        log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__RefundCurrencyCode:" + this.refundCurrencyCode);
                                    }
                                    else if (parentKey.Equals(Operator.FeeRefunded.ToString()))
                                    {
                                        feeRefundedCurrencyCode = obj.ToString();
                                        log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__FeeRefundedCurrencyCode:" + this.feeRefundedCurrencyCode);
                                    }
                                    break;
                                case Operator.RefundType:
                                    refundType = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__RefundType:" + this.refundType);
                                    break;
                                case Operator.ReasonCode:
                                    reasonCode = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__ReasonCode:" + this.reasonCode);
                                    break;
                                case Operator.ReasonDescription:
                                    reasonDescription = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__ReasonDescription:" + this.reasonDescription);
                                    break;
                                case Operator.State:
                                    refundState = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__RefundState:" + this.refundState);
                                    break;
                                case Operator.SoftDescriptor:
                                    softDescriptor = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__SoftDescriptor:" + this.softDescriptor);
                                    break;
                                case Operator.LastUpdateTimestamp:
                                    lastUpdateTimestamp = DateTime.Parse(obj.ToString());
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__LastUpdateTimestamp:" + this.lastUpdateTimestamp);
                                    break;
                                case Operator.CreationTimestamp:
                                    creationTimestamp = DateTime.Parse(obj.ToString());
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__CreationTimestamp:" + this.creationTimestamp);
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
                                                if (key.Equals(Operator.ProviderId.ToString()))
                                                {
                                                    providerId.Add(value);
                                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__ProviderId:" + value);
                                                }
                                                if (key.Equals(Operator.ProviderCreditReversalId.ToString()))
                                                {
                                                    providerCreditReversalId.Add(value);
                                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__ProviderCreditReversalId:" + value);
                                                }
                                            }
                                        }
                                    }
                                    break;

                                case Operator.ProviderId:
                                    providerId.Add(obj.ToString());
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__ProviderId:" + obj.ToString());
                                    break;
                                case Operator.ProviderCreditReversalId:
                                    providerCreditReversalId.Add(obj.ToString());
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__ProviderCreditReversalId:" + obj.ToString());
                                    break;
                            }
                        }
                    }
                }
            }
        }

        public string GetRefundId()
        {
            return this.amazonRefundId;
        }
        public string GetRequestId()
        {
            return this.requestId;
        }
        public string GetRefundReferenceId()
        {
            return this.refundReferenceId;
        }
        public string GetSellerRefundNote()
        {
            return this.sellerRefundNote;
        }
        public decimal GetRefundAmount()
        {
            return this.refundAmount;
        }
        public string GetRefundAmountCurrencyCode()
        {
            return this.refundCurrencyCode;
        }
        public decimal GetRefundFee()
        {
            return this.feeRefunded;
        }
        public string GetRefundFeeCurrencyCode()
        {
            return this.feeRefundedCurrencyCode;
        }
        public string GetRefundType()
        {
            return this.refundType;
        }
        public string GetRefundState()
        {
            return this.refundState;
        }
        public IList<string> GetProviderCreditReversalIdList()
        {
            return this.providerCreditReversalId.AsReadOnly();
        }
        public IList<string> GetProviderIdList()
        {
            return this.providerId.AsReadOnly();
        }
        public DateTime GetLastUpdateTimestamp()
        {
            return this.lastUpdateTimestamp;
        }
        public DateTime GetCreationTimestamp()
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
        public string GetSoftDescriptor()
        {
            return this.softDescriptor;
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
            return this.xml;
        }
        public string GetJson()
        {
            return this.json;
        }
        public IDictionary GetDictionary()
        {
            return this.dictionary;
        }

    }
}
