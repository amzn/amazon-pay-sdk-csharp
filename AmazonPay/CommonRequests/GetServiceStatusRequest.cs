using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AmazonPay.CommonRequests
{
    /// <summary>
    /// Set the GetServiceStatus API call parameters
    /// </summary>
    public class GetServiceStatusRequest : DelegateRequest<GetServiceStatusRequest>
    {
        public GetServiceStatusRequest()
        {
            SetAction(Constants.GetServiceStatus);
        }

        protected override GetServiceStatusRequest GetThis()
        {
            return this;
        }
    }
}
