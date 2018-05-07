using System;
using System.Collections;

namespace AmazonPay.Responses
{
    public class ConfirmBillingAgreementResponse : AbstractResponse
    {
        /// <summary>
        /// ConfirmBillingAgreementResponse
        /// </summary>
        public ConfirmBillingAgreementResponse(string xml)
        {
            SetDictionaryAndErrorResponse(xml);
            if (success)
            {
                ParseDictionaryToVariables(this.dictionary);
            }
        }
    }
}
