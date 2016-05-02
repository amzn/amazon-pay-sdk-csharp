/*******************************************************************************
 *  Copyright 2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *
 *  You may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at:
 *  http://aws.amazon.com/apache2.0
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License
 *  for the
 *  specific language governing permissions and limitations under the
 *  License.
 * *****************************************************************************
 */

using System;

namespace OffAmazonPaymentsNotifications
{
    public class BillingAgreement
    {

        private string amazonBillingAgreementIdField;

        private SellerBillingAgreementAttributes sellerBillingAgreementAttributesField;

        private BillingAgreementStatus billingAgreementStatusField;

        private DateTime creationTimestampField;

        private BillingAgreementLimits billingAgreementLimitsField;

        private bool billingAgreementConsentField;

        /// <remarks/>
        public string AmazonBillingAgreementId
        {
            get
            {
                return this.amazonBillingAgreementIdField;
            }
            set
            {
                this.amazonBillingAgreementIdField = value;
            }
        }

        /// <remarks/>
        public SellerBillingAgreementAttributes SellerBillingAgreementAttributes
        {
            get
            {
                return this.sellerBillingAgreementAttributesField;
            }
            set
            {
                this.sellerBillingAgreementAttributesField = value;
            }
        }

        /// <remarks/>
        public BillingAgreementStatus BillingAgreementStatus
        {
            get
            {
                return this.billingAgreementStatusField;
            }
            set
            {
                this.billingAgreementStatusField = value;
            }
        }

        /// <remarks/>
        public DateTime CreationTimestamp
        {
            get
            {
                return this.creationTimestampField;
            }
            set
            {
                this.creationTimestampField = value;
            }
        }

        /// <remarks/>
        public BillingAgreementLimits BillingAgreementLimits
        {
            get
            {
                return this.billingAgreementLimitsField;
            }
            set
            {
                this.billingAgreementLimitsField = value;
            }
        }

        /// <remarks/>
        public bool BillingAgreementConsent
        {
            get
            {
                return this.billingAgreementConsentField;
            }
            set
            {
                this.billingAgreementConsentField = value;
            }
        }
    }
}
