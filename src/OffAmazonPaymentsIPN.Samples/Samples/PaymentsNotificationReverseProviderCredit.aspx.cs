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

using OffAmazonPaymentsService.Model;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OffAmazonPaymentsNotifications.Samples;
using OffAmazonPaymentsServiceSampleLibrary;

namespace OffAmazonPaymentsNotifications.Samples
{
    /// <summary>
    /// Code behind file to invoke and run the reverse provider credit reference sample
    /// </summary>
    public partial class PaymentsNotificationReverseProviderCredit : PaymentsNotificationSample
    {
        private OffAmazonPaymentsServiceReverseProviderCredit _reverseProviderCredit;

        /// <summary>
        /// Setup variables that are specific to the page
        /// </summary>
        /// <param name="sender">Reference to the source of this event</param>
        /// <param name="e">arguments for the event</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this._reverseProviderCredit = new OffAmazonPaymentsServiceReverseProviderCredit();
        }

        /// <summary>
        /// Handle the form submisson
        /// </summary>
        /// <param name="sender">reference to the sender</param>
        /// <param name="e">arguments for the event</param>
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string amazonProviderCreditId = tb_ProiverCreditId.Text.Trim();
            string creditReversalAmount = tb_CreditReversalAmt.Text.Trim();
            RunSample(amazonProviderCreditId, creditReversalAmount);
        }

        /// <summary>
        /// Execute the sample, using the given arguments as parameters for the scenario
        /// 
        /// The sample executes the reverse provider credit against the provider credit and verifies that the
        /// provider credit reversal has been performed through waiting for a ProviderCreditReversel payment notification
        /// </summary>
        /// <param name="amazonProviderCreditId">Amazon Provider Credit Id from the provider credit transaction to perform the reverse provider credit against</param>
        /// <param name="creditReversalAmount">Amount to reverse credit for</param>
        private void RunSample(string amazonProviderCreditId, string creditReversalAmount)
        {
            /************************************************************************
            * Invoke Reverse Provider Credit Action
            ***********************************************************************/
            ReverseProviderCreditResponse reverseProviderCreditResponse = this._reverseProviderCredit.ReverseProviderCreditAction(amazonProviderCreditId, creditReversalAmount);
            if (reverseProviderCreditResponse == null)
            {
                throw new Exception("The response from Reverse Provider Credit request is null");
            }

            /************************************************************************
             * Wait for the provider credit reversal notification to arrive and display it to the user
             ***********************************************************************/
            lblNotification.Text += WaitAndGetNotificationDetails(reverseProviderCreditResponse.ReverseProviderCreditResult.ProviderCreditReversalDetails.AmazonProviderCreditReversalId + "_ProviderCreditReversal");
        }
    }
}