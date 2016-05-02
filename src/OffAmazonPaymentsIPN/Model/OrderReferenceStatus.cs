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
    public class OrderReferenceStatus
    {

        private String stateField;

        private DateTime lastUpdateTimestampField;

        private string reasonCodeField;

        private string reasonDescriptionField;

        /// <remarks/>
        public String State
        {
            get
            {
                return this.stateField;
            }
            set
            {
                this.stateField = value;
            }
        }

        /// <remarks/>
        public DateTime LastUpdateTimestamp
        {
            get
            {
                return this.lastUpdateTimestampField;
            }
            set
            {
                this.lastUpdateTimestampField = value;
            }
        }

        /// <remarks/>
        public string ReasonCode
        {
            get
            {
                return this.reasonCodeField;
            }
            set
            {
                this.reasonCodeField = value;
            }
        }

        /// <remarks/>
        public string ReasonDescription
        {
            get
            {
                return this.reasonDescriptionField;
            }
            set
            {
                this.reasonDescriptionField = value;
            }
        }
    }
}