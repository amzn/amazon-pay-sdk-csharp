using System;
using PayWithAmazon.ProviderCreditRequests;
using PayWithAmazon.StandardPaymentRequests;
using PayWithAmazon.RecurringPaymentRequests;
using System.Collections;

namespace PayWithAmazon
{
    interface IClient
    {
        ResponseParser Authorize(PayWithAmazon.StandardPaymentRequests.AuthorizeRequest requestParameters);
        ResponseParser AuthorizeOnBillingAgreement(PayWithAmazon.RecurringPaymentRequests.AuthorizeOnBillingAgreementRequest requestParameters);
        ResponseParser CalculateSignatureAndPost(System.Collections.Hashtable parameters);
        ResponseParser CancelOrderReference(PayWithAmazon.StandardPaymentRequests.CancelOrderReferenceRequest requestParameters);
        ResponseParser Capture(PayWithAmazon.StandardPaymentRequests.CaptureRequest requestParameters);
        ResponseParser Charge(PayWithAmazon.StandardPaymentRequests.ChargeRequest requestParameters);
        ResponseParser CloseAuthorization(PayWithAmazon.StandardPaymentRequests.CloseAuthorizationRequest requestParameters);
        ResponseParser CloseBillingAgreement(PayWithAmazon.RecurringPaymentRequests.CloseBillingAgreementRequest requestParameters);
        ResponseParser CloseOrderReference(PayWithAmazon.StandardPaymentRequests.CloseOrderReferenceRequest requestParameters);
        ResponseParser ConfirmBillingAgreement(PayWithAmazon.RecurringPaymentRequests.ConfirmBillingAgreementRequest requestParameters);
        ResponseParser ConfirmOrderReference(PayWithAmazon.StandardPaymentRequests.ConfirmOrderReferenceRequest requestParameters);
        ResponseParser CreateOrderReferenceForId(PayWithAmazon.RecurringPaymentRequests.CreateOrderReferenceForIdRequest requestParameters);
        ResponseParser GetAuthorizationDetails(PayWithAmazon.StandardPaymentRequests.GetAuthorizationDetailsRequest requestParameters);
        ResponseParser GetBillingAgreementDetails(PayWithAmazon.RecurringPaymentRequests.GetBillingAgreementDetailsRequest requestParameters);
        ResponseParser GetCaptureDetails(PayWithAmazon.StandardPaymentRequests.GetCaptureDetailsRequest requestParameters);
        string GetConfigValue(string name);
        ResponseParser GetOrderReferenceDetails(PayWithAmazon.StandardPaymentRequests.GetOrderReferenceDetailsRequest requestParameters);
        System.Collections.Generic.IDictionary<string, string> GetParameters();
        ResponseParser GetProviderCreditDetails(PayWithAmazon.ProviderCreditRequests.GetProviderCreditReversalDetailsRequest requestParameters);
        ResponseParser GetProviderCreditReversalDetails(PayWithAmazon.ProviderCreditRequests.GetProviderCreditReversalDetailsRequest requestParameters);
        ResponseParser GetRefundDetails(PayWithAmazon.StandardPaymentRequests.GetRefundDetailsRequest requestParameters);
        ResponseParser GetServiceStatus(PayWithAmazon.CommonRequests.GetServiceStatusRequest requestParameters);
        string GetUserInfo(string accessToken);
        ResponseParser Refund(PayWithAmazon.StandardPaymentRequests.RefundRequest requestParameters);
        ResponseParser ReverseProviderCredit(PayWithAmazon.ProviderCreditRequests.ReverseProviderCreditRequest requestParameters);
        ResponseParser SetBillingAgreementDetails(PayWithAmazon.RecurringPaymentRequests.SetBillingAgreementDetailsRequest requestParameters);
        void SetClientId(string input);
        void SetMwsDevoUrl(string url);
        void SetMwsServiceUrl(string url);
        ResponseParser SetOrderReferenceDetails(PayWithAmazon.StandardPaymentRequests.SetOrderReferenceDetailsRequest requestParameters);
        void SetProxy(string proxy_host = "", int proxy_port = -1, string proxy_user_name = "", string proxy_user_password = "");
        void SetSandbox(bool input);
        void SetTimeStamp(string timeStamp);
        ResponseParser ValidateBillingAgreement(PayWithAmazon.RecurringPaymentRequests.ValidateBillingAgreementRequest requestParameters);
    }
}
