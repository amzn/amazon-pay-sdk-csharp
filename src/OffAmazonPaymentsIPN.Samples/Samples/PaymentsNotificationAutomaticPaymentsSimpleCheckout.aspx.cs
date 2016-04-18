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

using OffAmazonPaymentsService;
using OffAmazonPaymentsService.Model;
using OffAmazonPaymentsServiceSampleLibrary;
using OffAmazonPaymentsServiceSampleLibrary.OffAmazonPaymentsServiceSampleLibrary.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace OffAmazonPaymentsNotifications.Samples
{
    public partial class PaymentsNotificationAutomaticPaymentsSimpleCheckout : PaymentsNotificationSample
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
            string billingAgreementId = tb_BAId.Text;
            string paymentAmount = tb_PaymentAmount.Text;
            int shippingOption = getShippingOption();
            OffAmazonPaymentsServiceAutomaticPaymentsSimpleCheckout automaticPayments = new OffAmazonPaymentsServiceAutomaticPaymentsSimpleCheckout(billingAgreementId);
            RunSample(automaticPayments, billingAgreementId, paymentAmount, shippingOption);
        }

        private int getShippingOption()
        {
            if (rb_StandardShipping.Checked)
            {
                return 1;
            }
            else if (rb_TwoDayShipping.Checked)
            {
                return 2;
            }
            else if (rb_NextDayShipping.Checked)
            {
                return 3;
            }
            else
            {
                throw new OffAmazonPaymentsServiceException("You must choose a shipping option");
            }
        }

        private void RunSample(OffAmazonPaymentsServiceAutomaticPaymentsSimpleCheckout automaticPayments,
            string billingAgreementId, string paymentAmount, int shippingOption)
        {
            /************************************************************************
             * Invoke Get Billing Agreement Details Action
             ***********************************************************************/
            GetBillingAgreementDetailsResponse getDetailsResponse = automaticPayments.GetBillingAgreementDetails();
            if (getDetailsResponse == null)
                throw new OffAmazonPaymentsServiceException("The response from GetBillingAgreementDetails request is null");

            /************************************************************************
             * Add the tax and shipping rates here
             * Get the rates by using the CountryCode and the StateOrRegionCode from the billingAgreementDetails
             ***********************************************************************/
            Destination destination = getDetailsResponse.GetBillingAgreementDetailsResult.BillingAgreementDetails.Destination;
            TaxAndShippingRates rates = new TaxAndShippingRates(destination);
            string totalAmount = rates.getTotalAmountWithTaxAndShipping(Convert.ToDouble(paymentAmount), shippingOption).ToString("0.##");

            Address address = destination.PhysicalDestination;
            lblShipping.Text = "The shipping address is: <br>" + address.City + "<br>" + address.StateOrRegion + "<br>" + address.PostalCode + "<br>"
                + "The total amount with tax and shipping is: " + totalAmount + "<br>";

            /************************************************************************
             * Invoke Set Billing Agreement Details Action
             ***********************************************************************/
            if (automaticPayments.SetBillingAgreementDetails() == null)
                throw new OffAmazonPaymentsServiceException("The response from SetBillingAgreementDetails request is null");

            /************************************************************************
             * Invoke Confirm Billing Agreement Action
             ***********************************************************************/
            if (automaticPayments.ConfirmBillingAgreement() == null)
                throw new OffAmazonPaymentsServiceException("The response from ConfirmBillingAgreement request is null");

            /************************************************************************
             * Invoke Validate Billing Agreement Action (Optional)
             ***********************************************************************/
            if (automaticPayments.ValidateBillingAgreement() == null)
                throw new OffAmazonPaymentsServiceException("The response from ValidateBillingAgreement request is null");
            
            /************************************************************************
             * Make the first payment
             ***********************************************************************/
            MakePayment(automaticPayments, totalAmount, 1, false);

            /************************************************************************
             * Make the second payment
             ***********************************************************************/
            MakePayment(automaticPayments, totalAmount, 2, false);

            /************************************************************************
             * Make the third payment with capture now
             ***********************************************************************/
            MakePayment(automaticPayments, totalAmount, 3, true);

            /************************************************************************
             * Invoke Close Billing Agreement Action
             ***********************************************************************/
            if (automaticPayments.CloseBillingAgreement() == null)
                throw new OffAmazonPaymentsServiceException("The response from CloseBillingAgreement request is null");

            /************************************************************************
             * Wait for the notification from ipn.aspx page in a loop, then print the corresponding information
             ***********************************************************************/
            lblNotification.Text += formatStringForDisplay(WaitAndGetNotificationDetails(billingAgreementId + "_BillingAgreement"));
        }

        private void MakePayment(OffAmazonPaymentsServiceAutomaticPaymentsSimpleCheckout automaticPayments,
            string totalAmount, int indicator, bool captureNow)
        {
            lblNotification.Text += "<br>-----Making payment with indicator " + indicator.ToString() + "<br>";

            /************************************************************************
             * Invoke Authorize on Billing Agreement Action
             ***********************************************************************/
            AuthorizeOnBillingAgreementResponse authResponse = automaticPayments.AuthorizeOnBillingAgreement(totalAmount, indicator, captureNow);
            if (authResponse == null)
                throw new OffAmazonPaymentsServiceException("The response from AuthorizeOnBillingAgreement request is null");

            /************************************************************************
             * Wait for the notification from ipn.aspx page in a loop, then print the corresponding information
             ***********************************************************************/
            lblNotification.Text += formatStringForDisplay(WaitAndGetNotificationDetails(authResponse.AuthorizeOnBillingAgreementResult.AuthorizationDetails.AmazonAuthorizationId + "_Authorize"));
            GetAuthorizationDetailsResponse response = automaticPayments.CheckAuthorizationStatus(authResponse);

            /************************************************************************
             * On an IPN callback, call GetAuthorizationDetails to retreive additional
             * information about the authorization - this is done as part of the
             * previous call to check the status.
             ***********************************************************************/
            StringWriter stringWriter = new StringWriter();
            GetAuthorizationDetailsSample.printGetAuthorizationDetailsResponseToBuffer(response, stringWriter);
            lblNotification.Text += formatStringForDisplay(stringWriter.ToString());

            if (!captureNow)
            {
                /************************************************************************
                 * Invoke Capture Action
                 ***********************************************************************/
                CaptureResponse captureResponse = automaticPayments.Capture(authResponse, totalAmount, indicator);
                if (captureResponse == null)
                    throw new OffAmazonPaymentsServiceException("The response from Capture request is null");

                /************************************************************************
                 * Wait for the notification from ipn.aspx page in a loop, then print the corresponding information
                 ***********************************************************************/
                lblNotification.Text += formatStringForDisplay(WaitAndGetNotificationDetails(captureResponse.CaptureResult.CaptureDetails.AmazonCaptureId + "_Capture"));

                /************************************************************************
                 * Invoke Get Capture Details Action
                 ***********************************************************************/
                if (automaticPayments.GetCaptureDetail(captureResponse) == null)
                    throw new OffAmazonPaymentsServiceException("The response from GetCaptureDetail request is null");
            }

            lblNotification.Text += "-----Payment with indicator " + indicator.ToString() + " is complete<br><br>";
        }
    }
}
