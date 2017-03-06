﻿using System;

namespace AmazonPay.ProviderCreditRequests
{
    /// <summary>
    /// Request class to set the ReverseProviderCredit API call parameters
    /// </summary>
    public class ReverseProviderCreditRequest
    {
        private readonly string action;
        private string merchant_id;
        private string amazon_provider_credit_id;
        private string credit_reversal_reference_id;
        private decimal amount;
        private string currency_code;
        private string credit_reversal_note;
        private string mws_auth_token;

        public ReverseProviderCreditRequest()
        {
            action = Constants.ReverseProviderCredit;
        }
        public string GetAction()
        {
            return action;
        }

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>ReverseProviderCreditRequest Object</returns>
        public ReverseProviderCreditRequest WithMerchantId(string merchant_id)
        {
            this.merchant_id = merchant_id;
            return this;
        }
        public string GetMerchantId()
        {
            return merchant_id;
        }

        /// <summary>
        /// Sets the Amazon Provider Credit ID
        /// </summary>
        /// <param name="amazon_provider_credit_id"></param>
        /// <returns>ReverseProviderCreditRequest Object</returns>
        public ReverseProviderCreditRequest WithAmazonProviderCreditId(string amazon_provider_credit_id)
        {
            this.amazon_provider_credit_id = amazon_provider_credit_id;
            return this;
        }
        public string GetAmazonProviderCreditId()
        {
            return amazon_provider_credit_id;
        }

        /// <summary>
        /// Sets the Credit Reversal Reference ID -  Unique string
        /// </summary>
        /// <param name="credit_reversal_reference_id"></param>
        /// <returns>ReverseProviderCreditRequest Object</returns>
        public ReverseProviderCreditRequest WithCreditReversalReferenceId(string credit_reversal_reference_id)
        {
            this.credit_reversal_reference_id = credit_reversal_reference_id;
            return this;
        }
        public string GetCreditReversalReferenceId()
        {
            return credit_reversal_reference_id;
        }

        /// <summary>
        /// Sets the Amount for the reversal
        /// </summary>
        /// <param name="credit_reversal_amount"></param>
        /// <returns>ReverseProviderCreditRequest Object</returns>
        public ReverseProviderCreditRequest WithAmount(decimal amount)
        {
            this.amount = amount;
            return this;
        }
        public decimal GetAmount()
        {
            return amount;
        }

        /// <summary>
        /// sets the Currency Code
        /// </summary>
        /// <param name="currency_code"></param>
        /// <returns>ReverseProviderCreditRequest Object</returns>
        public ReverseProviderCreditRequest WithCurrencyCode(Enum currency_code)
        {
            this.currency_code = currency_code.ToString();
            return this;
        }
        public string GetCurrencyCode()
        {
            return currency_code;
        }

        /// <summary>
        /// Sets the Credit Reversal Note
        /// </summary>
        /// <param name="credit_reversal_note"></param>
        /// <returns>ReverseProviderCreditRequest Object</returns>
        public ReverseProviderCreditRequest WithCreditReversalNote(string credit_reversal_note)
        {
            this.credit_reversal_note = credit_reversal_note;
            return this;
        }
        public string GetCreditReversalNote()
        {
            return credit_reversal_note;
        }
        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>ReverseProviderCreditRequest Object</returns>
        public ReverseProviderCreditRequest WithMWSAuthToken(string mws_auth_token)
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
