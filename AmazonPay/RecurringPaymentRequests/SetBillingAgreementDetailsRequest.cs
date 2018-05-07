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
    }
}
