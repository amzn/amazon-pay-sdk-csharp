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
    public class GetCaptureDetailsSample : SampleBase
    {
        public static GetCaptureDetailsResponse InvokeGetCaptureDetails(IOffAmazonPaymentsService service, GetCaptureDetailsRequest request)
        {
            GetCaptureDetailsResponse response = null;
            try
            {
                response = service.GetCaptureDetails(request);
                Console.WriteLine("Service Response");
                Console.WriteLine("=============================================================================");
                Console.WriteLine();
                Console.WriteLine("        GetCaptureDetailsResponse");
                if (response.IsSetGetCaptureDetailsResult())
                {
                    Console.WriteLine("            GetCaptureDetailsResult");
                    GetCaptureDetailsResult getCaptureDetailsResult = response.GetCaptureDetailsResult;
                    if (getCaptureDetailsResult.IsSetCaptureDetails())
                    {
                        Console.WriteLine("                CaptureDetails");
                        CaptureDetails captureDetails = getCaptureDetailsResult.CaptureDetails;
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
            }
            catch (OffAmazonPaymentsServiceException ex)
            {
                PrintException(ex);
            }
            return response;
        }

        public static GetCaptureDetailsResponse GetCaptureDetails(OffAmazonPaymentsServicePropertyCollection propertiesCollection,
            IOffAmazonPaymentsService service, string amazonCaptureId)
        {
            GetCaptureDetailsRequest getCaptureDetailsRequest = new GetCaptureDetailsRequest();
            getCaptureDetailsRequest.AmazonCaptureId = amazonCaptureId;
            getCaptureDetailsRequest.SellerId = propertiesCollection.MerchantID;
            return GetCaptureDetailsSample.InvokeGetCaptureDetails(service, getCaptureDetailsRequest);
        }

        public static ProviderCreditSummaryList CheckCaptureForProviderCreditSummaryList(string amazonCaptureId, OffAmazonPaymentsServicePropertyCollection propertiesCollection, IOffAmazonPaymentsService service)
        {

            //used to check if the ProviderCreditSummaryList is available
            TimeSpan startTime = DateTime.Now.TimeOfDay;
            GetCaptureDetailsResponse getCaptureDetailsResponse = GetCaptureDetailsSample.GetCaptureDetails(propertiesCollection, service, amazonCaptureId);
            while (getCaptureDetailsResponse.IsSetGetCaptureDetailsResult() && (!getCaptureDetailsResponse.GetCaptureDetailsResult.CaptureDetails.IsSetProviderCreditSummaryList() || getCaptureDetailsResponse.GetCaptureDetailsResult.CaptureDetails.ProviderCreditSummaryList.member.Count < 1))
            {
                if (DateTime.Now.TimeOfDay.Milliseconds - startTime.Milliseconds > 60000)
                    throw new OffAmazonPaymentsServiceException("The ProviderCreditSummaryList not found.");
                System.Threading.Thread.Sleep(8000);
                Console.WriteLine("Waiting until ProviderCreditSummaryList is found in GetCaptureDetailsResponse");
                getCaptureDetailsResponse = GetCaptureDetailsSample.GetCaptureDetails(propertiesCollection, service, amazonCaptureId);
            }
            return getCaptureDetailsResponse.GetCaptureDetailsResult.CaptureDetails.ProviderCreditSummaryList;
        }       
    }
}

