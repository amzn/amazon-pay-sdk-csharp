using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.CommonRequests
{
    /// <summary>
    /// Set the GetServiceStatus API call parameters
    /// </summary>
    public class GetServiceStatusRequest
    {
        
        private string merchant_id;
        private string mws_auth_token;
        private string action;
        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public GetServiceStatusRequest()
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Debug("METHOD__ReverseProviderCreditRequest Constructor | MESSAGE__Constructor Initiate");
            this.action = Constants.GetServiceStatus;
            log.Debug("METHOD__ReverseProviderCreditRequest | MESSAGE__Action: " + this.action);
        }
        public string GetAction()
        {
            return this.action;
        }

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>GetServiceStatusRequest Object</returns>
        public GetServiceStatusRequest WithMerchantId(string merchant_id)
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
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>GetServiceStatusRequest Object</returns>
        public GetServiceStatusRequest WithMWSAuthToken(string mws_auth_token)
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
