using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the Refund API call parameters
    /// </summary>
    public class RefundRequest
    {
        public Hashtable refundHashtable = new Hashtable();
        List<Hashtable> providerReverseCredit = new List<Hashtable>();

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>RefundRequest Object</returns>
        public RefundRequest WithMerchantId(string merchant_id)
        {
            refundHashtable["merchant_id"] = merchant_id;
            return this;
        }

        /// <summary>
        /// sets the Amazon Refund ID
        /// </summary>
        /// <param name="amazon_capture_id"></param>
        /// <returns>RefundRequest Object</returns>
        public RefundRequest WithAmazonCaptureId(string amazon_capture_id)
        {
            refundHashtable["amazon_capture_id"] = amazon_capture_id;
            return this;
        }

        /// <summary>
        /// Sets the Refund Amount
        /// </summary>
        /// <param name="refund_amount"></param>
        /// <returns>RefundRequest Object</returns>
        public RefundRequest WithAmount(string refund_amount)
        {
            refundHashtable["refund_amount"] = refund_amount;
            return this;
        }

        /// <summary>
        /// Sets the Currency Code
        /// </summary>
        /// <param name="currency_code"></param>
        /// <returns>RefundRequest Object</returns>
        public RefundRequest WithCurrencyCode(string currency_code)
        {
            refundHashtable["currency_code"] = currency_code;
            return this;
        }

        /// <summary>
        /// Sets the Refund Refrence ID - Unique string
        /// </summary>
        /// <param name="refund_reference_id"></param>
        /// <returns>RefundRequest Object</returns>
        public RefundRequest WithRefundReferenceId(string refund_reference_id)
        {
            refundHashtable["refund_reference_id"] = refund_reference_id;
            return this;
        }

        /// <summary>
        /// Sets the Provider Credit Reversal Details
        /// </summary>
        /// <param name="provider_id"></param>
        /// <param name="amount"></param>
        /// <param name="currency_code"></param>
        /// <returns>RefundRequest Object</returns>
        public RefundRequest WithProviderCreditReversalDetails(string provider_id, string amount, string currency_code)
        {
            Hashtable providerCreditDetails = new Hashtable();
            providerCreditDetails.Clear();
            providerCreditDetails["provider_id"] = provider_id;
            providerCreditDetails["credit_reversal_amount"] = amount;
            providerCreditDetails["currency_code"] = currency_code;

            providerReverseCredit.Add(providerCreditDetails);

            refundHashtable.Add("provider_credit_details", providerReverseCredit);
            return this;
        }

        /// <summary>
        /// Sets the Seller Refund Note
        /// </summary>
        /// <param name="seller_refund_note"></param>
        /// <returns>RefundRequest Object</returns>
        public RefundRequest WithSellerRefundNote(string seller_refund_note)
        {
            refundHashtable["seller_refund_note"] = seller_refund_note;
            return this;
        }

        /// <summary>
        /// Sets the Soft Descriptor
        /// </summary>
        /// <param name="soft_descriptor"></param>
        /// <returns>RefundRequest Object</returns>
        public RefundRequest WithSoftDescriptor(string soft_descriptor)
        {
            refundHashtable["soft_descriptor"] = soft_descriptor;
            return this;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>RefundRequest Object</returns>
        public RefundRequest WithMWSAuthToken(string mws_auth_token)
        {
            refundHashtable["mws_auth_token"] = mws_auth_token;
            return this;
        }
    }
}
