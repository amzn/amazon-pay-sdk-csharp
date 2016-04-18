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
    public class SetOrderReferenceDetailsSample : SampleBase
    {
        public static SetOrderReferenceDetailsResponse InvokeSetOrderReferenceDetails(IOffAmazonPaymentsService service, SetOrderReferenceDetailsRequest request)
        {
            SetOrderReferenceDetailsResponse response = null;
            try
            {
                response = service.SetOrderReferenceDetails(request);
                Console.WriteLine("Service Response");
                Console.WriteLine("=============================================================================");
                Console.WriteLine();
                Console.WriteLine("        SetOrderReferenceDetailsResponse");
                if (response.IsSetSetOrderReferenceDetailsResult())
                {
                    Console.WriteLine("            SetOrderReferenceDetailsResult");
                    SetOrderReferenceDetailsResult setOrderReferenceDetailsResult = response.SetOrderReferenceDetailsResult;
                    if (setOrderReferenceDetailsResult.IsSetOrderReferenceDetails())
                    {
                        Console.WriteLine("                OrderReferenceDetails");
                        OrderReferenceDetails orderReferenceDetails = setOrderReferenceDetailsResult.OrderReferenceDetails;
                        if (orderReferenceDetails.IsSetAmazonOrderReferenceId())
                        {
                            Console.WriteLine("                    AmazonOrderReferenceId");
                            Console.WriteLine("                        {0}", orderReferenceDetails.AmazonOrderReferenceId);
                        }
                        if (orderReferenceDetails.IsSetBuyer())
                        {
                            Console.WriteLine("                    Buyer");
                            Buyer buyer = orderReferenceDetails.Buyer;
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
                        if (orderReferenceDetails.IsSetOrderTotal())
                        {
                            Console.WriteLine("                    OrderTotal");
                            OrderTotal orderTotal = orderReferenceDetails.OrderTotal;
                            if (orderTotal.IsSetCurrencyCode())
                            {
                                Console.WriteLine("                        CurrencyCode");
                                Console.WriteLine("                            {0}", orderTotal.CurrencyCode);
                            }
                            if (orderTotal.IsSetAmount())
                            {
                                Console.WriteLine("                        Amount");
                                Console.WriteLine("                            {0}", orderTotal.Amount);
                            }
                        }
                        if (orderReferenceDetails.IsSetSellerNote())
                        {
                            Console.WriteLine("                    SellerNote");
                            Console.WriteLine("                        {0}", orderReferenceDetails.SellerNote);
                        }
                        if (orderReferenceDetails.IsSetPlatformId())
                        {
                            Console.WriteLine("                    PlatformId");
                            Console.WriteLine("                        {0}", orderReferenceDetails.PlatformId);
                        }
                        if (orderReferenceDetails.IsSetDestination())
                        {
                            Console.WriteLine("                    Destination");
                            Destination destination = orderReferenceDetails.Destination;
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
                        if (orderReferenceDetails.IsSetBillingAddress())
                        {
                            Console.WriteLine("                    BillingAddress");
                            BillingAddress billingAddress = orderReferenceDetails.BillingAddress;
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
                        if (orderReferenceDetails.IsSetReleaseEnvironment())
                        {
                            Console.WriteLine("                    ReleaseEnvironment");
                            Console.WriteLine("                        {0}", orderReferenceDetails.ReleaseEnvironment);
                        }
                        if (orderReferenceDetails.IsSetSellerOrderAttributes())
                        {
                            Console.WriteLine("                    SellerOrderAttributes");
                            SellerOrderAttributes sellerOrderAttributes = orderReferenceDetails.SellerOrderAttributes;
                            if (sellerOrderAttributes.IsSetSellerOrderId())
                            {
                                Console.WriteLine("                        SellerOrderId");
                                Console.WriteLine("                            {0}", sellerOrderAttributes.SellerOrderId);
                            }
                            if (sellerOrderAttributes.IsSetStoreName())
                            {
                                Console.WriteLine("                        StoreName");
                                Console.WriteLine("                            {0}", sellerOrderAttributes.StoreName);
                            }
                            if (sellerOrderAttributes.IsSetOrderItemCategories())
                            {
                                Console.WriteLine("                        OrderItemCategories");
                                OrderItemCategories orderItemCategories = sellerOrderAttributes.OrderItemCategories;
                                List<String> orderItemCategoryList = orderItemCategories.OrderItemCategory;
                                foreach (String orderItemCategory in orderItemCategoryList)
                                {
                                    Console.WriteLine("                            OrderItemCategory");
                                    Console.WriteLine("                                {0}", orderItemCategory);
                                }
                            }
                            if (sellerOrderAttributes.IsSetCustomInformation())
                            {
                                Console.WriteLine("                        CustomInformation");
                                Console.WriteLine("                            {0}", sellerOrderAttributes.CustomInformation);
                            }
                        }
                        if (orderReferenceDetails.IsSetOrderReferenceStatus())
                        {
                            Console.WriteLine("                    OrderReferenceStatus");
                            OrderReferenceStatus orderReferenceStatus = orderReferenceDetails.OrderReferenceStatus;
                            if (orderReferenceStatus.IsSetState())
                            {
                                Console.WriteLine("                        State");
                                Console.WriteLine("                            {0}", orderReferenceStatus.State);
                            }
                            if (orderReferenceStatus.IsSetLastUpdateTimestamp())
                            {
                                Console.WriteLine("                        LastUpdateTimestamp");
                                Console.WriteLine("                            {0}", orderReferenceStatus.LastUpdateTimestamp);
                            }
                            if (orderReferenceStatus.IsSetReasonCode())
                            {
                                Console.WriteLine("                        ReasonCode");
                                Console.WriteLine("                            {0}", orderReferenceStatus.ReasonCode);
                            }
                            if (orderReferenceStatus.IsSetReasonDescription())
                            {
                                Console.WriteLine("                        ReasonDescription");
                                Console.WriteLine("                            {0}", orderReferenceStatus.ReasonDescription);
                            }
                        }
                        if (orderReferenceDetails.IsSetConstraints())
                        {
                            Console.WriteLine("                    Constraints");
                            Constraints constraints = orderReferenceDetails.Constraints;
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
                        if (orderReferenceDetails.IsSetCreationTimestamp())
                        {
                            Console.WriteLine("                    CreationTimestamp");
                            Console.WriteLine("                        {0}", orderReferenceDetails.CreationTimestamp);
                        }
                        if (orderReferenceDetails.IsSetExpirationTimestamp())
                        {
                            Console.WriteLine("                    ExpirationTimestamp");
                            Console.WriteLine("                        {0}", orderReferenceDetails.ExpirationTimestamp);
                        }
                        if (orderReferenceDetails.IsSetIdList())
                        {
                            Console.WriteLine("                    IdList");
                            IdList  idList = orderReferenceDetails.IdList;
                            List<String> memberList  =  idList.member;
                            foreach (String member in memberList)
                            {
                                Console.WriteLine("                        member");
                                    Console.WriteLine("                            {0}", member);
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

        public static SetOrderReferenceDetailsResponse SetOrderReferenceDetails(OffAmazonPaymentsServicePropertyCollection propertiesCollection, 
            IOffAmazonPaymentsService service, string orderReferenceId, string orderAmount)
        {
            SetOrderReferenceDetailsRequest setOrderRequest = new SetOrderReferenceDetailsRequest();
            setOrderRequest.SellerId = propertiesCollection.MerchantID;
            setOrderRequest.AmazonOrderReferenceId = orderReferenceId;
            //setup the currency and amount as an ordertotal object
            OrderReferenceAttributes attributes = new OrderReferenceAttributes();
            OrderTotal orderTotal = new OrderTotal();
            orderTotal.Amount = orderAmount;
            orderTotal.CurrencyCode = propertiesCollection.CurrencyCode;
            attributes.OrderTotal = orderTotal;
            setOrderRequest.OrderReferenceAttributes = attributes;
            return SetOrderReferenceDetailsSample.InvokeSetOrderReferenceDetails(service, setOrderRequest);
        }
    }
}
