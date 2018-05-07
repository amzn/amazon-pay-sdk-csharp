using System;
using System.Collections;

namespace AmazonPay.Responses
{
    public class CloseAuthorizationResponse : AbstractResponse
    {
        /// <summary>
        /// CloseAuthorizationResponse 
        /// </summary>
        public CloseAuthorizationResponse(string xml)
        {
            SetDictionaryAndErrorResponse(xml);
            if (success)
            {
                ParseDictionaryToVariables(this.dictionary);
            }
        }
    }
}
