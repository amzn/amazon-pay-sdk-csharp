using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AmazonPay.Responses
{

    public class ChargebackResponse : AbstractResponse
    {
        private string amazonChargebackId;
        private string amazonOrderReferenceId;
        private string amazonCaptureReferenceId;
        private DateTime creationTimestamp;
        private string chargebackState;
        private string chargebackReason;
        private decimal chargebackAmount;
        private string chargebackAmountCurrencyCode;
        
        private string parentKey;

        /// <summary>
        /// Get the ChargebackResponse
        /// </summary>
        public ChargebackResponse(string xml)
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
    }
}
