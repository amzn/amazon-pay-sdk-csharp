namespace AmazonPay.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the CloseOrderReference API call parameters
    /// </summary>
    public class CloseOrderReferenceRequest : DelegateRequest<CloseOrderReferenceRequest>
    {
        private string amazon_order_reference_id;
        private string closure_reason;

        public CloseOrderReferenceRequest()
        {
            SetAction(Constants.CloseOrderReference);
        }

        protected override CloseOrderReferenceRequest GetThis()
        {
            return this;
        }

        /// <summary>
        /// Sets the Amazon Order Reference ID
        /// </summary>
        /// <param name="amazon_order_reference_id"></param>
        /// <returns>CloseOrderReferenceRequest Object</returns>
        public CloseOrderReferenceRequest WithAmazonOrderReferenceId(string amazon_order_reference_id)
        {
            this.amazon_order_reference_id = amazon_order_reference_id;
            return this;
        }

        /// <summary>
        /// Gets the Amazon Order Reference ID
        /// </summary>
        /// <returns>Amazon Order Reference ID</returns>
        public string GetAmazonOrderReferenceId()
        {
            return this.amazon_order_reference_id;
        }

        /// <summary>
        /// Sets the Closure reason
        /// </summary>
        /// <param name="closure_reason"></param>
        /// <returns>CloseOrderReferenceRequest Object</returns>
        public CloseOrderReferenceRequest WithClosureReason(string closure_reason)
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
