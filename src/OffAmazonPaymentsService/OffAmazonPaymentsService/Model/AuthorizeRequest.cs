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
    public class AuthorizeRequest
    {
    
        private String sellerIdField;

        private String amazonOrderReferenceIdField;

        private String authorizationReferenceIdField;

        private  Price authorizationAmountField;
        private String sellerAuthorizationNoteField;

        private  OrderItemCategories orderItemCategoriesField;
        private UInt32? transactionTimeoutField;

        private Boolean? captureNowField;

        private String softDescriptorField;

        private ProviderCreditList providerCreditListField;

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
        public AuthorizeRequest WithSellerId(String sellerId)
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
        /// Gets and sets the AmazonOrderReferenceId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AmazonOrderReferenceId")]
        public String AmazonOrderReferenceId
        {
            get { return this.amazonOrderReferenceIdField ; }
            set { this.amazonOrderReferenceIdField= value; }
        }



        /// <summary>
        /// Sets the AmazonOrderReferenceId property
        /// </summary>
        /// <param name="amazonOrderReferenceId">AmazonOrderReferenceId property</param>
        /// <returns>this instance</returns>
        public AuthorizeRequest WithAmazonOrderReferenceId(String amazonOrderReferenceId)
        {
            this.amazonOrderReferenceIdField = amazonOrderReferenceId;
            return this;
        }



        /// <summary>
        /// Checks if AmazonOrderReferenceId property is set
        /// </summary>
        /// <returns>true if AmazonOrderReferenceId property is set</returns>
        public Boolean IsSetAmazonOrderReferenceId()
        {
            return  this.amazonOrderReferenceIdField != null;

        }





        /// <summary>
        /// Gets and sets the AuthorizationReferenceId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AuthorizationReferenceId")]
        public String AuthorizationReferenceId
        {
            get { return this.authorizationReferenceIdField ; }
            set { this.authorizationReferenceIdField= value; }
        }



        /// <summary>
        /// Sets the AuthorizationReferenceId property
        /// </summary>
        /// <param name="authorizationReferenceId">AuthorizationReferenceId property</param>
        /// <returns>this instance</returns>
        public AuthorizeRequest WithAuthorizationReferenceId(String authorizationReferenceId)
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
            get { return this.authorizationAmountField ; }
            set { this.authorizationAmountField = value; }
        }



        /// <summary>
        /// Sets the AuthorizationAmount property
        /// </summary>
        /// <param name="authorizationAmount">AuthorizationAmount property</param>
        /// <returns>this instance</returns>
        public AuthorizeRequest WithAuthorizationAmount(Price authorizationAmount)
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
            get { return this.sellerAuthorizationNoteField ; }
            set { this.sellerAuthorizationNoteField= value; }
        }



        /// <summary>
        /// Sets the SellerAuthorizationNote property
        /// </summary>
        /// <param name="sellerAuthorizationNote">SellerAuthorizationNote property</param>
        /// <returns>this instance</returns>
        public AuthorizeRequest WithSellerAuthorizationNote(String sellerAuthorizationNote)
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
        /// Gets and sets the OrderItemCategories property.
        /// </summary>
        [XmlElementAttribute(ElementName = "OrderItemCategories")]
        public OrderItemCategories OrderItemCategories
        {
            get { return this.orderItemCategoriesField ; }
            set { this.orderItemCategoriesField = value; }
        }



        /// <summary>
        /// Sets the OrderItemCategories property
        /// </summary>
        /// <param name="orderItemCategories">OrderItemCategories property</param>
        /// <returns>this instance</returns>
        public AuthorizeRequest WithOrderItemCategories(OrderItemCategories orderItemCategories)
        {
            this.orderItemCategoriesField = orderItemCategories;
            return this;
        }



        /// <summary>
        /// Checks if OrderItemCategories property is set
        /// </summary>
        /// <returns>true if OrderItemCategories property is set</returns>
        public Boolean IsSetOrderItemCategories()
        {
            return this.orderItemCategoriesField != null;
        }



        /// <summary>
        /// Gets and sets the TransactionTimeout property.
        /// </summary>
        [XmlElementAttribute(ElementName = "TransactionTimeout")]
        public UInt32? TransactionTimeout
        {
            get { return this.transactionTimeoutField ; }
            set { this.transactionTimeoutField= value; }
        }



        /// <summary>
        /// Sets the TransactionTimeout property
        /// </summary>
        /// <param name="transactionTimeout">TransactionTimeout property</param>
        /// <returns>this instance</returns>
        public AuthorizeRequest WithTransactionTimeout(UInt32? transactionTimeout)
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
            get { return this.captureNowField.GetValueOrDefault() ; }
            set { this.captureNowField= value; }
        }



        /// <summary>
        /// Sets the CaptureNow property
        /// </summary>
        /// <param name="captureNow">CaptureNow property</param>
        /// <returns>this instance</returns>
        public AuthorizeRequest WithCaptureNow(Boolean captureNow)
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
            return  this.captureNowField.HasValue;

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
        public AuthorizeRequest WithSoftDescriptor(String softDescriptor)
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
        /// Gets and sets the ProviderCreditList property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ProviderCreditList")]
        public ProviderCreditList ProviderCreditList
        {
            get { return this.providerCreditListField; }
            set { this.providerCreditListField = value; }
        }



        /// <summary>
        /// Sets the ProviderCreditList property
        /// </summary>
        /// <param name="providerCreditList">ProviderCreditList property</param>
        /// <returns>this instance</returns>
        public AuthorizeRequest WithProviderCreditList(ProviderCreditList providerCreditList)
        {
            this.providerCreditListField = providerCreditList;
            return this;
        }



        /// <summary>
        /// Checks if ProviderCreditList property is set
        /// </summary>
        /// <returns>true if ProviderCreditList property is set</returns>
        public Boolean IsSetProviderCreditList()
        {
            return this.providerCreditListField != null;
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
        public AuthorizeRequest WithMWSAuthToken(String mwsAuthToken)
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