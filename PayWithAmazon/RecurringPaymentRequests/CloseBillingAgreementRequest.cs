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
        public Hashtable closeBillingAgreementHashtable = new Hashtable();

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>CloseBillingAgreementRequest Object</returns>
        public CloseBillingAgreementRequest WithMerchantId(string merchant_id)
        {
            closeBillingAgreementHashtable["merchant_id"] = merchant_id;
            return this;
        }

        /// <summary>
        /// Sets the Amazon Billing Agreement ID
        /// </summary>
        /// <param name="amazon_billing_agreement_id"></param>
        /// <returns>CloseBillingAgreementRequest Object</returns>
        public CloseBillingAgreementRequest WithAmazonBillingAgreementId(string amazon_billing_agreement_id)
        {
            closeBillingAgreementHashtable["amazon_billing_agreement_id"] = amazon_billing_agreement_id;
            return this;
        }

        /// <summary>
        /// Sets the Closure reason
        /// </summary>
        /// <param name="closure_reason"></param>
        /// <returns>CloseBillingAgreementRequest Object</returns>
        public CloseBillingAgreementRequest WithClosureReason(string closure_reason)
        {
            closeBillingAgreementHashtable["closure_reason"] = closure_reason;
            return this;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>CloseBillingAgreementRequest Object</returns>
        public CloseBillingAgreementRequest WithMWSAuthToken(string mws_auth_token)
        {
            closeBillingAgreementHashtable["mws_auth_token"] = mws_auth_token;
            return this;
        }
    }
}
