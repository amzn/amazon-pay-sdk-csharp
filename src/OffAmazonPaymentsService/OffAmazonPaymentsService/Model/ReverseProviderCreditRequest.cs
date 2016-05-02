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
    public class ReverseProviderCreditRequest
    {

        private String sellerIdField;

        private String amazonProviderCreditIdField;

        private String creditReversalReferenceIdField;

        private Price creditReversalAmountField;

        private String creditReversalNoteField;

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
        public ReverseProviderCreditRequest WithSellerId(String sellerId)
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
        public ReverseProviderCreditRequest WithAmazonProviderCreditId(String amazonProviderCreditId)
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
        public ReverseProviderCreditRequest WithCreditReversalReferenceId(String creditReversalReferenceId)
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
        public ReverseProviderCreditRequest WithCreditReversalAmount(Price creditReversalAmount)
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
        public ReverseProviderCreditRequest WithCreditReversalNote(String creditReversalNote)
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
        public ReverseProviderCreditRequest WithMWSAuthToken(String mwsAuthToken)
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