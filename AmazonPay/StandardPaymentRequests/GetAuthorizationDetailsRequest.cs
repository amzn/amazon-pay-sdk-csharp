namespace AmazonPay.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the GetAuthorizationDetails API call parameters
    /// </summary>
    public class GetAuthorizationDetailsRequest
    {
        private string merchant_id;
        private string amazon_authorization_id;
        private string mws_auth_token;
        private readonly string action;

        public GetAuthorizationDetailsRequest()
        {
            action = Constants.GetAuthorizationDetails;
        }
        public string GetAction()
        {
            return action;
        }

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>GetAuthorizationDetailsRequest Object</returns>
        public GetAuthorizationDetailsRequest WithMerchantId(string merchant_id)
        {
            this.merchant_id = merchant_id;
            return this;
        }
        public string GetMerchantId()
        {
            return merchant_id;
        }

        /// <summary>
        /// Sets the Amazon Authorization ID
        /// </summary>
        /// <param name="amazon_authorization_id"></param>
        /// <returns>GetAuthorizationDetailsRequest Object</returns>
        public GetAuthorizationDetailsRequest WithAmazonAuthorizationId(string amazon_authorization_id)
        {
            this.amazon_authorization_id = amazon_authorization_id;
            return this;
        }
        public string GetAmazonAuthorizationId()
        {
            return amazon_authorization_id;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>GetAuthorizationDetailsRequest Object</returns>
        public GetAuthorizationDetailsRequest WithMWSAuthToken(string mws_auth_token)
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
