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

namespace OffAmazonPaymentsNotifications.Certificate
{
    internal interface ICertificate
    {
        /// <summary>
        /// Performs certificate chain validation using basic validation policy
        /// </summary>
        bool VerifyCertificateChain();

        /// <summary>
        /// Gets certificate's subject information
        /// </summary>
        String GetSubject();

        /// <summary>
        /// Gets AsymmetricAlgorithm representing the certificate's public key
        /// </summary>
        AsymmetricAlgorithm GetPublicKey();
    }
}
