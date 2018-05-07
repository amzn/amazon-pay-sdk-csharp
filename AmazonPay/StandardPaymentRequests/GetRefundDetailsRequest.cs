namespace AmazonPay.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the GetRefundDetails API call parameters
    /// </summary>
    public class GetRefundDetailsRequest : DelegateRequest<GetRefundDetailsRequest>
    {
        private string amazon_refund_id;

        public GetRefundDetailsRequest()
        {
            SetAction(Constants.GetRefundDetails);
        }

        protected override GetRefundDetailsRequest GetThis()
        {
            return this;
        }
        
        /// <summary>
        /// Sets the Amazon Refund ID
        /// </summary>
        /// <param name="amazon_refund_id"></param>
        /// <returns>GetRefundDetailsRequest Object</returns>
        public GetRefundDetailsRequest WithAmazonRefundId(string amazon_refund_id)
        {
            this.amazon_refund_id = amazon_refund_id;
            return this;
        }

        /// <summary>
        /// Gets the Amazon Refund ID
        /// </summary>
        /// <returns>Amazon Refund ID</returns>
        public string GetAmazonRefundId()
        {
            return this.amazon_refund_id;
        }
    }
}
