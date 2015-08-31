using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the ConfirmOrderReference API call parameters
    /// </summary>
    public class ConfirmOrderReferenceRequest
    {
        public Hashtable confirmOrderReferenceHashtable = new Hashtable();

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>ConfirmOrderReferenceRequest Object</returns>
        public ConfirmOrderReferenceRequest WithMerchantId(string merchant_id)
        {
            confirmOrderReferenceHashtable["merchant_id"] = merchant_id;
            return this;
        }

        /// <summary>
        /// Sets the Amazon Order Reference ID
        /// </summary>
        /// <param name="amazon_order_reference_id"></param>
        /// <returns>ConfirmOrderReferenceRequest Object</returns>
        public ConfirmOrderReferenceRequest WithAmazonOrderReferenceId(string amazon_order_reference_id)
        {
            confirmOrderReferenceHashtable["amazon_order_reference_id"] = amazon_order_reference_id;
            return this;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>ConfirmOrderReferenceRequest Object</returns>
        public ConfirmOrderReferenceRequest WithMWSAuthToken(string mws_auth_token)
        {
            confirmOrderReferenceHashtable["mws_auth_token"] = mws_auth_token;
            return this;
        }
    }
}
