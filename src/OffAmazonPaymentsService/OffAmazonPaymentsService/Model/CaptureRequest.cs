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
    public class CaptureRequest
    {
    
        private String sellerIdField;

        private String amazonAuthorizationIdField;

        private String captureReferenceIdField;

        private  Price captureAmountField;
        private String sellerCaptureNoteField;

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
        public CaptureRequest WithSellerId(String sellerId)
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
        /// Gets and sets the AmazonAuthorizationId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AmazonAuthorizationId")]
        public String AmazonAuthorizationId
        {
            get { return this.amazonAuthorizationIdField ; }
            set { this.amazonAuthorizationIdField= value; }
        }



        /// <summary>
        /// Sets the AmazonAuthorizationId property
        /// </summary>
        /// <param name="amazonAuthorizationId">AmazonAuthorizationId property</param>
        /// <returns>this instance</returns>
        public CaptureRequest WithAmazonAuthorizationId(String amazonAuthorizationId)
        {
            this.amazonAuthorizationIdField = amazonAuthorizationId;
            return this;
        }



        /// <summary>
        /// Checks if AmazonAuthorizationId property is set
        /// </summary>
        /// <returns>true if AmazonAuthorizationId property is set</returns>
        public Boolean IsSetAmazonAuthorizationId()
        {
            return this.amazonAuthorizationIdField != null;

        }





        /// <summary>
        /// Gets and sets the CaptureReferenceId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "CaptureReferenceId")]
        public String CaptureReferenceId
        {
            get { return this.captureReferenceIdField ; }
            set { this.captureReferenceIdField= value; }
        }



        /// <summary>
        /// Sets the CaptureReferenceId property
        /// </summary>
        /// <param name="captureReferenceId">CaptureReferenceId property</param>
        /// <returns>this instance</returns>
        public CaptureRequest WithCaptureReferenceId(String captureReferenceId)
        {
            this.captureReferenceIdField = captureReferenceId;
            return this;
        }



        /// <summary>
        /// Checks if CaptureReferenceId property is set
        /// </summary>
        /// <returns>true if CaptureReferenceId property is set</returns>
        public Boolean IsSetCaptureReferenceId()
        {
            return this.captureReferenceIdField != null;

        }





        /// <summary>
        /// Gets and sets the CaptureAmount property.
        /// </summary>
        [XmlElementAttribute(ElementName = "CaptureAmount")]
        public Price CaptureAmount
        {
            get { return this.captureAmountField ; }
            set { this.captureAmountField = value; }
        }



        /// <summary>
        /// Sets the CaptureAmount property
        /// </summary>
        /// <param name="captureAmount">CaptureAmount property</param>
        /// <returns>this instance</returns>
        public CaptureRequest WithCaptureAmount(Price captureAmount)
        {
            this.captureAmountField = captureAmount;
            return this;
        }



        /// <summary>
        /// Checks if CaptureAmount property is set
        /// </summary>
        /// <returns>true if CaptureAmount property is set</returns>
        public Boolean IsSetCaptureAmount()
        {
            return this.captureAmountField != null;
        }



        /// <summary>
        /// Gets and sets the SellerCaptureNote property.
        /// </summary>
        [XmlElementAttribute(ElementName = "SellerCaptureNote")]
        public String SellerCaptureNote
        {
            get { return this.sellerCaptureNoteField ; }
            set { this.sellerCaptureNoteField= value; }
        }



        /// <summary>
        /// Sets the SellerCaptureNote property
        /// </summary>
        /// <param name="sellerCaptureNote">SellerCaptureNote property</param>
        /// <returns>this instance</returns>
        public CaptureRequest WithSellerCaptureNote(String sellerCaptureNote)
        {
            this.sellerCaptureNoteField = sellerCaptureNote;
            return this;
        }



        /// <summary>
        /// Checks if SellerCaptureNote property is set
        /// </summary>
        /// <returns>true if SellerCaptureNote property is set</returns>
        public Boolean IsSetSellerCaptureNote()
        {
            return this.sellerCaptureNoteField != null;

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
        public CaptureRequest WithSoftDescriptor(String softDescriptor)
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
        public CaptureRequest WithProviderCreditList(ProviderCreditList providerCreditList)
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
        public CaptureRequest WithMWSAuthToken(String mwsAuthToken)
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