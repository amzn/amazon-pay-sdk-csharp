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

        public GetServiceStatusRequest()
        {
            this.action = Constants.GetServiceStatus;
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
            return this;
        }
        public string GetMWSAuthToken()
        {
            return this.mws_auth_token;
        }
    }
}
