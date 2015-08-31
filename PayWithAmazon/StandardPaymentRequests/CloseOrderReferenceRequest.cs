using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the CloseOrderReference API call parameters
    /// </summary>
    public class CloseOrderReferenceRequest
    {
        public Hashtable closeOrderReferenceHashtable = new Hashtable();

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>CloseOrderReferenceRequest Object</returns>
        public CloseOrderReferenceRequest WithMerchantId(string merchant_id)
        {
            closeOrderReferenceHashtable["merchant_id"] = merchant_id;
            return this;
        }

        /// <summary>
        /// Sets the Amazon Order Reference ID
        /// </summary>
        /// <param name="amazon_order_reference_id"></param>
        /// <returns>CloseOrderReferenceRequest Object</returns>
        public CloseOrderReferenceRequest WithAmazonOrderReferenceId(string amazon_order_reference_id)
        {
            closeOrderReferenceHashtable["amazon_order_reference_id"] = amazon_order_reference_id;
            return this;
        }

        /// <summary>
        /// Sets the Closure reason
        /// </summary>
        /// <param name="closure_reason"></param>
        /// <returns>CloseOrderReferenceRequest Object</returns>
        public CloseOrderReferenceRequest WithClosureReason(string closure_reason)
        {
            closeOrderReferenceHashtable["closure_reason"] = closure_reason;
            return this;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>CloseOrderReferenceRequest Object</returns>
        public CloseOrderReferenceRequest WithMWSAuthToken(string mws_auth_token)
        {
            closeOrderReferenceHashtable["mws_auth_token"] = mws_auth_token;
            return this;
        }
    }
}
