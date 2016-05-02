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
    public class GetCaptureDetailsResponse
    {
    
        private  GetCaptureDetailsResult getCaptureDetailsResultField;
        private  ResponseMetadata responseMetadataField;

        /// <summary>
        /// Gets and sets the GetCaptureDetailsResult property.
        /// </summary>
        [XmlElementAttribute(ElementName = "GetCaptureDetailsResult")]
        public GetCaptureDetailsResult GetCaptureDetailsResult
        {
            get { return this.getCaptureDetailsResultField ; }
            set { this.getCaptureDetailsResultField = value; }
        }



        /// <summary>
        /// Sets the GetCaptureDetailsResult property
        /// </summary>
        /// <param name="getCaptureDetailsResult">GetCaptureDetailsResult property</param>
        /// <returns>this instance</returns>
        public GetCaptureDetailsResponse WithGetCaptureDetailsResult(GetCaptureDetailsResult getCaptureDetailsResult)
        {
            this.getCaptureDetailsResultField = getCaptureDetailsResult;
            return this;
        }



        /// <summary>
        /// Checks if GetCaptureDetailsResult property is set
        /// </summary>
        /// <returns>true if GetCaptureDetailsResult property is set</returns>
        public Boolean IsSetGetCaptureDetailsResult()
        {
            return this.getCaptureDetailsResultField != null;
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
        public GetCaptureDetailsResponse WithResponseMetadata(ResponseMetadata responseMetadata)
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
            xml.Append("<GetCaptureDetailsResponse xmlns=\"http://mws.amazonservices.com/schema/OffAmazonPayments/2013-01-01\">");
            if (IsSetGetCaptureDetailsResult()) {
                GetCaptureDetailsResult  getCaptureDetailsResult = this.GetCaptureDetailsResult;
                xml.Append("<GetCaptureDetailsResult>");
                xml.Append(getCaptureDetailsResult.ToXMLFragment());
                xml.Append("</GetCaptureDetailsResult>");
            } 
            if (IsSetResponseMetadata()) {
                ResponseMetadata  responseMetadata = this.ResponseMetadata;
                xml.Append("<ResponseMetadata>");
                xml.Append(responseMetadata.ToXMLFragment());
                xml.Append("</ResponseMetadata>");
            } 
            xml.Append("</GetCaptureDetailsResponse>");
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