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

using OffAmazonPaymentsNotifications.Certificate;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Caching;
using OffAmazonPaymentsService;

namespace OffAmazonPaymentsNotifications
{
    /// <summary>
    /// Implementation of the sns signature algorithms using asp.net framework
    /// obejcts
    /// </summary>
    internal class VerifyDataAspImpl : IVerifyData
    {
        /// <summary>
        /// Cache key format string to avoid conflicts with other items in the application cache
        /// </summary>
        private const string CacheKey = "OffAmazonPaymentNotifciations:{0}";

        /// <summary>
        /// Verify that certificate is valid and issued by Amazon.
        /// </summary>
        /// <param name="snsMessage">URI path to public key certificate to hash the constructed data</param>
        public bool VerifyCertIsIssuedByAmazon(ICertificate cert)
        {
            return cert.VerifyCertificateChain() && VerifyCertificateSubject(cert.GetSubject());
        }

        private bool VerifyCertificateSubject(String subject) 
        {
            string[] subjectAttributeDelimiters = new string[] { ", " };
            string[] subjectAttributesArr = subject.Split(subjectAttributeDelimiters, StringSplitOptions.None);
            List<string> subjectAttributesList = convertSubjectAttributesArr(subjectAttributesArr);

            Dictionary<string, string> subjectAttributes = new Dictionary<string, string>();
            char[] keyValueDelimiter = { '=' };
            foreach (string subjectAttribute in subjectAttributesList) {

                string[] keyValuePair = subjectAttribute.Split(keyValueDelimiter, 2);
                string key = keyValuePair[0];
                string value = keyValuePair[1];

                if (subjectAttributes.ContainsKey(key)) {
                    // indicates certificate tampering, as we have an invalid subject with duplicate key types
                    return false;
                } else {
                    subjectAttributes.Add(key, value);
                }
            }
            return ContainsAttribute(subjectAttributes, "CN", OffAmazonPaymentsServicePropertyCollection.getInstance().CertCN);
        }

        private List<string> convertSubjectAttributesArr(string[] subjectAttributesArr)
        {
            // Because ', ' is the delimiter, the value "Amazon.com, Inc." will get delimited when splitting the string.
            // This algorithm will merge the two delimited strings "Amazon.com" and "Inc." back into "Amazon.com, Inc.".
            List<string> subjectAttributes = new List<string>();
            for (int i = 0; i < subjectAttributesArr.Length; i++) {
                string subjectAttribute = subjectAttributesArr[i];
                if (!subjectAttribute.Contains("=")) {
                    subjectAttributes[i - 1] = subjectAttributes[i - 1] + ", " + subjectAttribute;
                } else {
                    subjectAttributes.Add(subjectAttribute);
                }
            }

            return subjectAttributes;
        }

        private bool ContainsAttribute(Dictionary<string, string> subjectAttributes, string attributeKey, string attributeValue)
        {
            string actualValue;
            if (!subjectAttributes.TryGetValue(attributeKey, out actualValue)) {
                return false;
            }

            return actualValue == attributeValue;
        }

        /// <summary>
        /// Perform the comparison of the message data with the signature,
        /// as described on http://docs.aws.amazon.com/sns/latest/dg/SendMessageToHttp.verify.signature.html,
        /// for version 1 of the signature algorithm
        /// </summary>
        /// <param name="data">Byte data to compare using a SHA1 hash</param>
        /// <param name="signature">Decoded signature byte array</param>
        /// <param name="certPath">URI path to public key certificate to hash the constructed data</param>
        /// <returns>true if successful</returns>
        public bool VerifyMsgMatchesSignatureWithPublicCert(byte[] data, byte[] signature, ICertificate cert)
        {
            RSACryptoServiceProvider csp = (RSACryptoServiceProvider) cert.GetPublicKey();
            return csp.VerifyData(data, CryptoConfig.MapNameToOID("SHA1"), signature);
        }
    }	
}
