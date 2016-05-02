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
using OffAmazonPaymentsService.Model;



namespace OffAmazonPaymentsServiceSampleLibrary
{
    public class AuthorizeOnBillingAgreementSample : SampleBase
    {
        public static AuthorizeOnBillingAgreementResponse InvokeAuthorizeOnBillingAgreement(IOffAmazonPaymentsService service, AuthorizeOnBillingAgreementRequest request)
        {
            AuthorizeOnBillingAgreementResponse response = null;
            try
            {
                
                response = service.AuthorizeOnBillingAgreement(request);

                Console.WriteLine("Service Response");
                Console.WriteLine("=============================================================================");
                Console.WriteLine();

                Console.WriteLine("        AuthorizeOnBillingAgreementResponse");
                if (response.IsSetAuthorizeOnBillingAgreementResult())
                {
                    Console.WriteLine("            AuthorizeOnBillingAgreementResult");
                    AuthorizeOnBillingAgreementResult authorizeOnBillingAgreementResult = response.AuthorizeOnBillingAgreementResult;
                    if (authorizeOnBillingAgreementResult.IsSetAuthorizationDetails())
                    {
                        Console.WriteLine("                AuthorizationDetails");
                        AuthorizationDetails authorizationDetails = authorizeOnBillingAgreementResult.AuthorizationDetails;
                        if (authorizationDetails.IsSetAmazonAuthorizationId())
                        {
                            Console.WriteLine("                    AmazonAuthorizationId");
                            Console.WriteLine("                        {0}", authorizationDetails.AmazonAuthorizationId);
                        }
                        if (authorizationDetails.IsSetAuthorizationReferenceId())
                        {
                            Console.WriteLine("                    AuthorizationReferenceId");
                            Console.WriteLine("                        {0}", authorizationDetails.AuthorizationReferenceId);
                        }
                        if (authorizationDetails.IsSetAuthorizationBillingAddress())
                        {
                            Console.WriteLine("                    AuthorizationBillingAddress");
                            Address authorizationBillingAddress = authorizationDetails.AuthorizationBillingAddress;
                            if (authorizationBillingAddress.IsSetName())
                            {
                                Console.WriteLine("                        Name");
                                Console.WriteLine("                            {0}", authorizationBillingAddress.Name);
                            }
                            if (authorizationBillingAddress.IsSetAddressLine1())
                            {
                                Console.WriteLine("                        AddressLine1");
                                Console.WriteLine("                            {0}", authorizationBillingAddress.AddressLine1);
                            }
                            if (authorizationBillingAddress.IsSetAddressLine2())
                            {
                                Console.WriteLine("                        AddressLine2");
                                Console.WriteLine("                            {0}", authorizationBillingAddress.AddressLine2);
                            }
                            if (authorizationBillingAddress.IsSetAddressLine3())
                            {
                                Console.WriteLine("                        AddressLine3");
                                Console.WriteLine("                            {0}", authorizationBillingAddress.AddressLine3);
                            }
                            if (authorizationBillingAddress.IsSetCity())
                            {
                                Console.WriteLine("                        City");
                                Console.WriteLine("                            {0}", authorizationBillingAddress.City);
                            }
                            if (authorizationBillingAddress.IsSetCounty())
                            {
                                Console.WriteLine("                        County");
                                Console.WriteLine("                            {0}", authorizationBillingAddress.County);
                            }
                            if (authorizationBillingAddress.IsSetDistrict())
                            {
                                Console.WriteLine("                        District");
                                Console.WriteLine("                            {0}", authorizationBillingAddress.District);
                            }
                            if (authorizationBillingAddress.IsSetStateOrRegion())
                            {
                                Console.WriteLine("                        StateOrRegion");
                                Console.WriteLine("                            {0}", authorizationBillingAddress.StateOrRegion);
                            }
                            if (authorizationBillingAddress.IsSetPostalCode())
                            {
                                Console.WriteLine("                        PostalCode");
                                Console.WriteLine("                            {0}", authorizationBillingAddress.PostalCode);
                            }
                            if (authorizationBillingAddress.IsSetCountryCode())
                            {
                                Console.WriteLine("                        CountryCode");
                                Console.WriteLine("                            {0}", authorizationBillingAddress.CountryCode);
                            }
                            if (authorizationBillingAddress.IsSetPhone())
                            {
                                Console.WriteLine("                        Phone");
                                Console.WriteLine("                            {0}", authorizationBillingAddress.Phone);
                            }
                        }
                        if (authorizationDetails.IsSetSellerAuthorizationNote())
                        {
                            Console.WriteLine("                    SellerAuthorizationNote");
                            Console.WriteLine("                        {0}", authorizationDetails.SellerAuthorizationNote);
                        }
                        if (authorizationDetails.IsSetAuthorizationAmount())
                        {
                            Console.WriteLine("                    AuthorizationAmount");
                            Price authorizationAmount = authorizationDetails.AuthorizationAmount;
                            if (authorizationAmount.IsSetAmount())
                            {
                                Console.WriteLine("                        Amount");
                                Console.WriteLine("                            {0}", authorizationAmount.Amount);
                            }
                            if (authorizationAmount.IsSetCurrencyCode())
                            {
                                Console.WriteLine("                        CurrencyCode");
                                Console.WriteLine("                            {0}", authorizationAmount.CurrencyCode);
                            }
                        }
                        if (authorizationDetails.IsSetCapturedAmount())
                        {
                            Console.WriteLine("                    CapturedAmount");
                            Price capturedAmount = authorizationDetails.CapturedAmount;
                            if (capturedAmount.IsSetAmount())
                            {
                                Console.WriteLine("                        Amount");
                                Console.WriteLine("                            {0}", capturedAmount.Amount);
                            }
                            if (capturedAmount.IsSetCurrencyCode())
                            {
                                Console.WriteLine("                        CurrencyCode");
                                Console.WriteLine("                            {0}", capturedAmount.CurrencyCode);
                            }
                        }
                        if (authorizationDetails.IsSetAuthorizationFee())
                        {
                            Console.WriteLine("                    AuthorizationFee");
                            Price authorizationFee = authorizationDetails.AuthorizationFee;
                            if (authorizationFee.IsSetAmount())
                            {
                                Console.WriteLine("                        Amount");
                                Console.WriteLine("                            {0}", authorizationFee.Amount);
                            }
                            if (authorizationFee.IsSetCurrencyCode())
                            {
                                Console.WriteLine("                        CurrencyCode");
                                Console.WriteLine("                            {0}", authorizationFee.CurrencyCode);
                            }
                        }
                        if (authorizationDetails.IsSetIdList())
                        {
                            Console.WriteLine("                    IdList");
                            IdList idList = authorizationDetails.IdList;
                            List<String> memberList = idList.member;
                            foreach (String member in memberList)
                            {
                                Console.WriteLine("                        member");
                                Console.WriteLine("                            {0}", member);
                            }
                        }
                        if (authorizationDetails.IsSetCreationTimestamp())
                        {
                            Console.WriteLine("                    CreationTimestamp");
                            Console.WriteLine("                        {0}", authorizationDetails.CreationTimestamp);
                        }
                        if (authorizationDetails.IsSetExpirationTimestamp())
                        {
                            Console.WriteLine("                    ExpirationTimestamp");
                            Console.WriteLine("                        {0}", authorizationDetails.ExpirationTimestamp);
                        }
                        if (authorizationDetails.IsSetAuthorizationStatus())
                        {
                            Console.WriteLine("                    AuthorizationStatus");
                            Status authorizationStatus = authorizationDetails.AuthorizationStatus;
                            if (authorizationStatus.IsSetState())
                            {
                                Console.WriteLine("                        State");
                                Console.WriteLine("                            {0}", authorizationStatus.State);
                            }
                            if (authorizationStatus.IsSetLastUpdateTimestamp())
                            {
                                Console.WriteLine("                        LastUpdateTimestamp");
                                Console.WriteLine("                            {0}", authorizationStatus.LastUpdateTimestamp);
                            }
                            if (authorizationStatus.IsSetReasonCode())
                            {
                                Console.WriteLine("                        ReasonCode");
                                Console.WriteLine("                            {0}", authorizationStatus.ReasonCode);
                            }
                            if (authorizationStatus.IsSetReasonDescription())
                            {
                                Console.WriteLine("                        ReasonDescription");
                                Console.WriteLine("                            {0}", authorizationStatus.ReasonDescription);
                            }
                        }
                        if (authorizationDetails.IsSetOrderItemCategories())
                        {
                            Console.WriteLine("                    OrderItemCategories");
                            OrderItemCategories orderItemCategories = authorizationDetails.OrderItemCategories;
                            List<String> orderItemCategoryList = orderItemCategories.OrderItemCategory;
                            foreach (String orderItemCategory in orderItemCategoryList)
                            {
                                Console.WriteLine("                        OrderItemCategory");
                                Console.WriteLine("                            {0}", orderItemCategory);
                            }
                        }
                        if (authorizationDetails.IsSetCaptureNow())
                        {
                            Console.WriteLine("                    CaptureNow");
                            Console.WriteLine("                        {0}", authorizationDetails.CaptureNow);
                        }
                        if (authorizationDetails.IsSetSoftDescriptor())
                        {
                            Console.WriteLine("                    SoftDescriptor");
                            Console.WriteLine("                        {0}", authorizationDetails.SoftDescriptor);
                        }
                        if (authorizationDetails.IsSetAddressVerificationCode())
                        {
                            Console.WriteLine("                    AddressVerificationCode");
                            Console.WriteLine("                        {0}", authorizationDetails.AddressVerificationCode);
                        }
                    }
                    if (authorizeOnBillingAgreementResult.IsSetAmazonOrderReferenceId())
                    {
                        Console.WriteLine("                AmazonOrderReferenceId");
                        Console.WriteLine("                    {0}", authorizeOnBillingAgreementResult.AmazonOrderReferenceId);
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

        public static AuthorizeOnBillingAgreementResponse AuthorizeOnBillingAgreement(OffAmazonPaymentsServicePropertyCollection propertiesCollection,
            IOffAmazonPaymentsService service, string billingAgreementId, String authAmount, int indicator, bool captureNow)
        {
            AuthorizeOnBillingAgreementRequest request = new AuthorizeOnBillingAgreementRequest();
            request.AmazonBillingAgreementId = billingAgreementId;
            request.SellerId = propertiesCollection.MerchantID;
            Price price = new Price();
            price.Amount = authAmount;
            price.CurrencyCode = propertiesCollection.CurrencyCode;
            request.AuthorizationAmount = price;
            request.CaptureNow = captureNow;
            request.AuthorizationReferenceId = billingAgreementId.Replace('-', 'a') + "authRef" + indicator.ToString();
            return InvokeAuthorizeOnBillingAgreement(service, request);
        }
    }
}
