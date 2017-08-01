using System;
using System.Collections.Generic;
using AmazonPay.Responses;
 
 
namespace AmazonPay.Responses
{
    /// <summary>
    /// PaymentDetailsResponse is a helper method which returns OrderReference, Authorization, Capture and 
    /// Refund response
    /// </summary>
    public class PaymentDetailsResponse
    {
        private OrderReferenceDetailsResponse orderReferenceDetails;
        private String id;
        private Dictionary<String, AuthorizeResponse> authorizationDetails = new Dictionary<String, AuthorizeResponse>();
        private Dictionary<String, CaptureResponse> captureDetails = new Dictionary<String, CaptureResponse>();
        private Dictionary<String, RefundResponse> refundDetails = new Dictionary<String, RefundResponse>();


        /// <summary>
        /// Add OrderReferenceID and OrderReferenceDetails
        /// </summary>
        public void PutOrderReferenceDetails(String id, OrderReferenceDetailsResponse orderReferenceResponse)
        {
            this.orderReferenceDetails = orderReferenceResponse;
            this.id = id;
        }

        /// <summary>
        /// Add AmazonAuthorizationReferenceID and AuthrizationDetails
        /// </summary>
        public void PutAuthorizationDetails(String id, AuthorizeResponse authorizeResponse)
        {
            authorizationDetails.Add(id, authorizeResponse);
        }

        /// <summary>
        /// Add AmazonCaptureID and CaptureDetails
        /// </summary>
        public void PutCaptureDetails(String id, CaptureResponse captureResponse)
        {
            captureDetails.Add(id, captureResponse);
        }

        /// <summary>
        /// Add AmazonRefundID and RefundDetails
        /// </summary>
        public void PutRefundDetails(String id, RefundResponse refundResponse)
        {
            refundDetails.Add(id, refundResponse);
        }

        /// <summary>
        /// Get the OrderReferenceDetails
        /// </summary>
        /// <returns>OrderReferenceDetailsResponse orderReferenceDetails</returns>
        public OrderReferenceDetailsResponse GetOrderReferenceDetails()
        {
            return orderReferenceDetails;
        }

        /// <summary>
        /// Get the AuthorizationDetails
        /// </summary>
        /// <returns>Dictionary<String, AuthorizeResponse> authorizationDetails</returns>
        public Dictionary<String, AuthorizeResponse> GetAuthorizationDetails()
        {
            return this.authorizationDetails;
        }

        /// <summary>
        /// Get the CaptureDetials
        /// </summary>
        /// <returns>Dictionary<String, CaptureResponse> captureDetials</returns>
        public Dictionary<String, CaptureResponse> GetCaptureDetails()
        {
            return this.captureDetails;
        }

        /// <summary>
        /// Get the RefundDetails
        /// </summary>
        /// <returns>Dictionary<String, RefundResponse> refundDetails</returns>
        public Dictionary<String, RefundResponse> GetRefundDetails()
        {
            return this.refundDetails;
        }
    }
}
