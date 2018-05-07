using System;
using System.Collections;

namespace AmazonPay.Responses
{
    /// <summary>
    /// Documentation Source https://pay.amazon.com/documentation/apireference/201752740#201751720
    /// </summary>

    public class ValidateBillingAgreementResponse : AbstractResponse
    {
        private string validationResult;
        private string failureReasonCode;
        private string billingAgreementState;

        private string reasonCode;
        private string reasonDescription;
        private DateTime lastUpdatedTimestamp;

        private string parentKey;


        /// <summary>
        /// Get the ValidateBillingAgreementResponse
        /// </summary>
        public ValidateBillingAgreementResponse(string xml)
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
                                case Operator.ValidationResult:
                                    validationResult = obj.ToString();
                                    break;
                                case Operator.FailureReasonCode:
                                    failureReasonCode = obj.ToString();
                                    break;
                                case Operator.State:
                                    billingAgreementState = obj.ToString();
                                    break;
                                case Operator.ReasonCode:
                                    reasonCode = obj.ToString();
                                    break;
                                case Operator.ReasonDescription:
                                    reasonDescription = obj.ToString();
                                    break;
                                case Operator.LastUpdatedTimestamp:
                                    lastUpdatedTimestamp = DateTime.Parse(obj.ToString());
                                    break;
                                case Operator.RequestId:
                                    requestId = obj.ToString();
                                    break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get the ValidationResult
        /// </summary>
        /// <returns>string validationResult</returns>
        public string GetValidationResult()
        {
            return this.validationResult;
        }

        /// <summary>
        /// Get the FailureReasonCode
        /// </summary>
        /// <returns>string failureReasonCode</returns>
        public string GetFailureReasonCode()
        {
            return this.failureReasonCode;
        }

        /// <summary>
        /// Get the BillingAgreementState
        /// </summary>
        /// <returns>string billingAgreementState</returns>
        public string GetBillingAgreementState() 
        {
            return this.billingAgreementState;
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
        /// Get the LastUpdatedTimestamp
        /// </summary>
        /// <returns>DateTime lastUpdatedTimestamp</returns>
        public DateTime GetLastUpdatedTimestamp()
        {
            return this.lastUpdatedTimestamp;
        }
    }
}

