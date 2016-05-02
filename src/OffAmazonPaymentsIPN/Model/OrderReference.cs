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
    public class OrderReference
    {

        private string amazonOrderReferenceIdField;

        private OrderTotal orderTotalField;

        private string sellerNoteField;

        private SellerOrderAttributes sellerOrderAttributesField;

        private OrderReferenceStatus orderReferenceStatusField;

        private DateTime creationTimestampField;

        private DateTime expirationTimestampField;

        /// <remarks/>
        public string AmazonOrderReferenceId
        {
            get
            {
                return this.amazonOrderReferenceIdField;
            }
            set
            {
                this.amazonOrderReferenceIdField = value;
            }
        }

        /// <remarks/>
        public OrderTotal OrderTotal
        {
            get
            {
                return this.orderTotalField;
            }
            set
            {
                this.orderTotalField = value;
            }
        }

        /// <remarks/>
        public string SellerNote
        {
            get
            {
                return this.sellerNoteField;
            }
            set
            {
                this.sellerNoteField = value;
            }
        }

        /// <remarks/>
        public SellerOrderAttributes SellerOrderAttributes
        {
            get
            {
                return this.sellerOrderAttributesField;
            }
            set
            {
                this.sellerOrderAttributesField = value;
            }
        }

        /// <remarks/>
        public OrderReferenceStatus OrderReferenceStatus
        {
            get
            {
                return this.orderReferenceStatusField;
            }
            set
            {
                this.orderReferenceStatusField = value;
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
        public DateTime ExpirationTimestamp
        {
            get
            {
                return this.expirationTimestampField;
            }
            set
            {
                this.expirationTimestampField = value;
            }
        }
    }
}