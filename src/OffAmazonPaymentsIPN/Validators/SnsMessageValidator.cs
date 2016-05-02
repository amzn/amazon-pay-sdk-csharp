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
using System.Text.RegularExpressions;

namespace OffAmazonPaymentsNotifications
{
    /// <summary>
    /// Class is responsible for performing SNS recommended validations
    /// </summary>
    internal class SnsMessageValidator
    {
        /// <summary>
        /// Error format string for unknown signature verification message
        /// </summary>
        private const string UnknownSignatureVerificationVersionErrStr
            = "Error with sns message verification - message is signed with unknown signature specification {0}";

        /// <summary>
        /// Error format string for failing signature verification
        /// </summary>
        private const string SignatureVerificationFailedErrString
            = "Error with sns message - signature verification v{0} failed for message id {1}, topicArn {2}";

        /// <summary>
        /// Instance of the signature verification algorithm to use
        /// </summary>
        private ISnsSignatureVerification _snsSignatureVerification;

        /// <summary>
        /// Create a new instance of the sns message validator class, using the
        /// injected validation algorithm to verify the message signature
        /// </summary>
        /// <param name="snsSignatureVerification">Instance of the signature verification instance</param>
        public SnsMessageValidator(ISnsSignatureVerification snsSignatureVerification)
        {
            this._snsSignatureVerification = snsSignatureVerification;
        }

        /// <summary>
        /// Verifies that the signing certificate url is from a recognizable source. 
        /// Returns the cert url if it cen be verified, otherwise throws an exception.
        /// </summary>
        /// <param name="certUrl"></param>
        /// <returns></returns>
        public void ValidateCertUrl(Message snsMessage)
        {
            string signingCertURL = snsMessage.GetMandatoryField("SigningCertURL");
            bool isValidUrl = false;
            var uri = new Uri(signingCertURL);

            if (uri.Scheme == "https" && signingCertURL.EndsWith(".pem", StringComparison.Ordinal))
            {
                const string pattern = @"^sns\.[a-zA-Z0-9\-]{3,}\.amazonaws\.com(\.cn)?$";
                var regex = new Regex(pattern);
                if (!regex.IsMatch(uri.Host))
                {
                    isValidUrl = false;
                }
                else
                {
                    isValidUrl = true;
                }
            }
            if(!isValidUrl)
            {
                throw new NotificationsException("Signing certificate url is not from a recognised source.");
            }

        }

        /// <summary>
        /// Validate this sns message by comparing the signature to
        /// the one consturcted on the client side to see if they match
        /// </summary>
        /// <param name="snsMessage">Sns message with metadata</param>
        public void ValidateMessageIsTrusted(Message snsMessage)
        {
            string signatureVersion = snsMessage.GetMandatoryField("SignatureVersion");
            switch (signatureVersion)
            {
                case "1":
                    VerifySnsMessageWithVersion1SignatureAlgorithm(snsMessage);
                    break;
                default:
                    throw new NotificationsException(String.Format(UnknownSignatureVerificationVersionErrStr, signatureVersion));
            }
        }

        /// <summary>
        /// Invoke the version 1 signature algorithm and throw an exception if
        /// it fails
        /// </summary>
        /// <param name="snsMessage">Sns message to verify</param>
        private void VerifySnsMessageWithVersion1SignatureAlgorithm(Message snsMessage)
        {
            bool isValid = this._snsSignatureVerification.VerifyMsgMatchesSignatureV1WithCert(snsMessage);
            if (!isValid)
            {
                SnsNotificationMetadata metadata = (SnsNotificationMetadata)snsMessage.Metadata;
                throw new NotificationsException(String.Format(SignatureVerificationFailedErrString, "1", metadata.MessageId, metadata.TopicArn));
            }
        }
    }
}