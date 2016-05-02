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
    class OffAmazonPaymentsServiceProviderRefundCLI
    {
        private static String amazonCaptureId;
        private static String refundAmount;
        private static String providerId;
        private static String creditReversalAmount;
        private static OffAmazonPaymentsServiceProviderRefund providerRefund;

        public static void Main(string[] args)
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("Welcome to Off Amazon Payments Service Provider Refund Sample!");
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
            providerRefund = new OffAmazonPaymentsServiceProviderRefund();
            amazonCaptureId = CLIHelper.getStringFromConsole("capture reference id");
            refundAmount = CLIHelper.getDoubleFromConsole("refund amount").ToString("0.##");
            providerId = CLIHelper.getStringFromConsole("provider id");
            creditReversalAmount = CLIHelper.getDoubleFromConsole("credit reversal amount").ToString("0.##");
        }

        private static void RunSample()
        {
            /************************************************************************
             * Invoke Refund Action With Provider Credit Reversal
             ***********************************************************************/
            RefundResponse refundResponse = providerRefund.RefundActionWithProviderCreditReversal(amazonCaptureId, refundAmount, providerId, creditReversalAmount);
            if (refundResponse == null)
                throw new OffAmazonPaymentsServiceException("The response of Refund request is null");

            /************************************************************************
             * Check Refund Status unitl it is not "PENDING" any more
             * GetRefundDetails is contained in this method
             ***********************************************************************/
            GetRefundDetailsResponse getRefundDetailsResponse = providerRefund.CheckRefundStatus(refundResponse);
            if (getRefundDetailsResponse == null)
                throw new OffAmazonPaymentsServiceException("The response of GetRefundDetails request is null");
            
            /************************************************************************
             * Invoke Get Provider Credit Reversal Details
             ***********************************************************************/
            if (getRefundDetailsResponse.GetRefundDetailsResult.RefundDetails.IsSetProviderCreditReversalSummaryList())
            {
                foreach (ProviderCreditReversalSummary providerCreditReversalSummary in getRefundDetailsResponse.GetRefundDetailsResult.RefundDetails.ProviderCreditReversalSummaryList.member)
                {
                    GetProviderCreditReversalDetailsResponse getProviderCreditReversalDetails = providerRefund.GetProviderCreditReversalDetails(providerCreditReversalSummary);
                    if (getProviderCreditReversalDetails == null)
                        throw new OffAmazonPaymentsServiceException("The response from GetProviderCreditDetails request is null for ProviderCreditId:" + providerCreditReversalSummary.ProviderCreditReversalId);
                    Console.WriteLine("=============================================================================");
                }
            }
        }
    }
}

