using log4net;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.Responses
{
    public class GetProviderCreditDetailsResponse
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
        private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public GetProviderCreditDetailsResponse(string xml)
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
                log.Debug("METHOD__GetProviderCreditDetailsResponse Constructor | MESSAGE__success:" + this.success);
                this.errorCode = errorResponse.GetErrorCode();
                log.Debug("METHOD__GetProviderCreditDetailsResponse Constructor | MESSAGE__errorCode:" + this.errorCode);
                this.errorMessage = errorResponse.GetErrorMessage();
                log.Debug("METHOD__GetProviderCreditDetailsResponse Constructor | MESSAGE__errorMessage:" + this.errorMessage);
                this.requestId = errorResponse.GetRequestId();
                log.Debug("METHOD__GetProviderCreditDetailsResponse Constructor | MESSAGE__RequestId:" + this.requestId);
            }
            else
            {
                success = true;
                log.Debug("METHOD__GetProviderCreditDetailsResponse Constructor | MESSAGE__success:" + this.success);
                ParseDictionaryToVariables(this.dictionary);
            }
        }

        private enum Operator
        {
            AmazonProviderCreditId, RequestId, ProviderId, CreditReferenceId, Amount, CreditAmount, CreditReversalAmount, CurrencyCode, ReasonCode, ReasonDescription,
            State, SoftDescriptor, LastUpdateTimestamp, member, SellerId
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
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__AmazonProviderCreditId:" + this.amazonProviderCreditId);
                                    break;
                                case Operator.RequestId:
                                    requestId = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__RequestId:" + this.requestId);
                                    break;
                                case Operator.ProviderId:
                                    providerId = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__ProviderId:" + this.providerId);
                                    break;
                                case Operator.SellerId:
                                    sellerId = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__LastUpdateTimestamp:" + this.sellerId);
                                    break;
                                case Operator.CreditReferenceId:
                                    creditReferenceId = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__CreditReferenceId:" + this.creditReferenceId);
                                    break;
                                case Operator.Amount:
                                    if (parentKey.Equals(Operator.CreditAmount.ToString()))
                                    {
                                        creditAmount = decimal.Parse(obj.ToString());
                                        log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__CreditAmount:" + this.creditAmount);
                                    }
                                    else if (parentKey.Equals(Operator.CreditReversalAmount.ToString()))
                                    {
                                        creditReversalAmount = decimal.Parse(obj.ToString());
                                        log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__CreditReversalAmount:" + this.creditReversalAmount);
                                    }
                                    break;
                                case Operator.CurrencyCode:
                                    if (parentKey.Equals(Operator.CreditAmount.ToString()))
                                    {
                                        creditAmountCurrencyCode = obj.ToString();
                                        log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__CreditAmountCurrencyCode:" + this.creditAmountCurrencyCode);
                                    }
                                    else if (parentKey.Equals(Operator.CreditReversalAmount.ToString()))
                                    {
                                        creditReversalAmountCurrencyCode = obj.ToString();
                                        log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__CreditReversalAmountCurrencyCode:" + this.creditReversalAmountCurrencyCode);
                                    }
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
                                    creditStatus = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__CreditStatus:" + this.creditStatus);
                                    break;
                                case Operator.SoftDescriptor:
                                    softDescriptor = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__SoftDescriptor:" + this.softDescriptor);
                                    break;
                                case Operator.LastUpdateTimestamp:
                                    lastUpdateTimestamp = DateTime.Parse(obj.ToString());
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__LastUpdateTimestamp:" + this.lastUpdateTimestamp);
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
                                            log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__ProviderCreditReversalId:" + creditReversalId);
                                        }
                                    }
                                    else
                                    {
                                        creditReversalIdList.Add(obj.ToString());
                                        log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__ProviderCreditReversalId:" + obj.ToString());
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
