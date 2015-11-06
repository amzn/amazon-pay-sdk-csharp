using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the CancelOrderReference API call parameters
    /// </summary>
    public class CancelOrderReferenceRequest
    {
        private string merchant_id;
        private string amazon_order_reference_id;
        private string cancelation_reason;
        private string mws_auth_token;
        private string action;

        public CancelOrderReferenceRequest()
        {
            this.action = Constants.CancelOrderReference;
        }
        public string GetAction()
        {
            return this.action;
        }

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>CancelOrderReferenceRequest Object</returns>
        public CancelOrderReferenceRequest WithMerchantId(string merchant_id)
        {
            this.merchant_id = merchant_id;
            return this;
        }
        public string GetMerchantId()
        {
            return this.merchant_id;
        }

        /// <summary>
        /// Sets the Amazon Order Reference ID
        /// </summary>
        /// <param name="amazon_order_reference_id"></param>
        /// <returns>CancelOrderReferenceRequest Object</returns>
        public CancelOrderReferenceRequest WithAmazonOrderReferenceId(string amazon_order_reference_id)
        {
            this.amazon_order_reference_id = amazon_order_reference_id;
            return this;
        }
        public string GetAmazonOrderReferenceId()
        {
            return this.amazon_order_reference_id;
        }

        /// <summary>
        /// Sets the Cancelation reason for the order
        /// </summary>
        /// <param name="cancelation_reason"></param>
        /// <returns>CancelOrderReferenceRequest Object</returns>
        public CancelOrderReferenceRequest WithCancelationReason(string cancelation_reason)
        {
            this.cancelation_reason = cancelation_reason;
            return this;
        }
        public string GetCancelationReason()
        {
            return this.cancelation_reason;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>CancelOrderReferenceRequest Object</returns>
        public CancelOrderReferenceRequest WithMWSAuthToken(string mws_auth_token)
        {
            this.mws_auth_token = mws_auth_token;
            return this;
        }
        public string GetMWSAuthToken()
        {
            return this.mws_auth_token;
        }
    }
}
