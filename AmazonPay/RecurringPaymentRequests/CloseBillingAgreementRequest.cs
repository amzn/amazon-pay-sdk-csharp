namespace AmazonPay.RecurringPaymentRequests
{
    /// <summary>
    /// Request class to set the CloseBillingAgreement API call parameters
    /// </summary>
    public class CloseBillingAgreementRequest
    {
        private string merchant_id;
        private string amazon_billing_agreement_id;
        private string closure_reason;
        private string mws_auth_token;
        private readonly string action;

        public CloseBillingAgreementRequest()
        {
            action = Constants.CloseBillingAgreement;
        }
        public string GetAction()
        {
            return action;
        }
        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>CloseBillingAgreementRequest Object</returns>
        public CloseBillingAgreementRequest WithMerchantId(string merchant_id)
        {
            this.merchant_id = merchant_id;
            return this;
        }
        public string GetMerchantId()
        {
            return merchant_id;
        }

        /// <summary>
        /// Sets the Amazon Billing Agreement ID
        /// </summary>
        /// <param name="amazon_billing_agreement_id"></param>
        /// <returns>CloseBillingAgreementRequest Object</returns>
        public CloseBillingAgreementRequest WithAmazonBillingAgreementId(string amazon_billing_agreement_id)
        {
            this.amazon_billing_agreement_id = amazon_billing_agreement_id;
            return this;
        }
        public string GetAmazonBillingAgreementId()
        {
            return amazon_billing_agreement_id;
        }

        /// <summary>
        /// Sets the Closure reason
        /// </summary>
        /// <param name="closure_reason"></param>
        /// <returns>CloseBillingAgreementRequest Object</returns>
        public CloseBillingAgreementRequest WithClosureReason(string closure_reason)
        {
            this.closure_reason = closure_reason;
            return this;
        }
        public string GetClosureReason()
        {
            return closure_reason;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>CloseBillingAgreementRequest Object</returns>
        public CloseBillingAgreementRequest WithMWSAuthToken(string mws_auth_token)
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
