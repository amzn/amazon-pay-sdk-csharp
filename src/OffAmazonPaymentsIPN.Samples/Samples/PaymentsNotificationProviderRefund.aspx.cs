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
using OffAmazonPaymentsService;
using OffAmazonPaymentsServiceSampleLibrary;


namespace OffAmazonPaymentsNotifications.Samples
{
    /// <summary>
    /// Code behind file to invoke and run the refund reference sample
    /// </summary>
    public partial class PaymentsNotificationProviderRefund : PaymentsNotificationSample
    {
        private OffAmazonPaymentsServiceProviderRefund _providerRefund;

        /// <summary>
        /// Setup variables that are specific to the page
        /// </summary>
        /// <param name="sender">Reference to the source of this event</param>
        /// <param name="e">arguments for the event</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this._providerRefund = new OffAmazonPaymentsServiceProviderRefund();
        }

        /// <summary>
        /// Handle the form submisson
        /// </summary>
        /// <param name="sender">reference to the sender</param>
        /// <param name="e">arguments for the event</param>
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            string amazonCaptureId = tb_CapId.Text.Trim();
            string refundAmount = tb_RefundAmt.Text.Trim();
            string providerId = tb_ProviderId.Text;
            string creditReversalAmount = tb_CreditReversalAmount.Text;
            RunSample(amazonCaptureId, refundAmount, providerId, creditReversalAmount);
        }


        /// <summary>
        /// Execute the sample, using the given arguments as parameters for the scenario
        /// 
        /// The sample executes the refund against the capture and verifies that the
        /// refund has been performed through waiting for a refund payment notification
        /// </summary>
        /// <param name="amazonCaptureId">Amazon Capture Id for the capture transaction to perform the refund against</param>
        /// <param name="refundAmount">Amount to refund to the customer</param>
        /// <param name="providerId">Provider Id for whom credit reversal is needed</param>
        /// <param name="creditReversalAmount">Credit Amount to reverse from the provider</param>
        private void RunSample(string amazonCaptureId, string refundAmount, string providerId, string creditReversalAmount)
        {
            /************************************************************************
            * Invoke Refund Action
            ***********************************************************************/
            RefundResponse refundResponse = this._providerRefund.RefundActionWithProviderCreditReversal(amazonCaptureId, refundAmount, providerId, creditReversalAmount);
            if (refundResponse == null)
            {
                throw new Exception("The response from Refund request is null");
            }
            /************************************************************************
             * Wait for the refund notification to arrive and display it to the user
             ***********************************************************************/
            lblNotification.Text += WaitAndGetNotificationDetails(refundResponse.RefundResult.RefundDetails.AmazonRefundId + "_Refund");

            /************************************************************************
            * Invoke Get Refund Details Action
            ***********************************************************************/
            GetRefundDetailsResponse getRefundDetailsResponse = this._providerRefund.GetRefundDetails(refundResponse);
            if (getRefundDetailsResponse == null)
                throw new OffAmazonPaymentsServiceException("The response from GetRefundDetails Response request is null");
            
            /************************************************************************
            * Invoke Get Provider Credit Reversal Details Action after getting ipn
            ***********************************************************************/
            if (!String.IsNullOrEmpty(providerId) && !String.IsNullOrEmpty(creditReversalAmount))
            {

                foreach (OffAmazonPaymentsService.Model.ProviderCreditReversalSummary providerCreditReversalSummary in getRefundDetailsResponse.GetRefundDetailsResult.RefundDetails.ProviderCreditReversalSummaryList.member)
                {
                    /************************************************************************
                    * Wait for the notification from ipn.aspx page in a loop, then print the corresponding information
                    ***********************************************************************/
                    lblNotification.Text += formatStringForDisplay(WaitAndGetNotificationDetails(providerCreditReversalSummary.ProviderCreditReversalId + "_ProviderCreditReversal"));
                    GetProviderCreditReversalDetailsResponse getProviderCreditReversalDetailsResponse = this._providerRefund.GetProviderCreditReversalDetails(providerCreditReversalSummary);
                    if (getProviderCreditReversalDetailsResponse == null)
                        throw new OffAmazonPaymentsServiceException("The response from GetProviderCreditReversalDetails request is null for ProviderCreditReversalId:" + providerCreditReversalSummary.ProviderCreditReversalId);
                }
            }
        }
    }
}
