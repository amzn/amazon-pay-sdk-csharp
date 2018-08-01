namespace AmazonPay.Responses
{
    public enum Operator
    {
        //Common to responses
        RequestId, Amount, CurrencyCode, ReasonCode, ReasonDescription, State, SoftDescriptor, 
        LastUpdateTimestamp, CreationTimestamp, member,

        //CaptureResponse
        AmazonCaptureId, SellerCaptureNote, CaptureReferenceId, CaptureAmount, RefundedAmount, CaptureFee, 
        ConvertedAmount, ConversionRate,  IdList, ProviderCreditSummaryList, ProviderId, ProviderSellerId, ProviderCreditId, 
        
        //AuthorizeResponse.cs
        AmazonOrderReferenceId, AmazonAuthorizationId, SellerAuthorizationNote, ExpirationTimestamp, AuthorizationReferenceId,
        AuthorizationAmount, CapturedAmount, AuthorizationFee, SoftDecline, CaptureNow, 
        
        //BillingAgreementDetailsResponse
        AmazonBillingAgreementId, TimePeriodStartDate, TimePeriodEndDate, LastUpdatedTimestamp, AmountLimitPerTimePeriod, 
        CurrentRemainingBalance, SellerNote, PlatformId, PostalCode, Name, Type, Id, Email, Phone, CountryCode, StateOrRegion, 
        AddressLine1, AddressLine2, AddressLine3, City, County, District, DestinationType, ReleaseEnvironment, SellerOrderId, 
        SellerBillingAgreementId, CustomInformation, StoreName, Constraint, ConstraintID, Description, BillingAddress, Buyer,

        //ChargebackResponse
        AmazonChargebackId,  AmazonCaptureReferenceId, ChargebackReason, ChargebackState,

        //GetProviderCreditDetailsResponse
        AmazonProviderCreditId, CreditReferenceId, CreditAmount, CreditReversalAmount, SellerId,

        //GetProviderCreditReversalDetailsResponse
        AmazonProviderCreditReversalId, CreditReversalNote, CreditReversalReferenceId,

        //GetServiceStatusResponse
        Status, Timestamp,

        //OrderReferenceDetailsResponse
        FullDescriptor, isAmazonBalanceFirst, OrderLanguage, RequestPaymentAuthorization, PaymentServiceProviderId, 
        PaymentServiceProviderOrderId, OrderItemCategory, SupplementaryData,
        
        //GetMerchantAccountStatusResponse
        AccountStatus,

        //RefundResponse
        AmazonRefundId, SellerRefundNote, RefundReferenceId, RefundAmount, FeeRefunded, RefundType,
        ProviderCreditReversalSummaryList, ProviderCreditReversalId,

        //ValidateBillingAgreementResponse
        ValidationResult, FailureReasonCode
    }
}
