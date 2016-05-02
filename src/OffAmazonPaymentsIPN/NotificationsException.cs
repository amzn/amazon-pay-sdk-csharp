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

namespace OffAmazonPaymentsNotifications
{
    /// <summary>
    /// Exception class for the OffAmazonPaymentsNotification
    /// library
    /// </summary>
    public class NotificationsException : Exception
    {
        /// <summary>
        /// Create a new notifications exception instance
        /// with a descriptive error message
        /// </summary>
        /// <param name="message">Cause of the error</param>
        public NotificationsException(string message)
            : base(message)
        {
        
        }

        /// <summary>
        /// Create a new notifications exception instance
        /// that wraps an inner exception with a error message
        /// </summary>
        /// <param name="message">Description of the error</param>
        /// <param name="innerException">Exception that caused this error</param>
        public NotificationsException(string message, Exception innerException)
            : base(message, innerException)
        {
        }   
    }
}
