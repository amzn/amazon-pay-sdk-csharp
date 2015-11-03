using log4net;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.Responses
{
    public class BillingAgreementDetailsResponse
    {
        /// <summary>
        /// Documentation Source https://payments.amazon.com/documentation/apireference/201752500
        /// </summary>

        public string xml;
        public string json;
        public IDictionary dictionary;

        // Billing Agreement general details
        public string amazonBillingAgreementId;
        public string billingAgreementState;
        public string releaseEnvironment;
        public List<string> constraintId = new List<string>();
        public List<string> description = new List<string>();
        public bool hasConstraint = false;
        public int reasonCode;
        public string reasonDescription;
        public string requestId;

        // Billing Agreement Limits
        public decimal amountLimitPerTimePeriod;
        public string amountLimitPerTimePeriodCurrencyCode;
        public decimal currentRemainingBalanceAmount;
        public string currentRemainingBalanceCurrencyCode;

        // Billing Agreement Seller details
        public string sellerNote;
        public string storeName;
        public string sellerOrderId;
        public string platformId;
        public string sellerBillingAgreementId;

        // Billing Agreement Validity details
        public DateTime timePeriodStartDate;
        public DateTime timePeriodEndDate;
        public DateTime lastUpdatedTimestamp;

        // Buyer Login Details
        public string phone;
        public string name;
        public string email;

        // Buyer Address Details
        public string addressLine1;
        public string addressLine2;
        public string addressLine3;
        public string countryCode;
        public string stateOrRegion;
        public string city;
        public string postalCode;
        public string county;
        public string district;
        public string destinationType;

        public string errorCode;
        public string errorMessage;

        public bool success = false;
        private string parentKey;

        BillingAddressDetails billingAddress;
        private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BillingAgreementDetailsResponse(string xml)
        {
            log4net.Config.XmlConfigurator.Configure();
            this.xml = xml;
            ResponseParser.SetXml(xml);
            this.json = ResponseParser.ToJson();
            this.dictionary = ResponseParser.ToDict();

            ErrorResponse errorResponse = new ErrorResponse(this.dictionary);
            if (errorResponse.IsSetErrorCode() && errorResponse.IsSetErrorMessage())
            {
                success = false;
                log.Debug("METHOD__BillingAgreementDetailsResponse Constructor | MESSAGE__success:" + this.success);
                this.errorCode = errorResponse.GetErrorCode();
                log.Debug("METHOD__BillingAgreementDetailsResponse Constructor | MESSAGE__errorCode:" + this.errorCode);
                this.errorMessage = errorResponse.GetErrorMessage();
                log.Debug("METHOD__BillingAgreementDetailsResponse Constructor | MESSAGE__errorMessage:" + this.errorMessage);
                this.requestId = errorResponse.GetRequestId();
                log.Debug("METHOD__BillingAgreementDetailsResponse Constructor | MESSAGE__RequestId:" + this.requestId);
            }
            else
            {
                success = true;
                log.Debug("METHOD__BillingAgreementDetailsResponse Constructor | MESSAGE__success:" + this.success);
                ParseDictionaryToVariables(this.dictionary);
            }
        }

        private enum Operator
        {
            AmazonBillingAgreementId, TimePeriodStartDate, TimePeriodEndDate, RequestId, LastUpdatedTimestamp, ReasonCode, ReasonDescription, State, AmountLimitPerTimePeriod,
            CurrentRemainingBalance, SellerNote, Amount, CurrencyCode, PlatformId, PostalCode, Name, Type, Id, Email, Phone, CountryCode, StateOrRegion, AddressLine1, AddressLine2,
            AddressLine3, City, County, District, DestinationType, ReleaseEnvironment, SellerOrderId, SellerBillingAgreementId, CustomInformation,
            StoreName, Constraint, ConstraintID, Description, member, BillingAddress
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
                                case Operator.AmazonBillingAgreementId:
                                    amazonBillingAgreementId = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__AmazonBillingAgreementId:" + this.amazonBillingAgreementId);
                                    break;
                                case Operator.RequestId:
                                    requestId = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__RequestId:" + this.requestId);
                                    break;
                                case Operator.TimePeriodStartDate:
                                    timePeriodStartDate = DateTime.Parse(obj.ToString());
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__TimePeriodStartDate:" + this.timePeriodStartDate);
                                    break;
                                case Operator.TimePeriodEndDate:
                                    timePeriodEndDate = DateTime.Parse(obj.ToString());
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__TimePeriodEndDate:" + this.timePeriodEndDate);
                                    break;
                                case Operator.LastUpdatedTimestamp:
                                    lastUpdatedTimestamp = DateTime.Parse(obj.ToString());
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__LastUpdatedTimestamp:" + this.lastUpdatedTimestamp);
                                    break;
                                case Operator.ReasonCode:
                                    reasonCode = Int32.Parse(obj.ToString());
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__ReasonCode:" + this.reasonCode);
                                    break;
                                case Operator.ReasonDescription:
                                    reasonDescription = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__ReasonDescription:" + this.reasonDescription);
                                    break;
                                case Operator.State:
                                    billingAgreementState = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__BillingAgreementState:" + this.billingAgreementState);
                                    break;
                                case Operator.SellerNote:
                                    sellerNote = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__SellerNote:" + this.sellerNote);
                                    break;
                                case Operator.Amount:
                                    if (parentKey.Equals(Operator.AmountLimitPerTimePeriod.ToString()))
                                    {
                                        amountLimitPerTimePeriod = decimal.Parse(obj.ToString());
                                        log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__AmountLimitPerTimePeriod:" + this.amountLimitPerTimePeriod);
                                    }
                                    else if (parentKey.Equals(Operator.CurrentRemainingBalance.ToString()))
                                    {
                                        currentRemainingBalanceAmount = decimal.Parse(obj.ToString());
                                        log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__CurrentRemainingBalance:" + this.currentRemainingBalanceAmount);
                                    }
                                    break;
                                case Operator.CurrencyCode:
                                    if (parentKey.Equals(Operator.AmountLimitPerTimePeriod.ToString()))
                                    {
                                        amountLimitPerTimePeriodCurrencyCode = obj.ToString();
                                        log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__AmountLimitPerTimePeriodCurrencyCode:" + this.amountLimitPerTimePeriodCurrencyCode);
                                    }
                                    else if (parentKey.Equals(Operator.CurrentRemainingBalance.ToString()))
                                    {
                                        currentRemainingBalanceCurrencyCode = obj.ToString();
                                        log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__CurrentRemainingBalanceCurrencyCode:" + this.currentRemainingBalanceCurrencyCode);
                                    }
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
                                case Operator.SellerBillingAgreementId:
                                    sellerBillingAgreementId = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__SellerBillingAgreementId:" + this.sellerBillingAgreementId);
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
                                                constraintId.Add(value);
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
                                    constraintId.Add(obj.ToString());
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__ConstraintID:" + obj.ToString());
                                    hasConstraint = true;
                                    break;
                                case Operator.Description:
                                    description.Add(obj.ToString());
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__Description:" + obj.ToString());
                                    hasConstraint = true;
                                    break;
                            }
                        }
                    }
                }
            }
        }

        public string GetAmazonBillingAgreementId()
        {
            return this.amazonBillingAgreementId;
        }
        public string GetRequestId()
        {
            return this.requestId;
        }
        public DateTime GetLastUpdatedTimestamp()
        {
            return this.lastUpdatedTimestamp;
        }
        public DateTime GetTimePeriodStartDate()
        {
            return this.timePeriodStartDate;
        }
        public DateTime GetTimePeriodEndDate()
        {
            return this.timePeriodEndDate;
        }
        public string GetSellerBillingAgreementId()
        {
            return this.sellerBillingAgreementId;
        }
        public int GetReasonCode()
        {
            return this.reasonCode;
        }
        public string GetReasonDescription()
        {
            return this.reasonDescription;
        }
        public string GetBillingAgreementState()
        {
            return this.billingAgreementState;
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
        public decimal GetAmountLimitPerTimePeriod()
        {
            return this.amountLimitPerTimePeriod;
        }
        public string GetAmountLimitPerTimePeriodCurrencyCode()
        {
            return this.amountLimitPerTimePeriodCurrencyCode;
        }
        public decimal GetCurrentRemainingBalanceAmount()
        {
            return this.currentRemainingBalanceAmount;
        }
        public string GetCurrentRemainingBalanceCurrencyCode()
        {
            return this.currentRemainingBalanceCurrencyCode;
        }
        public string GetCity()
        {
            return this.city;
        }
        public IList<string> GetConstraintIdList()
        {
            return this.constraintId.AsReadOnly();
        }
        public IList<string> GetDescriptionList()
        {
            return this.description.AsReadOnly();
        }
        public string GetCountryCode()
        {
            return this.countryCode;
        }
        public string GetCounty()
        {
            return this.county;
        }
        public string GetDestinationType()
        {
            return this.destinationType;
        }
        public IDictionary GetDictionary()
        {
            return this.dictionary;
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
        public bool GetSuccess()
        {
            return success;
        }
        public bool GetHasConstraint()
        {
            return this.hasConstraint;
        }
        public string GetJson()
        {
            return this.json;
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
        public string GetXml()
        {
            return this.xml;
        }
    }
}
