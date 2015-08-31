using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the SetOrderReferenceDetails API call parameters
    /// </summary>
    public class SetOrderReferenceDetailsRequest
    {
        public Hashtable setOrderReferenceDetailsHashtable = new Hashtable();

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithMerchantId(string merchant_id)
        {
            setOrderReferenceDetailsHashtable["merchant_id"] = merchant_id;
            return this;
        }

        /// <summary>
        /// Sets the Amazon Order Reference ID
        /// </summary>
        /// <param name="amazon_order_reference_id"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithAmazonOrderReferenceId(string amazon_order_reference_id)
        {
            setOrderReferenceDetailsHashtable["amazon_order_reference_id"] = amazon_order_reference_id;
            return this;
        }

        /// <summary>
        /// Sets the Amount for the order
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithAmount(string amount)
        {
            setOrderReferenceDetailsHashtable["amount"] = amount;
            return this;
        }

        /// <summary>
        /// Sets the Currency Code
        /// </summary>
        /// <param name="currency_code"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithCurrencyCode(string currency_code)
        {
            setOrderReferenceDetailsHashtable["currency_code"] = currency_code;
            return this;
        }

        /// <summary>
        /// Sets the Platform ID
        /// </summary>
        /// <param name="platform_id"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithPlatformId(string platform_id)
        {
            setOrderReferenceDetailsHashtable["platform_id"] = platform_id;
            return this;
        }

        /// <summary>
        /// Sets the Seller Note
        /// </summary>
        /// <param name="seller_note"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithSellerNote(string seller_note)
        {
            setOrderReferenceDetailsHashtable["seller_note"] = seller_note;
            return this;
        }

        /// <summary>
        /// Sets the Seller Order ID
        /// </summary>
        /// <param name="seller_order_id"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithSellerOrderId(string seller_order_id)
        {
            setOrderReferenceDetailsHashtable["seller_order_id"] = seller_order_id;
            return this;
        }

        /// <summary>
        /// Sets the Store Name
        /// </summary>
        /// <param name="store_name"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithStoreName(string store_name)
        {
            setOrderReferenceDetailsHashtable["store_name"] = store_name;
            return this;
        }

        /// <summary>
        /// Sets the Custom Information
        /// </summary>
        /// <param name="custom_information"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithCustomInformation(string custom_information)
        {
            setOrderReferenceDetailsHashtable["custom_information"] = custom_information;
            return this;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithMWSAuthToken(string mws_auth_token)
        {
            setOrderReferenceDetailsHashtable["mws_auth_token"] = mws_auth_token;
            return this;
        }
    }
}
