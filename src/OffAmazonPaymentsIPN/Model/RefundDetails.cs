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
    public class RefundDetails
    {

        private string amazonRefundIdField;

        private string refundReferenceIdField;

        private string refundTypeField;

        private Price refundAmountField;

        private Price feeRefundedField;

        private DateTime creationTimestampField;

        private Status refundStatusField;

        private ProviderCreditReversalSummaryList providerCreditReversalSummaryListField;

        private string softDescriptorField;

        public string AmazonRefundId
        {
            get
            {
                return this.amazonRefundIdField;
            }
            set
            {
                this.amazonRefundIdField = value;
            }
        }

        /// <remarks/>
        public string RefundReferenceId
        {
            get
            {
                return this.refundReferenceIdField;
            }
            set
            {
                this.refundReferenceIdField = value;
            }
        }

        /// <remarks/>
        public string RefundType
        {
            get
            {
                return this.refundTypeField;
            }
            set
            {
                this.refundTypeField = value;
            }
        }

        /// <remarks/>
        public Price RefundAmount
        {
            get
            {
                return this.refundAmountField;
            }
            set
            {
                this.refundAmountField = value;
            }
        }

        /// <remarks/>
        public Price FeeRefunded
        {
            get
            {
                return this.feeRefundedField;
            }
            set
            {
                this.feeRefundedField = value;
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
        public Status RefundStatus
        {
            get
            {
                return this.refundStatusField;
            }
            set
            {
                this.refundStatusField = value;
            }
        }

        /// <remarks/>
        public ProviderCreditReversalSummaryList ProviderCreditReversalSummaryList
        {
            get
            {
                return this.providerCreditReversalSummaryListField;
            }
            set
            {
                this.providerCreditReversalSummaryListField = value;
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