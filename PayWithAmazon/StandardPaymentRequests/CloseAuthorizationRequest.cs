using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the CloseAuthorization API call parameters
    /// </summary>
    public class CloseAuthorizationRequest
    {
        public Hashtable closeAuthorizationHashtable = new Hashtable();

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>CloseAuthorizationRequest Object</returns>
        public CloseAuthorizationRequest WithMerchantId(string merchant_id)
        {
            closeAuthorizationHashtable["merchant_id"] = merchant_id;
            return this;
        }

        /// <summary>
        /// Sets the Amazon Authorization ID
        /// </summary>
        /// <param name="amazon_authorization_id"></param>
        /// <returns>CloseAuthorizationRequest Object</returns>
        public CloseAuthorizationRequest WithAmazonAuthorizationId(string amazon_authorization_id)
        {
            closeAuthorizationHashtable["amazon_authorization_id"] = amazon_authorization_id;
            return this;
        }

        /// <summary>
        /// Sets the Closure Reason
        /// </summary>
        /// <param name="closure_reason"></param>
        /// <returns>CloseAuthorizationRequest Object</returns>
        public CloseAuthorizationRequest WithClosureReason(string closure_reason)
        {
            closeAuthorizationHashtable["closure_reason"] = closure_reason;
            return this;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>CloseAuthorizationRequest Object</returns>
        public CloseAuthorizationRequest WithMWSAuthToken(string mws_auth_token)
        {
            closeAuthorizationHashtable["mws_auth_token"] = mws_auth_token;
            return this;
        }
    }
}
