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
    public class ConfirmBillingAgreementResponse
    {

        private ConfirmBillingAgreementResult confirmBillingAgreementResultField;
        private ResponseMetadata responseMetadataField;

        /// <summary>
        /// Gets and sets the ConfirmBillingAgreementResult property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ConfirmBillingAgreementResult")]
        public ConfirmBillingAgreementResult ConfirmBillingAgreementResult
        {
            get { return this.confirmBillingAgreementResultField; }
            set { this.confirmBillingAgreementResultField = value; }
        }



        /// <summary>
        /// Sets the ConfirmBillingAgreementResult property
        /// </summary>
        /// <param name="confirmBillingAgreementResult">ConfirmBillingAgreementResult property</param>
        /// <returns>this instance</returns>
        public ConfirmBillingAgreementResponse WithConfirmBillingAgreementResult(ConfirmBillingAgreementResult confirmBillingAgreementResult)
        {
            this.confirmBillingAgreementResultField = confirmBillingAgreementResult;
            return this;
        }



        /// <summary>
        /// Checks if ConfirmBillingAgreementResult property is set
        /// </summary>
        /// <returns>true if ConfirmBillingAgreementResult property is set</returns>
        public Boolean IsSetConfirmBillingAgreementResult()
        {
            return this.confirmBillingAgreementResultField != null;
        }



        /// <summary>
        /// Gets and sets the ResponseMetadata property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ResponseMetadata")]
        public ResponseMetadata ResponseMetadata
        {
            get { return this.responseMetadataField; }
            set { this.responseMetadataField = value; }
        }



        /// <summary>
        /// Sets the ResponseMetadata property
        /// </summary>
        /// <param name="responseMetadata">ResponseMetadata property</param>
        /// <returns>this instance</returns>
        public ConfirmBillingAgreementResponse WithResponseMetadata(ResponseMetadata responseMetadata)
        {
            this.responseMetadataField = responseMetadata;
            return this;
        }



        /// <summary>
        /// Checks if ResponseMetadata property is set
        /// </summary>
        /// <returns>true if ResponseMetadata property is set</returns>
        public Boolean IsSetResponseMetadata()
        {
            return this.responseMetadataField != null;
        }





        /// <summary>
        /// XML Representation for this object
        /// </summary>
        /// <returns>XML String</returns>

        public String ToXML()
        {
            StringBuilder xml = new StringBuilder();
            xml.Append("<ConfirmBillingAgreementResponse xmlns=\"http://mws.amazonservices.com/schema/OffAmazonPayments/2013-01-01\">");
            if (IsSetConfirmBillingAgreementResult())
            {
                ConfirmBillingAgreementResult confirmBillingAgreementResult = this.ConfirmBillingAgreementResult;
                xml.Append("<ConfirmBillingAgreementResult>");
                xml.Append(confirmBillingAgreementResult.ToXMLFragment());
                xml.Append("</ConfirmBillingAgreementResult>");
            }
            if (IsSetResponseMetadata())
            {
                ResponseMetadata responseMetadata = this.ResponseMetadata;
                xml.Append("<ResponseMetadata>");
                xml.Append(responseMetadata.ToXMLFragment());
                xml.Append("</ResponseMetadata>");
            }
            xml.Append("</ConfirmBillingAgreementResponse>");
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