using System;
namespace AmazonPay
{
    /// <summary>
    /// Interface class for the AmazonPay Client class
    /// </summary>
    public interface IClient
    {
        Responses.AuthorizeResponse Authorize(StandardPaymentRequests.AuthorizeRequest requestParameters);
        Responses.AuthorizeResponse AuthorizeOnBillingAgreement(RecurringPaymentRequests.AuthorizeOnBillingAgreementRequest requestParameters);
        Responses.CancelOrderReferenceResponse CancelOrderReference(StandardPaymentRequests.CancelOrderReferenceRequest requestParameters);
        Responses.CaptureResponse Capture(StandardPaymentRequests.CaptureRequest requestParameters);
        Responses.AuthorizeResponse Charge(StandardPaymentRequests.ChargeRequest requestParameters);
        Responses.CloseAuthorizationResponse CloseAuthorization(StandardPaymentRequests.CloseAuthorizationRequest requestParameters);
        Responses.CloseBillingAgreementResponse CloseBillingAgreement(RecurringPaymentRequests.CloseBillingAgreementRequest requestParameters);
        Responses.CloseOrderReferenceResponse CloseOrderReference(StandardPaymentRequests.CloseOrderReferenceRequest requestParameters);
        Responses.ConfirmBillingAgreementResponse ConfirmBillingAgreement(RecurringPaymentRequests.ConfirmBillingAgreementRequest requestParameters);
        Responses.ConfirmOrderReferenceResponse ConfirmOrderReference(StandardPaymentRequests.ConfirmOrderReferenceRequest requestParameters);
        Responses.OrderReferenceDetailsResponse CreateOrderReferenceForId(RecurringPaymentRequests.CreateOrderReferenceForIdRequest requestParameters);
        Responses.AuthorizeResponse GetAuthorizationDetails(StandardPaymentRequests.GetAuthorizationDetailsRequest requestParameters);
        Responses.BillingAgreementDetailsResponse GetBillingAgreementDetails(RecurringPaymentRequests.GetBillingAgreementDetailsRequest requestParameters);
        Responses.CaptureResponse GetCaptureDetails(StandardPaymentRequests.GetCaptureDetailsRequest requestParameters);
        Responses.OrderReferenceDetailsResponse GetOrderReferenceDetails(StandardPaymentRequests.GetOrderReferenceDetailsRequest requestParameters);
        Responses.GetProviderCreditDetailsResponse GetProviderCreditDetails(ProviderCreditRequests.GetProviderCreditDetailsRequest requestParameters);
        Responses.GetProviderCreditReversalDetailsResponse GetProviderCreditReversalDetails(ProviderCreditRequests.GetProviderCreditReversalDetailsRequest requestParameters);
        Responses.RefundResponse GetRefundDetails(StandardPaymentRequests.GetRefundDetailsRequest requestParameters);
        Responses.GetServiceStatusResponse GetServiceStatus(CommonRequests.GetServiceStatusRequest requestParameters);
        string GetUserInfo(string accessToken);
        Responses.RefundResponse Refund(StandardPaymentRequests.RefundRequest requestParameters);
        Responses.GetProviderCreditReversalDetailsResponse ReverseProviderCredit(ProviderCreditRequests.ReverseProviderCreditRequest requestParameters);
        Responses.BillingAgreementDetailsResponse SetBillingAgreementDetails(RecurringPaymentRequests.SetBillingAgreementDetailsRequest requestParameters);
        Responses.OrderReferenceDetailsResponse SetOrderReferenceDetails(StandardPaymentRequests.SetOrderReferenceDetailsRequest requestParameters);
        Responses.OrderReferenceDetailsResponse SetOrderAttributes(StandardPaymentRequests.SetOrderAttributesRequest requestParameters);
        Responses.PaymentDetailsResponse GetPaymentDetails(String amazonOrderReferenceID, String mwsAuthToken);
        Responses.ValidateBillingAgreementResponse ValidateBillingAgreement(RecurringPaymentRequests.ValidateBillingAgreementRequest requestParameters);
        Responses.GetMerchantAccountStatusResponse GetMerchantAccountStatus(StandardPaymentRequests.GetMerchantAccountStatusRequest requestParameters);
    }
}
