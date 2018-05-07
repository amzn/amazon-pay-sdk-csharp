namespace AmazonPay.RecurringPaymentRequests
{
    /// <summary>
    /// Request class to set the GetBillingAgreementDetails API call parameters
    /// </summary>
    public class GetBillingAgreementDetailsRequest : DelegateRequest<GetBillingAgreementDetailsRequest>
    {
        private string amazon_billing_agreement_id;
        private string address_consent_token;

        public GetBillingAgreementDetailsRequest()
        {
            SetAction(Constants.GetBillingAgreementDetails);
        }

        protected override GetBillingAgreementDetailsRequest GetThis()
        {
            return this;
        }

        /// <summary>
        /// Sets the Amazon Billing Agreement ID
        /// </summary>
        /// <param name="amazon_billing_agreement_id"></param>
        /// <returns>GetBillingAgreementDetailsRequest Object</returns>
        public GetBillingAgreementDetailsRequest WithAmazonBillingAgreementId(string amazon_billing_agreement_id)
        {
            this.amazon_billing_agreement_id = amazon_billing_agreement_id;
            return this;
        }

        /// <summary>
        /// Gets the Amazon Billing Agreement ID
        /// </summary>
        /// <returns>Amazon Billing Agreement ID</returns>
        public string GetAmazonBillingAgreementId()
        {
            return this.amazon_billing_agreement_id;
        }

        /// <summary>
        /// Sets the Address Consent Token
        /// </summary>
        /// <param name="address_consent_token"></param>
        /// <returns>GetBillingAgreementDetailsRequest Object</returns>
        public GetBillingAgreementDetailsRequest WithaddressConsentToken(string address_consent_token)
        {
            this.address_consent_token = System.Web.HttpUtility.UrlDecode(address_consent_token);
            return this;
        }

        /// <summary>
        /// Gets the Address Consent Token
        /// </summary>
        /// <returns>Address Consent Token</returns>
        public string GetAddressConsentToken()
        {
            return this.address_consent_token;
        }
    }
}
