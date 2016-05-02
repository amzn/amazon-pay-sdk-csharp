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
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Caching;

namespace OffAmazonPaymentsNotifications
{
    internal class CertificateFactory : ICertificateFactory
    {
        /// <summary>
        /// Cache key format string to avoid conflicts with other items in the application cache
        /// </summary>
        private const string CacheKey = "OffAmazonPaymentNotifciations:{0}";

        /// <summary>
        /// Check the application cache for the certificate, and use this if still
        /// valid
        /// If not found, request the cert and add to the cache with a timeout of 24 hours
        /// </summary>
        /// <param name="certPath">URI path to certificate</param>
        /// <returns>Instance of the x508 certificate</returns>
        ICertificate ICertificateFactory.GetCertificate(string certPath)
        {
            X509Certificate2 cert = null;
            try
            {
                cert = (X509Certificate2)HttpRuntime.Cache.Get(String.Format(CacheKey, certPath));
            }
            catch (HttpException ex)
            {
                throw new NotificationsException("Error requesting certificate", ex);
            }

            if (cert == null)
            {
                cert = GetCertificateFromURI(certPath);
                HttpRuntime.Cache.Insert(String.Format(CacheKey, certPath), cert, null, DateTime.UtcNow.AddDays(1.0), Cache.NoSlidingExpiration);
            }

            return new Certificate.Certificate(cert);
        }

        /// <summary>
        /// Request the certifcate from the given URI
        /// </summary>
        /// <param name="certPath">URI path to certificate</param>
        /// <returns>Instance of the x508 certificate</returns>
        private X509Certificate2 GetCertificateFromURI(string certPath)
        {
            WebClient wc = new WebClient();
            byte[] raw = wc.DownloadData(certPath);
            return new X509Certificate2(raw);
        }
    }
}
