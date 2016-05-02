
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
using System.Security.Cryptography.X509Certificates;
using System.Text;
using OffAmazonPaymentsNotifications.Certificate;

namespace OffAmazonPaymentsNotifications
{
    /// <summary>
    /// Implements the environment indepent portion of the
    /// signature verification
    /// </summary>
    internal class SnsSignatureVerification : ISnsSignatureVerification
    {
        /// <summary>
        /// Contains environment specific signature verification functions
        /// </summary>
        private IVerifyData _verifyData;

        /// <summary>
        /// Factory for getting certificates from URIs
        /// </summary>
        private ICertificateFactory _certificateFactory;

        /// <summary>
        /// Format string for ipn timestamps, in ISO8601 format with millseconds, in UTC
        /// </summary>
        private const string Iso8601UTCDateWithMillisecondsFormatString = @"yyyy-MM-ddTHH:mm:ss.fffZ";

        /// <summary>
        /// Error string for unknown notification type
        /// </summary>
        private const string UnknownNotificationError
            = "Error with sns message verification - message is not of type Notification, no implementation of signing algorithm is present for other notification types";

        /// <summary>
        /// Error string for unknown notification type
        /// </summary>
        private const string InvalidCertificateError
            = "Error with sns message verification - certificate in Notification is not a valid certificate issued to Amazon";

        /// <summary>
        /// Create a new instance of the sns signature verification,
        /// using an implementation of the data verification interface
        /// </summary>
        /// <param name="verifyData">Data verification implementation</param>
        public SnsSignatureVerification(IVerifyData verifyData) : this(verifyData, new CertificateFactory())
        {
        }

        /// <summary>
        /// Create a new instance of the sns signature verification,
        /// using an implementation of the data verification interface
        /// </summary>
        /// <param name="verifyData">Data verification implementation</param>
        /// /// <param name="certificateFactory">Certificate factory implementation</param>
        public SnsSignatureVerification(IVerifyData verifyData, ICertificateFactory certificateFactory)
        {
            this._verifyData = verifyData;
            this._certificateFactory = certificateFactory;
        }

        /// <summary>
        /// Perform the comparison of the message data with the signature,
        /// as described on http://docs.aws.amazon.com/sns/latest/dg/SendMessageToHttp.verify.signature.html,
        /// for version 1 of the signature algorithm
        /// </summary>
        /// <param name="snsMessage">Sns message with metadata</param>
        /// <returns>true if verified, otherwise false</returns>
        public bool VerifyMsgMatchesSignatureV1WithCert(Message snsMessage)
        {
            if (!snsMessage.GetMandatoryField("Type").Equals("Notification"))
            {
                throw new NotificationsException(UnknownNotificationError);
            }

            string certPath = snsMessage.GetMandatoryField("SigningCertURL");
            ICertificate cert = _certificateFactory.GetCertificate(certPath);
            if (!this._verifyData.VerifyCertIsIssuedByAmazon(cert))
            {
                throw new NotificationsException(InvalidCertificateError);
            }

            UTF8Encoding encoding = new UTF8Encoding();
            string msg = GetMessageToSign(snsMessage);
            byte[] data = encoding.GetBytes(msg);

            // Server signature uses base 64 encoding, must desconstruct
            byte[] decodedSignature = Convert.FromBase64String(snsMessage.GetMandatoryField("Signature"));

            return this._verifyData.VerifyMsgMatchesSignatureWithPublicCert(data, decodedSignature, cert);
        }

        /// <summary>
        /// Extract the contents of the message and build a string to hash in
        /// order to verify the signature
        /// 
        /// Expected string is a single string in format field name\n field value\n, with the field names in alphabetical byte order (e.g. A-Za-z)
        /// notification use the Message, MessageId, Subject if provided, Timestamp, TopicArn & Type fields
        /// </summary>
        /// <param name="snsMessage">Sns message with metadata</param>
        /// <returns>Signature comparison string, unhashed</returns>
        private static string GetMessageToSign(Message snsMessage)
        {
            StringBuilder builder = new StringBuilder();
           
            builder.Append("Message\n");
            builder.Append(snsMessage.GetMandatoryField("Message"));
            builder.Append("\n");
            builder.Append("MessageId\n");
            builder.Append(snsMessage.GetMandatoryField("MessageId"));
            builder.Append("\n");
            String subject = snsMessage.GetField("Subject");
            if (subject != null)
            {
                builder.Append("Subject\n");
                builder.Append(subject);
                builder.Append("\n");
            }
            builder.Append("Timestamp\n");
            builder.Append(snsMessage.GetMandatoryFieldAsDateTime("Timestamp")
                .ToString(Iso8601UTCDateWithMillisecondsFormatString, System.Globalization.CultureInfo.InvariantCulture));
            builder.Append("\n");
            builder.Append("TopicArn\n");
            builder.Append(snsMessage.GetMandatoryField("TopicArn"));
            builder.Append("\n");
            builder.Append("Type\n");
            builder.Append(snsMessage.GetMandatoryField("Type"));
            builder.Append("\n");

            return builder.ToString();
        }
    }
}
