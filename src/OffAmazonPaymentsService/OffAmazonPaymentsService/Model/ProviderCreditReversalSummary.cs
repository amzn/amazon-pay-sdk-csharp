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
    public class ProviderCreditReversalSummary
    {

        private String providerIdField;

        private String providerCreditReversalIdField;


        /// <summary>
        /// Gets and sets the ProviderId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ProviderId")]
        public String ProviderId
        {
            get { return this.providerIdField; }
            set { this.providerIdField = value; }
        }



        /// <summary>
        /// Sets the ProviderId property
        /// </summary>
        /// <param name="providerId">ProviderId property</param>
        /// <returns>this instance</returns>
        public ProviderCreditReversalSummary WithProviderId(String providerId)
        {
            this.providerIdField = providerId;
            return this;
        }



        /// <summary>
        /// Checks if ProviderId property is set
        /// </summary>
        /// <returns>true if ProviderId property is set</returns>
        public Boolean IsSetProviderId()
        {
            return this.providerIdField != null;

        }





        /// <summary>
        /// Gets and sets the ProviderCreditReversalId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ProviderCreditReversalId")]
        public String ProviderCreditReversalId
        {
            get { return this.providerCreditReversalIdField; }
            set { this.providerCreditReversalIdField = value; }
        }



        /// <summary>
        /// Sets the ProviderCreditReversalId property
        /// </summary>
        /// <param name="providerCreditReversalId">ProviderCreditReversalId property</param>
        /// <returns>this instance</returns>
        public ProviderCreditReversalSummary WithProviderCreditReversalId(String providerCreditReversalId)
        {
            this.providerCreditReversalIdField = providerCreditReversalId;
            return this;
        }



        /// <summary>
        /// Checks if ProviderCreditReversalId property is set
        /// </summary>
        /// <returns>true if ProviderCreditReversalId property is set</returns>
        public Boolean IsSetProviderCreditReversalId()
        {
            return this.providerCreditReversalIdField != null;

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
            if (IsSetProviderId())
            {
                xml.Append("<ProviderId>");
                xml.Append(this.ProviderId);
                xml.Append("</ProviderId>");
            }
            if (IsSetProviderCreditReversalId())
            {
                xml.Append("<ProviderCreditReversalId>");
                xml.Append(this.ProviderCreditReversalId);
                xml.Append("</ProviderCreditReversalId>");
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