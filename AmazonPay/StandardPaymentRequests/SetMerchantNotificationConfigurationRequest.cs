using System;
using System.Collections.Generic;

namespace AmazonPay.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the SetMerchantNotificationConfigurationRequest API call parameters
    /// </summary>
    public class SetMerchantNotificationConfigurationRequest : DelegateRequest<SetMerchantNotificationConfigurationRequest>
    {
        private Dictionary<string, List<Constants.URLEventTypes>> merchant_notification_urls;

        public SetMerchantNotificationConfigurationRequest()
        {
            SetAction(Constants.SetMerchantNotificationConfiguration);
        }

        protected override SetMerchantNotificationConfigurationRequest GetThis()
        {
            return this;
        }

        /// <summary>
        /// Sets the notification URLs object (Dictionary <string> url, List<Constants.URLEventTypes> Event types
        /// </summary>
        /// <param name="notification_urls"></param>
        /// <returns>SetMerchantNotificationConfigurationRequest Object</returns>
        public SetMerchantNotificationConfigurationRequest WithMerchantNotificationUrls(Dictionary<string, List<Constants.URLEventTypes>> notification_urls)
        {
            this.merchant_notification_urls = notification_urls;
            return this;
        }

        /// <summary>
        /// Returns the MerchantNotificationUrls Configuration
        /// </summary>
        /// <returns>Dictionary<string, List<Constants.URLEventTypes>></returns>
        public Dictionary<string, List<Constants.URLEventTypes>> GetMerchantNotificationUrls()
        {
            return this.merchant_notification_urls;
        }
    }
}
