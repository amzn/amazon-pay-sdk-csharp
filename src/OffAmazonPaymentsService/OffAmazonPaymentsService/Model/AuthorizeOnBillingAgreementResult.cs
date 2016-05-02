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
    public class AuthorizeOnBillingAgreementResult
    {

        private AuthorizationDetails authorizationDetailsField;
        private String amazonOrderReferenceIdField;


        /// <summary>
        /// Gets and sets the AuthorizationDetails property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AuthorizationDetails")]
        public AuthorizationDetails AuthorizationDetails
        {
            get { return this.authorizationDetailsField; }
            set { this.authorizationDetailsField = value; }
        }



        /// <summary>
        /// Sets the AuthorizationDetails property
        /// </summary>
        /// <param name="authorizationDetails">AuthorizationDetails property</param>
        /// <returns>this instance</returns>
        public AuthorizeOnBillingAgreementResult WithAuthorizationDetails(AuthorizationDetails authorizationDetails)
        {
            this.authorizationDetailsField = authorizationDetails;
            return this;
        }



        /// <summary>
        /// Checks if AuthorizationDetails property is set
        /// </summary>
        /// <returns>true if AuthorizationDetails property is set</returns>
        public Boolean IsSetAuthorizationDetails()
        {
            return this.authorizationDetailsField != null;
        }



        /// <summary>
        /// Gets and sets the AmazonOrderReferenceId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AmazonOrderReferenceId")]
        public String AmazonOrderReferenceId
        {
            get { return this.amazonOrderReferenceIdField; }
            set { this.amazonOrderReferenceIdField = value; }
        }



        /// <summary>
        /// Sets the AmazonOrderReferenceId property
        /// </summary>
        /// <param name="amazonOrderReferenceId">AmazonOrderReferenceId property</param>
        /// <returns>this instance</returns>
        public AuthorizeOnBillingAgreementResult WithAmazonOrderReferenceId(String amazonOrderReferenceId)
        {
            this.amazonOrderReferenceIdField = amazonOrderReferenceId;
            return this;
        }



        /// <summary>
        /// Checks if AmazonOrderReferenceId property is set
        /// </summary>
        /// <returns>true if AmazonOrderReferenceId property is set</returns>
        public Boolean IsSetAmazonOrderReferenceId()
        {
            return this.amazonOrderReferenceIdField != null;

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
            if (IsSetAuthorizationDetails())
            {
                AuthorizationDetails authorizationDetailsObj = this.AuthorizationDetails;
                xml.Append("<AuthorizationDetails>");
                xml.Append(authorizationDetailsObj.ToXMLFragment());
                xml.Append("</AuthorizationDetails>");
            }
            if (IsSetAmazonOrderReferenceId())
            {
                xml.Append("<AmazonOrderReferenceId>");
                xml.Append(EscapeXML(this.AmazonOrderReferenceId));
                xml.Append("</AmazonOrderReferenceId>");
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