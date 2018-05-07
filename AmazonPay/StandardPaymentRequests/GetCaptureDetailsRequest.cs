namespace AmazonPay.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the GetCaptureDetails API call parameters
    /// </summary>
    public class GetCaptureDetailsRequest : DelegateRequest<GetCaptureDetailsRequest>
    {
        private string amazon_capture_id;

        public GetCaptureDetailsRequest()
        {
            SetAction(Constants.GetCaptureDetails);
        }

        protected override GetCaptureDetailsRequest GetThis()
        {
            return this;
        }
        
        /// <summary>
        /// Sets the Amazon Capture ID
        /// </summary>
        /// <param name="amazon_capture_id"></param>
        /// <returns>GetCaptureDetailsRequest Object</returns>
        public GetCaptureDetailsRequest WithAmazonCaptureId(string amazon_capture_id)
        {
            this.amazon_capture_id = amazon_capture_id;
            return this;
        }

        /// <summary>
        /// Gets the Amazon Capture ID
        /// </summary>
        /// <returns>Amazon Capture ID</returns>
        public string GetAmazonCaptureId()
        {
            return this.amazon_capture_id;
        }
    }
}
