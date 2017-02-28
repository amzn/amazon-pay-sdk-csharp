using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AmazonPay.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the Refund API call parameters
    /// </summary>
    public class RefundRequest
    {
        private string action;
        private string merchant_id;
        private string amazon_capture_id;
        private decimal amount;
        private string currency_code;
        private string seller_refund_note;
        private string refund_reference_id;
        private string soft_descriptor;
        private string mws_auth_token;
        List<Dictionary<string, string>> providerReverseCredit = new List<Dictionary<string, string>>();

        public RefundRequest()
        {
            this.action = Constants.Refund;
        }
        public string GetAction()
        {
            return this.action;
        }
        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>RefundRequest Object</returns>
        public RefundRequest WithMerchantId(string merchant_id)
        {
            this.merchant_id = merchant_id;
            return this;
        }
        public string GetMerchantId()
        {
            return this.merchant_id;
        }

        /// <summary>
        /// sets the Amazon Refund ID
        /// </summary>
        /// <param name="amazon_capture_id"></param>
        /// <returns>RefundRequest Object</returns>
        public RefundRequest WithAmazonCaptureId(string amazon_capture_id)
        {
            this.amazon_capture_id = amazon_capture_id;
            return this;
        }
        public string GetAmazonCaptureId()
        {
            return this.amazon_capture_id;
        }

        /// <summary>
        /// Sets the Refund Amount
        /// </summary>
        /// <param name="refund_amount"></param>
        /// <returns>RefundRequest Object</returns>
        public RefundRequest WithAmount(decimal refund_amount)
        {
            this.amount = refund_amount;
            return this;
        }
        public decimal GetAmount()
        {
            return this.amount;
        }

        /// <summary>
        /// Sets the Currency Code
        /// </summary>
        /// <param name="currency_code"></param>
        /// <returns>RefundRequest Object</returns>
        public RefundRequest WithCurrencyCode(Enum currency_code)
        {
            this.currency_code = currency_code.ToString();
            return this;
        }
        public string GetCurrencyCode()
        {
            return this.currency_code;
        }

        /// <summary>
        /// Sets the Refund Refrence ID - Unique string
        /// </summary>
        /// <param name="refund_reference_id"></param>
        /// <returns>RefundRequest Object</returns>
        public RefundRequest WithRefundReferenceId(string refund_reference_id)
        {
            this.refund_reference_id = refund_reference_id;
            return this;
        }
        public string GetRefundReferenceId()
        {
            return this.refund_reference_id;
        }

        /// <summary>
        /// Sets the Provider Credit Reversal Details
        /// </summary>
        /// <param name="provider_id"></param>
        /// <param name="amount"></param>
        /// <param name="currency_code"></param>
        /// <returns>RefundRequest Object</returns>
        public RefundRequest WithProviderCreditReversalDetails(string provider_id, decimal amount, string currency_code)
        {
            Dictionary<string, string> providerCreditDetails = new Dictionary<string, string>();
            providerCreditDetails.Clear();
            providerCreditDetails[Constants.ProviderId] = provider_id;
            providerCreditDetails[Constants.CreditReversalAmount_Amount] = amount.ToString();
            providerCreditDetails[Constants.CreditReversalAmount_CurrencyCode] = currency_code.ToUpper();

            providerReverseCredit.Add(providerCreditDetails);
            return this;
        }
        public IList<Dictionary<string, string>> GetProviderReverseCredit()
        {
            return this.providerReverseCredit.AsReadOnly();
        }

        /// <summary>
        /// Sets the Seller Refund Note
        /// </summary>
        /// <param name="seller_refund_note"></param>
        /// <returns>RefundRequest Object</returns>
        public RefundRequest WithSellerRefundNote(string seller_refund_note)
        {
            this.seller_refund_note = seller_refund_note;
            return this;
        }
        public string GetSellerRefundNote()
        {
            return this.seller_refund_note;
        }

        /// <summary>
        /// Sets the Soft Descriptor
        /// </summary>
        /// <param name="soft_descriptor"></param>
        /// <returns>RefundRequest Object</returns>
        public RefundRequest WithSoftDescriptor(string soft_descriptor)
        {
            this.soft_descriptor = soft_descriptor;
            return this;
        }
        public string GetSoftDescriptor()
        {
            return this.soft_descriptor;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>RefundRequest Object</returns>
        public RefundRequest WithMWSAuthToken(string mws_auth_token)
        {
            this.mws_auth_token = mws_auth_token;
            return this;
        }
        public string GetMWSAuthToken()
        {
            return this.mws_auth_token;
        }
    }
}
