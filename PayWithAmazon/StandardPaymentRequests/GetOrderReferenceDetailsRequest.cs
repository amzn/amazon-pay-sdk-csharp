using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the GetOrderReferenceDetails API call parameters
    /// </summary>
    public class GetOrderReferenceDetailsRequest
    {
        public Hashtable getOrderReferenceDetailsHashtable = new Hashtable();

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>GetOrderReferenceDetailsRequest Object</returns>
        public GetOrderReferenceDetailsRequest WithMerchantId(string merchant_id)
        {
            getOrderReferenceDetailsHashtable["merchant_id"] = merchant_id;
            return this;
        }

        /// <summary>
        /// Sets the Amazon Order Reference ID
        /// </summary>
        /// <param name="amazon_order_reference_id"></param>
        /// <returns>GetOrderReferenceDetailsRequest Object</returns>
        public GetOrderReferenceDetailsRequest WithAmazonOrderReferenceId(string amazon_order_reference_id)
        {
            getOrderReferenceDetailsHashtable["amazon_order_reference_id"] = amazon_order_reference_id;
            return this;
        }

        /// <summary>
        /// Sets the Address Consent Token
        /// </summary>
        /// <param name="address_consent_token"></param>
        /// <returns>GetOrderReferenceDetailsRequest Object</returns>
        public GetOrderReferenceDetailsRequest WithaddressConsentToken(string address_consent_token)
        {
            getOrderReferenceDetailsHashtable["address_consent_token"] = address_consent_token;
            return this;
        }

        /// <summary>
        /// Sets the MWS Auth Tokenh
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>GetOrderReferenceDetailsRequest Object</returns>
        public GetOrderReferenceDetailsRequest WithMWSAuthToken(string mws_auth_token)
        {
            getOrderReferenceDetailsHashtable["mws_auth_token"] = mws_auth_token;
            return this;
        }

    }
}
