using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the Capture API call parameters
    /// </summary>
    public class CaptureRequest
    {
        public Hashtable captureHashtable = new Hashtable();
        List<Hashtable> providerCredit = new List<Hashtable>();

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>CaptureRequest Object</returns>
        public CaptureRequest WithMerchantId(string merchant_id)
        {
            captureHashtable["merchant_id"] = merchant_id;
            return this;
        }

        /// <summary>
        /// Sets the Amazon Authorization ID
        /// </summary>
        /// <param name="amazon_authorization_id"></param>
        /// <returns>CaptureRequest Object</returns>
        public CaptureRequest WithAmazonAuthorizationId(string amazon_authorization_id)
        {
            captureHashtable["amazon_authorization_id"] = amazon_authorization_id;
            return this;
        }

        /// <summary>
        ///  Sets the Capture amount
        /// </summary>
        /// <param name="capture_amount"></param>
        /// <returns>CaptureRequest Object</returns>
        public CaptureRequest WithAmount(string capture_amount)
        {
            captureHashtable["capture_amount"] = capture_amount;
            return this;
        }

        /// <summary>
        ///  Sets the Capture Currency Code
        /// </summary>
        /// <param name="currency_code"></param>
        /// <returns>CaptureRequest Object</returns>
        public CaptureRequest WithCurrencyCode(string currency_code)
        {
            captureHashtable["currency_code"] = currency_code;
            return this;
        }

        /// <summary>
        /// Sets the Capture Reference ID  - Unique string
        /// </summary>
        /// <param name="capture_reference_id"></param>
        /// <returns>CaptureRequest Object</returns>
        public CaptureRequest WithCaptureReferenceId(string capture_reference_id)
        {
            captureHashtable["capture_reference_id"] = capture_reference_id;
            return this;
        }

        /// <summary>
        /// Sets the Provider Credit Details
        /// </summary>
        /// <param name="provider_id"></param>
        /// <param name="amount"></param>
        /// <param name="currency_code"></param>
        /// <returns>CaptureRequest Object</returns>
        public CaptureRequest WithProviderCreditDetails(string provider_id, string amount, string currency_code)
        {
            Hashtable providerCreditDetails = new Hashtable();
            providerCreditDetails.Clear();
            providerCreditDetails["provider_id"] = provider_id;
            providerCreditDetails["credit_amount"] = amount;
            providerCreditDetails["currency_code"] = currency_code;

            providerCredit.Add(providerCreditDetails);

            captureHashtable["provider_credit_details"] = providerCredit;
            return this;
        }

        /// <summary>
        /// Sets the Seller Capture Note
        /// </summary>
        /// <param name="seller_capture_note"></param>
        /// <returns>CaptureRequest Object</returns>
        public CaptureRequest WithSellerCaptureNote(string seller_capture_note)
        {
            captureHashtable["seller_capture_note"] = seller_capture_note;
            return this;
        }

        /// <summary>
        /// Sets the Soft Descriptor
        /// </summary>
        /// <param name="soft_descriptor"></param>
        /// <returns>CaptureRequest Object</returns>
        public CaptureRequest WithSoftDescriptor(string soft_descriptor)
        {
            captureHashtable["soft_descriptor"] = soft_descriptor;
            return this;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>CaptureRequest Object</returns>
        public CaptureRequest WithMWSAuthToken(string mws_auth_token)
        {
            captureHashtable["mws_auth_token"] = mws_auth_token;
            return this;
        }
    }
}
