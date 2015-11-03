using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the GetRefundDetails API call parameters
    /// </summary>
    public class GetRefundDetailsRequest
    {
        
        private string action;
        private string merchant_id;
        private string amazon_refund_id;
        private string mws_auth_token;
        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public GetRefundDetailsRequest()
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Debug("METHOD__GetRefundDetailsRequest Constructor | MESSAGE__Constructor Initiate");
            this.action = Constants.GetRefundDetails;
            log.Debug("METHOD__GetRefundDetailsRequest | MESSAGE__Action:" + this.action);
        }
        public string GetAction()
        {
            return this.action;
        }
        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>GetRefundDetailsRequest Object</returns>
        public GetRefundDetailsRequest WithMerchantId(string merchant_id)
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
        /// Sets the Amazon Refund ID
        /// </summary>
        /// <param name="amazon_refund_id"></param>
        /// <returns>GetRefundDetailsRequest Object</returns>
        public GetRefundDetailsRequest WithAmazonRefundId(string amazon_refund_id)
        {
            this.amazon_refund_id = amazon_refund_id;
            log.Debug("METHOD__WithAmazonRefundId | MESSAGE__amazon_refund_id:" + this.amazon_refund_id);
            return this;
        }
        public string GetAmazonRefundId()
        {
            return this.amazon_refund_id;
        }
        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>GetRefundDetailsRequest Object</returns>
        public GetRefundDetailsRequest WithMWSAuthToken(string mws_auth_token)
        {
            this.mws_auth_token = mws_auth_token;
            log.Debug("METHOD_WithMWSAuthToken | MESSAGE__mws_auth_token:" + this.mws_auth_token);
            return this;
        }
        public string GetMWSAuthToken()
        {
            return this.mws_auth_token;
        }
    }
}
