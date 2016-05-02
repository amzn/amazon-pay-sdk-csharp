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
    /// An IPN notification to indicate a change in status for a  ProviderCredit transaction
    /// </summary>
    public class ProviderCreditNotification : Notification
    {
        /// <summary>
        /// ProviderCredit details
        /// </summary>
        private ProviderCreditDetails _providerCreditDetails;

        /// <summary>
        /// Creates a new instance of the ProviderCredit Notification
        /// </summary>
        /// <param name="metadata">NotificationMetadata associated with this request</param>
        internal ProviderCreditNotification()
            : base(NotificationType.ProviderCreditNotification)
        {
            
        }

        /// <summary>
        /// Access the ProviderCredit details field
        /// </summary>
        public ProviderCreditDetails ProviderCreditDetails
        {
            get
            {
                return this._providerCreditDetails;
            }
            set
            {
                this._providerCreditDetails = value;
            }
        }
    }
}