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
    public class GetOrderReferenceDetailsSample : SampleBase
    {
        public static GetOrderReferenceDetailsResponse GetOrderReferenceDetails(OffAmazonPaymentsServicePropertyCollection propertiesCollection,
            IOffAmazonPaymentsService service, string orderReferenceId, string addressConsentToken)
        {
            return GetOrderReferenceDetails(propertiesCollection, service, orderReferenceId, addressConsentToken, Console.Out);
        }

        public static GetOrderReferenceDetailsResponse GetOrderReferenceDetails(OffAmazonPaymentsServicePropertyCollection propertiesCollection,
            IOffAmazonPaymentsService service, string orderReferenceId, string addressConsentToken, TextWriter buffer)
        {
            GetOrderReferenceDetailsResponse response = InvokeGetOrderReferenceDetails(propertiesCollection, service, orderReferenceId, addressConsentToken);
            printOrderReferenceDetailsResponseToBuffer(response, buffer);
            return response;
        }

        private static GetOrderReferenceDetailsResponse InvokeGetOrderReferenceDetails(OffAmazonPaymentsServicePropertyCollection propertiesCollection,
            IOffAmazonPaymentsService service, string orderReferenceId, string addressConsentToken)
        {
            GetOrderReferenceDetailsRequest getOrderRequest = new GetOrderReferenceDetailsRequest();
            getOrderRequest.SellerId = propertiesCollection.MerchantID;
            getOrderRequest.AmazonOrderReferenceId = orderReferenceId;
            getOrderRequest.AddressConsentToken = addressConsentToken;

            GetOrderReferenceDetailsResponse response = service.GetOrderReferenceDetails(getOrderRequest);
            return response;
        }

        private static void printOrderReferenceDetailsResponseToBuffer(GetOrderReferenceDetailsResponse response, TextWriter outputBuffer)
        {
            outputBuffer.WriteLine("Service Response");
            outputBuffer.WriteLine("=============================================================================");
            outputBuffer.WriteLine();
            outputBuffer.WriteLine("        GetOrderReferenceDetailsResponse");
            if (response.IsSetGetOrderReferenceDetailsResult())
            {
                outputBuffer.WriteLine("            GetOrderReferenceDetailsResult");
                GetOrderReferenceDetailsResult getOrderReferenceDetailsResult = response.GetOrderReferenceDetailsResult;
                if (getOrderReferenceDetailsResult.IsSetOrderReferenceDetails())
                {
                    outputBuffer.WriteLine("                OrderReferenceDetails");
                    OrderReferenceDetails orderReferenceDetails = getOrderReferenceDetailsResult.OrderReferenceDetails;
                    if (orderReferenceDetails.IsSetAmazonOrderReferenceId())
                    {
                        outputBuffer.WriteLine("                    AmazonOrderReferenceId");
                        outputBuffer.WriteLine("                        {0}", orderReferenceDetails.AmazonOrderReferenceId);
                    }
                    if (orderReferenceDetails.IsSetBuyer())
                    {
                        outputBuffer.WriteLine("                    Buyer");
                        Buyer buyer = orderReferenceDetails.Buyer;
                        if (buyer.IsSetName())
                        {
                            outputBuffer.WriteLine("                        Name");
                            outputBuffer.WriteLine("                            {0}", buyer.Name);
                        }
                        if (buyer.IsSetEmail())
                        {
                            outputBuffer.WriteLine("                        Email");
                            outputBuffer.WriteLine("                            {0}", buyer.Email);
                        }
                        if (buyer.IsSetPhone())
                        {
                            outputBuffer.WriteLine("                        Phone");
                            outputBuffer.WriteLine("                            {0}", buyer.Phone);
                        }
                    }
                    if (orderReferenceDetails.IsSetOrderTotal())
                    {
                        outputBuffer.WriteLine("                    OrderTotal");
                        OrderTotal orderTotal = orderReferenceDetails.OrderTotal;
                        if (orderTotal.IsSetCurrencyCode())
                        {
                            outputBuffer.WriteLine("                        CurrencyCode");
                            outputBuffer.WriteLine("                            {0}", orderTotal.CurrencyCode);
                        }
                        if (orderTotal.IsSetAmount())
                        {
                            outputBuffer.WriteLine("                        Amount");
                            outputBuffer.WriteLine("                            {0}", orderTotal.Amount);
                        }
                    }
                    if (orderReferenceDetails.IsSetSellerNote())
                    {
                        outputBuffer.WriteLine("                    SellerNote");
                        outputBuffer.WriteLine("                        {0}", orderReferenceDetails.SellerNote);
                    }
                    if (orderReferenceDetails.IsSetPlatformId())
                    {
                        outputBuffer.WriteLine("                    PlatformId");
                        outputBuffer.WriteLine("                        {0}", orderReferenceDetails.PlatformId);
                    }
                    if (orderReferenceDetails.IsSetDestination())
                    {
                        outputBuffer.WriteLine("                    Destination");
                        Destination destination = orderReferenceDetails.Destination;
                        if (destination.IsSetDestinationType())
                        {
                            outputBuffer.WriteLine("                        DestinationType");
                            outputBuffer.WriteLine("                            {0}", destination.DestinationType);
                        }
                        if (destination.IsSetPhysicalDestination())
                        {
                            outputBuffer.WriteLine("                        PhysicalDestination");
                            Address physicalDestination = destination.PhysicalDestination;
                            if (physicalDestination.IsSetName())
                            {
                                outputBuffer.WriteLine("                            Name");
                                outputBuffer.WriteLine("                                {0}", physicalDestination.Name);
                            }
                            if (physicalDestination.IsSetAddressLine1())
                            {
                                outputBuffer.WriteLine("                            AddressLine1");
                                outputBuffer.WriteLine("                                {0}", physicalDestination.AddressLine1);
                            }
                            if (physicalDestination.IsSetAddressLine2())
                            {
                                outputBuffer.WriteLine("                            AddressLine2");
                                outputBuffer.WriteLine("                                {0}", physicalDestination.AddressLine2);
                            }
                            if (physicalDestination.IsSetAddressLine3())
                            {
                                outputBuffer.WriteLine("                            AddressLine3");
                                outputBuffer.WriteLine("                                {0}", physicalDestination.AddressLine3);
                            }
                            if (physicalDestination.IsSetCity())
                            {
                                outputBuffer.WriteLine("                            City");
                                outputBuffer.WriteLine("                                {0}", physicalDestination.City);
                            }
                            if (physicalDestination.IsSetCounty())
                            {
                                outputBuffer.WriteLine("                            County");
                                outputBuffer.WriteLine("                                {0}", physicalDestination.County);
                            }
                            if (physicalDestination.IsSetDistrict())
                            {
                                outputBuffer.WriteLine("                            District");
                                outputBuffer.WriteLine("                                {0}", physicalDestination.District);
                            }
                            if (physicalDestination.IsSetStateOrRegion())
                            {
                                outputBuffer.WriteLine("                            StateOrRegion");
                                outputBuffer.WriteLine("                                {0}", physicalDestination.StateOrRegion);
                            }
                            if (physicalDestination.IsSetPostalCode())
                            {
                                outputBuffer.WriteLine("                            PostalCode");
                                outputBuffer.WriteLine("                                {0}", physicalDestination.PostalCode);
                            }
                            if (physicalDestination.IsSetCountryCode())
                            {
                                outputBuffer.WriteLine("                            CountryCode");
                                outputBuffer.WriteLine("                                {0}", physicalDestination.CountryCode);
                            }
                            if (physicalDestination.IsSetPhone())
                            {
                                outputBuffer.WriteLine("                            Phone");
                                outputBuffer.WriteLine("                                {0}", physicalDestination.Phone);
                            }
                        }
                    }
                    if (orderReferenceDetails.IsSetBillingAddress())
                    {
                        outputBuffer.WriteLine("                    BillingAddress");
                        BillingAddress billingAddress = orderReferenceDetails.BillingAddress;
                        if (billingAddress.IsSetAddressType())
                        {
                            outputBuffer.WriteLine("                        AddressType");
                            outputBuffer.WriteLine("                            {0}", billingAddress.AddressType);
                        }
                        if (billingAddress.IsSetPhysicalAddress())
                        {
                            outputBuffer.WriteLine("                        PhysicalAddress");
                            Address physicalAddress = billingAddress.PhysicalAddress;
                            if (physicalAddress.IsSetName())
                            {
                                outputBuffer.WriteLine("                            Name");
                                outputBuffer.WriteLine("                                {0}", physicalAddress.Name);
                            }
                            if (physicalAddress.IsSetAddressLine1())
                            {
                                outputBuffer.WriteLine("                            AddressLine1");
                                outputBuffer.WriteLine("                                {0}", physicalAddress.AddressLine1);
                            }
                            if (physicalAddress.IsSetAddressLine2())
                            {
                                outputBuffer.WriteLine("                            AddressLine2");
                                outputBuffer.WriteLine("                                {0}", physicalAddress.AddressLine2);
                            }
                            if (physicalAddress.IsSetAddressLine3())
                            {
                                outputBuffer.WriteLine("                            AddressLine3");
                                outputBuffer.WriteLine("                                {0}", physicalAddress.AddressLine3);
                            }
                            if (physicalAddress.IsSetCity())
                            {
                                outputBuffer.WriteLine("                            City");
                                outputBuffer.WriteLine("                                {0}", physicalAddress.City);
                            }
                            if (physicalAddress.IsSetCounty())
                            {
                                outputBuffer.WriteLine("                            County");
                                outputBuffer.WriteLine("                                {0}", physicalAddress.County);
                            }
                            if (physicalAddress.IsSetDistrict())
                            {
                                outputBuffer.WriteLine("                            District");
                                outputBuffer.WriteLine("                                {0}", physicalAddress.District);
                            }
                            if (physicalAddress.IsSetStateOrRegion())
                            {
                                outputBuffer.WriteLine("                            StateOrRegion");
                                outputBuffer.WriteLine("                                {0}", physicalAddress.StateOrRegion);
                            }
                            if (physicalAddress.IsSetPostalCode())
                            {
                                outputBuffer.WriteLine("                            PostalCode");
                                outputBuffer.WriteLine("                                {0}", physicalAddress.PostalCode);
                            }
                            if (physicalAddress.IsSetCountryCode())
                            {
                                outputBuffer.WriteLine("                            CountryCode");
                                outputBuffer.WriteLine("                                {0}", physicalAddress.CountryCode);
                            }
                            if (physicalAddress.IsSetPhone())
                            {
                                outputBuffer.WriteLine("                            Phone");
                                outputBuffer.WriteLine("                                {0}", physicalAddress.Phone);
                            }
                        }
                    }
                    if (orderReferenceDetails.IsSetReleaseEnvironment())
                    {
                        outputBuffer.WriteLine("                    ReleaseEnvironment");
                        outputBuffer.WriteLine("                        {0}", orderReferenceDetails.ReleaseEnvironment);
                    }
                    if (orderReferenceDetails.IsSetSellerOrderAttributes())
                    {
                        outputBuffer.WriteLine("                    SellerOrderAttributes");
                        SellerOrderAttributes sellerOrderAttributes = orderReferenceDetails.SellerOrderAttributes;
                        if (sellerOrderAttributes.IsSetSellerOrderId())
                        {
                            outputBuffer.WriteLine("                        SellerOrderId");
                            outputBuffer.WriteLine("                            {0}", sellerOrderAttributes.SellerOrderId);
                        }
                        if (sellerOrderAttributes.IsSetStoreName())
                        {
                            outputBuffer.WriteLine("                        StoreName");
                            outputBuffer.WriteLine("                            {0}", sellerOrderAttributes.StoreName);
                        }
                        if (sellerOrderAttributes.IsSetOrderItemCategories())
                        {
                            outputBuffer.WriteLine("                        OrderItemCategories");
                            OrderItemCategories orderItemCategories = sellerOrderAttributes.OrderItemCategories;
                            List<String> orderItemCategoryList = orderItemCategories.OrderItemCategory;
                            foreach (String orderItemCategory in orderItemCategoryList)
                            {
                                outputBuffer.WriteLine("                            OrderItemCategory");
                                outputBuffer.WriteLine("                                {0}", orderItemCategory);
                            }
                        }
                        if (sellerOrderAttributes.IsSetCustomInformation())
                        {
                            outputBuffer.WriteLine("                        CustomInformation");
                            outputBuffer.WriteLine("                            {0}", sellerOrderAttributes.CustomInformation);
                        }
                    }
                    if (orderReferenceDetails.IsSetOrderReferenceStatus())
                    {
                        outputBuffer.WriteLine("                    OrderReferenceStatus");
                        OrderReferenceStatus orderReferenceStatus = orderReferenceDetails.OrderReferenceStatus;
                        if (orderReferenceStatus.IsSetState())
                        {
                            outputBuffer.WriteLine("                        State");
                            outputBuffer.WriteLine("                            {0}", orderReferenceStatus.State);
                        }
                        if (orderReferenceStatus.IsSetLastUpdateTimestamp())
                        {
                            outputBuffer.WriteLine("                        LastUpdateTimestamp");
                            outputBuffer.WriteLine("                            {0}", orderReferenceStatus.LastUpdateTimestamp);
                        }
                        if (orderReferenceStatus.IsSetReasonCode())
                        {
                            outputBuffer.WriteLine("                        ReasonCode");
                            outputBuffer.WriteLine("                            {0}", orderReferenceStatus.ReasonCode);
                        }
                        if (orderReferenceStatus.IsSetReasonDescription())
                        {
                            outputBuffer.WriteLine("                        ReasonDescription");
                            outputBuffer.WriteLine("                            {0}", orderReferenceStatus.ReasonDescription);
                        }
                    }
                    if (orderReferenceDetails.IsSetConstraints())
                    {
                        outputBuffer.WriteLine("                    Constraints");
                        Constraints constraints = orderReferenceDetails.Constraints;
                        List<Constraint> constraintList = constraints.Constraint;
                        foreach (Constraint constraint in constraintList)
                        {
                            outputBuffer.WriteLine("                        Constraint");
                            if (constraint.IsSetConstraintID())
                            {
                                outputBuffer.WriteLine("                            ConstraintID");
                                outputBuffer.WriteLine("                                {0}", constraint.ConstraintID);
                            }
                            if (constraint.IsSetDescription())
                            {
                                outputBuffer.WriteLine("                            Description");
                                outputBuffer.WriteLine("                                {0}", constraint.Description);
                            }
                        }
                    }
                    if (orderReferenceDetails.IsSetCreationTimestamp())
                    {
                        outputBuffer.WriteLine("                    CreationTimestamp");
                        outputBuffer.WriteLine("                        {0}", orderReferenceDetails.CreationTimestamp);
                    }
                    if (orderReferenceDetails.IsSetExpirationTimestamp())
                    {
                        outputBuffer.WriteLine("                    ExpirationTimestamp");
                        outputBuffer.WriteLine("                        {0}", orderReferenceDetails.ExpirationTimestamp);
                    }
                    if (orderReferenceDetails.IsSetIdList())
                    {
                        outputBuffer.WriteLine("                    IdList");
                        IdList  idList = orderReferenceDetails.IdList;
                        List<String> memberList  =  idList.member;
                        foreach (String member in memberList)
                        {
                        		outputBuffer.WriteLine("                        member");
                        		outputBuffer.WriteLine("                            {0}", member);
                        }
                    }
                    if (orderReferenceDetails.IsSetOrderLanguage())
                    {
                        outputBuffer.WriteLine("                    OrderLanguage");
                        outputBuffer.WriteLine("                        {0}", orderReferenceDetails.OrderLanguage);
                    }
                }
            }
            if (response.IsSetResponseMetadata())
            {
                outputBuffer.WriteLine("            ResponseMetadata");
                ResponseMetadata responseMetadata = response.ResponseMetadata;
                if (responseMetadata.IsSetRequestId())
                {
                    outputBuffer.WriteLine("                RequestId");
                    outputBuffer.WriteLine("                    {0}", responseMetadata.RequestId);
                }
            }
        }
    }
}
