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
    /// Code behind file to invoke and run the refund reference sample
    /// </summary>
    public partial class PaymentsNotificationRefund : PaymentsNotificationSample
    {
        private OffAmazonPaymentsServiceRefund _refund;

        /// <summary>
        /// Setup variables that are specific to the page
        /// </summary>
        /// <param name="sender">Reference to the source of this event</param>
        /// <param name="e">arguments for the event</param>
        protected void Page_Load(object sender, EventArgs e)
        {
            this._refund = new OffAmazonPaymentsServiceRefund();
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
            RunSample(amazonCaptureId, refundAmount);
        }

        /// <summary>
        /// Execute the sample, using the given arguments as parameters for the scenario
        /// 
        /// The sample executes the refund against the capture and verifies that the
        /// refund has been performed through waiting for a refund payment notification
        /// </summary>
        /// <param name="amazonCaptureId">Amazon Capture Id for the capture transaction to perform the refund against</param>
        /// <param name="refundAmount">Amount to refund to the customer</param>
        private void RunSample(string amazonCaptureId, string refundAmount)
        {
            /************************************************************************
            * Invoke Refund Action
            ***********************************************************************/
            RefundResponse refundResponse = this._refund.RefundAction(amazonCaptureId, refundAmount);
            if (refundResponse == null)
            {
                throw new Exception("The response from Refund request is null");
            }

            /************************************************************************
             * Wait for the refund notification to arrive and display it to the user
             ***********************************************************************/
            lblNotification.Text += WaitAndGetNotificationDetails(refundResponse.RefundResult.RefundDetails.AmazonRefundId + "_Refund");
        }
    }
}