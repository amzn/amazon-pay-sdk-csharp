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
using System.Text.RegularExpressions;
using OffAmazonPaymentsService;
using OffAmazonPaymentsService.Mock;
using OffAmazonPaymentsService.Model;

namespace OffAmazonPaymentsServiceSampleLibrary
{
    /// <summary>
    /// This sample is running as a multiple shipping workflow. It contains the following steps:
    /// getOrderReference is used to calculate the tax and shipping
    /// setOrderReference is used to set the amount and currency of order reference objects
    /// comfirmOrderReference is used to confirm the order, make sure it is in OPEN state
    /// authorizeAction is used to authorize the order for capturing funds from it
    /// captureAction is used to get the amount of money from the authorization
    /// If necessary, there would be mutiple times of authorizeAction and captureAction
    /// </summary>
    public class OffAmazonPaymentsServiceMultipleShipment
    {
        private IOffAmazonPaymentsService service;
        private OffAmazonPaymentsServicePropertyCollection propertiesCollection;
        private string _orderReferenceId;
        private IDictionary<string, OrderItem> _orderList;


        /// <summary>
        /// Create a new instance of the class, using the order reference
        /// identifer as the basis for all service requests
        /// </summary>
        /// <param name="amazonOrderReferenceId">An order reference identifier for a draft order, obtained from the
        /// OffAmazonPayments widgets</param>
        public OffAmazonPaymentsServiceMultipleShipment(string amazonOrderReferenceId)
        {
            this.OrderList = new Dictionary<string, OrderItem>();
            ConstructOrders();

            // Instantiate the Merchant propertiesCollection object which contains
            // required parameters for creating a Marketplace Payment Service
            propertiesCollection = new OffAmazonPaymentsServicePropertyCollection();
            
            service = new OffAmazonPaymentsServiceClient(propertiesCollection);

            this._orderReferenceId = amazonOrderReferenceId;
        }

        private void ConstructOrders()
        {
            OrderItem a = new OrderItem("Apple", 3.20f, 2);
            OrderItem b = new OrderItem("Pineapple", 1.8f, 1);
            this.OrderList.Add("Apple", a);
            this.OrderList.Add("Pineapple", b);
        }

        /// <summary>
        /// Return the current order list
        /// </summary>
        public IDictionary<string, OrderItem> OrderList
        {
            get { return this._orderList; }
            set { this._orderList = value; }
        }

        /// <summary>
        /// Return the total value of the order
        /// </summary>
        /// <returns></returns>
        public String OrderTotal
        {
            get
            {
                float amount = 0.0f;
                foreach (string item in this.OrderList.Keys)
                    amount += this.OrderList[item].Price * this.OrderList[item].Number;
                return amount.ToString();
            }
        }

        /// <summary>
        /// Print the  current order list to the console
        /// </summary>
        /// <param name="list"></param>
        public void ShowCurrentOrders()
        {
            foreach (OrderItem item in this.OrderList.Values)
            {
                Console.WriteLine("Name: " + item.Name + ", Price: " + item.Price + ", Number: " + item.Number);
            }
        }

        //Invoke the SetOrderReferenceDetails method
        public SetOrderReferenceDetailsResponse SetOrderReferenceDetails(string orderAmount)
        {
            return SetOrderReferenceDetailsSample.SetOrderReferenceDetails(propertiesCollection, service, this._orderReferenceId, orderAmount);
        }

        //Invoke the ConfirmOrderReference method
        public ConfirmOrderReferenceResponse ConfirmOrderReferenceObject()
        {
            return ConfirmOrderReferenceSample.ConfirmOrderReferenceObject(propertiesCollection, service, this._orderReferenceId);
        }

        //Invoke the GetOrderReferenceDetails method
        public GetOrderReferenceDetailsResponse GetOrderReferenceDetails()
        {
            return GetOrderReferenceDetailsSample.GetOrderReferenceDetails(propertiesCollection, service, this._orderReferenceId, null);
        }

        //Invoke the Authorize method
        public AuthorizeResponse AuthorizeAction(String orderAmount, int id)
        {
            return AuthorizeSample.AuthorizeAction(propertiesCollection, service, this._orderReferenceId, orderAmount, id, 1);
        }

        //Use a loop to check the status of authorization. Once the status is not "PENDING", skip the loop.
        public void CheckAuthorizationStatus(AuthorizeResponse authResponse)
        {
            AuthorizeSample.CheckAuthorizationStatus(authResponse.AuthorizeResult.AuthorizationDetails.AmazonAuthorizationId, propertiesCollection, service);
        }

        //Invoke the Capture method
        public CaptureResponse CaptureAction(AuthorizeResponse authResponse, string orderAmount, int id)
        {
            return CaptureSample.CaptureAction(propertiesCollection, service, authResponse.AuthorizeResult.AuthorizationDetails.AmazonAuthorizationId, orderAmount, this._orderReferenceId, id, null, null);
        }

        //Invoke the GetCaptureDetails method
        public GetCaptureDetailsResponse GetCaptureDetails(CaptureResponse captureReponse)
        {
            return GetCaptureDetailsSample.GetCaptureDetails(propertiesCollection, service, captureReponse.CaptureResult.CaptureDetails.AmazonCaptureId);
        }

        //Invoke the CloseOrderReference method
        public CloseOrderReferenceResponse CloseOrderReference()
        {
            return CloseOrderReferenceSample.CloseOrderReference(propertiesCollection, service, this._orderReferenceId);
        }
    }

}

