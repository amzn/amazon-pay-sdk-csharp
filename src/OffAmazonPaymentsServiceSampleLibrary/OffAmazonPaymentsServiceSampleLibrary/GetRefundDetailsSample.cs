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
    public class GetRefundDetailsSample : SampleBase
    {
        public static GetRefundDetailsResponse InvokeGetRefundDetails(IOffAmazonPaymentsService service, GetRefundDetailsRequest request)
        {
            GetRefundDetailsResponse response = null;
            try
            {
                response = service.GetRefundDetails(request);
                Console.WriteLine("Service Response");
                Console.WriteLine("=============================================================================");
                Console.WriteLine();
                Console.WriteLine("        GetRefundDetailsResponse");
                if (response.IsSetGetRefundDetailsResult())
                {
                    Console.WriteLine("            GetRefundDetailsResult");
                    GetRefundDetailsResult getRefundDetailsResult = response.GetRefundDetailsResult;
                    if (getRefundDetailsResult.IsSetRefundDetails())
                    {
                        Console.WriteLine("                RefundDetails");
                        RefundDetails refundDetails = getRefundDetailsResult.RefundDetails;
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

        public static GetRefundDetailsResponse GetRefundDetails(IOffAmazonPaymentsService service, OffAmazonPaymentsServicePropertyCollection propertiesCollection, string amazonRefundId)
        {
            GetRefundDetailsRequest request = new GetRefundDetailsRequest();
            request.SellerId = propertiesCollection.MerchantID;
            request.AmazonRefundId = amazonRefundId;
            return GetRefundDetailsSample.InvokeGetRefundDetails(service, request);
        }
    }
}

