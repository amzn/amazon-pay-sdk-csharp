using System;
using System.Collections.Generic;
using System.Text;
using System.Globalization;

namespace AmazonPay.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the GetOrderReferenceDetails API call parameters
    /// </summary>
    public class ListOrderReferenceRequest : DelegateRequest<ListOrderReferenceRequest>
    {
        private string query_id;
        private string query_id_type;
        private int page_size;
        private string created_start_time;
        private string created_end_time;
        private string access_token;
        private string payment_domain;

        /// <summary>
        /// Constructor sets the Action variable for the MWS request
        /// </summary>
        public ListOrderReferenceRequest()
        {
            SetAction(Constants.ListOrderReference);
        }

        protected override ListOrderReferenceRequest GetThis()
        {
            return this;
        }

        /// <summary>
        /// Sets the Unique query ID for this request
        /// </summary>
        /// <param name="query_id"></param>
        /// <returns>ListOrderReferenceRequest Object</returns>
        public ListOrderReferenceRequest WithQueryId(string query_id)
        {
            this.query_id = query_id;
            return this;
        }

        /// <summary>
        /// Sets the Query Id Type for this request (merchant order id)
        /// </summary>
        /// <param name="query_id_type"></param>
        /// <returns>ListOrderReferenceRequest Object</returns>
        public ListOrderReferenceRequest WithQueryIdType(string query_id_type)
        {
            this.query_id_type = query_id_type;
            return this;
        }

        /// <summary>
        /// Sets the Page Size for this request (number of orders per page)
        /// </summary>
        /// <param name="page_size"></param>
        /// <returns>ListOrderReferenceRequest Object</returns>
        public ListOrderReferenceRequest WithPageSize(int page_size)
        {
            this.page_size = page_size;
            return this;
        }

        /// <summary>
        /// Sets the start date boundary for search request
        /// </summary>
        /// <param name="created_start_time"></param>
        /// <returns>ListOrderReferenceRequest Object</returns>
        public ListOrderReferenceRequest WithCreatedStartTime(DateTime created_start_time)
        {
            this.created_start_time = created_start_time.ToString("o");
            return this;
        }

        /// <summary>
        /// Sets the end date boundary for search request
        /// </summary>
        /// <param name="created_end_time"></param>
        /// <returns>ListOrderReferenceRequest Object</returns>
        public ListOrderReferenceRequest WithCreatedEndTime(DateTime created_end_time)
        {
            this.created_end_time = created_end_time.ToString("o");
            return this;
        }

        /// <summary>
        /// Sets the Access Token
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns>GetOrderReferenceDetailsRequest Object</returns>
        public ListOrderReferenceRequest WithAccessToken(string access_token)
        {
            this.access_token = System.Web.HttpUtility.UrlDecode(access_token); // Decode AccessToken from Atza%7CIwEBIJfreMiImhHw6s_C... to Atza|IwEDIJfreMiImhHw6s_C...
            return this;
        }

        /// <summary>
        /// Sets the Payment Domain
        /// </summary>
        /// <param name="payment_domain"></param>
        /// <returns>GetOrderReferenceDetailsRequest Object</returns>
        public ListOrderReferenceRequest WithPaymentDomain(string payment_domain)
        {
            this.payment_domain = payment_domain;
            return this;
        }

        /// <summary>
        /// Gets the Unique query ID from this request
        /// </summary>
        /// <param name="query_id"></param>
        /// <returns>string query_id</returns>
        public string GetQueryId()
        {
            return this.query_id;
        }

        /// <summary>
        /// Gets the Query Id Type from this request (merchant order id)
        /// </summary>
        /// <param name="query_id_type"></param>
        /// <returns>string query_id_type</returns>
        public string GetQueryIdType()
        {
            return this.query_id_type;
        }

        /// <summary>
        /// Gets the Page Size from this request (number of orders per page)
        /// </summary>
        /// <param name="page_size"></param>
        /// <returns>int page_size</returns>
        public int GetPageSize()
        {
            return this.page_size;
        }

        /// <summary>
        /// Gets the start date boundary from search request
        /// </summary>
        /// <param name="created_start_time"></param>
        /// <returns>DateTime created_start_time</returns>
        public string GetCreatedStartTime()
        {
            return this.created_start_time;
        }

        /// <summary>
        /// Gets the end date boundary from search request
        /// </summary>
        /// <param name="created_end_time"></param>
        /// <returns>ListOrderReferenceRequest Object</returns>
        public string GetCreatedEndTime()
        {
            return this.created_end_time;
        }

        /// <summary>
        /// Gets the Payment Domain from this request
        /// </summary>
        /// <param name="payment_domain"></param>
        /// <returns>int payment_domain</returns>
        public string GetPaymentDomain()
        {
            return this.payment_domain;
        }

        /// <summary>
        /// Gets the Access Token
        /// </summary>
        /// <returns>Access Token</returns>
        public string GetAccessToken()
        {
            return this.access_token;
        }
    }
}
