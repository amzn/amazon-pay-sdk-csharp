using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AmazonPay.Responses
{
    /// <summary>
    /// Documentation Source https://pay.amazon.com/documentation/apireference/201752580
    /// </summary>

    public class OrderReferenceDetailsResponse : IResponse
    {
        private readonly string xml;
        private readonly string json;
        private string amazonOrderReferenceId;

        private DateTime expirationTimeStamp;
        private DateTime creationTimestamp;
        private DateTime lastUpdateTimestamp;
        private readonly IDictionary dictionary;
        private readonly List<string> constraintID = new List<string>();
        private readonly List<string> description = new List<string>();
        private bool hasConstraint;

        private string requestId;
        private string reasonCode;
        private string reasonDescription;
        private string orderLanguage;

        private string orderReferenceState;
        private string sellerNote;
        private string platformId;

        private string releaseEnvironment;
        private decimal amount;
        private string currencyCode;

        private readonly List<string> authorizationId = new List<string>();

        private string phone;
        private string buyerName;
        private string email;

        private string buyerShippingName;
        private string stateOrRegion;
        private string addressLine1;
        private string addressLine2;
        private string addressLine3;
        private string city;
        private string postalCode;
        private string countryCode;
        private string district;
        private string county;
        private string destinationType;

        private string storeName;
        private string sellerOrderId;
        private string customInformation;

        /// <summary>
        /// Billing Agreement ID for CreateOrderReferenceForID API call
        /// </summary>
        private string id;
        private string type;

        private readonly string errorCode;
        private readonly string errorMessage;

        private readonly bool success;
        private string parentKey;

        BillingAddressDetails billingAddress;


        public OrderReferenceDetailsResponse(string xml)
        {
            this.xml = xml;
            ResponseParser.SetXml(xml);
            json = ResponseParser.ToJson();
            dictionary = ResponseParser.ToDict();

            ErrorResponse errorResponse = new ErrorResponse(dictionary);
            if (errorResponse.IsSetErrorCode() || errorResponse.IsSetErrorMessage())
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
            AmazonOrderReferenceId, ExpirationTimestamp, RequestId, CreationTimestamp, LastUpdateTimestamp, ReasonCode, ReasonDescription, State, SellerNote, Amount,
            CurrencyCode, PlatformId, PostalCode, Name, Type, Id, Email, Phone, CountryCode, StateOrRegion, AddressLine1, AddressLine2, AddressLine3,
            City, County, District, DestinationType, ReleaseEnvironment, SellerOrderId, CustomInformation,
            StoreName, Constraint, ConstraintID, Description, OrderLanguage, member, BillingAddress, Buyer
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
                        /* The below if case is when the Billing Address is present. If the key of the parent Dictionary is BillingAddress
                         * then obj being the value of the key will contain the inner Dictionary with Billing Address Details. Send this inner Dictionary
                         * to the BillingAddressDetails class so that it can be seperately flattened and parsed into variables. continue in this case will skip calling the 
                         * ParseDictionaryToVariables function and move to te next element in the parent Dictionary.
                         */
                        if (parentKey.Equals(Operator.BillingAddress.ToString()))
                        {
                            billingAddress = new BillingAddressDetails((IDictionary)obj);
                            continue;
                        }
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
                                case Operator.ExpirationTimestamp:
                                    expirationTimeStamp = DateTime.Parse(obj.ToString());
                                    break;
                                case Operator.RequestId:
                                    requestId = obj.ToString();
                                    break;
                                case Operator.CreationTimestamp:
                                    creationTimestamp = DateTime.Parse(obj.ToString());
                                    break;
                                case Operator.LastUpdateTimestamp:
                                    lastUpdateTimestamp = DateTime.Parse(obj.ToString());
                                    break;
                                case Operator.ReasonCode:
                                    reasonCode = obj.ToString();
                                    break;
                                case Operator.ReasonDescription:
                                    reasonDescription = obj.ToString();
                                    break;
                                case Operator.State:
                                    orderReferenceState = obj.ToString();
                                    break;
                                case Operator.SellerNote:
                                    sellerNote = obj.ToString();
                                    break;
                                case Operator.Amount:
                                    amount = decimal.Parse(obj.ToString());
                                    break;
                                case Operator.CurrencyCode:
                                    currencyCode = obj.ToString();
                                    break;
                                case Operator.PlatformId:
                                    platformId = obj.ToString();
                                    break;
                                case Operator.PostalCode:
                                    postalCode = obj.ToString();
                                    break;
                                case Operator.Name:
                                    /* Name is the Key in XML that is same for both Buyer name and Shipping Address name
                                     * When flattened the XML attribute is lost but saved in the parentKey Variable.
                                     * when parentKey equals 'Buyer' then parse it into buyerName else into buyerShippingName
                                     */
                                    if (parentKey.Equals(Operator.Buyer.ToString()))
                                    {
                                        buyerName = obj.ToString();
                                    }
                                    else
                                    {
                                        buyerShippingName = obj.ToString();
                                    }
                                    break;
                                case Operator.Type:
                                    type = obj.ToString();
                                    break;
                                case Operator.Id:
                                    id = obj.ToString();
                                    break;
                                case Operator.Email:
                                    email = obj.ToString();
                                    break;
                                case Operator.Phone:
                                    phone = obj.ToString();
                                    break;
                                case Operator.CountryCode:
                                    countryCode = obj.ToString();
                                    break;
                                case Operator.StateOrRegion:
                                    stateOrRegion = obj.ToString();
                                    break;
                                case Operator.AddressLine1:
                                    addressLine1 = obj.ToString();
                                    break;
                                case Operator.AddressLine2:
                                    addressLine2 = obj.ToString();
                                    break;
                                case Operator.AddressLine3:
                                    addressLine3 = obj.ToString();
                                    break;
                                case Operator.City:
                                    city = obj.ToString();
                                    break;
                                case Operator.County:
                                    county = obj.ToString();
                                    break;
                                case Operator.District:
                                    district = obj.ToString();
                                    break;
                                case Operator.DestinationType:
                                    destinationType = obj.ToString();
                                    break;
                                case Operator.ReleaseEnvironment:
                                    releaseEnvironment = obj.ToString();
                                    break;
                                case Operator.SellerOrderId:
                                    sellerOrderId = obj.ToString();
                                    break;
                                case Operator.CustomInformation:
                                    customInformation = obj.ToString();
                                    break;
                                case Operator.StoreName:
                                    storeName = obj.ToString();
                                    break;
                                /* The below case is when multiple constraints exist in the response. The flattening of the nested Dictionary
                                 * contains JArray of JObjects. Each Jobject contains ConstraintID and it's Description which is parsed and added to the List
                                 */
                                case Operator.Constraint:
                                    JArray array = JArray.Parse(obj.ToString());
                                    hasConstraint = true;
                                    foreach (JObject item in array.Children<JObject>())
                                    {
                                        foreach (JProperty property in item.Properties())
                                        {
                                            string key = property.Name;
                                            string value = property.Value.ToString();
                                            if (key.Equals(Operator.ConstraintID.ToString()))
                                            {
                                                constraintID.Add(value);
                                            }
                                            if (key.Equals(Operator.Description.ToString()))
                                            {
                                                description.Add(value);
                                            }
                                        }
                                    }
                                    break;
                                case Operator.ConstraintID:
                                    constraintID.Add(obj.ToString());
                                    hasConstraint = true;
                                    break;
                                case Operator.Description:
                                    description.Add(obj.ToString());
                                    hasConstraint = true;
                                    break;
                                /* The below case parses two types of Authorization ID member fields. When the nested Dictionary is flattened
                                 * it contains JArray. JArray contains the member field which contains the Authorization ID. this is added to the List
                                 */
                                case Operator.member:
                                    if (obj.GetType() == typeof(JArray))
                                    {
                                        JArray authIdArray = JArray.Parse(obj.ToString());
                                        foreach (string authId in authIdArray)
                                        {
                                            authorizationId.Add(authId);
                                        }
                                    }
                                    else
                                    {
                                        authorizationId.Add(obj.ToString());
                                    }
                                    break;
                                case Operator.OrderLanguage:
                                    orderLanguage = obj.ToString();
                                    break;
                            }
                        }
                    }
                }
            }
        }

        public string GetAmazonOrderReferenceId()
        {
            return amazonOrderReferenceId;
        }
        public DateTime GetExpirationTimestamp()
        {
            return expirationTimeStamp;
        }
        public DateTime GetCreationTimestamp()
        {
            return creationTimestamp;
        }
        public DateTime GetLastUpdateTimestamp()
        {
            return lastUpdateTimestamp;
        }
        public string GetRequestId()
        {
            return requestId;
        }
        public string GetReasonCode()
        {
            return reasonCode;
        }
        public string GetReasonDescription()
        {
            return reasonDescription;
        }
        public string GetOrderReferenceState()
        {
            return orderReferenceState;
        }
        public string GetOrderLanguage()
        {
            return orderLanguage;
        }
        public string GetAddressLine1()
        {
            return addressLine1;
        }
        public string GetAddressLine2()
        {
            return addressLine2;
        }
        public string GetAddressLine3()
        {
            return addressLine3;
        }
        public decimal GetAmount()
        {
            return amount;
        }
        public string GetCurrencyCode()
        {
            return currencyCode;
        }
        public IList<string> GetAuthorizationIdList()
        {
            return authorizationId.AsReadOnly();
        }
        public string GetCity()
        {
            return city;
        }
        public IList<string> GetConstraintIdList()
        {
            return constraintID.AsReadOnly();
        }
        public string GetBuyerShippingName()
        {
            return buyerShippingName;
        }
        public string GetCountryCode()
        {
            return countryCode;
        }
        public string GetCounty()
        {
            return county;
        }
        public string GetCustomInformation()
        {
            return customInformation;
        }
        public IList<string> GetDescriptionList()
        {
            return description.AsReadOnly();
        }
        public string GetDestinationType()
        {
            return destinationType;
        }
        public string GetDistrict()
        {
            return district;
        }
        public string GetEmail()
        {
            return email;
        }
        public string GetErrorCode()
        {
            return errorCode;
        }
        public string GetErrorMessage()
        {
            return errorMessage;
        }
        public bool GetHasConstraint()
        {
            return hasConstraint;
        }
        public string GetBuyerName()
        {
            return buyerName;
        }
        public string GetPhone()
        {
            return phone;
        }
        public string GetPlatformId()
        {
            return platformId;
        }
        public string GetPostalCode()
        {
            return postalCode;
        }
        public string GetReleaseEnvironment()
        {
            return releaseEnvironment;
        }
        public string GetSellerNote()
        {
            return sellerNote;
        }
        public string GetSellerOrderId()
        {
            return sellerOrderId;
        }
        public string GetStateOrRegion()
        {
            return stateOrRegion;
        }
        public string GetStoreName()
        {
            return storeName;
        }
        public BillingAddressDetails GetBillingAddressDetails()
        {
            return billingAddress;
        }
        public bool GetSuccess()
        {
            return success;
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
