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
        private string action;
        private string merchant_id;
        private string amazon_provider_credit_id;
        private string mws_auth_token;

        public GetProviderCreditDetailsRequest()
        {
            this.action = Constants.GetProviderCreditDetails;
        }
        public string GetAction()
        {
            return this.action;
        }
        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>GetProviderCreditDetailsRequest Object</returns>
        public GetProviderCreditDetailsRequest WithMerchantId(string merchant_id)
        {
            this.merchant_id = merchant_id;
            return this;
        }
        public string GetMerchantId()
        {
            return this.merchant_id;
        }

        /// <summary>
        /// Sets the Amazon Provider Credit ID
        /// </summary>
        /// <param name="amazon_provider_credit_id"></param>
        /// <returns>GetProviderCreditDetailsRequest Object</returns>
        public GetProviderCreditDetailsRequest WithAmazonProviderCreditId(string amazon_provider_credit_id)
        {
            this.amazon_provider_credit_id = amazon_provider_credit_id;
            return this;
        }
        public string GetAmazonProviderCreditId()
        {
            return this.amazon_provider_credit_id;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>GetProviderCreditDetailsRequest Object</returns>
        public GetProviderCreditDetailsRequest WithMWSAuthToken(string mws_auth_token)
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
