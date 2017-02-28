using System;
namespace AmazonPay
{
    /// <summary>
    /// Interface class for the AmazonPay Client class
    /// </summary>
    public interface IClient
    {
        AmazonPay.Responses.AuthorizeResponse Authorize(AmazonPay.StandardPaymentRequests.AuthorizeRequest requestParameters);
        AmazonPay.Responses.AuthorizeResponse AuthorizeOnBillingAgreement(AmazonPay.RecurringPaymentRequests.AuthorizeOnBillingAgreementRequest requestParameters);
        AmazonPay.Responses.CancelOrderReferenceResponse CancelOrderReference(AmazonPay.StandardPaymentRequests.CancelOrderReferenceRequest requestParameters);
        AmazonPay.Responses.CaptureResponse Capture(AmazonPay.StandardPaymentRequests.CaptureRequest requestParameters);
        AmazonPay.Responses.AuthorizeResponse Charge(AmazonPay.StandardPaymentRequests.ChargeRequest requestParameters);
        AmazonPay.Responses.CloseAuthorizationResponse CloseAuthorization(AmazonPay.StandardPaymentRequests.CloseAuthorizationRequest requestParameters);
        AmazonPay.Responses.CloseBillingAgreementResponse CloseBillingAgreement(AmazonPay.RecurringPaymentRequests.CloseBillingAgreementRequest requestParameters);
        AmazonPay.Responses.CloseOrderReferenceResponse CloseOrderReference(AmazonPay.StandardPaymentRequests.CloseOrderReferenceRequest requestParameters);
        AmazonPay.Responses.ConfirmBillingAgreementResponse ConfirmBillingAgreement(AmazonPay.RecurringPaymentRequests.ConfirmBillingAgreementRequest requestParameters);
        AmazonPay.Responses.ConfirmOrderReferenceResponse ConfirmOrderReference(AmazonPay.StandardPaymentRequests.ConfirmOrderReferenceRequest requestParameters);
        AmazonPay.Responses.OrderReferenceDetailsResponse CreateOrderReferenceForId(AmazonPay.RecurringPaymentRequests.CreateOrderReferenceForIdRequest requestParameters);
        AmazonPay.Responses.AuthorizeResponse GetAuthorizationDetails(AmazonPay.StandardPaymentRequests.GetAuthorizationDetailsRequest requestParameters);
        AmazonPay.Responses.BillingAgreementDetailsResponse GetBillingAgreementDetails(AmazonPay.RecurringPaymentRequests.GetBillingAgreementDetailsRequest requestParameters);
        AmazonPay.Responses.CaptureResponse GetCaptureDetails(AmazonPay.StandardPaymentRequests.GetCaptureDetailsRequest requestParameters);
        AmazonPay.Responses.OrderReferenceDetailsResponse GetOrderReferenceDetails(AmazonPay.StandardPaymentRequests.GetOrderReferenceDetailsRequest requestParameters);
        AmazonPay.Responses.GetProviderCreditDetailsResponse GetProviderCreditDetails(AmazonPay.ProviderCreditRequests.GetProviderCreditDetailsRequest requestParameters);
        AmazonPay.Responses.GetProviderCreditReversalDetailsResponse GetProviderCreditReversalDetails(AmazonPay.ProviderCreditRequests.GetProviderCreditReversalDetailsRequest requestParameters);
        AmazonPay.Responses.RefundResponse GetRefundDetails(AmazonPay.StandardPaymentRequests.GetRefundDetailsRequest requestParameters);
        AmazonPay.Responses.GetServiceStatusResponse GetServiceStatus(AmazonPay.CommonRequests.GetServiceStatusRequest requestParameters);
        string GetUserInfo(string accessToken);
        AmazonPay.Responses.RefundResponse Refund(AmazonPay.StandardPaymentRequests.RefundRequest requestParameters);
        AmazonPay.Responses.GetProviderCreditReversalDetailsResponse ReverseProviderCredit(AmazonPay.ProviderCreditRequests.ReverseProviderCreditRequest requestParameters);
        AmazonPay.Responses.BillingAgreementDetailsResponse SetBillingAgreementDetails(AmazonPay.RecurringPaymentRequests.SetBillingAgreementDetailsRequest requestParameters);
        AmazonPay.Responses.OrderReferenceDetailsResponse SetOrderReferenceDetails(AmazonPay.StandardPaymentRequests.SetOrderReferenceDetailsRequest requestParameters);
        AmazonPay.Responses.ValidateBillingAgreementResponse ValidateBillingAgreement(AmazonPay.RecurringPaymentRequests.ValidateBillingAgreementRequest requestParameters);
    }
}
