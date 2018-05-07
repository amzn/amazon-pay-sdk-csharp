namespace AmazonPay.ProviderCreditRequests
{
    /// <summary>
    /// Request class to set the  GetProviderCreditDetails API call parameters
    /// </summary>
    public class GetProviderCreditDetailsRequest : DelegateRequest<GetProviderCreditDetailsRequest>
    {
        private string amazon_provider_credit_id;

        public GetProviderCreditDetailsRequest()
        {
            SetAction(Constants.GetProviderCreditDetails);
        }

        protected override GetProviderCreditDetailsRequest GetThis()
        {
            return this;
        }

        /// <summary>
        /// Sets the Amazon Provider Credit ID
        /// </summary>
        /// <param name="amazon_provider_credit_id"></param>
        /// <returns>GetProviderCreditDetailsRequest Object</returns>
        public GetProviderCreditDetailsRequest WithAmazonProviderCreditId(string amazon_provider_credit_id)
        {
            this.amazon_provider_credit_id = amazon_provider_credit_id;
            return this;
        }

        /// <summary>
        /// Gets the Amazon Provider Credit ID
        /// </summary>
        /// <returns>Amazon Provider Credit ID</returns>
        public string GetAmazonProviderCreditId()
        {
            return this.amazon_provider_credit_id;
        }
    }
}
