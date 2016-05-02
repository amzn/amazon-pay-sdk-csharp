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
    public class Constraints
    {
    
        private  List<Constraint> constraintField;


        /// <summary>
        /// Gets and sets the Constraint property.
        /// </summary>
        [XmlElementAttribute(ElementName = "Constraint")]
        public List<Constraint> Constraint
        {
            get
            {
                if (this.constraintField == null)
                {
                    this.constraintField = new List<Constraint>();
                }
                return this.constraintField;
            }
            set { this.constraintField =  value; }
        }



        /// <summary>
        /// Sets the Constraint property
        /// </summary>
        /// <param name="list">Constraint property</param>
        /// <returns>this instance</returns>
        public Constraints WithConstraint(params Constraint[] list)
        {
            foreach (Constraint item in list)
            {
                Constraint.Add(item);
            }
            return this;
        }          
 


        /// <summary>
        /// Checks if Constraint property is set
        /// </summary>
        /// <returns>true if Constraint property is set</returns>
        public Boolean IsSetConstraint()
        {
            return (Constraint.Count > 0);
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
            List<Constraint> constraintObjList = this.Constraint;
            foreach (Constraint constraintObj in constraintObjList) {
                xml.Append("<Constraint>");
                xml.Append(constraintObj.ToXMLFragment());
                xml.Append("</Constraint>");
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