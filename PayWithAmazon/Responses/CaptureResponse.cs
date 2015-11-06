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

    public class CaptureResponse
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
            ReasonDescription, State, SoftDescriptor, LastUpdateTimestamp, CreationTimestamp, member, IdList, ProviderCreditSummaryList, ProviderId, ProviderCreditId
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
                                                if (key.Equals(Operator.ProviderId.ToString()))
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
                                case Operator.ProviderCreditId:
                                    providerCreditId.Add(obj.ToString());
                                    break;
                            }
                        }
                    }
                }
            }
        }

        public string GetCaptureId()
        {
            return this.amazonCaptureId;
        }
        public string GetRequestId()
        {
            return this.requestId;
        }
        public string GetCaptureReferenceId()
        {
            return this.captureReferenceId;
        }
        public DateTime GetLastUpdatedTimestamp()
        {
            return this.lastUpdateTimestamp;
        }
        public string GetSellerCaptureNote()
        {
            return this.sellerCaptureNote;
        }
        public decimal GetCaptureAmount()
        {
            return this.captureAmount;
        }
        public string GetCaptureAmountCurrencyCode()
        {
            return this.captureCurrencyCode;
        }
        public decimal GetCapturedAmount()
        {
            return this.captureAmount;
        }
        public decimal GetCaptureFee()
        {
            return this.captureFeeAmount;
        }
        public string GetCaptureFeeCurrencyCode()
        {
            return this.captureFeeCurrencyCode;
        }
        public string GetCaptureState()
        {
            return this.captureState;
        }
        public IList<string> GetRefundIdList()
        {
            return this.refundId.AsReadOnly();
        }
        public IList<string> GetProviderCreditIdList()
        {
            return this.providerCreditId.AsReadOnly();
        }
        public IList<string> GetProviderIdList()
        {
            return this.providerId.AsReadOnly();
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
