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
        public Hashtable cancelOrderReferenceHashtable = new Hashtable();

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>CancelOrderReferenceRequest Object</returns>
        public CancelOrderReferenceRequest WithMerchantId(string merchant_id)
        {
            cancelOrderReferenceHashtable["merchant_id"] = merchant_id;
            return this;
        }

        /// <summary>
        /// Sets the Amazon Order Reference ID
        /// </summary>
        /// <param name="amazon_order_reference_id"></param>
        /// <returns>CancelOrderReferenceRequest Object</returns>
        public CancelOrderReferenceRequest WithAmazonOrderReferenceId(string amazon_order_reference_id)
        {
            cancelOrderReferenceHashtable["amazon_order_reference_id"] = amazon_order_reference_id;
            return this;
        }

        /// <summary>
        /// Sets the Cancelation reason for the order
        /// </summary>
        /// <param name="cancelation_reason"></param>
        /// <returns>CancelOrderReferenceRequest Object</returns>
        public CancelOrderReferenceRequest WithCancelationReason(string cancelation_reason)
        {
            cancelOrderReferenceHashtable["cancelation_reason"] = cancelation_reason;
            return this;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>CancelOrderReferenceRequest Object</returns>
        public CancelOrderReferenceRequest WithMWSAuthToken(string mws_auth_token)
        {
            cancelOrderReferenceHashtable["mws_auth_token"] = mws_auth_token;
            return this;
        }
    }
}
