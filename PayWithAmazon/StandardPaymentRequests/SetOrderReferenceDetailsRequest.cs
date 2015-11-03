using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the SetOrderReferenceDetails API call parameters
    /// </summary>
    public class SetOrderReferenceDetailsRequest
    {
        
        private string action;
        private string merchant_id;
        private string amazon_order_reference_id;
        private decimal amount;
        private string currency_code;
        private string platform_id;
        private string seller_note;
        private string seller_order_id;
        private string store_name;
        private string custom_information;
        private string mws_auth_token;
        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public SetOrderReferenceDetailsRequest()
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Debug("METHOD__SetOrderReferenceDetailsRequest Constructor | MESSAGE__Constructor Initiate");
            this.action = Constants.SetOrderReferenceDetails;
            log.Debug("METHOD__SetOrderReferenceDetailsRequest | MESSAGE__Action: " + this.action);
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
            log.Debug("METHOD__WithMerchantId | MESSAGE__merchant_id: " + this.merchant_id);
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
            log.Debug("METHOD__WithAmazonOrderReferenceId | MESSAGE__amazon_order_reference_id: " + this.amazon_order_reference_id);
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
        public SetOrderReferenceDetailsRequest WithAmount(decimal amount)
        {
            this.amount = amount;
            log.Debug("METHOD__WithAmount | MESSAGE__amount: " + this.amount);
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
        /// <returns>SetOrderReferenceDetailsRequest Object</returns>
        public SetOrderReferenceDetailsRequest WithCurrencyCode(string currency_code)
        {
            this.currency_code = currency_code.ToUpper();
            log.Debug("METHOD__WithCurrencyCode | MESSAGE__currency_code: " + this.currency_code);
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
            log.Debug("METHOD__WithPlatformId | MESSAGE__platform_id: " + this.platform_id);
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
            log.Debug("METHOD__WithSellerNote | MESSAGE__seller_note: " + this.seller_note);
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
            log.Debug("METHOD__WithSellerOrderId | MESSAGE__seller_order_id: " + this.seller_order_id);
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
            log.Debug("METHOD__WithStoreName | MESSAGE__store_name: " + this.store_name);
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
            log.Debug("METHOD__WithCustomInformation | MESSAGE__custom_information: " + this.custom_information);
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
            log.Debug("METHOD__WithMWSAuthToken | MESSAGE__mws_auth_token: " + this.mws_auth_token);
            return this;
        }
        public string GetMWSAuthToken()
        {
            return this.mws_auth_token;
        }
    }
}
