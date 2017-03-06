﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AmazonPay.Responses
{
    public class AuthorizeResponse : IResponse
    {
        /// <summary>
        /// Documentation source https://pay.amazon.com/documentation/apireference/201752450
        /// AuthorizeResponse handles Response parsing for API calls
        /// 1. Authorize
        /// 2. GetAuthorizationDetails
        /// 3. AuthorizeOnBillingAgreement
        /// </summary>

        public string xml;
        public string json;
        public IDictionary dictionary;
        public string authorizationId;

        /// <summary>
        /// AmazonOrderReferenceId returned only for AuthorizeOnBillingAgreement API call
        /// </summary>
        public string amazonOrderReferenceId;
        public string requestId;
        public string authorizationReferenceId;
        public string sellerAuthorizationNote;

        public decimal authorizationAmount;
        public decimal capturedAmount;
        public string capturedAmountCurrencyCode;
        public string authorizationAmountCurrencyCode;

        public decimal authorizationFee;
        public string authorizationFeeCurrencyCode;
        public string authorizationState;
        public List<string> captureId = new List<string>();

        public DateTime lastUpdateTimestamp;
        public DateTime expirationTimeStamp;
        public DateTime creationTimestamp;

        public string reasonCode;
        public string reasonDescription;

        public bool captureNow;
        public string softDescriptor;

        public string errorCode;
        public string errorMessage;
        public string parentKey;

        public bool success;


        public AuthorizeResponse(string xml)
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
            AmazonOrderReferenceId, AmazonAuthorizationId, RequestId, SellerAuthorizationNote, ExpirationTimestamp, CreationTimestamp, AuthorizationReferenceId, State, Amount,
            AuthorizationAmount, CapturedAmount, AuthorizationFee, CurrencyCode, ReasonCode, ReasonDescription, CaptureNow, SoftDescriptor, LastUpdateTimestamp, member
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
                                case Operator.AmazonOrderReferenceId:
                                    amazonOrderReferenceId = obj.ToString();
                                    break;
                                case Operator.AmazonAuthorizationId:
                                    authorizationId = obj.ToString();
                                    break;
                                case Operator.RequestId:
                                    requestId = obj.ToString();
                                    break;
                                case Operator.SellerAuthorizationNote:
                                    sellerAuthorizationNote = obj.ToString();
                                    break;
                                case Operator.ExpirationTimestamp:
                                    expirationTimeStamp = DateTime.Parse(obj.ToString());
                                    break;
                                case Operator.LastUpdateTimestamp:
                                    lastUpdateTimestamp = DateTime.Parse(obj.ToString());
                                    break;
                                case Operator.CreationTimestamp:
                                    creationTimestamp = DateTime.Parse(obj.ToString());
                                    break;
                                case Operator.AuthorizationReferenceId:
                                    authorizationReferenceId = obj.ToString();
                                    break;
                                case Operator.State:
                                    authorizationState = obj.ToString();
                                    break;
                                case Operator.Amount:
                                    if (parentKey.Equals(Operator.AuthorizationAmount.ToString()))
                                    {
                                        authorizationAmount = decimal.Parse(obj.ToString());
                                    }
                                    else if (parentKey.Equals(Operator.CapturedAmount.ToString()))
                                    {
                                        capturedAmount = decimal.Parse(obj.ToString());
                                    }
                                    else if (parentKey.Equals(Operator.AuthorizationFee.ToString()))
                                    {
                                        authorizationFee = decimal.Parse(obj.ToString());
                                    }
                                    break;
                                case Operator.CurrencyCode:
                                    if (parentKey.Equals(Operator.AuthorizationAmount.ToString()))
                                    {
                                        authorizationAmountCurrencyCode = obj.ToString();
                                    }
                                    else if (parentKey.Equals(Operator.CapturedAmount.ToString()))
                                    {
                                        capturedAmountCurrencyCode = obj.ToString();
                                    }
                                    else if (parentKey.Equals(Operator.AuthorizationFee.ToString()))
                                    {
                                        authorizationFeeCurrencyCode = obj.ToString();
                                    }
                                    break;
                                case Operator.ReasonCode:
                                    reasonCode = obj.ToString();
                                    break;
                                case Operator.ReasonDescription:
                                    reasonDescription = obj.ToString();
                                    break;
                                case Operator.CaptureNow:
                                    captureNow = bool.Parse(obj.ToString());
                                    break;
                                case Operator.SoftDescriptor:
                                    softDescriptor = obj.ToString();
                                    break;
                                case Operator.member:
                                    if (obj.GetType() == typeof(JArray))
                                    {
                                        JArray capIdArray = JArray.Parse(obj.ToString());
                                        foreach (string capId in capIdArray)
                                        {
                                            captureId.Add(capId);
                                        }
                                    }
                                    else
                                    {
                                        captureId.Add(obj.ToString());
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get the Amazon Order Reference ID, Returned only for the AuthorizeOnBillingAgreement API call
        /// </summary>
        /// <returns>amazonOrderReferenceId</returns>
        public string GetAmazonOrderReferenceId()
        {
            return amazonOrderReferenceId;
        }

        /// <summary>
        /// Get the Amazon Authorization ID
        /// </summary>
        /// <returns>authorizationId</returns>
        public string GetAuthorizationId()
        {
            return authorizationId;
        }

        /// <summary>
        /// Get the request ID for the API call
        /// </summary>
        /// <returns>requestId</returns>
        public string GetRequestId()
        {
            return requestId;
        }

        /// <summary>
        /// Get the Authorization Reference ID
        /// </summary>
        /// <returns>authorizationReferenceId</returns>
        public string GetAuthorizationReferenceId()
        {
            return authorizationReferenceId;
        }

        /// <summary>
        /// Get the Seller Authorization Note
        /// </summary>
        /// <returns>sellerAuthorizationNote</returns>
        public string GetSellerAuthorizationNote()
        {
            return sellerAuthorizationNote;
        }

        /// <summary>
        /// Get the Amount Authorized for the order
        /// </summary>
        /// <returns>authorizationAmount</returns>
        public decimal GetAuthorizationAmount()
        {
            return authorizationAmount;
        }

        /// <summary>
        /// Get the Currency Code of the Authorized Amount
        /// </summary>
        /// <returns>authorizationAmountCurrencyCode</returns>
        public string GetAuthorizationAmountCurrencyCode()
        {
            return authorizationAmountCurrencyCode;
        }

        /// <summary>
        /// Get the Captured Amount Currency Code
        /// </summary>
        /// <returns>capturedAmountCurrencyCode</returns>
        public string GetCapturedAmountCurrencyCode()
        {
            return capturedAmountCurrencyCode;
        }

        /// <summary>
        /// Get the Amount captured
        /// </summary>
        /// <returns>capturedAmount</returns>
        public decimal GetCapturedAmount()
        {
            return capturedAmount;
        }

        /// <summary>
        /// Get the Authorization Fee
        /// </summary>
        /// <returns>authorizationFee</returns>
        public decimal GetAuthorizationFee()
        {
            return authorizationFee;
        }

        /// <summary>
        /// Get the Authorization Fee Currency Code
        /// </summary>
        /// <returns>authorizationFeeCurrencyCode</returns>
        public string GetAuthorizationFeeCurrencyCode()
        {
            return authorizationFeeCurrencyCode;
        }

        /// <summary>
        /// Get the State of the Authorization 
        /// </summary>
        /// <returns>authorizationState</returns>
        public string GetAuthorizationState()
        {
            return authorizationState;
        }

        /// <summary>
        /// Get the List of Captures made on this Authorization
        /// </summary>
        /// <returns>captureId</returns>
        public IList<string> GetCaptureIdList()
        {
            return captureId.AsReadOnly();
        }

        /// <summary>
        /// Get the Last Updated Time Stamp of this Authorization
        /// </summary>
        /// <returns>lastUpdateTimestamp</returns>
        public DateTime GetLastUpdateTimestamp()
        {
            return lastUpdateTimestamp;
        }

        /// <summary>
        /// Get the Expiration Timestamp of the Authorization
        /// </summary>
        /// <returns>expirationTimeStamp</returns>
        public DateTime GetExpirationTimestamp()
        {
            return expirationTimeStamp;
        }

        /// <summary>
        /// Get the Creation Time stamp of the Authorization
        /// </summary>
        /// <returns>creationTimestamp</returns>
        public DateTime GetCreationTimestamp()
        {
            return creationTimestamp;
        }

        /// <summary>
        /// Get the Reason Code for when the Authorization was closed or declined
        /// </summary>
        /// <returns>reasonCode</returns>
        public string GetReasonCode()
        {
            return reasonCode;
        }

        /// <summary>
        /// Get the Description for when the Authorization was closed or declined
        /// </summary>
        /// <returns>reasonDescription</returns>
        public string GetReasonDescription()
        {
            return reasonDescription;
        }

        /// <summary>
        /// Get the bool value if the captureNow was set to True or False
        /// </summary>
        /// <returns>captureNow</returns>
        public bool GetCaptureNow()
        {
            return captureNow;
        }

        /// <summary>
        /// Get the SoftDescriptor value
        /// </summary>
        /// <returns>softDescriptor</returns>
        public string GetSoftDescriptor()
        {
            return softDescriptor;
        }

        /// <summary>
        /// Get the bool value to know if the API call was a success(true) or a failure(false)
        /// </summary>
        /// <returns>success can be true or false</returns>
        public bool GetSuccess()
        {
            return success;
        }

        /// <summary>
        /// If the API call failed Get the Error Code
        /// </summary>
        /// <returns>errorCode</returns>
        public string GetErrorCode()
        {
            return errorCode;
        }

        /// <summary>
        /// If the API call failed Get the Error Message
        /// </summary>
        /// <returns>errorMessage</returns>
        public string GetErrorMessage()
        {
            return errorMessage;
        }

        /// <summary>
        /// Response returned in JSON format
        /// </summary>
        /// <returns>JSON format Response</returns>
        public string GetJson()
        {
            return json;
        }

        /// <summary>
        /// Response returned in XML format
        /// </summary>
        /// <returns>XML format Response</returns>
        public string GetXml()
        {
            return xml;
        }

        /// <summary>
        /// Response in Dictionary Format
        /// </summary>
        /// <returns>Dictionary<string,object> type Response</returns>
        public IDictionary GetDictionary()
        {
            return dictionary;
        }
    }
}
