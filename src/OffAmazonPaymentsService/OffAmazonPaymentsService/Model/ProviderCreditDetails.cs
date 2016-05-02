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
    public class ProviderCreditDetails
    {

        private String amazonProviderCreditIdField;

        private String sellerIdField;

        private String providerIdField;

        private String creditReferenceIdField;

        private Price creditAmountField;
        private Price creditReversalAmountField;
        private IdList creditReversalIdListField;
        private DateTime? creationTimestampField;

        private Status creditStatusField;

        /// <summary>
        /// Gets and sets the AmazonProviderCreditId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AmazonProviderCreditId")]
        public String AmazonProviderCreditId
        {
            get { return this.amazonProviderCreditIdField; }
            set { this.amazonProviderCreditIdField = value; }
        }



        /// <summary>
        /// Sets the AmazonProviderCreditId property
        /// </summary>
        /// <param name="amazonProviderCreditId">AmazonProviderCreditId property</param>
        /// <returns>this instance</returns>
        public ProviderCreditDetails WithAmazonProviderCreditId(String amazonProviderCreditId)
        {
            this.amazonProviderCreditIdField = amazonProviderCreditId;
            return this;
        }



        /// <summary>
        /// Checks if AmazonProviderCreditId property is set
        /// </summary>
        /// <returns>true if AmazonProviderCreditId property is set</returns>
        public Boolean IsSetAmazonProviderCreditId()
        {
            return this.amazonProviderCreditIdField != null;

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
        public ProviderCreditDetails WithSellerId(String sellerId)
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
        public ProviderCreditDetails WithProviderId(String providerId)
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
        /// Gets and sets the CreditReferenceId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "CreditReferenceId")]
        public String CreditReferenceId
        {
            get { return this.creditReferenceIdField; }
            set { this.creditReferenceIdField = value; }
        }



        /// <summary>
        /// Sets the CreditReferenceId property
        /// </summary>
        /// <param name="creditReferenceId">CreditReferenceId property</param>
        /// <returns>this instance</returns>
        public ProviderCreditDetails WithCreditReferenceId(String creditReferenceId)
        {
            this.creditReferenceIdField = creditReferenceId;
            return this;
        }



        /// <summary>
        /// Checks if CreditReferenceId property is set
        /// </summary>
        /// <returns>true if CreditReferenceId property is set</returns>
        public Boolean IsSetCreditReferenceId()
        {
            return this.creditReferenceIdField != null;

        }





        /// <summary>
        /// Gets and sets the CreditAmount property.
        /// </summary>
        [XmlElementAttribute(ElementName = "CreditAmount")]
        public Price CreditAmount
        {
            get { return this.creditAmountField; }
            set { this.creditAmountField = value; }
        }



        /// <summary>
        /// Sets the CreditAmount property
        /// </summary>
        /// <param name="creditAmount">CreditAmount property</param>
        /// <returns>this instance</returns>
        public ProviderCreditDetails WithCreditAmount(Price creditAmount)
        {
            this.creditAmountField = creditAmount;
            return this;
        }



        /// <summary>
        /// Checks if CreditAmount property is set
        /// </summary>
        /// <returns>true if CreditAmount property is set</returns>
        public Boolean IsSetCreditAmount()
        {
            return this.creditAmountField != null;
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
        public ProviderCreditDetails WithCreditReversalAmount(Price creditReversalAmount)
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
        /// Gets and sets the CreditReversalIdList property.
        /// </summary>
        [XmlElementAttribute(ElementName = "CreditReversalIdList")]
        public IdList CreditReversalIdList
        {
            get { return this.creditReversalIdListField; }
            set { this.creditReversalIdListField = value; }
        }



        /// <summary>
        /// Sets the CreditReversalIdList property
        /// </summary>
        /// <param name="creditReversalIdList">CreditReversalIdList property</param>
        /// <returns>this instance</returns>
        public ProviderCreditDetails WithCreditReversalIdList(IdList creditReversalIdList)
        {
            this.creditReversalIdListField = creditReversalIdList;
            return this;
        }



        /// <summary>
        /// Checks if CreditReversalIdList property is set
        /// </summary>
        /// <returns>true if CreditReversalIdList property is set</returns>
        public Boolean IsSetCreditReversalIdList()
        {
            return this.creditReversalIdListField != null;
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
        public ProviderCreditDetails WithCreationTimestamp(DateTime creationTimestamp)
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
        /// Gets and sets the CreditStatus property.
        /// </summary>
        [XmlElementAttribute(ElementName = "CreditStatus")]
        public Status CreditStatus
        {
            get { return this.creditStatusField; }
            set { this.creditStatusField = value; }
        }



        /// <summary>
        /// Sets the CreditStatus property
        /// </summary>
        /// <param name="creditStatus">CreditStatus property</param>
        /// <returns>this instance</returns>
        public ProviderCreditDetails WithCreditStatus(Status creditStatus)
        {
            this.creditStatusField = creditStatus;
            return this;
        }



        /// <summary>
        /// Checks if CreditStatus property is set
        /// </summary>
        /// <returns>true if CreditStatus property is set</returns>
        public Boolean IsSetCreditStatus()
        {
            return this.creditStatusField != null;
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
            if (IsSetAmazonProviderCreditId())
            {
                xml.Append("<AmazonProviderCreditId>");
                xml.Append(this.AmazonProviderCreditId);
                xml.Append("</AmazonProviderCreditId>");
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
            if (IsSetCreditReferenceId())
            {
                xml.Append("<CreditReferenceId>");
                xml.Append(this.CreditReferenceId);
                xml.Append("</CreditReferenceId>");
            }
            if (IsSetCreditAmount())
            {
                Price creditAmountObj = this.CreditAmount;
                xml.Append("<CreditAmount>");
                xml.Append(creditAmountObj.ToXMLFragment());
                xml.Append("</CreditAmount>");
            }
            if (IsSetCreditReversalAmount())
            {
                Price creditReversalAmountObj = this.CreditReversalAmount;
                xml.Append("<CreditReversalAmount>");
                xml.Append(creditReversalAmountObj.ToXMLFragment());
                xml.Append("</CreditReversalAmount>");
            }
            if (IsSetCreditReversalIdList())
            {
                IdList creditReversalIdListObj = this.CreditReversalIdList;
                xml.Append("<CreditReversalIdList>");
                xml.Append(creditReversalIdListObj.ToXMLFragment());
                xml.Append("</CreditReversalIdList>");
            }
            if (IsSetCreationTimestamp())
            {
                xml.Append("<CreationTimestamp>");
                xml.Append(this.CreationTimestamp);
                xml.Append("</CreationTimestamp>");
            }
            if (IsSetCreditStatus())
            {
                Status creditStatusObj = this.CreditStatus;
                xml.Append("<CreditStatus>");
                xml.Append(creditStatusObj.ToXMLFragment());
                xml.Append("</CreditStatus>");
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