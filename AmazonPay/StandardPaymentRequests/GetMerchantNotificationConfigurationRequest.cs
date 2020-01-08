namespace AmazonPay.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the GetMerchantNotificationConfiguration API call parameters,
    /// which are inhereted from the DelegateRequest parent object.
    /// </summary>
    public class GetMerchantNotificationConfigurationRequest : DelegateRequest<GetMerchantNotificationConfigurationRequest>
    {

        public GetMerchantNotificationConfigurationRequest()
        {
            SetAction(Constants.GetMerchantNotificationConfiguration);
        }

        protected override GetMerchantNotificationConfigurationRequest GetThis()
        {
            return this;
        }

    }
}
