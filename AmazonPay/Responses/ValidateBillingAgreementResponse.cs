﻿using System;
using System.Collections;

namespace AmazonPay.Responses
{
    /// <summary>
    /// Documentation Source https://pay.amazon.com/documentation/apireference/201752740#201751720
    /// </summary>

    public class ValidateBillingAgreementResponse : IResponse
    {
        public string xml;
        public string json;
        public IDictionary dictionary;
        private string validationResult;
        private string failureReasonCode;
        private string billingAgreementState;

        private string reasonCode;
        private string reasonDescription;
        private string requestId;
        private DateTime lastUpdatedTimestamp;

        private readonly string errorCode;
        private readonly string errorMessage;
        public string parentKey;
        private readonly bool success;


        public ValidateBillingAgreementResponse(string xml)
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

        public string GetValidationResult()
        {
            return validationResult;
        }
        public string GetFailureReasonCode()
        {
            return failureReasonCode;
        }
        public string GetReasonCode()
        {
            return reasonCode;
        }
        public string GetReasonDescription()
        {
            return reasonDescription;
        }
        public DateTime GetLastUpdatedTimestamp()
        {
            return lastUpdatedTimestamp;
        }
        public string GetRequestId()
        {
            return requestId;
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
            return json;
        }
        public string GetXml()
        {
            return xml;
        }
        public IDictionary GetDictionary()
        {
            return dictionary;
        }
    }
}

