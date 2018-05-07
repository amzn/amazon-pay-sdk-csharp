namespace AmazonPay.ProviderCreditRequests
{
    /// <summary>
    /// Request class to set the GetProviderCreditReversalDetails API call parameters
    /// </summary>
    public class GetProviderCreditReversalDetailsRequest : DelegateRequest<GetProviderCreditReversalDetailsRequest>
    {
        private string amazon_provider_credit_reversal_id;

        public GetProviderCreditReversalDetailsRequest()
        {
            SetAction(Constants.GetProviderCreditReversalDetails);
        }

        protected override GetProviderCreditReversalDetailsRequest GetThis()
        {
            return this;
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

        /// <summary>
        /// Gets the Amazon Provider Credit Reversal ID
        /// </summary>
        /// <returns>Amazon Provider Credit Reversal ID</returns>
        public string GetAmazonProviderCreditReversalId()
        {
            return this.amazon_provider_credit_reversal_id;
        }
    }
}
