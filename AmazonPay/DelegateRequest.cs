using System;
using System.Collections.Generic;
using System.Text;
using AmazonPay.StandardPaymentRequests;

namespace AmazonPay
{
    abstract public class DelegateRequest<T>
    {
        protected string action;
        protected string merchant_id;
        protected string mws_auth_token;

        protected abstract T GetThis();

        protected void SetAction(string action)
        {
            this.action = action;
        }

        /// <summary>
        /// Gets the action
        /// </summary>
        /// <returns>action</returns>
        public string GetAction()
        {
            return action;
        }
        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>Subclass Request Object</returns>
        public T WithMerchantId(string merchant_id)
        {
            this.merchant_id = merchant_id;
            return GetThis();
        }

        /// <summary>
        /// Gets the Merchant ID
        /// </summary>
        /// <returns>Merchant ID</returns>
        public string GetMerchantId()
        {
            return merchant_id;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>Subclass Request Object</returns>
        public T WithMWSAuthToken(string mws_auth_token)
        {
            this.mws_auth_token = mws_auth_token;
            return GetThis();
        }

        /// <summary>
        /// Gets the MWS AuthToken
        /// </summary>
        /// <returns>MWS AuthToken</returns>
        public string GetMWSAuthToken()
        {
            return mws_auth_token;
        }
    }
}
