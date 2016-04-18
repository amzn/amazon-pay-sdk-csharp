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
    public class GetProviderCreditReversalDetailsSample : SampleBase
    {
        public static GetProviderCreditReversalDetailsResponse InvokeGetProviderCreditReversalDetails(IOffAmazonPaymentsService service, GetProviderCreditReversalDetailsRequest request)
        {
            GetProviderCreditReversalDetailsResponse response = null;
            try
            {
                response = service.GetProviderCreditReversalDetails(request);
                Console.WriteLine("Service Response");
                Console.WriteLine("=============================================================================");
                Console.WriteLine();
                Console.WriteLine("        GetProviderCreditReversalDetailsResponse");
                if (response.IsSetGetProviderCreditReversalDetailsResult())
                {
                    Console.WriteLine("            GetProviderCreditReversalDetailsResult");
                    GetProviderCreditReversalDetailsResult GetProviderCreditReversalDetailsResult = response.GetProviderCreditReversalDetailsResult;
                    if (GetProviderCreditReversalDetailsResult.IsSetProviderCreditReversalDetails())
                    {
                        Console.WriteLine("                ProviderCreditReversalDetails");
                        ProviderCreditReversalDetails ProviderCreditReversalDetails = GetProviderCreditReversalDetailsResult.ProviderCreditReversalDetails;
                        if (ProviderCreditReversalDetails.IsSetAmazonProviderCreditReversalId())
                        {
                            Console.WriteLine("                    AmazonProviderCreditReversalId");
                            Console.WriteLine("                        {0}", ProviderCreditReversalDetails.AmazonProviderCreditReversalId);
                        }
                        if (ProviderCreditReversalDetails.IsSetCreditReversalReferenceId())
                        {
                            Console.WriteLine("                    CreditReversalReferenceId");
                            Console.WriteLine("                        {0}", ProviderCreditReversalDetails.AmazonProviderCreditReversalId);
                        }
                        if (ProviderCreditReversalDetails.IsSetProviderId())
                        {
                            Console.WriteLine("                    ProviderId");
                            Console.WriteLine("                        {0}", ProviderCreditReversalDetails.ProviderId);
                        }
                        if (ProviderCreditReversalDetails.IsSetSellerId())
                        {
                            Console.WriteLine("                    SellerId");
                            Console.WriteLine("                        {0}", ProviderCreditReversalDetails.SellerId);
                        }
                        if (ProviderCreditReversalDetails.IsSetCreditReversalAmount())
                        {
                            Console.WriteLine("                    CreditReversalAmount");
                            Price creditReversalAmount = ProviderCreditReversalDetails.CreditReversalAmount;
                            if (creditReversalAmount.IsSetAmount())
                            {
                                Console.WriteLine("                        Amount");
                                Console.WriteLine("                            {0}", creditReversalAmount.Amount);
                            }
                            if (creditReversalAmount.IsSetCurrencyCode())
                            {
                                Console.WriteLine("                        CurrencyCode");
                                Console.WriteLine("                            {0}", creditReversalAmount.CurrencyCode);
                            }
                        }
                        if (ProviderCreditReversalDetails.IsSetCreationTimestamp())
                        {
                            Console.WriteLine("                    CreationTimestamp");
                            Console.WriteLine("                        {0}", ProviderCreditReversalDetails.CreationTimestamp);
                        }
                        if (ProviderCreditReversalDetails.IsSetCreditReversalStatus())
                        {
                            Console.WriteLine("                    CreditReversalStatus");
                            Status creditReversalStatus = ProviderCreditReversalDetails.CreditReversalStatus;
                            if (creditReversalStatus.IsSetState())
                            {
                                Console.WriteLine("                        State");
                                Console.WriteLine("                            {0}", creditReversalStatus.State);
                            }
                            if (creditReversalStatus.IsSetLastUpdateTimestamp())
                            {
                                Console.WriteLine("                        LastUpdateTimestamp");
                                Console.WriteLine("                            {0}", creditReversalStatus.LastUpdateTimestamp);
                            }
                            if (creditReversalStatus.IsSetReasonCode())
                            {
                                Console.WriteLine("                        ReasonCode");
                                Console.WriteLine("                            {0}", creditReversalStatus.ReasonCode);
                            }
                            if (creditReversalStatus.IsSetReasonDescription())
                            {
                                Console.WriteLine("                        ReasonDescription");
                                Console.WriteLine("                            {0}", creditReversalStatus.ReasonDescription);
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

        public static GetProviderCreditReversalDetailsResponse GetProviderCreditReversalDetails( IOffAmazonPaymentsService service, OffAmazonPaymentsServicePropertyCollection propertiesCollection, string providerCreditReversalId)
        {
            GetProviderCreditReversalDetailsRequest getProviderCreditReversalDetailsRequest = new GetProviderCreditReversalDetailsRequest();
            getProviderCreditReversalDetailsRequest.AmazonProviderCreditReversalId = providerCreditReversalId;
            getProviderCreditReversalDetailsRequest.SellerId = propertiesCollection.MerchantID;
            return GetProviderCreditReversalDetailsSample.InvokeGetProviderCreditReversalDetails(service, getProviderCreditReversalDetailsRequest);
        }
    }
}

