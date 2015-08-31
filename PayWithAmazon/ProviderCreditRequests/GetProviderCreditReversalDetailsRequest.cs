using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.ProviderCreditRequests
{
    /// <summary>
    /// Request class to set the GetProviderCreditReversalDetails API call parameters
    /// </summary>
    public class GetProviderCreditReversalDetailsRequest
    {
        public Hashtable getProviderCreditReversalDetailsHashtable = new Hashtable();

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>GetProviderCreditReversalDetailsRequest Object</returns>
        public GetProviderCreditReversalDetailsRequest WithMerchantId(string merchant_id)
        {
            getProviderCreditReversalDetailsHashtable["merchant_id"] = merchant_id;
            return this;
        }

        /// <summary>
        /// Sets the Amazon Provider Credit Reversal ID
        /// </summary>
        /// <param name="amazon_provider_credit_reversal_id"></param>
        /// <returns>GetProviderCreditReversalDetailsRequest Object</returns>
        public GetProviderCreditReversalDetailsRequest WithAmazonProviderCreditReversalId(string amazon_provider_credit_reversal_id)
        {
            getProviderCreditReversalDetailsHashtable["amazon_provider_credit_reversal_id"] = amazon_provider_credit_reversal_id;
            return this;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>GetProviderCreditReversalDetailsRequest Object</returns>
        public GetProviderCreditReversalDetailsRequest WithMWSAuthToken(string mws_auth_token)
        {
            getProviderCreditReversalDetailsHashtable["mws_auth_token"] = mws_auth_token;
            return this;
        }
    }
}
