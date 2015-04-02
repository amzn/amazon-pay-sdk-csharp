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

namespace OffAmazonPaymentsNotifications.Samples.Samples
{
    public partial class PaymentsNotificationMultipleShipment_2 : PaymentsNotificationSample
    {
        private string orderReferenceId;
        private int numberOfShipment;
        private float[] amountEachShip;

        protected void Page_Load(object sender, EventArgs e)
        {
            orderReferenceId = Request.QueryString["orderReferenceId"];
            numberOfShipment = int.Parse(Request.QueryString["number"]);
            amountEachShip = new float[3];

            if (numberOfShipment == 1)
            {
                panel_2.Visible = false;
                panel_3.Visible = false;
            }
            else if (numberOfShipment == 2)
            {
                panel_3.Visible = false;
            }
        }

        /// <summary>
        /// Handle the form submisson
        /// </summary>
        /// <param name="sender">reference to the sender</param>
        /// <param name="e">arguments for the event</param>
        protected void btn_submit_Click(object sender, EventArgs e)
        {
            OffAmazonPaymentsServiceMultipleShipment instance = new OffAmazonPaymentsServiceMultipleShipment(orderReferenceId);
            InitializeShipmentArray();
            float amount = GetTotalOrderAmount();
            RunSampleMultiShipments(amount.ToString(), instance);
        }

        private void InitializeShipmentArray()
        {
            amountEachShip[0] = GetItemPrice(int.Parse(ddl_item1.SelectedValue)) * int.Parse(ddl_item1Number.SelectedValue);
            amountEachShip[1] = GetItemPrice(int.Parse(ddl_item2.SelectedValue)) * int.Parse(ddl_item2Number.SelectedValue);
            amountEachShip[0] = GetItemPrice(int.Parse(ddl_item3.SelectedValue)) * int.Parse(ddl_item3Number.SelectedValue);
        }

        private float GetTotalOrderAmount()
        {
            float result = 0.0f;
            result += GetItemPrice(int.Parse(ddl_item1.SelectedValue)) * int.Parse(ddl_item1Number.SelectedValue);
            result += GetItemPrice(int.Parse(ddl_item2.SelectedValue)) * int.Parse(ddl_item2Number.SelectedValue);
            result += GetItemPrice(int.Parse(ddl_item3.SelectedValue)) * int.Parse(ddl_item3Number.SelectedValue);

            return result;
        }

        private float GetItemPrice(int item)
        {
            switch (item)
            {
                case 0:
                    return 0.6f;
                case 1:
                    return 3.2f;
                case 2:
                    return 0.3f;
                case 3:
                    return 0.6f;
                case 4:
                    return 0.45f;
                default:
                    return 0.0f;
            }
        }

        //Create an indicator which is used to compose different AuthorizationReferenceId and CaptureReferenceId
        private static int indicator = 0;

        private void RunSampleMultiShipments(string orderAmount, OffAmazonPaymentsServiceMultipleShipment instance)
        {
            /************************************************************************
            * Invoke Get Order Reference Details Action
            ***********************************************************************/
            GetOrderReferenceDetailsResponse getOrderDetails = instance.GetOrderReferenceDetails();
            if (getOrderDetails == null)
                throw new OffAmazonPaymentsServiceException("The response from GetOrderReference request is null");

            Address address = getOrderDetails.GetOrderReferenceDetailsResult.OrderReferenceDetails.Destination.PhysicalDestination;
            lblShipping.Text = "The shipping address is: " + address.City + "<br>" + address.StateOrRegion + "<br>" + address.PostalCode + "<br>";

            /************************************************************************
            * Invoke Set Order Reference Details Action
            ***********************************************************************/
            SetOrderReferenceDetailsResponse setOrderDetailsResponse = instance.SetOrderReferenceDetails(orderAmount);
            if (setOrderDetailsResponse == null)
                throw new OffAmazonPaymentsServiceException("The response from SetOrderReference request is null");

            /************************************************************************
            * Invoke Confirm Order Reference Action
            ***********************************************************************/
            if (instance.ConfirmOrderReferenceObject() == null)
                throw new OffAmazonPaymentsServiceException("The response from ConfirmOrderResponse request is null");

            //iterate the authoriztion amount in the authList
            for (int i = 0; i < numberOfShipment; i++)
            {
                String eachOrderAmount = amountEachShip[i].ToString();
                /************************************************************************
                * Invoke Authorize Action
                ***********************************************************************/
                AuthorizeResponse authResponse = instance.AuthorizeAction(eachOrderAmount, indicator);
                if (authResponse == null)
                    throw new OffAmazonPaymentsServiceException("The response from Authorization Response request is null");

                /************************************************************************
                * Wait for the notification from ipn.aspx page in a loop, then print the corresponding information
                ***********************************************************************/
                lblNotification.Text += WaitAndGetNotificationDetails(authResponse.AuthorizeResult.AuthorizationDetails.AmazonAuthorizationId + "_Authorize");
                
                instance.CheckAuthorizationStatus(authResponse);

                /************************************************************************
                * Invoke Capture Action
                ***********************************************************************/
                CaptureResponse captureResponse = instance.CaptureAction(authResponse, eachOrderAmount, indicator);
                if (captureResponse == null)
                    throw new OffAmazonPaymentsServiceException("The response from Caputre Response request is null");

                lblNotification.Text += WaitAndGetNotificationDetails(captureResponse.CaptureResult.CaptureDetails.AmazonCaptureId + "_Capture");

                /************************************************************************
                * Invoke Get Capture Details Action
                ***********************************************************************/
                if (instance.GetCaptureDetails(captureResponse) == null)
                    throw new OffAmazonPaymentsServiceException("The response from GetCaputreDetails Response request is null");

                indicator++;
            }

            /************************************************************************
            * Invoke Close Order Reference Action
            ***********************************************************************/
            if (instance.CloseOrderReference() == null)
                throw new OffAmazonPaymentsServiceException("The response from CloseOrderReference Response request is null");

            lblNotification.Text += WaitAndGetNotificationDetails(orderReferenceId + "_OrderReference");
        }
    }
}
