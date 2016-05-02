/******************************************************************************* 
 *  Copyright 2008-2013 Amazon.com, Inc. or its affiliates. All Rights Reserved.
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
using OffAmazonPaymentsService;
using OffAmazonPaymentsService.Mock;
using OffAmazonPaymentsService.Model;
using OffAmazonPaymentsServiceSampleLibrary;

namespace OffAmazonPaymentsService.Sample
{
    class OffAmazonPaymentsServiceCancellationCLI
    {
        private static String orderReferenceId;
        private static OffAmazonPaymentsServiceCancellation instance;

        public static void Main(string[] args)
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("Welcome to Off Amazon Payments Service Cancellation Sample!");
            Console.WriteLine("===========================================");
            Console.WriteLine();

            init();
            instance = new OffAmazonPaymentsServiceCancellation();
            RunSample();

            Console.WriteLine();
            Console.WriteLine("===========================================");
            Console.WriteLine("End of output. You can close this window");
            Console.WriteLine("===========================================");

            System.Threading.Thread.Sleep(50000);
        }

        //Read the order reference object id from the command line
        private static void init()
        {
            orderReferenceId = CLIHelper.getStringFromConsole("order reference id");
        }

        private static void RunSample()
        {
            CancelOrderReferenceResponse response = instance.CancelOrderReference(orderReferenceId);
            if (response == null)
                throw new OffAmazonPaymentsServiceException("The response from the CancelOrderReference request is null");
        }
    }
}

