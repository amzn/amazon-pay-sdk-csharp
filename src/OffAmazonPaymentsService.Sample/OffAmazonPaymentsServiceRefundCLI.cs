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
    class OffAmazonPaymentsServiceRefundCLI
    {
        private static String amazonCaptureId;
        private static String refundAmount;
        private static OffAmazonPaymentsServiceRefund instance;

        public static void Main(string[] args)
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("Welcome to Off Amazon Payments Service Refund Sample!");
            Console.WriteLine("===========================================");
            Console.WriteLine();

            init();
            instance = new OffAmazonPaymentsServiceRefund();
            RunSample();

			Console.WriteLine();
            Console.WriteLine("===========================================");
            Console.WriteLine("End of output. You can close this window");
            Console.WriteLine("===========================================");

            System.Threading.Thread.Sleep(50000);
        }

        private static void init()
        {
            /************************************************************************
             * Two arguments required for the refund sample
             * First argument is the capture reference id
             * Second argument is the refund amount (The maximum can be refunded is orderAmount + Min(75, 15%)
            ***********************************************************************/
            amazonCaptureId = CLIHelper.getStringFromConsole("capture reference id");
            refundAmount = CLIHelper.getDoubleFromConsole("refund amount").ToString("0.##");
        }

        private static void RunSample()
        {
            /************************************************************************
             * Invoke Refund Action
             ***********************************************************************/
            RefundResponse refundResponse = instance.RefundAction(amazonCaptureId, refundAmount);	
			if (refundResponse == null)
                throw new OffAmazonPaymentsServiceException("The response of Refund request is null");
            
            /************************************************************************
             * Invoke Get Refund Details
             ***********************************************************************/
            GetRefundDetailsResponse refundDetailsResponse = instance.GetRefundDetails(refundResponse);
            if (refundDetailsResponse == null)
                throw new OffAmazonPaymentsServiceException("The response of GetRefundDetails request is null");
        }
    }
}

