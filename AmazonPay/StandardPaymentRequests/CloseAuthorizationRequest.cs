namespace AmazonPay.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the CloseAuthorization API call parameters
    /// </summary>
    public class CloseAuthorizationRequest : DelegateRequest<CloseAuthorizationRequest>
    {
        private string amazon_authorization_id;
        private string closure_reason;

        public CloseAuthorizationRequest()
        {
            SetAction(Constants.CloseAuthorization);
        }

        protected override CloseAuthorizationRequest GetThis()
        {
            return this;
        }
        
        /// <summary>
        /// Sets the Amazon Authorization ID
        /// </summary>
        /// <param name="amazon_authorization_id"></param>
        /// <returns>CloseAuthorizationRequest Object</returns>
        public CloseAuthorizationRequest WithAmazonAuthorizationId(string amazon_authorization_id)
        {
            this.amazon_authorization_id = amazon_authorization_id;
            return this;
        }

        /// <summary>
        /// Gets the Amazon Authorization ID
        /// </summary>
        /// <returns>Amazon Authorization ID></returns>
        public string GetAmazonAuthorizationId()
        {
            return this.amazon_authorization_id;
        }

        /// <summary>
        /// Sets the Closure Reason
        /// </summary>
        /// <param name="closure_reason"></param>
        /// <returns>CloseAuthorizationRequest Object</returns>
        public CloseAuthorizationRequest WithClosureReason(string closure_reason)
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
