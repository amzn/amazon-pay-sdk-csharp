﻿using System;
using System.Collections.Generic;

namespace AmazonPay.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the Autorize API call parameters
    /// </summary>
    public class AuthorizeRequest
    {
        private readonly string action;
        private string merchant_id;
        private string amazon_order_reference_id;
        private decimal amount;
        private string currency_code;
        private bool? capture_now;
        private string seller_authorization_note;
        private string authorization_reference_id;
        private string soft_descriptor;
        private int? transaction_timeout;
        private string mws_auth_token;
        readonly List<Dictionary<string, string>> providerCredit = new List<Dictionary<string, string>>();


        public AuthorizeRequest()
        {
            action = Constants.Authorize;
        }
        public string GetAction()
        {
            return action;
        }
        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>Merchant ID</returns>
        public AuthorizeRequest WithMerchantId(string merchant_id)
        {
            this.merchant_id = merchant_id;
            return this;
        }
        public string GetMerchantId()
        {
            return merchant_id;
        }

        /// <summary>
        /// Sets the Amazo Order Reference ID
        /// </summary>
        /// <param name="amazon_order_reference_id"></param>
        /// <returns>Amazon Order Reference Id </returns>
        public AuthorizeRequest WithAmazonOrderReferenceId(string amazon_order_reference_id)
        {
            this.amazon_order_reference_id = amazon_order_reference_id;
            return this;
        }
        public string GetAmazonOrderReferenceId()
        {
            return amazon_order_reference_id;
        }

        /// <summary>
        /// Sets the Amount for the order
        /// </summary>
        /// <param name="authorization_amount"></param>
        /// <returns>Amount</returns>
        public AuthorizeRequest WithAmount(decimal authorization_amount)
        {
            amount = authorization_amount;
            return this;
        }
        public decimal GetAmount()
        {
            return amount;
        }

        /// <summary>
        /// Sets the Currency Code for the Amount
        /// </summary>
        /// <param name="currency_code"></param>
        /// <returns>AuthorizeRequest Object</returns>
        public AuthorizeRequest WithCurrencyCode(Enum currency_code)
        {
            this.currency_code = currency_code.ToString();
            return this;
        }
        public string GetCurrencyCode()
        {
            return currency_code;
        }

        /// <summary>
        /// Sets the Authorization Reference ID - Unique string
        /// </summary>
        /// <param name="authorization_reference_id"></param>
        /// <returns>AuthorizeRequest Object</returns>
        public AuthorizeRequest WithAuthorizationReferenceId(string authorization_reference_id)
        {
            this.authorization_reference_id = authorization_reference_id;
            return this;
        }
        public string GetAuthorizationReferenceId()
        {
            return authorization_reference_id;
        }
        /// <summary>
        /// Sets the Boolean value for the Capture Now.
        /// The accepted values are true, false and null.
        /// </summary>
        /// <param name="capture_now"></param>
        /// <returns>AuthorizeRequest Object</returns>
        public AuthorizeRequest WithCaptureNow(bool? capture_now)
        {
            this.capture_now = capture_now;
            return this;
        }
        public string GetCaptureNow()
        {
            return capture_now.ToString().ToLower();
        }

        /// <summary>
        /// Sets the Provider Credit Details
        /// </summary>
        /// <param name="provider_id"></param>
        /// <param name="amount"></param>
        /// <param name="currency_code"></param>
        /// <returns>AuthorizeRequest Object</returns>
        public AuthorizeRequest WithProviderCreditDetails(string provider_id, decimal amount, string currency_code)
        {
            Dictionary<string, string> providerCreditDetails = new Dictionary<string, string>();
            providerCreditDetails.Clear();
            providerCreditDetails[Constants.ProviderId] = provider_id;
            providerCreditDetails[Constants.CreditAmount_Amount] = amount.ToString();
            providerCreditDetails[Constants.CreditAmount_CurrencyCode] = currency_code.ToUpper();

            providerCredit.Add(providerCreditDetails);
            return this;
        }

        public IList<Dictionary<string, string>> GetProviderCreditDetails()
        {
            return providerCredit;
        }

        /// <summary>
        /// Sets the Seller Authorization Note
        /// </summary>
        /// <param name="seller_authorization_note"></param>
        /// <returns>AuthorizeRequest Object</returns>
        public AuthorizeRequest WithSellerAuthorizationNote(string seller_authorization_note)
        {
            this.seller_authorization_note = seller_authorization_note;
            return this;
        }
        public string GetSellerAuthorizationNote()
        {
            return seller_authorization_note;
        }

        /// <summary>
        /// Sets the Transaction Timeout value
        /// </summary>
        /// <param name="transaction_timeout"></param>
        /// <returns>AuthorizeRequest Object</returns>
        public AuthorizeRequest WithTransactionTimeout(int? transaction_timeout = null)
        {
            this.transaction_timeout = transaction_timeout;
            return this;
        }
        public int? GetTransactionTimeout()
        {
            return transaction_timeout;
        }

        /// <summary>
        /// Sets the Soft Descriptor
        /// </summary>
        /// <param name="soft_descriptor"></param>
        /// <returns>AuthorizeRequest Object</returns>
        public AuthorizeRequest WithSoftDescriptor(string soft_descriptor)
        {
            this.soft_descriptor = soft_descriptor;
            return this;
        }
        public string GetSoftDescriptor()
        {
            return soft_descriptor;
        }

        /// <summary>
        /// Sets the MWS AuthToken
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>AuthorizeRequest Object</returns>
        public AuthorizeRequest WithMWSAuthToken(string mws_auth_token)
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
