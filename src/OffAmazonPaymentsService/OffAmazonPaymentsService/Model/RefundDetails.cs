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
    public class RefundDetails
    {
    
        private String amazonRefundIdField;

        private String refundReferenceIdField;

        private String sellerRefundNoteField;

        private RefundType? refundTypeField;

        private  Price refundAmountField;
        private  Price feeRefundedField;
        private DateTime? creationTimestampField;

        private  Status refundStatusField;
        private String softDescriptorField;

        private ProviderCreditReversalSummaryList providerCreditReversalSummaryListField;


        /// <summary>
        /// Gets and sets the AmazonRefundId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AmazonRefundId")]
        public String AmazonRefundId
        {
            get { return this.amazonRefundIdField ; }
            set { this.amazonRefundIdField= value; }
        }



        /// <summary>
        /// Sets the AmazonRefundId property
        /// </summary>
        /// <param name="amazonRefundId">AmazonRefundId property</param>
        /// <returns>this instance</returns>
        public RefundDetails WithAmazonRefundId(String amazonRefundId)
        {
            this.amazonRefundIdField = amazonRefundId;
            return this;
        }



        /// <summary>
        /// Checks if AmazonRefundId property is set
        /// </summary>
        /// <returns>true if AmazonRefundId property is set</returns>
        public Boolean IsSetAmazonRefundId()
        {
            return this.amazonRefundIdField != null;

        }





        /// <summary>
        /// Gets and sets the RefundReferenceId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "RefundReferenceId")]
        public String RefundReferenceId
        {
            get { return this.refundReferenceIdField ; }
            set { this.refundReferenceIdField= value; }
        }



        /// <summary>
        /// Sets the RefundReferenceId property
        /// </summary>
        /// <param name="refundReferenceId">RefundReferenceId property</param>
        /// <returns>this instance</returns>
        public RefundDetails WithRefundReferenceId(String refundReferenceId)
        {
            this.refundReferenceIdField = refundReferenceId;
            return this;
        }



        /// <summary>
        /// Checks if RefundReferenceId property is set
        /// </summary>
        /// <returns>true if RefundReferenceId property is set</returns>
        public Boolean IsSetRefundReferenceId()
        {
            return this.refundReferenceIdField != null;

        }





        /// <summary>
        /// Gets and sets the SellerRefundNote property.
        /// </summary>
        [XmlElementAttribute(ElementName = "SellerRefundNote")]
        public String SellerRefundNote
        {
            get { return this.sellerRefundNoteField ; }
            set { this.sellerRefundNoteField= value; }
        }



        /// <summary>
        /// Sets the SellerRefundNote property
        /// </summary>
        /// <param name="sellerRefundNote">SellerRefundNote property</param>
        /// <returns>this instance</returns>
        public RefundDetails WithSellerRefundNote(String sellerRefundNote)
        {
            this.sellerRefundNoteField = sellerRefundNote;
            return this;
        }



        /// <summary>
        /// Checks if SellerRefundNote property is set
        /// </summary>
        /// <returns>true if SellerRefundNote property is set</returns>
        public Boolean IsSetSellerRefundNote()
        {
            return  this.sellerRefundNoteField != null;

        }





        /// <summary>
        /// Gets and sets the RefundType property.
        /// </summary>
        [XmlElementAttribute(ElementName = "RefundType")]
        public RefundType RefundType
        {
            get { return this.refundTypeField.GetValueOrDefault() ; }
            set { this.refundTypeField= value; }
        }



        /// <summary>
        /// Sets the RefundType property
        /// </summary>
        /// <param name="refundType">RefundType property</param>
        /// <returns>this instance</returns>
        public RefundDetails WithRefundType(RefundType refundType)
        {
            this.refundTypeField = refundType;
            return this;
        }



        /// <summary>
        /// Checks if RefundType property is set
        /// </summary>
        /// <returns>true if RefundType property is set</returns>
        public Boolean IsSetRefundType()
        {
            return this.refundTypeField.HasValue;

        }





        /// <summary>
        /// Gets and sets the RefundAmount property.
        /// </summary>
        [XmlElementAttribute(ElementName = "RefundAmount")]
        public Price RefundAmount
        {
            get { return this.refundAmountField ; }
            set { this.refundAmountField = value; }
        }



        /// <summary>
        /// Sets the RefundAmount property
        /// </summary>
        /// <param name="refundAmount">RefundAmount property</param>
        /// <returns>this instance</returns>
        public RefundDetails WithRefundAmount(Price refundAmount)
        {
            this.refundAmountField = refundAmount;
            return this;
        }



        /// <summary>
        /// Checks if RefundAmount property is set
        /// </summary>
        /// <returns>true if RefundAmount property is set</returns>
        public Boolean IsSetRefundAmount()
        {
            return this.refundAmountField != null;
        }



        /// <summary>
        /// Gets and sets the FeeRefunded property.
        /// </summary>
        [XmlElementAttribute(ElementName = "FeeRefunded")]
        public Price FeeRefunded
        {
            get { return this.feeRefundedField ; }
            set { this.feeRefundedField = value; }
        }



        /// <summary>
        /// Sets the FeeRefunded property
        /// </summary>
        /// <param name="feeRefunded">FeeRefunded property</param>
        /// <returns>this instance</returns>
        public RefundDetails WithFeeRefunded(Price feeRefunded)
        {
            this.feeRefundedField = feeRefunded;
            return this;
        }



        /// <summary>
        /// Checks if FeeRefunded property is set
        /// </summary>
        /// <returns>true if FeeRefunded property is set</returns>
        public Boolean IsSetFeeRefunded()
        {
            return this.feeRefundedField != null;
        }



        /// <summary>
        /// Gets and sets the CreationTimestamp property.
        /// </summary>
        [XmlElementAttribute(ElementName = "CreationTimestamp")]
        public DateTime CreationTimestamp
        {
            get { return this.creationTimestampField.GetValueOrDefault() ; }
            set { this.creationTimestampField= value; }
        }



        /// <summary>
        /// Sets the CreationTimestamp property
        /// </summary>
        /// <param name="creationTimestamp">CreationTimestamp property</param>
        /// <returns>this instance</returns>
        public RefundDetails WithCreationTimestamp(DateTime creationTimestamp)
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
            return  this.creationTimestampField.HasValue;

        }





        /// <summary>
        /// Gets and sets the RefundStatus property.
        /// </summary>
        [XmlElementAttribute(ElementName = "RefundStatus")]
        public Status RefundStatus
        {
            get { return this.refundStatusField ; }
            set { this.refundStatusField = value; }
        }



        /// <summary>
        /// Sets the RefundStatus property
        /// </summary>
        /// <param name="refundStatus">RefundStatus property</param>
        /// <returns>this instance</returns>
        public RefundDetails WithRefundStatus(Status refundStatus)
        {
            this.refundStatusField = refundStatus;
            return this;
        }



        /// <summary>
        /// Checks if RefundStatus property is set
        /// </summary>
        /// <returns>true if RefundStatus property is set</returns>
        public Boolean IsSetRefundStatus()
        {
            return this.refundStatusField != null;
        }



        /// <summary>
        /// Gets and sets the SoftDescriptor property.
        /// </summary>
        [XmlElementAttribute(ElementName = "SoftDescriptor")]
        public String SoftDescriptor
        {
            get { return this.softDescriptorField ; }
            set { this.softDescriptorField= value; }
        }



        /// <summary>
        /// Sets the SoftDescriptor property
        /// </summary>
        /// <param name="softDescriptor">SoftDescriptor property</param>
        /// <returns>this instance</returns>
        public RefundDetails WithSoftDescriptor(String softDescriptor)
        {
            this.softDescriptorField = softDescriptor;
            return this;
        }



        /// <summary>
        /// Checks if SoftDescriptor property is set
        /// </summary>
        /// <returns>true if SoftDescriptor property is set</returns>
        public Boolean IsSetSoftDescriptor()
        {
            return  this.softDescriptorField != null;

        }





        /// <summary>
        /// Gets and sets the ProviderCreditReversalSummaryList property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ProviderCreditReversalSummaryList")]
        public ProviderCreditReversalSummaryList ProviderCreditReversalSummaryList
        {
            get { return this.providerCreditReversalSummaryListField; }
            set { this.providerCreditReversalSummaryListField = value; }
        }



        /// <summary>
        /// Sets the ProviderCreditReversalSummaryList property
        /// </summary>
        /// <param name="providerCreditReversalSummaryList">ProviderCreditReversalSummaryList property</param>
        /// <returns>this instance</returns>
        public RefundDetails WithProviderCreditReversalSummaryList(ProviderCreditReversalSummaryList providerCreditReversalSummaryList)
        {
            this.providerCreditReversalSummaryListField = providerCreditReversalSummaryList;
            return this;
        }



        /// <summary>
        /// Checks if ProviderCreditReversalSummaryList property is set
        /// </summary>
        /// <returns>true if ProviderCreditReversalSummaryList property is set</returns>
        public Boolean IsSetProviderCreditReversalSummaryList()
        {
            return this.providerCreditReversalSummaryListField != null;
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
            if (IsSetAmazonRefundId()) {
                xml.Append("<AmazonRefundId>");
                xml.Append(this.AmazonRefundId);
                xml.Append("</AmazonRefundId>");
            }
            if (IsSetRefundReferenceId()) {
                xml.Append("<RefundReferenceId>");
                xml.Append(this.RefundReferenceId);
                xml.Append("</RefundReferenceId>");
            }
            if (IsSetSellerRefundNote()) {
                xml.Append("<SellerRefundNote>");
                xml.Append(EscapeXML(this.SellerRefundNote));
                xml.Append("</SellerRefundNote>");
            }
            if (IsSetRefundType()) {
                xml.Append("<RefundType>");
                xml.Append(this.RefundType);
                xml.Append("</RefundType>");
            }
            if (IsSetRefundAmount()) {
                Price  refundAmountObj = this.RefundAmount;
                xml.Append("<RefundAmount>");
                xml.Append(refundAmountObj.ToXMLFragment());
                xml.Append("</RefundAmount>");
            } 
            if (IsSetFeeRefunded()) {
                Price  feeRefundedObj = this.FeeRefunded;
                xml.Append("<FeeRefunded>");
                xml.Append(feeRefundedObj.ToXMLFragment());
                xml.Append("</FeeRefunded>");
            } 
            if (IsSetCreationTimestamp()) {
                xml.Append("<CreationTimestamp>");
                xml.Append(this.CreationTimestamp);
                xml.Append("</CreationTimestamp>");
            }
            if (IsSetRefundStatus()) {
                Status  refundStatusObj = this.RefundStatus;
                xml.Append("<RefundStatus>");
                xml.Append(refundStatusObj.ToXMLFragment());
                xml.Append("</RefundStatus>");
            } 
            if (IsSetSoftDescriptor()) {
                xml.Append("<SoftDescriptor>");
                xml.Append(EscapeXML(this.SoftDescriptor));
                xml.Append("</SoftDescriptor>");
            }
            if (IsSetProviderCreditReversalSummaryList())
            {
                ProviderCreditReversalSummaryList providerCreditReversalSummaryListObj = this.ProviderCreditReversalSummaryList;
                xml.Append("<ProviderCreditReversalSummaryList>");
                xml.Append(providerCreditReversalSummaryListObj.ToXMLFragment());
                xml.Append("</ProviderCreditReversalSummaryList>");
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