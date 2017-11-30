using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AmazonPay.Responses
{

    public class ChargebackResponse : IResponse
    {
        private string xml;
        private string json;
        private IDictionary dictionary;
        private string amazonChargebackId;
        private string amazonOrderReferenceId;
        private string amazonCaptureReferenceId;
        private DateTime creationTimestamp;
        private string chargebackState;
        private string chargebackReason;
        private decimal chargebackAmount;
        private string chargebackAmountCurrencyCode;


        private string requestId;

        private string errorCode;
        private string errorMessage;
        private string parentKey;
        private bool success = false;


        /// <summary>
        /// Get the ChargebackResponse
        /// </summary>
        public ChargebackResponse(string xml)
        {
            this.xml = xml;
            this.json = ResponseParser.ToJson(xml);
            this.dictionary = ResponseParser.ToDict(xml);

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
            AmazonChargebackId, AmazonOrderReferenceId, AmazonCaptureReferenceId, RequestId, Amount, CurrencyCode, ChargebackReason, ChargebackState, CreationTimestamp
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
                                case Operator.AmazonCaptureReferenceId:
                                    amazonCaptureReferenceId = obj.ToString();
                                    break;
                                case Operator.AmazonChargebackId:
                                    amazonChargebackId = obj.ToString();
                                    break;
                                case Operator.AmazonOrderReferenceId:
                                    amazonOrderReferenceId = obj.ToString();
                                    break;
                                case Operator.RequestId:
                                    requestId = obj.ToString();
                                    break;
                                case Operator.Amount:
                                    chargebackAmount = decimal.Parse(obj.ToString(), Constants.USNumberFormat);
                                    break;
                                case Operator.CurrencyCode:
                                    chargebackAmountCurrencyCode = obj.ToString();
                                    break;
                                case Operator.ChargebackReason:
                                    chargebackReason = obj.ToString();
                                    break;
                                case Operator.ChargebackState:
                                    chargebackState = obj.ToString();
                                    break;
                                case Operator.CreationTimestamp:
                                    creationTimestamp = DateTime.Parse(obj.ToString());
                                    break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get the Amazon ChargebackId 
        /// </summary>
        /// <returns>string amazonChargebackId</returns>
        public string GetAmazonChargebackId()
        {
            return this.amazonChargebackId;
        }

        /// <summary>
        /// Get the RequestID
        /// </summary>
        /// <returns>string requestID</returns>
        public string GetRequestId()
        {
            return this.requestId;
        }

        /// <summary>
        /// Get the AmazonCaptureId 
        /// </summary>
        /// <returns>string AmazonCaptureId</returns>
        public string GetAmazonCaptureId()
        {
            return this.amazonCaptureReferenceId;
        }

        /// <summary>
        /// Get the AmazonOrderReferenceId
        /// </summary>
        /// <returns>string AmazonOrderReferenceId</returns>
        public string GetOrderReferenceId()
        {
            return this.amazonOrderReferenceId;
        }

        /// <summary>
        /// Get the Chargeback Amount
        /// </summary>
        /// <returns>decimal chargebackAmount</returns>
        public decimal GetChargebackAmount()
        {
            return this.chargebackAmount;
        }

        /// <summary>
        /// Get the Chargeback Amount Currency Code
        /// </summary>
        /// <returns>string chargebackAmountCurrencyCode</returns>
        public string GetChargebackAmountCurrencyCode()
        {
            return this.chargebackAmountCurrencyCode;
        }

        /// <summary>
        /// Get the Chargeback State
        /// </summary>
        /// <returns>string chargebackState</returns>
        public string GetChargebackState()
        {
            return this.chargebackState;
        }

        /// <summary>
        /// Get the chargeback Reason
        /// </summary>
        /// <returns>string chargebackReason</returns>
        public string GetChargebackReason()
        {
            return this.chargebackReason;
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
        /// Get the Success
        /// </summary>
        /// <returns>bool success</returns>
        public bool GetSuccess()
        {
            return success;
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
        /// Get the Json
        /// </summary>
        /// <returns>string json</returns>
        public string GetJson()
        {
            return this.json;
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
