using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AmazonPay.StandardPaymentRequests
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

        public GetRefundDetailsRequest()
        {
            this.action = Constants.GetRefundDetails;
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
            return this;
        }
        public string GetMWSAuthToken()
        {
            return this.mws_auth_token;
        }
    }
}
