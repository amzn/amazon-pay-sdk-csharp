using System;
using System.Collections.Generic;

namespace AmazonPay.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the SetOrderAttributes API call parameters
    /// (extends the SetOrderReferenceDetailsRequest class)
    /// </summary>
    public class SetOrderAttributesRequest : DelegateRequest<SetOrderAttributesRequest>
    {
        private string amazon_order_reference_id;
        private decimal? amount;
        private string currency_code;
        private string platform_id;
        private string seller_note;
        private string seller_order_id;
        private string store_name;
        private string custom_information;
        private bool request_payment_authorization;
        private string payment_service_provider_id;
        private string payment_service_provider_order_id;
        private List<string> order_item_categories;

       public SetOrderAttributesRequest()
        {
            SetAction(Constants.SetOrderAttributes);
        }

       protected override SetOrderAttributesRequest GetThis()
       {
           return this;
       }

       /// <summary>
       /// Sets the Amazon Order Reference ID
       /// </summary>
       /// <param name="amazon_order_reference_id"></param>
       /// <returns>SetOrderAttributesRequest Object</returns>
       public SetOrderAttributesRequest WithAmazonOrderReferenceId(string amazon_order_reference_id)
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
       /// <returns>SetOrderAttributesRequest Object</returns>
       public SetOrderAttributesRequest WithAmount(decimal? amount)
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
       /// <returns>SetOrderAttributesRequest Object</returns>
       public SetOrderAttributesRequest WithCurrencyCode(Enum currency_code)
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
       /// <returns>SetOrderAttributesRequest Object</returns>
       public SetOrderAttributesRequest WithPlatformId(string platform_id)
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
       /// <returns>SetOrderAttributesRequest Object</returns>
       public SetOrderAttributesRequest WithSellerNote(string seller_note)
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
       /// <returns>SetOrderAttributesRequest Object</returns>
       public SetOrderAttributesRequest WithSellerOrderId(string seller_order_id)
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
       /// <returns>SetOrderAttributesRequest Object</returns>
       public SetOrderAttributesRequest WithStoreName(string store_name)
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
       /// <returns>SetOrderAttributesRequest Object</returns>
       public SetOrderAttributesRequest WithCustomInformation(string custom_information)
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
       public SetOrderAttributesRequest WithRequestPaymentAuthorization(bool request_payment_authorization)
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
        /// Sets the Payment Service Provider ID
        /// </summary>
        /// <param name="payment_service_provider_id"></param>
        /// <returns>SetOrderAttributesRequest Object</returns>
        public SetOrderAttributesRequest WithPaymentServiceProviderId(string payment_service_provider_id)
        {
            this.payment_service_provider_id = payment_service_provider_id;
            return this;
        }

        /// <summary>
        /// Gets the Payment Service Provider ID
        /// </summary>
        /// <returns>Payment Service Provider ID</returns>
        public string GetPaymentServiceProviderId()
        {
            return this.payment_service_provider_id;
        }

        /// <summary>
        /// Sets the Payment Service Provider Order ID
        /// </summary>
        /// <param name="payment_service_provider_order_id"></param>
        /// <returns>SetOrderAttributesRequest Object</returns>
        public SetOrderAttributesRequest WithPaymentServiceProviderOrderId(string payment_service_provider_order_id)
        {
            this.payment_service_provider_order_id = payment_service_provider_order_id;
            return this;
        }

        /// <summary>
        /// Gets the Payment Service Provider Order ID
        /// </summary>
        /// <returns>Payment Service Provider Order ID</returns>
        public string GetPaymentServiceProviderOrderId()
        {
            return this.payment_service_provider_order_id;
        }

        /// <summary>
        /// Sets the order item categories
        /// </summary>
        /// <param name="order_item_categories"></param>
        /// <returns>SetOrderAttributesRequest Object</returns>
        public SetOrderAttributesRequest WithOrderItemCategories(List<string> order_item_categories)
        {
            this.order_item_categories = order_item_categories;
            return this;
        }

        /// <summary>
        /// Gets the Order Item Categories
        /// </summary>
        /// <returns>Order Item Categories</returns>
        public List<string> GetOrderItemCategories()
        {
            return this.order_item_categories;
        }
    }
}

