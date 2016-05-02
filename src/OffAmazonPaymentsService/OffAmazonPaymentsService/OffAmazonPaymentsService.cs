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
using OffAmazonPaymentsService.Model;

namespace OffAmazonPaymentsService
{




    /// <summary>
    /// Coral service for marketplace
    /// payment API operations for external
    /// merchants.
    /// 
    /// </summary>
    public interface IOffAmazonPaymentsService
    {
            
        /// <summary>
        /// Capture 
        /// </summary>
        /// <param name="request">Capture  request</param>
        /// <returns>Capture  Response from the service</returns>
        CaptureResponse Capture(CaptureRequest request);

            
        /// <summary>
        /// Refund 
        /// </summary>
        /// <param name="request">Refund  request</param>
        /// <returns>Refund  Response from the service</returns>
        RefundResponse Refund(RefundRequest request);

            
        /// <summary>
        /// Close Authorization 
        /// </summary>
        /// <param name="request">Close Authorization  request</param>
        /// <returns>Close Authorization  Response from the service</returns>
        CloseAuthorizationResponse CloseAuthorization(CloseAuthorizationRequest request);

            
        /// <summary>
        /// Get Refund Details 
        /// </summary>
        /// <param name="request">Get Refund Details  request</param>
        /// <returns>Get Refund Details  Response from the service</returns>
        GetRefundDetailsResponse GetRefundDetails(GetRefundDetailsRequest request);

            
        /// <summary>
        /// Get Capture Details 
        /// </summary>
        /// <param name="request">Get Capture Details  request</param>
        /// <returns>Get Capture Details  Response from the service</returns>
        GetCaptureDetailsResponse GetCaptureDetails(GetCaptureDetailsRequest request);

            
        /// <summary>
        /// Close Order Reference 
        /// </summary>
        /// <param name="request">Close Order Reference  request</param>
        /// <returns>Close Order Reference  Response from the service</returns>
        CloseOrderReferenceResponse CloseOrderReference(CloseOrderReferenceRequest request);

            
        /// <summary>
        /// Confirm Order Reference 
        /// </summary>
        /// <param name="request">Confirm Order Reference  request</param>
        /// <returns>Confirm Order Reference  Response from the service</returns>
        ConfirmOrderReferenceResponse ConfirmOrderReference(ConfirmOrderReferenceRequest request);

            
        /// <summary>
        /// Get Order Reference Details 
        /// </summary>
        /// <param name="request">Get Order Reference Details  request</param>
        /// <returns>Get Order Reference Details  Response from the service</returns>
        GetOrderReferenceDetailsResponse GetOrderReferenceDetails(GetOrderReferenceDetailsRequest request);

            
        /// <summary>
        /// Authorize 
        /// </summary>
        /// <param name="request">Authorize  request</param>
        /// <returns>Authorize  Response from the service</returns>
        AuthorizeResponse Authorize(AuthorizeRequest request);

            
        /// <summary>
        /// Set Order Reference Details 
        /// </summary>
        /// <param name="request">Set Order Reference Details  request</param>
        /// <returns>Set Order Reference Details  Response from the service</returns>
        SetOrderReferenceDetailsResponse SetOrderReferenceDetails(SetOrderReferenceDetailsRequest request);

            
        /// <summary>
        /// Get Authorization Details 
        /// </summary>
        /// <param name="request">Get Authorization Details  request</param>
        /// <returns>Get Authorization Details  Response from the service</returns>
        GetAuthorizationDetailsResponse GetAuthorizationDetails(GetAuthorizationDetailsRequest request);

            
        /// <summary>
        /// Cancel Order Reference 
        /// </summary>
        /// <param name="request">Cancel Order Reference  request</param>
        /// <returns>Cancel Order Reference  Response from the service</returns>
        CancelOrderReferenceResponse CancelOrderReference(CancelOrderReferenceRequest request);


        /// <summary>
        /// Create Order Reference For Id 
        /// </summary>
        /// <param name="request">Create Order Reference For Id  request</param>
        /// <returns>Create Order Reference For Id  Response from the service</returns>
        CreateOrderReferenceForIdResponse CreateOrderReferenceForId(CreateOrderReferenceForIdRequest request);


        /// <summary>
        /// Get Billing Agreement Details 
        /// </summary>
        /// <param name="request">Get Billing Agreement Details  request</param>
        /// <returns>Get Billing Agreement Details  Response from the service</returns>
        GetBillingAgreementDetailsResponse GetBillingAgreementDetails(GetBillingAgreementDetailsRequest request);


        /// <summary>
        /// Set Billing Agreement Details 
        /// </summary>
        /// <param name="request">Set Billing Agreement Details  request</param>
        /// <returns>Set Billing Agreement Details  Response from the service</returns>
        SetBillingAgreementDetailsResponse SetBillingAgreementDetails(SetBillingAgreementDetailsRequest request);


        /// <summary>
        /// Confirm Billing Agreement 
        /// </summary>
        /// <param name="request">Confirm Billing Agreement  request</param>
        /// <returns>Confirm Billing Agreement  Response from the service</returns>
        ConfirmBillingAgreementResponse ConfirmBillingAgreement(ConfirmBillingAgreementRequest request);


        /// <summary>
        /// Validate Billing Agreement 
        /// </summary>
        /// <param name="request">Validate Billing Agreement  request</param>
        /// <returns>Validate Billing Agreement  Response from the service</returns>
        ValidateBillingAgreementResponse ValidateBillingAgreement(ValidateBillingAgreementRequest request);


        /// <summary>
        /// Authorize On Billing Agreement 
        /// </summary>
        /// <param name="request">Authorize On Billing Agreement  request</param>
        /// <returns>Authorize On Billing Agreement  Response from the service</returns>
        AuthorizeOnBillingAgreementResponse AuthorizeOnBillingAgreement(AuthorizeOnBillingAgreementRequest request);


        /// <summary>
        /// Close Billing Agreement 
        /// </summary>
        /// <param name="request">Close Billing Agreement  request</param>
        /// <returns>Close Billing Agreement  Response from the service</returns>
        CloseBillingAgreementResponse CloseBillingAgreement(CloseBillingAgreementRequest request);


        /// <summary>
        /// Get Provider Credit Details 
        /// </summary>
        /// <param name="request">Get Provider Credit Details  request</param>
        /// <returns>Get Provider Credit Details  Response from the service</returns>
        /// <remarks>
        /// A query API for ProviderCredits.  Both Provider and Seller sellerIds are authorized to call this API.
        ///   
        /// </remarks>
        GetProviderCreditDetailsResponse GetProviderCreditDetails(GetProviderCreditDetailsRequest request);


        /// <summary>
        /// Reverse Provider Credit 
        /// </summary>
        /// <param name="request">Reverse Provider Credit  request</param>
        /// <returns>Reverse Provider Credit  Response from the service</returns>
        /// <remarks>
        /// Activity to enable the Caller/Provider to reverse the funds credited to Provider.
        ///   
        /// </remarks>
        ReverseProviderCreditResponse ReverseProviderCredit(ReverseProviderCreditRequest request);

        /// <summary>
        /// Get Provider Credit Reversal Details 
        /// </summary>
        /// <param name="request">Get Provider Credit Reversal Details  request</param>
        /// <returns>Get Provider Credit Reversal Details  Response from the service</returns>
        /// <remarks>
        /// Activity to query the funds reversed against a given Provider Credit reversal.
        ///   
        /// </remarks>
        GetProviderCreditReversalDetailsResponse GetProviderCreditReversalDetails(GetProviderCreditReversalDetailsRequest request);

            
    }
}
