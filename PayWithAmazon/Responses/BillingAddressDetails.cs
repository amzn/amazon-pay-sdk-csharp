using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.Responses
{
    public class BillingAddressDetails
    {
        private string phone;
        private string name;

        private string stateOrRegion;
        private string addressLine1;
        private string addressLine2;
        private string addressLine3;
        private string city;
        private string postalCode;
        private string countryCode;
        private string district;
        private string county;
        private string addressType;

        private static ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BillingAddressDetails(IDictionary dictionary)
        {
            log4net.Config.XmlConfigurator.Configure();
            ParseDictionaryToVariables(dictionary);
        }

        private enum Operator
        {
            PostalCode, Name, Phone, CountryCode, StateOrRegion, AddressLine1, AddressLine2, AddressLine3,
            City, County, District, AddressType
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
                        ParseDictionaryToVariables((IDictionary)obj);
                    }
                    else
                    {
                        if (Enum.IsDefined(typeof(Operator), strKey))
                        {
                            switch ((Operator)Enum.Parse(typeof(Operator), strKey))
                            {
                                case Operator.PostalCode:
                                    postalCode = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__PostalCode:" + this.postalCode);
                                    break;
                                case Operator.Name:
                                    name = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__Name:" + this.name);
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
                                case Operator.AddressType:
                                    addressType = obj.ToString();
                                    log.Debug("METHOD__ParseDictionaryToVariables | MESSAGE__AddressType:" + this.addressType);
                                    break;
                            }
                        }
                    }
                }
            }
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
        public string GetCity()
        {
            return this.city;
        }
        public string GetCountryCode()
        {
            return this.countryCode;
        }
        public string GetCounty()
        {
            return this.county;
        }
        public string GetAddressType()
        {
            return this.addressType;
        }
        public string GetDistrict()
        {
            return this.district;
        }
        public string GetName()
        {
            return this.name;
        }
        public string GetPhone()
        {
            return this.phone;
        }
        public string GetPostalCode()
        {
            return this.postalCode;
        }
        public string GetStateOrRegion()
        {
            return this.stateOrRegion;
        }
    }
}
