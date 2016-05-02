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
    public class CreateOrderReferenceForIdRequest
    {

        private String idField;

        private String sellerIdField;

        private String idTypeField;

        private Boolean? inheritShippingAddressField;

        private Boolean? confirmNowField;

        private OrderReferenceAttributes orderReferenceAttributesField;

        private String mwsAuthTokenField;

        /// <summary>
        /// Gets and sets the Id property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Id")]
        public String Id
        {
            get { return this.idField; }
            set { this.idField = value; }
        }



        /// <summary>
        /// Sets the Id property
        /// </summary>
        /// <param name="id">Id property</param>
        /// <returns>this instance</returns>
        public CreateOrderReferenceForIdRequest WithId(String id)
        {
            this.idField = id;
            return this;
        }



        /// <summary>
        /// Checks if Id property is set
        /// </summary>
        /// <returns>true if Id property is set</returns>
        public Boolean IsSetId()
        {
            return this.idField != null;

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
        public CreateOrderReferenceForIdRequest WithSellerId(String sellerId)
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
        /// Gets and sets the IdType property.
        /// </summary>
        [XmlElementAttribute(ElementName = "IdType")]
        public String IdType
        {
            get { return this.idTypeField; }
            set { this.idTypeField = value; }
        }



        /// <summary>
        /// Sets the IdType property
        /// </summary>
        /// <param name="idType">IdType property</param>
        /// <returns>this instance</returns>
        public CreateOrderReferenceForIdRequest WithIdType(String idType)
        {
            this.idTypeField = idType;
            return this;
        }



        /// <summary>
        /// Checks if IdType property is set
        /// </summary>
        /// <returns>true if IdType property is set</returns>
        public Boolean IsSetIdType()
        {
            return this.idTypeField != null;

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
        public CreateOrderReferenceForIdRequest WithInheritShippingAddress(Boolean inheritShippingAddress)
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
        /// Gets and sets the ConfirmNow property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ConfirmNow")]
        public Boolean ConfirmNow
        {
            get { return this.confirmNowField.GetValueOrDefault(); }
            set { this.confirmNowField = value; }
        }



        /// <summary>
        /// Sets the ConfirmNow property
        /// </summary>
        /// <param name="confirmNow">ConfirmNow property</param>
        /// <returns>this instance</returns>
        public CreateOrderReferenceForIdRequest WithConfirmNow(Boolean confirmNow)
        {
            this.confirmNowField = confirmNow;
            return this;
        }



        /// <summary>
        /// Checks if ConfirmNow property is set
        /// </summary>
        /// <returns>true if ConfirmNow property is set</returns>
        public Boolean IsSetConfirmNow()
        {
            return this.confirmNowField.HasValue;

        }





        /// <summary>
        /// Gets and sets the OrderReferenceAttributes property.
        /// </summary>
        [XmlElementAttribute(ElementName = "OrderReferenceAttributes")]
        public OrderReferenceAttributes OrderReferenceAttributes
        {
            get { return this.orderReferenceAttributesField; }
            set { this.orderReferenceAttributesField = value; }
        }



        /// <summary>
        /// Sets the OrderReferenceAttributes property
        /// </summary>
        /// <param name="orderReferenceAttributes">OrderReferenceAttributes property</param>
        /// <returns>this instance</returns>
        public CreateOrderReferenceForIdRequest WithOrderReferenceAttributes(OrderReferenceAttributes orderReferenceAttributes)
        {
            this.orderReferenceAttributesField = orderReferenceAttributes;
            return this;
        }



        /// <summary>
        /// Checks if OrderReferenceAttributes property is set
        /// </summary>
        /// <returns>true if OrderReferenceAttributes property is set</returns>
        public Boolean IsSetOrderReferenceAttributes()
        {
            return this.orderReferenceAttributesField != null;
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
        public CreateOrderReferenceForIdRequest WithMWSAuthToken(String mwsAuthToken)
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