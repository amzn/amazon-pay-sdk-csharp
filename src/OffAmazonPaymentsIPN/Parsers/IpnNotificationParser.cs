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

namespace OffAmazonPaymentsNotifications
{
    /// <summary>
    /// This class is responsible for parsing the input data
    /// into a message the conforms to an Ipn message
    /// </summary>
    internal class IpnNotificationParser
    {
        /// <summary>
        /// Extract data from a message conforming to an sns message into
        /// an ipn message
        /// </summary>
        /// <param name="snsMessage">Message conforming to sns data structure</param>
        /// <returns>Message conforming to ipn data structure</returns>
        public static Message ParseSnsMessage(Message snsMessage)
        {
            Message msg = new Message(snsMessage.GetMandatoryField("Message"));
            msg.Metadata = new IpnNotificationMetadata(msg, snsMessage.Metadata);
            return msg;
        }
    }
}
