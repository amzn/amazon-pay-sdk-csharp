namespace AmazonPay.RecurringPaymentRequests
{
    /// <summary>
    /// Request class to set the ValidateBillingAgreement API call parameters
    /// </summary>
    public class ValidateBillingAgreementRequest : DelegateRequest<ValidateBillingAgreementRequest>
    {
        private string amazon_billing_agreement_id;

        public ValidateBillingAgreementRequest()
        {
            SetAction(Constants.ValidateBillingAgreement);
        }

        protected override ValidateBillingAgreementRequest GetThis()
        {
            return this;
        }

        /// <summary>
        /// Sets the Amazon Billing Agreement ID
        /// </summary>
        /// <param name="amazon_billing_agreement_id"></param>
        /// <returns>ValidateBillingAgreementRequest Object</returns>
        public ValidateBillingAgreementRequest WithAmazonBillingAgreementId(string amazon_billing_agreement_id)
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
    }
}
