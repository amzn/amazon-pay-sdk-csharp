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
    public class RefundSample : SampleBase
    {
        public static RefundResponse InvokeRefund(IOffAmazonPaymentsService service, RefundRequest request)
        {
            RefundResponse response = null;
            try
            {
                response = service.Refund(request);
                Console.WriteLine("Service Response");
                Console.WriteLine("=============================================================================");
                Console.WriteLine();
                Console.WriteLine("        RefundResponse");
                if (response.IsSetRefundResult())
                {
                    Console.WriteLine("            RefundResult");
                    RefundResult refundResult = response.RefundResult;
                    if (refundResult.IsSetRefundDetails())
                    {
                        Console.WriteLine("                RefundDetails");
                        RefundDetails refundDetails = refundResult.RefundDetails;
                        if (refundDetails.IsSetAmazonRefundId())
                        {
                            Console.WriteLine("                    AmazonRefundId");
                            Console.WriteLine("                        {0}", refundDetails.AmazonRefundId);
                        }
                        if (refundDetails.IsSetRefundReferenceId())
                        {
                            Console.WriteLine("                    RefundReferenceId");
                            Console.WriteLine("                        {0}", refundDetails.RefundReferenceId);
                        }
                        if (refundDetails.IsSetSellerRefundNote())
                        {
                            Console.WriteLine("                    SellerRefundNote");
                            Console.WriteLine("                        {0}", refundDetails.SellerRefundNote);
                        }
                        if (refundDetails.IsSetRefundType())
                        {
                            Console.WriteLine("                    RefundType");
                            Console.WriteLine("                        {0}", refundDetails.RefundType);
                        }
                        if (refundDetails.IsSetFeeRefunded())
                        {
                            Console.WriteLine("                    FeeRefunded");
                            Price feeRefunded = refundDetails.FeeRefunded;
                            if (feeRefunded.IsSetAmount())
                            {
                                Console.WriteLine("                        Amount");
                                Console.WriteLine("                            {0}", feeRefunded.Amount);
                            }
                            if (feeRefunded.IsSetCurrencyCode())
                            {
                                Console.WriteLine("                        CurrencyCode");
                                Console.WriteLine("                            {0}", feeRefunded.CurrencyCode);
                            }
                        }
                        if (refundDetails.IsSetCreationTimestamp())
                        {
                            Console.WriteLine("                    CreationTimestamp");
                            Console.WriteLine("                        {0}", refundDetails.CreationTimestamp);
                        }
                        if (refundDetails.IsSetProviderCreditReversalSummaryList())
                        {
                            foreach (ProviderCreditReversalSummary providerCreditReversalSummary in refundDetails.ProviderCreditReversalSummaryList.member)
                            {
                                if (providerCreditReversalSummary.IsSetProviderCreditReversalId())
                                {
                                    Console.WriteLine("                    ProviderCreditReversalId");
                                    Console.WriteLine("                        {0}", providerCreditReversalSummary.ProviderCreditReversalId);
                                }
                                if (providerCreditReversalSummary.IsSetProviderId())
                                {
                                    Console.WriteLine("                    ProviderId");
                                    Console.WriteLine("                        {0}", providerCreditReversalSummary.ProviderId);
                                }
                            }
                        }
                        if (refundDetails.IsSetRefundStatus())
                        {
                            Console.WriteLine("                    RefundStatus");
                            Status refundStatus = refundDetails.RefundStatus;
                            if (refundStatus.IsSetState())
                            {
                                Console.WriteLine("                        State");
                                Console.WriteLine("                            {0}", refundStatus.State);
                            }
                            if (refundStatus.IsSetLastUpdateTimestamp())
                            {
                                Console.WriteLine("                        LastUpdateTimestamp");
                                Console.WriteLine("                            {0}", refundStatus.LastUpdateTimestamp);
                            }
                            if (refundStatus.IsSetReasonCode())
                            {
                                Console.WriteLine("                        ReasonCode");
                                Console.WriteLine("                            {0}", refundStatus.ReasonCode);
                            }
                            if (refundStatus.IsSetReasonDescription())
                            {
                                Console.WriteLine("                        ReasonDescription");
                                Console.WriteLine("                            {0}", refundStatus.ReasonDescription);
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

        public static RefundResponse RefundAction(IOffAmazonPaymentsService service, OffAmazonPaymentsServicePropertyCollection propertiesCollection, Random rng, string amazonCaptureID, string refundAmount, string providerId, string creditReversalAmountString)
        {

            //Initiate the Refund request, including SellerId, CaptureId, RefundReferenceId and RefundAmount
            RefundRequest request = new RefundRequest();
            request.SellerId = propertiesCollection.MerchantID;
            request.AmazonCaptureId = amazonCaptureID;
            request.RefundReferenceId = amazonCaptureID.Replace("-", "") + "r" + rng.Next(1, 1000).ToString();

            //assign the refundAmount to the refund request
            Price price = new Price();
            price.Amount = refundAmount;
            price.CurrencyCode = propertiesCollection.CurrencyCode;
            request.RefundAmount = price;
            if (!String.IsNullOrEmpty(providerId) && !String.IsNullOrEmpty(creditReversalAmountString))
            {
                ProviderCreditReversal providerCreditReversal = new ProviderCreditReversal();
                providerCreditReversal.ProviderId = providerId;
                Price creditReversalAmount = new Price();
                creditReversalAmount.Amount = creditReversalAmountString;
                creditReversalAmount.CurrencyCode = propertiesCollection.CurrencyCode;
                providerCreditReversal.CreditReversalAmount = creditReversalAmount;
                ProviderCreditReversalList providerCreditReversalList = new ProviderCreditReversalList();
                providerCreditReversalList.member = new List<ProviderCreditReversal>();
                providerCreditReversalList.member.Add(providerCreditReversal);
                request.ProviderCreditReversalList = providerCreditReversalList;
            }
            return RefundSample.InvokeRefund(service, request);
        }

        public static GetRefundDetailsResponse CheckRefundStatus(string amazonRefundId, IOffAmazonPaymentsService service, OffAmazonPaymentsServicePropertyCollection propertiesCollection)
        {
            //used to check if the refund is time-out
            TimeSpan startTime = DateTime.Now.TimeOfDay;
            GetRefundDetailsRequest refundDetailRequest = new GetRefundDetailsRequest();
            refundDetailRequest.SellerId = propertiesCollection.MerchantID;
            refundDetailRequest.AmazonRefundId = amazonRefundId;

            GetRefundDetailsResponse getRefundDetailsResponse = GetRefundDetailsSample.InvokeGetRefundDetails(service, refundDetailRequest);
            while (getRefundDetailsResponse.IsSetGetRefundDetailsResult() && getRefundDetailsResponse.GetRefundDetailsResult.RefundDetails.RefundStatus.State.Equals(PaymentStatus.PENDING))
            {
                if (DateTime.Now.TimeOfDay.Milliseconds - startTime.Milliseconds > 60000)
                    throw new OffAmazonPaymentsServiceException("The refund has timed-out.");

                System.Threading.Thread.Sleep(8000);
                Console.WriteLine("Waiting until the Refund Status changes from PENDING");
                getRefundDetailsResponse = GetRefundDetailsSample.InvokeGetRefundDetails(service, refundDetailRequest);
            }

            return getRefundDetailsResponse;

        }
    }
}
