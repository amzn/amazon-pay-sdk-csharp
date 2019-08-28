namespace AmazonPay.Types
{
    /// <summary>
    /// This enum class represents region codes for United States(na), Europe(eu) and Japan(jp).
    /// 
    /// The region value is used while constructing the mandatory headers.
    /// </summary>
    public enum BillingAgreementTypes
    {
        CustomerInitiatedTransaction, MerchantInitiatedTransaction
    }
}