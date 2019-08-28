namespace AmazonPay.RecurringPaymentRequests
{
    /// <summary>
    /// Request class to set the ConfirmBillingAgreement API call parameters
    /// </summary>
    public class ConfirmBillingAgreementRequest : DelegateRequest<ConfirmBillingAgreementRequest>
    {
        private string amazon_billing_agreement_id;
        private string success_url;
        private string failure_url;

        public ConfirmBillingAgreementRequest()
        {
            SetAction(Constants.ConfirmBillingAgreement);
        }

        protected override ConfirmBillingAgreementRequest GetThis()
        {
            return this;
        }

        /// <summary>
        /// Sets the Amazon Billing Agreement ID
        /// </summary>
        /// <param name="amazon_billing_agreement_id"></param>
        /// <returns>ConfirmBillingAgreementRequest Object</returns>
        /// Deprecating because of typo in method name
        [System.Obsolete("Erroneous method name. Please use WithAmazonBillingAgreementId")]
        public ConfirmBillingAgreementRequest WithAmazonBillingreementId(string amazon_billing_agreement_id)
        {
            this.amazon_billing_agreement_id = amazon_billing_agreement_id;
            return this;
        }

        /// <summary>
        /// Sets the Amazon Billing Agreement ID
        /// </summary>
        /// <param name="amazon_billing_agreement_id"></param>
        /// <returns>ConfirmBillingAgreementRequest Object</returns>
        public ConfirmBillingAgreementRequest WithAmazonBillingAgreementId(string amazon_billing_agreement_id)
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
        /// Sets the Success URL
        /// </summary>
        /// <param name="success_url"></param>
        /// <returns>ConfirmBillingAgreementRequest Object</returns>
        public ConfirmBillingAgreementRequest WithSuccessUrl(string success_url)
        {
            this.success_url = success_url;
            return this;
        }

        /// <summary>
        /// Gets the Success URL
        /// </summary>
        /// <returns>Success URL</returns>
        public string GetSuccessUrl()
        {
            return this.success_url;
        }

        /// <summary>
        /// Sets the Failure URL
        /// </summary>
        /// <param name="failure_url"></param>
        /// <returns>ConfirmBillingAgreementRequest Object</returns>
        public ConfirmBillingAgreementRequest WithFailureUrl(string failure_url)
        {
            this.failure_url = failure_url;
            return this;
        }

        /// <summary>
        /// Gets the Failure URL
        /// </summary>
        /// <returns>Failure URL</returns>
        public string GetFailureUrl()
        {
            return this.failure_url;
        }
    }
}
