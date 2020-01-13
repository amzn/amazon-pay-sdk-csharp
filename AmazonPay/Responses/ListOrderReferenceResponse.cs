using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AmazonPay.Responses
{
    public class ListOrderReferenceResponse : AbstractResponse
    {
        private List<Dictionary<string, string>> orderReferences = new List<Dictionary<string, string>>();
        private string nextPageToken = "";

        /// <summary>
        /// GetMerchantAccountStatusResponse 
        /// </summary>
        public ListOrderReferenceResponse(string xml)
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
                    // if obj is a single instance of OrderReference it will process wrong by default,
                    // this pulls the relevant json from the object and converts it to a single instance to a JArray string for consumption
                    if (obj is IDictionary && strKey == "OrderReference")
                    {
                        JObject jsonObject = JObject.Parse(this.json);
                        if (this.json.Contains("ListOrderReferenceResponse"))
                        {
                            obj = "[" + jsonObject["ListOrderReferenceResponse"]["ListOrderReferenceResult"]["OrderReferenceList"]["OrderReference"].ToString() + "]";
                        }
                        else
                        {
                            obj = "[" + jsonObject["ListOrderReferenceByNextTokenResponse"]["ListOrderReferenceByNextTokenResult"]["OrderReferenceList"]["OrderReference"].ToString() + "]";
                        }
                    }
                    // If obj is dictionary recursively parse it
                    if (obj is IDictionary)
                    {
                        ParseDictionaryToNewVariables((IDictionary)obj);
                    }
                    else
                    {
                        if (Enum.IsDefined(typeof(Operator), strKey))
                        {
                            switch ((Operator)Enum.Parse(typeof(Operator), strKey))
                            {
                                case Operator.NextPageToken:
                                    nextPageToken = obj.ToString();
                                    break;
                                case Operator.OrderReference:
                                    JArray array = JArray.Parse(obj.ToString());

                                    foreach (JObject orderReference in array.Children<JObject>())
                                    {
                                        int orderRefIx = orderReferences.Count;
                                        orderReferences.Add(new Dictionary<string, string>());
                                        orderReferences[orderRefIx].Add("ReleaseEnvironment", orderReference["ReleaseEnvironment"].ToString());
                                        orderReferences[orderRefIx].Add("AmazonOrderReferenceId", orderReference["AmazonOrderReferenceId"].ToString());
                                        orderReferences[orderRefIx].Add("CreationTimestamp", orderReference["CreationTimestamp"].ToString());
                                        orderReferences[orderRefIx].Add("StoreName", orderReference["SellerOrderAttributes"]["StoreName"].ToString());
                                        orderReferences[orderRefIx].Add("SellerOrderId", orderReference["SellerOrderAttributes"]["SellerOrderId"].ToString());
                                        orderReferences[orderRefIx].Add("State", orderReference["OrderReferenceStatus"]["State"].ToString());
                                        orderReferences[orderRefIx].Add("LastUpdateTimestamp", orderReference["OrderReferenceStatus"]["LastUpdateTimestamp"].ToString());
                                        orderReferences[orderRefIx].Add("CurrencyCode", orderReference["OrderTotal"]["CurrencyCode"].ToString());
                                        orderReferences[orderRefIx].Add("Amount", orderReference["OrderTotal"]["Amount"].ToString());
                                        orderReferences[orderRefIx].Add("ReasonDescription", (orderReference["OrderReferenceStatus"]["ReasonDescription"] == null) ? null : orderReference["OrderReferenceStatus"]["ReasonDescription"].ToString());
                                        orderReferences[orderRefIx].Add("ReasonCode", (orderReference["OrderReferenceStatus"]["ReasonCode"] == null) ? null : orderReference["OrderReferenceStatus"]["ReasonCode"].ToString());
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
        }
        /// <summary>
        /// Get the CreationTimestamp 
        /// </summary>
        /// <returns>Datetime creationTimestamp</returns>
        public List<Dictionary<string, string>> GetOrderReferences()
        {
            return this.orderReferences;
        }
        /// <summary>
        /// Get the NextPageToken for use in ListOrderReferenceByToken 
        /// </summary>
        /// <returns>Datetime creationTimestamp</returns>
        public string GetNextPageToken()
        {
            return this.nextPageToken;
        }

    }
}