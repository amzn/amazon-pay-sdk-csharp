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
    public class ValidateBillingAgreementResult
    {

        private RequestStatus? validationResultField;

        private String failureReasonCodeField;

        private BillingAgreementStatus billingAgreementStatusField;

        /// <summary>
        /// Gets and sets the ValidationResult property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ValidationResult")]
        public RequestStatus ValidationResult
        {
            get { return this.validationResultField.GetValueOrDefault(); }
            set { this.validationResultField = value; }
        }



        /// <summary>
        /// Sets the ValidationResult property
        /// </summary>
        /// <param name="validationResult">ValidationResult property</param>
        /// <returns>this instance</returns>
        public ValidateBillingAgreementResult WithValidationResult(RequestStatus validationResult)
        {
            this.validationResultField = validationResult;
            return this;
        }



        /// <summary>
        /// Checks if ValidationResult property is set
        /// </summary>
        /// <returns>true if ValidationResult property is set</returns>
        public Boolean IsSetValidationResult()
        {
            return this.validationResultField.HasValue;

        }





        /// <summary>
        /// Gets and sets the FailureReasonCode property.
        /// </summary>
        [XmlElementAttribute(ElementName = "FailureReasonCode")]
        public String FailureReasonCode
        {
            get { return this.failureReasonCodeField; }
            set { this.failureReasonCodeField = value; }
        }



        /// <summary>
        /// Sets the FailureReasonCode property
        /// </summary>
        /// <param name="failureReasonCode">FailureReasonCode property</param>
        /// <returns>this instance</returns>
        public ValidateBillingAgreementResult WithFailureReasonCode(String failureReasonCode)
        {
            this.failureReasonCodeField = failureReasonCode;
            return this;
        }



        /// <summary>
        /// Checks if FailureReasonCode property is set
        /// </summary>
        /// <returns>true if FailureReasonCode property is set</returns>
        public Boolean IsSetFailureReasonCode()
        {
            return this.failureReasonCodeField != null;

        }





        /// <summary>
        /// Gets and sets the BillingAgreementStatus property.
        /// </summary>
        [XmlElementAttribute(ElementName = "BillingAgreementStatus")]
        public BillingAgreementStatus BillingAgreementStatus
        {
            get { return this.billingAgreementStatusField; }
            set { this.billingAgreementStatusField = value; }
        }



        /// <summary>
        /// Sets the BillingAgreementStatus property
        /// </summary>
        /// <param name="billingAgreementStatus">BillingAgreementStatus property</param>
        /// <returns>this instance</returns>
        public ValidateBillingAgreementResult WithBillingAgreementStatus(BillingAgreementStatus billingAgreementStatus)
        {
            this.billingAgreementStatusField = billingAgreementStatus;
            return this;
        }



        /// <summary>
        /// Checks if BillingAgreementStatus property is set
        /// </summary>
        /// <returns>true if BillingAgreementStatus property is set</returns>
        public Boolean IsSetBillingAgreementStatus()
        {
            return this.billingAgreementStatusField != null;
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
            if (IsSetValidationResult())
            {
                xml.Append("<ValidationResult>");
                xml.Append(this.ValidationResult);
                xml.Append("</ValidationResult>");
            }
            if (IsSetFailureReasonCode())
            {
                xml.Append("<FailureReasonCode>");
                xml.Append(EscapeXML(this.FailureReasonCode));
                xml.Append("</FailureReasonCode>");
            }
            if (IsSetBillingAgreementStatus())
            {
                BillingAgreementStatus billingAgreementStatusObj = this.BillingAgreementStatus;
                xml.Append("<BillingAgreementStatus>");
                xml.Append(billingAgreementStatusObj.ToXMLFragment());
                xml.Append("</BillingAgreementStatus>");
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