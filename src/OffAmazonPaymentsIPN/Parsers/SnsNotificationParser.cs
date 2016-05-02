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
using System.Collections.Specialized;

namespace OffAmazonPaymentsNotifications
{
    /// <summary>
    /// Class to convert a json string into a message that
    /// corresponds to an SNS notification
    /// </summary>
    internal class SnsNotificationParser
    {
        /// <summary>
        /// Error string for unknown notificaton type
        /// </summary>
        private const string UnexpectedMessageErrStr = "Error with sns notification - unexpected message with Type of {0}";

        /// <summary>
        /// Error string for missing sns header
        /// </summary>
        private const string MissingSnsHeaderErrStr = "Error with message - header does not contain x-amz-sns-message-type";

        /// <summary>
        /// Error string for invalid sns header
        /// </summary>
        private const string InvalidSnsHeaderErrStr = "Error with sns message - header x-amz-sns-message-type has value {0}, expected Notification";

        /// <summary>
        /// Error string for null header object
        /// </summary>
        private const string MissingHeadersErrStr = "Expected headers to be passed, null value received";

        /// <summary>
        /// Parse a json string in an sns format and convert it
        /// into a message object that stores key/value pairs
        /// </summary>
        /// <param name="headers">Sns headers</param>
        /// <param name="snsJson">Sns json string</param>
        /// <returns>Message</returns>
        public static Message ParseNotification(NameValueCollection headers, string snsJson)
        {
            ValidateHeader(headers);
            Message msg = new Message(snsJson);
            ValidateMessageType(msg);
            AddSnsNotificationMetadataToMessage(msg);
            return msg;
        }

        /// <summary>
        /// Check the sns headers to ensure that the notification
        /// is valid
        /// </summary>
        /// <param name="headers">Sns header collection</param>
        private static void ValidateHeader(NameValueCollection headers)
        {
            string messageType = null;

            try
            {
                messageType = headers["x-amz-sns-message-type"];
            }
            catch (NullReferenceException nre)
            {
                throw new NotificationsException(MissingHeadersErrStr, nre);
            }

            if (messageType == null)
            {
                throw new NotificationsException(MissingSnsHeaderErrStr);
            }

            if (!messageType.Equals("Notification", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new NotificationsException(String.Format(InvalidSnsHeaderErrStr, messageType));
            }
        }

        /// <summary>
        /// Ensure that the sns message is the valid notificaton type
        /// </summary>
        /// <param name="msg">SNS message</param>
        private static void ValidateMessageType(Message msg)
        {
            string notificatonType = msg.GetMandatoryField("Type");
            if (!notificatonType.Equals("Notification", StringComparison.InvariantCultureIgnoreCase))
            {
                throw new NotificationsException(String.Format(UnexpectedMessageErrStr, notificatonType));
            }
        }

        /// <summary>
        /// Add the notifciation metadata to the message
        /// </summary>
        /// <param name="msg">Message to add notification metadata to</param>
        private static void AddSnsNotificationMetadataToMessage(Message msg)
        {
            msg.Metadata = new SnsNotificationMetadata(msg);
        }
    }
}
