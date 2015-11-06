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

        private string action;
        private string merchant_id;
        private string amazon_authorization_id;
        private decimal amount;
        private string currency_code;
        private string seller_capture_note;
        private string capture_reference_id;
        private string soft_descriptor;
        private string mws_auth_token;
        List<Dictionary<string, string>> providerCredit = new List<Dictionary<string, string>>();

        public CaptureRequest()
        {
            this.action = Constants.Capture;
        }
        public string GetAction()
        {
            return this.action;
        }
        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>CaptureRequest Object</returns>
        public CaptureRequest WithMerchantId(string merchant_id)
        {
            this.merchant_id = merchant_id;
            return this;
        }
        public string GetMerchantId()
        {
            return this.merchant_id;
        }
        /// <summary>
        /// Sets the Amazon Authorization ID
        /// </summary>
        /// <param name="amazon_authorization_id"></param>
        /// <returns>CaptureRequest Object</returns>
        public CaptureRequest WithAmazonAuthorizationId(string amazon_authorization_id)
        {
            this.amazon_authorization_id = amazon_authorization_id;
            return this;
        }
        public string GetAmazonAuthorizationId()
        {
            return this.amazon_authorization_id;
        }
        /// <summary>
        ///  Sets the Capture amount
        /// </summary>
        /// <param name="capture_amount"></param>
        /// <returns>CaptureRequest Object</returns>
        public CaptureRequest WithAmount(decimal capture_amount)
        {
            this.amount = capture_amount;
            return this;
        }
        public decimal GetAmount()
        {
            return this.amount;
        }
        /// <summary>
        ///  Sets the Capture Currency Code
        /// </summary>
        /// <param name="currency_code"></param>
        /// <returns>CaptureRequest Object</returns>
        public CaptureRequest WithCurrencyCode(Enum currency_code)
        {
            this.currency_code = currency_code.ToString();
            return this;
        }
        public string GetCurrencyCode()
        {
            return this.currency_code;
        }
        /// <summary>
        /// Sets the Capture Reference ID  - Unique string
        /// </summary>
        /// <param name="capture_reference_id"></param>
        /// <returns>CaptureRequest Object</returns>
        public CaptureRequest WithCaptureReferenceId(string capture_reference_id)
        {
            this.capture_reference_id = capture_reference_id;
            return this;
        }
        public string GetCaptureReferenceId()
        {
            return this.capture_reference_id;
        }

        /// <summary>
        /// Sets the Provider Credit Details
        /// </summary>
        /// <param name="provider_id"></param>
        /// <param name="amount"></param>
        /// <param name="currency_code"></param>
        /// <returns>CaptureRequest Object</returns>
        public CaptureRequest WithProviderCreditDetails(string provider_id, decimal amount, string currency_code)
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
            return this.providerCredit.AsReadOnly();
        }

        /// <summary>
        /// Sets the Seller Capture Note
        /// </summary>
        /// <param name="seller_capture_note"></param>
        /// <returns>CaptureRequest Object</returns>
        public CaptureRequest WithSellerCaptureNote(string seller_capture_note)
        {
            this.seller_capture_note = seller_capture_note;
            return this;

        }
        public string GetSellerCaptureNote()
        {
            return this.seller_capture_note;
        }
        /// <summary>
        /// Sets the Soft Descriptor
        /// </summary>
        /// <param name="soft_descriptor"></param>
        /// <returns>CaptureRequest Object</returns>
        public CaptureRequest WithSoftDescriptor(string soft_descriptor)
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
        /// <returns>CaptureRequest Object</returns>
        public CaptureRequest WithMWSAuthToken(string mws_auth_token)
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
