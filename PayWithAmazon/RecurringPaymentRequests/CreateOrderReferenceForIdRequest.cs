using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.RecurringPaymentRequests
{
    /// <summary>
    /// Request class to set the CreateOrderReferenceForId API call parameters
    /// </summary>
    public class CreateOrderReferenceForIdRequest
    {
        public Hashtable createOrderReferenceForIdHashtable = new Hashtable();

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>CreateOrderReferenceForIdRequest Object</returns>
        public CreateOrderReferenceForIdRequest WithMerchantId(string merchant_id)
        {
            createOrderReferenceForIdHashtable["merchant_id"] = merchant_id;
            return this;
        }

        /// <summary>
        /// Sets the Amazon Billing Agreement ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns>CreateOrderReferenceForIdRequest Object</returns>
        public CreateOrderReferenceForIdRequest WithId(string id)
        {
            createOrderReferenceForIdHashtable["id"] = id;
            return this;
        }

        /// <summary>
        /// Sets the ID Type
        /// </summary>
        /// <param name="id_type"></param>
        /// <returns>CreateOrderReferenceForIdRequest Object</returns>
        public CreateOrderReferenceForIdRequest WithIdType(string id_type)
        {
            createOrderReferenceForIdHashtable["id_type"] = id_type;
            return this;
        }

        /// <summary>
        /// Sets the Inherit Shipping Address Boolean value
        /// </summary>
        /// <param name="inherit_shipping_address"></param>
        /// <returns>CreateOrderReferenceForIdRequest Object</returns>
        public CreateOrderReferenceForIdRequest WithInheritShippingAddress(Boolean inherit_shipping_address)
        {
            createOrderReferenceForIdHashtable["inherit_shipping_address"] = inherit_shipping_address;
            return this;
        }

        /// <summary>
        /// Sets the Confirm Now Boolean value
        /// </summary>
        /// <param name="confirm_now"></param>
        /// <returns>CreateOrderReferenceForIdRequest Object</returns>
        public CreateOrderReferenceForIdRequest WithConfirmNow(Boolean confirm_now)
        {
            createOrderReferenceForIdHashtable["confirm_now"] = confirm_now;
            return this;
        }

        /// <summary>
        /// Sets the Amount
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public CreateOrderReferenceForIdRequest WithAmount(string amount)
        {
            createOrderReferenceForIdHashtable["amount"] = amount;
            return this;
        }

        /// <summary>
        /// Sets the Currency Code
        /// </summary>
        /// <param name="currency_code"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public CreateOrderReferenceForIdRequest WithCurrencyCode(string currency_code)
        {
            createOrderReferenceForIdHashtable["currency_code"] = currency_code;
            return this;
        }

        /// <summary>
        /// Sets the Platform ID
        /// </summary>
        /// <param name="platform_id"></param>
        /// <returns>CreateOrderReferenceForIdRequest Object</returns>
        public CreateOrderReferenceForIdRequest WithPlatformId(string platform_id)
        {
            createOrderReferenceForIdHashtable["platform_id"] = platform_id;
            return this;
        }

        /// <summary>
        /// Sets the Seller Note
        /// </summary>
        /// <param name="seller_note"></param>
        /// <returns>CreateOrderReferenceForIdRequest Object</returns>
        public CreateOrderReferenceForIdRequest WithSellerNote(string seller_note)
        {
            createOrderReferenceForIdHashtable["seller_note"] = seller_note;
            return this;
        }

        /// <summary>
        /// Sets the Seller Order ID
        /// </summary>
        /// <param name="seller_order_id"></param>
        /// <returns>CreateOrderReferenceForIdRequest Object</returns>
        public CreateOrderReferenceForIdRequest WithSellerOrderId(string seller_order_id)
        {
            createOrderReferenceForIdHashtable["seller_order_id"] = seller_order_id;
            return this;
        }

        /// <summary>
        /// Sets the Store Name
        /// </summary>
        /// <param name="store_name"></param>
        /// <returns>CreateOrderReferenceForIdRequest Object</returns>
        public CreateOrderReferenceForIdRequest WithStoreName(string store_name)
        {
            createOrderReferenceForIdHashtable["store_name"] = store_name;
            return this;
        }

        /// <summary>
        /// Sets the Custom Information
        /// </summary>
        /// <param name="custom_information"></param>
        /// <returns>CreateOrderReferenceForIdRequest Object</returns>
        public CreateOrderReferenceForIdRequest WithCustomInformation(string custom_information)
        {
            createOrderReferenceForIdHashtable["custom_information"] = custom_information;
            return this;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>CreateOrderReferenceForIdRequest Object</returns>
        public CreateOrderReferenceForIdRequest WithMWSAuthToken(string mws_auth_token)
        {
            createOrderReferenceForIdHashtable["mws_auth_token"] = mws_auth_token;
            return this;
        }
    }
}
