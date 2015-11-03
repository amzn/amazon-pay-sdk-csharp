using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the GetOrderReferenceDetails API call parameters
    /// </summary>
    public class GetOrderReferenceDetailsRequest
    {
        
        private string merchant_id;
        private string amazon_order_reference_id;
        private string address_consent_token;
        private string mws_auth_token;
        private string action;
        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// <summary>
        /// Constructor sets the Action variable for the MWS request
        /// </summary>
        public GetOrderReferenceDetailsRequest()
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Debug("METHOD__GetOrderReferenceDetailsRequest Constructor | MESSAGE__Constructor Initiate");
            
            this.action = Constants.GetOrderReferenceDetails;
            log.Debug("METHOD__GetOrderReferenceDetailsRequest Constructor | MESSAGE__Action:" + this.action);
        }

        public string GetAction()
        {
            return this.action;
        }
        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>GetOrderReferenceDetailsRequest Object</returns>
        public GetOrderReferenceDetailsRequest WithMerchantId(string merchant_id)
        {
            this.merchant_id = merchant_id;
            log.Debug("METHOD__WithMerchantId Constructor | MESSAGE__merchant_id: " + this.merchant_id);
            return this;
        }

        public string GetMerchantId()
        {
            return this.merchant_id;
        }

        /// <summary>
        /// Sets the Amazon Order Reference ID
        /// </summary>
        /// <param name="amazon_order_reference_id"></param>
        /// <returns>GetOrderReferenceDetailsRequest Object</returns>
        public GetOrderReferenceDetailsRequest WithAmazonOrderReferenceId(string amazon_order_reference_id)
        {
            this.amazon_order_reference_id = amazon_order_reference_id;
            log.Debug("METHOD__WithAmazonOrderReferenceId | MESSAGE__amazon_order_reference_id: " + this.amazon_order_reference_id);
            return this;
        }

        public string GetAmazonOrderReferenceId()
        {
            return this.amazon_order_reference_id;
        }
        /// <summary>
        /// Sets the Address Consent Token
        /// </summary>
        /// <param name="address_consent_token"></param>
        /// <returns>GetOrderReferenceDetailsRequest Object</returns>
        public GetOrderReferenceDetailsRequest WithaddressConsentToken(string address_consent_token)
        {
            this.address_consent_token = System.Web.HttpUtility.UrlDecode(address_consent_token);
            log.Debug("METHOD__WithaddressConsentToken | MESSAGE__address_consent_token: " + this.address_consent_token);
            return this;
        }

        public string GetAddressConsentToken()
        {
            return this.address_consent_token;
        }

        /// <summary>
        /// Sets the MWS Auth Tokenh
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>GetOrderReferenceDetailsRequest Object</returns>
        public GetOrderReferenceDetailsRequest WithMWSAuthToken(string mws_auth_token)
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
