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
    public class ReverseProviderCreditSample : SampleBase
    {
        public static ReverseProviderCreditResponse InvokeReverseProviderCredit(IOffAmazonPaymentsService service, ReverseProviderCreditRequest request)
        {
            ReverseProviderCreditResponse response = null;
            try
            {
                response = service.ReverseProviderCredit(request);
                Console.WriteLine("Service Response");
                Console.WriteLine("=============================================================================");
                Console.WriteLine();
                Console.WriteLine("        ReverseProviderCreditResponse");
                if (response.IsSetReverseProviderCreditResult())
                {
                    Console.WriteLine("            ReverseProviderCreditResult");
                    ReverseProviderCreditResult ReverseProviderCreditResult = response.ReverseProviderCreditResult;
                    if (ReverseProviderCreditResult.IsSetProviderCreditReversalDetails())
                    {
                        Console.WriteLine("                ReverseProviderCreditDetails");
                        ProviderCreditReversalDetails ReverseProviderCreditDetails = ReverseProviderCreditResult.ProviderCreditReversalDetails;
                        if (ReverseProviderCreditDetails.IsSetAmazonProviderCreditReversalId())
                        {
                            Console.WriteLine("                    AmazonProviderCreditReversalId");
                            Console.WriteLine("                        {0}", ReverseProviderCreditDetails.AmazonProviderCreditReversalId);
                        }
                        if (ReverseProviderCreditDetails.IsSetCreditReversalReferenceId())
                        {
                            Console.WriteLine("                    CreditReversalReferenceId");
                            Console.WriteLine("                        {0}", ReverseProviderCreditDetails.CreditReversalReferenceId);
                        }
                        if (ReverseProviderCreditDetails.IsSetCreditReversalNote())
                        {
                            Console.WriteLine("                    CreditReversalNote");
                            Console.WriteLine("                        {0}", ReverseProviderCreditDetails.CreditReversalNote);
                        }
                        if (ReverseProviderCreditDetails.IsSetCreationTimestamp())
                        {
                            Console.WriteLine("                    CreationTimestamp");
                            Console.WriteLine("                        {0}", ReverseProviderCreditDetails.CreationTimestamp);
                        }
                        if (ReverseProviderCreditDetails.IsSetCreditReversalStatus())
                        {
                            Console.WriteLine("                    CreditReversalStatus");
                            Status ReverseProviderCreditStatus = ReverseProviderCreditDetails.CreditReversalStatus;
                            if (ReverseProviderCreditStatus.IsSetState())
                            {
                                Console.WriteLine("                        State");
                                Console.WriteLine("                            {0}", ReverseProviderCreditStatus.State);
                            }
                            if (ReverseProviderCreditStatus.IsSetLastUpdateTimestamp())
                            {
                                Console.WriteLine("                        LastUpdateTimestamp");
                                Console.WriteLine("                            {0}", ReverseProviderCreditStatus.LastUpdateTimestamp);
                            }
                            if (ReverseProviderCreditStatus.IsSetReasonCode())
                            {
                                Console.WriteLine("                        ReasonCode");
                                Console.WriteLine("                            {0}", ReverseProviderCreditStatus.ReasonCode);
                            }
                            if (ReverseProviderCreditStatus.IsSetReasonDescription())
                            {
                                Console.WriteLine("                        ReasonDescription");
                                Console.WriteLine("                            {0}", ReverseProviderCreditStatus.ReasonDescription);
                            }
                        }
                        if (ReverseProviderCreditDetails.IsSetSellerId())
                        {
                            Console.WriteLine("                    SellerId");
                            Console.WriteLine("                        {0}", ReverseProviderCreditDetails.SellerId);
                        }
                        if (ReverseProviderCreditDetails.IsSetProviderId())
                        {
                            Console.WriteLine("                    ProviderId");
                            Console.WriteLine("                        {0}", ReverseProviderCreditDetails.ProviderId);
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

        public static ReverseProviderCreditResponse ReverseProviderCreditAction(IOffAmazonPaymentsService service, OffAmazonPaymentsServicePropertyCollection propertiesCollection, Random rng, string amazonProviderCreditId, string creditReversalAmount)
        {
            //Initiate the ReverseProviderCredit request, including SellerId, AmazonProviderCreditId, CreditReversalReferenceId and CreditReversalAmount
            ReverseProviderCreditRequest request = new ReverseProviderCreditRequest();
            request.SellerId = propertiesCollection.MerchantID;
            request.AmazonProviderCreditId = amazonProviderCreditId;
            request.CreditReversalReferenceId = amazonProviderCreditId.Replace("-", "") + "r" + rng.Next(1, 1000).ToString();

            //assign the ReverseProviderCreditAmount to the ReverseProviderCredit request
            Price price = new Price();
            price.Amount = creditReversalAmount;
            price.CurrencyCode = propertiesCollection.CurrencyCode;
            request.CreditReversalAmount = price;

            return ReverseProviderCreditSample.InvokeReverseProviderCredit(service, request);
        }

    }
}
