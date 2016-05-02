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
    public class GetOrderReferenceDetailsResponse
    {
    
        private  GetOrderReferenceDetailsResult getOrderReferenceDetailsResultField;
        private  ResponseMetadata responseMetadataField;

        /// <summary>
        /// Gets and sets the GetOrderReferenceDetailsResult property.
        /// </summary>
        [XmlElementAttribute(ElementName = "GetOrderReferenceDetailsResult")]
        public GetOrderReferenceDetailsResult GetOrderReferenceDetailsResult
        {
            get { return this.getOrderReferenceDetailsResultField ; }
            set { this.getOrderReferenceDetailsResultField = value; }
        }



        /// <summary>
        /// Sets the GetOrderReferenceDetailsResult property
        /// </summary>
        /// <param name="getOrderReferenceDetailsResult">GetOrderReferenceDetailsResult property</param>
        /// <returns>this instance</returns>
        public GetOrderReferenceDetailsResponse WithGetOrderReferenceDetailsResult(GetOrderReferenceDetailsResult getOrderReferenceDetailsResult)
        {
            this.getOrderReferenceDetailsResultField = getOrderReferenceDetailsResult;
            return this;
        }



        /// <summary>
        /// Checks if GetOrderReferenceDetailsResult property is set
        /// </summary>
        /// <returns>true if GetOrderReferenceDetailsResult property is set</returns>
        public Boolean IsSetGetOrderReferenceDetailsResult()
        {
            return this.getOrderReferenceDetailsResultField != null;
        }



        /// <summary>
        /// Gets and sets the ResponseMetadata property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ResponseMetadata")]
        public ResponseMetadata ResponseMetadata
        {
            get { return this.responseMetadataField ; }
            set { this.responseMetadataField = value; }
        }



        /// <summary>
        /// Sets the ResponseMetadata property
        /// </summary>
        /// <param name="responseMetadata">ResponseMetadata property</param>
        /// <returns>this instance</returns>
        public GetOrderReferenceDetailsResponse WithResponseMetadata(ResponseMetadata responseMetadata)
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

        public String ToXML() {
            StringBuilder xml = new StringBuilder();
            xml.Append("<GetOrderReferenceDetailsResponse xmlns=\"http://mws.amazonservices.com/schema/OffAmazonPayments/2013-01-01\">");
            if (IsSetGetOrderReferenceDetailsResult()) {
                GetOrderReferenceDetailsResult  getOrderReferenceDetailsResult = this.GetOrderReferenceDetailsResult;
                xml.Append("<GetOrderReferenceDetailsResult>");
                xml.Append(getOrderReferenceDetailsResult.ToXMLFragment());
                xml.Append("</GetOrderReferenceDetailsResult>");
            } 
            if (IsSetResponseMetadata()) {
                ResponseMetadata  responseMetadata = this.ResponseMetadata;
                xml.Append("<ResponseMetadata>");
                xml.Append(responseMetadata.ToXMLFragment());
                xml.Append("</ResponseMetadata>");
            } 
            xml.Append("</GetOrderReferenceDetailsResponse>");
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