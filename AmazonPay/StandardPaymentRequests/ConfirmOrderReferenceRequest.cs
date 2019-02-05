using System;

namespace AmazonPay.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the ConfirmOrderReference API call parameters
    /// </summary>
    public class ConfirmOrderReferenceRequest : DelegateRequest<ConfirmOrderReferenceRequest>
    {
        private string amazon_order_reference_id;
        private string success_url;
        private string failure_url;
        private decimal? amount;
        private string currency_code;

        public ConfirmOrderReferenceRequest()
        {
            SetAction(Constants.ConfirmOrderReference);
        }

        protected override ConfirmOrderReferenceRequest GetThis()
        {
            return this;
        }
        
        /// <summary>
        /// Sets the Amazon Order Reference ID
        /// </summary>
        /// <param name="amazon_order_reference_id"></param>
        /// <returns>ConfirmOrderReferenceRequest Object</returns>
        public ConfirmOrderReferenceRequest WithAmazonOrderReferenceId(string amazon_order_reference_id)
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
        ///  Sets the amount
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>ConfirmOrderReferenceRequest Object</returns>
        public ConfirmOrderReferenceRequest WithAmount(decimal? amount)
        {
            this.amount = amount;
            return this;
        }

        /// <summary>
        /// Gets the amount
        /// </summary>
        /// <returns>amount</returns>
        public decimal? GetAmount()
        {
            return this.amount;
        }

        /// <summary>
        ///  Sets the Currency Code
        /// </summary>
        /// <param name="currency_code"></param>
        /// <returns>ConfirmOrderReferenceRequest Object</returns>
        public ConfirmOrderReferenceRequest WithCurrencyCode(Enum currency_code)
        {
            this.currency_code = currency_code.ToString();
            return this;
        }

        /// <summary>
        /// Gets the Currency Code
        /// </summary>
        /// <returns>Currency Code</returns>
        public string GetCurrencyCode()
        {
            return this.currency_code;
        }

        /// <summary>
        ///  Sets the success url
        /// </summary>
        /// <param name="success_url"></param>
        /// <returns>ConfirmOrderReferenceRequest Object</returns>
        public ConfirmOrderReferenceRequest WithSuccessUrl(string success_url)
        {
            this.success_url = success_url;
            return this;
        }

        /// <summary>
        /// Gets the success url
        /// </summary>
        /// <returns>success url</returns>
        public string GetSuccessUrl()
        {
            return this.success_url;
        }

        /// <summary>
        ///  Sets the failure url
        /// </summary>
        /// <param name="failure_url"></param>
        /// <returns>ConfirmOrderReferenceRequest Object</returns>
        public ConfirmOrderReferenceRequest WithFailureUrl(string failure_url)
        {
            this.failure_url = failure_url;
            return this;
        }

        /// <summary>
        /// Gets the failure url
        /// </summary>
        /// <returns>failure url</returns>
        public string GetFailureUrl()
        {
            return this.failure_url;
        }
    }
}
