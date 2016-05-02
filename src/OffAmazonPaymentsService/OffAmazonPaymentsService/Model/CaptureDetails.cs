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
    public class CaptureDetails
    {
    
        private String amazonCaptureIdField;

        private String captureReferenceIdField;

        private String sellerCaptureNoteField;

        private  Price captureAmountField;
        private  Price refundedAmountField;
        private  Price captureFeeField;
        private  IdList idListField;
        private DateTime? creationTimestampField;

        private  Status captureStatusField;
        private String softDescriptorField;

        private ProviderCreditSummaryList providerCreditSummaryListField;

        /// <summary>
        /// Gets and sets the AmazonCaptureId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AmazonCaptureId")]
        public String AmazonCaptureId
        {
            get { return this.amazonCaptureIdField ; }
            set { this.amazonCaptureIdField= value; }
        }



        /// <summary>
        /// Sets the AmazonCaptureId property
        /// </summary>
        /// <param name="amazonCaptureId">AmazonCaptureId property</param>
        /// <returns>this instance</returns>
        public CaptureDetails WithAmazonCaptureId(String amazonCaptureId)
        {
            this.amazonCaptureIdField = amazonCaptureId;
            return this;
        }



        /// <summary>
        /// Checks if AmazonCaptureId property is set
        /// </summary>
        /// <returns>true if AmazonCaptureId property is set</returns>
        public Boolean IsSetAmazonCaptureId()
        {
            return this.amazonCaptureIdField != null;

        }





        /// <summary>
        /// Gets and sets the CaptureReferenceId property.
        /// </summary>
        [XmlElementAttribute(ElementName = "CaptureReferenceId")]
        public String CaptureReferenceId
        {
            get { return this.captureReferenceIdField ; }
            set { this.captureReferenceIdField= value; }
        }



        /// <summary>
        /// Sets the CaptureReferenceId property
        /// </summary>
        /// <param name="captureReferenceId">CaptureReferenceId property</param>
        /// <returns>this instance</returns>
        public CaptureDetails WithCaptureReferenceId(String captureReferenceId)
        {
            this.captureReferenceIdField = captureReferenceId;
            return this;
        }



        /// <summary>
        /// Checks if CaptureReferenceId property is set
        /// </summary>
        /// <returns>true if CaptureReferenceId property is set</returns>
        public Boolean IsSetCaptureReferenceId()
        {
            return this.captureReferenceIdField != null;

        }





        /// <summary>
        /// Gets and sets the SellerCaptureNote property.
        /// </summary>
        [XmlElementAttribute(ElementName = "SellerCaptureNote")]
        public String SellerCaptureNote
        {
            get { return this.sellerCaptureNoteField ; }
            set { this.sellerCaptureNoteField= value; }
        }



        /// <summary>
        /// Sets the SellerCaptureNote property
        /// </summary>
        /// <param name="sellerCaptureNote">SellerCaptureNote property</param>
        /// <returns>this instance</returns>
        public CaptureDetails WithSellerCaptureNote(String sellerCaptureNote)
        {
            this.sellerCaptureNoteField = sellerCaptureNote;
            return this;
        }



        /// <summary>
        /// Checks if SellerCaptureNote property is set
        /// </summary>
        /// <returns>true if SellerCaptureNote property is set</returns>
        public Boolean IsSetSellerCaptureNote()
        {
            return  this.sellerCaptureNoteField != null;

        }





        /// <summary>
        /// Gets and sets the CaptureAmount property.
        /// </summary>
        [XmlElementAttribute(ElementName = "CaptureAmount")]
        public Price CaptureAmount
        {
            get { return this.captureAmountField ; }
            set { this.captureAmountField = value; }
        }



        /// <summary>
        /// Sets the CaptureAmount property
        /// </summary>
        /// <param name="captureAmount">CaptureAmount property</param>
        /// <returns>this instance</returns>
        public CaptureDetails WithCaptureAmount(Price captureAmount)
        {
            this.captureAmountField = captureAmount;
            return this;
        }



        /// <summary>
        /// Checks if CaptureAmount property is set
        /// </summary>
        /// <returns>true if CaptureAmount property is set</returns>
        public Boolean IsSetCaptureAmount()
        {
            return this.captureAmountField != null;
        }



        /// <summary>
        /// Gets and sets the RefundedAmount property.
        /// </summary>
        [XmlElementAttribute(ElementName = "RefundedAmount")]
        public Price RefundedAmount
        {
            get { return this.refundedAmountField ; }
            set { this.refundedAmountField = value; }
        }



        /// <summary>
        /// Sets the RefundedAmount property
        /// </summary>
        /// <param name="refundedAmount">RefundedAmount property</param>
        /// <returns>this instance</returns>
        public CaptureDetails WithRefundedAmount(Price refundedAmount)
        {
            this.refundedAmountField = refundedAmount;
            return this;
        }



        /// <summary>
        /// Checks if RefundedAmount property is set
        /// </summary>
        /// <returns>true if RefundedAmount property is set</returns>
        public Boolean IsSetRefundedAmount()
        {
            return this.refundedAmountField != null;
        }



        /// <summary>
        /// Gets and sets the CaptureFee property.
        /// </summary>
        [XmlElementAttribute(ElementName = "CaptureFee")]
        public Price CaptureFee
        {
            get { return this.captureFeeField ; }
            set { this.captureFeeField = value; }
        }



        /// <summary>
        /// Sets the CaptureFee property
        /// </summary>
        /// <param name="captureFee">CaptureFee property</param>
        /// <returns>this instance</returns>
        public CaptureDetails WithCaptureFee(Price captureFee)
        {
            this.captureFeeField = captureFee;
            return this;
        }



        /// <summary>
        /// Checks if CaptureFee property is set
        /// </summary>
        /// <returns>true if CaptureFee property is set</returns>
        public Boolean IsSetCaptureFee()
        {
            return this.captureFeeField != null;
        }



        /// <summary>
        /// Gets and sets the IdList property.
        /// </summary>
        [XmlElementAttribute(ElementName = "IdList")]
        public IdList IdList
        {
            get { return this.idListField ; }
            set { this.idListField = value; }
        }



        /// <summary>
        /// Sets the IdList property
        /// </summary>
        /// <param name="idList">IdList property</param>
        /// <returns>this instance</returns>
        public CaptureDetails WithIdList(IdList idList)
        {
            this.idListField = idList;
            return this;
        }



        /// <summary>
        /// Checks if IdList property is set
        /// </summary>
        /// <returns>true if IdList property is set</returns>
        public Boolean IsSetIdList()
        {
            return this.idListField != null;
        }



        /// <summary>
        /// Gets and sets the CreationTimestamp property.
        /// </summary>
        [XmlElementAttribute(ElementName = "CreationTimestamp")]
        public DateTime CreationTimestamp
        {
            get { return this.creationTimestampField.GetValueOrDefault() ; }
            set { this.creationTimestampField= value; }
        }



        /// <summary>
        /// Sets the CreationTimestamp property
        /// </summary>
        /// <param name="creationTimestamp">CreationTimestamp property</param>
        /// <returns>this instance</returns>
        public CaptureDetails WithCreationTimestamp(DateTime creationTimestamp)
        {
            this.creationTimestampField = creationTimestamp;
            return this;
        }



        /// <summary>
        /// Checks if CreationTimestamp property is set
        /// </summary>
        /// <returns>true if CreationTimestamp property is set</returns>
        public Boolean IsSetCreationTimestamp()
        {
            return  this.creationTimestampField.HasValue;

        }





        /// <summary>
        /// Gets and sets the CaptureStatus property.
        /// </summary>
        [XmlElementAttribute(ElementName = "CaptureStatus")]
        public Status CaptureStatus
        {
            get { return this.captureStatusField ; }
            set { this.captureStatusField = value; }
        }



        /// <summary>
        /// Sets the CaptureStatus property
        /// </summary>
        /// <param name="captureStatus">CaptureStatus property</param>
        /// <returns>this instance</returns>
        public CaptureDetails WithCaptureStatus(Status captureStatus)
        {
            this.captureStatusField = captureStatus;
            return this;
        }



        /// <summary>
        /// Checks if CaptureStatus property is set
        /// </summary>
        /// <returns>true if CaptureStatus property is set</returns>
        public Boolean IsSetCaptureStatus()
        {
            return this.captureStatusField != null;
        }



        /// <summary>
        /// Gets and sets the SoftDescriptor property.
        /// </summary>
        [XmlElementAttribute(ElementName = "SoftDescriptor")]
        public String SoftDescriptor
        {
            get { return this.softDescriptorField ; }
            set { this.softDescriptorField= value; }
        }



        /// <summary>
        /// Sets the SoftDescriptor property
        /// </summary>
        /// <param name="softDescriptor">SoftDescriptor property</param>
        /// <returns>this instance</returns>
        public CaptureDetails WithSoftDescriptor(String softDescriptor)
        {
            this.softDescriptorField = softDescriptor;
            return this;
        }



        /// <summary>
        /// Checks if SoftDescriptor property is set
        /// </summary>
        /// <returns>true if SoftDescriptor property is set</returns>
        public Boolean IsSetSoftDescriptor()
        {
            return  this.softDescriptorField != null;

        }




        /// <summary>
        /// Gets and sets the ProviderCreditSummaryList property.
        /// </summary>
        [XmlElementAttribute(ElementName = "ProviderCreditSummaryList")]
        public ProviderCreditSummaryList ProviderCreditSummaryList
        {
            get { return this.providerCreditSummaryListField; }
            set { this.providerCreditSummaryListField = value; }
        }



        /// <summary>
        /// Sets the ProviderCreditSummaryList property
        /// </summary>
        /// <param name="providerCreditSummaryList">ProviderCreditSummaryList property</param>
        /// <returns>this instance</returns>
        public CaptureDetails WithProviderCreditSummaryList(ProviderCreditSummaryList providerCreditSummaryList)
        {
            this.providerCreditSummaryListField = providerCreditSummaryList;
            return this;
        }



        /// <summary>
        /// Checks if ProviderCreditSummaryList property is set
        /// </summary>
        /// <returns>true if ProviderCreditSummaryList property is set</returns>
        public Boolean IsSetProviderCreditSummaryList()
        {
            return this.providerCreditSummaryListField != null;
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
            if (IsSetAmazonCaptureId()) {
                xml.Append("<AmazonCaptureId>");
                xml.Append(this.AmazonCaptureId);
                xml.Append("</AmazonCaptureId>");
            }
            if (IsSetCaptureReferenceId()) {
                xml.Append("<CaptureReferenceId>");
                xml.Append(this.CaptureReferenceId);
                xml.Append("</CaptureReferenceId>");
            }
            if (IsSetSellerCaptureNote()) {
                xml.Append("<SellerCaptureNote>");
                xml.Append(EscapeXML(this.SellerCaptureNote));
                xml.Append("</SellerCaptureNote>");
            }
            if (IsSetCaptureAmount()) {
                Price  captureAmountObj = this.CaptureAmount;
                xml.Append("<CaptureAmount>");
                xml.Append(captureAmountObj.ToXMLFragment());
                xml.Append("</CaptureAmount>");
            } 
            if (IsSetRefundedAmount()) {
                Price  refundedAmountObj = this.RefundedAmount;
                xml.Append("<RefundedAmount>");
                xml.Append(refundedAmountObj.ToXMLFragment());
                xml.Append("</RefundedAmount>");
            } 
            if (IsSetCaptureFee()) {
                Price  captureFeeObj = this.CaptureFee;
                xml.Append("<CaptureFee>");
                xml.Append(captureFeeObj.ToXMLFragment());
                xml.Append("</CaptureFee>");
            } 
            if (IsSetIdList()) {
                IdList  idListObj = this.IdList;
                xml.Append("<IdList>");
                xml.Append(idListObj.ToXMLFragment());
                xml.Append("</IdList>");
            } 
            if (IsSetCreationTimestamp()) {
                xml.Append("<CreationTimestamp>");
                xml.Append(this.CreationTimestamp);
                xml.Append("</CreationTimestamp>");
            }
            if (IsSetCaptureStatus()) {
                Status  captureStatusObj = this.CaptureStatus;
                xml.Append("<CaptureStatus>");
                xml.Append(captureStatusObj.ToXMLFragment());
                xml.Append("</CaptureStatus>");
            } 
            if (IsSetSoftDescriptor()) {
                xml.Append("<SoftDescriptor>");
                xml.Append(EscapeXML(this.SoftDescriptor));
                xml.Append("</SoftDescriptor>");
            }
            if (IsSetProviderCreditSummaryList())
            {
                ProviderCreditSummaryList providerCreditSummaryListObj = this.ProviderCreditSummaryList;
                xml.Append("<ProviderCreditSummaryList>");
                xml.Append(providerCreditSummaryListObj.ToXMLFragment());
                xml.Append("</ProviderCreditSummaryList>");
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