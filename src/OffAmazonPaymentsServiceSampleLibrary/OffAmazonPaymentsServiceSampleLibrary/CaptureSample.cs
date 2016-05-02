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
using System.Xml.Serialization;
using System.Collections.Generic;
using OffAmazonPaymentsService;
using OffAmazonPaymentsService.Model;

namespace OffAmazonPaymentsServiceSampleLibrary
{
    public class CaptureSample : SampleBase
    {
        public static CaptureResponse InvokeCapture(IOffAmazonPaymentsService service, CaptureRequest request)
        {
            CaptureResponse response = null;
            try
            {
                response = service.Capture(request);
                Console.WriteLine("Service Response");
                Console.WriteLine("=============================================================================");
                Console.WriteLine();
                Console.WriteLine("        CaptureResponse");
                if (response.IsSetCaptureResult())
                {
                    Console.WriteLine("            CaptureResult");
                    CaptureResult captureResult = response.CaptureResult;
                    if (captureResult.IsSetCaptureDetails())
                    {
                        Console.WriteLine("                CaptureDetails");
                        CaptureDetails captureDetails = captureResult.CaptureDetails;
                        if (captureDetails.IsSetAmazonCaptureId())
                        {
                            Console.WriteLine("                    AmazonCaptureId");
                            Console.WriteLine("                        {0}", captureDetails.AmazonCaptureId);
                        }
                        if (captureDetails.IsSetCaptureReferenceId())
                        {
                            Console.WriteLine("                    CaptureReferenceId");
                            Console.WriteLine("                        {0}", captureDetails.CaptureReferenceId);
                        }
                        if (captureDetails.IsSetSellerCaptureNote())
                        {
                            Console.WriteLine("                    SellerCaptureNote");
                            Console.WriteLine("                        {0}", captureDetails.SellerCaptureNote);
                        }
                        if (captureDetails.IsSetCaptureAmount())
                        {
                            Console.WriteLine("                    CaptureAmount");
                            Price captureAmount = captureDetails.CaptureAmount;
                            if (captureAmount.IsSetAmount())
                            {
                                Console.WriteLine("                        Amount");
                                Console.WriteLine("                            {0}", captureAmount.Amount);
                            }
                            if (captureAmount.IsSetCurrencyCode())
                            {
                                Console.WriteLine("                        CurrencyCode");
                                Console.WriteLine("                            {0}", captureAmount.CurrencyCode);
                            }
                        }
                        if (captureDetails.IsSetRefundedAmount())
                        {
                            Console.WriteLine("                    RefundedAmount");
                            Price refundedAmount = captureDetails.RefundedAmount;
                            if (refundedAmount.IsSetAmount())
                            {
                                Console.WriteLine("                        Amount");
                                Console.WriteLine("                            {0}", refundedAmount.Amount);
                            }
                            if (refundedAmount.IsSetCurrencyCode())
                            {
                                Console.WriteLine("                        CurrencyCode");
                                Console.WriteLine("                            {0}", refundedAmount.CurrencyCode);
                            }
                        }
                        if (captureDetails.IsSetCaptureFee())
                        {
                            Console.WriteLine("                    CaptureFee");
                            Price captureFee = captureDetails.CaptureFee;
                            if (captureFee.IsSetAmount())
                            {
                                Console.WriteLine("                        Amount");
                                Console.WriteLine("                            {0}", captureFee.Amount);
                            }
                            if (captureFee.IsSetCurrencyCode())
                            {
                                Console.WriteLine("                        CurrencyCode");
                                Console.WriteLine("                            {0}", captureFee.CurrencyCode);
                            }
                        }
                        if (captureDetails.IsSetCreationTimestamp())
                        {
                            Console.WriteLine("                    CreationTimestamp");
                            Console.WriteLine("                        {0}", captureDetails.CreationTimestamp);
                        }
                        if (captureDetails.IsSetProviderCreditSummaryList())
                        {
                            Console.WriteLine("                    ProviderCreditSummaryList");
                            foreach (ProviderCreditSummary providerCreditSummary in captureDetails.ProviderCreditSummaryList.member)
                            {
                                if (providerCreditSummary.IsSetProviderCreditId())
                                {
                                    Console.WriteLine("                         ProviderCreditId");
                                    Console.WriteLine("                             {0}", providerCreditSummary.ProviderCreditId);
                                }
                                if (providerCreditSummary.IsSetProviderId())
                                {
                                    Console.WriteLine("                         ProviderId");
                                    Console.WriteLine("                             {0}", providerCreditSummary.ProviderId);
                                }

                            }
                        }
                        if (captureDetails.IsSetCaptureStatus())
                        {
                            Console.WriteLine("                    CaptureStatus");
                            Status captureStatus = captureDetails.CaptureStatus;
                            if (captureStatus.IsSetState())
                            {
                                Console.WriteLine("                        State");
                                Console.WriteLine("                            {0}", captureStatus.State);
                            }
                            if (captureStatus.IsSetLastUpdateTimestamp())
                            {
                                Console.WriteLine("                        LastUpdateTimestamp");
                                Console.WriteLine("                            {0}", captureStatus.LastUpdateTimestamp);
                            }
                            if (captureStatus.IsSetReasonCode())
                            {
                                Console.WriteLine("                        ReasonCode");
                                Console.WriteLine("                            {0}", captureStatus.ReasonCode);
                            }
                            if (captureStatus.IsSetReasonDescription())
                            {
                                Console.WriteLine("                        ReasonDescription");
                                Console.WriteLine("                            {0}", captureStatus.ReasonDescription);
                            }
                        }
                    }
                }

                if (response.IsSetResponseMetadata())
                {
                    Console.WriteLine("            ResponseMetadata");
                    ResponseMetadata responseMetadata = response.ResponseMetadata;
                    if (responseMetadata.IsSetRequestId())
                    {
                        Console.WriteLine("                RequestId");
                        Console.WriteLine("                    {0}", responseMetadata.RequestId);
                    }
                }
				
                Console.WriteLine();
            }

            catch (OffAmazonPaymentsServiceException ex)
            {
                PrintException(ex);
            }

            return response;
        }



        public static CaptureResponse CaptureAction(OffAmazonPaymentsServicePropertyCollection propertiesCollection,
            IOffAmazonPaymentsService service, string amazonAuthorizationId, string orderAmount, string orderReferenceId, int indicator, string providerId, string creditAmountString)
        {
            //initiate the capture request
            CaptureRequest captureRequest = new CaptureRequest();
            captureRequest.SellerId = propertiesCollection.MerchantID;
            captureRequest.AmazonAuthorizationId = amazonAuthorizationId;
            
			Price price = new Price();
            price.Amount = orderAmount;
            price.CurrencyCode = propertiesCollection.CurrencyCode;
			
            captureRequest.CaptureAmount = price;
            captureRequest.CaptureReferenceId = orderReferenceId.Replace('-', 'c') + "captureRef" + indicator.ToString();
            if (!String.IsNullOrEmpty(providerId) && !String.IsNullOrEmpty(creditAmountString))
            {
                ProviderCredit providerCredit = new ProviderCredit();
                providerCredit.ProviderId= providerId;
                Price creditAmount = new Price();
                creditAmount.Amount = creditAmountString;
                creditAmount.CurrencyCode = propertiesCollection.CurrencyCode;
                providerCredit.CreditAmount= creditAmount;
                ProviderCreditList providerCreditList = new ProviderCreditList();
                providerCreditList.member = new List<ProviderCredit>();
                providerCreditList.member.Add(providerCredit);
                captureRequest.ProviderCreditList = providerCreditList;
            }
            
            return CaptureSample.InvokeCapture(service, captureRequest);
        }


    }
}

