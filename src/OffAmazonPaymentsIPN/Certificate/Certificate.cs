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
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace OffAmazonPaymentsNotifications.Certificate
{
    internal class Certificate : ICertificate
    {
        private X509Certificate2 _x509Cert;

        public Certificate(X509Certificate2 x509Cert)
        {
            this._x509Cert = x509Cert;
        }

        /// <summary>
        /// Performs certificate chain validation using basic validation policy
        /// </summary>
        public bool VerifyCertificateChain()
        {
            return _x509Cert.Verify();
        }

        /// <summary>
        /// Gets certificate's subject information
        /// </summary>
        public String GetSubject()
        {
            return _x509Cert.Subject;
        }

        /// <summary>
        /// Gets AsymmetricAlgorithm representing the certificate's public key
        /// </summary>
        public AsymmetricAlgorithm GetPublicKey()
        {
            return _x509Cert.PublicKey.Key;
        }
    }
}
