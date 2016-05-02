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
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using OffAmazonPaymentsService.Model;

namespace OffAmazonPaymentsService.Mock
{

    /// <summary>
    /// OffAmazonPaymentsServiceMock is the implementation of OffAmazonPaymentsService based
    /// on the pre-populated set of XML files that serve local data. It simulates 
    /// responses from Off Amazon Payments Service service.
    /// </summary>
    /// <remarks>
    /// Use this to test your application without making a call to 
    /// Off Amazon Payments Service 
    /// 
    /// Note, current Mock Service implementation does not valiadate requests
    /// </remarks>
    public  class OffAmazonPaymentsServiceMock : IOffAmazonPaymentsService {
    

        // Public API ------------------------------------------------------------//
    
    
        /// <summary>
        /// Capture 
        /// </summary>
        /// <param name="request">Capture  request</param>
        /// <returns>Capture  Response from the service</returns>
        /// <remarks>
  
        /// </remarks>
        public CaptureResponse Capture(CaptureRequest request)
        {
            return Invoke<CaptureResponse>("CaptureResponse.xml");
        }
    
        /// <summary>
        /// Refund 
        /// </summary>
        /// <param name="request">Refund  request</param>
        /// <returns>Refund  Response from the service</returns>
        /// <remarks>
  
        /// </remarks>
        public RefundResponse Refund(RefundRequest request)
        {
            return Invoke<RefundResponse>("RefundResponse.xml");
        }
    
        /// <summary>
        /// Close Authorization 
        /// </summary>
        /// <param name="request">Close Authorization  request</param>
        /// <returns>Close Authorization  Response from the service</returns>
        /// <remarks>
  
        /// </remarks>
        public CloseAuthorizationResponse CloseAuthorization(CloseAuthorizationRequest request)
        {
            return Invoke<CloseAuthorizationResponse>("CloseAuthorizationResponse.xml");
        }
    
        /// <summary>
        /// Get Refund Details 
        /// </summary>
        /// <param name="request">Get Refund Details  request</param>
        /// <returns>Get Refund Details  Response from the service</returns>
        /// <remarks>
  
        /// </remarks>
        public GetRefundDetailsResponse GetRefundDetails(GetRefundDetailsRequest request)
        {
            return Invoke<GetRefundDetailsResponse>("GetRefundDetailsResponse.xml");
        }
    
        /// <summary>
        /// Get Capture Details 
        /// </summary>
        /// <param name="request">Get Capture Details  request</param>
        /// <returns>Get Capture Details  Response from the service</returns>
        /// <remarks>
  
        /// </remarks>
        public GetCaptureDetailsResponse GetCaptureDetails(GetCaptureDetailsRequest request)
        {
            return Invoke<GetCaptureDetailsResponse>("GetCaptureDetailsResponse.xml");
        }
    
        /// <summary>
        /// Close Order Reference 
        /// </summary>
        /// <param name="request">Close Order Reference  request</param>
        /// <returns>Close Order Reference  Response from the service</returns>
        /// <remarks>
  
        /// </remarks>
        public CloseOrderReferenceResponse CloseOrderReference(CloseOrderReferenceRequest request)
        {
            return Invoke<CloseOrderReferenceResponse>("CloseOrderReferenceResponse.xml");
        }
    
        /// <summary>
        /// Confirm Order Reference 
        /// </summary>
        /// <param name="request">Confirm Order Reference  request</param>
        /// <returns>Confirm Order Reference  Response from the service</returns>
        /// <remarks>
  
        /// </remarks>
        public ConfirmOrderReferenceResponse ConfirmOrderReference(ConfirmOrderReferenceRequest request)
        {
            return Invoke<ConfirmOrderReferenceResponse>("ConfirmOrderReferenceResponse.xml");
        }
    
        /// <summary>
        /// Get Order Reference Details 
        /// </summary>
        /// <param name="request">Get Order Reference Details  request</param>
        /// <returns>Get Order Reference Details  Response from the service</returns>
        /// <remarks>
  
        /// </remarks>
        public GetOrderReferenceDetailsResponse GetOrderReferenceDetails(GetOrderReferenceDetailsRequest request)
        {
            return Invoke<GetOrderReferenceDetailsResponse>("GetOrderReferenceDetailsResponse.xml");
        }
    
        /// <summary>
        /// Authorize 
        /// </summary>
        /// <param name="request">Authorize  request</param>
        /// <returns>Authorize  Response from the service</returns>
        /// <remarks>
  
        /// </remarks>
        public AuthorizeResponse Authorize(AuthorizeRequest request)
        {
            return Invoke<AuthorizeResponse>("AuthorizeResponse.xml");
        }
    
        /// <summary>
        /// Set Order Reference Details 
        /// </summary>
        /// <param name="request">Set Order Reference Details  request</param>
        /// <returns>Set Order Reference Details  Response from the service</returns>
        /// <remarks>
  
        /// </remarks>
        public SetOrderReferenceDetailsResponse SetOrderReferenceDetails(SetOrderReferenceDetailsRequest request)
        {
            return Invoke<SetOrderReferenceDetailsResponse>("SetOrderReferenceDetailsResponse.xml");
        }
    
        /// <summary>
        /// Get Authorization Details 
        /// </summary>
        /// <param name="request">Get Authorization Details  request</param>
        /// <returns>Get Authorization Details  Response from the service</returns>
        /// <remarks>
  
        /// </remarks>
        public GetAuthorizationDetailsResponse GetAuthorizationDetails(GetAuthorizationDetailsRequest request)
        {
            return Invoke<GetAuthorizationDetailsResponse>("GetAuthorizationDetailsResponse.xml");
        }
    
        /// <summary>
        /// Cancel Order Reference 
        /// </summary>
        /// <param name="request">Cancel Order Reference  request</param>
        /// <returns>Cancel Order Reference  Response from the service</returns>
        /// <remarks>
  
        /// </remarks>
        public CancelOrderReferenceResponse CancelOrderReference(CancelOrderReferenceRequest request)
        {
            return Invoke<CancelOrderReferenceResponse>("CancelOrderReferenceResponse.xml");
        }

        /// <summary>
        /// Create Order Reference For Id 
        /// </summary>
        /// <param name="request">Create Order Reference For Id  request</param>
        /// <returns>Create Order Reference For Id  Response from the service</returns>
        /// <remarks>
        /// Activity for validating Payment Plan of Billing Agreement.
        ///   
        /// </remarks>
        public CreateOrderReferenceForIdResponse CreateOrderReferenceForId(CreateOrderReferenceForIdRequest request)
        {
            return Invoke<CreateOrderReferenceForIdResponse>("CreateOrderReferenceForIdResponse.xml");
        }

        /// <summary>
        /// Get Billing Agreement Details 
        /// </summary>
        /// <param name="request">Get Billing Agreement Details  request</param>
        /// <returns>Get Billing Agreement Details  Response from the service</returns>
        /// <remarks>
        /// Activity to close Billing Agreement.
        ///   
        /// </remarks>
        public GetBillingAgreementDetailsResponse GetBillingAgreementDetails(GetBillingAgreementDetailsRequest request)
        {
            return Invoke<GetBillingAgreementDetailsResponse>("GetBillingAgreementDetailsResponse.xml");
        }

        /// <summary>
        /// Set Billing Agreement Details 
        /// </summary>
        /// <param name="request">Set Billing Agreement Details  request</param>
        /// <returns>Set Billing Agreement Details  Response from the service</returns>
        /// <remarks>
        /// Activity to close Billing Agreement.
        ///   
        /// </remarks>
        public SetBillingAgreementDetailsResponse SetBillingAgreementDetails(SetBillingAgreementDetailsRequest request)
        {
            return Invoke<SetBillingAgreementDetailsResponse>("SetBillingAgreementDetailsResponse.xml");
        }

        /// <summary>
        /// Confirm Billing Agreement 
        /// </summary>
        /// <param name="request">Confirm Billing Agreement  request</param>
        /// <returns>Confirm Billing Agreement  Response from the service</returns>
        /// <remarks>
        /// Activity for validating Payment Plan of Billing Agreement.
        ///   
        /// </remarks>
        public ConfirmBillingAgreementResponse ConfirmBillingAgreement(ConfirmBillingAgreementRequest request)
        {
            return Invoke<ConfirmBillingAgreementResponse>("ConfirmBillingAgreementResponse.xml");
        }

        /// <summary>
        /// Validate Billing Agreement 
        /// </summary>
        /// <param name="request">Validate Billing Agreement  request</param>
        /// <returns>Validate Billing Agreement  Response from the service</returns>
        /// <remarks>
        /// Activity for validating Payment Plan of Billing Agreement.
        ///   
        /// </remarks>
        public ValidateBillingAgreementResponse ValidateBillingAgreement(ValidateBillingAgreementRequest request)
        {
            return Invoke<ValidateBillingAgreementResponse>("ValidateBillingAgreementResponse.xml");
        }

        /// <summary>
        /// Authorize On Billing Agreement 
        /// </summary>
        /// <param name="request">Authorize On Billing Agreement  request</param>
        /// <returns>Authorize On Billing Agreement  Response from the service</returns>
        /// <remarks>
        /// Activity for validating Payment Plan of Billing Agreement.
        ///   
        /// </remarks>
        public AuthorizeOnBillingAgreementResponse AuthorizeOnBillingAgreement(AuthorizeOnBillingAgreementRequest request)
        {
            return Invoke<AuthorizeOnBillingAgreementResponse>("AuthorizeOnBillingAgreementResponse.xml");
        }

        /// <summary>
        /// Close Billing Agreement 
        /// </summary>
        /// <param name="request">Close Billing Agreement  request</param>
        /// <returns>Close Billing Agreement  Response from the service</returns>
        /// <remarks>
        /// Activity to close Billing Agreement.
        ///   
        /// </remarks>
        public CloseBillingAgreementResponse CloseBillingAgreement(CloseBillingAgreementRequest request)
        {
            return Invoke<CloseBillingAgreementResponse>("CloseBillingAgreementResponse.xml");
        }

        /// <summary>
        /// Get Provider Credit Details 
        /// </summary>
        /// <param name="request">Get Provider Credit Details   request</param>
        /// <returns>Get Provider Credit Details   Response from the service</returns>
        /// <remarks>
        /// Activity to Get Provider Credit Details.
        ///   
        /// </remarks>
        public GetProviderCreditDetailsResponse GetProviderCreditDetails(GetProviderCreditDetailsRequest request)
        {
            return Invoke<GetProviderCreditDetailsResponse>("GetProviderCreditDetailsResponse.xml");
        }

        /// <summary>
        /// Reverse Provider Credit 
        /// </summary>
        /// <param name="request">Reverse Provider Credit  request</param>
        /// <returns>Reverse Provider Credit  Response from the service</returns>
        /// <remarks>
        /// Activity to Reverse Provider Credit.
        ///   
        /// </remarks>
        public ReverseProviderCreditResponse ReverseProviderCredit(ReverseProviderCreditRequest request)
        {
            return Invoke<ReverseProviderCreditResponse>("ReverseProviderCreditResponse.xml");
        }

        /// <summary>
        /// Get Provider Credit Reversal Details
        /// </summary>
        /// <param name="request">Get Provider Credit Reversal Details  request</param>
        /// <returns>Get Provider Credit Reversal Details  Response from the service</returns>
        /// <remarks>
        /// Activity to Get ProviderCreditReversal Details
        ///   
        /// </remarks>
        public GetProviderCreditReversalDetailsResponse GetProviderCreditReversalDetails(GetProviderCreditReversalDetailsRequest request)
        {
            return Invoke<GetProviderCreditReversalDetailsResponse>("GetProviderCreditReversalDetailsResponse.xml");
        }

        // Private API ------------------------------------------------------------//

        private T Invoke<T>(String xmlResource)
        {
            XmlSerializer serlizer = new XmlSerializer(typeof(T));
            Stream xmlStream = Assembly.GetAssembly(this.GetType()).GetManifestResourceStream(xmlResource);
            return (T)serlizer.Deserialize(xmlStream);
        }
    }
}
