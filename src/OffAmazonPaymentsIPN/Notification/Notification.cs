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

using System.Xml.Serialization;

namespace OffAmazonPaymentsNotifications
{
    /// <summary>
    /// Abstract implementation of the notification interface
    /// encapulates the common properties of all notifications
    /// </summary>
    public abstract class Notification : INotification
    {
        /// <summary>
        /// Metadata associated with this notification
        /// </summary>
        private INotificationMetadata _notificationMetadata;

        /// <summary>
        /// The type of notification
        /// </summary>
        private NotificationType _notificationType;

        /// <summary>
        /// Create a new typed notification instance
        /// </summary>
        /// <param name="type">Notification type</param>
        internal Notification(NotificationType type)
        {
            this._notificationMetadata = null;
            this._notificationType = type;
        }

        /// <summary>
        /// Indicates what type of notification is implementing
        /// this interface
        /// </summary>
        public NotificationType NotificationType
        {
            get { return this._notificationType; }
        }

        /// <summary>
        /// Reference to the metadata that is associated with
        /// this notification
        /// </summary>
        [XmlIgnore]
        public INotificationMetadata NotificationMetadata
        {
            get { return this._notificationMetadata; }
            internal set { this._notificationMetadata = value; }
        }
    }
}
