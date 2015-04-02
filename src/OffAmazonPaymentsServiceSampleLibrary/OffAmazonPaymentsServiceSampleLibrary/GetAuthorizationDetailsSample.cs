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
using System.IO;

namespace OffAmazonPaymentsServiceSampleLibrary
{
    public class GetAuthorizationDetailsSample : SampleBase
    {
        public static GetAuthorizationDetailsResponse InvokeGetAuthorizationDetails(IOffAmazonPaymentsService service, GetAuthorizationDetailsRequest request)
        {
            return GetAuthorizationDetails(service, request, Console.Out);
        }

        public static GetAuthorizationDetailsResponse GetAuthorizationDetails(IOffAmazonPaymentsService service, GetAuthorizationDetailsRequest request, TextWriter buffer)
        {
            GetAuthorizationDetailsResponse response = GetAuthorizationDetails(service, request);
            printGetAuthorizationDetailsResponseToBuffer(response, buffer);
            return response;
        }

        private static GetAuthorizationDetailsResponse GetAuthorizationDetails(IOffAmazonPaymentsService service, GetAuthorizationDetailsRequest request)
        {
            GetAuthorizationDetailsResponse response = null;
            response = service.GetAuthorizationDetails(request);
            return response;
        }
            
        public static void printGetAuthorizationDetailsResponseToBuffer(GetAuthorizationDetailsResponse response, TextWriter writer)
        {
            writer.WriteLine("Service Response");
            writer.WriteLine("=============================================================================");
            writer.WriteLine();
            writer.WriteLine("        GetAuthorizationDetailsResponse");
            if (response.IsSetGetAuthorizationDetailsResult())
            {
                writer.WriteLine("            GetAuthorizationDetailsResult");
                GetAuthorizationDetailsResult getAuthorizationDetailsResult = response.GetAuthorizationDetailsResult;
                if (getAuthorizationDetailsResult.IsSetAuthorizationDetails())
                {
                    writer.WriteLine("                AuthorizationDetails");
                    AuthorizationDetails authorizationDetails = getAuthorizationDetailsResult.AuthorizationDetails;
                    if (authorizationDetails.IsSetAmazonAuthorizationId())
                    {
                        writer.WriteLine("                    AmazonAuthorizationId");
                        writer.WriteLine("                        {0}", authorizationDetails.AmazonAuthorizationId);
                    }
                    if (authorizationDetails.IsSetAuthorizationReferenceId())
                    {
                        writer.WriteLine("                    AuthorizationReferenceId");
                        writer.WriteLine("                        {0}", authorizationDetails.AuthorizationReferenceId);
                    }
                    if (authorizationDetails.IsSetAuthorizationBillingAddress())
                    {
                        writer.WriteLine("                    AuthorizationBillingAddress");
                        Address authorizationBillingAddress = authorizationDetails.AuthorizationBillingAddress;
                        if (authorizationBillingAddress.IsSetName())
                        {
                            writer.WriteLine("                            Name");
                            writer.WriteLine("                                {0}", authorizationBillingAddress.Name);
                        }
                        if (authorizationBillingAddress.IsSetAddressLine1())
                        {
                            writer.WriteLine("                            AddressLine1");
                            writer.WriteLine("                                {0}", authorizationBillingAddress.AddressLine1);
                        }
                        if (authorizationBillingAddress.IsSetAddressLine2())
                        {
                            writer.WriteLine("                            AddressLine2");
                            writer.WriteLine("                                {0}", authorizationBillingAddress.AddressLine2);
                        }
                        if (authorizationBillingAddress.IsSetAddressLine3())
                        {
                            writer.WriteLine("                            AddressLine3");
                            writer.WriteLine("                                {0}", authorizationBillingAddress.AddressLine3);
                        }
                        if (authorizationBillingAddress.IsSetCity())
                        {
                            writer.WriteLine("                            City");
                            writer.WriteLine("                                {0}", authorizationBillingAddress.City);
                        }
                        if (authorizationBillingAddress.IsSetCounty())
                        {
                            writer.WriteLine("                            County");
                            writer.WriteLine("                                {0}", authorizationBillingAddress.County);
                        }
                        if (authorizationBillingAddress.IsSetDistrict())
                        {
                            writer.WriteLine("                            District");
                            writer.WriteLine("                                {0}", authorizationBillingAddress.District);
                        }
                        if (authorizationBillingAddress.IsSetStateOrRegion())
                        {
                            writer.WriteLine("                            StateOrRegion");
                            writer.WriteLine("                                {0}", authorizationBillingAddress.StateOrRegion);
                        }
                        if (authorizationBillingAddress.IsSetPostalCode())
                        {
                            writer.WriteLine("                            PostalCode");
                            writer.WriteLine("                                {0}", authorizationBillingAddress.PostalCode);
                        }
                        if (authorizationBillingAddress.IsSetCountryCode())
                        {
                            writer.WriteLine("                            CountryCode");
                            writer.WriteLine("                                {0}", authorizationBillingAddress.CountryCode);
                        }
                        if (authorizationBillingAddress.IsSetPhone())
                        {
                            writer.WriteLine("                            Phone");
                            writer.WriteLine("                                {0}", authorizationBillingAddress.Phone);
                        }
                    }
                    if (authorizationDetails.IsSetSellerAuthorizationNote())
                    {
                        writer.WriteLine("                    SellerAuthorizationNote");
                        writer.WriteLine("                        {0}", authorizationDetails.SellerAuthorizationNote);
                    }
                    if (authorizationDetails.IsSetAuthorizationAmount())
                    {
                        writer.WriteLine("                    AuthorizationAmount");
                        Price authorizationAmount = authorizationDetails.AuthorizationAmount;
                        if (authorizationAmount.IsSetAmount())
                        {
                            writer.WriteLine("                        Amount");
                            writer.WriteLine("                            {0}", authorizationAmount.Amount);
                        }
                        if (authorizationAmount.IsSetCurrencyCode())
                        {
                            writer.WriteLine("                        CurrencyCode");
                            writer.WriteLine("                            {0}", authorizationAmount.CurrencyCode);
                        }
                    }
                    if (authorizationDetails.IsSetCapturedAmount())
                    {
                        writer.WriteLine("                    CapturedAmount");
                        Price capturedAmount = authorizationDetails.CapturedAmount;
                        if (capturedAmount.IsSetAmount())
                        {
                            writer.WriteLine("                        Amount");
                            writer.WriteLine("                            {0}", capturedAmount.Amount);
                        }
                        if (capturedAmount.IsSetCurrencyCode())
                        {
                            writer.WriteLine("                        CurrencyCode");
                            writer.WriteLine("                            {0}", capturedAmount.CurrencyCode);
                        }
                    }
                    if (authorizationDetails.IsSetAuthorizationFee())
                    {
                        writer.WriteLine("                    AuthorizationFee");
                        Price authorizationFee = authorizationDetails.AuthorizationFee;
                        if (authorizationFee.IsSetAmount())
                        {
                            writer.WriteLine("                        Amount");
                            writer.WriteLine("                            {0}", authorizationFee.Amount);
                        }
                        if (authorizationFee.IsSetCurrencyCode())
                        {
                            writer.WriteLine("                        CurrencyCode");
                            writer.WriteLine("                            {0}", authorizationFee.CurrencyCode);
                        }
                    }
                    if (authorizationDetails.IsSetCreationTimestamp())
                    {
                        writer.WriteLine("                    CreationTimestamp");
                        writer.WriteLine("                        {0}", authorizationDetails.CreationTimestamp);
                    }
                    if (authorizationDetails.IsSetExpirationTimestamp())
                    {
                        writer.WriteLine("                    ExpirationTimestamp");
                        writer.WriteLine("                        {0}", authorizationDetails.ExpirationTimestamp);
                    }
                    if (authorizationDetails.IsSetAuthorizationStatus())
                    {
                        writer.WriteLine("                    AuthorizationStatus");
                        Status authorizationStatus = authorizationDetails.AuthorizationStatus;
                        if (authorizationStatus.IsSetState())
                        {
                            writer.WriteLine("                        State");
                            writer.WriteLine("                            {0}", authorizationStatus.State);
                        }
                        if (authorizationStatus.IsSetLastUpdateTimestamp())
                        {
                            writer.WriteLine("                        LastUpdateTimestamp");
                            writer.WriteLine("                            {0}", authorizationStatus.LastUpdateTimestamp);
                        }
                        if (authorizationStatus.IsSetReasonCode())
                        {
                            writer.WriteLine("                        ReasonCode");
                            writer.WriteLine("                            {0}", authorizationStatus.ReasonCode);
                        }
                        if (authorizationStatus.IsSetReasonDescription())
                        {
                            writer.WriteLine("                        ReasonDescription");
                            writer.WriteLine("                            {0}", authorizationStatus.ReasonDescription);
                        }
                        if (authorizationDetails.IsSetAddressVerificationCode())
                        {
                        	writer.WriteLine("                    AddressVerificationCode");
                        	writer.WriteLine("                        {0}", authorizationDetails.AddressVerificationCode);
                        }
                    }
                }
            }
            if (response.IsSetResponseMetadata())
            {
                writer.WriteLine("            ResponseMetadata");
                ResponseMetadata responseMetadata = response.ResponseMetadata;
                if (responseMetadata.IsSetRequestId())
                {
                    writer.WriteLine("                RequestId");
                    writer.WriteLine("                    {0}", responseMetadata.RequestId);
                }
            }
        }
    }
}
