using System;

namespace AmazonPay.ProviderCreditRequests
{
    /// <summary>
    /// Request class to set the ReverseProviderCredit API call parameters
    /// </summary>
    public class ReverseProviderCreditRequest : DelegateRequest<ReverseProviderCreditRequest>
    {
        private string amazon_provider_credit_id;
        private string credit_reversal_reference_id;
        private decimal amount;
        private string currency_code;
        private string credit_reversal_note;

        public ReverseProviderCreditRequest()
        {
            SetAction(Constants.ReverseProviderCredit);
        }

        protected override ReverseProviderCreditRequest GetThis()
        {
            return this;
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
        
        /// <summary>
        /// Gets the Amazon Provider Credit ID
        /// </summary>
        /// <returns>Amazon Provider Credit ID</returns>
        public string GetAmazonProviderCreditId()
        {
            return this.amazon_provider_credit_id;
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
        
        /// <summary>
        /// Gets the Credit Reversal Reference ID
        /// </summary>
        /// <returns>Credit Reversal Reference ID</returns>
        public string GetCreditReversalReferenceId()
        {
            return this.credit_reversal_reference_id;
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

        /// <summary>
        /// Gets the amount for reversal
        /// </summary>
        /// <returns>amount</returns>
        public decimal GetAmount()
        {
            return this.amount;
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
            return this.currency_code;
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
            return this.credit_reversal_note;
        }
    }
}
