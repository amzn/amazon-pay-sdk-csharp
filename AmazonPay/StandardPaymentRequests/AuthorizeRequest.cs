using System;
using System.Collections.Generic;

namespace AmazonPay.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the Autorize API call parameters
    /// </summary>
    public class AuthorizeRequest : DelegateRequest<AuthorizeRequest>
    {
        private string amazon_order_reference_id;
        private decimal amount;
        private string currency_code;
        private bool? capture_now;
        private string seller_authorization_note;
        private string authorization_reference_id;
        private string soft_descriptor;
        private int? transaction_timeout;
        List<Dictionary<string, string>> providerCredit = new List<Dictionary<string, string>>();


        public AuthorizeRequest()
        {
            SetAction(Constants.Authorize);
        }

        protected override AuthorizeRequest GetThis()
        {
            return this;
        }

        /// <summary>
        /// Sets the Amazo Order Reference ID
        /// </summary>
        /// <param name="amazon_order_reference_id"></param>
        /// <returns>Amazon Order Reference Id </returns>
        public AuthorizeRequest WithAmazonOrderReferenceId(string amazon_order_reference_id)
        {
            this.amazon_order_reference_id = amazon_order_reference_id;
            return this;
        }

        /// <summary>
        /// Gets the Amzon Order Reference ID
        /// </summary>
        /// <returns>Amzon Order Reference ID</returns>
        public string GetAmazonOrderReferenceId()
        {
            return this.amazon_order_reference_id;
        }

        /// <summary>
        /// Sets the Amount for the order
        /// </summary>
        /// <param name="authorization_amount"></param>
        /// <returns>Amount</returns>
        public AuthorizeRequest WithAmount(decimal authorization_amount)
        {
            this.amount = authorization_amount;
            return this;
        }

        /// <summary>
        /// Gets the Amount for the order
        /// </summary>
        /// <returns>Amount</returns>
        public decimal GetAmount()
        {
            return this.amount;
        }

        /// <summary>
        /// Sets the Currency Code for the Amount
        /// </summary>
        /// <param name="currency_code"></param>
        /// <returns>AuthorizeRequest Object</returns>
        public AuthorizeRequest WithCurrencyCode(Enum currency_code)
        {
            this.currency_code = currency_code.ToString();
            return this;
        }

        /// <summary>
        /// Gets the Currency Code for the amount
        /// </summary>
        /// <returns>Currency Code</returns>
        public string GetCurrencyCode()
        {
            return this.currency_code;
        }

        /// <summary>
        /// Sets the Authorization Reference ID - Unique string
        /// </summary>
        /// <param name="authorization_reference_id"></param>
        /// <returns>AuthorizeRequest Object</returns>
        public AuthorizeRequest WithAuthorizationReferenceId(string authorization_reference_id)
        {
            this.authorization_reference_id = authorization_reference_id;
            return this;
        }

        /// <summary>
        /// Gets the Authorization reference ID
        /// </summary>
        /// <returns>Authorization reference ID</returns>
        public string GetAuthorizationReferenceId()
        {
            return this.authorization_reference_id;
        }

        /// <summary>
        /// Sets the Boolean value for the Capture Now.
        /// The accepted values are true, false and null.
        /// </summary>
        /// <param name="capture_now"></param>
        /// <returns>AuthorizeRequest Object</returns>
        public AuthorizeRequest WithCaptureNow(bool? capture_now)
        {
            this.capture_now = capture_now;
            return this;
        }

        /// <summary>
        /// Gets the Capture Now value
        /// </summary>
        /// <returns>Capture Now</returns>
        public string GetCaptureNow()
        {
            return this.capture_now.ToString().ToLower();
        }

        /// <summary>
        /// Sets the Provider Credit Details
        /// </summary>
        /// <param name="provider_id"></param>
        /// <param name="amount"></param>
        /// <param name="currency_code"></param>
        /// <returns>AuthorizeRequest Object</returns>
        public AuthorizeRequest WithProviderCreditDetails(string provider_id, decimal amount, string currency_code)
        {
            Dictionary<string, string> providerCreditDetails = new Dictionary<string, string>();
            providerCreditDetails.Clear();
            providerCreditDetails[Constants.ProviderId] = provider_id;
            providerCreditDetails[Constants.CreditAmount_Amount] = amount.ToString();
            providerCreditDetails[Constants.CreditAmount_CurrencyCode] = currency_code.ToUpper();

            providerCredit.Add(providerCreditDetails);
            return this;
        }

        /// <summary>
        /// Gets the Provider Credit Details
        /// </summary>
        /// <returns>Provider Credit Details</returns>
        public IList<Dictionary<string, string>> GetProviderCreditDetails()
        {
            return this.providerCredit;
        }

        /// <summary>
        /// Sets the Seller Authorization Note
        /// </summary>
        /// <param name="seller_authorization_note"></param>
        /// <returns>AuthorizeRequest Object</returns>
        public AuthorizeRequest WithSellerAuthorizationNote(string seller_authorization_note)
        {
            this.seller_authorization_note = seller_authorization_note;
            return this;
        }

        /// <summary>
        /// Gets the Seller Authorization Note
        /// </summary>
        /// <returns>Seller Authorization Note</returns>
        public string GetSellerAuthorizationNote()
        {
            return this.seller_authorization_note;
        }

        /// <summary>
        /// Sets the Transaction Timeout value
        /// </summary>
        /// <param name="transaction_timeout"></param>
        /// <returns>AuthorizeRequest Object</returns>
        public AuthorizeRequest WithTransactionTimeout(int? transaction_timeout = null)
        {
            this.transaction_timeout = transaction_timeout;
            return this;
        }

        /// <summary>
        /// Gets the Transaction Timeout
        /// </summary>
        /// <returns>Transaction Timeout</returns>
        public int? GetTransactionTimeout()
        {
            return this.transaction_timeout;
        }

        /// <summary>
        /// Sets the Soft Descriptor
        /// </summary>
        /// <param name="soft_descriptor"></param>
        /// <returns>AuthorizeRequest Object</returns>
        public AuthorizeRequest WithSoftDescriptor(string soft_descriptor)
        {
            this.soft_descriptor = soft_descriptor;
            return this;
        }

        /// <summary>
        /// Gets the Soft Descriptor value
        /// </summary>
        /// <returns>Soft Descriptor</returns>
        public string GetSoftDescriptor()
        {
            return this.soft_descriptor;
        }
    }
}
