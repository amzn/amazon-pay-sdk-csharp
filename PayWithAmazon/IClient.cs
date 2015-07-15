using System;
using System.Collections;

/* Interface class to showcase the public API methods for Pay With Amazon */

namespace PayWithAmazon
{
    interface IClient
    {
        /* Authorize API call - Reserves a specified amount against the payment method(s) stored in the order reference.
         * @see https://payments.amazon.com/documentation/apireference/201752010
         *
         * @param requestParameters["merchant_id"] - [String]
         * @param requestParameters["amazon_order_reference_id"] - [String]
         * @param requestParameters["authorization_amount"] [String]
         * @param requestParameters["currency_code"] - [String]
         * @param requestParameters["authorization_reference_id"] [String]
         * @optional requestParameters["capture_now"] [String]
         * @optional requestParameters["provider_credit_details"] - [list(Hashtable)]
         * @optional requestParameters["seller_authorization_note"] [String]
         * @optional requestParameters["transaction_timeout"] [String] - Defaults to 1440 minutes
         * @optional requestParameters["soft_descriptor"] - [String]
         * @optional requestParameters["mws_auth_token"] - [String]
         */

        ResponseParser Authorize(Hashtable requestParameters);

        /* AuthorizeOnBillingAgreement API call - Reserves a specified amount against the payment method(s) stored in the Billing Agreement.
         * @see https://payments.amazon.com/documentation/apireference/201751940
         *
         * @param requestParameters["merchant_id"] - [String]
         * @param requestParameters["amazon_billing_agreement_id"] - [String]
         * @param requestParameters["authorization_reference_id"] [String]
         * @param requestParameters["authorization_amount"] [String]
         * @param requestParameters["currency_code"] - [String]
         * @optional requestParameters["seller_authorization_note"] [String]
         * @optional requestParameters["transaction_timeout"] - Defaults to 1440 minutes
         * @optional requestParameters["capture_now"] [String]
         * @optional requestParameters["soft_descriptor"] - - [String]
         * @optional requestParameters["seller_note"] - [String]
         * @optional requestParameters["platform_id"] - [String]
         * @optional requestParameters["custom_information"] - [String]
         * @optional requestParameters["seller_order_id"] - [String]
         * @optional requestParameters["store_name"] - [String]
         * @optional requestParameters["inherit_shipping_address"] [Boolean] - Defaults to true
         * @optional requestParameters["mws_auth_token"] - [String]
         */

        ResponseParser AuthorizeOnBillingAgreement(Hashtable requestParameters);

        /* CancelOrderReferenceDetails API call - Cancels a previously confirmed order reference.
         * @see https://payments.amazon.com/documentation/apireference/201751990
         *
         * @param requestParameters["merchant_id"] - [String]
         * @param requestParameters["amazon_order_reference_id"] - [String]
         * @optional requestParameters["cancelation_reason"] [String]
         * @optional requestParameters["mws_auth_token"] - [String]
         */

        ResponseParser CancelOrderReference(Hashtable requestParameters);

        /* Capture API call - Captures funds from an authorized payment instrument.
         * @see https://payments.amazon.com/documentation/apireference/201752040
         *
         * @param requestParameters["merchant_id"] - [String]
         * @param requestParameters["amazon_authorization_id"] - [String]
         * @param requestParameters["capture_amount"] - [String]
         * @param requestParameters["currency_code"] - [String]
         * @param requestParameters["capture_reference_id"] - [String]
         * @optional requestParameters["provider_credit_details"] - [list(Hashtable())]
         * @optional requestParameters["seller_capture_note"] - [String]
         * @optional requestParameters["soft_descriptor"] - [String]
         * @optional requestParameters["mws_auth_token"] - [String]
         */

        ResponseParser Capture(Hashtable requestParameters);

        /* Charge convenience method
         * Performs the API calls
         * 1. SetOrderReferenceDetails / SetBillingAgreementDetails
         * 2. ConfirmOrderReference / ConfirmBillingAgreement
         * 3. Authorize (with Capture) / AuthorizeOnBillingAgreeemnt (with Capture)
         *
         * @param requestParameters["merchant_id"] - [String]
         *
         * @param requestParameters["amazon_reference_id"] - [String] : Order Reference ID /Billing Agreement ID
         * If requestParameters["amazon_reference_id"] is empty then the following is required,
         * @param requestParameters["amazon_order_reference_id"] - [String] : Order Reference ID
         * or,
         * @param requestParameters["amazon_billing_agreement_id"] - [String] : Billing Agreement ID
         * 
         * @param requestParameters["charge_amount"] - [String] : Amount value to be captured
         * @param requestParameters["currency_code"] - [String] : Currency Code for the Amount
         * @param requestParameters["authorization_reference_id"] - [String]- Any unique string that needs to be passed
         * @optional requestParameters["charge_note"] - [String] : Seller Note sent to the buyer
         * @optional requestParameters["transaction_timeout"] - [String] : Defaults to 1440 minutes
         * @param requestParameters["capture_now"] - [String]- captures payment automatically when set to true, defaults to false
         * @optional requestParameters["charge_order_id"] - [String] : Custom Order ID provided
         * @optional requestParameters["mws_auth_token"] - [String]
         */

        ResponseParser Charge(Hashtable requestParameters);

        /* CloseAuthorization API call - Closes an authorization.
         * @see https://payments.amazon.com/documentation/apireference/201752070
         *
         * @param requestParameters["merchant_id"] - [String]
         * @param requestParameters["amazon_authorization_id"] - [String]
         * @optional requestParameters["closure_reason"] [String]
         * @optional requestParameters["mws_auth_token"] - [String]
        */

        ResponseParser CloseAuthorization(Hashtable requestParameters);

        /* CloseBillingAgreement API Call - Returns details about the Billing Agreement object and its current state.
         * @see https://payments.amazon.com/documentation/apireference/201751950
         *
         * @param requestParameters["merchant_id"] - [String]
         * @param requestParameters["amazon_billing_agreement_id"] - [String]
         * @optional requestParameters["closure_reason"] [String]
         * @optional requestParameters["mws_auth_token"] - [String]
         */

        ResponseParser CloseBillingAgreement(Hashtable requestParameters);

        /* CloseOrderReference API call - Confirms that an order reference has been fulfilled (fully or partially)
         * and that you do not expect to create any new authorizations on this order reference.
         * @see https://payments.amazon.com/documentation/apireference/201752000
         *
         * @param requestParameters["merchant_id"] - [String]
         * @param requestParameters["amazon_order_reference_id"] - [String]
         * @optional requestParameters["closure_reason"] [String]
         * @optional requestParameters["mws_auth_token"] - [String]
         */

        ResponseParser CloseOrderReference(Hashtable requestParameters);

        /* ConfirmBillingAgreement API Call - Confirms that the Billing Agreement is free of constraints and all required information has been set on the Billing Agreement.
         * @see https://payments.amazon.com/documentation/apireference/201751710
         *
         * @param requestParameters["merchant_id"] - [String]
         * @param requestParameters["amazon_billing_agreement_id"] - [String]
         * @optional requestParameters["mws_auth_token"] - [String]
         */

        ResponseParser ConfirmBillingAgreement(Hashtable requestParameters);

        /* ConfirmOrderReference API call - Confirms that the order reference is free of constraints and all required information has been set on the order reference.
         * @see https://payments.amazon.com/documentation/apireference/201751980
         * @param requestParameters["merchant_id"] - [String]
         * @param requestParameters["amazon_order_reference_id"] - [String]
         * @optional requestParameters["mws_auth_token"] - [String]
         */

        ResponseParser ConfirmOrderReference(Hashtable requestParameters);

        /* CreateOrderReferenceForId API Call - Creates an order reference for the given object
         * @see https://payments.amazon.com/documentation/apireference/201751670
         *
         * @param requestParameters["merchant_id"] - [String]
         * @param requestParameters["Id"] - [String]
         * @optional requestParameters["inherit_shipping_address"] [Boolean]
         * @optional requestParameters["ConfirmNow"] - [Boolean]
         * @optional Amount (required when confirm_now is set to true) [String]
         * @optional requestParameters["currency_code"] - [String]
         * @optional requestParameters["seller_note"] - [String]
         * @optional requestParameters["seller_order_id"] - [String]
         * @optional requestParameters["store_name"] - [String]
         * @optional requestParameters["custom_information"] - [String]
         * @optional requestParameters["mws_auth_token"] - [String]
         */

        ResponseParser CreateOrderReferenceForId(Hashtable requestParameters);

        /* GetAuthorizationDetails API call - Returns the status of a particular authorization and the total amount captured on the authorization.
         * @see https://payments.amazon.com/documentation/apireference/201752030
         *
         * @param requestParameters["merchant_id"] - [String]
         * @param requestParameters["amazon_authorization_id"] [String]
         * @optional requestParameters["mws_auth_token"] - [String]
         */

        ResponseParser GetAuthorizationDetails(Hashtable requestParameters);

        /* GetBillingAgreementDetails API Call - Returns details about the Billing Agreement object and its current state.
         * @see https://payments.amazon.com/documentation/apireference/201751690
         *
         * @param requestParameters["merchant_id"] - [String]
         * @param requestParameters["amazon_billing_agreement_id"] - [String]
         * @optional requestParameters["mws_auth_token"] - [String]
         */
        ResponseParser GetBillingAgreementDetails(Hashtable requestParameters);

        /* GetCaptureDetails API call - Returns the status of a particular capture and the total amount refunded on the capture.
         * @see https://payments.amazon.com/documentation/apireference/201752060
         *
         * @param requestParameters["merchant_id"] - [String]
         * @param requestParameters["amazon_capture_id"] - [String]
         * @optional requestParameters["mws_auth_token"] - [String]
         */

        ResponseParser GetCaptureDetails(Hashtable requestParameters);

        /* Getter
         * Gets the value for the key if the key exists in config
         */
        string GetConfigValue(string name);

        /* GetOrderReferenceDetails API call - Returns details about the Order Reference object and its current state.
         * @see https://payments.amazon.com/documentation/apireference/201751970
         *
         * @param requestParameters["merchant_id"] - [String]
         * @param requestParameters["amazon_order_reference_id"] - [String]
         * @optional requestParameters["address_consent_token"] - [String]
         * @optional requestParameters["mws_auth_token"] - [String]
         */

        ResponseParser GetOrderReferenceDetails(Hashtable requestParameters);

        /* GetProviderCreditDetails API Call - Get the details of the Provider Credit.
         *
         * @param requestParameters["merchant_id"] - [String]
         * @param requestParameters["amazon_provider_credit_id"] - [String]
         * @optional requestParameters["mws_auth_token"] - [String]
         */

        ResponseParser GetProviderCreditDetails(Hashtable requestParameters);

        /* GetProviderCreditReversalDetails API Call - Get details of the Provider Credit Reversal.
         *
         * @param requestParameters["merchant_id"] - [String]
         * @param requestParameters["amazon_provider_credit_reversal_id"] - [String]
         * @optional requestParameters["mws_auth_token"] - [String]
         */

        ResponseParser GetProviderCreditReversalDetails(Hashtable requestParameters);

        /* GetRefundDetails API call - Returns the status of a particular refund.
         * @see https://payments.amazon.com/documentation/apireference/201752100
         *
         * @param requestParameters["merchant_id"] - [String]
         * @param requestParameters["amazon_refund_id"] - [String]
         * @optional requestParameters["mws_auth_token"] - [String]
         */

        ResponseParser GetRefundDetails(Hashtable requestParameters);

        /* GetServiceStatus API Call - Returns the operational status of the Off-Amazon Payments API section
        * @see https://payments.amazon.com/documentation/apireference/201752110
        *
        * The GetServiceStatus operation returns the operational status of the Off-Amazon Payments API
        * section of Amazon Marketplace Web Service (Amazon MWS).
        * Status values are GREEN, GREEN_I, YELLOW, and RED.
        *
        * @param requestParameters["merchant_id"] - [String]
        * @optional requestParameters["mws_auth_token"] - [String]
        */

        ResponseParser GetServiceStatus(Hashtable requestParameters);

        /* GetUserInfo convenience function - Returns user's profile information from Amazon using the access token returned by the Button widget.
         *
         * @see http://login.amazon.com/website Step 4
         * @param $accessToken [String]
         */

        string GetUserInfo(string accessToken);

        /* Refund API call - Refunds a previously captured amount.
         * @see https://payments.amazon.com/documentation/apireference/201752080
         *
         * @param requestParameters["merchant_id"] - [String]
         * @param requestParameters["amazon_capture_id"] - [String]
         * @param requestParameters["refund_reference_id"] - [String]
         * @param requestParameters["refund_amount"] - [String]
         * @param requestParameters["currency_code"] - [String]
         * @optional requestParameters["provider_credit_reversal_details"] - [list(Hashtable())]
         * @optional requestParameters["seller_refund_note"] [String]
         * @optional requestParameters["soft_descriptor"] - [String]
         * @optional requestParameters["mws_auth_token"] - [String]
         */

        ResponseParser Refund(Hashtable requestParameters);

        /* ReverseProviderCredit API Call - Reverse the Provider Credit.
         *
         * @param requestParameters["merchant_id"] - [String]
         * @param requestParameters["amazon_provider_credit_id"] - [String]
         * @optional requestParameters["credit_reversal_reference_id"] - [String]
         * @param requestParameters["credit_reversal_amount"] - [String]
         * @optional requestParameters["currency_code"] - [String]
         * @optional requestParameters["credit_reversal_note"] - [String]
         * @optional requestParameters["mws_auth_token"] - [String]
         */

        ResponseParser ReverseProviderCredit(Hashtable requestParameters);

        /* SetBillingAgreementDetails API call - Sets Billing Agreement details such as a description of the agreement and other information about the seller.
         * @see https://payments.amazon.com/documentation/apireference/201751700
         *
         * @param requestParameters["merchant_id"] - [String]
         * @param requestParameters["amazon_billing_agreement_id"] - [String]
         * @param requestParameters["amount"] - [String]
         * @param requestParameters["currency_code"] - [String]
         * @optional requestParameters["platform_id"] - [String]
         * @optional requestParameters["seller_note"] - [String]
         * @optional requestParameters["seller_billing_agreement_id"] - [String]
         * @optional requestParameters["store_name"] - [String]
         * @optional requestParameters["custom_information"] - [String]
         * @optional requestParameters["mws_auth_token"] - [String]
         */

        ResponseParser SetBillingAgreementDetails(Hashtable requestParameters);

        /* Setter for config["client_id"]
         * Sets the value for config["client_id"] variable
         */

        void SetClientId(string value);

        /* Setter for mwsServiceUrl
         * Set the URL to which the post request has to be made for unit testing
         */

        void SetMwsServiceUrl(string url);

        /* SetOrderReferenceDetails API call - Sets order reference details such as the order total and a description for the order.
         * @see https://payments.amazon.com/documentation/apireference/201751960
         *
         * @param requestParameters["merchant_id"] - [String]
         * @param requestParameters["amazon_order_reference_id"] - [String]
         * @param requestParameters["amount"] - [String]
         * @param requestParameters["currency_code"] - [String]
         * @optional requestParameters["platform_id"] - [String]
         * @optional requestParameters["seller_note"] - [String]
         * @optional requestParameters["seller_order_id"] - [String]
         * @optional requestParameters["store_name"] - [String]
         * @optional requestParameters["custom_information"] - [String]
         * @optional requestParameters["mws_auth_token"] - [String]
         */

        ResponseParser SetOrderReferenceDetails(Hashtable requestParameters);

        /* Setter for Proxy
         * input proxy [Hashtable]
         * @param proxy["proxy_user_host"] - hostname for the proxy
         * @param proxy["proxy_user_port"] - hostname for the proxy
         * @param proxy["proxy_user_name"] - if your proxy required a username
         * @param proxy["proxy_user_password"] - if your proxy required a password
         */

        void SetProxy(Hashtable proxy);

        /* Setter for sandbox
         * Sets the Boolean value for config["sandbox"] variable
         */

        void SetSandbox(bool value);

        /* ValidateBillignAgreement API Call - Validates the status of the Billing Agreement object and the payment method associated with it.
         * @see https://payments.amazon.com/documentation/apireference/201751720
         *
         * @param requestParameters["merchant_id"] - [String]
         * @param requestParameters["amazon_billing_agreement_id"] - [String]
         * @optional requestParameters["mws_auth_token"] - [String]
         */

        ResponseParser ValidateBillingAgreement(Hashtable requestParameters);
    }
}
