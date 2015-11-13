using System;
namespace PayWithAmazon
{
    /// <summary>
    /// Interface class for the PayWithAmazon Client class
    /// </summary>
    public interface IClient
    {
        PayWithAmazon.Responses.AuthorizeResponse Authorize(PayWithAmazon.StandardPaymentRequests.AuthorizeRequest requestParameters);
        PayWithAmazon.Responses.AuthorizeResponse AuthorizeOnBillingAgreement(PayWithAmazon.RecurringPaymentRequests.AuthorizeOnBillingAgreementRequest requestParameters);
        PayWithAmazon.Responses.CancelOrderReferenceResponse CancelOrderReference(PayWithAmazon.StandardPaymentRequests.CancelOrderReferenceRequest requestParameters);
        PayWithAmazon.Responses.CaptureResponse Capture(PayWithAmazon.StandardPaymentRequests.CaptureRequest requestParameters);
        PayWithAmazon.Responses.AuthorizeResponse Charge(PayWithAmazon.StandardPaymentRequests.ChargeRequest requestParameters);
        PayWithAmazon.Responses.CloseAuthorizationResponse CloseAuthorization(PayWithAmazon.StandardPaymentRequests.CloseAuthorizationRequest requestParameters);
        PayWithAmazon.Responses.CloseBillingAgreementResponse CloseBillingAgreement(PayWithAmazon.RecurringPaymentRequests.CloseBillingAgreementRequest requestParameters);
        PayWithAmazon.Responses.CloseOrderReferenceResponse CloseOrderReference(PayWithAmazon.StandardPaymentRequests.CloseOrderReferenceRequest requestParameters);
        PayWithAmazon.Responses.ConfirmBillingAgreementResponse ConfirmBillingAgreement(PayWithAmazon.RecurringPaymentRequests.ConfirmBillingAgreementRequest requestParameters);
        PayWithAmazon.Responses.ConfirmOrderReferenceResponse ConfirmOrderReference(PayWithAmazon.StandardPaymentRequests.ConfirmOrderReferenceRequest requestParameters);
        PayWithAmazon.Responses.OrderReferenceDetailsResponse CreateOrderReferenceForId(PayWithAmazon.RecurringPaymentRequests.CreateOrderReferenceForIdRequest requestParameters);
        PayWithAmazon.Responses.AuthorizeResponse GetAuthorizationDetails(PayWithAmazon.StandardPaymentRequests.GetAuthorizationDetailsRequest requestParameters);
        PayWithAmazon.Responses.BillingAgreementDetailsResponse GetBillingAgreementDetails(PayWithAmazon.RecurringPaymentRequests.GetBillingAgreementDetailsRequest requestParameters);
        PayWithAmazon.Responses.CaptureResponse GetCaptureDetails(PayWithAmazon.StandardPaymentRequests.GetCaptureDetailsRequest requestParameters);
        PayWithAmazon.Responses.OrderReferenceDetailsResponse GetOrderReferenceDetails(PayWithAmazon.StandardPaymentRequests.GetOrderReferenceDetailsRequest requestParameters);
        PayWithAmazon.Responses.GetProviderCreditDetailsResponse GetProviderCreditDetails(PayWithAmazon.ProviderCreditRequests.GetProviderCreditDetailsRequest requestParameters);
        PayWithAmazon.Responses.GetProviderCreditReversalDetailsResponse GetProviderCreditReversalDetails(PayWithAmazon.ProviderCreditRequests.GetProviderCreditReversalDetailsRequest requestParameters);
        PayWithAmazon.Responses.RefundResponse GetRefundDetails(PayWithAmazon.StandardPaymentRequests.GetRefundDetailsRequest requestParameters);
        PayWithAmazon.Responses.GetServiceStatusResponse GetServiceStatus(PayWithAmazon.CommonRequests.GetServiceStatusRequest requestParameters);
        string GetUserInfo(string accessToken);
        PayWithAmazon.Responses.RefundResponse Refund(PayWithAmazon.StandardPaymentRequests.RefundRequest requestParameters);
        PayWithAmazon.Responses.GetProviderCreditReversalDetailsResponse ReverseProviderCredit(PayWithAmazon.ProviderCreditRequests.ReverseProviderCreditRequest requestParameters);
        PayWithAmazon.Responses.BillingAgreementDetailsResponse SetBillingAgreementDetails(PayWithAmazon.RecurringPaymentRequests.SetBillingAgreementDetailsRequest requestParameters);
        PayWithAmazon.Responses.OrderReferenceDetailsResponse SetOrderReferenceDetails(PayWithAmazon.StandardPaymentRequests.SetOrderReferenceDetailsRequest requestParameters);
        PayWithAmazon.Responses.ValidateBillingAgreementResponse ValidateBillingAgreement(PayWithAmazon.RecurringPaymentRequests.ValidateBillingAgreementRequest requestParameters);
    }
}
