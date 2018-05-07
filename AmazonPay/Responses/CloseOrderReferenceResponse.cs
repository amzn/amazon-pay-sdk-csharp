using System;
using System.Collections;

namespace AmazonPay.Responses
{
    public class CloseOrderReferenceResponse : AbstractResponse
    {
        /// <summary>
        /// CloseOrderReferenceResponse
        /// </summary>
        public CloseOrderReferenceResponse(string xml)
        {
            SetDictionaryAndErrorResponse(xml);
            if (success)
            {
                ParseDictionaryToVariables(this.dictionary);
            }
        }
    }
}
