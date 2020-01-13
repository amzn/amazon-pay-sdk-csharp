using System;
namespace AmazonPay.StandardPaymentRequests
{
    /// <summary>
    /// Request class to set the GetOrderReferenceDetails API call parameters
    /// </summary>
    public class GetOrderReferenceDetailsRequest : DelegateRequest<GetOrderReferenceDetailsRequest>
    {
        private string amazon_order_reference_id;
        private string address_consent_token;
        private string access_token;
        
        /// <summary>
        /// Constructor sets the Action variable for the MWS request
        /// </summary>
        public GetOrderReferenceDetailsRequest()
        {
            SetAction(Constants.GetOrderReferenceDetails);
        }

        protected override GetOrderReferenceDetailsRequest GetThis()
        {
            return this;
        }

        /// <summary>
        /// Sets the Amazon Order Reference ID
        /// </summary>
        /// <param name="amazon_order_reference_id"></param>
        /// <returns>GetOrderReferenceDetailsRequest Object</returns>
        public GetOrderReferenceDetailsRequest WithAmazonOrderReferenceId(string amazon_order_reference_id)
        {
            this.amazon_order_reference_id = amazon_order_reference_id;
            return this;
        }

        /// <summary>
        /// Gets the Amazon Order Reference ID
        /// </summary>
        /// <returns>Amazon Order Reference ID</returns>
        public string GetAmazonOrderReferenceId()
        {
            return this.amazon_order_reference_id;
        }
        /// <summary>
        /// Sets the Address Consent Token
        /// </summary>
        /// <param name="address_consent_token"></param>
        /// <returns>GetOrderReferenceDetailsRequest Object</returns>
        [Obsolete("use WithAccessToken instead")]
        public GetOrderReferenceDetailsRequest WithaddressConsentToken(string address_consent_token)
        {
            this.address_consent_token = System.Web.HttpUtility.UrlDecode(address_consent_token);
            return this;
        }

        /// <summary>
        /// Gets the Address Consent Token
        /// </summary>
        /// <returns>Address Consent Token</returns>
        [Obsolete("use GetAccessToken instead")]
        public string GetAddressConsentToken()
        {
            return this.address_consent_token;
        }

        /// <summary>
        /// Sets the Access Token
        /// </summary>
        /// <param name="access_token"></param>
        /// <returns>GetOrderReferenceDetailsRequest Object</returns>
        public GetOrderReferenceDetailsRequest WithAccessToken(string access_token)
        {
            this.access_token = System.Web.HttpUtility.UrlDecode(access_token); // Decode AccessToken from Atza%7CIwEBIJfreMiImhHw6s_C... to Atza|IwEDIJfreMiImhHw6s_C...
            return this;
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
