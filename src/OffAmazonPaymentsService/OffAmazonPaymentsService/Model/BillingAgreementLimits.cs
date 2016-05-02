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
    public class BillingAgreementLimits
    {

        private Price amountLimitPerTimePeriodField;
        private DateTime? timePeriodStartDateField;

        private DateTime? timePeriodEndDateField;

        private Price currentRemainingBalanceField;

        /// <summary>
        /// Gets and sets the AmountLimitPerTimePeriod property.
        /// </summary>
        [XmlElementAttribute(ElementName = "AmountLimitPerTimePeriod")]
        public Price AmountLimitPerTimePeriod
        {
            get { return this.amountLimitPerTimePeriodField; }
            set { this.amountLimitPerTimePeriodField = value; }
        }



        /// <summary>
        /// Sets the AmountLimitPerTimePeriod property
        /// </summary>
        /// <param name="amountLimitPerTimePeriod">AmountLimitPerTimePeriod property</param>
        /// <returns>this instance</returns>
        public BillingAgreementLimits WithAmountLimitPerTimePeriod(Price amountLimitPerTimePeriod)
        {
            this.amountLimitPerTimePeriodField = amountLimitPerTimePeriod;
            return this;
        }



        /// <summary>
        /// Checks if AmountLimitPerTimePeriod property is set
        /// </summary>
        /// <returns>true if AmountLimitPerTimePeriod property is set</returns>
        public Boolean IsSetAmountLimitPerTimePeriod()
        {
            return this.amountLimitPerTimePeriodField != null;
        }



        /// <summary>
        /// Gets and sets the TimePeriodStartDate property.
        /// </summary>
        [XmlElementAttribute(ElementName = "TimePeriodStartDate")]
        public DateTime TimePeriodStartDate
        {
            get { return this.timePeriodStartDateField.GetValueOrDefault(); }
            set { this.timePeriodStartDateField = value; }
        }



        /// <summary>
        /// Sets the TimePeriodStartDate property
        /// </summary>
        /// <param name="timePeriodStartDate">TimePeriodStartDate property</param>
        /// <returns>this instance</returns>
        public BillingAgreementLimits WithTimePeriodStartDate(DateTime timePeriodStartDate)
        {
            this.timePeriodStartDateField = timePeriodStartDate;
            return this;
        }



        /// <summary>
        /// Checks if TimePeriodStartDate property is set
        /// </summary>
        /// <returns>true if TimePeriodStartDate property is set</returns>
        public Boolean IsSetTimePeriodStartDate()
        {
            return this.timePeriodStartDateField.HasValue;

        }





        /// <summary>
        /// Gets and sets the TimePeriodEndDate property.
        /// </summary>
        [XmlElementAttribute(ElementName = "TimePeriodEndDate")]
        public DateTime TimePeriodEndDate
        {
            get { return this.timePeriodEndDateField.GetValueOrDefault(); }
            set { this.timePeriodEndDateField = value; }
        }



        /// <summary>
        /// Sets the TimePeriodEndDate property
        /// </summary>
        /// <param name="timePeriodEndDate">TimePeriodEndDate property</param>
        /// <returns>this instance</returns>
        public BillingAgreementLimits WithTimePeriodEndDate(DateTime timePeriodEndDate)
        {
            this.timePeriodEndDateField = timePeriodEndDate;
            return this;
        }



        /// <summary>
        /// Checks if TimePeriodEndDate property is set
        /// </summary>
        /// <returns>true if TimePeriodEndDate property is set</returns>
        public Boolean IsSetTimePeriodEndDate()
        {
            return this.timePeriodEndDateField.HasValue;

        }





        /// <summary>
        /// Gets and sets the CurrentRemainingBalance property.
        /// </summary>
        [XmlElementAttribute(ElementName = "CurrentRemainingBalance")]
        public Price CurrentRemainingBalance
        {
            get { return this.currentRemainingBalanceField; }
            set { this.currentRemainingBalanceField = value; }
        }



        /// <summary>
        /// Sets the CurrentRemainingBalance property
        /// </summary>
        /// <param name="currentRemainingBalance">CurrentRemainingBalance property</param>
        /// <returns>this instance</returns>
        public BillingAgreementLimits WithCurrentRemainingBalance(Price currentRemainingBalance)
        {
            this.currentRemainingBalanceField = currentRemainingBalance;
            return this;
        }



        /// <summary>
        /// Checks if CurrentRemainingBalance property is set
        /// </summary>
        /// <returns>true if CurrentRemainingBalance property is set</returns>
        public Boolean IsSetCurrentRemainingBalance()
        {
            return this.currentRemainingBalanceField != null;
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
            if (IsSetAmountLimitPerTimePeriod())
            {
                Price amountLimitPerTimePeriodObj = this.AmountLimitPerTimePeriod;
                xml.Append("<AmountLimitPerTimePeriod>");
                xml.Append(amountLimitPerTimePeriodObj.ToXMLFragment());
                xml.Append("</AmountLimitPerTimePeriod>");
            }
            if (IsSetTimePeriodStartDate())
            {
                xml.Append("<TimePeriodStartDate>");
                xml.Append(this.TimePeriodStartDate);
                xml.Append("</TimePeriodStartDate>");
            }
            if (IsSetTimePeriodEndDate())
            {
                xml.Append("<TimePeriodEndDate>");
                xml.Append(this.TimePeriodEndDate);
                xml.Append("</TimePeriodEndDate>");
            }
            if (IsSetCurrentRemainingBalance())
            {
                Price currentRemainingBalanceObj = this.CurrentRemainingBalance;
                xml.Append("<CurrentRemainingBalance>");
                xml.Append(currentRemainingBalanceObj.ToXMLFragment());
                xml.Append("</CurrentRemainingBalance>");
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