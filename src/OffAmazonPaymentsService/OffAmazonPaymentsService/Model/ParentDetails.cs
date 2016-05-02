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
    public class ParentDetails
    {

        private String idField;

        private Type? typeField;


        /// <summary>
        /// Gets and sets the Id property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Id")]
        public String Id
        {
            get { return this.idField; }
            set { this.idField = value; }
        }



        /// <summary>
        /// Sets the Id property
        /// </summary>
        /// <param name="id">Id property</param>
        /// <returns>this instance</returns>
        public ParentDetails WithId(String id)
        {
            this.idField = id;
            return this;
        }



        /// <summary>
        /// Checks if Id property is set
        /// </summary>
        /// <returns>true if Id property is set</returns>
        public Boolean IsSetId()
        {
            return this.idField != null;

        }





        /// <summary>
        /// Gets and sets the Type property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Type")]
        public Type Type
        {
            get { return this.typeField.GetValueOrDefault(); }
            set { this.typeField = value; }
        }



        /// <summary>
        /// Sets the Type property
        /// </summary>
        /// <param name="type">Type property</param>
        /// <returns>this instance</returns>
        public ParentDetails WithType(Type type)
        {
            this.typeField = type;
            return this;
        }



        /// <summary>
        /// Checks if Type property is set
        /// </summary>
        /// <returns>true if Type property is set</returns>
        public Boolean IsSetType()
        {
            return this.typeField.HasValue;

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
            if (IsSetId())
            {
                xml.Append("<Id>");
                xml.Append(EscapeXML(this.Id));
                xml.Append("</Id>");
            }
            if (IsSetType())
            {
                xml.Append("<Type>");
                xml.Append(this.Type);
                xml.Append("</Type>");
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