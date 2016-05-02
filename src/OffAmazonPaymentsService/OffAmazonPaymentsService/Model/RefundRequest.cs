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
    public class RefundRequest
    {
    
        private String sellerIdField;

        private String amazonCaptureIdField;

        private String refundReferenceIdField;

        private  Price refundAmountField;
        private String sellerRefundNoteField;

        private String softDescriptorField;

        private ProviderCreditReversalList providerCreditReversalListField;

        private String mwsAuthTokenField;

        /// <summary>
        /// Gets and sets the SellerId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "SellerId")]
        public String SellerId
        {
            get { return this.sellerIdField ; }
            set { this.sellerIdField= value; }
        }



        /// <summary>
        /// Sets the SellerId property
        /// </summary>
        /// <param name="sellerId">SellerId property</param>
        /// <returns>this instance</returns>
        public RefundRequest WithSellerId(String sellerId)
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
        /// Gets and sets the AmazonCaptureId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AmazonCaptureId")]
        public String AmazonCaptureId
        {
            get { return this.amazonCaptureIdField ; }
            set { this.amazonCaptureIdField= value; }
        }



        /// <summary>
        /// Sets the AmazonCaptureId property
        /// </summary>
        /// <param name="amazonCaptureId">AmazonCaptureId property</param>
        /// <returns>this instance</returns>
        public RefundRequest WithAmazonCaptureId(String amazonCaptureId)
        {
            this.amazonCaptureIdField = amazonCaptureId;
            return this;
        }



        /// <summary>
        /// Checks if AmazonCaptureId property is set
        /// </summary>
        /// <returns>true if AmazonCaptureId property is set</returns>
        public Boolean IsSetAmazonCaptureId()
        {
            return this.amazonCaptureIdField != null;

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
        public RefundRequest WithRefundReferenceId(String refundReferenceId)
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
        public RefundRequest WithRefundAmount(Price refundAmount)
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
        public RefundRequest WithSellerRefundNote(String sellerRefundNote)
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
            return this.sellerRefundNoteField != null;

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
        public RefundRequest WithSoftDescriptor(String softDescriptor)
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
            return this.softDescriptorField != null;

        }



        /// <summary>
        /// Gets and sets the ProviderCreditReversalList property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ProviderCreditReversalList")]
        public ProviderCreditReversalList ProviderCreditReversalList
        {
            get { return this.providerCreditReversalListField; }
            set { this.providerCreditReversalListField = value; }
        }



        /// <summary>
        /// Sets the ProviderCreditReversalList property
        /// </summary>
        /// <param name="providerCreditReversalList">ProviderCreditReversalList property</param>
        /// <returns>this instance</returns>
        public RefundRequest WithProviderCreditReversalList(ProviderCreditReversalList providerCreditReversalList)
        {
            this.providerCreditReversalListField = providerCreditReversalList;
            return this;
        }



        /// <summary>
        /// Checks if ProviderCreditReversalList property is set
        /// </summary>
        /// <returns>true if ProviderCreditReversalList property is set</returns>
        public Boolean IsSetProviderCreditReversalList()
        {
            return this.providerCreditReversalListField != null;
        }



        /// <summary>
        /// Gets and sets the mwsAuthToken property.
        /// </summary>
        [XmlElementAttribute(ElementName = "MWSAuthToken")]
        public String MWSAuthToken
        {
            get { return this.mwsAuthTokenField; }
            set { this.mwsAuthTokenField = value; }
        }

        /// <summary>
        /// Sets the mwsAuthToken property
        /// </summary>
        /// <param name="mwsAuthToken">MWSAuthToken property</param>
        /// <returns>this instance</returns>
        public RefundRequest WithMWSAuthToken(String mwsAuthToken)
        {
            this.mwsAuthTokenField = mwsAuthToken;
            return this;
        }

        /// <summary>
        /// Checks if mwsAuthToken property is set
        /// </summary>
        /// <returns>true if mwsAuthToken property is set</returns>
        public Boolean IsSetMWSAuthToken()
        {
            return this.mwsAuthTokenField != null;

        }




    }

}