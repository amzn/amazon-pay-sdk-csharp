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
    public class OrderReferenceDetails
    {
    
        private String amazonOrderReferenceIdField;
        private String orderLanguage;
        private  Buyer buyerField;
        private  OrderTotal orderTotalField;
        private String sellerNoteField;
        private String platformIdField;

        private  Destination destinationField;
        private BillingAddress billingAddressField;
        private ReleaseEnvironment? releaseEnvironmentField;

        private  SellerOrderAttributes sellerOrderAttributesField;
        private  OrderReferenceStatus orderReferenceStatusField;
        private  Constraints constraintsField;
        private DateTime? creationTimestampField;

        private DateTime? expirationTimestampField;

        private ParentDetails parentDetailsField;
        
        private  IdList idListField;

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
        public OrderReferenceDetails WithAmazonOrderReferenceId(String amazonOrderReferenceId)
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
        /// Gets and sets the OrderLanguage property.
        /// </summary>
        [XmlElementAttribute(ElementName = "OrderLanguage")]
        public String OrderLanguage
        {
            get { return this.orderLanguage; }
            set { this.orderLanguage = value; }
        }



        /// <summary>
        /// Sets the OrderLanguage property
        /// </summary>
        /// <param name="OrderLanguage">OrderLanguage property</param>
        /// <returns>this instance</returns>
        public OrderReferenceDetails WithOrderLanguage(String orderLanguage)
        {
            this.orderLanguage = orderLanguage;
            return this;
        }



        /// <summary>
        /// Checks if OrderLanguage property is set
        /// </summary>
        /// <returns>true if OrderLanguage property is set</returns>
        public Boolean IsSetOrderLanguage()
        {
            return this.orderLanguage != null;
        }
        

        /// <summary>
        /// Gets and sets the Buyer property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Buyer")]
        public Buyer Buyer
        {
            get { return this.buyerField ; }
            set { this.buyerField = value; }
        }



        /// <summary>
        /// Sets the Buyer property
        /// </summary>
        /// <param name="buyer">Buyer property</param>
        /// <returns>this instance</returns>
        public OrderReferenceDetails WithBuyer(Buyer buyer)
        {
            this.buyerField = buyer;
            return this;
        }



        /// <summary>
        /// Checks if Buyer property is set
        /// </summary>
        /// <returns>true if Buyer property is set</returns>
        public Boolean IsSetBuyer()
        {
            return this.buyerField != null;
        }



        /// <summary>
        /// Gets and sets the OrderTotal property.
        /// </summary>
        [XmlElementAttribute(ElementName = "OrderTotal")]
        public OrderTotal OrderTotal
        {
            get { return this.orderTotalField ; }
            set { this.orderTotalField = value; }
        }



        /// <summary>
        /// Sets the OrderTotal property
        /// </summary>
        /// <param name="orderTotal">OrderTotal property</param>
        /// <returns>this instance</returns>
        public OrderReferenceDetails WithOrderTotal(OrderTotal orderTotal)
        {
            this.orderTotalField = orderTotal;
            return this;
        }



        /// <summary>
        /// Checks if OrderTotal property is set
        /// </summary>
        /// <returns>true if OrderTotal property is set</returns>
        public Boolean IsSetOrderTotal()
        {
            return this.orderTotalField != null;
        }



        /// <summary>
        /// Gets and sets the SellerNote property.
        /// </summary>
        [XmlElementAttribute(ElementName = "SellerNote")]
        public String SellerNote
        {
            get { return this.sellerNoteField ; }
            set { this.sellerNoteField= value; }
        }



        /// <summary>
        /// Sets the SellerNote property
        /// </summary>
        /// <param name="sellerNote">SellerNote property</param>
        /// <returns>this instance</returns>
        public OrderReferenceDetails WithSellerNote(String sellerNote)
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
        public OrderReferenceDetails WithPlatformId(String platformId)
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
        /// Gets and sets the Destination property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Destination")]
        public Destination Destination
        {
            get { return this.destinationField ; }
            set { this.destinationField = value; }
        }



        /// <summary>
        /// Sets the Destination property
        /// </summary>
        /// <param name="destination">Destination property</param>
        /// <returns>this instance</returns>
        public OrderReferenceDetails WithDestination(Destination destination)
        {
            this.destinationField = destination;
            return this;
        }



        /// <summary>
        /// Checks if Destination property is set
        /// </summary>
        /// <returns>true if Destination property is set</returns>
        public Boolean IsSetDestination()
        {
            return this.destinationField != null;
        }


        
        /// <summary>
        /// Gets and sets the BillingAddress property.
        /// </summary>
        [XmlElementAttribute(ElementName = "BillingAddress")]
        public BillingAddress BillingAddress
        {
            get { return this.billingAddressField; }
            set { this.billingAddressField = value; }
        }



        /// <summary>
        /// Sets the BillingAddress property
        /// </summary>
        /// <param name="billingAddress">BillingAddress property</param>
        /// <returns>this instance</returns>
        public OrderReferenceDetails WithBillingAddress(BillingAddress billingAddress)
        {
            this.billingAddressField = billingAddress;
            return this;
        }



        /// <summary>
        /// Checks if BillingAddress property is set
        /// </summary>
        /// <returns>true if BillingAddress property is set</returns>
        public Boolean IsSetBillingAddress()
        {
            return this.billingAddressField != null;
        }



        /// <summary>
        /// Gets and sets the ReleaseEnvironment property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ReleaseEnvironment")]
        public ReleaseEnvironment ReleaseEnvironment
        {
            get { return this.releaseEnvironmentField.GetValueOrDefault() ; }
            set { this.releaseEnvironmentField= value; }
        }



        /// <summary>
        /// Sets the ReleaseEnvironment property
        /// </summary>
        /// <param name="releaseEnvironment">ReleaseEnvironment property</param>
        /// <returns>this instance</returns>
        public OrderReferenceDetails WithReleaseEnvironment(ReleaseEnvironment releaseEnvironment)
        {
            this.releaseEnvironmentField = releaseEnvironment;
            return this;
        }



        /// <summary>
        /// Checks if ReleaseEnvironment property is set
        /// </summary>
        /// <returns>true if ReleaseEnvironment property is set</returns>
        public Boolean IsSetReleaseEnvironment()
        {
            return this.releaseEnvironmentField.HasValue;

        }





        /// <summary>
        /// Gets and sets the SellerOrderAttributes property.
        /// </summary>
        [XmlElementAttribute(ElementName = "SellerOrderAttributes")]
        public SellerOrderAttributes SellerOrderAttributes
        {
            get { return this.sellerOrderAttributesField ; }
            set { this.sellerOrderAttributesField = value; }
        }



        /// <summary>
        /// Sets the SellerOrderAttributes property
        /// </summary>
        /// <param name="sellerOrderAttributes">SellerOrderAttributes property</param>
        /// <returns>this instance</returns>
        public OrderReferenceDetails WithSellerOrderAttributes(SellerOrderAttributes sellerOrderAttributes)
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
        /// Gets and sets the OrderReferenceStatus property.
        /// </summary>
        [XmlElementAttribute(ElementName = "OrderReferenceStatus")]
        public OrderReferenceStatus OrderReferenceStatus
        {
            get { return this.orderReferenceStatusField ; }
            set { this.orderReferenceStatusField = value; }
        }



        /// <summary>
        /// Sets the OrderReferenceStatus property
        /// </summary>
        /// <param name="orderReferenceStatus">OrderReferenceStatus property</param>
        /// <returns>this instance</returns>
        public OrderReferenceDetails WithOrderReferenceStatus(OrderReferenceStatus orderReferenceStatus)
        {
            this.orderReferenceStatusField = orderReferenceStatus;
            return this;
        }



        /// <summary>
        /// Checks if OrderReferenceStatus property is set
        /// </summary>
        /// <returns>true if OrderReferenceStatus property is set</returns>
        public Boolean IsSetOrderReferenceStatus()
        {
            return this.orderReferenceStatusField != null;
        }



        /// <summary>
        /// Gets and sets the Constraints property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Constraints")]
        public Constraints Constraints
        {
            get { return this.constraintsField ; }
            set { this.constraintsField = value; }
        }



        /// <summary>
        /// Sets the Constraints property
        /// </summary>
        /// <param name="constraints">Constraints property</param>
        /// <returns>this instance</returns>
        public OrderReferenceDetails WithConstraints(Constraints constraints)
        {
            this.constraintsField = constraints;
            return this;
        }



        /// <summary>
        /// Checks if Constraints property is set
        /// </summary>
        /// <returns>true if Constraints property is set</returns>
        public Boolean IsSetConstraints()
        {
            return this.constraintsField != null;
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
        public OrderReferenceDetails WithCreationTimestamp(DateTime creationTimestamp)
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
        /// Gets and sets the ExpirationTimestamp property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ExpirationTimestamp")]
        public DateTime ExpirationTimestamp
        {
            get { return this.expirationTimestampField.GetValueOrDefault() ; }
            set { this.expirationTimestampField= value; }
        }



        /// <summary>
        /// Sets the ExpirationTimestamp property
        /// </summary>
        /// <param name="expirationTimestamp">ExpirationTimestamp property</param>
        /// <returns>this instance</returns>
        public OrderReferenceDetails WithExpirationTimestamp(DateTime expirationTimestamp)
        {
            this.expirationTimestampField = expirationTimestamp;
            return this;
        }



        /// <summary>
        /// Checks if ExpirationTimestamp property is set
        /// </summary>
        /// <returns>true if ExpirationTimestamp property is set</returns>
        public Boolean IsSetExpirationTimestamp()
        {
            return  this.expirationTimestampField.HasValue;

        }





        /// <summary>
        /// Gets and sets the ParentDetails property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ParentDetails")]
        public ParentDetails ParentDetails
        {
            get { return this.parentDetailsField; }
            set { this.parentDetailsField = value; }
        }



        /// <summary>
        /// Sets the ParentDetails property
        /// </summary>
        /// <param name="parentDetails">ParentDetails property</param>
        /// <returns>this instance</returns>
        public OrderReferenceDetails WithParentDetails(ParentDetails parentDetails)
        {
            this.parentDetailsField = parentDetails;
            return this;
        }



        /// <summary>
        /// Checks if ParentDetails property is set
        /// </summary>
        /// <returns>true if ParentDetails property is set</returns>
        public Boolean IsSetParentDetails()
        {
            return this.parentDetailsField != null;
        }



        /// <summary>
        /// Gets and sets the IdList property.
        /// </summary>
        [XmlElementAttribute(ElementName = "IdList")]
        public IdList IdList
        {
            get { return this.idListField ; }
            set { this.idListField = value; }
        }



        /// <summary>
        /// Sets the IdList property
        /// </summary>
        /// <param name="idList">IdList property</param>
        /// <returns>this instance</returns>
        public OrderReferenceDetails WithIdList(IdList idList)
        {
            this.idListField = idList;
            return this;
        }



        /// <summary>
        /// Checks if IdList property is set
        /// </summary>
        /// <returns>true if IdList property is set</returns>
        public Boolean IsSetIdList()
        {
            return this.idListField != null;
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
            if (IsSetAmazonOrderReferenceId()) {
                xml.Append("<AmazonOrderReferenceId>");
                xml.Append(EscapeXML(this.AmazonOrderReferenceId));
                xml.Append("</AmazonOrderReferenceId>");
            }
            if (IsSetOrderLanguage())
            {
                xml.Append("<OrderLanguage>");
                xml.Append(EscapeXML(this.OrderLanguage));
                xml.Append("</OrderLanguage>");
            }
            if (IsSetBuyer()) {
                Buyer  buyerObj = this.Buyer;
                xml.Append("<Buyer>");
                xml.Append(buyerObj.ToXMLFragment());
                xml.Append("</Buyer>");
            } 
            if (IsSetOrderTotal()) {
                OrderTotal  orderTotalObj = this.OrderTotal;
                xml.Append("<OrderTotal>");
                xml.Append(orderTotalObj.ToXMLFragment());
                xml.Append("</OrderTotal>");
            } 
            if (IsSetSellerNote()) {
                xml.Append("<SellerNote>");
                xml.Append(this.SellerNote);
                xml.Append("</SellerNote>");
            }
            if (IsSetPlatformId()) {
                xml.Append("<PlatformId>");
                xml.Append(EscapeXML(this.PlatformId));
                xml.Append("</PlatformId>");
            }
            if (IsSetDestination()) {
                Destination  destinationObj = this.Destination;
                xml.Append("<Destination>");
                xml.Append(destinationObj.ToXMLFragment());
                xml.Append("</Destination>");
            }
            if (IsSetBillingAddress())
            {
                BillingAddress billingAddressObj = this.BillingAddress;
                xml.Append("<BillingAddress>");
                xml.Append(billingAddressObj.ToXMLFragment());
                xml.Append("</BillingAddress>");
            } 
            if (IsSetReleaseEnvironment()) {
                xml.Append("<ReleaseEnvironment>");
                xml.Append(this.ReleaseEnvironment);
                xml.Append("</ReleaseEnvironment>");
            }
            if (IsSetSellerOrderAttributes()) {
                SellerOrderAttributes  sellerOrderAttributesObj = this.SellerOrderAttributes;
                xml.Append("<SellerOrderAttributes>");
                xml.Append(sellerOrderAttributesObj.ToXMLFragment());
                xml.Append("</SellerOrderAttributes>");
            } 
            if (IsSetOrderReferenceStatus()) {
                OrderReferenceStatus  orderReferenceStatusObj = this.OrderReferenceStatus;
                xml.Append("<OrderReferenceStatus>");
                xml.Append(orderReferenceStatusObj.ToXMLFragment());
                xml.Append("</OrderReferenceStatus>");
            } 
            if (IsSetConstraints()) {
                Constraints  constraintsObj = this.Constraints;
                xml.Append("<Constraints>");
                xml.Append(constraintsObj.ToXMLFragment());
                xml.Append("</Constraints>");
            } 
            if (IsSetCreationTimestamp()) {
                xml.Append("<CreationTimestamp>");
                xml.Append(this.CreationTimestamp);
                xml.Append("</CreationTimestamp>");
            }
            if (IsSetExpirationTimestamp()) {
                xml.Append("<ExpirationTimestamp>");
                xml.Append(this.ExpirationTimestamp);
                xml.Append("</ExpirationTimestamp>");
            }
            if (IsSetParentDetails()) {
                ParentDetails parentDetailsObj = this.ParentDetails;
                xml.Append("<ParentDetails>");
                xml.Append(parentDetailsObj.ToXMLFragment());
                xml.Append("</ParentDetails>");
            }
            if (IsSetIdList()) {
                IdList  idListObj = this.IdList;
                xml.Append("<IdList>");
                xml.Append(idListObj.ToXMLFragment());
                xml.Append("</IdList>");
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