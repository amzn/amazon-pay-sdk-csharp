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
        public Hashtable setBillingAgreementDetailsHashtable = new Hashtable();

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>SetBillingAgreementDetailsRequest Object</returns>
        public SetBillingAgreementDetailsRequest WithMerchantId(string merchant_id)
        {
            setBillingAgreementDetailsHashtable["merchant_id"] = merchant_id;
            return this;
        }

        /// <summary>
        /// Sets the Amazon Order Reference ID
        /// </summary>
        /// <param name="amazon_billing_agreement_id"></param>
        /// <returns>SetBillingAgreementDetailsRequest Object</returns>
        public SetBillingAgreementDetailsRequest WithAmazonBillingAgreementId(string amazon_billing_agreement_id)
        {
            setBillingAgreementDetailsHashtable["amazon_billing_agreement_id"] = amazon_billing_agreement_id;
            return this;
        }

        /// <summary>
        /// Sets the Platform ID
        /// </summary>
        /// <param name="platform_id"></param>
        /// <returns>SetBillingAgreementDetailsRequest Object</returns>
        public SetBillingAgreementDetailsRequest WithPlatformId(string platform_id)
        {
            setBillingAgreementDetailsHashtable["platform_id"] = platform_id;
            return this;
        }

        /// <summary>
        /// Sets the Seller Note
        /// </summary>
        /// <param name="seller_note"></param>
        /// <returns>SetBillingAgreementDetailsRequest Object</returns>
        public SetBillingAgreementDetailsRequest WithSellerNote(string seller_note)
        {
            setBillingAgreementDetailsHashtable["seller_note"] = seller_note;
            return this;
        }

        /// <summary>
        /// Sets the Seller Billing Agreement ID
        /// </summary>
        /// <param name="seller_billing_agreement_id"></param>
        /// <returns>SetBillingAgreementDetailsRequest Object</returns>
        public SetBillingAgreementDetailsRequest WithSellerBillingAgreementId(string seller_billing_agreement_id)
        {
            setBillingAgreementDetailsHashtable["seller_billing_agreement_id"] = seller_billing_agreement_id;
            return this;
        }

        /// <summary>
        /// Sets the Store Name
        /// </summary>
        /// <param name="store_name"></param>
        /// <returns>SetBillingAgreementDetailsRequest Object</returns>
        public SetBillingAgreementDetailsRequest WithStoreName(string store_name)
        {
            setBillingAgreementDetailsHashtable["store_name"] = store_name;
            return this;
        }

        /// <summary>
        /// Sets the Custom Information
        /// </summary>
        /// <param name="custom_information"></param>
        /// <returns>SetBillingAgreementDetailsRequest Object</returns>
        public SetBillingAgreementDetailsRequest WithCustomInformation(string custom_information)
        {
            setBillingAgreementDetailsHashtable["custom_information"] = custom_information;
            return this;
        }

        /// <summary>
        /// Sets the MWS Auth Token
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>SetBillingAgreementDetailsRequest Object</returns>
        public SetBillingAgreementDetailsRequest WithMWSAuthToken(string mws_auth_token)
        {
            setBillingAgreementDetailsHashtable["mws_auth_token"] = mws_auth_token;
            return this;
        }
    }
}
