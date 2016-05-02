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
    public class CreateOrderReferenceForIdResponse
    {

        private CreateOrderReferenceForIdResult createOrderReferenceForIdResultField;
        private ResponseMetadata responseMetadataField;

        /// <summary>
        /// Gets and sets the CreateOrderReferenceForIdResult property.
        /// </summary>
        [XmlElementAttribute(ElementName = "CreateOrderReferenceForIdResult")]
        public CreateOrderReferenceForIdResult CreateOrderReferenceForIdResult
        {
            get { return this.createOrderReferenceForIdResultField; }
            set { this.createOrderReferenceForIdResultField = value; }
        }



        /// <summary>
        /// Sets the CreateOrderReferenceForIdResult property
        /// </summary>
        /// <param name="createOrderReferenceForIdResult">CreateOrderReferenceForIdResult property</param>
        /// <returns>this instance</returns>
        public CreateOrderReferenceForIdResponse WithCreateOrderReferenceForIdResult(CreateOrderReferenceForIdResult createOrderReferenceForIdResult)
        {
            this.createOrderReferenceForIdResultField = createOrderReferenceForIdResult;
            return this;
        }



        /// <summary>
        /// Checks if CreateOrderReferenceForIdResult property is set
        /// </summary>
        /// <returns>true if CreateOrderReferenceForIdResult property is set</returns>
        public Boolean IsSetCreateOrderReferenceForIdResult()
        {
            return this.createOrderReferenceForIdResultField != null;
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
        public CreateOrderReferenceForIdResponse WithResponseMetadata(ResponseMetadata responseMetadata)
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
            xml.Append("<CreateOrderReferenceForIdResponse xmlns=\"http://mws.amazonservices.com/schema/OffAmazonPayments/2013-01-01\">");
            if (IsSetCreateOrderReferenceForIdResult())
            {
                CreateOrderReferenceForIdResult createOrderReferenceForIdResult = this.CreateOrderReferenceForIdResult;
                xml.Append("<CreateOrderReferenceForIdResult>");
                xml.Append(createOrderReferenceForIdResult.ToXMLFragment());
                xml.Append("</CreateOrderReferenceForIdResult>");
            }
            if (IsSetResponseMetadata())
            {
                ResponseMetadata responseMetadata = this.ResponseMetadata;
                xml.Append("<ResponseMetadata>");
                xml.Append(responseMetadata.ToXMLFragment());
                xml.Append("</ResponseMetadata>");
            }
            xml.Append("</CreateOrderReferenceForIdResponse>");
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