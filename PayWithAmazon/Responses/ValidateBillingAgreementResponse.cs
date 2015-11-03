using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.Responses
{
    /// <summary>
    /// Documentation Source https://payments.amazon.com/documentation/apireference/201752740#201751720
    /// </summary>

    public class ValidateBillingAgreementResponse
    {
        public string xml;
        public string json;
        public IDictionary dictionary;
        private string validationResult;
        private string failureReasonCode;
        private string billingAgreementState;

        private int reasonCode;
        private string reasonDescription;
        private string requestId;
        private DateTime lastUpdatedTimestamp;

        private string errorCode;
        private string errorMessage;
        public string parentKey;
        private bool success = false;
        private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ValidateBillingAgreementResponse(string xml)
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
                log.Debug("METHOD__ValidateBillingAgreementResponse Constructor | MESSAGE__success:" + this.success);
                this.errorCode = errorResponse.GetErrorCode();
                log.Debug("METHOD__ValidateBillingAgreementResponse Constructor | MESSAGE__errorCode:" + this.errorCode);
                this.errorMessage = errorResponse.GetErrorMessage();
                log.Debug("METHOD__ValidateBillingAgreementResponse Constructor | MESSAGE__errorMessage:" + this.errorMessage);
                this.requestId = errorResponse.GetRequestId();
                log.Debug("METHOD__ValidateBillingAgreementResponse Constructor | MESSAGE__RequestId:" + this.requestId);
            }
            else
            {
                success = true;
                log.Debug("METHOD__ValidateBillingAgreementResponse Constructor | MESSAGE__success:" + this.success);
                ParseDictionaryToVariables(this.dictionary);
            }
        }

        private enum Operator
        {
            ValidationResult, FailureReasonCode, State, ReasonCode, ReasonDescription, LastUpdatedTimestamp, RequestId
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
                                case Operator.ValidationResult:
                                    validationResult = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__ValidationResult:" + this.validationResult);
                                    break;
                                case Operator.FailureReasonCode:
                                    failureReasonCode = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__FailureReasonCode:" + this.failureReasonCode);
                                    break;
                                case Operator.State:
                                    billingAgreementState = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__BillingAgreementState:" + this.billingAgreementState);
                                    break;
                                case Operator.ReasonCode:
                                    reasonCode = int.Parse(obj.ToString());
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__reasonCode:" + this.reasonCode);
                                    break;
                                case Operator.ReasonDescription:
                                    reasonDescription = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__ReasonDescription:" + this.reasonDescription);
                                    break;
                                case Operator.LastUpdatedTimestamp:
                                    lastUpdatedTimestamp = DateTime.Parse(obj.ToString());
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__LastUpdatedTimestamp:" + this.lastUpdatedTimestamp);
                                    break;
                                case Operator.RequestId:
                                    requestId = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__RequestId:" + this.requestId);
                                    break;
                            }
                        }
                    }
                }
            }
        }

        public string GetValidationResult()
        {
            return this.validationResult;
        }
        public string GetFailureReasonCode()
        {
            return this.failureReasonCode;
        }
        public int GetReasonCode()
        {
            return this.reasonCode;
        }
        public string GetReasonDescription()
        {
            return this.reasonDescription;
        }
        public DateTime GetLastUpdatedTimestamp()
        {
            return this.lastUpdatedTimestamp;
        }
        public string GetRequestId()
        {
            return this.requestId;
        }
        public bool GetSuccess()
        {
            return success;
        }
        public string GetErrorCode()
        {
            return errorCode;
        }
        public string GetErrorMessage()
        {
            return errorMessage;
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

