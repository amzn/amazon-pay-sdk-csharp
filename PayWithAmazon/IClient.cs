using System;
using System.Collections;

namespace PayWithAmazon
{
    /// <summary>
    /// Interface class to showcase the public API methods for Pay With Amazon
    /// </summary>
    interface IClient
    {
        /// <summary>
        /// Authorize API call - Reserves a specified amount against the payment method(s) stored in the order reference.
        /// https://payments.amazon.com/documentation/apireference/201752010
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        ///  <code>
        ///   Hashtable requestParameters = new Hashtable();
        ///    
        ///   // Required
        ///   requestParameters["amazon_order_reference_id"] = "S01/P01-XXXXX-XXXXX";
        ///   requestParameters["authorization_amount"] = "100";
        ///   
        ///   // Optional
        ///   requestParameters["merchant_id"] = "MERCHANT_ID"; // Required if config["merchant_id"] is null
        ///   requestParameters["currency_code"] = "USD"; // Required if config["currency_code"] is null
        ///   requestParameters["authorization_reference_id"] = "UNIQUE_STRING";
        ///   requestParameters["capture_now"] = false; // Defaults to false
        ///   requestParameters["provider_credit_details"] = "list of Hashtable"; // [list(Hashtable)]
        ///   requestParameters["seller_authorization_note"] = "CUSTOM_NOTE";
        ///   requestParameters["transaction_timeout"] = "5"; // Defaults to 1440 minutes
        ///   requestParameters["soft_descriptor"] = "AMZ*CUSTOM";
        ///   requestParameters["mws_auth_token"] = "MWS_AUTH_TOKEN";
        ///  </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        ResponseParser Authorize(Hashtable requestParameters);

        /// <summary>
        /// AuthorizeOnBillingAgreement API call - Reserves a specified amount against the payment method(s) stored in the Billing Agreement.
        /// https://payments.amazon.com/documentation/apireference/201751940
        /// </summary>
        /// <example>
        ///  <code>
        ///   Hashtable requestParameters = new Hashtable();
        ///    
        ///   // Required
        ///   requestParameters["amazon_billing_agreement_id"] = "C01/B01-XXXXX-XXXXX";
        ///   requestParameters["authorization_reference_id"] = "UNIQUE_STRING";
        ///   requestParameters["authorization_amount"] = "100";
        ///   
        ///   
        ///   // Optional
        ///   requestParameters["merchant_id"] = "MERCHANT_ID"; // Required if config["merchant_id"] is null
        ///   requestParameters["currency_code"] = "USD"; // Required if config["currency_code"] is null
        ///   requestParameters["seller_authorization_note"] = "CUSTOM_NOTE";
        ///   requestParameters["transaction_timeout"] = 5; // Defaults to 1440 minutes
        ///   requestParameters["capture_now"] = false; // Defaults to false
        ///   requestParameters["soft_descriptor"] = "AMZ*CUSTOM";
        ///   requestParameters["seller_note"] = "CUSTOM_NOTE";
        ///   requestParameters["platform_id"] = "PLATFORM_ID" // Solution Provider ID
        ///   requestParameters["custom_information"] = "CUSTOM_INFO";
        ///   requestParameters["seller_order_id"] = "CUSTOM_ID";
        ///   requestParameters["store_name"] = "CUSTOM_NAME";
        ///   requestParameters["inherit_shipping_address"] = true; // Defaults to true
        ///   requestParameters["mws_auth_token"] = "MWS_AUTH_TOKEN";
        ///  </code>
        /// </example>
        /// <param name="requestParameters"></param>
        /// <returns>ResponseParser responseObject</returns>
        ResponseParser AuthorizeOnBillingAgreement(Hashtable requestParameters);
        
        /// <summary>
        /// CancelOrderReferenceDetails API call - Cancels a previously confirmed order reference.
        /// https://payments.amazon.com/documentation/apireference/201751990"
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        ///  <code>
        ///   Hashtable requestParameters = new Hashtable();
        ///   
        ///   // Required
        ///   requestParameters["amazon_order_reference_id"] = "S01/P01-XXXXX-XXXXX";
        ///  
        ///   // Optional
        ///   requestParameters["merchant_id"] = "MERCHANT_ID"; // Required if config["merchant_id"] is null
        ///   requestParameters["cancelation_reason"] = "CUSTOM_CANCEL_REASON";
        ///   requestParameters["mws_auth_token"] = "MWS_AUTH_TOKEN";
        /// </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        ResponseParser CancelOrderReference(Hashtable requestParameters);

        /// <summary>
        /// Capture API call - Captures funds from an authorized payment instrument
        /// https://payments.amazon.com/documentation/apireference/201752040
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        ///  <code>
        ///   Hashtable requestParameters = new Hashtable();
        ///   // Required
        ///   requestParameters["amazon_authorization_id"] "S01/P01-XXXXX-XXXXX-AXXXX";
        ///   requestParameters["capture_amount"] = "100";
        ///   requestParameters["capture_reference_id"] = "UNIQUE_STRING";
        ///  
        ///   // Optional 
        ///   requestParameters["merchant_id"] = "MERCHANT_ID"; // Required if config["merchant_id"] is null
        ///   requestParameters["currency_code"] = "USD"; // Required if config["currency_code"] is null
        ///   requestParameters["provider_credit_details"] = [list(Hashtable)]; // list of Provider Credit Hashtable(s) details
        ///   requestParameters["seller_capture_note"] = "CUSTOM_NOTE";
        ///   requestParameters["soft_descriptor"] = "AMZ*CUSTOM";
        ///   requestParameters["mws_auth_token"] = "MWS_AUTH_TOKEN";
        ///  </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        ResponseParser Capture(Hashtable requestParameters);

        /// <summary>
        /// Charge convenience method
        /// Performs the API calls
        /// 1. SetOrderReferenceDetails / SetBillingAgreementDetails
        /// 2. ConfirmOrderReference / ConfirmBillingAgreement
        /// 3. Authorize / AuthorizeOnBillingAgreeemnt
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        ///  <code>
        ///   Hashtable requestParameters = new Hashtable();
        ///   
        ///   // Required
        ///   requestParameters["amazon_reference_id"] = "(S01/P01-XXXXX-XXXXX) / (C01/B01-XXXXX-XXXXX)";// Order Reference ID /Billing Agreement ID
        ///   // If requestParameters["amazon_reference_id"] is empty then the following is required,
        ///    requestParameters["amazon_order_reference_id"]="S01/P01-XXXXX-XXXXX";
        ///   // or,
        ///    requestParameters["amazon_billing_agreement_id"] = "C01/B01-XXXXX-XXXXX";
        ///    requestParameters["authorization_reference_id"] ="UNIQUE_STRING" // Any unique string that needs to be passed
        ///    requestParameters["charge_amount"] = "100";
        ///    
        ///   // Optional
        ///   requestParameters["merchant_id"] = "MERCHANT_ID"; // Required if config["merchant_id"] is null
        ///   requestParameters["currency_code"] = "USD"; // Required if config["currency_code"] is null
        ///   requestParameters["charge_note"] =  "CUSTOM_NOTE" // Seller Note sent to the buyer
        ///   requestParameters["transaction_timeout"] = 5; // Defaults to 1440 minutes
        ///   requestParameters["capture_now"] = false; // captures payment automatically when set to true, defaults to false
        ///   requestParameters["charge_order_id"] = "CUSTOM_ID"; // Custom Order ID provided
        ///   requestParameters["mws_auth_token"] = "MWS_AUTH_TOKEN";
        ///  </code>
        /// </example>
        /// <returns>ResponseParser response</returns>
        ResponseParser Charge(Hashtable requestParameters);

        /// <summary>
        /// CloseAuthorization API call - Closes an authorization.
        /// https://payments.amazon.com/documentation/apireference/201752070
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        ///  <code>
        ///   Hashtable requestParameters = new Hashtable();
        ///   
        ///   // Required
        ///   requestParameters["amazon_authorization_id"] = "S01/P01-XXXXX-XXXXX-AXXXXX";
        ///   
        ///   // Optional
        ///   requestParameters["merchant_id"] = "MERCHANT_ID"; // Required if config["merchant_id"] is null
        ///   requestParameters["closure_reason"] = "CLOSURE_REASON";
        ///   requestParameters["mws_auth_token"] = "MWS_AUTH_TOKEN";
        ///  </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        ResponseParser CloseAuthorization(Hashtable requestParameters);

        /// <summary>
        /// CloseBillingAgreement API Call - Returns details about the Billing Agreement object and its current state.
        /// https://payments.amazon.com/documentation/apireference/201751950
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        /// <code>
        ///  Hashtable requestParameters = new Hashtable();
        ///   
        ///  // Required
        ///  requestParameters["amazon_billing_agreement_id"] = "C01/B01-XXXXX-XXXXX";
        ///   
        ///  // Optional
        ///  requestParameters["merchant_id"] = "MERCHANT_ID"; // Required if config["merchant_id"] is null
        ///  requestParameters["closure_reason"] = "CLOSURE_REASON";
        ///  requestParameters["mws_auth_token"] = "MWS_AUTH_TOKEN";
        /// </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        ResponseParser CloseBillingAgreement(Hashtable requestParameters);

        /// <summary>
        /// CloseOrderReference API call - Confirms that an order reference has been fulfilled (fully or partially)
        /// https://payments.amazon.com/documentation/apireference/201752000
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        ///  <code>
        ///   Hashtable requestParameters = new Hashtable();
        ///   
        ///   // Required
        ///   requestParameters["amazon_order_reference_id"] "S01/P01-XXXXX-XXXXX";
        /// 
        ///   // Optional
        ///   requestParameters["merchant_id"] = "MERCHANT_ID"; // Required if config["merchant_id"] is null
        ///   requestParameters["closure_reason"] = "CLOSURE_REASON";
        ///   requestParameters["mws_auth_token"] = "MWS_AUTH_TOKEN";
        /// </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        ResponseParser CloseOrderReference(Hashtable requestParameters);

        /// <summary>
        /// CloseBillingAgreement API Call - Returns details about the Billing Agreement object and its current state.
        /// https://payments.amazon.com/documentation/apireference/201751950
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        /// <code>
        ///  Hashtable requestParameters = new Hashtable();
        ///   
        ///  // Required
        ///  requestParameters["amazon_billing_agreement_id"] = "C01/B01-XXXXX-XXXXX";
        ///   
        ///  // Optional
        ///  requestParameters["merchant_id"] = "MERCHANT_ID"; // Required if config["merchant_id"] is null
        ///  requestParameters["closure_reason"] = "CLOSURE_REASON";
        ///  requestParameters["mws_auth_token"] = "MWS_AUTH_TOKEN";
        /// </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        ResponseParser ConfirmBillingAgreement(Hashtable requestParameters);

        /// <summary>
        /// ConfirmOrderReference API call - Confirms that the order reference is free of constraints and all required information has been set on the order reference.
        /// https://payments.amazon.com/documentation/apireference/201751980
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        /// <code>
        ///  Hashtable requestParameters = new Hashtable();
        ///  
        ///  // Required
        ///  requestParameters["amazon_order_reference_id"] = "S01/P01-XXXXX-XXXXX";
        /// 
        ///  // Optional
        ///  requestParameters["merchant_id"] = "MERCHANT_ID"; // Required if config["merchant_id"] is null
        ///  requestParameters["mws_auth_token"] = "MWS_AUTH_TOKEN";
        /// </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        ResponseParser ConfirmOrderReference(Hashtable requestParameters);

        /// <summary>
        /// CreateOrderReferenceForId API Call - Creates an order reference for the given object
        /// https://payments.amazon.com/documentation/apireference/201751670
        /// </summary>
        /// <example>
        ///  <code>
        ///    Hashtable requestParameters = new Hashtable();
        ///   
        ///   // Required
        ///   requestParameters["Id"] = "C01/B01-XXXXX-XXXXX" // Billing Agreement ID
        ///   
        ///   // Optional
        ///   requestParameters["inherit_shipping_address"] = true; // Defaults to false
        ///   requestParameters["ConfirmNow"]  = true; // Defaults to False
        ///   requestParameters["amount"] = "100"; // Required when requestParameters["ConfirmNow"] is set to true
        ///   requestParameters["currency_code"] = "USD"; // Required if config["currency_code"] is null
        ///   requestParameters["seller_note"] = "CUSTOM_NOTE";
        ///   requestParameters["seller_order_id"] = "CUSTOM_ORDER_ID";
        ///   requestParameters["store_name"] = "CUSTOM_NAME";
        ///   requestParameters["custom_information"] = "CUSTOM_INFO";
        ///   requestParameters["mws_auth_token"] = "MWS_AUTH_TOKEN";
        ///  </code>
        /// </example>
        /// <param name="requestParameters"></param>
        /// <returns>ResponseParser responseObject</returns>
        ResponseParser CreateOrderReferenceForId(Hashtable requestParameters);

        /// <summary>
        /// GetAuthorizationDetails API call - Returns the status of a particular authorization and the total amount captured on the authorization.
        /// https://payments.amazon.com/documentation/apireference/201752030
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        ///  <code>
        ///   Hashtable requestParameters = new Hashtable();
        ///   
        ///   // Required
        ///   requestParameters["amazon_authorization_id"] = "S01/P01-XXXXX-XXXXX-AXXXXX";
        ///  
        ///   // Optional 
        ///   requestParameters["merchant_id"] = "MERCHANT_ID";
        ///   requestParameters["mws_auth_token"] "MWS_AUTH_TOKEN";
        ///  </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        ResponseParser GetAuthorizationDetails(Hashtable requestParameters);

        /// <summary>
        /// GetBillingAgreementDetails API Call - Returns details about the Billing Agreement object and its current state.
        /// https://payments.amazon.com/documentation/apireference/201751690
        /// </summary>
        /// <example>
        ///  <code>
        ///    Hashtable requestParameters = new Hashtable();
        ///    
        ///   // Required
        ///   requestParameters["amazon_billing_agreement_id"] = "C01/B01-XXXXX-XXXXX";
        ///   
        ///   // Optional
        ///   requestParameters["merchant_id"] = "MERCHANT_ID";
        ///   requestParameters["mws_auth_token"] = "MWS_AUTH_TOKEN";
        ///  </code>
        /// </example>
        /// <param name="requestParameters"></param>
        /// <returns>ResponseParser responseObject</returns>
        ResponseParser GetBillingAgreementDetails(Hashtable requestParameters);

        /// <summary>
        /// GetCaptureDetails API call - Returns the status of a particular capture and the total amount refunded on the capture.
        /// https://payments.amazon.com/documentation/apireference/201752060
        /// </summary>
        /// <example>
        ///  <code>
        ///   Hashtable requestParameters = new Hashtable();
        ///   
        ///   // Required
        ///   requestParameters["amazon_capture_id"] = "S01/P01-XXXXX-XXXXX-CXXXXX" ;
        ///  
        ///   // Optional
        ///   requestParameters["merchant_id"] = "MERCHANT_ID"; // Required if config["merchant_id"] is null
        ///   requestParameters["mws_auth_token"] = "MWS_AUTH_TOKEN";
        ///  </code>
        /// </example>
        /// <param name="requestParameters"></param>
        /// <returns>ResponseParser responseObject</returns>
        ResponseParser GetCaptureDetails(Hashtable requestParameters);

        /// <summary>
        /// Gets the value for the key if the key exists in config
        /// </summary>
        /// <param name="name"></param>
        /// <returns>string</returns>
        string GetConfigValue(string name);

        /// <summary>
        /// GetOrderReferenceDetails API call - Returns details about the Order Reference object and its current state.
        /// </summary>
        /// <example>
        ///  <code>
        ///   Hashtable requestParameters = new Hashtable();
        ///  
        ///   // Required params
        ///   requestParameters["amazon_order_reference_id"] = "S01/P01-XXXXX-XXXXX";
        ///  
        ///   // Optional params
        ///   requestParameters["merchant_id"] = "MERCHANT_ID"; // Required if config["merchant_id"] is null
        ///   requestParameters["address_consent_token"] = "ACCESS_TOKEN";
        ///   requestParameters["mws_auth_token"] = "MWS_AUTH_TOKEN";
        ///  </code>
        /// </example>
        /// <param name="requestParameters"></param>
        /// <returns>ResponseParser responseObject</returns>
        ResponseParser GetOrderReferenceDetails(Hashtable requestParameters);

        /// <summary>
        /// GetProviderCreditDetails API Call - Get the details of the Provider Credit.
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        /// <code>
        ///  Hashtable requestParameters = new Hashtable();
        ///  
        ///  // Required
        ///  requestParameters["amazon_provider_credit_id"]  = "PROVIDER_CREDIT_ID";
        ///  
        ///  // Optional
        ///  requestParameters["merchant_id"] = "MERCHANT_ID"; // Required if config["merchant_id"] is null
        ///  requestParameters["mws_auth_token"] = "MWS_AUTH_TOKEN";
        /// </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        ResponseParser GetProviderCreditDetails(Hashtable requestParameters);

        /// <summary>
        /// GetProviderCreditReversalDetails API Call - Get details of the Provider Credit Reversal.
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        /// <code>
        ///  Hashtable requestParameters = new Hashtable();
        ///  
        ///  // Required
        ///  requestParameters["amazon_provider_credit_reversal_id"]  = "PROVIDER_CREDIT_REVERSAL_ID";
        ///  
        ///  // Optional
        ///  requestParameters["merchant_id"] = "MERCHANT_ID"; // Required if config["merchant_id"] is null
        ///  requestParameters["mws_auth_token"] = "MWS_AUTH_TOKEN";
        /// </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        ResponseParser GetProviderCreditReversalDetails(Hashtable requestParameters);

        /// <summary>
        /// GetRefundDetails API call - Returns the status of a particular refund.
        /// https://payments.amazon.com/documentation/apireference/201752100
        /// </summary>
        /// <example>
        ///  <code>
        ///   Hashtable requestParameters = new Hashtable();
        ///   
        ///   // Required
        ///   requestParameters["amazon_refund_id"] = "S01/P01-XXXXX-XXXXX-RXXXXX";
        ///   
        ///   // Optional
        ///   requestParameters["merchant_id"] = "MERCHANT_ID"; // Required if config["merchant_id"] is null
        ///   requestParameters["mws_auth_token"] "MWS_AUTH_TOKEN";
        ///  </code>
        /// </example>
        /// <param name="requestParameters"></param>
        /// <returns>ResponseParser responseObject</returns>
        ResponseParser GetRefundDetails(Hashtable requestParameters);

        /// <summary>
        /// GetServiceStatus API Call - Returns the operational status of the Off-Amazon Payments API section
        /// section of Amazon Marketplace Web Service (Amazon MWS). Status values are GREEN, GREEN_I, YELLOW, and RED.
        /// https://payments.amazon.com/documentation/apireference/201752110
        /// </summary>
        /// <example>
        ///  <code>
        ///   // Optional
        ///   requestParameters["merchant_id"] = "MERCHANT_ID"; // Required if config["merchant_id"] is null
        ///   requestParameters["mws_auth_token"] = "MWS_AUTH_TOKEN";
        ///  </code>
        /// </example>
        /// <param name="requestParameters"></param>
        /// <returns></returns>
        ResponseParser GetServiceStatus(Hashtable requestParameters);

        /// <summary>
        /// GetUserInfo convenience function - Returns user's profile information from Amazon using the access token returned by the Button widget.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns>string response - json output of profile information</returns>
        string GetUserInfo(string accessToken);

        /// <summary>
        /// Refund API call - Refunds a previously captured amount.
        /// https://payments.amazon.com/documentation/apireference/201752080
        /// </summary>
        /// <example>
        ///  <code>
        ///   Hashtable requestParameters = new Hashtable();
        ///   
        ///   // Required
        ///   requestParameters["amazon_capture_id"] = "S01/P01-XXXXX-XXXXX";
        ///   requestParameters["refund_reference_id"] = "UNIQUE_STRING";
        ///   requestParameters["refund_amount"] = "100";
        ///   
        ///   //Optional
        ///   requestParameters["merchant_id"] = "MERCHANT_ID"; // Required if config["merchant_id"] is null
        ///   requestParameters["currency_code"] = "USD"; // Required if config["currency_code"] is null
        ///   requestParameters["provider_credit_reversal_details"] = [list(Hashtable)]; // list of Provider Credit Hashtable(s) details
        ///   requestParameters["seller_refund_note"] = "CUSTOM_NOTE";
        ///   requestParameters["soft_descriptor"] = "AMZ*CUSTOM";
        ///   requestParameters["mws_auth_token"] = "MWS_AUTH_TOKEN";
        ///  </code>
        /// </example>
        /// <param name="requestParameters"></param>
        /// <returns>ResponseParser responseObject</returns>
        ResponseParser Refund(Hashtable requestParameters);

        /// <summary>
        /// ReverseProviderCredit API Call - Reverse the Provider Credit.
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        /// <code>
        ///  Hashtable requestParameters = new Hashtable();
        ///  
        ///  // Required
        ///  requestParameters["amazon_provider_credit_id"]  = "PROVIDER_CREDIT_ID";
        ///  requestParameters["credit_reversal_reference_id"] = "UNIQUE_STRING";
        ///  requestParameters["credit_reversal_amount"] = "10";
        ///  
        ///  
        ///  // Optional
        ///  requestParameters["merchant_id"] = "MERCHANT_ID"; // Required if config["merchant_id"] is null
        ///  requestParameters["currency_code"] = "USD"; // Required if config["currency_code"] is null
        ///  requestParameters["credit_reversal_note"] = "CUSTOM_NOTE";
        ///  requestParameters["mws_auth_token"] = "MWS_AUTH_TOKEN";
        /// </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        ResponseParser ReverseProviderCredit(Hashtable requestParameters);

        /// <summary>
        /// SetBillingAgreementDetails API call - Sets Billing Agreement details such as a description of the agreement and other information about the seller.
        /// https://payments.amazon.com/documentation/apireference/201751700
        /// </summary>
        /// <example>
        ///  <code>
        ///   Hashtable requestParameters = new Hashtable();
        ///   
        ///   // Required
        ///   requestParameters["amazon_billing_agreement_id"] = "C01/B01-XXXXX-XXXXX";
        ///   requestParameters["amount"] = "100";
        ///   
        ///   // Optional
        ///   requestParameters["merchant_id"] = "MERCHANT_ID"; // Required if config["merchant_id"] is null
        ///   requestParameters["currency_code"] = "USD"; // Required if config["currency_code"] is null
        ///   requestParameters["platform_id"] = "PLATFORM_ID"; // Solution Provider ID
        ///   requestParameters["seller_note"] = "CUSTOM_NOTE":
        ///   requestParameters["seller_billing_agreement_id"] = "CUSTOM_ID"; 
        ///   requestParameters["store_name"] = "CUSTOM_STORE_NAME";
        ///   requestParameters["custom_information"] = "CUSTOM_INFO";
        ///   requestParameters["mws_auth_token"] = "MWS_AUTH_TOKEN" ;
        ///  </code>
        /// </example>
        /// <param name="requestParameters"></param>
        /// <returns>ResponseParser responseObject</returns>
        ResponseParser SetBillingAgreementDetails(Hashtable requestParameters);

        /// <summary>
        /// Setter for config["client_id"]
        /// Sets the value for config["client_id"] variable
        /// </summary>
        /// <param name="value"></param>
        void SetClientId(string value);

        /// <summary>
        /// Setter for mwsServiceUrl
        /// Set the URL to which the post request has to be made for unit testing
        /// </summary>
        /// <param name="url"></param>
        void SetMwsServiceUrl(string url);

        /// <summary>
        /// SetOrderReferenceDetails API call - Sets order reference details such as the order total and a description for the order.
        /// https://payments.amazon.com/documentation/apireference/201751960
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        ///  <code>
        ///   Hashtable requestParameters = new Hashtable();
        ///  
        ///   // Required Parameters
        ///   requestParameters["amazon_order_reference_id"] = "S01/P01-XXXXX-XXXXX";
        ///   requestParameters["amount"] = "100";
        ///   requestParameters["currency_code"] = "USD"; // Required if config["currency_code"] is null
        ///   requestParameters["merchant_id"] = "MERCHANT_ID"; // Required if config["merchant_id"] is null
        /// 
        ///   // Optional 
        ///   requestParameters["platform_id"] = "SOLUTION_PROVIDER_ID";
        ///   requestParameters["seller_note"] = "CUSTOM_NOTE";
        ///   requestParameters["seller_order_id"] = "CUSTOM_ORDER_ID";
        ///   requestParameters["store_name"] = "CUSTOM_STORE_NAME";
        ///   requestParameters["custom_information"] = "CUSTOM_INFO";
        ///   requestParameters["mws_auth_token"] = "MWS_AUTH_TOKEN";
        ///  </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        ResponseParser SetOrderReferenceDetails(Hashtable requestParameters);

        /// <summary>
        /// Setter for Proxy
        /// </summary>
        /// <param name="proxy"></param>
        /// <example>
        ///  <code>
        ///   proxy["proxy_user_host"] = "PROXY_HOST_NAME";
        ///   proxy["proxy_user_port"] = "PROXY_USER_PORT";
        ///   proxy["proxy_user_name"] = "PROXY_USER_NAME";
        ///   proxy["proxy_user_password"] = "PROXY_USER_PASSWORD";
        ///  </code>
        /// </example>
        void SetProxy(Hashtable proxy);

        /// <summary>
        /// Setter for sandbox
        /// Sets the Boolean value for config["sandbox"] variable
        /// </summary>
        /// <param name="value"></param>
        void SetSandbox(bool value);

        /// <summary>
        /// ValidateBillignAgreement API Call - Validates the status of the Billing Agreement object and the payment method associated with it.
        /// https://payments.amazon.com/documentation/apireference/201751720
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        ///  <code>
        ///   Hashtable requestParameters = new Hashtable();
        ///    
        ///   // Required
        ///   requestParameters["amazon_billing_agreement_id"] = "C01/B01-XXXXX-XXXXX";
        ///   
        ///   // Optional
        ///   requestParameters["merchant_id"]  = "MERCHANT_ID"; // Required if config["merchant_id"] is null
        ///   requestParameters["mws_auth_token"] = "MWS_AUTH_TOKEN";
        ///  </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        ResponseParser ValidateBillingAgreement(Hashtable requestParameters);
    }
}