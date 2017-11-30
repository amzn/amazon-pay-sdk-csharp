using System;
using System.Collections.Generic;

namespace AmazonPay.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the SetOrderAttributes API call parameters
    /// (extends the SetOrderReferenceDetailsRequest class)
    /// </summary>
    public class SetOrderAttributesRequest : SetOrderReferenceDetailsRequest
    {
        private string payment_service_provider_id;
        private string payment_service_provider_order_id;
        private List<string> order_item_categories;

       public SetOrderAttributesRequest()
        {
            this.action = Constants.SetOrderAttributes;
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
        public List<string> GetOrderItemCategories()
        {
            return this.order_item_categories;
        }
    }
}

