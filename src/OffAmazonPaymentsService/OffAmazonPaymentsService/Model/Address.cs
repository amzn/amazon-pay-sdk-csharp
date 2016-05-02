/******************************************************************************* 
 *  Copyright 2008-2012 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  
 *  You may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 *  specific language governing permissions and limitations under the License.
 * ***************************************************************************** 
 * 
 *  Off Amazon Payments Service CSharp Library
 *  API Version: 2013-01-01
 * 
 */


using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;


namespace OffAmazonPaymentsService.Model
{
    [XmlTypeAttribute(Namespace = "http://mws.amazonservices.com/schema/OffAmazonPayments/2013-01-01")]
    [XmlRootAttribute(Namespace = "http://mws.amazonservices.com/schema/OffAmazonPayments/2013-01-01", IsNullable = false)]
    public class Address
    {
    
        private String nameField;

        private String addressLine1Field;

        private String addressLine2Field;

        private String addressLine3Field;

        private String cityField;

        private String countyField;

        private String districtField;

        private String stateOrRegionField;

        private String postalCodeField;

        private String countryCodeField;

        private String phoneField;


        /// <summary>
        /// Gets and sets the Name property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Name")]
        public String Name
        {
            get { return this.nameField ; }
            set { this.nameField= value; }
        }



        /// <summary>
        /// Sets the Name property
        /// </summary>
        /// <param name="name">Name property</param>
        /// <returns>this instance</returns>
        public Address WithName(String name)
        {
            this.nameField = name;
            return this;
        }



        /// <summary>
        /// Checks if Name property is set
        /// </summary>
        /// <returns>true if Name property is set</returns>
        public Boolean IsSetName()
        {
            return  this.nameField != null;

        }





        /// <summary>
        /// Gets and sets the AddressLine1 property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AddressLine1")]
        public String AddressLine1
        {
            get { return this.addressLine1Field ; }
            set { this.addressLine1Field= value; }
        }



        /// <summary>
        /// Sets the AddressLine1 property
        /// </summary>
        /// <param name="addressLine1">AddressLine1 property</param>
        /// <returns>this instance</returns>
        public Address WithAddressLine1(String addressLine1)
        {
            this.addressLine1Field = addressLine1;
            return this;
        }



        /// <summary>
        /// Checks if AddressLine1 property is set
        /// </summary>
        /// <returns>true if AddressLine1 property is set</returns>
        public Boolean IsSetAddressLine1()
        {
            return  this.addressLine1Field != null;

        }





        /// <summary>
        /// Gets and sets the AddressLine2 property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AddressLine2")]
        public String AddressLine2
        {
            get { return this.addressLine2Field ; }
            set { this.addressLine2Field= value; }
        }



        /// <summary>
        /// Sets the AddressLine2 property
        /// </summary>
        /// <param name="addressLine2">AddressLine2 property</param>
        /// <returns>this instance</returns>
        public Address WithAddressLine2(String addressLine2)
        {
            this.addressLine2Field = addressLine2;
            return this;
        }



        /// <summary>
        /// Checks if AddressLine2 property is set
        /// </summary>
        /// <returns>true if AddressLine2 property is set</returns>
        public Boolean IsSetAddressLine2()
        {
            return  this.addressLine2Field != null;

        }





        /// <summary>
        /// Gets and sets the AddressLine3 property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AddressLine3")]
        public String AddressLine3
        {
            get { return this.addressLine3Field ; }
            set { this.addressLine3Field= value; }
        }



        /// <summary>
        /// Sets the AddressLine3 property
        /// </summary>
        /// <param name="addressLine3">AddressLine3 property</param>
        /// <returns>this instance</returns>
        public Address WithAddressLine3(String addressLine3)
        {
            this.addressLine3Field = addressLine3;
            return this;
        }



        /// <summary>
        /// Checks if AddressLine3 property is set
        /// </summary>
        /// <returns>true if AddressLine3 property is set</returns>
        public Boolean IsSetAddressLine3()
        {
            return  this.addressLine3Field != null;

        }





        /// <summary>
        /// Gets and sets the City property.
        /// </summary>
        [XmlElementAttribute(ElementName = "City")]
        public String City
        {
            get { return this.cityField ; }
            set { this.cityField= value; }
        }



        /// <summary>
        /// Sets the City property
        /// </summary>
        /// <param name="city">City property</param>
        /// <returns>this instance</returns>
        public Address WithCity(String city)
        {
            this.cityField = city;
            return this;
        }



        /// <summary>
        /// Checks if City property is set
        /// </summary>
        /// <returns>true if City property is set</returns>
        public Boolean IsSetCity()
        {
            return  this.cityField != null;

        }





        /// <summary>
        /// Gets and sets the County property.
        /// </summary>
        [XmlElementAttribute(ElementName = "County")]
        public String County
        {
            get { return this.countyField ; }
            set { this.countyField= value; }
        }



        /// <summary>
        /// Sets the County property
        /// </summary>
        /// <param name="county">County property</param>
        /// <returns>this instance</returns>
        public Address WithCounty(String county)
        {
            this.countyField = county;
            return this;
        }



        /// <summary>
        /// Checks if County property is set
        /// </summary>
        /// <returns>true if County property is set</returns>
        public Boolean IsSetCounty()
        {
            return  this.countyField != null;

        }





        /// <summary>
        /// Gets and sets the District property.
        /// </summary>
        [XmlElementAttribute(ElementName = "District")]
        public String District
        {
            get { return this.districtField ; }
            set { this.districtField= value; }
        }



        /// <summary>
        /// Sets the District property
        /// </summary>
        /// <param name="district">District property</param>
        /// <returns>this instance</returns>
        public Address WithDistrict(String district)
        {
            this.districtField = district;
            return this;
        }



        /// <summary>
        /// Checks if District property is set
        /// </summary>
        /// <returns>true if District property is set</returns>
        public Boolean IsSetDistrict()
        {
            return  this.districtField != null;

        }





        /// <summary>
        /// Gets and sets the StateOrRegion property.
        /// </summary>
        [XmlElementAttribute(ElementName = "StateOrRegion")]
        public String StateOrRegion
        {
            get { return this.stateOrRegionField ; }
            set { this.stateOrRegionField= value; }
        }



        /// <summary>
        /// Sets the StateOrRegion property
        /// </summary>
        /// <param name="stateOrRegion">StateOrRegion property</param>
        /// <returns>this instance</returns>
        public Address WithStateOrRegion(String stateOrRegion)
        {
            this.stateOrRegionField = stateOrRegion;
            return this;
        }



        /// <summary>
        /// Checks if StateOrRegion property is set
        /// </summary>
        /// <returns>true if StateOrRegion property is set</returns>
        public Boolean IsSetStateOrRegion()
        {
            return  this.stateOrRegionField != null;

        }





        /// <summary>
        /// Gets and sets the PostalCode property.
        /// </summary>
        [XmlElementAttribute(ElementName = "PostalCode")]
        public String PostalCode
        {
            get { return this.postalCodeField ; }
            set { this.postalCodeField= value; }
        }



        /// <summary>
        /// Sets the PostalCode property
        /// </summary>
        /// <param name="postalCode">PostalCode property</param>
        /// <returns>this instance</returns>
        public Address WithPostalCode(String postalCode)
        {
            this.postalCodeField = postalCode;
            return this;
        }



        /// <summary>
        /// Checks if PostalCode property is set
        /// </summary>
        /// <returns>true if PostalCode property is set</returns>
        public Boolean IsSetPostalCode()
        {
            return  this.postalCodeField != null;

        }





        /// <summary>
        /// Gets and sets the CountryCode property.
        /// </summary>
        [XmlElementAttribute(ElementName = "CountryCode")]
        public String CountryCode
        {
            get { return this.countryCodeField ; }
            set { this.countryCodeField= value; }
        }



        /// <summary>
        /// Sets the CountryCode property
        /// </summary>
        /// <param name="countryCode">CountryCode property</param>
        /// <returns>this instance</returns>
        public Address WithCountryCode(String countryCode)
        {
            this.countryCodeField = countryCode;
            return this;
        }



        /// <summary>
        /// Checks if CountryCode property is set
        /// </summary>
        /// <returns>true if CountryCode property is set</returns>
        public Boolean IsSetCountryCode()
        {
            return  this.countryCodeField != null;

        }





        /// <summary>
        /// Gets and sets the Phone property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Phone")]
        public String Phone
        {
            get { return this.phoneField ; }
            set { this.phoneField= value; }
        }



        /// <summary>
        /// Sets the Phone property
        /// </summary>
        /// <param name="phone">Phone property</param>
        /// <returns>this instance</returns>
        public Address WithPhone(String phone)
        {
            this.phoneField = phone;
            return this;
        }



        /// <summary>
        /// Checks if Phone property is set
        /// </summary>
        /// <returns>true if Phone property is set</returns>
        public Boolean IsSetPhone()
        {
            return  this.phoneField != null;

        }







        /// <summary>
        /// XML fragment representation of this object
        /// </summary>
        /// <returns>XML fragment for this object.</returns>
        /// <remarks>
        /// Name for outer tag expected to be set by calling method. 
        /// This fragment returns inner properties representation only
        /// </remarks>


        protected internal String ToXMLFragment() {
            StringBuilder xml = new StringBuilder();
            if (IsSetName()) {
                xml.Append("<Name>");
                xml.Append(EscapeXML(this.Name));
                xml.Append("</Name>");
            }
            if (IsSetAddressLine1()) {
                xml.Append("<AddressLine1>");
                xml.Append(EscapeXML(this.AddressLine1));
                xml.Append("</AddressLine1>");
            }
            if (IsSetAddressLine2()) {
                xml.Append("<AddressLine2>");
                xml.Append(EscapeXML(this.AddressLine2));
                xml.Append("</AddressLine2>");
            }
            if (IsSetAddressLine3()) {
                xml.Append("<AddressLine3>");
                xml.Append(EscapeXML(this.AddressLine3));
                xml.Append("</AddressLine3>");
            }
            if (IsSetCity()) {
                xml.Append("<City>");
                xml.Append(EscapeXML(this.City));
                xml.Append("</City>");
            }
            if (IsSetCounty()) {
                xml.Append("<County>");
                xml.Append(EscapeXML(this.County));
                xml.Append("</County>");
            }
            if (IsSetDistrict()) {
                xml.Append("<District>");
                xml.Append(EscapeXML(this.District));
                xml.Append("</District>");
            }
            if (IsSetStateOrRegion()) {
                xml.Append("<StateOrRegion>");
                xml.Append(EscapeXML(this.StateOrRegion));
                xml.Append("</StateOrRegion>");
            }
            if (IsSetPostalCode()) {
                xml.Append("<PostalCode>");
                xml.Append(EscapeXML(this.PostalCode));
                xml.Append("</PostalCode>");
            }
            if (IsSetCountryCode()) {
                xml.Append("<CountryCode>");
                xml.Append(EscapeXML(this.CountryCode));
                xml.Append("</CountryCode>");
            }
            if (IsSetPhone()) {
                xml.Append("<Phone>");
                xml.Append(EscapeXML(this.Phone));
                xml.Append("</Phone>");
            }
            return xml.ToString();
        }

        /**
         * 
         * Escape XML special characters
         */
        private String EscapeXML(String str) {
            if (str == null)
                return "null";
            StringBuilder sb = new StringBuilder();
            foreach (Char c in str)
            {
                switch (c) {
                case '&':
                    sb.Append("&amp;");
                    break;
                case '<':
                    sb.Append("&lt;");
                    break;
                case '>':
                    sb.Append("&gt;");
                    break;
                case '\'':
                    sb.Append("&#039;");
                    break;
                case '"':
                    sb.Append("&quot;");
                    break;
                default:
                    sb.Append(c);
                    break;
                }
            }
            return sb.ToString();
        }



    }

}