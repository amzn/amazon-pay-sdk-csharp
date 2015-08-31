using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.RecurringPaymentRequests
{
    /// <summary>
    /// Request class to set the ConfirmBillingAgreement API call parameters
    /// </summary>
    public class ConfirmBillingAgreementRequest
    {
        public Hashtable confirmBillingAgreementHashtable = new Hashtable();

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>ConfirmBillingAgreementRequest Object</returns>
        public ConfirmBillingAgreementRequest WithMerchantId(string merchant_id)
        {
            confirmBillingAgreementHashtable["merchant_id"] = merchant_id;
            return this;
        }

        /// <summary>
        /// Sets the Amazon Billing Agreement ID
        /// </summary>
        /// <param name="amazon_billing_agreement_id"></param>
        /// <returns>ConfirmBillingAgreementRequest Object</returns>
        public ConfirmBillingAgreementRequest WithAmazonBillingreementId(string amazon_billing_agreement_id)
        {
            confirmBillingAgreementHashtable["amazon_billing_agreement_id"] = amazon_billing_agreement_id;
            return this;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>ConfirmBillingAgreementRequest Object</returns>
        public ConfirmBillingAgreementRequest WithMWSAuthToken(string mws_auth_token)
        {
            confirmBillingAgreementHashtable["mws_auth_token"] = mws_auth_token;
            return this;
        }
    }
}
