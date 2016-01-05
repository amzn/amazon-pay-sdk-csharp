using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.Responses
{
    /// <summary>
    /// Documentation Source https://payments.amazon.com/documentation/apireference/201752580
    /// </summary>

    public class CaptureResponse : IResponse
    {
        public string xml;
        public string json;
        public IDictionary dictionary;
        public string amazonCaptureId;
        public string requestId;
        public string captureReferenceId;
        public string sellerCaptureNote;

        public decimal captureAmount;
        public string captureCurrencyCode;

        public decimal refundedAmount;
        public string refundedAmountCurrencyCode;

        public decimal captureFeeAmount;
        public string captureFeeCurrencyCode;

        public string captureState;
        public List<string> refundId = new List<string>();

        public DateTime lastUpdateTimestamp;
        public DateTime creationTimestamp;

        public string reasonCode;
        public string reasonDescription;
        public string softDescriptor;

        public List<string> providerId = new List<string>();
        public List<string> providerCreditId = new List<string>();

        public string errorCode;
        public string errorMessage;
        public bool success = false;
        public string parentKey;


        public CaptureResponse(string xml)
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
            AmazonCaptureId, RequestId, SellerCaptureNote, CaptureReferenceId, Amount, CaptureAmount, RefundedAmount, CaptureFee, CurrencyCode, ReasonCode,
            ReasonDescription, State, SoftDescriptor, LastUpdateTimestamp, CreationTimestamp, member, IdList,
            ProviderCreditSummaryList, ProviderId, ProviderSellerId, ProviderCreditId
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
                                case Operator.AmazonCaptureId:
                                    this.amazonCaptureId = obj.ToString();
                                    break;
                                case Operator.RequestId:
                                    requestId = obj.ToString();
                                    break;
                                case Operator.SellerCaptureNote:
                                    sellerCaptureNote = obj.ToString();
                                    break;
                                case Operator.CaptureReferenceId:
                                    captureReferenceId = obj.ToString();
                                    break;
                                case Operator.Amount:
                                    if (parentKey.Equals(Operator.CaptureAmount.ToString()))
                                    {
                                        captureAmount = decimal.Parse(obj.ToString());
                                    }
                                    else if (parentKey.Equals(Operator.RefundedAmount.ToString()))
                                    {
                                        refundedAmount = decimal.Parse(obj.ToString());
                                    }
                                    else if (parentKey.Equals(Operator.CaptureFee.ToString()))
                                    {
                                        captureFeeAmount = decimal.Parse(obj.ToString());
                                    }
                                    break;
                                case Operator.CurrencyCode:
                                    if (parentKey.Equals(Operator.CaptureAmount.ToString()))
                                    {
                                        captureCurrencyCode = obj.ToString();
                                    }
                                    else if (parentKey.Equals(Operator.RefundedAmount.ToString()))
                                    {
                                        refundedAmountCurrencyCode = obj.ToString();
                                    }
                                    else if (parentKey.Equals(Operator.CaptureFee.ToString()))
                                    {
                                        captureFeeCurrencyCode = obj.ToString();
                                    }
                                    break;
                                case Operator.ReasonCode:
                                    reasonCode = obj.ToString();
                                    break;
                                case Operator.ReasonDescription:
                                    reasonDescription = obj.ToString();
                                    break;
                                case Operator.State:
                                    captureState = obj.ToString();
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
                                    if (parentKey.Equals(Operator.IdList.ToString()))
                                    {
                                        if (obj.GetType() == typeof(JArray))
                                        {
                                            JArray refundIdArray = JArray.Parse(obj.ToString());
                                            foreach (string id in refundIdArray)
                                            {
                                                refundId.Add(id);
                                            }
                                        }
                                        else
                                        {
                                            refundId.Add(obj.ToString());
                                        }
                                    }
                                    if (parentKey.Equals(Operator.ProviderCreditSummaryList.ToString()))
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
                                                if (key.Equals(Operator.ProviderCreditId.ToString()))
                                                {
                                                    providerCreditId.Add(value);
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
                                case Operator.ProviderCreditId:
                                    providerCreditId.Add(obj.ToString());
                                    break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get the Amazon Capture ID
        /// </summary>
        /// <returns>string amazonCaptureId</returns>
        public string GetCaptureId()
        {
            return this.amazonCaptureId;
        }

        /// <summary>
        /// Get the Request ID
        /// </summary>
        /// <returns>string requestId</returns>
        public string GetRequestId()
        {
            return this.requestId;
        }

        /// <summary>
        /// Get the unique Capture Reference Id
        /// </summary>
        /// <returns>string captureReferenceId</returns>
        public string GetCaptureReferenceId()
        {
            return this.captureReferenceId;
        }

        /// <summary>
        /// Get the last Update Timestamp of the Amazon Capture ID
        /// </summary>
        /// <returns>DateTime lastUpdateTimestamp</returns>
        public DateTime GetLastUpdatedTimestamp()
        {
            return this.lastUpdateTimestamp;
        }

        /// <summary>
        /// Get the Seller Capture Note provided 
        /// </summary>
        /// <returns>string sellerCaptureNote</returns>
        public string GetSellerCaptureNote()
        {
            return this.sellerCaptureNote;
        }

        /// <summary>
        /// Get the Captured Amount
        /// </summary>
        /// <returns>decimal captureAmount</returns>
        public decimal GetCaptureAmount()
        {
            return this.captureAmount;
        }

        /// <summary>
        /// Get the Currency Code of the amount Captured
        /// </summary>
        /// <returns>string captureCurrencyCode</returns>
        public string GetCaptureAmountCurrencyCode()
        {
            return this.captureCurrencyCode;
        }

        /// <summary>
        /// Get the Capture Fee
        /// </summary>
        /// <returns>decimal captureFeeAmount</returns>
        public decimal GetCaptureFee()
        {
            return this.captureFeeAmount;
        }

        /// <summary>
        /// Get teh CaptureFee Currency Code
        /// </summary>
        /// <returns>string captureFeeCurrencyCode</returns>
        public string GetCaptureFeeCurrencyCode()
        {
            return this.captureFeeCurrencyCode;
        }

        /// <summary>
        /// Get the state of the Amazon Capture ID
        /// </summary>
        /// <returns>string captureState</returns>
        public string GetCaptureState()
        {
            return this.captureState;
        }

        /// <summary>
        /// Get the IList of the Refund IDS 
        /// </summary>
        /// <returns>IList refundId</returns>
        public IList<string> GetRefundIdList()
        {
            return this.refundId.AsReadOnly();
        }

        /// <summary>
        /// Get the List of Provider Credit IDS
        /// </summary>
        /// <returns>IList providerCreditId</returns>
        public IList<string> GetProviderCreditIdList()
        {
            return this.providerCreditId.AsReadOnly();
        }

        /// <summary>
        /// Get the List of the Provider ID(s)
        /// </summary>
        /// <returns>IList providerId</returns>
        public IList<string> GetProviderIdList()
        {
            return this.providerId.AsReadOnly();
        }

        /// <summary>
        /// Get the Creation Timestamp of the Amazon Capture ID
        /// </summary>
        /// <returns>DateTime creationTimestamp</returns>
        public DateTime GetCreationTimestamp()
        {
            return this.creationTimestamp;
        }

        /// <summary>
        /// Get the Reason code when the Amazon Capture ID is in a different state than Open
        /// </summary>
        /// <returns>string reasonCode</returns>
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

        /// <summary>
        /// Get the ErrorCode when te API call failed
        /// </summary>
        /// <returns>string errorCode</returns>
        public string GetErrorCode()
        {
            return errorCode;
        }

        /// <summary>
        /// Get the ErrorMessage when the API call failed
        /// </summary>
        /// <returns>string errorMesage</returns>
        public string GetErrorMessage()
        {
            return errorMessage;
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
        /// Response returned in JSON format
        /// </summary>
        /// <returns>JSON format Response</returns>
        public string GetJson()
        {
            return this.json;
        }

        /// <summary>
        /// Response returned in XML format
        /// </summary>
        /// <returns>XML format Response</returns>
        public string GetXml()
        {
            return this.xml;
        }

        /// <summary>
        /// Response in Dictionary Format
        /// </summary>
        /// <returns>Dictionary<string,object> type Response</returns>
        public IDictionary GetDictionary()
        {
            return this.dictionary;
        }
    }
}
