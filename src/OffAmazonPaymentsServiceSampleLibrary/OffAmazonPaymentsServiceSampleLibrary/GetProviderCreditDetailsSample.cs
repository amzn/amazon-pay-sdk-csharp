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
    public class GetProviderCreditDetailsSample : SampleBase
    {
        public static GetProviderCreditDetailsResponse InvokeGetProviderCreditDetails(IOffAmazonPaymentsService service, GetProviderCreditDetailsRequest request)
        {
            GetProviderCreditDetailsResponse response = null;
            try
            {
                response = service.GetProviderCreditDetails(request);
                Console.WriteLine("Service Response");
                Console.WriteLine("=============================================================================");
                Console.WriteLine();
                Console.WriteLine("        GetProviderCreditDetailsResponse");
                if (response.IsSetGetProviderCreditDetailsResult())
                {
                    Console.WriteLine("            GetProviderCreditDetailsResult");
                    GetProviderCreditDetailsResult GetProviderCreditDetailsResult = response.GetProviderCreditDetailsResult;
                    if (GetProviderCreditDetailsResult.IsSetProviderCreditDetails())
                    {
                        Console.WriteLine("                ProviderCreditDetails");
                        ProviderCreditDetails providerCreditDetails = GetProviderCreditDetailsResult.ProviderCreditDetails;
                        if (providerCreditDetails.IsSetAmazonProviderCreditId())
                        {
                            Console.WriteLine("                    AmazonProviderCreditId");
                            Console.WriteLine("                        {0}", providerCreditDetails.AmazonProviderCreditId);
                        }
                        if (providerCreditDetails.IsSetCreditReferenceId())
                        {
                            Console.WriteLine("                    CreditReferenceId");
                            Console.WriteLine("                        {0}", providerCreditDetails.CreditReferenceId);
                        }
                        if (providerCreditDetails.IsSetProviderId())
                        {
                            Console.WriteLine("                    ProviderId");
                            Console.WriteLine("                        {0}", providerCreditDetails.ProviderId);
                        }
                        if (providerCreditDetails.IsSetSellerId())
                        {
                            Console.WriteLine("                    SellerId");
                            Console.WriteLine("                        {0}", providerCreditDetails.SellerId);
                        }
                        if (providerCreditDetails.IsSetCreditAmount())
                        {
                            Console.WriteLine("                    CreditAmount");
                            Price creditAmount = providerCreditDetails.CreditAmount;
                            if (creditAmount.IsSetAmount())
                            {
                                Console.WriteLine("                        Amount");
                                Console.WriteLine("                            {0}", creditAmount.Amount);
                            }
                            if (creditAmount.IsSetCurrencyCode())
                            {
                                Console.WriteLine("                        CurrencyCode");
                                Console.WriteLine("                            {0}", creditAmount.CurrencyCode);
                            }
                        }
                        if (providerCreditDetails.IsSetCreditReversalAmount())
                        {
                            Console.WriteLine("                    CreditReversalAmount");
                            Price creditReversalAmount = providerCreditDetails.CreditReversalAmount;
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
                        if (providerCreditDetails.IsSetCreationTimestamp())
                        {
                            Console.WriteLine("                    CreationTimestamp");
                            Console.WriteLine("                        {0}", providerCreditDetails.CreationTimestamp);
                        }
                        if (providerCreditDetails.IsSetCreditStatus())
                        {
                            Console.WriteLine("                    creditStatus");
                            Status creditStatus = providerCreditDetails.CreditStatus;
                            if (creditStatus.IsSetState())
                            {
                                Console.WriteLine("                        State");
                                Console.WriteLine("                            {0}", creditStatus.State);
                            }
                            if (creditStatus.IsSetLastUpdateTimestamp())
                            {
                                Console.WriteLine("                        LastUpdateTimestamp");
                                Console.WriteLine("                            {0}", creditStatus.LastUpdateTimestamp);
                            }
                            if (creditStatus.IsSetReasonCode())
                            {
                                Console.WriteLine("                        ReasonCode");
                                Console.WriteLine("                            {0}", creditStatus.ReasonCode);
                            }
                            if (creditStatus.IsSetReasonDescription())
                            {
                                Console.WriteLine("                        ReasonDescription");
                                Console.WriteLine("                            {0}", creditStatus.ReasonDescription);
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

        public static GetProviderCreditDetailsResponse GetProviderCreditDetails(OffAmazonPaymentsServicePropertyCollection propertiesCollection,
            IOffAmazonPaymentsService service, string providerCreditId)
        {
            GetProviderCreditDetailsRequest getProviderCreditDetailsRequest = new GetProviderCreditDetailsRequest();
            getProviderCreditDetailsRequest.AmazonProviderCreditId = providerCreditId;
            getProviderCreditDetailsRequest.SellerId = propertiesCollection.MerchantID;
            return GetProviderCreditDetailsSample.InvokeGetProviderCreditDetails(service, getProviderCreditDetailsRequest);
        }
    }
}

