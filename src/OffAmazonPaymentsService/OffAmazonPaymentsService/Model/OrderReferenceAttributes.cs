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
    public class OrderReferenceAttributes
    {
    
        private  OrderTotal orderTotalField;
        private String platformId;
        private String sellerNoteField;

        private  SellerOrderAttributes sellerOrderAttributesField;

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
        public OrderReferenceAttributes WithOrderTotal(OrderTotal orderTotal)
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
        /// Gets and sets the PlatformId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "PlatformId")]
        public String PlatformId
        {
            get { return this.platformId ; }
            set { this.platformId= value; }
        }


        /// <summary>
        /// Sets the SellerNote property
        /// </summary>
        /// <param name="platformId">PlatformId property</param>
        /// <returns>this instance</returns>
        public OrderReferenceAttributes WithPlatformId(String platformId)
        {
            this.platformId = platformId;
            return this;
        }



        /// <summary>
        /// Checks if PlatformId property is set
        /// </summary>
        /// <returns>true if PlatformId property is set</returns>
        public Boolean IsSetPlatformId()
        {
            return this.platformId != null;

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
        public OrderReferenceAttributes WithSellerNote(String sellerNote)
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
        public OrderReferenceAttributes WithSellerOrderAttributes(SellerOrderAttributes sellerOrderAttributes)
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
        /// XML fragment representation of this object
        /// </summary>
        /// <returns>XML fragment for this object.</returns>
        /// <remarks>
        /// Name for outer tag expected to be set by calling method. 
        /// This fragment returns inner properties representation only
        /// </remarks>


        protected internal String ToXMLFragment() {
            StringBuilder xml = new StringBuilder();
            if (IsSetOrderTotal()) {
                OrderTotal  orderTotalObj = this.OrderTotal;
                xml.Append("<OrderTotal>");
                xml.Append(orderTotalObj.ToXMLFragment());
                xml.Append("</OrderTotal>");
            } 
            if (IsSetPlatformId()) {
                xml.Append("<PlatformId>");
                xml.Append(this.platformId);
                xml.Append("</PlatformId>");
            }
            if (IsSetSellerNote()) {
                xml.Append("<SellerNote>");
                xml.Append(this.SellerNote);
                xml.Append("</SellerNote>");
            }
            if (IsSetSellerOrderAttributes()) {
                SellerOrderAttributes  sellerOrderAttributesObj = this.SellerOrderAttributes;
                xml.Append("<SellerOrderAttributes>");
                xml.Append(sellerOrderAttributesObj.ToXMLFragment());
                xml.Append("</SellerOrderAttributes>");
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