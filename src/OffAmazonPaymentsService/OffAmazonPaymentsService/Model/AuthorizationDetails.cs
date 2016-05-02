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
    public class AuthorizationDetails
    {
    
        private String amazonAuthorizationIdField;

        private String authorizationReferenceIdField;

        private Address authorizationBillingAddress;

        private String sellerAuthorizationNoteField;

        private  Price authorizationAmountField;
        private  Price capturedAmountField;
        private  Price authorizationFeeField;
        private  IdList idListField;
        private DateTime? creationTimestampField;

        private DateTime? expirationTimestampField;

        private  Status authorizationStatusField;
        private  OrderItemCategories orderItemCategoriesField;
        private Boolean? captureNowField;

        private String softDescriptorField;

        private String addressVerificationCodeField;

        private Boolean? softDeclineField;

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
        public AuthorizationDetails WithAmazonAuthorizationId(String amazonAuthorizationId)
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
        public AuthorizationDetails WithAuthorizationReferenceId(String authorizationReferenceId)
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
        /// Gets ands sets the AuthorizationBillingAddress property is set
        /// </summary>
        [XmlElementAttribute(ElementName = "AuthorizationBillingAddress")]
        public Address AuthorizationBillingAddress
        {
            get { return this.authorizationBillingAddress ; }
            set { this.authorizationBillingAddress= value; }
        }

        /// <summary>
        /// Sets the AuthorizationBillingAddress property
        /// </summary>
        /// <param name="authorizationBillingAddress">AuthorizationBillingAddress property</param>
        /// <returns>this instance</returns>
        public AuthorizationDetails WithAuthorizationBillingAddress(Address authorizationBillingAddress)
        {
            this.authorizationBillingAddress = authorizationBillingAddress;
            return this;
        }

        /// <summary>
        /// Checks if AuthorizationBillingAddress property is set
        /// </summary>
        /// <returns>true if AuthorizationBillingAddress property is set</returns>
        public Boolean IsSetAuthorizationBillingAddress()
        {
            return this.authorizationBillingAddress != null;

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
        public AuthorizationDetails WithSellerAuthorizationNote(String sellerAuthorizationNote)
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
            return  this.sellerAuthorizationNoteField != null;

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
        public AuthorizationDetails WithAuthorizationAmount(Price authorizationAmount)
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
        /// Gets and sets the CapturedAmount property.
        /// </summary>
        [XmlElementAttribute(ElementName = "CapturedAmount")]
        public Price CapturedAmount
        {
            get { return this.capturedAmountField ; }
            set { this.capturedAmountField = value; }
        }



        /// <summary>
        /// Sets the CapturedAmount property
        /// </summary>
        /// <param name="capturedAmount">CapturedAmount property</param>
        /// <returns>this instance</returns>
        public AuthorizationDetails WithCapturedAmount(Price capturedAmount)
        {
            this.capturedAmountField = capturedAmount;
            return this;
        }



        /// <summary>
        /// Checks if CapturedAmount property is set
        /// </summary>
        /// <returns>true if CapturedAmount property is set</returns>
        public Boolean IsSetCapturedAmount()
        {
            return this.capturedAmountField != null;
        }



        /// <summary>
        /// Gets and sets the AuthorizationFee property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AuthorizationFee")]
        public Price AuthorizationFee
        {
            get { return this.authorizationFeeField ; }
            set { this.authorizationFeeField = value; }
        }



        /// <summary>
        /// Sets the AuthorizationFee property
        /// </summary>
        /// <param name="authorizationFee">AuthorizationFee property</param>
        /// <returns>this instance</returns>
        public AuthorizationDetails WithAuthorizationFee(Price authorizationFee)
        {
            this.authorizationFeeField = authorizationFee;
            return this;
        }



        /// <summary>
        /// Checks if AuthorizationFee property is set
        /// </summary>
        /// <returns>true if AuthorizationFee property is set</returns>
        public Boolean IsSetAuthorizationFee()
        {
            return this.authorizationFeeField != null;
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
        public AuthorizationDetails WithIdList(IdList idList)
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
        public AuthorizationDetails WithCreationTimestamp(DateTime creationTimestamp)
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
        public AuthorizationDetails WithExpirationTimestamp(DateTime expirationTimestamp)
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
        /// Gets and sets the AuthorizationStatus property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AuthorizationStatus")]
        public Status AuthorizationStatus
        {
            get { return this.authorizationStatusField ; }
            set { this.authorizationStatusField = value; }
        }



        /// <summary>
        /// Sets the AuthorizationStatus property
        /// </summary>
        /// <param name="authorizationStatus">AuthorizationStatus property</param>
        /// <returns>this instance</returns>
        public AuthorizationDetails WithAuthorizationStatus(Status authorizationStatus)
        {
            this.authorizationStatusField = authorizationStatus;
            return this;
        }



        /// <summary>
        /// Checks if AuthorizationStatus property is set
        /// </summary>
        /// <returns>true if AuthorizationStatus property is set</returns>
        public Boolean IsSetAuthorizationStatus()
        {
            return this.authorizationStatusField != null;
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
        public AuthorizationDetails WithOrderItemCategories(OrderItemCategories orderItemCategories)
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
        public AuthorizationDetails WithCaptureNow(Boolean captureNow)
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
        public AuthorizationDetails WithSoftDescriptor(String softDescriptor)
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
        /// Gets and sets the AddressVerificationCode property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AddressVerificationCode")]
        public String AddressVerificationCode
        {
            get { return this.addressVerificationCodeField ; }
            set { this.addressVerificationCodeField= value; }
        }



        /// <summary>
        /// Sets the AddressVerificationCode property
        /// </summary>
        /// <param name="addressVerificationCode">AddressVerificationCode property</param>
        /// <returns>this instance</returns>
        public AuthorizationDetails WithAddressVerificationCode(String addressVerificationCode)
        {
            this.addressVerificationCodeField = addressVerificationCode;
            return this;
        }



        /// <summary>
        /// Checks if AddressVerificationCode property is set
        /// </summary>
        /// <returns>true if AddressVerificationCode property is set</returns>
        public Boolean IsSetAddressVerificationCode()
        {
            return  this.addressVerificationCodeField != null;

        }


        /// <summary>
        /// Gets and sets the SoftDecline property.
        /// </summary>
        [XmlElementAttribute(ElementName = "SoftDecline")]
        public Boolean SoftDecline
        {
            get { return this.softDeclineField.GetValueOrDefault(); }
            set { this.softDeclineField = value; }
        }



        /// <summary>
        /// Sets the SoftDecline property
        /// </summary>
        /// <param name="softDecline">SoftDecline property</param>
        /// <returns>this instance</returns>
        public AuthorizationDetails WithSoftDecline(Boolean softDecline)
        {
            this.softDeclineField = softDecline;
            return this;
        }



        /// <summary>
        /// Checks if SoftDecline property is set
        /// </summary>
        /// <returns>true if SoftDecline property is set</returns>
        public Boolean IsSetSoftDecline()
        {
            return this.softDeclineField != null;

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
            if (IsSetAmazonAuthorizationId()) {
                xml.Append("<AmazonAuthorizationId>");
                xml.Append(this.AmazonAuthorizationId);
                xml.Append("</AmazonAuthorizationId>");
            }
            if (IsSetAuthorizationReferenceId()) {
                xml.Append("<AuthorizationReferenceId>");
                xml.Append(this.AuthorizationReferenceId);
                xml.Append("</AuthorizationReferenceId>");
            }
            if (IsSetAuthorizationBillingAddress()) {
                xml.Append("<AuthorizationBillingAddress>");
                xml.Append(this.AuthorizationBillingAddress);
                xml.Append("</AuthorizationBillingAddress>");
            }
            if (IsSetSellerAuthorizationNote()) {
                xml.Append("<SellerAuthorizationNote>");
                xml.Append(EscapeXML(this.SellerAuthorizationNote));
                xml.Append("</SellerAuthorizationNote>");
            }
            if (IsSetAuthorizationAmount()) {
                Price  authorizationAmountObj = this.AuthorizationAmount;
                xml.Append("<AuthorizationAmount>");
                xml.Append(authorizationAmountObj.ToXMLFragment());
                xml.Append("</AuthorizationAmount>");
            } 
            if (IsSetCapturedAmount()) {
                Price  capturedAmountObj = this.CapturedAmount;
                xml.Append("<CapturedAmount>");
                xml.Append(capturedAmountObj.ToXMLFragment());
                xml.Append("</CapturedAmount>");
            } 
            if (IsSetAuthorizationFee()) {
                Price  authorizationFeeObj = this.AuthorizationFee;
                xml.Append("<AuthorizationFee>");
                xml.Append(authorizationFeeObj.ToXMLFragment());
                xml.Append("</AuthorizationFee>");
            } 
            if (IsSetIdList()) {
                IdList  idListObj = this.IdList;
                xml.Append("<IdList>");
                xml.Append(idListObj.ToXMLFragment());
                xml.Append("</IdList>");
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
            if (IsSetAuthorizationStatus()) {
                Status  authorizationStatusObj = this.AuthorizationStatus;
                xml.Append("<AuthorizationStatus>");
                xml.Append(authorizationStatusObj.ToXMLFragment());
                xml.Append("</AuthorizationStatus>");
            } 
            if (IsSetOrderItemCategories()) {
                OrderItemCategories  orderItemCategoriesObj = this.OrderItemCategories;
                xml.Append("<OrderItemCategories>");
                xml.Append(orderItemCategoriesObj.ToXMLFragment());
                xml.Append("</OrderItemCategories>");
            } 
            if (IsSetCaptureNow()) {
                xml.Append("<CaptureNow>");
                xml.Append(this.CaptureNow);
                xml.Append("</CaptureNow>");
            }
            if (IsSetSoftDescriptor()) {
                xml.Append("<SoftDescriptor>");
                xml.Append(EscapeXML(this.SoftDescriptor));
                xml.Append("</SoftDescriptor>");
            }
            if (IsSetAddressVerificationCode()) {
                xml.Append("<AddressVerificationCode>");
                xml.Append(EscapeXML(this.AddressVerificationCode));
                xml.Append("</AddressVerificationCode>");
            }
            if (IsSetSoftDecline())
            {
                xml.Append("<SoftDecline>");
                xml.Append(this.SoftDecline);
                xml.Append("</SoftDecline>");
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