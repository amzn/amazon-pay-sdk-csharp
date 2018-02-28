namespace AmazonPay.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the ConfirmOrderReference API call parameters
    /// </summary>
    public class ConfirmOrderReferenceRequest
    {
        private readonly string action;
        private string amazon_order_reference_id;
        private string merchant_id;
        private string mws_auth_token;

        public ConfirmOrderReferenceRequest()
        {
            action = Constants.ConfirmOrderReference;
        }
        public string GetAction()
        {
            return action;
        }
        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>ConfirmOrderReferenceRequest Object</returns>
        public ConfirmOrderReferenceRequest WithMerchantId(string merchant_id)
        {
            this.merchant_id = merchant_id;
            return this;
        }

        public string GetMerchantId()
        {
            return merchant_id;
        }
        /// <summary>
        /// Sets the Amazon Order Reference ID
        /// </summary>
        /// <param name="amazon_order_reference_id"></param>
        /// <returns>ConfirmOrderReferenceRequest Object</returns>
        public ConfirmOrderReferenceRequest WithAmazonOrderReferenceId(string amazon_order_reference_id)
        {
            this.amazon_order_reference_id = amazon_order_reference_id;
            return this;
        }
        public string GetAmazonOrderReferenceId()
        {
            return amazon_order_reference_id;
        }
        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>ConfirmOrderReferenceRequest Object</returns>
        public ConfirmOrderReferenceRequest WithMWSAuthToken(string mws_auth_token)
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
