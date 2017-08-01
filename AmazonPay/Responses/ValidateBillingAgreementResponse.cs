using System;
using System.Collections;

namespace AmazonPay.Responses
{
    /// <summary>
    /// Documentation Source https://pay.amazon.com/documentation/apireference/201752740#201751720
    /// </summary>

    public class ValidateBillingAgreementResponse : IResponse
    {
        private string xml;
        private string json;
        private IDictionary dictionary;
        private string validationResult;
        private string failureReasonCode;
        private string billingAgreementState;

        private string reasonCode;
        private string reasonDescription;
        private string requestId;
        private DateTime lastUpdatedTimestamp;

        private string errorCode;
        private string errorMessage;
        private string parentKey;
        private bool success = false;


        /// <summary>
        /// Get the ValidateBillingAgreementResponse
        /// </summary>
        public ValidateBillingAgreementResponse(string xml)
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

        /// <summary>
        /// Get the RequestId
        /// </summary>
        /// <returns>string requestId</returns>
        public string GetRequestId()
        {
            return this.requestId;
        }

        /// <summary>
        /// Get the Success
        /// </summary>
        /// <returns>bool success</returns>
        public bool GetSuccess()
        {
            return success;
        }

        /// <summary>
        /// Get the ErrorCode
        /// </summary>
        /// <returns>string errorCode</returns>
        public string GetErrorCode()
        {
            return errorCode;
        }

        /// <summary>
        /// Get the ErrorMessage
        /// </summary>
        /// <returns>string errorMessage</returns>
        public string GetErrorMessage()
        {
            return errorMessage;
        }

        /// <summary>
        /// Get the Json
        /// </summary>
        /// <returns>string json</returns>
        public string GetJson()
        {
            return this.json;
        }

        /// <summary>
        /// Get the XML
        /// </summary>
        /// <returns>string xml</returns>
        public string GetXml()
        {
            return this.xml;
        }

        /// <summary>
        /// Get the Dictionary
        /// </summary>
        /// <returns>IDictionary dictionary</returns>
        public IDictionary GetDictionary()
        {
            return this.dictionary;
        }
    }
}

