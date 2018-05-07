using System;
using System.Collections;

namespace AmazonPay.Responses
{
    public class CloseBillingAgreementResponse : AbstractResponse
    {
        /// <summary>
        /// CloseBillingAgreementResponse
        /// </summary>
        public CloseBillingAgreementResponse(string xml)
        {
            SetDictionaryAndErrorResponse(xml);
            if (success)
            {
                ParseDictionaryToVariables(this.dictionary);
            }
        }
    }
}
