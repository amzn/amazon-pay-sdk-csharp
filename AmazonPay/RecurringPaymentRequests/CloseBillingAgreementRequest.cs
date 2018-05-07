namespace AmazonPay.RecurringPaymentRequests
{
    /// <summary>
    /// Request class to set the CloseBillingAgreement API call parameters
    /// </summary>
    public class CloseBillingAgreementRequest : DelegateRequest<CloseBillingAgreementRequest>
    {
        private string amazon_billing_agreement_id;
        private string closure_reason;

        public CloseBillingAgreementRequest()
        {
            SetAction(Constants.CloseBillingAgreement);
        }

        protected override CloseBillingAgreementRequest GetThis()
        {
            return this;
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

        /// <summary>
        /// Gets the Amazon Billing Agreement ID
        /// </summary>
        /// <returns>Amazon Billing Agreement ID</returns>
        public string GetAmazonBillingAgreementId()
        {
            return this.amazon_billing_agreement_id;
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

        /// <summary>
        /// Gets the Closure Reason
        /// </summary>
        /// <returns>Closure Reason</returns>
        public string GetClosureReason()
        {
            return this.closure_reason;
        }
    }
}
