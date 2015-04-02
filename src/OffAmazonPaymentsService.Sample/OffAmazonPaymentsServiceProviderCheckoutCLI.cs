/******************************************************************************* 
 *  Copyright 2008-2012 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"); 
 *  
 *  You may not use this file except in compliance with the License. 
 *  You may obtain a copy of the License at: http://aws.amazon.com/apache2.0
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR 
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the 
 *  specific language governing permissions and limitations under the License.
 * ***************************************************************************** 
 * 
 *  Off Amazon Payments Service CSharp Library
 *  API Version: 2013-01-01
 * 
 */
 
using System;
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Collections.Generic;
using OffAmazonPaymentsService;
using OffAmazonPaymentsService.Mock;
using OffAmazonPaymentsService.Model;
using OffAmazonPaymentsServiceSampleLibrary;
using OffAmazonPaymentsServiceSampleLibrary.OffAmazonPaymentsServiceSampleLibrary.Utilities;

namespace OffAmazonPaymentsService.Sample
{
    class OffAmazonPaymentsServiceProviderCheckoutCLI
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("Welcome to Off Amazon Payments Service Provider Checkout Sample!");
            Console.WriteLine("===========================================");
            Console.WriteLine();

            string orderReferenceId = CLIHelper.getStringFromConsole("order reference id");
            double orderAmount = CLIHelper.getDoubleFromConsole("order amount");
            int shippingOption = CLIHelper.getShippingOption();
            int authorizationOption = CLIHelper.getAuthorizationOption();
            string providerId = CLIHelper.getStringFromConsole("provider id");
            string creditAmount = CLIHelper.getDoubleFromConsole("credit amount").ToString();
            OffAmazonPaymentsServiceProviderCheckout providerCheckout = new OffAmazonPaymentsServiceProviderCheckout(orderReferenceId);
            RunSample(orderReferenceId, orderAmount, shippingOption, providerCheckout, authorizationOption, providerId, creditAmount);
			
            Console.WriteLine();
            Console.WriteLine("===========================================");
            Console.WriteLine("End of output. You can close this window");
            Console.WriteLine("===========================================");

            System.Threading.Thread.Sleep(50000);
        }

        private static void RunSample(string orderReferenceId, double orderAmount, int shippingOption, OffAmazonPaymentsServiceProviderCheckout providerCheckout, int authorizationOption, string providerId, string creditAmount)
        {
            /************************************************************************
             * Invoke Get Order Reference Details Action
             ***********************************************************************/
            GetOrderReferenceDetailsResponse getOrderDetails = providerCheckout.GetOrderReferenceDetails();

            if (getOrderDetails == null)
                throw new OffAmazonPaymentsServiceException("The response from GetOrderReference request is null");

            /************************************************************************
             * Add the tax and shipping rates here
             * Get the rates by using the CountryCode and the StateOrRegionCode from the orderReferenceDetails
             ***********************************************************************/
            Destination destination = getOrderDetails.GetOrderReferenceDetailsResult.OrderReferenceDetails.Destination;
            TaxAndShippingRates rates = new TaxAndShippingRates(destination);
            string totalAmount = rates.getTotalAmountWithTaxAndShipping(orderAmount, shippingOption).ToString("0.##");

            Console.WriteLine("=========================Tax and Shipping Calculation========================");
            Console.WriteLine("The tax and shipping rate will be calculated based on the CountryCode: " + destination.PhysicalDestination.CountryCode
                + " and the StateOrRegionCode: " + destination.PhysicalDestination.StateOrRegion);
            Console.WriteLine("The total amount is " + totalAmount);
            Console.WriteLine("=============================================================================");
            
            /************************************************************************
             * Invoke Set Order Reference Details Action
             ***********************************************************************/
            SetOrderReferenceDetailsResponse setOrderDetailsResponse = providerCheckout.SetOrderReferenceDetails(totalAmount);
            if (setOrderDetailsResponse == null)
                throw new OffAmazonPaymentsServiceException("The response from SetOrderReference request is null");
            Console.WriteLine("=============================================================================");

            /************************************************************************
             * Invoke Confirm Order Reference Action
             ***********************************************************************/
            if (providerCheckout.ConfirmOrderReferenceObject() == null)
                throw new OffAmazonPaymentsServiceException("The response from ConfirmOrderResponse request is null");
            Console.WriteLine("=============================================================================");
			
            /************************************************************************
             * Invoke Authorize Action
             ***********************************************************************/
            AuthorizeResponse authResponse = providerCheckout.AuthorizeAction(setOrderDetailsResponse, authorizationOption);
            if (authResponse == null)
                throw new OffAmazonPaymentsServiceException("The response from Authorization request is null");
            Console.WriteLine("=============================================================================");

            /************************************************************************
             * When Regular Asynchronous Authorization is used, the Authorization
             * State remains in pending and we need to wait for the state change.
             * Fast Authorization has a synchronous response and doesn't require this.
             ***********************************************************************/
            if (authorizationOption == 1)
            {
                /************************************************************************
                 * Check the authorization status unitl it is not "PENDING" any more
                 * GetAuthorizeDetails is contained in this method
                 ***********************************************************************/
                providerCheckout.CheckAuthorizationStatus(authResponse);
            }

            /************************************************************************
             * Invoke Capture Action
             ***********************************************************************/
            CaptureResponse captureResponse = providerCheckout.CaptureActionWithProviderCredit(authResponse, totalAmount, providerId, creditAmount);
            if (captureResponse == null)
                throw new OffAmazonPaymentsServiceException("The response from Caputre request is null");

            Console.WriteLine("=============================================================================");

            /************************************************************************
             * Invoke GetCaptureDetails Action
             ***********************************************************************/
            GetCaptureDetailsResponse getCaptureDetailsResponse = providerCheckout.GetCaptureDetails(captureResponse);
            if ( getCaptureDetailsResponse == null)
                throw new OffAmazonPaymentsServiceException("The response from GetCaputreDetails request is null");
            Console.WriteLine("=============================================================================");


            /************************************************************************
             * Invoke GetProviderCreditDetails Action
             ***********************************************************************/
            if (!String.IsNullOrEmpty(providerId) && !String.IsNullOrEmpty(creditAmount))
            {
                //Wait till the the ProviderCreditSummaryList is available in the GetCaptureDetailsResponse
                ProviderCreditSummaryList providerCreditSummaryList = providerCheckout.CheckCaptureForProviderCreditSummaryList(captureResponse); 
                foreach (ProviderCreditSummary providerCreditSummary in providerCreditSummaryList.member)
                {
                    GetProviderCreditDetailsResponse getProviderCreditDetailsResponse = providerCheckout.GetProviderCreditDetails(providerCreditSummary);
                    if (getProviderCreditDetailsResponse == null)
                        throw new OffAmazonPaymentsServiceException("The response from GetProviderCreditDetails request is null for ProviderCreditId:" + providerCreditSummary.ProviderCreditId);
                    Console.WriteLine("=============================================================================");

                }
            }

            /************************************************************************
             * Invoke CloseOrderReference Action
             ***********************************************************************/
            if (providerCheckout.CloseOrderReference() == null)
                throw new OffAmazonPaymentsServiceException("The response from CloseOrderReference request is null");
        }
    }
}

