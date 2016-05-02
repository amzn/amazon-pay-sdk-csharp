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
    public class BillingAgreementAttributes
    {

        private String platformIdField;

        private String sellerNoteField;

        private SellerBillingAgreementAttributes sellerBillingAgreementAttributesField;

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
        public BillingAgreementAttributes WithPlatformId(String platformId)
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
        public BillingAgreementAttributes WithSellerNote(String sellerNote)
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
        /// Gets and sets the SellerBillingAgreementAttributes property.
        /// </summary>
        [XmlElementAttribute(ElementName = "SellerBillingAgreementAttributes")]
        public SellerBillingAgreementAttributes SellerBillingAgreementAttributes
        {
            get { return this.sellerBillingAgreementAttributesField; }
            set { this.sellerBillingAgreementAttributesField = value; }
        }



        /// <summary>
        /// Sets the SellerBillingAgreementAttributes property
        /// </summary>
        /// <param name="sellerBillingAgreementAttributes">SellerBillingAgreementAttributes property</param>
        /// <returns>this instance</returns>
        public BillingAgreementAttributes WithSellerBillingAgreementAttributes(SellerBillingAgreementAttributes sellerBillingAgreementAttributes)
        {
            this.sellerBillingAgreementAttributesField = sellerBillingAgreementAttributes;
            return this;
        }



        /// <summary>
        /// Checks if SellerBillingAgreementAttributes property is set
        /// </summary>
        /// <returns>true if SellerBillingAgreementAttributes property is set</returns>
        public Boolean IsSetSellerBillingAgreementAttributes()
        {
            return this.sellerBillingAgreementAttributesField != null;
        }





        /// <summary>
        /// XML fragment representation of this object
        /// </summary>
        /// <returns>XML fragment for this object.</returns>
        /// <remarks>
        /// Name for outer tag expected to be set by calling method. 
        /// This fragment returns inner properties representation only
        /// </remarks>


        protected internal String ToXMLFragment()
        {
            StringBuilder xml = new StringBuilder();
            if (IsSetPlatformId())
            {
                xml.Append("<PlatformId>");
                xml.Append(EscapeXML(this.PlatformId));
                xml.Append("</PlatformId>");
            }
            if (IsSetSellerNote())
            {
                xml.Append("<SellerNote>");
                xml.Append(EscapeXML(this.SellerNote));
                xml.Append("</SellerNote>");
            }
            if (IsSetSellerBillingAgreementAttributes())
            {
                SellerBillingAgreementAttributes sellerBillingAgreementAttributesObj = this.SellerBillingAgreementAttributes;
                xml.Append("<SellerBillingAgreementAttributes>");
                xml.Append(sellerBillingAgreementAttributesObj.ToXMLFragment());
                xml.Append("</SellerBillingAgreementAttributes>");
            }
            return xml.ToString();
        }

        /**
         * 
         * Escape XML special characters
         */
        private String EscapeXML(String str)
        {
            if (str == null)
                return "null";
            StringBuilder sb = new StringBuilder();
            foreach (Char c in str)
            {
                switch (c)
                {
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