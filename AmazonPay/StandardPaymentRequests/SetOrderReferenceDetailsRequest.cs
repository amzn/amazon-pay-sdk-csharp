using System;

namespace AmazonPay.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the SetOrderReferenceDetails API call parameters
    /// </summary>
    public class SetOrderReferenceDetailsRequest
    {
        protected string action;
        protected string merchant_id;
        protected string amazon_order_reference_id;
        protected decimal? amount;
        protected string currency_code;
        protected string platform_id;
        protected string seller_note;
        protected string seller_order_id;
        protected string store_name;
        protected string custom_information;
        protected bool request_payment_authorization;
        protected string mws_auth_token;
        

        public SetOrderReferenceDetailsRequest()
        {
            this.action = Constants.SetOrderReferenceDetails;
        }
        public string GetAction()
        {
            return this.action;
        }
        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithMerchantId(string merchant_id)
        {
            this.merchant_id = merchant_id;
            
            return this;
        }
        public string GetMerchantId()
        {
            return this.merchant_id;
        }

        /// <summary>
        /// Sets the Amazon Order Reference ID
        /// </summary>
        /// <param name="amazon_order_reference_id"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithAmazonOrderReferenceId(string amazon_order_reference_id)
        {
            this.amazon_order_reference_id = amazon_order_reference_id;
            return this;
        }

        public string GetAmazonOrderReferenceId()
        {
            return this.amazon_order_reference_id;
        }
        /// <summary>
        /// Sets the Amount for the order
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithAmount(decimal? amount)
        {
            this.amount = amount;
            return this;
        }

        public decimal? GetAmount()
        {
            return this.amount;
        }

        /// <summary>
        /// Sets the Currency Code
        /// </summary>
        /// <param name="currency_code"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithCurrencyCode(Enum currency_code)
        {
            this.currency_code = currency_code.ToString();
            return this;
        }

        public string GetCurrencyCode()
        {
            return this.currency_code;
        }

        /// <summary>
        /// Sets the Platform ID
        /// </summary>
        /// <param name="platform_id"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithPlatformId(string platform_id)
        {
            this.platform_id = platform_id;
            return this;
        }
        public string GetPlatformId()
        {
            return this.platform_id;
        }

        /// <summary>
        /// Sets the Seller Note
        /// </summary>
        /// <param name="seller_note"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithSellerNote(string seller_note)
        {
            this.seller_note = seller_note;
            return this;
        }
        public string GetSellerNote()
        {
            return this.seller_note;
        }
        /// <summary>
        /// Sets the Seller Order ID
        /// </summary>
        /// <param name="seller_order_id"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithSellerOrderId(string seller_order_id)
        {
            this.seller_order_id = seller_order_id;
            return this;
        }
        public string GetSellerOrderId()
        {
            return this.seller_order_id;
        }

        /// <summary>
        /// Sets the Store Name
        /// </summary>
        /// <param name="store_name"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithStoreName(string store_name)
        {
            this.store_name = store_name;
            return this;
        }
        public string GetStoreName()
        {
            return this.store_name;
        }

        /// <summary>
        /// Sets the Custom Information
        /// </summary>
        /// <param name="custom_information"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithCustomInformation(string custom_information)
        {
            this.custom_information = custom_information;
            return this;
        }
        public string GetCustomInformation()
        {
            return this.custom_information;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithMWSAuthToken(string mws_auth_token)
        {
            this.mws_auth_token = mws_auth_token;
            return this;
        }
        public string GetMWSAuthToken()
        {
            return this.mws_auth_token;
        }

        /// <summary>
        /// Specifies if the merchants wants their buyers to go through
        /// multi-factor authentication
        /// </summary>
        /// <param name="request_payment_authorization"></param>
        /// <returns>SetOrderAttributesRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithRequestPaymentAuthorization(bool request_payment_authorization)
        {
            this.request_payment_authorization = request_payment_authorization;
            return this;
        }
        public bool GetRequestPaymentAuthorization()
        {
            return this.request_payment_authorization;
        }
    }
}
