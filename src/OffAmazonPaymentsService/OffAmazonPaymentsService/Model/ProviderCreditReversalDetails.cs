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
    public class ProviderCreditReversalDetails
    {

        private String amazonProviderCreditReversalIdField;

        private String sellerIdField;

        private String providerIdField;

        private String creditReversalReferenceIdField;

        private Price creditReversalAmountField;
        private DateTime? creationTimestampField;

        private Status creditReversalStatusField;
        private String creditReversalNoteField;


        /// <summary>
        /// Gets and sets the AmazonProviderCreditReversalId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AmazonProviderCreditReversalId")]
        public String AmazonProviderCreditReversalId
        {
            get { return this.amazonProviderCreditReversalIdField; }
            set { this.amazonProviderCreditReversalIdField = value; }
        }



        /// <summary>
        /// Sets the AmazonProviderCreditReversalId property
        /// </summary>
        /// <param name="amazonProviderCreditReversalId">AmazonProviderCreditReversalId property</param>
        /// <returns>this instance</returns>
        public ProviderCreditReversalDetails WithAmazonProviderCreditReversalId(String amazonProviderCreditReversalId)
        {
            this.amazonProviderCreditReversalIdField = amazonProviderCreditReversalId;
            return this;
        }



        /// <summary>
        /// Checks if AmazonProviderCreditReversalId property is set
        /// </summary>
        /// <returns>true if AmazonProviderCreditReversalId property is set</returns>
        public Boolean IsSetAmazonProviderCreditReversalId()
        {
            return this.amazonProviderCreditReversalIdField != null;

        }





        /// <summary>
        /// Gets and sets the SellerId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "SellerId")]
        public String SellerId
        {
            get { return this.sellerIdField; }
            set { this.sellerIdField = value; }
        }



        /// <summary>
        /// Sets the SellerId property
        /// </summary>
        /// <param name="sellerId">SellerId property</param>
        /// <returns>this instance</returns>
        public ProviderCreditReversalDetails WithSellerId(String sellerId)
        {
            this.sellerIdField = sellerId;
            return this;
        }



        /// <summary>
        /// Checks if SellerId property is set
        /// </summary>
        /// <returns>true if SellerId property is set</returns>
        public Boolean IsSetSellerId()
        {
            return this.sellerIdField != null;

        }





        /// <summary>
        /// Gets and sets the ProviderId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ProviderId")]
        public String ProviderId
        {
            get { return this.providerIdField; }
            set { this.providerIdField = value; }
        }



        /// <summary>
        /// Sets the ProviderId property
        /// </summary>
        /// <param name="providerId">ProviderId property</param>
        /// <returns>this instance</returns>
        public ProviderCreditReversalDetails WithProviderId(String providerId)
        {
            this.providerIdField = providerId;
            return this;
        }



        /// <summary>
        /// Checks if ProviderId property is set
        /// </summary>
        /// <returns>true if ProviderId property is set</returns>
        public Boolean IsSetProviderId()
        {
            return this.providerIdField != null;

        }





        /// <summary>
        /// Gets and sets the CreditReversalReferenceId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "CreditReversalReferenceId")]
        public String CreditReversalReferenceId
        {
            get { return this.creditReversalReferenceIdField; }
            set { this.creditReversalReferenceIdField = value; }
        }



        /// <summary>
        /// Sets the CreditReversalReferenceId property
        /// </summary>
        /// <param name="creditReversalReferenceId">CreditReversalReferenceId property</param>
        /// <returns>this instance</returns>
        public ProviderCreditReversalDetails WithCreditReversalReferenceId(String creditReversalReferenceId)
        {
            this.creditReversalReferenceIdField = creditReversalReferenceId;
            return this;
        }



        /// <summary>
        /// Checks if CreditReversalReferenceId property is set
        /// </summary>
        /// <returns>true if CreditReversalReferenceId property is set</returns>
        public Boolean IsSetCreditReversalReferenceId()
        {
            return this.creditReversalReferenceIdField != null;

        }





        /// <summary>
        /// Gets and sets the CreditReversalAmount property.
        /// </summary>
        [XmlElementAttribute(ElementName = "CreditReversalAmount")]
        public Price CreditReversalAmount
        {
            get { return this.creditReversalAmountField; }
            set { this.creditReversalAmountField = value; }
        }



        /// <summary>
        /// Sets the CreditReversalAmount property
        /// </summary>
        /// <param name="creditReversalAmount">CreditReversalAmount property</param>
        /// <returns>this instance</returns>
        public ProviderCreditReversalDetails WithCreditReversalAmount(Price creditReversalAmount)
        {
            this.creditReversalAmountField = creditReversalAmount;
            return this;
        }



        /// <summary>
        /// Checks if CreditReversalAmount property is set
        /// </summary>
        /// <returns>true if CreditReversalAmount property is set</returns>
        public Boolean IsSetCreditReversalAmount()
        {
            return this.creditReversalAmountField != null;
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
        public ProviderCreditReversalDetails WithCreationTimestamp(DateTime creationTimestamp)
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
        /// Gets and sets the CreditReversalStatus property.
        /// </summary>
        [XmlElementAttribute(ElementName = "CreditReversalStatus")]
        public Status CreditReversalStatus
        {
            get { return this.creditReversalStatusField; }
            set { this.creditReversalStatusField = value; }
        }



        /// <summary>
        /// Sets the CreditReversalStatus property
        /// </summary>
        /// <param name="creditReversalStatus">CreditReversalStatus property</param>
        /// <returns>this instance</returns>
        public ProviderCreditReversalDetails WithCreditReversalStatus(Status creditReversalStatus)
        {
            this.creditReversalStatusField = creditReversalStatus;
            return this;
        }



        /// <summary>
        /// Checks if CreditReversalStatus property is set
        /// </summary>
        /// <returns>true if CreditReversalStatus property is set</returns>
        public Boolean IsSetCreditReversalStatus()
        {
            return this.creditReversalStatusField != null;
        }



        /// <summary>
        /// Gets and sets the CreditReversalNote property.
        /// </summary>
        [XmlElementAttribute(ElementName = "CreditReversalNote")]
        public String CreditReversalNote
        {
            get { return this.creditReversalNoteField; }
            set { this.creditReversalNoteField = value; }
        }



        /// <summary>
        /// Sets the CreditReversalNote property
        /// </summary>
        /// <param name="creditReversalNote">CreditReversalNote property</param>
        /// <returns>this instance</returns>
        public ProviderCreditReversalDetails WithCreditReversalNote(String creditReversalNote)
        {
            this.creditReversalNoteField = creditReversalNote;
            return this;
        }



        /// <summary>
        /// Checks if CreditReversalNote property is set
        /// </summary>
        /// <returns>true if CreditReversalNote property is set</returns>
        public Boolean IsSetCreditReversalNote()
        {
            return this.creditReversalNoteField != null;

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
            if (IsSetAmazonProviderCreditReversalId())
            {
                xml.Append("<AmazonProviderCreditReversalId>");
                xml.Append(this.AmazonProviderCreditReversalId);
                xml.Append("</AmazonProviderCreditReversalId>");
            }
            if (IsSetSellerId())
            {
                xml.Append("<SellerId>");
                xml.Append(this.SellerId);
                xml.Append("</SellerId>");
            }
            if (IsSetProviderId())
            {
                xml.Append("<ProviderId>");
                xml.Append(this.ProviderId);
                xml.Append("</ProviderId>");
            }
            if (IsSetCreditReversalReferenceId())
            {
                xml.Append("<CreditReversalReferenceId>");
                xml.Append(this.CreditReversalReferenceId);
                xml.Append("</CreditReversalReferenceId>");
            }
            if (IsSetCreditReversalAmount())
            {
                Price creditReversalAmountObj = this.CreditReversalAmount;
                xml.Append("<CreditReversalAmount>");
                xml.Append(creditReversalAmountObj.ToXMLFragment());
                xml.Append("</CreditReversalAmount>");
            }
            if (IsSetCreationTimestamp())
            {
                xml.Append("<CreationTimestamp>");
                xml.Append(this.CreationTimestamp);
                xml.Append("</CreationTimestamp>");
            }
            if (IsSetCreditReversalStatus())
            {
                Status creditReversalStatusObj = this.CreditReversalStatus;
                xml.Append("<CreditReversalStatus>");
                xml.Append(creditReversalStatusObj.ToXMLFragment());
                xml.Append("</CreditReversalStatus>");
            }
            if (IsSetCreditReversalNote())
            {
                xml.Append("<CreditReversalNote>");
                xml.Append(EscapeXML(this.CreditReversalNote));
                xml.Append("</CreditReversalNote>");
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