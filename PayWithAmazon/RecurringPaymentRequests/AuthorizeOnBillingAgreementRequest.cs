using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.RecurringPaymentRequests
{
    /// <summary>
    /// Request class to set the AuthorizeOnBillingAgreement API call PARAMETERS
    /// </summary>
    public class AuthorizeOnBillingAgreementRequest
    {
        public Hashtable authorizeOnBillingAgreementHashtable = new Hashtable();

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithMerchantId(string merchant_id)
        {
            authorizeOnBillingAgreementHashtable["merchant_id"] =  merchant_id;
            return this;
        }

        /// <summary>
        /// Sets the Amazon Billing Agreement ID
        /// </summary>
        /// <param name="amazon_billing_agreement_id"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithAmazonBillingAgreementId(string amazon_billing_agreement_id)
        {
            authorizeOnBillingAgreementHashtable["amazon_billing_agreement_id"] =  amazon_billing_agreement_id;
            return this;
        }

        /// <summary>
        /// Sets the Amazon Billing Agreement ID
        /// </summary>
        /// <param name="authorization_reference_id"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithAuthorizationReferenceId(string authorization_reference_id)
        {
            authorizeOnBillingAgreementHashtable["authorization_reference_id"] =  authorization_reference_id;
            return this;
        }

        /// <summary>
        /// Sets the Amount
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithAmount(string amount)
        {
            authorizeOnBillingAgreementHashtable["authorization_amount"] =  amount;
            return this;
        }
        
        /// <summary>
        /// Sets the Currency Code
        /// </summary>
        /// <param name="currency_code"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithCurrencyCode(string currency_code)
        {
            authorizeOnBillingAgreementHashtable["currency_code"] =  currency_code;
            return this;
        }

        /// <summary>
        /// Sets the Seller Authorization Note
        /// </summary>
        /// <param name="seller_authorization_note"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithSellerAuthorizationNote(string seller_authorization_note)
        {
            authorizeOnBillingAgreementHashtable["seller_authorization_note"] =  seller_authorization_note;
            return this;
        }

        /// <summary>
        /// Sets the Transaction Timeout
        /// </summary>
        /// <param name="transaction_timeout"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithTransactionTimeout(int transaction_timeout)
        {
            authorizeOnBillingAgreementHashtable["transaction_timeout"] =  transaction_timeout;
            return this;
        }

        /// <summary>
        /// Sets the Capture Now Boolean value
        /// </summary>
        /// <param name="capture_now"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithCaptureNow(Boolean capture_now = false)
        {
            authorizeOnBillingAgreementHashtable["capture_now"] =  capture_now;
            return this;
        }

        /// <summary>
        /// Sets the Soft Descriptor value
        /// </summary>
        /// <param name="soft_descriptor"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithSoftDescriptor(string soft_descriptor)
        {
            authorizeOnBillingAgreementHashtable["soft_descriptor"] =  soft_descriptor;
            return this;
        }

        /// <summary>
        /// Sets the Platform ID
        /// </summary>
        /// <param name="platform_id"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithPlatformId(string platform_id)
        {
            authorizeOnBillingAgreementHashtable["platform_id"] =  platform_id;
            return this;
        }

        /// <summary>
        /// Sets the Seller Note
        /// </summary>
        /// <param name="seller_note"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithSellerNote(string seller_note)
        {
            authorizeOnBillingAgreementHashtable["seller_note"] =  seller_note;
            return this;
        }

        /// <summary>
        /// Sets the Store Name
        /// </summary>
        /// <param name="store_name"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithStoreName(string store_name)
        {
            authorizeOnBillingAgreementHashtable["store_name"] =  store_name;
            return this;
        }

        /// <summary>
        /// Sets the Seller Order ID
        /// </summary>
        /// <param name="seller_order_id"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithSellerOrderId(string seller_order_id)
        {
            authorizeOnBillingAgreementHashtable["seller_order_id"] =  seller_order_id;
            return this;
        }

        /// <summary>
        /// Sets the Custom Information
        /// </summary>
        /// <param name="custom_information"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithCustomInformation(string custom_information)
        {
            authorizeOnBillingAgreementHashtable["custom_information"] =  custom_information;
            return this;
        }

        /// <summary>
        /// Sets the Inherit Shipping Address Boolean value
        /// </summary>
        /// <param name="inherit_shipping_address"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithInheritShippingAddress(Boolean inherit_shipping_address = false)
        {
            authorizeOnBillingAgreementHashtable["inherit_shipping_address"] =  inherit_shipping_address;
            return this;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithMWSAuthToken(string mws_auth_token)
        {
            authorizeOnBillingAgreementHashtable["mws_auth_token"] =  mws_auth_token;
            return this;
        }
    }
}
