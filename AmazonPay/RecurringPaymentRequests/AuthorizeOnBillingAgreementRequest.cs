﻿using System;

namespace AmazonPay.RecurringPaymentRequests
{
    /// <summary>
    /// Request class to set the AuthorizeOnBillingAgreement API call PARAMETERS
    /// </summary>
    public class AuthorizeOnBillingAgreementRequest
    {
        private readonly string action;
        private string merchant_id;
        private string amazon_billing_agreement_id;
        private decimal amount;
        private string currency_code;
        private string platform_id;
        private string seller_note;
        private string store_name;
        private string seller_order_id;
        private string custom_information;
        private bool inherit_shipping_address = true;
        private bool? capture_now;
        private string seller_authorization_note;
        private string authorization_reference_id;
        private string soft_descriptor;
        private int? transaction_timeout;
        private string mws_auth_token;


        public AuthorizeOnBillingAgreementRequest()
        {
            action = Constants.AuthorizeOnBillingAgreement;
        }
        public string GetAction()
        {
            return action;
        }

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithMerchantId(string merchant_id)
        {
            this.merchant_id = merchant_id;

            return this;
        }
        public string GetMerchantId()
        {
            return merchant_id;
        }

        /// <summary>
        /// Sets the Amazon Billing Agreement ID
        /// </summary>
        /// <param name="amazon_billing_agreement_id"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithAmazonBillingAgreementId(string amazon_billing_agreement_id)
        {
            this.amazon_billing_agreement_id = amazon_billing_agreement_id;
            return this;
        }
        public string GetAmazonBillingAgreementId()
        {
            return amazon_billing_agreement_id;
        }

        /// <summary>
        /// Sets the Amazon Billing Agreement ID
        /// </summary>
        /// <param name="authorization_reference_id"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithAuthorizationReferenceId(string authorization_reference_id)
        {
            this.authorization_reference_id = authorization_reference_id;
            return this;
        }
        public string GetAuthorizationReferenceId()
        {
            return authorization_reference_id;
        }
        /// <summary>
        /// Sets the Amount
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithAmount(decimal amount)
        {
            this.amount = amount;
            return this;
        }
        public decimal GetAmount()
        {
            return amount;
        }
        /// <summary>
        /// Sets the Currency Code
        /// </summary>
        /// <param name="currency_code"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithCurrencyCode(Enum currency_code)
        {
            this.currency_code = currency_code.ToString();

            return this;
        }
        public string GetCurrencyCode()
        {
            return currency_code;
        }

        /// <summary>
        /// Sets the Seller Authorization Note
        /// </summary>
        /// <param name="seller_authorization_note"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithSellerAuthorizationNote(string seller_authorization_note)
        {
            this.seller_authorization_note = seller_authorization_note;
            return this;
        }
        public string GetSellerAuthorizationNote()
        {
            return seller_authorization_note;
        }

        /// <summary>
        /// Sets the Transaction Timeout
        /// </summary>
        /// <param name="transaction_timeout"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithTransactionTimeout(int? transaction_timeout = null)
        {
            this.transaction_timeout = transaction_timeout;
            return this;
        }
        public int? GetTransactionTimeout()
        {
            return transaction_timeout;
        }

        /// <summary>
        /// Sets the Capture Now Boolean value.
        /// The accepted values are true, false and null.
        /// </summary>
        /// <param name="capture_now"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithCaptureNow(bool? capture_now)
        {
            this.capture_now = capture_now;
            return this;
        }
        public string GetCaptureNow()
        {
            return capture_now.ToString().ToLower();
        }

        /// <summary>
        /// Sets the Soft Descriptor value
        /// </summary>
        /// <param name="soft_descriptor"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithSoftDescriptor(string soft_descriptor)
        {
            this.soft_descriptor = soft_descriptor;
            return this;
        }
        public string GetSoftDescriptor()
        {
            return soft_descriptor;
        }

        /// <summary>
        /// Sets the Platform ID
        /// </summary>
        /// <param name="platform_id"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithPlatformId(string platform_id)
        {
            this.platform_id = platform_id;
            return this;
        }
        public string GetPlatformId()
        {
            return platform_id;
        }

        /// <summary>
        /// Sets the Seller Note
        /// </summary>
        /// <param name="seller_note"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithSellerNote(string seller_note)
        {
            this.seller_note = seller_note;
            return this;
        }
        public string GetSellerNote()
        {
            return seller_note;
        }
        /// <summary>
        /// Sets the Store Name
        /// </summary>
        /// <param name="store_name"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithStoreName(string store_name)
        {
            this.store_name = store_name;
            return this;
        }
        public string GetStoreName()
        {
            return store_name;
        }
        /// <summary>
        /// Sets the Seller Order ID
        /// </summary>
        /// <param name="seller_order_id"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithSellerOrderId(string seller_order_id)
        {
            this.seller_order_id = seller_order_id;
            return this;
        }
        public string GetSellerOrderId()
        {
            return seller_order_id;
        }
        /// <summary>
        /// Sets the Custom Information
        /// </summary>
        /// <param name="custom_information"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithCustomInformation(string custom_information)
        {
            this.custom_information = custom_information;
            return this;
        }
        public string GetCustomInformation()
        {
            return custom_information;
        }

        /// <summary>
        /// Sets the Inherit Shipping Address Boolean value
        /// </summary>
        /// <param name="inherit_shipping_address"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithInheritShippingAddress(bool inherit_shipping_address = true)
        {
            this.inherit_shipping_address = inherit_shipping_address;
            return this;
        }
        public string GetInheritShippingAddress()
        {
            return inherit_shipping_address.ToString().ToLower();
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>AuthorizeOnBillingAgreementRequest Object</returns>
        public AuthorizeOnBillingAgreementRequest WithMWSAuthToken(string mws_auth_token)
        {
            this.mws_auth_token = mws_auth_token;
            return this;
        }
        public string GetMWSAuthToken()
        {
            return mws_auth_token;
        }
    }
}
