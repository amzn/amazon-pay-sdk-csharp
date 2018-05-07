namespace AmazonPay.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the GetAuthorizationDetails API call parameters
    /// </summary>
    public class GetAuthorizationDetailsRequest : DelegateRequest<GetAuthorizationDetailsRequest>
    {
        private string amazon_authorization_id;

        public GetAuthorizationDetailsRequest()
        {
            SetAction(Constants.GetAuthorizationDetails);
        }

        protected override GetAuthorizationDetailsRequest GetThis()
        {
            return this;
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

        /// <summary>
        /// Gets the Amazon AUthorization ID
        /// </summary>
        /// <returns> Amazon AUthorization ID</returns>
        public string GetAmazonAuthorizationId()
        {
            return this.amazon_authorization_id;
        }
    }
}
