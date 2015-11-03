using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the CloseOrderReference API call parameters
    /// </summary>
    public class CloseOrderReferenceRequest
    {
        
        private string merchant_id;
        private string amazon_order_reference_id;
        private string closure_reason;
        private string mws_auth_token;
        private string action;
        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CloseOrderReferenceRequest()
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Debug("METHOD__CloseOrderReferenceRequest Constructor | MESSAGE__Constructor Initiate");
            this.action = Constants.CloseOrderReference;
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
        /// <returns>CloseOrderReferenceRequest Object</returns>
        public CloseOrderReferenceRequest WithMerchantId(string merchant_id)
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
        /// <returns>CloseOrderReferenceRequest Object</returns>
        public CloseOrderReferenceRequest WithAmazonOrderReferenceId(string amazon_order_reference_id)
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
        /// Sets the Closure reason
        /// </summary>
        /// <param name="closure_reason"></param>
        /// <returns>CloseOrderReferenceRequest Object</returns>
        public CloseOrderReferenceRequest WithClosureReason(string closure_reason)
        {
            this.closure_reason = closure_reason;
            log.Debug("METHOD__WithClosureReason | MESSAGE__closure_reason:" + this.closure_reason);
            return this;
        }
        public string GetClosureReason()
        {
            return this.closure_reason;
        }
        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>CloseOrderReferenceRequest Object</returns>
        public CloseOrderReferenceRequest WithMWSAuthToken(string mws_auth_token)
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
