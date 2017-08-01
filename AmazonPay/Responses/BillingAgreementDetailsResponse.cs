using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;

namespace AmazonPay.Responses
{
    public class BillingAgreementDetailsResponse : IResponse
    {
        /// <summary>
        /// Documentation Source https://pay.amazon.com/documentation/apireference/201752500
        /// </summary>

        private string xml;
        private string json;
        private IDictionary dictionary;

        // Billing Agreement general details
        private string amazonBillingAgreementId;
        private string billingAgreementState;
        private string releaseEnvironment;
        private List<string> constraintId = new List<string>();
        private List<string> description = new List<string>();
        private bool hasConstraint = false;
        private string reasonCode;
        private string reasonDescription;
        private string requestId;
        private DateTime creationTimestamp;

        // Billing Agreement Limits
        private decimal amountLimitPerTimePeriod;
        private string amountLimitPerTimePeriodCurrencyCode;
        private decimal currentRemainingBalanceAmount;
        private string currentRemainingBalanceCurrencyCode;

        // Billing Agreement Seller details
        private string sellerNote;
        private string storeName;
        private string sellerOrderId;
        private string platformId;
        private string sellerBillingAgreementId;

        // Billing Agreement Validity details
        private DateTime timePeriodStartDate;
        private DateTime timePeriodEndDate;
        private DateTime lastUpdatedTimestamp;

        // Buyer Login Details
        private string phone;
        private string buyerName;
        private string email;

        // Buyer Address Details
        private string buyerShippingName;
        private string addressLine1;
        private string addressLine2;
        private string addressLine3;
        private string countryCode;
        private string stateOrRegion;
        private string city;
        private string postalCode;
        private string county;
        private string district;
        private string destinationType;

        private string errorCode;
        private string errorMessage;

        private bool success = false;
        private string parentKey;

        BillingAddressDetails billingAddress;


        public BillingAgreementDetailsResponse(string xml)
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
            AmazonBillingAgreementId, TimePeriodStartDate, TimePeriodEndDate, RequestId, CreationTimestamp, LastUpdatedTimestamp, ReasonCode, ReasonDescription, State, AmountLimitPerTimePeriod,
            CurrentRemainingBalance, SellerNote, Amount, CurrencyCode, PlatformId, PostalCode, Name, Type, Id, Email, Phone, CountryCode, StateOrRegion, AddressLine1, AddressLine2,
            AddressLine3, City, County, District, DestinationType, ReleaseEnvironment, SellerOrderId, SellerBillingAgreementId, CustomInformation,
            StoreName, Constraint, ConstraintID, Description, member, BillingAddress, Buyer
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
                                    break;
                                case Operator.RequestId:
                                    requestId = obj.ToString();
                                    break;
                                case Operator.CreationTimestamp:
                                    creationTimestamp = DateTime.Parse(obj.ToString());
                                    break;
                                case Operator.TimePeriodStartDate:
                                    timePeriodStartDate = DateTime.Parse(obj.ToString());
                                    break;
                                case Operator.TimePeriodEndDate:
                                    timePeriodEndDate = DateTime.Parse(obj.ToString());
                                    break;
                                case Operator.LastUpdatedTimestamp:
                                    lastUpdatedTimestamp = DateTime.Parse(obj.ToString());
                                    break;
                                case Operator.ReasonCode:
                                    reasonCode = obj.ToString();
                                    break;
                                case Operator.ReasonDescription:
                                    reasonDescription = obj.ToString();
                                    break;
                                case Operator.State:
                                    billingAgreementState = obj.ToString();
                                    break;
                                case Operator.SellerNote:
                                    sellerNote = obj.ToString();
                                    break;
                                case Operator.Amount:
                                    if (parentKey.Equals(Operator.AmountLimitPerTimePeriod.ToString()))
                                    {
                                        amountLimitPerTimePeriod = decimal.Parse(obj.ToString(), Constants.USNumberFormat);
                                    }
                                    else if (parentKey.Equals(Operator.CurrentRemainingBalance.ToString()))
                                    {
                                        currentRemainingBalanceAmount = decimal.Parse(obj.ToString(), Constants.USNumberFormat);
                                    }
                                    break;
                                case Operator.CurrencyCode:
                                    if (parentKey.Equals(Operator.AmountLimitPerTimePeriod.ToString()))
                                    {
                                        amountLimitPerTimePeriodCurrencyCode = obj.ToString();
                                    }
                                    else if (parentKey.Equals(Operator.CurrentRemainingBalance.ToString()))
                                    {
                                        currentRemainingBalanceCurrencyCode = obj.ToString();
                                    }
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
                                case Operator.SellerBillingAgreementId:
                                    sellerBillingAgreementId = obj.ToString();
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
                                                constraintId.Add(value);
                                            }
                                            if (key.Equals(Operator.Description.ToString()))
                                            {
                                                description.Add(value);
                                            }
                                        }
                                    }
                                    break;
                                case Operator.ConstraintID:
                                    constraintId.Add(obj.ToString());
                                    hasConstraint = true;
                                    break;
                                case Operator.Description:
                                    description.Add(obj.ToString());
                                    hasConstraint = true;
                                    break;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Get the Amazon Billing Agreement ID
        /// </summary>
        /// <returns>string amazonBillingAgreementId</returns>
        public string GetAmazonBillingAgreementId()
        {
            return this.amazonBillingAgreementId;
        }

        /// <summary>
        /// Get the requestId
        /// </summary>
        /// <returns>string requestId</returns>
        public string GetRequestId()
        {
            return this.requestId;
        }

        /// <summary>
        /// Get the creationTimestamp
        /// </summary>
        /// <returns>DateTime creationTimestamp</returns>
        public DateTime GetCreationTimestamp()
        {
            return this.creationTimestamp;
        }

        /// <summary>
        /// Get the last Updated Timestamp
        /// </summary>
        /// <returns>DateTime lastUpdatedTimestamp</returns>
        public DateTime GetLastUpdatedTimestamp()
        {
            return this.lastUpdatedTimestamp;
        }

        /// <summary>
        /// Get the Time Period Start Date
        /// </summary>
        /// <returns>DateTime timePeriodStartDate</returns>
        public DateTime GetTimePeriodStartDate()
        {
            return this.timePeriodStartDate;
        }

        /// <summary>
        /// Get the Time Period End Date
        /// </summary>
        /// <returns>DateTime timePeriodEndDate</returns>
        public DateTime GetTimePeriodEndDate()
        {
            return this.timePeriodEndDate;
        }

        /// <summary>
        /// Get the custom Seller Billing Agreement if set
        /// </summary>
        /// <returns>sellerBillingAgreementId</returns>
        public string GetSellerBillingAgreementId()
        {
            return this.sellerBillingAgreementId;
        }

        /// <summary>
        /// If the Billing Agreement is not in the Open state and if closed/canceled get the Reason Code 
        /// </summary>
        /// <returns>string reasonCode</returns>
        public string GetReasonCode()
        {
            return this.reasonCode;
        }

        /// <summary>
        /// If the Billing Agreement is not in the Open state and if closed/canceled get the Reason Description 
        /// </summary>
        /// <returns>string reasonDescription</returns>
        public string GetReasonDescription()
        {
            return this.reasonDescription;
        }

        /// <summary>
        /// Get the state of the Billing Agreement
        /// </summary>
        /// <returns>string billingAgreementState</returns>
        public string GetBillingAgreementState()
        {
            return this.billingAgreementState;
        }

        /// <summary>
        /// Get the shipping Address Line 1 of the Buyer
        /// </summary>
        /// <returns>string addressLine1</returns>
        public string GetAddressLine1()
        {
            return this.addressLine1;
        }

        /// <summary>
        /// Get the Shipping Name as provided by the Buyer from the Wallet Widget
        /// </summary>
        /// <returns>string buyerShippingName</returns>
        public string GetBuyerShippingName()
        {
            return this.buyerShippingName;
        }

        /// <summary>
        /// Get the shipping Address Line 2 of the Buyer
        /// </summary>
        /// <returns>string addressLine2</returns>
        public string GetAddressLine2()
        {
            return this.addressLine2;
        }

        /// <summary>
        /// Get the shipping Address Line 3 of the Buyer
        /// </summary>
        /// <returns>string addressLine3</returns>
        public string GetAddressLine3()
        {
            return this.addressLine3;
        }

        /// <summary>
        /// Get the Limit Amount Per Time Period for the Amazon Billing Agreement ID
        /// </summary>
        /// <returns>string amountLimitPerTimePeriod</returns>
        public decimal GetAmountLimitPerTimePeriod()
        {
            return this.amountLimitPerTimePeriod;
        }

        /// <summary>
        /// Get the Amount Limit Per Time Period Currency Code for the Amazon Billing Agreement ID
        /// </summary>
        /// <returns>string amountLimitPerTimePeriodCurrencyCode</returns>
        public string GetAmountLimitPerTimePeriodCurrencyCode()
        {
            return this.amountLimitPerTimePeriodCurrencyCode;
        }

        /// <summary>
        /// Get the Current Remaining Balance Amount for the Amazon Billing Agreement ID
        /// </summary>
        /// <returns>string currentRemainingBalanceAmount</returns>
        public decimal GetCurrentRemainingBalanceAmount()
        {
            return this.currentRemainingBalanceAmount;
        }

        /// <summary>
        /// Get the Current Remaining Balance Amount Currency Code for the Amazon Billing Agreement ID
        /// </summary>
        /// <returns>string currentRemainingBalanceAmount</returns>
        public string GetCurrentRemainingBalanceCurrencyCode()
        {
            return this.currentRemainingBalanceCurrencyCode;
        }

        /// <summary>
        /// Get the  shipping address city of the Buyer
        /// </summary>
        /// <returns>string city</returns>
        public string GetCity()
        {
            return this.city;
        }

        /// <summary>
        /// Get any List of constraints if exuists on the Amazon Billing Agreement ID
        /// </summary>
        /// <returns>IList constraintId</returns>
        public IList<string> GetConstraintIdList()
        {
            return this.constraintId.AsReadOnly();
        }

        /// <summary>
        /// Get List of respective Descriptions for the constraints returned on the Amazon Billing Agreement ID
        /// </summary>
        /// <returns>IList description</returns>
        public IList<string> GetDescriptionList()
        {
            return this.description.AsReadOnly();
        }

        /// <summary>
        /// Get the shipping address country Code of the Buyer
        /// </summary>
        /// <returns>string countryCode</returns>
        public string GetCountryCode()
        {
            return this.countryCode;
        }

        /// <summary>
        /// Get the shipping address county of the Buyer
        /// </summary>
        /// <returns>string county</returns>
        public string GetCounty()
        {
            return this.county;
        }

        /// <summary>
        /// Get the destinationType whether if it's a physical desitination or a Billing address
        /// </summary>
        /// <returns>string destinationType</returns>
        public string GetDestinationType()
        {
            return this.destinationType;
        }

        /// <summary>
        /// Response in Dictionary Format
        /// </summary>
        /// <returns>Dictionary<string,object> type Response</returns>
        public IDictionary GetDictionary()
        {
            return this.dictionary;
        }

        /// <summary>
        /// Get the shipping address district of the Buyer
        /// </summary>
        /// <returns>string district</returns>
        public string GetDistrict()
        {
            return this.district;
        }

        /// <summary>
        /// Get the Email of the Buyer
        /// </summary>
        /// <returns>string email</returns>
        public string GetEmail()
        {
            return this.email;
        }

        /// <summary>
        /// Get the ErrorCode when te API call failed
        /// </summary>
        /// <returns>string errorCode</returns>
        public string GetErrorCode()
        {
            return this.errorCode;
        }

        /// <summary>
        /// Get the ErrorMessage when the API call failed
        /// </summary>
        /// <returns>string errorCode</returns>
        public string GetErrorMessage()
        {
            return this.errorMessage;
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
        /// Get the boolean value to check if the Constaints exist
        /// </summary>
        /// <returns>true or false for hasConstraint</returns>
        public bool GetHasConstraint()
        {
            return this.hasConstraint;
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
        /// Get the Buyer name 
        /// </summary>
        /// <returns>string buyerName</returns>
        public string GetBuyerName()
        {
            return this.buyerName;
        }

        /// <summary>
        /// Get the Buyer phone number
        /// </summary>
        /// <returns>string phone</returns>
        public string GetPhone()
        {
            return this.phone;
        }

        /// <summary>
        /// Get the Platform ID
        /// </summary>
        /// <returns>string platformId</returns>
        public string GetPlatformId()
        {
            return this.platformId;
        }

        /// <summary>
        /// Get the Shipping address Postal code 
        /// </summary>
        /// <returns>string postalCode</returns>
        public string GetPostalCode()
        {
            return this.postalCode;
        }

        /// <summary>
        /// Get the Release environment , Sandbox or Live
        /// </summary>
        /// <returns>string releaseEnvironment</returns>
        public string GetReleaseEnvironment()
        {
            return this.releaseEnvironment;
        }

        /// <summary>
        /// Get the Seller Note
        /// </summary>
        /// <returns>string sellerNote</returns>
        public string GetSellerNote()
        {
            return this.sellerNote;
        }

        /// <summary>
        /// Get the custom Seller Order ID
        /// </summary>
        /// <returns>string sellerOrderId</returns>
        public string GetSellerOrderId()
        {
            return this.sellerOrderId;
        }

        /// <summary>
        /// Get the Shipping Address StateOrRegion
        /// </summary>
        /// <returns>string stateOrRegion</returns>
        public string GetStateOrRegion()
        {
            return this.stateOrRegion;
        }

        /// <summary>
        /// Get the Merchant Store Name
        /// </summary>
        /// <returns>string storeName</returns>
        public string GetStoreName()
        {
            return this.storeName;
        }

        /// <summary>
        /// Get the Billing Address class object. Applies to case where in the billing address is returned in the response
        /// </summary>
        /// <returns>BillingAddressDetails billingAddress</returns>
        public BillingAddressDetails GetBillingAddressDetails()
        {
            return this.billingAddress;
        }

        /// <summary>
        /// Response returned in XML format
        /// </summary>
        /// <returns>XML format Response</returns>
        public string GetXml()
        {
            return this.xml;
        }
    }
}
