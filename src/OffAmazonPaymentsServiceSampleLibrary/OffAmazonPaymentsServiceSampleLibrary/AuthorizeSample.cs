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

    public class AuthorizeSample : SampleBase
    {
        public static AuthorizeResponse InvokeAuthorize(IOffAmazonPaymentsService service, AuthorizeRequest request)
        {
            AuthorizeResponse response = null;
            try
            {
                response = service.Authorize(request);

                Console.WriteLine("Service Response");
                Console.WriteLine("=============================================================================");
                Console.WriteLine();
                Console.WriteLine("        AuthorizeResponse");
                if (response.IsSetAuthorizeResult())
                {
                    Console.WriteLine("            AuthorizeResult");
                    AuthorizeResult authorizeResult = response.AuthorizeResult;
                    if (authorizeResult.IsSetAuthorizationDetails())
                    {
                        Console.WriteLine("                AuthorizationDetails");
                        AuthorizationDetails authorizationDetails = authorizeResult.AuthorizationDetails;
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
                                Console.WriteLine("                            Name");
                                Console.WriteLine("                                {0}", authorizationBillingAddress.Name);
                            }
                            if (authorizationBillingAddress.IsSetAddressLine1())
                            {
                                Console.WriteLine("                            AddressLine1");
                                Console.WriteLine("                                {0}", authorizationBillingAddress.AddressLine1);
                            }
                            if (authorizationBillingAddress.IsSetAddressLine2())
                            {
                                Console.WriteLine("                            AddressLine2");
                                Console.WriteLine("                                {0}", authorizationBillingAddress.AddressLine2);
                            }
                            if (authorizationBillingAddress.IsSetAddressLine3())
                            {
                                Console.WriteLine("                            AddressLine3");
                                Console.WriteLine("                                {0}", authorizationBillingAddress.AddressLine3);
                            }
                            if (authorizationBillingAddress.IsSetCity())
                            {
                                Console.WriteLine("                            City");
                                Console.WriteLine("                                {0}", authorizationBillingAddress.City);
                            }
                            if (authorizationBillingAddress.IsSetCounty())
                            {
                                Console.WriteLine("                            County");
                                Console.WriteLine("                                {0}", authorizationBillingAddress.County);
                            }
                            if (authorizationBillingAddress.IsSetDistrict())
                            {
                                Console.WriteLine("                            District");
                                Console.WriteLine("                                {0}", authorizationBillingAddress.District);
                            }
                            if (authorizationBillingAddress.IsSetStateOrRegion())
                            {
                                Console.WriteLine("                            StateOrRegion");
                                Console.WriteLine("                                {0}", authorizationBillingAddress.StateOrRegion);
                            }
                            if (authorizationBillingAddress.IsSetPostalCode())
                            {
                                Console.WriteLine("                            PostalCode");
                                Console.WriteLine("                                {0}", authorizationBillingAddress.PostalCode);
                            }
                            if (authorizationBillingAddress.IsSetCountryCode())
                            {
                                Console.WriteLine("                            CountryCode");
                                Console.WriteLine("                                {0}", authorizationBillingAddress.CountryCode);
                            }
                            if (authorizationBillingAddress.IsSetPhone())
                            {
                                Console.WriteLine("                            Phone");
                                Console.WriteLine("                                {0}", authorizationBillingAddress.Phone);
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
                        if (authorizationDetails.IsSetAddressVerificationCode())
                        {
                        	Console.WriteLine("                    AddressVerificationCode");
                        	Console.WriteLine("                        {0}", authorizationDetails.AddressVerificationCode);
                        }
                    }
                }
            }

            catch (OffAmazonPaymentsServiceException ex)
            {
                PrintException(ex);
            }
            return response;
        }

        public static AuthorizeResponse AuthorizeAction(OffAmazonPaymentsServicePropertyCollection propertiesCollection, 
            IOffAmazonPaymentsService service, string orderReferenceId, String orderAmount, int indicator, int authorizationOption)
        {
            //initiate the authorization request
            AuthorizeRequest authRequest = new AuthorizeRequest();
            authRequest.AmazonOrderReferenceId = orderReferenceId;
            authRequest.SellerId = propertiesCollection.MerchantID;
            Price price = new Price();
            //get the ordertotal object from the setOrderReference's response
            OrderTotal authOrderTotal = new OrderTotal();
            price.Amount = orderAmount;
            price.CurrencyCode = propertiesCollection.CurrencyCode;
            authRequest.AuthorizationAmount = price;
            authRequest.AuthorizationReferenceId = orderReferenceId.Replace('-', 'a') + "authRef" + indicator.ToString();
            //If Fast Authorization is required, set the transaction timeout in the request to 0.
            if (authorizationOption == 2)
            {
                authRequest.TransactionTimeout = 0;
            }

            return AuthorizeSample.InvokeAuthorize(service, authRequest);

        }

        //Use a loop to check the status of authorization. Once the status is not "PENDING", skip the loop.
        public static GetAuthorizationDetailsResponse CheckAuthorizationStatus(string amazonAuthorizationId, OffAmazonPaymentsServicePropertyCollection propertiesCollection,
            IOffAmazonPaymentsService service)
        {
            //used to check if the authorization is time-out
            TimeSpan startTime = DateTime.Now.TimeOfDay;
            GetAuthorizationDetailsRequest authDetailRequest = new GetAuthorizationDetailsRequest();
            authDetailRequest.SellerId = propertiesCollection.MerchantID;
            authDetailRequest.AmazonAuthorizationId = amazonAuthorizationId;

            GetAuthorizationDetailsResponse getAuthResponse = GetAuthorizationDetailsSample.InvokeGetAuthorizationDetails(service, authDetailRequest);
            while (getAuthResponse.IsSetGetAuthorizationDetailsResult() && getAuthResponse.GetAuthorizationDetailsResult.AuthorizationDetails.AuthorizationStatus.State.Equals(PaymentStatus.PENDING))
            {
                if (DateTime.Now.TimeOfDay.Milliseconds - startTime.Milliseconds > 60000)
                    throw new OffAmazonPaymentsServiceException("The authorization is time-out.");

                System.Threading.Thread.Sleep(8000);
                Console.WriteLine("Waiting until the Authorization Status becomes OPEN");
                getAuthResponse = GetAuthorizationDetailsSample.InvokeGetAuthorizationDetails(service, authDetailRequest);
            }

            return getAuthResponse;
        }

    }
}
