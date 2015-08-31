using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the GetCaptureDetails API call parameters
    /// </summary>
    public class GetCaptureDetailsRequest
    {
        public Hashtable getCaptureDetailsHashtable = new Hashtable();

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>GetCaptureDetailsRequest Object</returns>
        public GetCaptureDetailsRequest WithMerchantId(string merchant_id)
        {
            getCaptureDetailsHashtable["merchant_id"] = merchant_id;
            return this;
        }

        /// <summary>
        /// Sets the Amazon Capture ID
        /// </summary>
        /// <param name="amazon_capture_id"></param>
        /// <returns>GetCaptureDetailsRequest Object</returns>
        public GetCaptureDetailsRequest WithAmazonCaptureId(string amazon_capture_id)
        {
            getCaptureDetailsHashtable["amazon_capture_id"] = amazon_capture_id;
            return this;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>GetCaptureDetailsRequest Object</returns>
        public GetCaptureDetailsRequest WithMWSAuthToken(string mws_auth_token)
        {
            getCaptureDetailsHashtable["mws_auth_token"] = mws_auth_token;
            return this;
        }
    }
}
