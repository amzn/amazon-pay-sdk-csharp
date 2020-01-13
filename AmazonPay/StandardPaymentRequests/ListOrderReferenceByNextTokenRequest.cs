using System;
using System.Collections.Generic;
using System.Text;

namespace AmazonPay.StandardPaymentRequests
{
    public class ListOrderReferenceByNextTokenRequest : DelegateRequest<ListOrderReferenceByNextTokenRequest>
    {
        private string next_page_token;

        /// <summary>
        /// Constructor sets the Action variable for the MWS request
        /// </summary>
        public ListOrderReferenceByNextTokenRequest()
        {
            SetAction(Constants.ListOrderReferenceByNextToken);
        }
        protected override ListOrderReferenceByNextTokenRequest GetThis()
        {
            return this;
        }

        /// <summary>
        /// Sets the Token for the next page of results
        /// </summary>
        /// <param name="query_id"></param>
        /// <returns>ListOrderReferenceRequest Object</returns>
        public ListOrderReferenceByNextTokenRequest WithNextPageToken(string next_page_token)
        {
            this.next_page_token = next_page_token;
            return this;
        }

        /// <summary>
        /// Gets the Token for the next page of results
        /// </summary>
        /// <param name="query_id"></param>
        /// <returns>ListOrderReferenceRequest Object</returns>
        public string GetNextPageToken()
        {
            return this.next_page_token;
        }
    }
}
