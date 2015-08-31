using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.ProviderCreditRequests
{
    /// <summary>
    /// Request class to set the  GetProviderCreditDetails API call parameters
    /// </summary>
    public class GetProviderCreditDetailsRequest
    {
        public Hashtable getProviderCreditDetailsHashtable = new Hashtable();

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>GetProviderCreditDetailsRequest Object</returns>
        public GetProviderCreditDetailsRequest WithMerchantId(string merchant_id)
        {
            getProviderCreditDetailsHashtable["merchant_id"] = merchant_id;
            return this;
        }

        /// <summary>
        /// Sets the Amazon Provider Credit ID
        /// </summary>
        /// <param name="amazon_provider_credit_id"></param>
        /// <returns>GetProviderCreditDetailsRequest Object</returns>
        public GetProviderCreditDetailsRequest WithAmazonProviderCreditId(string amazon_provider_credit_id)
        {
            getProviderCreditDetailsHashtable["amazon_provider_credit_id"] = amazon_provider_credit_id;
            return this;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>GetProviderCreditDetailsRequest Object</returns>
        public GetProviderCreditDetailsRequest WithMWSAuthToken(string mws_auth_token)
        {
            getProviderCreditDetailsHashtable["mws_auth_token"] = mws_auth_token;
            return this;
        }
    }
}
