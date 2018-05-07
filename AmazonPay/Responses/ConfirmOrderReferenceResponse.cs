using System;
using System.Collections;

namespace AmazonPay.Responses
{
    /// <summary>
    /// The output format of the API call response XML will contain the following details
    /// <code>
    /// xmlns="https://mws.amazonservices.com/schema/OffAmazonPayments/2013-01-01">
    /// <ResponseMetadata>
    ///  <RequestId>5f20169b-7ab2-11df-bcef-d35615e2b044</RequestId>
    /// </ResponseMetadata>
    /// </code>
    /// </summary>

    public class ConfirmOrderReferenceResponse : AbstractResponse
    {
        /// <summary>
        /// ConfirmOrderReferenceResponse 
        /// </summary>
        public ConfirmOrderReferenceResponse(string xml)
        {
            SetDictionaryAndErrorResponse(xml);
            if (success)
            {
                ParseDictionaryToVariables(this.dictionary);
            }
        }
    }
}
