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
    public class Destination
    {
    
        private String destinationTypeField;

        private  Address physicalDestinationField;

        /// <summary>
        /// Gets and sets the DestinationType property.
        /// </summary>
        [XmlElementAttribute(ElementName = "DestinationType")]
        public String DestinationType
        {
            get { return this.destinationTypeField ; }
            set { this.destinationTypeField= value; }
        }



        /// <summary>
        /// Sets the DestinationType property
        /// </summary>
        /// <param name="destinationType">DestinationType property</param>
        /// <returns>this instance</returns>
        public Destination WithDestinationType(String destinationType)
        {
            this.destinationTypeField = destinationType;
            return this;
        }



        /// <summary>
        /// Checks if DestinationType property is set
        /// </summary>
        /// <returns>true if DestinationType property is set</returns>
        public Boolean IsSetDestinationType()
        {
            return  this.destinationTypeField != null;

        }





        /// <summary>
        /// Gets and sets the PhysicalDestination property.
        /// </summary>
        [XmlElementAttribute(ElementName = "PhysicalDestination")]
        public Address PhysicalDestination
        {
            get { return this.physicalDestinationField ; }
            set { this.physicalDestinationField = value; }
        }



        /// <summary>
        /// Sets the PhysicalDestination property
        /// </summary>
        /// <param name="physicalDestination">PhysicalDestination property</param>
        /// <returns>this instance</returns>
        public Destination WithPhysicalDestination(Address physicalDestination)
        {
            this.physicalDestinationField = physicalDestination;
            return this;
        }



        /// <summary>
        /// Checks if PhysicalDestination property is set
        /// </summary>
        /// <returns>true if PhysicalDestination property is set</returns>
        public Boolean IsSetPhysicalDestination()
        {
            return this.physicalDestinationField != null;
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
            if (IsSetDestinationType()) {
                xml.Append("<DestinationType>");
                xml.Append(EscapeXML(this.DestinationType));
                xml.Append("</DestinationType>");
            }
            if (IsSetPhysicalDestination()) {
                Address  physicalDestinationObj = this.PhysicalDestination;
                xml.Append("<PhysicalDestination>");
                xml.Append(physicalDestinationObj.ToXMLFragment());
                xml.Append("</PhysicalDestination>");
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