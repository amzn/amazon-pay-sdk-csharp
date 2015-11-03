using log4net;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.RecurringPaymentRequests
{
    /// <summary>
    /// Request class to set the SetBillingAgreementDetails API call parameters
    /// </summary>
    public class SetBillingAgreementDetailsRequest
    {
        
        private string action;
        private string merchant_id;
        private string amazon_billing_agreement_id;
        private string platform_id;
        private string seller_note;
        private string seller_order_id;
        private string seller_billing_agreement_id;
        private string store_name;
        private string custom_information;
        private string mws_auth_token;
        private ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public SetBillingAgreementDetailsRequest()
        {
            log4net.Config.XmlConfigurator.Configure();
            log.Debug("METHOD__SetBillingAgreementDetailsRequest Constructor | MESSAGE__Constructor Initiate");
            this.action = Constants.SetBillingAgreementDetails;
            log.Debug("METHOD__SetBillingAgreementDetailsRequest | MESSAGE__Action: " + this.action);
        }
        public string GetAction()
        {
            return this.action;
        }
        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>SetBillingAgreementDetailsRequest Object</returns>
        public SetBillingAgreementDetailsRequest WithMerchantId(string merchant_id)
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
        /// Sets the Amazon Order Reference ID
        /// </summary>
        /// <param name="amazon_billing_agreement_id"></param>
        /// <returns>SetBillingAgreementDetailsRequest Object</returns>
        public SetBillingAgreementDetailsRequest WithAmazonBillingAgreementId(string amazon_billing_agreement_id)
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
        /// Sets the Platform ID
        /// </summary>
        /// <param name="platform_id"></param>
        /// <returns>SetBillingAgreementDetailsRequest Object</returns>
        public SetBillingAgreementDetailsRequest WithPlatformId(string platform_id)
        {
            this.platform_id = platform_id;
            log.Debug("METHOD__WithPlatformId | MESSAGE__platform_id: " + this.platform_id);
            return this;
        }
        public string GetPlatformId()
        {
            return this.platform_id;
        }

        /// <summary>
        /// Sets the Seller Note
        /// </summary>
        /// <param name="seller_note"></param>
        /// <returns>SetBillingAgreementDetailsRequest Object</returns>
        public SetBillingAgreementDetailsRequest WithSellerNote(string seller_note)
        {
            this.seller_note = seller_note;
            log.Debug("METHOD__WithSellerNote | MESSAGE__seller_note: " + this.seller_note);
            return this;
        }
        public string GetSellerNote()
        {
            return this.seller_note;
        }

        /// <summary>
        /// Sets the Seller Billing Agreement ID
        /// </summary>
        /// <param name="seller_billing_agreement_id"></param>
        /// <returns>SetBillingAgreementDetailsRequest Object</returns>
        public SetBillingAgreementDetailsRequest WithSellerBillingAgreementId(string seller_billing_agreement_id)
        {
            this.seller_billing_agreement_id = seller_billing_agreement_id;
            log.Debug("METHOD__WithSellerBillingAgreementId | MESSAGE__seller_billing_agreement_id: " + this.seller_billing_agreement_id);
            return this;
        }
        public string GetSellerBillingAgreementId()
        {
            return this.seller_billing_agreement_id;
        }

        /// <summary>
        /// Sets the Store Name
        /// </summary>
        /// <param name="store_name"></param>
        /// <returns>SetBillingAgreementDetailsRequest Object</returns>
        public SetBillingAgreementDetailsRequest WithStoreName(string store_name)
        {
            this.store_name = store_name;
            log.Debug("METHOD__WithStoreName | MESSAGE__store_name: " + this.store_name);
            return this;
        }
        public string GetStoreName()
        {
            return this.store_name;
        }
        /// <summary>
        /// Sets the Custom Information
        /// </summary>
        /// <param name="custom_information"></param>
        /// <returns>SetBillingAgreementDetailsRequest Object</returns>
        public SetBillingAgreementDetailsRequest WithCustomInformation(string custom_information)
        {
            this.custom_information = custom_information;
            log.Debug("METHOD__WithCustomInformation | MESSAGE__custom_information: " + this.custom_information);
            return this;
        }
        public string GetCustomInformation()
        {
            return this.custom_information;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>SetBillingAgreementDetailsRequest Object</returns>
        public SetBillingAgreementDetailsRequest WithMWSAuthToken(string mws_auth_token)
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
