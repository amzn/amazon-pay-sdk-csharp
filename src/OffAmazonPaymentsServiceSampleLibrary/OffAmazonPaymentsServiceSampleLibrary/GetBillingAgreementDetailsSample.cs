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
    public class GetBillingAgreementDetailsSample : SampleBase
    {
        public static GetBillingAgreementDetailsResponse InvokeGetBillingAgreementDetails(IOffAmazonPaymentsService service, GetBillingAgreementDetailsRequest request)
        {
            GetBillingAgreementDetailsResponse response = null;
            try
            {
                response = service.GetBillingAgreementDetails(request);

                Console.WriteLine("Service Response");
                Console.WriteLine("=============================================================================");
                Console.WriteLine();

                Console.WriteLine("        GetBillingAgreementDetailsResponse");
                if (response.IsSetGetBillingAgreementDetailsResult())
                {
                    Console.WriteLine("            GetBillingAgreementDetailsResult");
                    GetBillingAgreementDetailsResult getBillingAgreementDetailsResult = response.GetBillingAgreementDetailsResult;
                    if (getBillingAgreementDetailsResult.IsSetBillingAgreementDetails())
                    {
                        Console.WriteLine("                BillingAgreementDetails");
                        BillingAgreementDetails billingAgreementDetails = getBillingAgreementDetailsResult.BillingAgreementDetails;
                        if (billingAgreementDetails.IsSetAmazonBillingAgreementId())
                        {
                            Console.WriteLine("                    AmazonBillingAgreementId");
                            Console.WriteLine("                        {0}", billingAgreementDetails.AmazonBillingAgreementId);
                        }
                        if (billingAgreementDetails.IsSetBillingAgreementLimits())
                        {
                            Console.WriteLine("                    BillingAgreementLimits");
                            BillingAgreementLimits billingAgreementLimits = billingAgreementDetails.BillingAgreementLimits;
                            if (billingAgreementLimits.IsSetAmountLimitPerTimePeriod())
                            {
                                Console.WriteLine("                        AmountLimitPerTimePeriod");
                                Price amountLimitPerTimePeriod = billingAgreementLimits.AmountLimitPerTimePeriod;
                                if (amountLimitPerTimePeriod.IsSetAmount())
                                {
                                    Console.WriteLine("                            Amount");
                                    Console.WriteLine("                                {0}", amountLimitPerTimePeriod.Amount);
                                }
                                if (amountLimitPerTimePeriod.IsSetCurrencyCode())
                                {
                                    Console.WriteLine("                            CurrencyCode");
                                    Console.WriteLine("                                {0}", amountLimitPerTimePeriod.CurrencyCode);
                                }
                            }
                            if (billingAgreementLimits.IsSetTimePeriodStartDate())
                            {
                                Console.WriteLine("                        TimePeriodStartDate");
                                Console.WriteLine("                            {0}", billingAgreementLimits.TimePeriodStartDate);
                            }
                            if (billingAgreementLimits.IsSetTimePeriodEndDate())
                            {
                                Console.WriteLine("                        TimePeriodEndDate");
                                Console.WriteLine("                            {0}", billingAgreementLimits.TimePeriodEndDate);
                            }
                            if (billingAgreementLimits.IsSetCurrentRemainingBalance())
                            {
                                Console.WriteLine("                        CurrentRemainingBalance");
                                Price currentRemainingBalance = billingAgreementLimits.CurrentRemainingBalance;
                                if (currentRemainingBalance.IsSetAmount())
                                {
                                    Console.WriteLine("                            Amount");
                                    Console.WriteLine("                                {0}", currentRemainingBalance.Amount);
                                }
                                if (currentRemainingBalance.IsSetCurrencyCode())
                                {
                                    Console.WriteLine("                            CurrencyCode");
                                    Console.WriteLine("                                {0}", currentRemainingBalance.CurrencyCode);
                                }
                            }
                        }
                        if (billingAgreementDetails.IsSetBuyer())
                        {
                            Console.WriteLine("                    Buyer");
                            Buyer buyer = billingAgreementDetails.Buyer;
                            if (buyer.IsSetName())
                            {
                                Console.WriteLine("                        Name");
                                Console.WriteLine("                            {0}", buyer.Name);
                            }
                            if (buyer.IsSetEmail())
                            {
                                Console.WriteLine("                        Email");
                                Console.WriteLine("                            {0}", buyer.Email);
                            }
                            if (buyer.IsSetPhone())
                            {
                                Console.WriteLine("                        Phone");
                                Console.WriteLine("                            {0}", buyer.Phone);
                            }
                        }
                        if (billingAgreementDetails.IsSetSellerNote())
                        {
                            Console.WriteLine("                    SellerNote");
                            Console.WriteLine("                        {0}", billingAgreementDetails.SellerNote);
                        }
                        if (billingAgreementDetails.IsSetPlatformId())
                        {
                            Console.WriteLine("                    PlatformId");
                            Console.WriteLine("                        {0}", billingAgreementDetails.PlatformId);
                        }
                        if (billingAgreementDetails.IsSetDestination())
                        {
                            Console.WriteLine("                    Destination");
                            Destination destination = billingAgreementDetails.Destination;
                            if (destination.IsSetDestinationType())
                            {
                                Console.WriteLine("                        DestinationType");
                                Console.WriteLine("                            {0}", destination.DestinationType);
                            }
                            if (destination.IsSetPhysicalDestination())
                            {
                                Console.WriteLine("                        PhysicalDestination");
                                Address physicalDestination = destination.PhysicalDestination;
                                if (physicalDestination.IsSetName())
                                {
                                    Console.WriteLine("                            Name");
                                    Console.WriteLine("                                {0}", physicalDestination.Name);
                                }
                                if (physicalDestination.IsSetAddressLine1())
                                {
                                    Console.WriteLine("                            AddressLine1");
                                    Console.WriteLine("                                {0}", physicalDestination.AddressLine1);
                                }
                                if (physicalDestination.IsSetAddressLine2())
                                {
                                    Console.WriteLine("                            AddressLine2");
                                    Console.WriteLine("                                {0}", physicalDestination.AddressLine2);
                                }
                                if (physicalDestination.IsSetAddressLine3())
                                {
                                    Console.WriteLine("                            AddressLine3");
                                    Console.WriteLine("                                {0}", physicalDestination.AddressLine3);
                                }
                                if (physicalDestination.IsSetCity())
                                {
                                    Console.WriteLine("                            City");
                                    Console.WriteLine("                                {0}", physicalDestination.City);
                                }
                                if (physicalDestination.IsSetCounty())
                                {
                                    Console.WriteLine("                            County");
                                    Console.WriteLine("                                {0}", physicalDestination.County);
                                }
                                if (physicalDestination.IsSetDistrict())
                                {
                                    Console.WriteLine("                            District");
                                    Console.WriteLine("                                {0}", physicalDestination.District);
                                }
                                if (physicalDestination.IsSetStateOrRegion())
                                {
                                    Console.WriteLine("                            StateOrRegion");
                                    Console.WriteLine("                                {0}", physicalDestination.StateOrRegion);
                                }
                                if (physicalDestination.IsSetPostalCode())
                                {
                                    Console.WriteLine("                            PostalCode");
                                    Console.WriteLine("                                {0}", physicalDestination.PostalCode);
                                }
                                if (physicalDestination.IsSetCountryCode())
                                {
                                    Console.WriteLine("                            CountryCode");
                                    Console.WriteLine("                                {0}", physicalDestination.CountryCode);
                                }
                                if (physicalDestination.IsSetPhone())
                                {
                                    Console.WriteLine("                            Phone");
                                    Console.WriteLine("                                {0}", physicalDestination.Phone);
                                }
                            }
                        }
                        if (billingAgreementDetails.IsSetBillingAddress())
                        {
                            Console.WriteLine("                    BillingAddress");
                            BillingAddress  billingAddress = billingAgreementDetails.BillingAddress;
                            if (billingAddress.IsSetAddressType())
                            {
                                Console.WriteLine("                        AddressType");
                                Console.WriteLine("                            {0}", billingAddress.AddressType);
                            }
                            if (billingAddress.IsSetPhysicalAddress())
                            {
                                Console.WriteLine("                        PhysicalAddress");
                                Address physicalAddress = billingAddress.PhysicalAddress;
                                if (physicalAddress.IsSetName())
                                {
                                    Console.WriteLine("                            Name");
                                    Console.WriteLine("                                {0}", physicalAddress.Name);
                                }
                                if (physicalAddress.IsSetAddressLine1())
                                {
                                    Console.WriteLine("                            AddressLine1");
                                    Console.WriteLine("                                {0}", physicalAddress.AddressLine1);
                                }
                                if (physicalAddress.IsSetAddressLine2())
                                {
                                    Console.WriteLine("                            AddressLine2");
                                    Console.WriteLine("                                {0}", physicalAddress.AddressLine2);
                                }
                                if (physicalAddress.IsSetAddressLine3())
                                {
                                    Console.WriteLine("                            AddressLine3");
                                    Console.WriteLine("                                {0}", physicalAddress.AddressLine3);
                                }
                                if (physicalAddress.IsSetCity())
                                {
                                    Console.WriteLine("                            City");
                                    Console.WriteLine("                                {0}", physicalAddress.City);
                                }
                                if (physicalAddress.IsSetCounty())
                                {
                                    Console.WriteLine("                            County");
                                    Console.WriteLine("                                {0}", physicalAddress.County);
                                }
                                if (physicalAddress.IsSetDistrict())
                                {
                                    Console.WriteLine("                            District");
                                    Console.WriteLine("                                {0}", physicalAddress.District);
                                }
                                if (physicalAddress.IsSetStateOrRegion())
                                {
                                    Console.WriteLine("                            StateOrRegion");
                                    Console.WriteLine("                                {0}", physicalAddress.StateOrRegion);
                                }
                                if (physicalAddress.IsSetPostalCode())
                                {
                                    Console.WriteLine("                            PostalCode");
                                    Console.WriteLine("                                {0}", physicalAddress.PostalCode);
                                }
                                if (physicalAddress.IsSetCountryCode())
                                {
                                    Console.WriteLine("                            CountryCode");
                                    Console.WriteLine("                                {0}", physicalAddress.CountryCode);
                                }
                                if (physicalAddress.IsSetPhone())
                                {
                                    Console.WriteLine("                            Phone");
                                    Console.WriteLine("                                {0}", physicalAddress.Phone);
                                }
                            }
                        }
                        if (billingAgreementDetails.IsSetReleaseEnvironment())
                        {
                            Console.WriteLine("                    ReleaseEnvironment");
                            Console.WriteLine("                        {0}", billingAgreementDetails.ReleaseEnvironment);
                        }
                        if (billingAgreementDetails.IsSetSellerBillingAgreementAttributes())
                        {
                            Console.WriteLine("                    SellerBillingAgreementAttributes");
                            SellerBillingAgreementAttributes sellerBillingAgreementAttributes = billingAgreementDetails.SellerBillingAgreementAttributes;
                            if (sellerBillingAgreementAttributes.IsSetSellerBillingAgreementId())
                            {
                                Console.WriteLine("                        SellerBillingAgreementId");
                                Console.WriteLine("                            {0}", sellerBillingAgreementAttributes.SellerBillingAgreementId);
                            }
                            if (sellerBillingAgreementAttributes.IsSetStoreName())
                            {
                                Console.WriteLine("                        StoreName");
                                Console.WriteLine("                            {0}", sellerBillingAgreementAttributes.StoreName);
                            }
                            if (sellerBillingAgreementAttributes.IsSetCustomInformation())
                            {
                                Console.WriteLine("                        CustomInformation");
                                Console.WriteLine("                            {0}", sellerBillingAgreementAttributes.CustomInformation);
                            }
                        }
                        if (billingAgreementDetails.IsSetBillingAgreementStatus())
                        {
                            Console.WriteLine("                    BillingAgreementStatus");
                            BillingAgreementStatus billingAgreementStatus = billingAgreementDetails.BillingAgreementStatus;
                            if (billingAgreementStatus.IsSetState())
                            {
                                Console.WriteLine("                        State");
                                Console.WriteLine("                            {0}", billingAgreementStatus.State);
                            }
                            if (billingAgreementStatus.IsSetLastUpdatedTimestamp())
                            {
                                Console.WriteLine("                        LastUpdatedTimestamp");
                                Console.WriteLine("                            {0}", billingAgreementStatus.LastUpdatedTimestamp);
                            }
                            if (billingAgreementStatus.IsSetReasonCode())
                            {
                                Console.WriteLine("                        ReasonCode");
                                Console.WriteLine("                            {0}", billingAgreementStatus.ReasonCode);
                            }
                            if (billingAgreementStatus.IsSetReasonDescription())
                            {
                                Console.WriteLine("                        ReasonDescription");
                                Console.WriteLine("                            {0}", billingAgreementStatus.ReasonDescription);
                            }
                        }
                        if (billingAgreementDetails.IsSetConstraints())
                        {
                            Console.WriteLine("                    Constraints");
                            Constraints constraints = billingAgreementDetails.Constraints;
                            List<Constraint> constraintList = constraints.Constraint;
                            foreach (Constraint constraint in constraintList)
                            {
                                Console.WriteLine("                        Constraint");
                                if (constraint.IsSetConstraintID())
                                {
                                    Console.WriteLine("                            ConstraintID");
                                    Console.WriteLine("                                {0}", constraint.ConstraintID);
                                }
                                if (constraint.IsSetDescription())
                                {
                                    Console.WriteLine("                            Description");
                                    Console.WriteLine("                                {0}", constraint.Description);
                                }
                            }
                        }
                        if (billingAgreementDetails.IsSetCreationTimestamp())
                        {
                            Console.WriteLine("                    CreationTimestamp");
                            Console.WriteLine("                        {0}", billingAgreementDetails.CreationTimestamp);
                        }
                        if (billingAgreementDetails.IsSetExpirationTimestamp())
                        {
                            Console.WriteLine("                    ExpirationTimestamp");
                            Console.WriteLine("                        {0}", billingAgreementDetails.ExpirationTimestamp);
                        }
                        if (billingAgreementDetails.IsSetBillingAgreementConsent())
                        {
                            Console.WriteLine("                    BillingAgreementConsent");
                            Console.WriteLine("                        {0}", billingAgreementDetails.BillingAgreementConsent);
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

        public static GetBillingAgreementDetailsResponse GetBillingAgreementDetails(OffAmazonPaymentsServicePropertyCollection propertiesCollection,
            IOffAmazonPaymentsService service, string billingAgreementId)
        {
            GetBillingAgreementDetailsRequest request = new GetBillingAgreementDetailsRequest();
            request.AmazonBillingAgreementId = billingAgreementId;
            request.SellerId = propertiesCollection.MerchantID;
            return InvokeGetBillingAgreementDetails(service, request);
        }
    }
}
