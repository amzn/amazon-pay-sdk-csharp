using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.RecurringPaymentRequests
{
    /// <summary>
    /// Request class to set the GetBillingAgreementDetails API call parameters
    /// </summary>
    public class GetBillingAgreementDetailsRequest
    {
        
        private string action;
        private string merchant_id;
        private string amazon_billing_agreement_id;
        private string mws_auth_token;
        private string address_consent_token;
        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public GetBillingAgreementDetailsRequest()
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Debug("METHOD__GetBillingAgreementDetailsRequest Constructor | MESSAGE__Constructor Initiate");
            this.action = Constants.GetBillingAgreementDetails;
            log.Debug("METHOD__GetBillingAgreementDetailsRequest | MESSAGE__Action: " + this.action);
        }
        public string GetAction()
        {
            return this.action;
        }

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>GetBillingAgreementDetailsRequest Object</returns>
        public GetBillingAgreementDetailsRequest WithMerchantId(string merchant_id)
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
        /// Sets the Amazon Billing Agreement ID
        /// </summary>
        /// <param name="amazon_billing_agreement_id"></param>
        /// <returns>GetBillingAgreementDetailsRequest Object</returns>
        public GetBillingAgreementDetailsRequest WithAmazonBillingAgreementId(string amazon_billing_agreement_id)
        {
            this.amazon_billing_agreement_id = amazon_billing_agreement_id;
            log.Debug("METHOD__WithAmazonBillingAgreementId | MESSAGE__amazon_billing_agreement_id: " + this.amazon_billing_agreement_id);
            return this;
        }
        public string GetAmazonBillingAgreementId()
        {
            return this.amazon_billing_agreement_id;
        }

        /// <summary>
        /// Sets the Address Consent Token
        /// </summary>
        /// <param name="address_consent_token"></param>
        /// <returns>GetBillingAgreementDetailsRequest Object</returns>
        public GetBillingAgreementDetailsRequest WithaddressConsentToken(string address_consent_token)
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
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>GetBillingAgreementDetailsRequest Object</returns>
        public GetBillingAgreementDetailsRequest WithMWSAuthToken(string mws_auth_token)
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
