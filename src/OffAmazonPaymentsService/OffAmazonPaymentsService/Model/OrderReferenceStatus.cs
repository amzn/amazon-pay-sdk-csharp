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
    public class OrderReferenceStatus
    {
    
        private String stateField;

        private DateTime? lastUpdateTimestampField;

        private String reasonCodeField;

        private String reasonDescriptionField;


        /// <summary>
        /// Gets and sets the State property.
        /// </summary>
        [XmlElementAttribute(ElementName = "State")]
        public String State
        {
            get { return this.stateField ; }
            set { this.stateField= value; }
        }



        /// <summary>
        /// Sets the State property
        /// </summary>
        /// <param name="state">State property</param>
        /// <returns>this instance</returns>
        public OrderReferenceStatus WithState(String state)
        {
            this.stateField = state;
            return this;
        }



        /// <summary>
        /// Checks if State property is set
        /// </summary>
        /// <returns>true if State property is set</returns>
        public Boolean IsSetState()
        {
            return  this.stateField != null;

        }





        /// <summary>
        /// Gets and sets the LastUpdateTimestamp property.
        /// </summary>
        [XmlElementAttribute(ElementName = "LastUpdateTimestamp")]
        public DateTime LastUpdateTimestamp
        {
            get { return this.lastUpdateTimestampField.GetValueOrDefault() ; }
            set { this.lastUpdateTimestampField= value; }
        }



        /// <summary>
        /// Sets the LastUpdateTimestamp property
        /// </summary>
        /// <param name="lastUpdateTimestamp">LastUpdateTimestamp property</param>
        /// <returns>this instance</returns>
        public OrderReferenceStatus WithLastUpdateTimestamp(DateTime lastUpdateTimestamp)
        {
            this.lastUpdateTimestampField = lastUpdateTimestamp;
            return this;
        }



        /// <summary>
        /// Checks if LastUpdateTimestamp property is set
        /// </summary>
        /// <returns>true if LastUpdateTimestamp property is set</returns>
        public Boolean IsSetLastUpdateTimestamp()
        {
            return  this.lastUpdateTimestampField.HasValue;

        }





        /// <summary>
        /// Gets and sets the ReasonCode property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ReasonCode")]
        public String ReasonCode
        {
            get { return this.reasonCodeField ; }
            set { this.reasonCodeField= value; }
        }



        /// <summary>
        /// Sets the ReasonCode property
        /// </summary>
        /// <param name="reasonCode">ReasonCode property</param>
        /// <returns>this instance</returns>
        public OrderReferenceStatus WithReasonCode(String reasonCode)
        {
            this.reasonCodeField = reasonCode;
            return this;
        }



        /// <summary>
        /// Checks if ReasonCode property is set
        /// </summary>
        /// <returns>true if ReasonCode property is set</returns>
        public Boolean IsSetReasonCode()
        {
            return  this.reasonCodeField != null;

        }





        /// <summary>
        /// Gets and sets the ReasonDescription property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ReasonDescription")]
        public String ReasonDescription
        {
            get { return this.reasonDescriptionField ; }
            set { this.reasonDescriptionField= value; }
        }



        /// <summary>
        /// Sets the ReasonDescription property
        /// </summary>
        /// <param name="reasonDescription">ReasonDescription property</param>
        /// <returns>this instance</returns>
        public OrderReferenceStatus WithReasonDescription(String reasonDescription)
        {
            this.reasonDescriptionField = reasonDescription;
            return this;
        }



        /// <summary>
        /// Checks if ReasonDescription property is set
        /// </summary>
        /// <returns>true if ReasonDescription property is set</returns>
        public Boolean IsSetReasonDescription()
        {
            return  this.reasonDescriptionField != null;

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
            if (IsSetState()) {
                xml.Append("<State>");
                xml.Append(EscapeXML(this.State));
                xml.Append("</State>");
            }
            if (IsSetLastUpdateTimestamp()) {
                xml.Append("<LastUpdateTimestamp>");
                xml.Append(this.LastUpdateTimestamp);
                xml.Append("</LastUpdateTimestamp>");
            }
            if (IsSetReasonCode()) {
                xml.Append("<ReasonCode>");
                xml.Append(EscapeXML(this.ReasonCode));
                xml.Append("</ReasonCode>");
            }
            if (IsSetReasonDescription()) {
                xml.Append("<ReasonDescription>");
                xml.Append(EscapeXML(this.ReasonDescription));
                xml.Append("</ReasonDescription>");
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