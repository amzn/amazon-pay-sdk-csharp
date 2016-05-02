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
    public class ProviderCreditDetails
    {
        private string amazonProviderCreditIdField;

        private string sellerIdField;

        private string providerSellerIdField;

        private Price creditAmountField;

        private Price creditReversalAmountField;

        private DateTime creationTimestampField;

        private Status creditStatusField;

        private IdList idListField;

        /// <remarks/>
        public string AmazonProviderCreditId
        {
            get
            {
                return this.amazonProviderCreditIdField;
            }
            set
            {
                this.amazonProviderCreditIdField = value;
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
        public Price CreditAmount
        {
            get
            {
                return this.creditAmountField;
            }
            set
            {
                this.creditAmountField = value;
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
        public Status CreditStatus
        {
            get
            {
                return this.creditStatusField;
            }
            set
            {
                this.creditStatusField = value;
            }
        }

        /// <remarks/>
        public IdList CreditReversalIdList
        {
            get
            {
                return this.idListField;
            }
            set
            {
                this.idListField = value;
            }
        }
    }
}