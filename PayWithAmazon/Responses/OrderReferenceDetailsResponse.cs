using log4net;
using Newtonsoft.Json;
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

    public class OrderReferenceDetailsResponse
    {
        private string xml;
        private string json;
        private string amazonOrderReferenceId;

        private DateTime expirationTimeStamp;
        private DateTime creationTimestamp;
        private DateTime lastUpdateTimestamp;
        private IDictionary dictionary;
        private List<string> constraintID = new List<string>();
        private List<string> description = new List<string>();
        private bool hasConstraint = false;

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

        private List<string> authorizationId = new List<string>();

        private string phone;
        private string name;
        private string email;

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

        private string errorCode;
        private string errorMessage;

        private bool success = false;
        private string parentKey;

        BillingAddressDetails billingAddress;
        private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public OrderReferenceDetailsResponse(string xml)
        {
            log4net.Config.XmlConfigurator.Configure();
            this.xml = xml;
            ResponseParser.SetXml(xml);
            this.json = ResponseParser.ToJson();
            this.dictionary = ResponseParser.ToDict();

            ErrorResponse errorResponse = new ErrorResponse(this.dictionary);
            if (errorResponse.IsSetErrorCode() || errorResponse.IsSetErrorMessage())
            {
                this.success = false;
                log.Debug("METHOD__OrderReferenceDetailsResponse Constructor | MESSAGE__success:" + this.success);
                this.errorCode = errorResponse.GetErrorCode();
                log.Debug("METHOD__OrderReferenceDetailsResponse Constructor | MESSAGE__errorCode:" + this.errorCode);
                this.errorMessage = errorResponse.GetErrorMessage();
                log.Debug("METHOD__OrderReferenceDetailsResponse Constructor | MESSAGE__errorMessage:" + this.errorMessage);
                this.requestId = errorResponse.GetRequestId();
                log.Debug("METHOD__OrderReferenceDetailsResponse Constructor | MESSAGE__RequestId:" + this.requestId);
            }
            else
            {
                this.success = true;
                log.Debug("METHOD__OrderReferenceDetailsResponse Constructor | MESSAGE__success:" + this.success);
                ParseDictionaryToVariables(this.dictionary);
            }
        }

        private enum Operator
        {
            AmazonOrderReferenceId, ExpirationTimestamp, RequestId, CreationTimestamp, LastUpdateTimestamp, ReasonCode, ReasonDescription, State, SellerNote, Amount,
            CurrencyCode, PlatformId, PostalCode, Name, Type, Id, Email, Phone, CountryCode, StateOrRegion, AddressLine1, AddressLine2, AddressLine3,
            City, County, District, DestinationType, ReleaseEnvironment, SellerOrderId, CustomInformation,
            StoreName, Constraint, ConstraintID, Description, OrderLanguage, member, BillingAddress
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
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__AmazonOrderReferenceId:" + this.amazonOrderReferenceId);
                                    break;
                                case Operator.ExpirationTimestamp:
                                    expirationTimeStamp = DateTime.Parse(obj.ToString());
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__ExpirationTimestamp:" + this.expirationTimeStamp);
                                    break;
                                case Operator.RequestId:
                                    requestId = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__RequestId:" + this.requestId);
                                    break;
                                case Operator.CreationTimestamp:
                                    creationTimestamp = DateTime.Parse(obj.ToString());
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__CreationTimestamp:" + this.creationTimestamp);
                                    break;
                                case Operator.LastUpdateTimestamp:
                                    lastUpdateTimestamp = DateTime.Parse(obj.ToString());
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__LastUpdateTimestamp:" + this.lastUpdateTimestamp);
                                    break;
                                case Operator.ReasonCode:
                                    reasonCode = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__ReasonCode:" + this.reasonCode);
                                    break;
                                case Operator.ReasonDescription:
                                    reasonDescription = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__ReasonDescription:" + this.reasonDescription);
                                    break;
                                case Operator.State:
                                    orderReferenceState = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__OrderReferenceState:" + this.orderReferenceState);
                                    break;
                                case Operator.SellerNote:
                                    sellerNote = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__SellerNote:" + this.sellerNote);
                                    break;
                                case Operator.Amount:
                                    amount = decimal.Parse(obj.ToString());
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__Amount:" + this.amount);
                                    break;
                                case Operator.CurrencyCode:
                                    currencyCode = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__CurrencyCode:" + this.currencyCode);
                                    break;
                                case Operator.PlatformId:
                                    platformId = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__PlatformId:" + this.platformId);
                                    break;
                                case Operator.PostalCode:
                                    postalCode = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__PostalCode:" + this.postalCode);
                                    break;
                                case Operator.Name:
                                    name = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__Name:" + this.name);
                                    break;
                                case Operator.Type:
                                    type = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__CreateOrderReferenceForIDType:" + this.type);
                                    break;
                                case Operator.Id:
                                    id = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__AmazonBillingAgreementId:" + this.id);
                                    break;
                                case Operator.Email:
                                    email = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__Email:" + this.email);
                                    break;
                                case Operator.Phone:
                                    phone = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__Phone:" + this.phone);
                                    break;
                                case Operator.CountryCode:
                                    countryCode = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__CountryCode:" + this.countryCode);
                                    break;
                                case Operator.StateOrRegion:
                                    stateOrRegion = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__StateOrRegion:" + this.stateOrRegion);
                                    break;
                                case Operator.AddressLine1:
                                    addressLine1 = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__AddressLine1:" + this.addressLine1);
                                    break;
                                case Operator.AddressLine2:
                                    addressLine2 = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__AddressLine2:" + this.addressLine2);
                                    break;
                                case Operator.AddressLine3:
                                    addressLine3 = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__AddressLine3:" + this.addressLine3);
                                    break;
                                case Operator.City:
                                    city = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__City:" + this.city);
                                    break;
                                case Operator.County:
                                    county = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__County:" + this.county);
                                    break;
                                case Operator.District:
                                    district = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__District:" + this.district);
                                    break;
                                case Operator.DestinationType:
                                    destinationType = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__DestinationType:" + this.destinationType);
                                    break;
                                case Operator.ReleaseEnvironment:
                                    releaseEnvironment = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__ReleaseEnvironment:" + this.releaseEnvironment);
                                    break;
                                case Operator.SellerOrderId:
                                    sellerOrderId = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__SellerOrderId:" + this.sellerOrderId);
                                    break;
                                case Operator.CustomInformation:
                                    customInformation = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__CustomInformation:" + this.customInformation);
                                    break;
                                case Operator.StoreName:
                                    storeName = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__StoreName:" + this.storeName);
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
                                                log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__ConstraintID:" + value);
                                            }
                                            if (key.Equals(Operator.Description.ToString()))
                                            {
                                                description.Add(value);
                                                log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__Description:" + value);
                                            }
                                        }
                                    }
                                    break;
                                case Operator.ConstraintID:
                                    constraintID.Add(obj.ToString());
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__ConstraintID:" + obj.ToString());
                                    hasConstraint = true;
                                    break;
                                case Operator.Description:
                                    description.Add(obj.ToString());
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__Description:" + obj.ToString());
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
                                            log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__AuthorizationId:" + authId);
                                        }
                                    }
                                    else
                                    {
                                        authorizationId.Add(obj.ToString());
                                        log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__AuthorizationId:" + obj.ToString());
                                    }
                                    break;
                                case Operator.OrderLanguage:
                                    orderLanguage = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__OrderLanguage:" + this.orderLanguage);
                                    break;
                            }
                        }
                    }
                }
            }
        }

        public string GetAmazonOrderReferenceId()
        {
            return this.amazonOrderReferenceId;
        }
        public DateTime GetExpirationTimestamp()
        {
            return this.expirationTimeStamp;
        }
        public DateTime GetCreationTimestamp()
        {
            return this.creationTimestamp;
        }
        public DateTime GetLastUpdateTimestamp()
        {
            return this.lastUpdateTimestamp;
        }
        public string GetRequestId()
        {
            return this.requestId;
        }
        public string GetReasonCode()
        {
            return this.reasonCode;
        }
        public string GetReasonDescription()
        {
            return this.reasonDescription;
        }
        public string GetOrderReferenceState()
        {
            return this.orderReferenceState;
        }
        public string GetOrderLanguage()
        {
            return this.orderLanguage;
        }
        public string GetAddressLine1()
        {
            return this.addressLine1;
        }
        public string GetAddressLine2()
        {
            return this.addressLine2;
        }
        public string GetAddressLine3()
        {
            return this.addressLine3;
        }
        public decimal GetAmount()
        {
            return this.amount;
        }
        public string GetCurrencyCode()
        {
            return this.currencyCode;
        }
        public IList<string> GetAuthorizationIdList()
        {
            return this.authorizationId.AsReadOnly();
        }
        public string GetCity()
        {
            return this.city;
        }
        public IList<string> GetConstraintIdList()
        {
            return this.constraintID.AsReadOnly();
        }
        public string GetCountryCode()
        {
            return this.countryCode;
        }
        public string GetCounty()
        {
            return this.county;
        }
        public string GetCustomInformation()
        {
            return this.customInformation;
        }
        public IList<string> GetDescriptionList()
        {
            return this.description.AsReadOnly();
        }
        public string GetDestinationType()
        {
            return this.destinationType;
        }
        public string GetDistrict()
        {
            return this.district;
        }
        public string GetEmail()
        {
            return this.email;
        }
        public string GetErrorCode()
        {
            return this.errorCode;
        }
        public string GetErrorMessage()
        {
            return this.errorMessage;
        }
        public bool GetHasConstraint()
        {
            return this.hasConstraint;
        }
        public string GetName()
        {
            return this.name;
        }
        public string GetPhone()
        {
            return this.phone;
        }
        public string GetPlatformId()
        {
            return this.platformId;
        }
        public string GetPostalCode()
        {
            return this.postalCode;
        }
        public string GetReleaseEnvironment()
        {
            return this.releaseEnvironment;
        }
        public string GetSellerNote()
        {
            return this.sellerNote;
        }
        public string GetSellerOrderId()
        {
            return this.sellerOrderId;
        }
        public string GetStateOrRegion()
        {
            return this.stateOrRegion;
        }
        public string GetStoreName()
        {
            return this.storeName;
        }
        public BillingAddressDetails GetBillingAddressDetails()
        {
            return this.billingAddress;
        }
        public bool GetSuccess()
        {
            return this.success;
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
