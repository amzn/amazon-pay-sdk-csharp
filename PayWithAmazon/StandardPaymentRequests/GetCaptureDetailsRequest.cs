using log4net;
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
        
        private string merchant_id;
        private string amazon_capture_id;
        private string mws_auth_token;
        private string action;
        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public GetCaptureDetailsRequest()
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Debug("METHOD__GetCaptureDetailsRequest Constructor | MESSAGE__Constructor Initiate");
            this.action = Constants.GetCaptureDetails;
            log.Debug("METHOD__GetCaptureDetailsRequest | MESSAGE__Action:" + this.action);
        }
        public string GetAction()
        {
            return this.action;
        }
        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>GetCaptureDetailsRequest Object</returns>
        public GetCaptureDetailsRequest WithMerchantId(string merchant_id)
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
        /// Sets the Amazon Capture ID
        /// </summary>
        /// <param name="amazon_capture_id"></param>
        /// <returns>GetCaptureDetailsRequest Object</returns>
        public GetCaptureDetailsRequest WithAmazonCaptureId(string amazon_capture_id)
        {
            this.amazon_capture_id = amazon_capture_id;
            log.Debug("METHOD__WithAmazonCaptureId | MESSAGE__amazon_capture_id:" + this.amazon_capture_id);
            return this;
        }
        public string GetAmazonCaptureId()
        {
            return this.amazon_capture_id;
        }
        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>GetCaptureDetailsRequest Object</returns>
        public GetCaptureDetailsRequest WithMWSAuthToken(string mws_auth_token)
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
