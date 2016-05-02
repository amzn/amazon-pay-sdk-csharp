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

namespace OffAmazonPaymentsNotifications
{
    /// <summary>
    /// An IPN notification to indicate a change in status for a ProviderCreditReversal transaction
    /// </summary>
    public class ProviderCreditReversalNotification : Notification
    {
        /// <summary>
        /// ProviderCreditReversal details
        /// </summary>
        private ProviderCreditReversalDetails _providerCreditReversalDetails;

        /// <summary>
        /// Creates a new instance of the ProviderCreditReversal Notification
        /// </summary>
        /// <param name="metadata">NotificationMetadata associated with this request</param>
        internal ProviderCreditReversalNotification()
            : base(NotificationType.ProviderCreditReversalNotification)
        {
            
        }

        /// <summary>
        /// Access the ProviderCreditReversal details field
        /// </summary>
        public ProviderCreditReversalDetails ProviderCreditReversalDetails
        {
            get
            {
                return this._providerCreditReversalDetails;
            }
            set
            {
                this._providerCreditReversalDetails = value;
            }
        }
    }
}