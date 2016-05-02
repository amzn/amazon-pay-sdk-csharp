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
    public class BillingAgreementDetails
    {

        private String amazonBillingAgreementIdField;
        private String orderLanguage;
        private BillingAgreementLimits billingAgreementLimitsField;
        private Buyer buyerField;
        private String sellerNoteField;

        private String platformIdField;

        private Destination destinationField;
        private BillingAddress  billingAddressField;
        private ReleaseEnvironment? releaseEnvironmentField;

        private SellerBillingAgreementAttributes sellerBillingAgreementAttributesField;
        private BillingAgreementStatus billingAgreementStatusField;
        private Constraints constraintsField;
        private DateTime? creationTimestampField;

        private DateTime? expirationTimestampField;

        private Boolean? billingAgreementConsentField;


        /// <summary>
        /// Gets and sets the AmazonBillingAgreementId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AmazonBillingAgreementId")]
        public String AmazonBillingAgreementId
        {
            get { return this.amazonBillingAgreementIdField; }
            set { this.amazonBillingAgreementIdField = value; }
        }



        /// <summary>
        /// Sets the AmazonBillingAgreementId property
        /// </summary>
        /// <param name="amazonBillingAgreementId">AmazonBillingAgreementId property</param>
        /// <returns>this instance</returns>
        public BillingAgreementDetails WithAmazonBillingAgreementId(String amazonBillingAgreementId)
        {
            this.amazonBillingAgreementIdField = amazonBillingAgreementId;
            return this;
        }



        /// <summary>
        /// Checks if AmazonBillingAgreementId property is set
        /// </summary>
        /// <returns>true if AmazonBillingAgreementId property is set</returns>
        public Boolean IsSetAmazonBillingAgreementId()
        {
            return this.amazonBillingAgreementIdField != null;

        }


        /// <summary>
        /// Gets and sets the OrderLanguage property.
        /// </summary>
        [XmlElementAttribute(ElementName = "OrderLanguage")]
        public String OrderLanguage
        {
            get { return this.orderLanguage; }
            set { this.orderLanguage = value; }
        }



        /// <summary>
        /// Sets the OrderLanguage property
        /// </summary>
        /// <param name="OrderLanguage">OrderLanguage property</param>
        /// <returns>this instance</returns>
        public BillingAgreementDetails WithOrderLanguage(String orderLanguage)
        {
            this.orderLanguage = orderLanguage;
            return this;
        }



        /// <summary>
        /// Checks if OrderLanguage property is set
        /// </summary>
        /// <returns>true if OrderLanguage property is set</returns>
        public Boolean IsSetOrderLanguage()
        {
            return this.orderLanguage != null;
        }


        /// <summary>
        /// Gets and sets the BillingAgreementLimits property.
        /// </summary>
        [XmlElementAttribute(ElementName = "BillingAgreementLimits")]
        public BillingAgreementLimits BillingAgreementLimits
        {
            get { return this.billingAgreementLimitsField; }
            set { this.billingAgreementLimitsField = value; }
        }



        /// <summary>
        /// Sets the BillingAgreementLimits property
        /// </summary>
        /// <param name="billingAgreementLimits">BillingAgreementLimits property</param>
        /// <returns>this instance</returns>
        public BillingAgreementDetails WithBillingAgreementLimits(BillingAgreementLimits billingAgreementLimits)
        {
            this.billingAgreementLimitsField = billingAgreementLimits;
            return this;
        }



        /// <summary>
        /// Checks if BillingAgreementLimits property is set
        /// </summary>
        /// <returns>true if BillingAgreementLimits property is set</returns>
        public Boolean IsSetBillingAgreementLimits()
        {
            return this.billingAgreementLimitsField != null;
        }



        /// <summary>
        /// Gets and sets the Buyer property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Buyer")]
        public Buyer Buyer
        {
            get { return this.buyerField; }
            set { this.buyerField = value; }
        }



        /// <summary>
        /// Sets the Buyer property
        /// </summary>
        /// <param name="buyer">Buyer property</param>
        /// <returns>this instance</returns>
        public BillingAgreementDetails WithBuyer(Buyer buyer)
        {
            this.buyerField = buyer;
            return this;
        }



        /// <summary>
        /// Checks if Buyer property is set
        /// </summary>
        /// <returns>true if Buyer property is set</returns>
        public Boolean IsSetBuyer()
        {
            return this.buyerField != null;
        }



        /// <summary>
        /// Gets and sets the SellerNote property.
        /// </summary>
        [XmlElementAttribute(ElementName = "SellerNote")]
        public String SellerNote
        {
            get { return this.sellerNoteField; }
            set { this.sellerNoteField = value; }
        }



        /// <summary>
        /// Sets the SellerNote property
        /// </summary>
        /// <param name="sellerNote">SellerNote property</param>
        /// <returns>this instance</returns>
        public BillingAgreementDetails WithSellerNote(String sellerNote)
        {
            this.sellerNoteField = sellerNote;
            return this;
        }



        /// <summary>
        /// Checks if SellerNote property is set
        /// </summary>
        /// <returns>true if SellerNote property is set</returns>
        public Boolean IsSetSellerNote()
        {
            return this.sellerNoteField != null;

        }





        /// <summary>
        /// Gets and sets the PlatformId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "PlatformId")]
        public String PlatformId
        {
            get { return this.platformIdField; }
            set { this.platformIdField = value; }
        }



        /// <summary>
        /// Sets the PlatformId property
        /// </summary>
        /// <param name="platformId">PlatformId property</param>
        /// <returns>this instance</returns>
        public BillingAgreementDetails WithPlatformId(String platformId)
        {
            this.platformIdField = platformId;
            return this;
        }



        /// <summary>
        /// Checks if PlatformId property is set
        /// </summary>
        /// <returns>true if PlatformId property is set</returns>
        public Boolean IsSetPlatformId()
        {
            return this.platformIdField != null;

        }





        /// <summary>
        /// Gets and sets the Destination property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Destination")]
        public Destination Destination
        {
            get { return this.destinationField; }
            set { this.destinationField = value; }
        }



        /// <summary>
        /// Sets the Destination property
        /// </summary>
        /// <param name="destination">Destination property</param>
        /// <returns>this instance</returns>
        public BillingAgreementDetails WithDestination(Destination destination)
        {
            this.destinationField = destination;
            return this;
        }



        /// <summary>
        /// Checks if Destination property is set
        /// </summary>
        /// <returns>true if Destination property is set</returns>
        public Boolean IsSetDestination()
        {
            return this.destinationField != null;
        }



        /// <summary>
        /// Gets and sets the Billing Address property.
        /// </summary>
        [XmlElementAttribute(ElementName = "BillingAddress")]
        public BillingAddress  BillingAddress
        {
            get { return this.billingAddressField ; }
            set { this.billingAddressField  = value; }
        }



        /// <summary>
        /// Sets the BillingAddress property
        /// </summary>
        /// <param name="destination">BillingAddress property</param>
        /// <returns>this instance</returns>
        public BillingAgreementDetails WithBillingAddress(BillingAddress  billingAddress)
        {
            this.billingAddressField  = billingAddress;
            return this;
        }



        /// <summary>
        /// Checks if Billing Address property is set
        /// </summary>
        /// <returns>true if Billing Address property is set</returns>
        public Boolean IsSetBillingAddress()
        {
            return this.billingAddressField  != null;
        }





        /// <summary>
        /// Gets and sets the ReleaseEnvironment property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ReleaseEnvironment")]
        public ReleaseEnvironment ReleaseEnvironment
        {
            get { return this.releaseEnvironmentField.GetValueOrDefault(); }
            set { this.releaseEnvironmentField = value; }
        }



        /// <summary>
        /// Sets the ReleaseEnvironment property
        /// </summary>
        /// <param name="releaseEnvironment">ReleaseEnvironment property</param>
        /// <returns>this instance</returns>
        public BillingAgreementDetails WithReleaseEnvironment(ReleaseEnvironment releaseEnvironment)
        {
            this.releaseEnvironmentField = releaseEnvironment;
            return this;
        }



        /// <summary>
        /// Checks if ReleaseEnvironment property is set
        /// </summary>
        /// <returns>true if ReleaseEnvironment property is set</returns>
        public Boolean IsSetReleaseEnvironment()
        {
            return this.releaseEnvironmentField.HasValue;

        }





        /// <summary>
        /// Gets and sets the SellerBillingAgreementAttributes property.
        /// </summary>
        [XmlElementAttribute(ElementName = "SellerBillingAgreementAttributes")]
        public SellerBillingAgreementAttributes SellerBillingAgreementAttributes
        {
            get { return this.sellerBillingAgreementAttributesField; }
            set { this.sellerBillingAgreementAttributesField = value; }
        }



        /// <summary>
        /// Sets the SellerBillingAgreementAttributes property
        /// </summary>
        /// <param name="sellerBillingAgreementAttributes">SellerBillingAgreementAttributes property</param>
        /// <returns>this instance</returns>
        public BillingAgreementDetails WithSellerBillingAgreementAttributes(SellerBillingAgreementAttributes sellerBillingAgreementAttributes)
        {
            this.sellerBillingAgreementAttributesField = sellerBillingAgreementAttributes;
            return this;
        }



        /// <summary>
        /// Checks if SellerBillingAgreementAttributes property is set
        /// </summary>
        /// <returns>true if SellerBillingAgreementAttributes property is set</returns>
        public Boolean IsSetSellerBillingAgreementAttributes()
        {
            return this.sellerBillingAgreementAttributesField != null;
        }



        /// <summary>
        /// Gets and sets the BillingAgreementStatus property.
        /// </summary>
        [XmlElementAttribute(ElementName = "BillingAgreementStatus")]
        public BillingAgreementStatus BillingAgreementStatus
        {
            get { return this.billingAgreementStatusField; }
            set { this.billingAgreementStatusField = value; }
        }



        /// <summary>
        /// Sets the BillingAgreementStatus property
        /// </summary>
        /// <param name="billingAgreementStatus">BillingAgreementStatus property</param>
        /// <returns>this instance</returns>
        public BillingAgreementDetails WithBillingAgreementStatus(BillingAgreementStatus billingAgreementStatus)
        {
            this.billingAgreementStatusField = billingAgreementStatus;
            return this;
        }



        /// <summary>
        /// Checks if BillingAgreementStatus property is set
        /// </summary>
        /// <returns>true if BillingAgreementStatus property is set</returns>
        public Boolean IsSetBillingAgreementStatus()
        {
            return this.billingAgreementStatusField != null;
        }



        /// <summary>
        /// Gets and sets the Constraints property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Constraints")]
        public Constraints Constraints
        {
            get { return this.constraintsField; }
            set { this.constraintsField = value; }
        }



        /// <summary>
        /// Sets the Constraints property
        /// </summary>
        /// <param name="constraints">Constraints property</param>
        /// <returns>this instance</returns>
        public BillingAgreementDetails WithConstraints(Constraints constraints)
        {
            this.constraintsField = constraints;
            return this;
        }



        /// <summary>
        /// Checks if Constraints property is set
        /// </summary>
        /// <returns>true if Constraints property is set</returns>
        public Boolean IsSetConstraints()
        {
            return this.constraintsField != null;
        }



        /// <summary>
        /// Gets and sets the CreationTimestamp property.
        /// </summary>
        [XmlElementAttribute(ElementName = "CreationTimestamp")]
        public DateTime CreationTimestamp
        {
            get { return this.creationTimestampField.GetValueOrDefault(); }
            set { this.creationTimestampField = value; }
        }



        /// <summary>
        /// Sets the CreationTimestamp property
        /// </summary>
        /// <param name="creationTimestamp">CreationTimestamp property</param>
        /// <returns>this instance</returns>
        public BillingAgreementDetails WithCreationTimestamp(DateTime creationTimestamp)
        {
            this.creationTimestampField = creationTimestamp;
            return this;
        }



        /// <summary>
        /// Checks if CreationTimestamp property is set
        /// </summary>
        /// <returns>true if CreationTimestamp property is set</returns>
        public Boolean IsSetCreationTimestamp()
        {
            return this.creationTimestampField.HasValue;

        }





        /// <summary>
        /// Gets and sets the ExpirationTimestamp property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ExpirationTimestamp")]
        public DateTime ExpirationTimestamp
        {
            get { return this.expirationTimestampField.GetValueOrDefault(); }
            set { this.expirationTimestampField = value; }
        }



        /// <summary>
        /// Sets the ExpirationTimestamp property
        /// </summary>
        /// <param name="expirationTimestamp">ExpirationTimestamp property</param>
        /// <returns>this instance</returns>
        public BillingAgreementDetails WithExpirationTimestamp(DateTime expirationTimestamp)
        {
            this.expirationTimestampField = expirationTimestamp;
            return this;
        }



        /// <summary>
        /// Checks if ExpirationTimestamp property is set
        /// </summary>
        /// <returns>true if ExpirationTimestamp property is set</returns>
        public Boolean IsSetExpirationTimestamp()
        {
            return this.expirationTimestampField.HasValue;

        }





        /// <summary>
        /// Gets and sets the BillingAgreementConsent property.
        /// </summary>
        [XmlElementAttribute(ElementName = "BillingAgreementConsent")]
        public Boolean BillingAgreementConsent
        {
            get { return this.billingAgreementConsentField.GetValueOrDefault(); }
            set { this.billingAgreementConsentField = value; }
        }



        /// <summary>
        /// Sets the BillingAgreementConsent property
        /// </summary>
        /// <param name="billingAgreementConsent">BillingAgreementConsent property</param>
        /// <returns>this instance</returns>
        public BillingAgreementDetails WithBillingAgreementConsent(Boolean billingAgreementConsent)
        {
            this.billingAgreementConsentField = billingAgreementConsent;
            return this;
        }



        /// <summary>
        /// Checks if BillingAgreementConsent property is set
        /// </summary>
        /// <returns>true if BillingAgreementConsent property is set</returns>
        public Boolean IsSetBillingAgreementConsent()
        {
            return this.billingAgreementConsentField.HasValue;

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
            if (IsSetAmazonBillingAgreementId())
            {
                xml.Append("<AmazonBillingAgreementId>");
                xml.Append(EscapeXML(this.AmazonBillingAgreementId));
                xml.Append("</AmazonBillingAgreementId>");
            }
            if (IsSetOrderLanguage())
            {
                xml.Append("<OrderLanguage>");
                xml.Append(EscapeXML(this.OrderLanguage));
                xml.Append("</OrderLanguage>");
            }
            if (IsSetBillingAgreementLimits())
            {
                BillingAgreementLimits billingAgreementLimitsObj = this.BillingAgreementLimits;
                xml.Append("<BillingAgreementLimits>");
                xml.Append(billingAgreementLimitsObj.ToXMLFragment());
                xml.Append("</BillingAgreementLimits>");
            }
            if (IsSetBuyer())
            {
                Buyer buyerObj = this.Buyer;
                xml.Append("<Buyer>");
                xml.Append(buyerObj.ToXMLFragment());
                xml.Append("</Buyer>");
            }
            if (IsSetSellerNote())
            {
                xml.Append("<SellerNote>");
                xml.Append(EscapeXML(this.SellerNote));
                xml.Append("</SellerNote>");
            }
            if (IsSetPlatformId())
            {
                xml.Append("<PlatformId>");
                xml.Append(EscapeXML(this.PlatformId));
                xml.Append("</PlatformId>");
            }
            if (IsSetDestination())
            {
                Destination destinationObj = this.Destination;
                xml.Append("<Destination>");
                xml.Append(destinationObj.ToXMLFragment());
                xml.Append("</Destination>");
            }
            if (IsSetReleaseEnvironment())
            {
                xml.Append("<ReleaseEnvironment>");
                xml.Append(this.ReleaseEnvironment);
                xml.Append("</ReleaseEnvironment>");
            }
            if (IsSetSellerBillingAgreementAttributes())
            {
                SellerBillingAgreementAttributes sellerBillingAgreementAttributesObj = this.SellerBillingAgreementAttributes;
                xml.Append("<SellerBillingAgreementAttributes>");
                xml.Append(sellerBillingAgreementAttributesObj.ToXMLFragment());
                xml.Append("</SellerBillingAgreementAttributes>");
            }
            if (IsSetBillingAgreementStatus())
            {
                BillingAgreementStatus billingAgreementStatusObj = this.BillingAgreementStatus;
                xml.Append("<BillingAgreementStatus>");
                xml.Append(billingAgreementStatusObj.ToXMLFragment());
                xml.Append("</BillingAgreementStatus>");
            }
            if (IsSetConstraints())
            {
                Constraints constraintsObj = this.Constraints;
                xml.Append("<Constraints>");
                xml.Append(constraintsObj.ToXMLFragment());
                xml.Append("</Constraints>");
            }
            if (IsSetCreationTimestamp())
            {
                xml.Append("<CreationTimestamp>");
                xml.Append(this.CreationTimestamp);
                xml.Append("</CreationTimestamp>");
            }
            if (IsSetExpirationTimestamp())
            {
                xml.Append("<ExpirationTimestamp>");
                xml.Append(this.ExpirationTimestamp);
                xml.Append("</ExpirationTimestamp>");
            }
            if (IsSetBillingAgreementConsent())
            {
                xml.Append("<BillingAgreementConsent>");
                xml.Append(this.BillingAgreementConsent);
                xml.Append("</BillingAgreementConsent>");
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