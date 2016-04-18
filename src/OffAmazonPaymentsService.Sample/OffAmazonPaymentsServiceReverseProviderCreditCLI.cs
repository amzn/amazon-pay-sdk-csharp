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
    class OffAmazonPaymentsServiceReverseProviderCreditCLI
    {
        private static String amazonProviderCreditId;
        private static String creditReversalAmount;
        private static OffAmazonPaymentsServiceReverseProviderCredit reverseProviderCreditInstance;

        public static void Main(string[] args)
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("Welcome to Off Amazon Payments Service Reverse Provider Credit Sample!");
            Console.WriteLine("===========================================");
            Console.WriteLine();

            init();
            RunSample();
            
            Console.WriteLine();
            Console.WriteLine("===========================================");
            Console.WriteLine("End of output. You can close this window");
            Console.WriteLine("===========================================");

            System.Threading.Thread.Sleep(50000);
        }

        private static void init()
        {
            reverseProviderCreditInstance = new OffAmazonPaymentsServiceReverseProviderCredit();
            amazonProviderCreditId = CLIHelper.getStringFromConsole("Provider Credit Id");
            creditReversalAmount = CLIHelper.getDoubleFromConsole("Credit Reversal Amount").ToString("0.##");

        }

        private static void RunSample()
        {
            /************************************************************************
             * Invoke Reverse Provider Credit Action
             ***********************************************************************/
            ReverseProviderCreditResponse reverseProviderCreditResponse = reverseProviderCreditInstance.ReverseProviderCreditAction(amazonProviderCreditId, creditReversalAmount);
            if (reverseProviderCreditResponse == null)
                throw new OffAmazonPaymentsServiceException("The response of  ReverseProviderCredit request is null");

            /************************************************************************
             * Invoke Get Provider Credit Reversal Details
             ***********************************************************************/
            GetProviderCreditReversalDetailsResponse getProviderCreditReversalDetailsResponse = reverseProviderCreditInstance.GetProviderCreditReversalDetails(reverseProviderCreditResponse);
            if (getProviderCreditReversalDetailsResponse == null)
                throw new OffAmazonPaymentsServiceException("The response of getProviderCreditReversalDetails request is null");
 
        }

    }
}

