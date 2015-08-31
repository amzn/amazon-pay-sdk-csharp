using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the GetAuthorizationDetails API call parameters
    /// </summary>
    public class GetAuthorizationDetailsRequest
    {
        public Hashtable getAuthorizationDetailsHashtable = new Hashtable();

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>GetAuthorizationDetailsRequest Object</returns>
        public GetAuthorizationDetailsRequest WithMerchantId(string merchant_id)
        {
            getAuthorizationDetailsHashtable["merchant_id"] = merchant_id;
            return this;
        }

        /// <summary>
        /// Sets the Amazon Authorization ID
        /// </summary>
        /// <param name="amazon_authorization_id"></param>
        /// <returns>GetAuthorizationDetailsRequest Object</returns>
        public GetAuthorizationDetailsRequest WithAmazonAuthorizationId(string amazon_authorization_id)
        {
            getAuthorizationDetailsHashtable["amazon_authorization_id"] = amazon_authorization_id;
            return this;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>GetAuthorizationDetailsRequest Object</returns>
        public GetAuthorizationDetailsRequest WithMWSAuthToken(string mws_auth_token)
        {
            getAuthorizationDetailsHashtable["mws_auth_token"] = mws_auth_token;
            return this;
        }
    }
}
