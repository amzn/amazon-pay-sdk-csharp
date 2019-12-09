using System;
using System.Collections;

namespace AmazonPay.Responses
{

    public class SetMerchantNotificationConfigurationResponse : AbstractResponse
    {
        /// <summary>
        /// SetMerchantNotificationConfigurationResponse 
        /// </summary>
        public SetMerchantNotificationConfigurationResponse(string xml)
        {
            SetDictionaryAndErrorResponse(xml);
            if (success)
            {
                ParseDictionaryToVariables(this.dictionary);
            }
        }
    }
}
