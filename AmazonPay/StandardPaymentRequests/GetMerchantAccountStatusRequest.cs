using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonPay.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the GetMerchantAccountStatus API call parameters
    /// </summary>
    public class GetMerchantAccountStatusRequest : DelegateRequest<GetMerchantAccountStatusRequest>
    {
        public GetMerchantAccountStatusRequest()
        {
            SetAction(Constants.GetMerchantAccountStatus);
        }

        protected override GetMerchantAccountStatusRequest GetThis()
        {
            return this;
        }
    }
}
