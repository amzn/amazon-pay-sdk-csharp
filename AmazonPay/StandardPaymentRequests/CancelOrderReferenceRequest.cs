namespace AmazonPay.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the CancelOrderReference API call parameters
    /// </summary>
    public class CancelOrderReferenceRequest : DelegateRequest<CancelOrderReferenceRequest>
    {
        private string amazon_order_reference_id;
        private string cancelation_reason;

        public CancelOrderReferenceRequest()
        {
            SetAction(Constants.CancelOrderReference);
        }

        protected override CancelOrderReferenceRequest GetThis()
        {
            return this;
        }

        /// <summary>
        /// Sets the Amazon Order Reference ID
        /// </summary>
        /// <param name="amazon_order_reference_id"></param>
        /// <returns>CancelOrderReferenceRequest Object</returns>
        public CancelOrderReferenceRequest WithAmazonOrderReferenceId(string amazon_order_reference_id)
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
        /// Sets the Cancelation reason for the order
        /// </summary>
        /// <param name="cancelation_reason"></param>
        /// <returns>CancelOrderReferenceRequest Object</returns>
        public CancelOrderReferenceRequest WithCancelationReason(string cancelation_reason)
        {
            this.cancelation_reason = cancelation_reason;
            return this;
        }

        /// <summary>
        /// Gets the Cancelation reason
        /// </summary>
        /// <returns>Cancelation reason</returns>
        public string GetCancelationReason()
        {
            return this.cancelation_reason;
        }
    }
}
