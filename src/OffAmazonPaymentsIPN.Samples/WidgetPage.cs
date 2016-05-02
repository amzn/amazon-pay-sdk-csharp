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
using OffAmazonPaymentsService;

namespace OffAmazonPaymentsNotifications.Samples
{
    public class WidgetPage : System.Web.UI.Page
    {
        private string merchantId;
        private string javascriptInclude;
        private string clientId;


        public string JavascriptInclude
        {
            get { return javascriptInclude; }
            set { javascriptInclude = value; }
        }

        public string MerchantId
        {
            get { return merchantId; }
            set { merchantId = value; }
        }

        public string ClientId
        {
            get { return clientId; }
            set { clientId = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            OffAmazonPaymentsServicePropertyCollection props = OffAmazonPaymentsServicePropertyCollection.getInstance();
            this.javascriptInclude = props.WidgetUrl;
            this.merchantId = props.MerchantID;
            this.clientId = props.ClientId;
        }
    }
}