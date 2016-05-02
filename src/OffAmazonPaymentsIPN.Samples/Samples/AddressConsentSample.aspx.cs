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

using OffAmazonPaymentsServiceSampleLibrary;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OffAmazonPaymentsService;
using OffAmazonPaymentsService.Model;
using System.IO;
using System.Xml;

namespace OffAmazonPaymentsNotifications.Samples.Samples
{
    public partial class PayWithAmazonAddressConsentExample : PaymentsNotificationSample
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handle the form submisson
        /// </summary>
        /// <param name="sender">reference to the sender</param>
        /// <param name="e">arguments for the event</param>
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string orderReferenceId = tb_ORId.Text;
            string accessToken = tb_AccessToken.Text;
            OffAmazonPaymentsAddressConsentSample addressConsentSample = new OffAmazonPaymentsAddressConsentSample(orderReferenceId);
            RunSample(accessToken, addressConsentSample);
        }

        private void RunSample(string accessToken, OffAmazonPaymentsAddressConsentSample addressConsentSample)
        {
            /*****************************************************************
             * Get the order reference details without address consent token
             *****************************************************************/
            String gorWithoutConsent = addressConsentSample.GetOrderReferenceDetailsWithoutConsent();
            if (gorWithoutConsent == null)
            {
                throw new OffAmazonPaymentsServiceException("The response from GetOrderReferenceDetailsWithoutConsent was null");
            }

            /******************************************************************
             * Get the order reference details with the consent token - this
             * response will contain additional information about the customer
             * comparsed to the previous response.
             * ****************************************************************/
            String gorWithConsent = addressConsentSample.GetOrderReferenceDetailsWithConsent(Server.UrlDecode(accessToken));
            if (gorWithConsent == null)
            {
                throw new OffAmazonPaymentsServiceException("The response from GetOrderReferenceDetailsWithoutConsent was null");
            }

            ltOrderDetailsNoConsent.Text += formatStringForDisplay(gorWithoutConsent);
            ltOrderDetailsWithConsent.Text += formatStringForDisplay(gorWithConsent);
        }
    }
}