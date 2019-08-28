using AmazonPay.Types;

namespace AmazonPay.RecurringPaymentRequests
{
    /// <summary>
    /// Request class to set the SetBillingAgreementDetails API call parameters
    /// </summary>
    public class SetBillingAgreementDetailsRequest : DelegateRequest<SetBillingAgreementDetailsRequest>
    {
        private string amazon_billing_agreement_id;
        private string platform_id;
        private string seller_note;
        private string seller_order_id;
        private string seller_billing_agreement_id;
        private string store_name;
        private string custom_information;
        private BillingAgreementTypes? billing_agreement_type;
        private decimal? subscription_amount;
        private Regions.currencyCode? subscription_currency_code;

        public SetBillingAgreementDetailsRequest()
        {
            SetAction(Constants.SetBillingAgreementDetails);
        }

        protected override SetBillingAgreementDetailsRequest GetThis()
        {
            return this;
        }

        /// <summary>
        /// Sets the Amazon Billing Agreement ID
        /// </summary>
        /// <param name="amazon_billing_agreement_id"></param>
        /// <returns>SetBillingAgreementDetailsRequest Object</returns>
        public SetBillingAgreementDetailsRequest WithAmazonBillingAgreementId(string amazon_billing_agreement_id)
        {
            this.amazon_billing_agreement_id = amazon_billing_agreement_id;
            return this;
        }

        /// <summary>
        /// Gets the Amazon Billing Agreement ID
        /// </summary>
        /// <returns>Amazon Billing Agreement ID</returns>
        public string GetAmazonBillingAgreementId()
        {
            return this.amazon_billing_agreement_id;
        }

        /// <summary>
        /// Sets the Seller Order ID
        /// </summary>
        /// <param name="amazon_billing_agreement_id"></param>
        /// <returns>SetBillingAgreementDetailsRequest Object</returns>
        public SetBillingAgreementDetailsRequest WithSellerOrderId(string seller_order_id)
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
        /// Sets the Platform ID
        /// </summary>
        /// <param name="platform_id"></param>
        /// <returns>SetBillingAgreementDetailsRequest Object</returns>
        public SetBillingAgreementDetailsRequest WithPlatformId(string platform_id)
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
        /// <returns>SetBillingAgreementDetailsRequest Object</returns>
        public SetBillingAgreementDetailsRequest WithSellerNote(string seller_note)
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
        /// Sets the Seller Billing Agreement ID
        /// </summary>
        /// <param name="seller_billing_agreement_id"></param>
        /// <returns>SetBillingAgreementDetailsRequest Object</returns>
        public SetBillingAgreementDetailsRequest WithSellerBillingAgreementId(string seller_billing_agreement_id)
        {
            this.seller_billing_agreement_id = seller_billing_agreement_id;
            return this;
        }

        /// <summary>
        /// Gets the Seller Billing Agreement ID
        /// </summary>
        /// <returns>Seller Billing Agreement ID</returns>
        public string GetSellerBillingAgreementId()
        {
            return this.seller_billing_agreement_id;
        }

        /// <summary>
        /// Sets the Store Name
        /// </summary>
        /// <param name="store_name"></param>
        /// <returns>SetBillingAgreementDetailsRequest Object</returns>
        public SetBillingAgreementDetailsRequest WithStoreName(string store_name)
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
        /// Sets the Custom Information
        /// </summary>
        /// <param name="custom_information"></param>
        /// <returns>SetBillingAgreementDetailsRequest Object</returns>
        public SetBillingAgreementDetailsRequest WithCustomInformation(string custom_information)
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
        /// Sets the Billing Agreement Type
        /// </summary>
        /// <param name="billing_agreement_type"></param>
        /// <returns>SetBillingAgreementDetailsRequest Object</returns>
        public SetBillingAgreementDetailsRequest WithBillingAgreementType(BillingAgreementTypes billing_agreement_type)
        {
            this.billing_agreement_type = billing_agreement_type;
            return this;
        }

        /// <summary>
        /// Gets the Billing Agreement Type
        /// </summary>
        /// <returns>Billing Agreement Type</returns>
        public BillingAgreementTypes? GetBillingAgreementType()
        {
            return this.billing_agreement_type;
        }

        /// <summary>
        /// Sets the Subscription Amount
        /// </summary>
        /// <param name="subscription_amount"></param>
        /// <returns>SetBillingAgreementDetailsRequest Object</returns>
        public SetBillingAgreementDetailsRequest WithSubscriptionAmount(decimal subscription_amount)
        {
            this.subscription_amount = subscription_amount;
            return this;
        }

        /// <summary>
        /// Gets the Subscription Amount
        /// </summary>
        /// <returns>Subscription Amount</returns>
        public decimal? GetSubscriptionAmount()
        {
            return this.subscription_amount;
        }

        /// <summary>
        /// Sets the Subscription Currency Code
        /// </summary>
        /// <param name="currency_code"></param>
        /// <returns>SetBillingAgreementDetailsRequest Object</returns>
        public SetBillingAgreementDetailsRequest WithSubscriptionCurrencyCode(Regions.currencyCode? currency_code)
        {
            this.subscription_currency_code = currency_code;
            return this;
        }

        /// <summary>
        /// Gets the Subscription Currency Code
        /// </summary>
        /// <returns>Currency Code</returns>
        public Regions.currencyCode? GetSubscriptionCurrencyCode()
        {
            return this.subscription_currency_code;
        }
    }
}
