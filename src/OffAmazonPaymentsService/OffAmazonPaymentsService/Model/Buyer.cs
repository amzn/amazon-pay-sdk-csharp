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
    public class Buyer
    {
    
        private String nameField;

        private String emailField;

        private String phoneField;


        /// <summary>
        /// Gets and sets the Name property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Name")]
        public String Name
        {
            get { return this.nameField ; }
            set { this.nameField= value; }
        }



        /// <summary>
        /// Sets the Name property
        /// </summary>
        /// <param name="name">Name property</param>
        /// <returns>this instance</returns>
        public Buyer WithName(String name)
        {
            this.nameField = name;
            return this;
        }



        /// <summary>
        /// Checks if Name property is set
        /// </summary>
        /// <returns>true if Name property is set</returns>
        public Boolean IsSetName()
        {
            return  this.nameField != null;

        }





        /// <summary>
        /// Gets and sets the Email property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Email")]
        public String Email
        {
            get { return this.emailField ; }
            set { this.emailField= value; }
        }



        /// <summary>
        /// Sets the Email property
        /// </summary>
        /// <param name="email">Email property</param>
        /// <returns>this instance</returns>
        public Buyer WithEmail(String email)
        {
            this.emailField = email;
            return this;
        }



        /// <summary>
        /// Checks if Email property is set
        /// </summary>
        /// <returns>true if Email property is set</returns>
        public Boolean IsSetEmail()
        {
            return  this.emailField != null;

        }





        /// <summary>
        /// Gets and sets the Phone property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Phone")]
        public String Phone
        {
            get { return this.phoneField ; }
            set { this.phoneField= value; }
        }



        /// <summary>
        /// Sets the Phone property
        /// </summary>
        /// <param name="phone">Phone property</param>
        /// <returns>this instance</returns>
        public Buyer WithPhone(String phone)
        {
            this.phoneField = phone;
            return this;
        }



        /// <summary>
        /// Checks if Phone property is set
        /// </summary>
        /// <returns>true if Phone property is set</returns>
        public Boolean IsSetPhone()
        {
            return  this.phoneField != null;

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
            if (IsSetName()) {
                xml.Append("<Name>");
                xml.Append(EscapeXML(this.Name));
                xml.Append("</Name>");
            }
            if (IsSetEmail()) {
                xml.Append("<Email>");
                xml.Append(EscapeXML(this.Email));
                xml.Append("</Email>");
            }
            if (IsSetPhone()) {
                xml.Append("<Phone>");
                xml.Append(EscapeXML(this.Phone));
                xml.Append("</Phone>");
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