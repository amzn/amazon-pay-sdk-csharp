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
    /// Parent class for common functionality across all notification metadata
    /// implementations
    /// </summary>
    public abstract class NotificationMetadata : INotificationMetadata
    {
        /// <summary>
        /// Parent notification metadata if applicable, otherwise null
        /// </summary>
        private INotificationMetadata _parentNotificationMetadata = null;

        /// <summary>
        /// Initialize the common fields of the parent class
        /// Default contructor - all overloaded constructors should call this first
        /// </summary>
        public NotificationMetadata()
        {
        }

        /// <summary>
        /// Extend the base constructor and initialisze the parent notification metadata parameter
        /// </summary>
        /// <param name="parentNotificationMetadata">parent message information null if not applicable</param>
        public NotificationMetadata(INotificationMetadata parentNotificationMetadata) : this()
        {
            this._parentNotificationMetadata = parentNotificationMetadata;
        }

        /// <summary>
        /// Stores a reference to the parent notification metadata type
        /// if defined, otherwise is null
        /// </summary>
        public INotificationMetadata ParentNotificationMetadata
        {
            get { return this._parentNotificationMetadata; }
        }

        /// <summary>
        /// Indicates the type of the implementation notification
        /// metadata
        /// </summary>
        public NotificationMetadataType NotificationMetadataType
        {
            get { return this.GetNotificationMetadataType(); }
        }

        /// <summary>
        /// Indicates the type of notification metadata
        /// </summary>
        /// <returns>NotificationMetadataType</returns>
        protected abstract NotificationMetadataType GetNotificationMetadataType();
    }
}
