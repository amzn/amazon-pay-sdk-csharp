using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the GetAuthorizationDetails API call parameters
    /// </summary>
    public class GetAuthorizationDetailsRequest
    {
        
        private string merchant_id;
        private string amazon_authorization_id;
        private string mws_auth_token;
        private string action;
        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public GetAuthorizationDetailsRequest()
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Debug("PayWithAmazon_GetAuthorizationDetailsRequest | METHOD__GetAuthorizationDetailsRequest Constructor | MESSAGE__Constructor Initiate");
            this.action = Constants.GetAuthorizationDetails;
            log.Debug("PayWithAmazon_GetAuthorizationDetailsRequest | METHOD__GetAuthorizationDetailsRequest | MESSAGE__Action:" + this.action);
        }
        public string GetAction()
        {
            return this.action;
        }

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>GetAuthorizationDetailsRequest Object</returns>
        public GetAuthorizationDetailsRequest WithMerchantId(string merchant_id)
        {
            this.merchant_id = merchant_id;
            log.Debug("PayWithAmazon_GetAuthorizationDetailsRequest | METHOD__WithMerchantId | MESSAGE__merchant_id:" + this.merchant_id);
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
        /// <returns>GetAuthorizationDetailsRequest Object</returns>
        public GetAuthorizationDetailsRequest WithAmazonAuthorizationId(string amazon_authorization_id)
        {
            this.amazon_authorization_id = amazon_authorization_id;
            log.Debug("PayWithAmazon_GetAuthorizationDetailsRequest | METHOD__WithAmazonAuthorizationId | MESSAGE__amazon_authorization_id:" + this.amazon_authorization_id);
            return this;
        }
        public string GetAmazonAuthorizationId()
        {
            return this.amazon_authorization_id;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>GetAuthorizationDetailsRequest Object</returns>
        public GetAuthorizationDetailsRequest WithMWSAuthToken(string mws_auth_token)
        {
            this.mws_auth_token = mws_auth_token;
            log.Debug("PayWithAmazon_GetAuthorizationDetailsRequest | METHOD__WithMWSAuthToken | MESSAGE__mws_auth_token:" + this.mws_auth_token);
            return this;
        }
        public string GetMWSAuthToken()
        {
            return this.mws_auth_token;
        }
    }
}
