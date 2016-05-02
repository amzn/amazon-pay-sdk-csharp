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
    /// <summary>
    /// Notification metadata for the ipn message
    /// </summary>
    public class IpnNotificationMetadata : NotificationMetadata
    {
        /// <summary>
        /// Timestamp for when the notification was generated
        /// </summary>
        private DateTime _timestamp;

        /// <summary>
        /// Environment in which the notification was generated
        /// </summary>
        private string _releaseEnvironment;

        /// <summary>
        /// Identification for the reference id
        /// </summary>
        private string _notificationReferenceId;

        /// <summary>
        /// Creates a new ipn notification metadata object from 
        /// an ipn message
        /// </summary>
        /// <param name="ipnMessage">message conforming to ipn structure</param>
        /// <param name="snsNotificationMetadata">parent notification metadata</param>
        internal IpnNotificationMetadata(Message ipnMessage, INotificationMetadata parentNotificationMetadata)
            : base(parentNotificationMetadata)
        {
            this._timestamp = ipnMessage.GetMandatoryFieldAsDateTime("Timestamp");
            this._releaseEnvironment = ipnMessage.GetMandatoryField("ReleaseEnvironment");
            this._notificationReferenceId = ipnMessage.GetMandatoryField("NotificationReferenceId");
        }

        /// <summary>
        /// Timestamp for the ipn request
        /// </summary>
        public DateTime Timestamp
        {
            get { return this._timestamp; }
        }

        /// <summary>
        /// Notification reference id for the ipn request
        /// </summary>
        public string NotificationReferenceId
        {
            get { return this._notificationReferenceId; }
        }

        /// <summary>
        /// Release environment for the ipn request
        /// </summary>
        public string ReleaseEnvironment
        {
            get { return this._releaseEnvironment; }
        }

        /// <summary>
        /// Indicates the type of notification metadata
        /// </summary>
        /// <returns>Ipn for IpnNotificationMetadata</returns>
        protected override NotificationMetadataType GetNotificationMetadataType()
        {
            return NotificationMetadataType.Ipn;
        }
    }
}
