using System;

namespace AmazonPay.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the SetOrderReferenceDetails API call parameters
    /// </summary>
    public class SetOrderReferenceDetailsRequest : DelegateRequest<SetOrderReferenceDetailsRequest>
    {
        protected string amazon_order_reference_id;
        protected decimal? amount;
        protected string currency_code;
        protected string platform_id;
        protected string seller_note;
        protected string seller_order_id;
        protected string store_name;
        protected string custom_information;
        protected bool request_payment_authorization;
        protected string supplementary_data;

        public SetOrderReferenceDetailsRequest()
        {
            SetAction(Constants.SetOrderReferenceDetails);
        }

        protected override SetOrderReferenceDetailsRequest GetThis()
        {
            return this;
        }

        /// <summary>
        /// Sets the Amazon Order Reference ID
        /// </summary>
        /// <param name="amazon_order_reference_id"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithAmazonOrderReferenceId(string amazon_order_reference_id)
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
        /// Sets the Amount for the order
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithAmount(decimal? amount)
        {
            this.amount = amount;
            return this;
        }

        /// <summary>
        /// Gets the Amount for the order
        /// </summary>
        /// <returns>Amount</returns>
        public decimal? GetAmount()
        {
            return this.amount;
        }

        /// <summary>
        /// Sets the Currency Code
        /// </summary>
        /// <param name="currency_code"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithCurrencyCode(Enum currency_code)
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
        /// Sets the Platform ID
        /// </summary>
        /// <param name="platform_id"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithPlatformId(string platform_id)
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
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithSellerNote(string seller_note)
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
        /// Sets the Seller Order ID
        /// </summary>
        /// <param name="seller_order_id"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithSellerOrderId(string seller_order_id)
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
        /// Sets the Store Name
        /// </summary>
        /// <param name="store_name"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithStoreName(string store_name)
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
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithCustomInformation(string custom_information)
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
        /// Specifies if the merchants wants their buyers to go through
        /// multi-factor authentication
        /// </summary>
        /// <param name="request_payment_authorization"></param>
        /// <returns>SetOrderAttributesRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithRequestPaymentAuthorization(bool request_payment_authorization)
        {
            this.request_payment_authorization = request_payment_authorization;
            return this;
        }

        /// <summary>
        /// Gets the Request Payment Authorization boolean value
        /// </summary>
        /// <returns>Request Payment Authorization</returns>
        public bool GetRequestPaymentAuthorization()
        {
            return this.request_payment_authorization;
        }

        /// <summary>
        /// Sets the Supplementary Data
        /// </summary>
        /// <param name="supplementary_data"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithSupplementaryData(string supplementary_data)
        {
            this.supplementary_data = supplementary_data;
            return this;
        }

        /// <summary>
        /// Gets the Supplementary Data
        /// </summary>
        /// <returns>Supplementary Data</returns>
        public string GetSupplementaryData()
        {
            return this.supplementary_data;
        }
    }
}
