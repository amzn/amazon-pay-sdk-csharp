using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the Autorize API call parameters
    /// </summary>
    public class AuthorizeRequest
    {
        public Hashtable authorizeHashtable = new Hashtable();
        List<Hashtable> providerCredit = new List<Hashtable>();

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>AuthorizeRequest Object</returns>
        public AuthorizeRequest WithMerchantId(string merchant_id)
        {
            authorizeHashtable["merchant_id"] = merchant_id;
            return this;
        }

        /// <summary>
        /// Sets the Amazo Order Reference ID
        /// </summary>
        /// <param name="amazon_order_reference_id"></param>
        /// <returns>AuthorizeRequest Object</returns>
        public AuthorizeRequest WithAmazonOrderReferenceId(string amazon_order_reference_id)
        {
            authorizeHashtable["amazon_order_reference_id"] = amazon_order_reference_id;
            return this;
        }

        /// <summary>
        /// Sets the Amount for the order
        /// </summary>
        /// <param name="authorization_amount"></param>
        /// <returns>AuthorizeRequest Object</returns>
        public AuthorizeRequest WithAmount(string authorization_amount)
        {
            authorizeHashtable["authorization_amount"] = authorization_amount;
            return this;
        }

        /// <summary>
        /// Sets the Currency Code for the Amount
        /// </summary>
        /// <param name="currency_code"></param>
        /// <returns>AuthorizeRequest Object</returns>
        public AuthorizeRequest WithCurrencyCode(string currency_code)
        {
            authorizeHashtable["currency_code"] = currency_code;
            return this;
        }

        /// <summary>
        /// Sets the Authorization Reference ID - Unique string
        /// </summary>
        /// <param name="authorization_reference_id"></param>
        /// <returns>AuthorizeRequest Object</returns>
        public AuthorizeRequest WithAuthorizationReferenceId(string authorization_reference_id)
        {
            authorizeHashtable["authorization_reference_id"] = authorization_reference_id;
            return this;
        }

        /// <summary>
        /// Sets the Boolean value for the Capture Now
        /// </summary>
        /// <param name="capture_now"></param>
        /// <returns>AuthorizeRequest Object</returns>
        public AuthorizeRequest WithCaptureNow(Boolean capture_now = false)
        {
            authorizeHashtable["capture_now"] = capture_now;
            return this;
        }

        /// <summary>
        /// Sets the Provider Credit Details
        /// </summary>
        /// <param name="provider_id"></param>
        /// <param name="amount"></param>
        /// <param name="currency_code"></param>
        /// <returns>AuthorizeRequest Object</returns>
        public AuthorizeRequest WithProviderCreditDetails(string provider_id, string amount, string currency_code)
        {
            Hashtable providerCreditDetails = new Hashtable();
            providerCreditDetails.Clear();
            providerCreditDetails["provider_id"] = provider_id;
            providerCreditDetails["credit_amount"] = amount;
            providerCreditDetails["currency_code"] = currency_code;

            providerCredit.Add(providerCreditDetails);

            authorizeHashtable["provider_credit_details"] = providerCredit;
            return this;
        }

        /// <summary>
        /// Sets the Seller Authorization Note
        /// </summary>
        /// <param name="seller_authorization_note"></param>
        /// <returns>AuthorizeRequest Object</returns>
        public AuthorizeRequest WithSellerAuthorizationNote(string seller_authorization_note)
        {
            authorizeHashtable["seller_authorization_note"] = seller_authorization_note;
            return this;
        }

        /// <summary>
        /// Sets the Transaction Timeout value
        /// </summary>
        /// <param name="transaction_timeout"></param>
        /// <returns>AuthorizeRequest Object</returns>
        public AuthorizeRequest WithTransactionTimeout(int transaction_timeout)
        {
            authorizeHashtable["transaction_timeout"] = transaction_timeout;
            return this;
        }

        /// <summary>
        /// Sets the Soft Descriptor
        /// </summary>
        /// <param name="soft_descriptor"></param>
        /// <returns>AuthorizeRequest Object</returns>
        public AuthorizeRequest WithSoftDescriptor(string soft_descriptor)
        {
            authorizeHashtable["soft_descriptor"] = soft_descriptor;
            return this;
        }

        /// <summary>
        /// Sets the MWS AuthToken
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>AuthorizeRequest Object</returns>
        public AuthorizeRequest WithMWSAuthToken(string mws_auth_token)
        {
            authorizeHashtable["mws_auth_token"] = mws_auth_token;
            return this;
        }
    }
}
