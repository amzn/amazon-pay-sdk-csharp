using System;
using System.Collections;

namespace AmazonPay.Responses
{
    public class CancelOrderReferenceResponse : AbstractResponse
    {
    
        /// <summary>
        /// CancelOrderreferenceResponse
        /// </summary>
        /// <param name="xml"></param>
        public CancelOrderReferenceResponse(string xml)
        {
            SetDictionaryAndErrorResponse(xml);
            if (success)
            {
                ParseDictionaryToVariables(this.dictionary);
            }   
        }
    }
}
