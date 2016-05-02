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
    public class AuthorizeOnBillingAgreementRequest
    {

        private String sellerIdField;

        private String amazonBillingAgreementIdField;

        private String authorizationReferenceIdField;

        private Price authorizationAmountField;
        private String sellerAuthorizationNoteField;

        private UInt32? transactionTimeoutField;

        private Boolean? captureNowField;

        private String softDescriptorField;

        private String sellerNoteField;

        private String platformIdField;

        private SellerOrderAttributes sellerOrderAttributesField;

        private Boolean? inheritShippingAddressField;

        private String mwsAuthTokenField; 

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
        public AuthorizeOnBillingAgreementRequest WithSellerId(String sellerId)
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
        public AuthorizeOnBillingAgreementRequest WithAmazonBillingAgreementId(String amazonBillingAgreementId)
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
        /// Gets and sets the AuthorizationReferenceId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AuthorizationReferenceId")]
        public String AuthorizationReferenceId
        {
            get { return this.authorizationReferenceIdField; }
            set { this.authorizationReferenceIdField = value; }
        }



        /// <summary>
        /// Sets the AuthorizationReferenceId property
        /// </summary>
        /// <param name="authorizationReferenceId">AuthorizationReferenceId property</param>
        /// <returns>this instance</returns>
        public AuthorizeOnBillingAgreementRequest WithAuthorizationReferenceId(String authorizationReferenceId)
        {
            this.authorizationReferenceIdField = authorizationReferenceId;
            return this;
        }



        /// <summary>
        /// Checks if AuthorizationReferenceId property is set
        /// </summary>
        /// <returns>true if AuthorizationReferenceId property is set</returns>
        public Boolean IsSetAuthorizationReferenceId()
        {
            return this.authorizationReferenceIdField != null;

        }





        /// <summary>
        /// Gets and sets the AuthorizationAmount property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AuthorizationAmount")]
        public Price AuthorizationAmount
        {
            get { return this.authorizationAmountField; }
            set { this.authorizationAmountField = value; }
        }



        /// <summary>
        /// Sets the AuthorizationAmount property
        /// </summary>
        /// <param name="authorizationAmount">AuthorizationAmount property</param>
        /// <returns>this instance</returns>
        public AuthorizeOnBillingAgreementRequest WithAuthorizationAmount(Price authorizationAmount)
        {
            this.authorizationAmountField = authorizationAmount;
            return this;
        }



        /// <summary>
        /// Checks if AuthorizationAmount property is set
        /// </summary>
        /// <returns>true if AuthorizationAmount property is set</returns>
        public Boolean IsSetAuthorizationAmount()
        {
            return this.authorizationAmountField != null;
        }



        /// <summary>
        /// Gets and sets the SellerAuthorizationNote property.
        /// </summary>
        [XmlElementAttribute(ElementName = "SellerAuthorizationNote")]
        public String SellerAuthorizationNote
        {
            get { return this.sellerAuthorizationNoteField; }
            set { this.sellerAuthorizationNoteField = value; }
        }



        /// <summary>
        /// Sets the SellerAuthorizationNote property
        /// </summary>
        /// <param name="sellerAuthorizationNote">SellerAuthorizationNote property</param>
        /// <returns>this instance</returns>
        public AuthorizeOnBillingAgreementRequest WithSellerAuthorizationNote(String sellerAuthorizationNote)
        {
            this.sellerAuthorizationNoteField = sellerAuthorizationNote;
            return this;
        }



        /// <summary>
        /// Checks if SellerAuthorizationNote property is set
        /// </summary>
        /// <returns>true if SellerAuthorizationNote property is set</returns>
        public Boolean IsSetSellerAuthorizationNote()
        {
            return this.sellerAuthorizationNoteField != null;

        }





        /// <summary>
        /// Gets and sets the TransactionTimeout property.
        /// </summary>
        [XmlElementAttribute(ElementName = "TransactionTimeout")]
        public UInt32? TransactionTimeout
        {
            get { return this.transactionTimeoutField; }
            set { this.transactionTimeoutField = value; }
        }



        /// <summary>
        /// Sets the TransactionTimeout property
        /// </summary>
        /// <param name="transactionTimeout">TransactionTimeout property</param>
        /// <returns>this instance</returns>
        public AuthorizeOnBillingAgreementRequest WithTransactionTimeout(UInt32? transactionTimeout)
        {
            this.transactionTimeoutField = transactionTimeout;
            return this;
        }



        /// <summary>
        /// Checks if TransactionTimeout property is set
        /// </summary>
        /// <returns>true if TransactionTimeout property is set</returns>
        public Boolean IsSetTransactionTimeout()
        {
            return this.transactionTimeoutField != null;

        }





        /// <summary>
        /// Gets and sets the CaptureNow property.
        /// </summary>
        [XmlElementAttribute(ElementName = "CaptureNow")]
        public Boolean CaptureNow
        {
            get { return this.captureNowField.GetValueOrDefault(); }
            set { this.captureNowField = value; }
        }



        /// <summary>
        /// Sets the CaptureNow property
        /// </summary>
        /// <param name="captureNow">CaptureNow property</param>
        /// <returns>this instance</returns>
        public AuthorizeOnBillingAgreementRequest WithCaptureNow(Boolean captureNow)
        {
            this.captureNowField = captureNow;
            return this;
        }



        /// <summary>
        /// Checks if CaptureNow property is set
        /// </summary>
        /// <returns>true if CaptureNow property is set</returns>
        public Boolean IsSetCaptureNow()
        {
            return this.captureNowField.HasValue;

        }





        /// <summary>
        /// Gets and sets the SoftDescriptor property.
        /// </summary>
        [XmlElementAttribute(ElementName = "SoftDescriptor")]
        public String SoftDescriptor
        {
            get { return this.softDescriptorField; }
            set { this.softDescriptorField = value; }
        }



        /// <summary>
        /// Sets the SoftDescriptor property
        /// </summary>
        /// <param name="softDescriptor">SoftDescriptor property</param>
        /// <returns>this instance</returns>
        public AuthorizeOnBillingAgreementRequest WithSoftDescriptor(String softDescriptor)
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
        public AuthorizeOnBillingAgreementRequest WithSellerNote(String sellerNote)
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
        public AuthorizeOnBillingAgreementRequest WithPlatformId(String platformId)
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
        /// Gets and sets the SellerOrderAttributes property.
        /// </summary>
        [XmlElementAttribute(ElementName = "SellerOrderAttributes")]
        public SellerOrderAttributes SellerOrderAttributes
        {
            get { return this.sellerOrderAttributesField; }
            set { this.sellerOrderAttributesField = value; }
        }



        /// <summary>
        /// Sets the SellerOrderAttributes property
        /// </summary>
        /// <param name="sellerOrderAttributes">SellerOrderAttributes property</param>
        /// <returns>this instance</returns>
        public AuthorizeOnBillingAgreementRequest WithSellerOrderAttributes(SellerOrderAttributes sellerOrderAttributes)
        {
            this.sellerOrderAttributesField = sellerOrderAttributes;
            return this;
        }



        /// <summary>
        /// Checks if SellerOrderAttributes property is set
        /// </summary>
        /// <returns>true if SellerOrderAttributes property is set</returns>
        public Boolean IsSetSellerOrderAttributes()
        {
            return this.sellerOrderAttributesField != null;
        }



        /// <summary>
        /// Gets and sets the InheritShippingAddress property.
        /// </summary>
        [XmlElementAttribute(ElementName = "InheritShippingAddress")]
        public Boolean InheritShippingAddress
        {
            get { return this.inheritShippingAddressField.GetValueOrDefault(); }
            set { this.inheritShippingAddressField = value; }
        }



        /// <summary>
        /// Sets the InheritShippingAddress property
        /// </summary>
        /// <param name="inheritShippingAddress">InheritShippingAddress property</param>
        /// <returns>this instance</returns>
        public AuthorizeOnBillingAgreementRequest WithInheritShippingAddress(Boolean inheritShippingAddress)
        {
            this.inheritShippingAddressField = inheritShippingAddress;
            return this;
        }



        /// <summary>
        /// Checks if InheritShippingAddress property is set
        /// </summary>
        /// <returns>true if InheritShippingAddress property is set</returns>
        public Boolean IsSetInheritShippingAddress()
        {
            return this.inheritShippingAddressField.HasValue;

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
        public AuthorizeOnBillingAgreementRequest WithMWSAuthToken(String mwsAuthToken)
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