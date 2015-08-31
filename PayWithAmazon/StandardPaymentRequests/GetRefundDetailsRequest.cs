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
        public Hashtable getRefundDetailsHashtable = new Hashtable();

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>GetRefundDetailsRequest Object</returns>
        public GetRefundDetailsRequest WithMerchantId(string merchant_id)
        {
            getRefundDetailsHashtable["merchant_id"] = merchant_id;
            return this;
        }

        /// <summary>
        /// Sets the Amazon Refund ID
        /// </summary>
        /// <param name="amazon_refund_id"></param>
        /// <returns>GetRefundDetailsRequest Object</returns>
        public GetRefundDetailsRequest WithAmazonRefundId(string amazon_refund_id)
        {
            getRefundDetailsHashtable["amazon_refund_id"] = amazon_refund_id;
            return this;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>GetRefundDetailsRequest Object</returns>
        public GetRefundDetailsRequest WithMWSAuthToken(string mws_auth_token)
        {
            getRefundDetailsHashtable["mws_auth_token"] = mws_auth_token;
            return this;
        }
    }
}
