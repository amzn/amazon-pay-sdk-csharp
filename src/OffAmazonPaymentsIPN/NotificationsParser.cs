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

using System.Collections.Specialized;

namespace OffAmazonPaymentsNotifications
{
    /// <summary>
    /// Implemention of the notification parser for the
    /// OffAmazonPaymentsNotification system
    /// </summary>
    public class NotificationsParser : INotificationsParser
    {
        /// <summary>
        /// Instance of the sns message validator class
        /// </summary>
        private SnsMessageValidator _snsMessageValidator;

        /// <summary>
        /// Create a new instance of the parser class, using
        /// the ASP.NET message validator implementation
        /// </summary>
        public NotificationsParser()
        {
            ISnsSignatureVerification snsSignatureVerificationV1Impl = new SnsSignatureVerification(new VerifyDataAspImpl());
            this._snsMessageValidator = new SnsMessageValidator(snsSignatureVerificationV1Impl);
        }

        /// <summary>
        /// Convert a raw http POST request that contains an IPN and
        /// conver to an object
        /// 
        /// Will throw a NotificationsException if the content is not a
        /// valid IPN
        /// 
        /// Callers are expected to return a 503 http code an exception is
        /// thrown by this method, otherwise reply with a HTTP OK status
        /// </summary>
        /// <param name="headers">HTTP request headers</param>
        /// <param name="body">HTTP POST body content</param>
        /// <returns>Instance of an INotification that matches the notification type</returns>
        public INotification ParseRawMessage(NameValueCollection headers, string body)
        {
            Message snsMessage = SnsNotificationParser.ParseNotification(headers, body);
            this._snsMessageValidator.ValidateMessageIsTrusted(snsMessage);
            this._snsMessageValidator.ValidateCertUrl(snsMessage);
            Message ipnMsg = IpnNotificationParser.ParseSnsMessage(snsMessage);
            return XmlNotificationParser.ParseIpnMessage(ipnMsg);
        }
    }
}