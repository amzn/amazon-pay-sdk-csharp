namespace AmazonPay.CommonRequests
{
    /// <summary>
    /// Set the GetServiceStatus API call parameters
    /// </summary>
    public class GetServiceStatusRequest
    {
        private string merchant_id;
        private string mws_auth_token;
        private readonly string action;

        public GetServiceStatusRequest()
        {
            action = Constants.GetServiceStatus;
        }
        public string GetAction()
        {
            return action;
        }

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>GetServiceStatusRequest Object</returns>
        public GetServiceStatusRequest WithMerchantId(string merchant_id)
        {
            this.merchant_id = merchant_id;
            return this;
        }
        public string GetMerchantId()
        {
            return merchant_id;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>GetServiceStatusRequest Object</returns>
        public GetServiceStatusRequest WithMWSAuthToken(string mws_auth_token)
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
