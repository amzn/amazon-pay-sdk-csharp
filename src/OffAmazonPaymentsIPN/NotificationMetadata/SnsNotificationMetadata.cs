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
    /// Metadata assocated with an sns message
    /// </summary>
    public class SnsNotificationMetadata : NotificationMetadata
    {
        /// <summary>
        /// Timestamp for when this notification was generated
        /// </summary>
        private DateTime _timestamp;

        /// <summary>
        /// Topic that the notification was generated from
        /// </summary>
        private string _topicArn;

        /// <summary>
        /// Message id for the notification
        /// </summary>
        private string _messageId;

        /// <summary>
        /// Create a new instance of the SnsNotificationMetadata
        /// from a message conforming to a sns message structure
        /// </summary>
        /// <param name="msg">Message conforming to an sns message structure</param>
        internal SnsNotificationMetadata(Message msg)
        {
            this._timestamp = msg.GetMandatoryFieldAsDateTime("Timestamp");
            this._topicArn = msg.GetMandatoryField("TopicArn");
            this._messageId = msg.GetMandatoryField("MessageId");
        }

        /// <summary>
        /// Timestamp for the SNS notification
        /// </summary>
        public DateTime Timestamp
        {
            get { return this._timestamp; }
        }

        /// <summary>
        /// Topic ARN that this sns notification was published to
        /// </summary>
        public string TopicArn
        {
            get { return this._topicArn; }
        }

        /// <summary>
        /// Message id for the SNS message
        /// </summary>
        public string MessageId
        {
            get { return this._messageId; }
        }

        /// <summary>
        /// Indicates the type of notification metadata
        /// </summary>
        /// <returns>SNS for SNSNotificationMetadata</returns>
        protected override NotificationMetadataType GetNotificationMetadataType()
        {
            return NotificationMetadataType.Sns;
        }

    }
}
