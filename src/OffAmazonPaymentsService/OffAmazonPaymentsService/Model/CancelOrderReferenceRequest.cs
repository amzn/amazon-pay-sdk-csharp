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
    public class CancelOrderReferenceRequest
    {
    
        private String sellerIdField;

        private String amazonOrderReferenceIdField;

        private String cancelationReasonField;

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
        public CancelOrderReferenceRequest WithSellerId(String sellerId)
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
        public CancelOrderReferenceRequest WithAmazonOrderReferenceId(String amazonOrderReferenceId)
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
        /// Gets and sets the CancelationReason property.
        /// </summary>
        [XmlElementAttribute(ElementName = "CancelationReason")]
        public String CancelationReason
        {
            get { return this.cancelationReasonField ; }
            set { this.cancelationReasonField= value; }
        }



        /// <summary>
        /// Sets the CancelationReason property
        /// </summary>
        /// <param name="cancelationReason">CancelationReason property</param>
        /// <returns>this instance</returns>
        public CancelOrderReferenceRequest WithCancelationReason(String cancelationReason)
        {
            this.cancelationReasonField = cancelationReason;
            return this;
        }



        /// <summary>
        /// Checks if CancelationReason property is set
        /// </summary>
        /// <returns>true if CancelationReason property is set</returns>
        public Boolean IsSetCancelationReason()
        {
            return this.cancelationReasonField != null;

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
        public CancelOrderReferenceRequest WithMWSAuthToken(String mwsAuthToken)
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