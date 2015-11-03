using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the CloseAuthorization API call parameters
    /// </summary>
    public class CloseAuthorizationRequest
    {
        
        private string merchant_id;
        private string amazon_authorization_id;
        private string closure_reason;
        private string mws_auth_token;
        private string action;
        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CloseAuthorizationRequest()
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Debug("METHOD__CloseAuthorizationRequest Constructor | MESSAGE__Constructor Initiate");
            this.action = Constants.CloseAuthorization;
            log.Debug("METHOD__CloseAuthorizationRequest | MESSAGE__Action:" + this.action);
        }
        public string GetAction()
        {
            return this.action;
        }
        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>CloseAuthorizationRequest Object</returns>
        public CloseAuthorizationRequest WithMerchantId(string merchant_id)
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
        /// Sets the Amazon Authorization ID
        /// </summary>
        /// <param name="amazon_authorization_id"></param>
        /// <returns>CloseAuthorizationRequest Object</returns>
        public CloseAuthorizationRequest WithAmazonAuthorizationId(string amazon_authorization_id)
        {
            this.amazon_authorization_id = amazon_authorization_id;
            log.Debug("METHOD__WithAmazonAuthorizationId | MESSAGE__amazon_authorization_id:" + this.amazon_authorization_id);
            return this;
        }
        public string GetAmazonAuthorizationId()
        {
            return this.amazon_authorization_id;
        }

        /// <summary>
        /// Sets the Closure Reason
        /// </summary>
        /// <param name="closure_reason"></param>
        /// <returns>CloseAuthorizationRequest Object</returns>
        public CloseAuthorizationRequest WithClosureReason(string closure_reason)
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
        /// <returns>CloseAuthorizationRequest Object</returns>
        public CloseAuthorizationRequest WithMWSAuthToken(string mws_auth_token)
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
