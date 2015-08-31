using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.RecurringPaymentRequests
{
    /// <summary>
    /// Request class to set the ValidateBillingAgreement API call parameters
    /// </summary>
    public class ValidateBillingAgreementRequest
    {
        public Hashtable validateBillingAgreementHashtable = new Hashtable();

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>ValidateBillingAgreementRequest Object</returns>
        public ValidateBillingAgreementRequest WithMerchantId(string merchant_id)
        {
            validateBillingAgreementHashtable["merchant_id"] = merchant_id;
            return this;
        }

        /// <summary>
        /// Sets the Amazon Billing Agreement ID
        /// </summary>
        /// <param name="amazon_billing_agreement_id"></param>
        /// <returns>ValidateBillingAgreementRequest Object</returns>
        public ValidateBillingAgreementRequest WithAmazonBillingAgreementId(string amazon_billing_agreement_id)
        {
            validateBillingAgreementHashtable["amazon_billing_agreement_id"] = amazon_billing_agreement_id;
            return this;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>ValidateBillingAgreementRequest Object</returns>
        public ValidateBillingAgreementRequest WithMWSAuthToken(string mws_auth_token)
        {
            validateBillingAgreementHashtable["mws_auth_token"] = mws_auth_token;
            return this;
        }
    }
}
