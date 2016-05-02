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
    public class SellerBillingAgreementAttributes
    {

        private String sellerBillingAgreementIdField;

        private String storeNameField;

        private String customInformationField;


        /// <summary>
        /// Gets and sets the SellerBillingAgreementId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "SellerBillingAgreementId")]
        public String SellerBillingAgreementId
        {
            get { return this.sellerBillingAgreementIdField; }
            set { this.sellerBillingAgreementIdField = value; }
        }



        /// <summary>
        /// Sets the SellerBillingAgreementId property
        /// </summary>
        /// <param name="sellerBillingAgreementId">SellerBillingAgreementId property</param>
        /// <returns>this instance</returns>
        public SellerBillingAgreementAttributes WithSellerBillingAgreementId(String sellerBillingAgreementId)
        {
            this.sellerBillingAgreementIdField = sellerBillingAgreementId;
            return this;
        }



        /// <summary>
        /// Checks if SellerBillingAgreementId property is set
        /// </summary>
        /// <returns>true if SellerBillingAgreementId property is set</returns>
        public Boolean IsSetSellerBillingAgreementId()
        {
            return this.sellerBillingAgreementIdField != null;

        }





        /// <summary>
        /// Gets and sets the StoreName property.
        /// </summary>
        [XmlElementAttribute(ElementName = "StoreName")]
        public String StoreName
        {
            get { return this.storeNameField; }
            set { this.storeNameField = value; }
        }



        /// <summary>
        /// Sets the StoreName property
        /// </summary>
        /// <param name="storeName">StoreName property</param>
        /// <returns>this instance</returns>
        public SellerBillingAgreementAttributes WithStoreName(String storeName)
        {
            this.storeNameField = storeName;
            return this;
        }



        /// <summary>
        /// Checks if StoreName property is set
        /// </summary>
        /// <returns>true if StoreName property is set</returns>
        public Boolean IsSetStoreName()
        {
            return this.storeNameField != null;

        }





        /// <summary>
        /// Gets and sets the CustomInformation property.
        /// </summary>
        [XmlElementAttribute(ElementName = "CustomInformation")]
        public String CustomInformation
        {
            get { return this.customInformationField; }
            set { this.customInformationField = value; }
        }



        /// <summary>
        /// Sets the CustomInformation property
        /// </summary>
        /// <param name="customInformation">CustomInformation property</param>
        /// <returns>this instance</returns>
        public SellerBillingAgreementAttributes WithCustomInformation(String customInformation)
        {
            this.customInformationField = customInformation;
            return this;
        }



        /// <summary>
        /// Checks if CustomInformation property is set
        /// </summary>
        /// <returns>true if CustomInformation property is set</returns>
        public Boolean IsSetCustomInformation()
        {
            return this.customInformationField != null;

        }







        /// <summary>
        /// XML fragment representation of this object
        /// </summary>
        /// <returns>XML fragment for this object.</returns>
        /// <remarks>
        /// Name for outer tag expected to be set by calling method. 
        /// This fragment returns inner properties representation only
        /// </remarks>


        protected internal String ToXMLFragment()
        {
            StringBuilder xml = new StringBuilder();
            if (IsSetSellerBillingAgreementId())
            {
                xml.Append("<SellerBillingAgreementId>");
                xml.Append(EscapeXML(this.SellerBillingAgreementId));
                xml.Append("</SellerBillingAgreementId>");
            }
            if (IsSetStoreName())
            {
                xml.Append("<StoreName>");
                xml.Append(EscapeXML(this.StoreName));
                xml.Append("</StoreName>");
            }
            if (IsSetCustomInformation())
            {
                xml.Append("<CustomInformation>");
                xml.Append(EscapeXML(this.CustomInformation));
                xml.Append("</CustomInformation>");
            }
            return xml.ToString();
        }

        /**
         * 
         * Escape XML special characters
         */
        private String EscapeXML(String str)
        {
            if (str == null)
                return "null";
            StringBuilder sb = new StringBuilder();
            foreach (Char c in str)
            {
                switch (c)
                {
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