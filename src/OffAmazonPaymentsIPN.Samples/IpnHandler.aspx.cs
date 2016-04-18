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
using System.Configuration;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace OffAmazonPaymentsNotifications.Samples
{
    public partial class IpnHandler : System.Web.UI.Page
    {
        /// <summary>
        /// Location of the log file
        /// </summary>
        private string _logFile = null;

        /// <summary>
        /// Setup the log file from the app settings file
        /// </summary>
        public IpnHandler()
        {
            string dir = ConfigurationManager.AppSettings["logPath"];
            if (Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            this._logFile =  dir + "logfile.txt";
        }

        /// <summary>
        /// Read in the HTTP POST request on page load
        /// </summary>
        /// <param name="sender">Sender of this event</param>
        /// <param name="e">Event params</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Stream s = Request.InputStream;
                StreamReader sr = new StreamReader(s);
                string json = sr.ReadToEnd();
                NameValueCollection headers = Request.Headers;

                if (json != null)
                {
                    Convert(headers, json);
                }
            }
            catch (NotificationsException ex)
            {
                this.Response.StatusCode = 503;
                Response.StatusDescription = "Service Unavailable";
                WriteLog(ex.Message);
            }
        }

        /// <summary>
        /// Parse the notification
        /// </summary>
        /// <param name="headers">POST request headers</param>
        /// <param name="json">POST body content</param>
        private void Convert(NameValueCollection headers, string json)
        {
            NotificationsParser client = new NotificationsParser();
            INotification notification = client.ParseRawMessage(headers, json);
            string notificationStr = ConvertNotificationToString(notification);
            WriteLog(notificationStr);
            PlaceNotificationInApplicationCache(notification, notificationStr);
        }

        /// <summary>
        /// Convert a notification to an xml string
        /// </summary>
        /// <param name="notification">Notification object</param>
        /// <returns>string representation of the notification</returns>
        public string ConvertNotificationToString(INotification notification)
        {
            StringBuilder xmlStringBuilder = new StringBuilder();
            using (StringWriter fs = new StringWriter(xmlStringBuilder))
            {
                fs.WriteLine("LOG AT " + DateTime.Now);

                fs.WriteLine("NOTIFICATION_TYPE: " + notification.NotificationType);
                IpnNotificationMetadata metadata = (IpnNotificationMetadata)notification.NotificationMetadata;
                fs.WriteLine("NOTIFICATION_METADATA_TIMESTAMP: " + metadata.Timestamp);
                fs.WriteLine("NOTIFICATION_METADATA_NotificationReferenceId: " + metadata.NotificationReferenceId);
                fs.WriteLine("NOTIFICATION_METADATA_ReleaseEnvironment: " + metadata.ReleaseEnvironment);
                fs.WriteLine(); 

                new XmlSerializer(notification.GetType()).Serialize(fs, notification);
                return xmlStringBuilder.ToString();
            }
        }

        /// <summary>
        /// Write the notification to the log file
        /// </summary>
        /// <param name="headers"></param>
        /// <param name="notification"></param>
        public void WriteLog(String notification)
        {
            FileMode fileMode = File.Exists(this._logFile) ? FileMode.Append : FileMode.CreateNew;
            using (FileStream file = new FileStream(this._logFile, fileMode))
            {
                using (StreamWriter sr = new StreamWriter(file))
                {
                    
                    sr.WriteLine(notification);
                    sr.WriteLine();
                }
            }
        }

        /// <summary>
        /// Place the notification details into the application wide cache
        /// </summary>
        /// <param name="notification">Notification object</param>
        /// <param name="xmlString">String representation of the object</param>
        private void PlaceNotificationInApplicationCache(INotification notification, string xmlString)
        {
            String key = null;
            switch(notification.NotificationType)
            {
                case NotificationType.AuthorizationNotification:
                    string authId = ((AuthorizationNotification)notification).AuthorizationDetails.AmazonAuthorizationId;
                    key = authId + "_Authorize";
                    break;
                case NotificationType.CaptureNotification:
                    string captureId = ((CaptureNotification)notification).CaptureDetails.AmazonCaptureId;
                    key = captureId + "_Capture";
                    break;
                case NotificationType.OrderReferenceNotification:
                    string ORId = ((OrderReferenceNotification)notification).OrderReference.AmazonOrderReferenceId;
                    key = ORId + "_OrderReference";
                    break;
                case NotificationType.RefundNotification:
                    string refundId = ((RefundNotification)notification).RefundDetails.AmazonRefundId;
                    key = refundId + "_Refund";
                    break;
                case NotificationType.ProviderCreditNotification:
                    string providerCreditId = ((ProviderCreditNotification)notification).ProviderCreditDetails.AmazonProviderCreditId;
                    key = providerCreditId + "_ProviderCredit";
                    break;
                case NotificationType.ProviderCreditReversalNotification:
                    string providerCreditReversalId = ((ProviderCreditReversalNotification)notification).ProviderCreditReversalDetails.AmazonProviderCreditReversalId;
                    key = providerCreditReversalId + "_ProviderCreditReversal";
                    break;
                case NotificationType.SolutionProviderMerchantNotification:
                    string sellerId = ((SolutionProviderMerchantNotification)notification).MerchantRegistrationDetails.SellerId;
                    key = sellerId + "_SolutionProviderMerchant";
                    break;
                case NotificationType.BillingAgreementNotification:
                    string BAId = ((BillingAgreementNotification)notification).BillingAgreement.AmazonBillingAgreementId;
                    key = BAId + "_BillingAgreement";
                    break;
                default:
                    return;
            }

            if (key != null)
            {
                Cache[key] = xmlString;
                WriteLog("Test: " + key);
            }
        }
    }
}
