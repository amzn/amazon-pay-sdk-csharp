using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.RecurringPaymentRequests
{
    /// <summary>
    /// Request class to set the CloseBillingAgreement API call parameters
    /// </summary>
    public class CloseBillingAgreementRequest
    {
        
        private string merchant_id;
        private string amazon_billing_agreement_id;
        private string closure_reason;
        private string mws_auth_token;
        private string action;
        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public CloseBillingAgreementRequest()
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Debug("METHOD__CloseBillingAgreementRequest Constructor | MESSAGE__Constructor Initiate");
            this.action = Constants.CloseBillingAgreement;
            log.Debug("METHOD__CloseBillingAgreementRequest | MESSAGE__Action: " + this.action);
        }
        public string GetAction()
        {
            return this.action;
        }
        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>CloseBillingAgreementRequest Object</returns>
        public CloseBillingAgreementRequest WithMerchantId(string merchant_id)
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
        /// <returns>CloseBillingAgreementRequest Object</returns>
        public CloseBillingAgreementRequest WithAmazonBillingAgreementId(string amazon_billing_agreement_id)
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
        /// Sets the Closure reason
        /// </summary>
        /// <param name="closure_reason"></param>
        /// <returns>CloseBillingAgreementRequest Object</returns>
        public CloseBillingAgreementRequest WithClosureReason(string closure_reason)
        {
            this.closure_reason = closure_reason;
            log.Debug("METHOD__WithClosureReason | MESSAGE__closure_reason: " + this.closure_reason);
            return this;
        }
        public string GetClosureReason()
        {
            return this.closure_reason;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>CloseBillingAgreementRequest Object</returns>
        public CloseBillingAgreementRequest WithMWSAuthToken(string mws_auth_token)
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
