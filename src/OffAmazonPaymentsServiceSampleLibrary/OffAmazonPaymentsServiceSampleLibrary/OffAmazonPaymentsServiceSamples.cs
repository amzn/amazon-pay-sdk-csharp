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
using System.Xml.Serialization;
using System.Collections.Generic;
using OffAmazonPaymentsService;
using OffAmazonPaymentsService.Mock;
using OffAmazonPaymentsService.Model;

namespace OffAmazonPaymentsService.Samples
{
    /// <summary>
    /// Off Amazon Payments Service  Samples
    /// </summary>
    public class OffAmazonPaymentsServiceSamples 
    {   
       /**
        * Samples for Off Amazon Payments Service functionality
        */
        public static void Main(string [] args) 
        {
            Console.WriteLine("===========================================");
            Console.WriteLine("Welcome to Off Amazon Payments Service Samples!");
            Console.WriteLine("===========================================");

            Console.WriteLine("To get started:");
            Console.WriteLine("===========================================");
            Console.WriteLine("  - Fill in your MWS credentials");
            Console.WriteLine("  - Uncomment sample you're interested in trying");
            Console.WriteLine("  - Set request with desired parameters");
            Console.WriteLine("  - Hit F5 to run!");
            Console.WriteLine();

            Console.WriteLine("===========================================");
            Console.WriteLine("Samples Output");
            Console.WriteLine("===========================================");
            Console.WriteLine();

           /************************************************************************
            * Access Key ID and Secret Access Key ID
            ***********************************************************************/
            String accessKeyId = "<Your Access Key Id>";
            String secretAccessKey = "<Your Secret Access Key>";
            String merchantId = "<Your Merchant Id>";
            String marketplaceId = "<Your Marketplace Id>";

            /************************************************************************
             * The application name and version are included in each MWS call's
             * HTTP User-Agent field.
             ***********************************************************************/
            const string applicationName = "<Your Application Name>";
            const string applicationVersion = "<Your Application Version>";

            /************************************************************************
            * Uncomment to try advanced configuration options. Available options are:
            *
            *  - Signature Version
            *  - Proxy Host and Proxy Port
            *  - Service URL
            *  - User Agent String to be sent to Off Amazon Payments Service  service
            *
            ***********************************************************************/
            OffAmazonPaymentsServiceConfig config = new OffAmazonPaymentsServiceConfig();
            //
            // IMPORTANT: Uncomment out the appropriate line for the country you wish 
            // to sell in:
            // 
            // United States:
            // config.ServiceURL = "https://mws.amazonservices.com/OffAmazonPayments/2013-01-01";
            //
            // Canada:
            // config.ServiceURL = "https://mws.amazonservices.ca/OffAmazonPayments/2013-01-01";
            //
            // Europe:
            // config.ServiceURL = "https://mws-eu.amazonservices.com/OffAmazonPayments/2013-01-01";
            //
            // Japan:
            // config.ServiceURL = "https://mws.amazonservices.jp/OffAmazonPayments/2013-01-01";
            //
            // China:
            // config.ServiceURL = "https://mws.amazonservices.com.cn/OffAmazonPayments/2013-01-01";
            //

            /************************************************************************
            * Instantiate  Implementation of Off Amazon Payments Service  
            ***********************************************************************/
            IOffAmazonPaymentsService service = new OffAmazonPaymentsServiceClient(
                applicationName, applicationVersion, accessKeyId, secretAccessKey, config);
         
            /************************************************************************
            * Uncomment to try out Mock Service that simulates Off Amazon Payments Service 
            * responses without calling Off Amazon Payments Service  service.
            *
            * Responses are loaded from local XML files. You can tweak XML files to
            * experiment with various outputs during development
            *
            * XML files available under OffAmazonPaymentsService\Mock tree
            *
            ***********************************************************************/
            // OffAmazonPaymentsService service = new OffAmazonPaymentsServiceMock();


            /************************************************************************
            * Uncomment to invoke Capture Action
            ***********************************************************************/
            // CaptureRequest request = new CaptureRequest();
            // @TODO: set request parameters here
            // request.SellerId = merchantId;
            
            // CaptureSample.InvokeCapture(service, request);
            /************************************************************************
            * Uncomment to invoke Refund Action
            ***********************************************************************/
            // RefundRequest request = new RefundRequest();
            // @TODO: set request parameters here
            // request.SellerId = merchantId;
            
            // RefundSample.InvokeRefund(service, request);
            /************************************************************************
            * Uncomment to invoke Close Authorization Action
            ***********************************************************************/
            // CloseAuthorizationRequest request = new CloseAuthorizationRequest();
            // @TODO: set request parameters here
            // request.SellerId = merchantId;
            
            // CloseAuthorizationSample.InvokeCloseAuthorization(service, request);
            /************************************************************************
            * Uncomment to invoke Get Refund Details Action
            ***********************************************************************/
            // GetRefundDetailsRequest request = new GetRefundDetailsRequest();
            // @TODO: set request parameters here
            // request.SellerId = merchantId;
            
            // GetRefundDetailsSample.InvokeGetRefundDetails(service, request);
            /************************************************************************
            * Uncomment to invoke Get Capture Details Action
            ***********************************************************************/
            // GetCaptureDetailsRequest request = new GetCaptureDetailsRequest();
            // @TODO: set request parameters here
            // request.SellerId = merchantId;
            
            // GetCaptureDetailsSample.InvokeGetCaptureDetails(service, request);
            /************************************************************************
            * Uncomment to invoke Close Order Reference Action
            ***********************************************************************/
            // CloseOrderReferenceRequest request = new CloseOrderReferenceRequest();
            // @TODO: set request parameters here
            // request.SellerId = merchantId;
            
            // CloseOrderReferenceSample.InvokeCloseOrderReference(service, request);
            /************************************************************************
            * Uncomment to invoke Confirm Order Reference Action
            ***********************************************************************/
            // ConfirmOrderReferenceRequest request = new ConfirmOrderReferenceRequest();
            // @TODO: set request parameters here
            // request.SellerId = merchantId;
            
            // ConfirmOrderReferenceSample.InvokeConfirmOrderReference(service, request);
            /************************************************************************
            * Uncomment to invoke Get Order Reference Details Action
            ***********************************************************************/
            // GetOrderReferenceDetailsRequest request = new GetOrderReferenceDetailsRequest();
            // @TODO: set request parameters here
            // request.SellerId = merchantId;
            
            // GetOrderReferenceDetailsSample.InvokeGetOrderReferenceDetails(service, request);
            /************************************************************************
            * Uncomment to invoke Authorize Action
            ***********************************************************************/
            // AuthorizeRequest request = new AuthorizeRequest();
            // @TODO: set request parameters here
            // request.SellerId = merchantId;
            
            // AuthorizeSample.InvokeAuthorize(service, request);
            /************************************************************************
            * Uncomment to invoke Set Order Reference Details Action
            ***********************************************************************/
            // SetOrderReferenceDetailsRequest request = new SetOrderReferenceDetailsRequest();
            // @TODO: set request parameters here
            // request.SellerId = merchantId;
            
            // SetOrderReferenceDetailsSample.InvokeSetOrderReferenceDetails(service, request);
            /************************************************************************
            * Uncomment to invoke Get Authorization Details Action
            ***********************************************************************/
            // GetAuthorizationDetailsRequest request = new GetAuthorizationDetailsRequest();
            // @TODO: set request parameters here
            // request.SellerId = merchantId;
            
            // GetAuthorizationDetailsSample.InvokeGetAuthorizationDetails(service, request);
            /************************************************************************
            * Uncomment to invoke Cancel Order Reference Action
            ***********************************************************************/
            // CancelOrderReferenceRequest request = new CancelOrderReferenceRequest();
            // @TODO: set request parameters here
            // request.SellerId = merchantId;
            
            // CancelOrderReferenceSample.InvokeCancelOrderReference(service, request);
            Console.WriteLine();
            Console.WriteLine("===========================================");
            Console.WriteLine("End of output. You can close this window");
            Console.WriteLine("===========================================");

            System.Threading.Thread.Sleep(50000);
        }

    }
}
