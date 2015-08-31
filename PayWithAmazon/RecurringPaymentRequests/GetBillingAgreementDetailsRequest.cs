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
        public Hashtable getBillingAgreementDetailsHashtable = new Hashtable();

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>GetBillingAgreementDetailsRequest Object</returns>
        public GetBillingAgreementDetailsRequest WithMerchantId(string merchant_id)
        {
            getBillingAgreementDetailsHashtable["merchant_id"] = merchant_id;
            return this;
        }

        /// <summary>
        /// Sets the Amazon Billing Agreement ID
        /// </summary>
        /// <param name="amazon_billing_agreement_id"></param>
        /// <returns>GetBillingAgreementDetailsRequest Object</returns>
        public GetBillingAgreementDetailsRequest WithAmazonBillingAgreementId(string amazon_billing_agreement_id)
        {
            getBillingAgreementDetailsHashtable["amazon_billing_agreement_id"] = amazon_billing_agreement_id;
            return this;
        }

        /// <summary>
        /// Sets the Address Consent Token
        /// </summary>
        /// <param name="address_consent_token"></param>
        /// <returns>GetBillingAgreementDetailsRequest Object</returns>
        public GetBillingAgreementDetailsRequest WithaddressConsentToken(string address_consent_token)
        {
            getBillingAgreementDetailsHashtable["address_consent_token"] = address_consent_token;
            return this;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>GetBillingAgreementDetailsRequest Object</returns>
        public GetBillingAgreementDetailsRequest WithMWSAuthToken(string mws_auth_token)
        {
            getBillingAgreementDetailsHashtable["mws_auth_token"] = mws_auth_token;
            return this;
        }
    }
}
