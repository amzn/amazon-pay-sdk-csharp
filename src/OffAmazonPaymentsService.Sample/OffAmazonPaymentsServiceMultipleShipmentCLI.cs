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
using OffAmazonPaymentsServiceSampleLibrary;

namespace OffAmazonPaymentsService.Sample
{
    class OffAmazonPaymentsServiceMultipleShipmentCLI
    {
        //Create an indicator which is used to compose different AuthorizationReferenceId and CaptureReferenceId
        private static int indicator = 0;

        public static void Main(string[] args)
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("Welcome to Off Amazon Payments Service Multiple Shipments Sample!");
            Console.WriteLine("===========================================");
            Console.WriteLine();

            string orderReferenceId = CLIHelper.getStringFromConsole("order reference id");
            OffAmazonPaymentsServiceMultipleShipment instance = new OffAmazonPaymentsServiceMultipleShipment(orderReferenceId);
            string orderAmount = instance.OrderTotal;
            RunSampleMultiShipments(orderReferenceId, orderAmount, instance);

            Console.WriteLine();
            Console.WriteLine("===========================================");
            Console.WriteLine("End of output. You can close this window");
            Console.WriteLine("===========================================");
            System.Threading.Thread.Sleep(50000);
        }

        private static void RunSampleMultiShipments(string orderReferenceId, string orderAmount, OffAmazonPaymentsServiceMultipleShipment instance)
        {
            /************************************************************************
            * Invoke Get Order Reference Details Action
            ***********************************************************************/
            GetOrderReferenceDetailsResponse getOrderDetails = instance.GetOrderReferenceDetails();
            if (getOrderDetails == null)
                throw new OffAmazonPaymentsServiceException("The response from GetOrderReference request is null");
            Console.WriteLine("=======================================================");

            /************************************************************************
            * Invoke Set Order Reference Details Action
            ***********************************************************************/
            SetOrderReferenceDetailsResponse setOrderDetailsResponse = instance.SetOrderReferenceDetails(orderAmount);
            if (setOrderDetailsResponse == null)
                throw new OffAmazonPaymentsServiceException("The response from SetOrderReference request is null");
            Console.WriteLine("=======================================================");

            /************************************************************************
            * Invoke Confirm Order Reference Action
            ***********************************************************************/
            if (instance.ConfirmOrderReferenceObject() == null)
                throw new OffAmazonPaymentsServiceException("The response from ConfirmOrderResponse request is null");
            Console.WriteLine("=======================================================");
            Console.WriteLine("===========================================");
            Console.WriteLine("Here is the demo of one capture per authorization.");
            Console.WriteLine("===========================================");
            Console.WriteLine();

            IDictionary<string, OrderItem> orderList = instance.OrderList;
            Console.WriteLine("Current orders are listed as below: ");
            instance.ShowCurrentOrders();
            System.Threading.Thread.Sleep(3000);

            //iterate the authoriztion amount in the authList
            foreach (string item in orderList.Keys)
            {
                String eachOrderAmount = (orderList[item].Price * orderList[item].Number).ToString();
                /************************************************************************
                * Invoke Authorize Action
                ***********************************************************************/
                AuthorizeResponse authResponse = instance.AuthorizeAction(eachOrderAmount, indicator);
                if (authResponse == null)
                    throw new OffAmazonPaymentsServiceException("The response from Authorization Response request is null");
                Console.WriteLine("=======================================================");

                /************************************************************************
                * Check the authorization status unitl it is not "PENDING" any more
                 * GetAuthorizeDetails is contained in this method
                ***********************************************************************/
                instance.CheckAuthorizationStatus(authResponse);

                /************************************************************************
                * Invoke Capture Action
                ***********************************************************************/
                CaptureResponse captureResponse = instance.CaptureAction(authResponse, eachOrderAmount, indicator);
                if (captureResponse == null)
                    throw new OffAmazonPaymentsServiceException("The response from Caputre Response request is null");
                Console.WriteLine("=======================================================");

                /************************************************************************
                * Invoke GetCaptureDetails Action
                ***********************************************************************/
                if (instance.GetCaptureDetails(captureResponse) == null)
                    throw new OffAmazonPaymentsServiceException("The response from GetCaputreDetails Response request is null");
                Console.WriteLine("=======================================================");

                indicator++;
            }

            /************************************************************************
            * Invoke CloseOrderReference Action
            ***********************************************************************/
            if (instance.CloseOrderReference() == null)
                throw new OffAmazonPaymentsServiceException("The response from CloseOrderReference Response request is null");
        }
    }
}

