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
    /// An IPN notification to indicate a change in status for an Authorization transaction
    /// </summary>
    public class AuthorizationNotification : Notification
    {
        /// <summary>
        /// Authorization details field
        /// </summary>
        private AuthorizationDetails _authorizationDetails;

        /// <summary>
        /// Creates a new instance of the Authorization Notification
        /// </summary>
        internal AuthorizationNotification()
            : base(NotificationType.AuthorizationNotification)
        {

        }

        /// <summary>
        /// Access the authorization details field
        /// </summary>
        public AuthorizationDetails AuthorizationDetails
        {
            get
            {
                return this._authorizationDetails;
            }
            set
            {
                this._authorizationDetails = value;
            }
        }
    }
}