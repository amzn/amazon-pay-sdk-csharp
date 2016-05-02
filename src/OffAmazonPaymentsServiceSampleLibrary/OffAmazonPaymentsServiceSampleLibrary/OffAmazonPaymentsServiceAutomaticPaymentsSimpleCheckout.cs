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
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService;
using OffAmazonPaymentsService.Model;

namespace OffAmazonPaymentsServiceSampleLibrary
{
    public class OffAmazonPaymentsServiceAutomaticPaymentsSimpleCheckout
    {
        /**
         * Automatic payment simple checkout example
         *
         * This demonstrates a merchant use case where the item is in stock, and
         * the billing agreement creation is immediately followed by the order
         * confirmation and capture of funds for the merchant
         *
         * This use case makes the assumption that the merchant is using the billing 
         * agreement address capture widget to capture the destination address for the 
         * order, and uses the address information to calculate a tax and shipping rate
         *
         * This example will show the following service calls:
         *    - GetBillingAgreementDetails
         *    - SetBillingAgreementDetails
         *    - ConfirmBillingAgreement
         *    - ValidateBillingAgreement
         *    - AuthorizeOnBillingAgreement
         *    - GetAuthorizationDetails
         *    - Capture
         *    - GetCaptureDetails
         *    - CloseBillingAgreement
         */

        private static IOffAmazonPaymentsService service;
        private static OffAmazonPaymentsServicePropertyCollection propertiesCollection;
        private String billingAgreementId;

        public OffAmazonPaymentsServiceAutomaticPaymentsSimpleCheckout(string billingAgreementId)
        {
            propertiesCollection = OffAmazonPaymentsServicePropertyCollection.getInstance();
            service = new OffAmazonPaymentsServiceClient(propertiesCollection);
            this.billingAgreementId = billingAgreementId;
        }

        //Invoke the GetBillingAgreementDetails method
        public GetBillingAgreementDetailsResponse GetBillingAgreementDetails()
        {
            return GetBillingAgreementDetailsSample.GetBillingAgreementDetails(propertiesCollection, service, billingAgreementId);
        }

        //Invoke the SetBillingAgreementDetails method
        public SetBillingAgreementDetailsResponse SetBillingAgreementDetails()
        {
            return SetBillingAgreementDetailsSample.SetBillingAgreementDetails(propertiesCollection, service, billingAgreementId, "", "", "", "");
        }

        //Invoke the ConfirmBillingAgreement method
        public ConfirmBillingAgreementResponse ConfirmBillingAgreement()
        {
            return ConfirmBillingAgreementSample.ConfirmBillingAgreement(propertiesCollection, service, billingAgreementId);
        }

        //Invoke the ValidateBillingAgreement method
        public ValidateBillingAgreementResponse ValidateBillingAgreement()
        {
            return ValidateBillingAgreementSample.ValidateBillingAgreement(propertiesCollection, service, billingAgreementId);
        }

        //Invoke the AuthorizeOnBillingAgreement method
        public AuthorizeOnBillingAgreementResponse AuthorizeOnBillingAgreement(string authAmount, int indicator, bool captureNow)
        {
            return AuthorizeOnBillingAgreementSample.AuthorizeOnBillingAgreement(propertiesCollection, service, billingAgreementId, authAmount, indicator, captureNow);
        }

        //Use a loop to check the status of authorization. Once the status is not "PENDING", skip the loop.
        public GetAuthorizationDetailsResponse CheckAuthorizationStatus(AuthorizeOnBillingAgreementResponse authResponse)
        {
            return AuthorizeSample.CheckAuthorizationStatus(authResponse.AuthorizeOnBillingAgreementResult.AuthorizationDetails.AmazonAuthorizationId, propertiesCollection, service);
        }

        //Invoke the Capture method
        public CaptureResponse Capture(AuthorizeOnBillingAgreementResponse authResponse, string captureAmount, int indicator)
        {
            return CaptureSample.CaptureAction(propertiesCollection, service, authResponse.AuthorizeOnBillingAgreementResult.AuthorizationDetails.AmazonAuthorizationId, captureAmount, billingAgreementId, indicator, null, null);
        }

        //Invoke the GetCaptureDetails method
        public GetCaptureDetailsResponse GetCaptureDetail(CaptureResponse captureReponse)
        {
            return GetCaptureDetailsSample.GetCaptureDetails(propertiesCollection, service, captureReponse.CaptureResult.CaptureDetails.AmazonCaptureId);
        }

        //Invoke the CloseBillingAgreement method
        public CloseBillingAgreementResponse CloseBillingAgreement()
        {
            return CloseBillingAgreementSample.CloseBillingAgreement(propertiesCollection, service, billingAgreementId);
        }
    }
}
