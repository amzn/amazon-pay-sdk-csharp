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
        public Hashtable getServiceStatusRequestHashtable = new Hashtable();

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>GetServiceStatusRequest Object</returns>
        public GetServiceStatusRequest WithMerchantId(string merchant_id)
        {
            getServiceStatusRequestHashtable["merchant_id"] = merchant_id;
            return this;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>GetServiceStatusRequest Object</returns>
        public GetServiceStatusRequest WithMWSAuthToken(string mws_auth_token)
        {
            getServiceStatusRequestHashtable["mws_auth_token"] = mws_auth_token;
            return this;
        }
    }
}
