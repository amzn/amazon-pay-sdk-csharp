namespace AmazonPay.ProviderCreditRequests
{
    /// <summary>
    /// Request class to set the GetProviderCreditReversalDetails API call parameters
    /// </summary>
    public class GetProviderCreditReversalDetailsRequest
    {
        private readonly string action;
        private string merchant_id;
        private string amazon_provider_credit_reversal_id;
        private string mws_auth_token;

        public GetProviderCreditReversalDetailsRequest()
        {
            action = Constants.GetProviderCreditReversalDetails;
        }
        public string GetAction()
        {
            return action;
        }

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>GetProviderCreditReversalDetailsRequest Object</returns>
        public GetProviderCreditReversalDetailsRequest WithMerchantId(string merchant_id)
        {
            this.merchant_id = merchant_id;
            return this;
        }
        public string GetMerchantId()
        {
            return merchant_id;
        }

        /// <summary>
        /// Sets the Amazon Provider Credit Reversal ID
        /// </summary>
        /// <param name="amazon_provider_credit_reversal_id"></param>
        /// <returns>GetProviderCreditReversalDetailsRequest Object</returns>
        public GetProviderCreditReversalDetailsRequest WithAmazonProviderCreditReversalId(string amazon_provider_credit_reversal_id)
        {
            this.amazon_provider_credit_reversal_id = amazon_provider_credit_reversal_id;
            return this;
        }
        public string GetAmazonProviderCreditReversalId()
        {
            return amazon_provider_credit_reversal_id;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>GetProviderCreditReversalDetailsRequest Object</returns>
        public GetProviderCreditReversalDetailsRequest WithMWSAuthToken(string mws_auth_token)
        {
            this.mws_auth_token = mws_auth_token;
            return this;
        }
        public string GetMWSAuthToken()
        {
            return mws_auth_token;
        }
    }
}
