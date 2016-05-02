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
using System.IO;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace OffAmazonPaymentsNotifications
{
    /// <summary>
    /// Wrapper around a decoded IPN notification message
    /// to create the notification objects
    /// </summary>
    internal class XmlNotificationParser
    {
        /// <summary>
        /// Error message for unknown notification type
        /// </summary>
        private const string UnknownNotificationTypeErrMsg = "Error with ipn notification - unknown notification type: {0}";

        /// <summary>
        /// Error message for invalid xml
        /// </summary>
        private const string InvalidXmlErrMsg = "Error with ipn message - NotificationData field does not contain valid xml, contents: {0}";

        /// <summary>
        /// Create an instance of the IPN notification that represents the
        /// xml contained within the ipn message structure
        /// </summary>
        /// <param name="ipnMessage">IPN message, containing the xml in the NotificationData field</param>
        /// <throws>NotificationsException if the message is not an ipn message, or if the xml cannot be constructed</throws>
        /// <returns>Instance of INotification</returns>
        public static INotification ParseIpnMessage(Message ipnMessage)
        {
            string notificationData = ipnMessage.GetMandatoryField("NotificationData");
            string notificationType = ipnMessage.GetMandatoryField("NotificationType");
            Type type = null;

            switch (notificationType)
            {
                case "OrderReferenceNotification":
                    type = typeof(OrderReferenceNotification);
                    break;
                case "PaymentAuthorize":
                    type = typeof(AuthorizationNotification);
                    break;
                case "PaymentCapture":
                    type = typeof(CaptureNotification);
                    break;
                case "PaymentRefund":
                    type = typeof(RefundNotification);
                    break;
                case "ProviderCredit":
                    type = typeof(ProviderCreditNotification);
                    break;
                case "ProviderCreditReversal":
                    type = typeof(ProviderCreditReversalNotification);
                    break;
                case "SolutionProviderEvent":
                    type = typeof(SolutionProviderMerchantNotification);
                    break;
                case "BillingAgreementNotification":
                    type = typeof(BillingAgreementNotification);
                    break;
                default:
                    throw new NotificationsException(String.Format(UnknownNotificationTypeErrMsg, notificationType));
            }

            Notification notification = null;

            try
            {
                XmlSerializer serializer = new XmlSerializer(type, GetXmlRootAttribute(notificationData));
                notification = (Notification)serializer.Deserialize(new StringReader(notificationData));
                notification.NotificationMetadata = ipnMessage.Metadata;
            }
            catch (Exception ex)
            {
                throw new NotificationsException(String.Format(InvalidXmlErrMsg, notificationData), ex);
            }

            return notification;
        }

        /// <summary>
        /// Get the name of the xml root element from the payload
        /// We do not perform validation against a schema but we
        /// need to have the xml strongly typed against a namespace
        /// </summary>
        /// <param name="xml">xml string</param>
        /// <returns>Namespace</returns>
        private static XmlRootAttribute GetXmlRootAttribute(string xml)
        {
            XmlRootAttribute xRoot = new XmlRootAttribute();
            Regex regex = new Regex("xmlns=\"(.*)\">");
            Match match = regex.Match(xml);
            xRoot.Namespace = match.Groups[1].Value;

            return xRoot;
        }
    }
}
