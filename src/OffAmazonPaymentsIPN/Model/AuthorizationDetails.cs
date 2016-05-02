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
using System.Xml.Serialization;

namespace OffAmazonPaymentsNotifications
{
    public class AuthorizationDetails
    {
        private string amazonAuthorizationIdField;

        private string authorizationReferenceIdField;

        private Price authorizationAmountField;

        private Price capturedAmountField;

        private Price authorizationFeeField;

        private IdList idListField;

        private DateTime creationTimestampField;

        private DateTime expirationTimestampField;

        private bool expirationTimestampFieldSpecified;

        private String addressVerificationCodeField;

        private Status authorizationStatusField;

        private string[] orderItemCategoriesField;

        private bool captureNowField;

        private string softDescriptorField;

        private bool softDeclineField;

        /// <remarks/>
        public string AmazonAuthorizationId
        {
            get
            {
                return this.amazonAuthorizationIdField;
            }
            set
            {
                this.amazonAuthorizationIdField = value;
            }
        }

        /// <remarks/>
        public string AuthorizationReferenceId
        {
            get
            {
                return this.authorizationReferenceIdField;
            }
            set
            {
                this.authorizationReferenceIdField = value;
            }
        }

        /// <remarks/>
        public Price AuthorizationAmount
        {
            get
            {
                return this.authorizationAmountField;
            }
            set
            {
                this.authorizationAmountField = value;
            }
        }

        /// <remarks/>
        public Price CapturedAmount
        {
            get
            {
                return this.capturedAmountField;
            }
            set
            {
                this.capturedAmountField = value;
            }
        }

        /// <remarks/>
        public Price AuthorizationFee
        {
            get
            {
                return this.authorizationFeeField;
            }
            set
            {
                this.authorizationFeeField = value;
            }
        }

        /// <remarks/>
        public IdList IdList
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

        /// <remarks/>
        [XmlIgnoreAttribute()]
        public bool ExpirationTimestampSpecified
        {
            get
            {
                return this.expirationTimestampFieldSpecified;
            }
            set
            {
                this.expirationTimestampFieldSpecified = value;
            }
        }

        /// <remarks/>
        public string AddressVerificationCode
        {
            get
            {
                return this.addressVerificationCodeField;
            }
            set
            {
                this.addressVerificationCodeField = value;
            }
        }

        /// <remarks/>
        public Status AuthorizationStatus
        {
            get
            {
                return this.authorizationStatusField;
            }
            set
            {
                this.authorizationStatusField = value;
            }
        }

        /// <remarks/>
        [XmlArrayItemAttribute("String", IsNullable = false)]
        public string[] OrderItemCategories
        {
            get
            {
                return this.orderItemCategoriesField;
            }
            set
            {
                this.orderItemCategoriesField = value;
            }
        }

        /// <remarks/>
        public bool CaptureNow
        {
            get
            {
                return this.captureNowField;
            }
            set
            {
                this.captureNowField = value;
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


        /// <remarks/>
        public bool SoftDecline
        {
            get
            {
                return this.softDeclineField;
            }
            set
            {
                this.softDeclineField = value;
            }
        }


    }
}