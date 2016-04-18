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
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OffAmazonPaymentsService;
using OffAmazonPaymentsService.Model;
using OffAmazonPaymentsServiceSampleLibrary;
using System.IO;
using OffAmazonPaymentsServiceSampleLibrary.OffAmazonPaymentsServiceSampleLibrary.Utilities;

namespace OffAmazonPaymentsNotifications.Samples
{
    public partial class SimpleCheckout : PaymentsNotificationSample
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
            string orderAmount = tb_OrderAmount.Text;
            int shippingOption = getShippingOption();

            int authorizationOption = Convert.ToInt32(rb_AuthrorizationOption.SelectedValue);
            OffAmazonPaymentsServiceSimpleCheckout simpleCheckout = new OffAmazonPaymentsServiceSimpleCheckout(orderReferenceId);
            RunSample(simpleCheckout, orderReferenceId, orderAmount, shippingOption, authorizationOption);
        }

        private void RunSample(OffAmazonPaymentsServiceSimpleCheckout simpleCheckout,
            string orderReferenceId, string orderAmount, int shippingOption, int authorizationOption)
        {
            /************************************************************************
            * Invoke Get Order Reference Details Action
            ***********************************************************************/
            GetOrderReferenceDetailsResponse getOrderDetails = simpleCheckout.GetOrderReferenceDetails();
            if (getOrderDetails == null)
                throw new OffAmazonPaymentsServiceException("The response from GetOrderReference request is null");

            /************************************************************************
             * Add the tax and shipping rates here
             * Get the rates by using the CountryCode and the StateOrRegionCode from the orderReferenceDetails
            ***********************************************************************/
            Destination destination = getOrderDetails.GetOrderReferenceDetailsResult.OrderReferenceDetails.Destination;
            TaxAndShippingRates rates = new TaxAndShippingRates(destination);
            string totalAmount = rates.getTotalAmountWithTaxAndShipping(Convert.ToDouble(orderAmount), shippingOption).ToString("0.##");

            Address address = destination.PhysicalDestination;
            lblShipping.Text = "The shipping address is: <br>" + address.City + "<br>" + address.StateOrRegion + "<br>" + address.PostalCode + "<br>"
                + "The total amount with tax and shipping is: " + totalAmount + "<br>";
            /************************************************************************
            * Invoke Set Order Reference Details Action
            ***********************************************************************/
            SetOrderReferenceDetailsResponse setOrderDetailsResponse = simpleCheckout.SetOrderReferenceDetails(totalAmount);
            if (setOrderDetailsResponse == null)
                throw new OffAmazonPaymentsServiceException("The response from SetOrderReference request is null");

            /************************************************************************
            * Invoke Confirm Order Reference Action
            ***********************************************************************/
            if (simpleCheckout.ConfirmOrderReferenceObject() == null)
                throw new OffAmazonPaymentsServiceException("The response from ConfirmOrderResponse request is null");

            /************************************************************************
            * Invoke Authorize Action
            ***********************************************************************/
            AuthorizeResponse authResponse = simpleCheckout.AuthorizeAction(setOrderDetailsResponse, authorizationOption);
            if (authResponse == null)
                throw new OffAmazonPaymentsServiceException("The response from Authorization Response request is null");

            /************************************************************************
            * Wait for the notification from ipn.aspx page in a loop, then print the corresponding information
            ***********************************************************************/
            lblNotification.Text += formatStringForDisplay(WaitAndGetNotificationDetails(authResponse.AuthorizeResult.AuthorizationDetails.AmazonAuthorizationId + "_Authorize"));
            GetAuthorizationDetailsResponse response = simpleCheckout.CheckAuthorizationStatus(authResponse);

            /************************************************************************
             * On an IPN callback, call Get Authorization Details to retreive additional
             * information about the authorization - this is done as part of the
             * previous call to check the status.
             ***********************************************************************/
            StringWriter stringWriter = new StringWriter();
            GetAuthorizationDetailsSample.printGetAuthorizationDetailsResponseToBuffer(response, stringWriter);
            lblNotification.Text += formatStringForDisplay(stringWriter.ToString());

            /************************************************************************
            * Invoke Capture Action
            ***********************************************************************/
            CaptureResponse captureResponse = simpleCheckout.CaptureAction(authResponse, totalAmount);
            if (captureResponse == null)
                throw new OffAmazonPaymentsServiceException("The response from Caputre Response request is null");

            /************************************************************************
            * Wait for the notification from ipn.aspx page in a loop, then print the corresponding information
            ***********************************************************************/
            lblNotification.Text += formatStringForDisplay(WaitAndGetNotificationDetails(captureResponse.CaptureResult.CaptureDetails.AmazonCaptureId + "_Capture"));

            /************************************************************************
            * Invoke Get Capture Details Action
            ***********************************************************************/
            if (simpleCheckout.GetCaptureDetails(captureResponse) == null)
                throw new OffAmazonPaymentsServiceException("The response from GetCaputreDetails Response request is null");

            /************************************************************************
            * Invoke Close Order Reference Action
            ***********************************************************************/
            if (simpleCheckout.CloseOrderReference() == null)
                throw new OffAmazonPaymentsServiceException("The response from CloseOrderReference Response request is null");

            /************************************************************************
            * Wait for the notification from ipn.aspx page in a loop, then print the corresponding information
            ***********************************************************************/
            lblNotification.Text += formatStringForDisplay(WaitAndGetNotificationDetails(orderReferenceId + "_OrderReference"));
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

    }      

}
