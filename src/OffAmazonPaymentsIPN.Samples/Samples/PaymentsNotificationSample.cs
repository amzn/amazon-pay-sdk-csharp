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
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Web.UI.WebControls;

namespace OffAmazonPaymentsNotifications.Samples
{
    public abstract class PaymentsNotificationSample : System.Web.UI.Page
    {
        public string WaitAndGetNotificationDetails (string notificationType)
        {
            while (Cache[notificationType] == null)
            {
                System.Threading.Thread.Sleep(2000);
            }
            string result = Cache[notificationType].ToString().Replace("\n", "<br>");
            Cache.Remove(notificationType);
            
            return result;
        }

        protected String formatStringForDisplay(string rawString)
        {
            StringBuilder builder = new StringBuilder();
            
            builder.Append("<pre>");
            builder.Append(rawString);
            builder.Append("</pre>");

            return builder.ToString();
        }
    }
}
