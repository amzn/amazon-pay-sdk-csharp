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
    public class CaptureDetails
    {
        private string amazonCaptureIdField;

        private string captureReferenceIdField;

        private Price captureAmountField;

        private Price refundedAmountField;

        private Price captureFeeField;

        private DateTime creationTimestampField;

        private Status captureStatusField;

        private ProviderCreditSummaryList providerCreditSummaryListField;

        private string softDescriptorField;

        /// <remarks/>
        public string AmazonCaptureId
        {
            get
            {
                return this.amazonCaptureIdField;
            }
            set
            {
                this.amazonCaptureIdField = value;
            }
        }

        /// <remarks/>
        public string CaptureReferenceId
        {
            get
            {
                return this.captureReferenceIdField;
            }
            set
            {
                this.captureReferenceIdField = value;
            }
        }

        /// <remarks/>
        public Price CaptureAmount
        {
            get
            {
                return this.captureAmountField;
            }
            set
            {
                this.captureAmountField = value;
            }
        }

        /// <remarks/>
        public Price RefundedAmount
        {
            get
            {
                return this.refundedAmountField;
            }
            set
            {
                this.refundedAmountField = value;
            }
        }

        /// <remarks/>
        public Price CaptureFee
        {
            get
            {
                return this.captureFeeField;
            }
            set
            {
                this.captureFeeField = value;
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
        public Status CaptureStatus
        {
            get
            {
                return this.captureStatusField;
            }
            set
            {
                this.captureStatusField = value;
            }
        }

        /// <remarks/>
        public ProviderCreditSummaryList ProviderCreditSummaryList
        {
            get
            {
                return this.providerCreditSummaryListField;
            }
            set
            {
                this.providerCreditSummaryListField = value;
            }
        }

        /// <remarks/>
        public string SoftDescriptor
        {
            get
            {
                return this.softDescriptorField;
            }
            set
            {
                this.softDescriptorField = value;
            }
        }
    }
}