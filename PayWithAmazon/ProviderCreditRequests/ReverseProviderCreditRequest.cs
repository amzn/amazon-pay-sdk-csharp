using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.ProviderCreditRequests
{
    /// <summary>
    /// Request class to set the ReverseProviderCredit API call parameters
    /// </summary>
    public class ReverseProviderCreditRequest
    {
        public Hashtable reverseProviderCreditHashtable = new Hashtable();

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>ReverseProviderCreditRequest Object</returns>
        public ReverseProviderCreditRequest WithMerchantId(string merchant_id)
        {
            reverseProviderCreditHashtable["merchant_id"] = merchant_id;
            return this;
        }

        /// <summary>
        /// Sets the Amazon Provider Credit ID
        /// </summary>
        /// <param name="amazon_provider_credit_id"></param>
        /// <returns>ReverseProviderCreditRequest Object</returns>
        public ReverseProviderCreditRequest WithAmazonProviderCreditId(string amazon_provider_credit_id)
        {
            reverseProviderCreditHashtable["amazon_provider_credit_id"] = amazon_provider_credit_id;
            return this;
        }

        /// <summary>
        /// Sets the Credit Reversal Reference ID -  Unique string
        /// </summary>
        /// <param name="credit_reversal_reference_id"></param>
        /// <returns>ReverseProviderCreditRequest Object</returns>
        public ReverseProviderCreditRequest WithCreditReversalReferenceId(string credit_reversal_reference_id)
        {
            reverseProviderCreditHashtable["credit_reversal_reference_id"] = credit_reversal_reference_id;
            return this;
        }

        /// <summary>
        /// Sets the Amount for the reversal
        /// </summary>
        /// <param name="credit_reversal_amount"></param>
        /// <returns>ReverseProviderCreditRequest Object</returns>
        public ReverseProviderCreditRequest WithAmount(string credit_reversal_amount)
        {
            reverseProviderCreditHashtable["credit_reversal_amount"] = credit_reversal_amount;
            return this;
        }

        /// <summary>
        /// sets the Currency Code
        /// </summary>
        /// <param name="currency_code"></param>
        /// <returns>ReverseProviderCreditRequest Object</returns>
        public ReverseProviderCreditRequest WithCurrencyCode(string currency_code)
        {
            reverseProviderCreditHashtable["currency_code"] = currency_code;
            return this;
        }

        /// <summary>
        /// Sets the Credit Reversal Note
        /// </summary>
        /// <param name="credit_reversal_note"></param>
        /// <returns>ReverseProviderCreditRequest Object</returns>
        public ReverseProviderCreditRequest WithCreditReversalNote(string credit_reversal_note)
        {
            reverseProviderCreditHashtable["credit_reversal_note"] = credit_reversal_note;
            return this;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>ReverseProviderCreditRequest Object</returns>
        public ReverseProviderCreditRequest WithMWSAuthToken(string mws_auth_token)
        {
            reverseProviderCreditHashtable["mws_auth_token"] = mws_auth_token;
            return this;
        }
    }
}
