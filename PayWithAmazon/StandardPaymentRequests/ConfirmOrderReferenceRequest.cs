using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the ConfirmOrderReference API call parameters
    /// </summary>
    public class ConfirmOrderReferenceRequest
    {
        private string action;
        private string amazon_order_reference_id;
        private string merchant_id;
        private string mws_auth_token;
        
        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public ConfirmOrderReferenceRequest()
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Debug("METHOD__ConfirmOrderReferenceRequest Constructor | MESSAGE__Constructor Initiate");
            this.action = Constants.ConfirmOrderReference;
            log.Debug("METHOD__CloseOrderReferenceRequest | MESSAGE__Action:" + this.action);
        }
        public string GetAction()
        {
            return this.action;
        }
        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>ConfirmOrderReferenceRequest Object</returns>
        public ConfirmOrderReferenceRequest WithMerchantId(string merchant_id)
        {
            this.merchant_id = merchant_id;
            log.Debug("METHOD__WithMerchantId | MESSAGE__merchant_id:" + this.merchant_id);
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
        /// <returns>ConfirmOrderReferenceRequest Object</returns>
        public ConfirmOrderReferenceRequest WithAmazonOrderReferenceId(string amazon_order_reference_id)
        {
            this.amazon_order_reference_id = amazon_order_reference_id;
            log.Debug("METHOD__WithAmazonOrderReferenceId | MESSAGE__amazon_order_reference_id:" + this.amazon_order_reference_id);
            return this;
        }
        public string GetAmazonOrderReferenceId()
        {
            return this.amazon_order_reference_id;
        }
        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>ConfirmOrderReferenceRequest Object</returns>
        public ConfirmOrderReferenceRequest WithMWSAuthToken(string mws_auth_token)
        {
            this.mws_auth_token = mws_auth_token;
            log.Debug("METHOD__WithMWSAuthToken | MESSAGE__mws_auth_token:" + this.mws_auth_token);
            return this;
        }

        public string GetMWSAuthToken()
        {
            return this.mws_auth_token;
        }
    }
}
