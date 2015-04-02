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
using System.Text.RegularExpressions;
using System.Xml.Serialization;
using System.Collections.Generic;
using OffAmazonPaymentsService;
using OffAmazonPaymentsService.Mock;
using OffAmazonPaymentsService.Model;

namespace OffAmazonPaymentsServiceSampleLibrary
{
    public class OffAmazonPaymentsServiceSimpleCheckout
    {
       /************************************************************************
         * Simple checkout example
         * This demonstrates a merchant use case where the item is in stock, and
         * the order reference creation is immediately followed by the order
         * confirmation and capture of funds for the merchant
         *
         * This use case makes the assumption that the merchant is using the
         * address capture widget to capture the destination address for the order, and
         * uses the address information to calculate a tax and shipping rate
         *
         * This example will show the following service calls:
         *    - GetOrderReferenceDetails
         *    - SetOrderReferenceDetails
         *    - ConfirmOrderReference
         *    - Authorize
         *    - GetAuthorizeDetails
         *    - Capture
         *    - GetCaptureDetails
         *    - CloseOrderReference
        ***********************************************************************/

        private static IOffAmazonPaymentsService service;
        private static OffAmazonPaymentsServicePropertyCollection propertiesCollection;
        private String orderReferenceId;

        public OffAmazonPaymentsServiceSimpleCheckout(String oroId)
        {
            /************************************************************************
            * Instantiate the Merchant propertiesCollection object which contains required parameters for creating a Marketplace Payment Service  
            ***********************************************************************/
            propertiesCollection = OffAmazonPaymentsServicePropertyCollection.getInstance();

            /************************************************************************
            * Instantiate  Implementation of Marketplace Payment Service  
            ***********************************************************************/
            service = new OffAmazonPaymentsServiceClient(propertiesCollection);
            this.orderReferenceId = oroId;
        }

        //Invoke the SetOrderReferenceDetails method
        public SetOrderReferenceDetailsResponse SetOrderReferenceDetails(string orderAmount)
        {
            return SetOrderReferenceDetailsSample.SetOrderReferenceDetails(propertiesCollection, service, orderReferenceId, orderAmount);
        }
		
        //Invoke the ConfirmOrderReference method
        public ConfirmOrderReferenceResponse ConfirmOrderReferenceObject()
        {
            return ConfirmOrderReferenceSample.ConfirmOrderReferenceObject(propertiesCollection, service, orderReferenceId);
        }

        //Invoke the GetOrderReferenceDetails method
        public GetOrderReferenceDetailsResponse GetOrderReferenceDetails()
        {
            return GetOrderReferenceDetailsSample.GetOrderReferenceDetails(propertiesCollection, service, orderReferenceId, null);
        }

        //Invoke the Authorize method
        public AuthorizeResponse AuthorizeAction(SetOrderReferenceDetailsResponse setOrderReferenceDetailsResponse, int authorizationOption)
        {
            string orderAmount = setOrderReferenceDetailsResponse.SetOrderReferenceDetailsResult.OrderReferenceDetails.OrderTotal.Amount;
            return AuthorizeSample.AuthorizeAction(propertiesCollection, service, orderReferenceId, orderAmount, 0, authorizationOption);
        }
        
        //Use a loop to check the status of authorization. Once the status is not "PENDING", skip the loop.
        public GetAuthorizationDetailsResponse CheckAuthorizationStatus(AuthorizeResponse authResponse)
        {
            return AuthorizeSample.CheckAuthorizationStatus(authResponse.AuthorizeResult.AuthorizationDetails.AmazonAuthorizationId, propertiesCollection, service);
        }

        //Invoke the Capture method.
        public CaptureResponse CaptureAction(AuthorizeResponse authResponse, string orderAmount)
        {
            return CaptureSample.CaptureAction(propertiesCollection, service, authResponse.AuthorizeResult.AuthorizationDetails.AmazonAuthorizationId, orderAmount, orderReferenceId, 0, null, null);
        }
        
        //Invoke the GetCaptureDetails method
        public GetCaptureDetailsResponse GetCaptureDetails(CaptureResponse captureReponse)
        {
            return GetCaptureDetailsSample.GetCaptureDetails(propertiesCollection, service, captureReponse.CaptureResult.CaptureDetails.AmazonCaptureId);
        }
        
        //Invoke the CloseOrderReference method
        public CloseOrderReferenceResponse CloseOrderReference()
        {
            return CloseOrderReferenceSample.CloseOrderReference(propertiesCollection, service, orderReferenceId);
        }

    }
}

