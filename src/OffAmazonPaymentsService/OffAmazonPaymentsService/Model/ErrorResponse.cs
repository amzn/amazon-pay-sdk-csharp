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
    public class ErrorResponse
    {
    
        private  List<Error> errorField;

        private String requestIdField;


        /// <summary>
        /// Gets and sets the Error property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Error")]
        public List<Error> Error
        {
            get
            {
                if (this.errorField == null)
                {
                    this.errorField = new List<Error>();
                }
                return this.errorField;
            }
            set { this.errorField =  value; }
        }



        /// <summary>
        /// Sets the Error property
        /// </summary>
        /// <param name="list">Error property</param>
        /// <returns>this instance</returns>
        public ErrorResponse WithError(params Error[] list)
        {
            foreach (Error item in list)
            {
                Error.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks if Error property is set
        /// </summary>
        /// <returns>true if Error property is set</returns>
        public Boolean IsSetError()
        {
            return (Error.Count > 0);
        }


        /// <summary>
        /// Gets and sets the RequestId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "RequestId")]
        public String RequestId
        {
            get { return this.requestIdField ; }
            set { this.requestIdField= value; }
        }



        /// <summary>
        /// Sets the RequestId property
        /// </summary>
        /// <param name="requestId">RequestId property</param>
        /// <returns>this instance</returns>
        public ErrorResponse WithRequestId(String requestId)
        {
            this.requestIdField = requestId;
            return this;
        }



        /// <summary>
        /// Checks if RequestId property is set
        /// </summary>
        /// <returns>true if RequestId property is set</returns>
        public Boolean IsSetRequestId()
        {
            return  this.requestIdField != null;

        }







        /// <summary>
        /// XML Representation for this object
        /// </summary>
        /// <returns>XML String</returns>

        public String ToXML() {
            StringBuilder xml = new StringBuilder();
            xml.Append("<ErrorResponse xmlns=\"http://mws.amazonservices.com/schema/OffAmazonPayments/2013-01-01\">");
            List<Error> errorList = this.Error;
            foreach (Error error in errorList) {
                xml.Append("<Error>");
                xml.Append(error.ToXMLFragment());
                xml.Append("</Error>");
            }
            if (IsSetRequestId()) {
                xml.Append("<RequestId>");
                xml.Append(EscapeXML(this.RequestId));
                xml.Append("</RequestId>");
            }
            xml.Append("</ErrorResponse>");
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