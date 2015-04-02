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
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using OffAmazonPaymentsService.Model;
using OffAmazonPaymentsServiceSampleLibrary;
using OffAmazonPaymentsServiceSampleLibrary.OffAmazonPaymentsServiceSampleLibrary.Utilities;

namespace OffAmazonPaymentsService.Sample
{
    class OffAmazonPaymentsServiceAutomaticPaymentsSimpleCheckoutCLI
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("Welcome to Off Amazon Payments Service Automatic Payments Simple Checkout Sample!");
            Console.WriteLine("===========================================");
            Console.WriteLine();

            string billingAgreementId = CLIHelper.getStringFromConsole("billing agreement id");
            double paymentAmount = CLIHelper.getDoubleFromConsole("payment amount");
            int shippingOption = CLIHelper.getShippingOption();
            OffAmazonPaymentsServiceAutomaticPaymentsSimpleCheckout automaticPayments =
                new OffAmazonPaymentsServiceAutomaticPaymentsSimpleCheckout(billingAgreementId);
            RunSample(automaticPayments, billingAgreementId, paymentAmount, shippingOption);

            Console.WriteLine();
            Console.WriteLine("===========================================");
            Console.WriteLine("End of output. You can close this window");
            Console.WriteLine("===========================================");

            System.Threading.Thread.Sleep(50000);
        }

        private static void RunSample(OffAmazonPaymentsServiceAutomaticPaymentsSimpleCheckout automaticPayments,
            string billingAgreementId, double paymentAmount, int shippingOption)
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
            string totalAmount = rates.getTotalAmountWithTaxAndShipping(paymentAmount, shippingOption).ToString("0.##");

            Console.WriteLine("=========================Tax and Shipping Calculation========================");
            Console.WriteLine("The tax and shipping rate will be calculated based on the CountryCode: " + destination.PhysicalDestination.CountryCode
                + " and the StateOrRegionCode: " + destination.PhysicalDestination.StateOrRegion);
            Console.WriteLine("The total amount is " + totalAmount);
            Console.WriteLine("=============================================================================");

            /************************************************************************
             * Invoke Set Billing Agreement Details Action
             ***********************************************************************/
            if (automaticPayments.SetBillingAgreementDetails() == null)
                throw new OffAmazonPaymentsServiceException("The response from SetBillingAgreementDetails request is null");
            Console.WriteLine("=============================================================================");

            /************************************************************************
             * Invoke Confirm Billing Agreement Action
             ***********************************************************************/
            if (automaticPayments.ConfirmBillingAgreement() == null)
                throw new OffAmazonPaymentsServiceException("The response from ConfirmBillingAgreement request is null");
            Console.WriteLine("=============================================================================");

            /************************************************************************
             * Invoke Validate Billing Agreement Action (Optional)
             ***********************************************************************/
            if (automaticPayments.ValidateBillingAgreement() == null)
                throw new OffAmazonPaymentsServiceException("The response from ValidateBillingAgreement request is null");
            Console.WriteLine("=============================================================================");

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
        }

        private static void MakePayment(OffAmazonPaymentsServiceAutomaticPaymentsSimpleCheckout automaticPayments,
            string totalAmount, int indicator, bool captureNow)
        {
            Console.WriteLine("Making payment with indicator " + indicator.ToString());
            Console.WriteLine("=============================================================================");

            /************************************************************************
             * Invoke Authorize on Billing Agreement Action
             ***********************************************************************/
            AuthorizeOnBillingAgreementResponse authResponse = automaticPayments.AuthorizeOnBillingAgreement(totalAmount, indicator, captureNow);
            if (authResponse == null)
                throw new OffAmazonPaymentsServiceException("The response from AuthorizeOnBillingAgreement request is null");
            Console.WriteLine("=============================================================================");

            /************************************************************************
             * Check the authorization status unitl it is not "PENDING" any more
             * GetAuthorizationDetails is contained in this method
             ***********************************************************************/
            automaticPayments.CheckAuthorizationStatus(authResponse);

            if (!captureNow)
            {
                /************************************************************************
                 * Invoke Capture Action
                 ***********************************************************************/
                CaptureResponse captureResponse = automaticPayments.Capture(authResponse, totalAmount, indicator);
                if (captureResponse == null)
                    throw new OffAmazonPaymentsServiceException("The response from Capture request is null");
                Console.WriteLine("=============================================================================");

                /************************************************************************
                 * Invoke Get Capture Details Action
                 ***********************************************************************/
                if (automaticPayments.GetCaptureDetail(captureResponse) == null)
                    throw new OffAmazonPaymentsServiceException("The response from GetCaptureDetail request is null");
                Console.WriteLine("=============================================================================");
            }

            Console.WriteLine("Payment with indicator " + indicator.ToString() + " is complete");
            Console.WriteLine("=============================================================================");
        }
    }
}
