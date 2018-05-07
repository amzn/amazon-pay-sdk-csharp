using System;

namespace AmazonPay.RecurringPaymentRequests
{
    /// <summary>
    /// Request class to set the AuthorizeOnBillingAgreement API call PARAMETERS
    /// </summary>
    public class AuthorizeOnBillingAgreementRequest : DelegateRequest<AuthorizeOnBillingAgreementRequest>
    {
        private string amazon_billing_agreement_id;
        private decimal amount;
        private string currency_code;
        private string platform_id;
        private string seller_note;
        private string store_name;
        private string seller_order_id;
        private string custom_information;
        private bool inherit_shipping_address = true;
        private bool? capture_now;
        private string seller_authorization_note;
        private string authorization_reference_id;
        private string soft_descriptor;
        private int? transaction_timeout;

        public AuthorizeOnBillingAgreementRequest()
        {
            SetAction(Constants.AuthorizeOnBillingAgreement);
        }

        protected override AuthorizeOnBillingAgreementRequest GetThis()
        {
            return this;
        }

        /// <summary>
        /// Sets the Amazon Billing Agreement ID
        /// </summary>
        /// <param name="amazon_billing_agreement_id"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithAmazonBillingAgreementId(string amazon_billing_agreement_id)
        {
            this.amazon_billing_agreement_id = amazon_billing_agreement_id;
            return this;
        }
        
        /// <summary>
        /// gets the Amazon Billing Agreement ID
        /// </summary>
        /// <returns>Amazon Billing Agreement ID</returns>
        public string GetAmazonBillingAgreementId()
        {
            return this.amazon_billing_agreement_id;
        }

        /// <summary>
        /// Sets the Authorization Reference ID
        /// </summary>
        /// <param name="authorization_reference_id"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithAuthorizationReferenceId(string authorization_reference_id)
        {
            this.authorization_reference_id = authorization_reference_id;
            return this;
        }
        
        /// <summary>
        /// Gets the Authorization Reference ID
        /// </summary>
        /// <returns>Authorization Reference ID</returns>
        public string GetAuthorizationReferenceId()
        {
            return this.authorization_reference_id;
        }
        /// <summary>
        /// Sets the Amount
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithAmount(decimal amount)
        {
            this.amount = amount;
            return this;
        }
        
        /// <summary>
        /// Gets the Amount
        /// </summary>
        /// <returns>Amount</returns>
        public decimal GetAmount()
        {
            return this.amount;
        }

        /// <summary>
        /// Sets the Currency Code
        /// </summary>
        /// <param name="currency_code"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithCurrencyCode(Enum currency_code)
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
        /// Sets the Seller Authorization Note
        /// </summary>
        /// <param name="seller_authorization_note"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithSellerAuthorizationNote(string seller_authorization_note)
        {
            this.seller_authorization_note = seller_authorization_note;
            return this;
        }

        /// <summary>
        /// Gets the Seller Authorzation Note
        /// </summary>
        /// <returns>Seller Authorzation Note</returns>
        public string GetSellerAuthorizationNote()
        {
            return this.seller_authorization_note;
        }

        /// <summary>
        /// Sets the Transaction Timeout
        /// </summary>
        /// <param name="transaction_timeout"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithTransactionTimeout(int? transaction_timeout = null)
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
        /// Sets the Capture Now Boolean value.
        /// The accepted values are true, false and null.
        /// </summary>
        /// <param name="capture_now"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithCaptureNow(bool? capture_now)
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
        /// Sets the Soft Descriptor value
        /// </summary>
        /// <param name="soft_descriptor"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithSoftDescriptor(string soft_descriptor)
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

        /// <summary>
        /// Sets the Platform ID
        /// </summary>
        /// <param name="platform_id"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithPlatformId(string platform_id)
        {
            this.platform_id = platform_id;
            return this;
        }
        
        /// <summary>
        /// Gets the Platform ID
        /// </summary>
        /// <returns>Platform ID</returns>
        public string GetPlatformId()
        {
            return this.platform_id;
        }

        /// <summary>
        /// Sets the Seller Note
        /// </summary>
        /// <param name="seller_note"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithSellerNote(string seller_note)
        {
            this.seller_note = seller_note;
            return this;
        }

        /// <summary>
        /// Gets the Seller Note
        /// </summary>
        /// <returns>Seller Note</returns>
        public string GetSellerNote()
        {
            return this.seller_note;
        }

        /// <summary>
        /// Sets the Store Name
        /// </summary>
        /// <param name="store_name"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithStoreName(string store_name)
        {
            this.store_name = store_name;
            return this;
        }

        /// <summary>
        /// Gets the Store Name
        /// </summary>
        /// <returns>Store Name</returns>
        public string GetStoreName()
        {
            return this.store_name;
        }

        /// <summary>
        /// Sets the Seller Order ID
        /// </summary>
        /// <param name="seller_order_id"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithSellerOrderId(string seller_order_id)
        {
            this.seller_order_id = seller_order_id;
            return this;
        }

        /// <summary>
        /// Gets the Seller Order ID
        /// </summary>
        /// <returns>Seller Order ID</returns>
        public string GetSellerOrderId()
        {
            return this.seller_order_id;
        }

        /// <summary>
        /// Sets the Custom Information
        /// </summary>
        /// <param name="custom_information"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithCustomInformation(string custom_information)
        {
            this.custom_information = custom_information;
            return this;
        }

        /// <summary>
        /// Gets the Custom Information
        /// </summary>
        /// <returns>Custom Information</returns>
        public string GetCustomInformation()
        {
            return this.custom_information;
        }

        /// <summary>
        /// Sets the Inherit Shipping Address Boolean value
        /// </summary>
        /// <param name="inherit_shipping_address"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithInheritShippingAddress(bool inherit_shipping_address = true)
        {
            this.inherit_shipping_address = inherit_shipping_address;
            return this;
        }

        /// <summary>
        /// Gets the Inherit Shipping Address value
        /// </summary>
        /// <returns>Inherit Shipping Address</returns>
        public string GetInheritShippingAddress()
        {
            return this.inherit_shipping_address.ToString().ToLower();
        }
    }
}
