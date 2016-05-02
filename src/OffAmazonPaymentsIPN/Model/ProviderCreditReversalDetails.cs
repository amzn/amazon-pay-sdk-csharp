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
    public class ProviderCreditReversalDetails
    {
        private string amazonProviderCreditReversalIdField;

        private string sellerIdField;

        private string providerSellerIdField;

        private string creditReversalReferenceIdField;

        private Price creditReversalAmountField;

        private DateTime creationTimestampField;

        private string creditReversalNoteField;

        private Status creditReversalStatusField;

        /// <remarks/>
        public string AmazonProviderCreditReversalId
        {
            get
            {
                return this.amazonProviderCreditReversalIdField;
            }
            set
            {
                this.amazonProviderCreditReversalIdField = value;
            }
        }

        /// <remarks/>
        public string SellerId
        {
            get
            {
                return this.sellerIdField;
            }
            set
            {
                this.sellerIdField = value;
            }
        }

        /// <remarks/>
        public string ProviderSellerId
        {
            get
            {
                return this.providerSellerIdField;
            }
            set
            {
                this.providerSellerIdField = value;
            }
        }

        /// <remarks/>
        public string CreditReversalReferenceId
        {
            get
            {
                return this.creditReversalReferenceIdField;
            }
            set
            {
                this.creditReversalReferenceIdField = value;
            }
        }

        /// <remarks/>
        public Price CreditReversalAmount
        {
            get
            {
                return this.creditReversalAmountField;
            }
            set
            {
                this.creditReversalAmountField = value;
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
        public string CreditReversalNote
        {
            get
            {
                return this.creditReversalNoteField;
            }
            set
            {
                this.creditReversalNoteField = value;
            }
        }

        /// <remarks/>
        public Status CreditReversalStatus
        {
            get
            {
                return this.creditReversalStatusField;
            }
            set
            {
                this.creditReversalStatusField = value;
            }
        }
    }
}