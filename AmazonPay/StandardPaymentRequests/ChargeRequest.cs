using System;
using AmazonPay.RecurringPaymentRequests;
using System.IO;


namespace AmazonPay.StandardPaymentRequests
{
    /// <summary>
    /// Request class to take the Charge convenience Method parameters and construct the appropriate API call request objects
    /// </summary>
    public class ChargeRequest
    {
        public GetOrderReferenceDetailsRequest getOrderReferenceDetails;
        public SetOrderReferenceDetailsRequest setOrderReferenceDetails;
        public ConfirmOrderReferenceRequest confirmOrderReference;
        public AuthorizeRequest authorizeOrderReference;

        public string chargeType = "";


        public GetBillingAgreementDetailsRequest getBillingAgreementDetails;
        public SetBillingAgreementDetailsRequest setBillingAgreementDetails;
        public ConfirmBillingAgreementRequest confirmBillingAgreement;
        public AuthorizeOnBillingAgreementRequest authorizeOnBillingAgreement;

        /// <summary>
        /// constructor initializes the required API request objects
        /// </summary>
        public ChargeRequest()
        {
            getOrderReferenceDetails = new GetOrderReferenceDetailsRequest();
            setOrderReferenceDetails = new SetOrderReferenceDetailsRequest();
            confirmOrderReference = new ConfirmOrderReferenceRequest();
            authorizeOrderReference = new AuthorizeRequest();

            getBillingAgreementDetails = new GetBillingAgreementDetailsRequest();
            setBillingAgreementDetails = new SetBillingAgreementDetailsRequest();
            confirmBillingAgreement = new ConfirmBillingAgreementRequest();
            authorizeOnBillingAgreement = new AuthorizeOnBillingAgreementRequest();
        }

        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>ChargeRequest</returns>
        public ChargeRequest WithMerchantId(string merchant_id)
        {
            switch (chargeType)
            {
                case "OrderReference":
                    getOrderReferenceDetails.WithMerchantId(merchant_id);
                    setOrderReferenceDetails.WithMerchantId(merchant_id);
                    confirmOrderReference.WithMerchantId(merchant_id);
                    authorizeOrderReference.WithMerchantId(merchant_id);
                    break;
                case "BillingAgreement":
                    getBillingAgreementDetails.WithMerchantId(merchant_id);
                    setBillingAgreementDetails.WithMerchantId(merchant_id);
                    confirmBillingAgreement.WithMerchantId(merchant_id);
                    authorizeOnBillingAgreement.WithMerchantId(merchant_id);
                    break;
            }
            return this;
        }

        /// <summary>
        /// Sets the Amazon Order Reference ID / Amazon Billing Agreement ID
        /// </summary>
        /// <param name="amazon_reference_id"></param>
        /// <returns>ChargeRequest</returns>
        public ChargeRequest WithAmazonReferenceId(string amazon_reference_id)
        {
            if (!string.IsNullOrEmpty(amazon_reference_id))
            {
                string switchChar = amazon_reference_id;
                switch (switchChar[0])
                {
                    case 'P':
                    case 'S':
                        chargeType = "OrderReference";
                        getOrderReferenceDetails.WithAmazonOrderReferenceId(amazon_reference_id);
                        setOrderReferenceDetails.WithAmazonOrderReferenceId(amazon_reference_id);
                        confirmOrderReference.WithAmazonOrderReferenceId(amazon_reference_id);
                        authorizeOrderReference.WithAmazonOrderReferenceId(amazon_reference_id);
                        break;
                    case 'B':
                    case 'C':
                        chargeType = "BillingAgreement";
                        getBillingAgreementDetails.WithAmazonBillingAgreementId(amazon_reference_id);
                        setBillingAgreementDetails.WithAmazonBillingAgreementId(amazon_reference_id);
                        confirmBillingAgreement.WithAmazonBillingAgreementId(amazon_reference_id);
                        authorizeOnBillingAgreement.WithAmazonBillingAgreementId(amazon_reference_id);
                        break;
                    default:
                        throw new InvalidDataException("Invalid Amazon Reference ID");
                }
            }
            else
            {
                throw new MissingFieldException("Amazon Reference ID is a required field and should be a Order Reference ID / Billing Agreement ID");
            }

            return this;
        }

        /// <summary>
        /// Sets the amount
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>ChargeRequest</returns>
        public ChargeRequest WithAmount(decimal amount)
        {
            switch (chargeType)
            {
                case "OrderReference":
                    setOrderReferenceDetails.WithAmount(amount);
                    authorizeOrderReference.WithAmount(amount);
                    break;
                case "BillingAgreement":
                    authorizeOnBillingAgreement.WithAmount(amount);
                    break;
            }
            return this;
        }

        /// <summary>
        /// Sets the Currency Code
        /// </summary>
        /// <param name="currency_code"></param>
        /// <returns>ChargeRequest</returns>
        public ChargeRequest WithCurrencyCode(Enum currency_code)
        {
            switch (chargeType)
            {
                case "OrderReference":
                    setOrderReferenceDetails.WithCurrencyCode(currency_code);
                    authorizeOrderReference.WithCurrencyCode(currency_code);
                    break;
                case "BillingAgreement":
                    authorizeOnBillingAgreement.WithCurrencyCode(currency_code);
                    break;
            }
            return this;
        }

        /// <summary>
        /// Sets the Authorization Reference ID - Unique string
        /// </summary>
        /// <param name="charge_reference_id"></param>
        /// <returns>ChargeRequest</returns>
        public ChargeRequest WithChargeReferenceId(string charge_reference_id)
        {
            switch (chargeType)
            {
                case "OrderReference":
                    authorizeOrderReference.WithAuthorizationReferenceId(charge_reference_id);
                    break;
                case "BillingAgreement":
                    authorizeOnBillingAgreement.WithAuthorizationReferenceId(charge_reference_id);
                    break;
            }
            return this;
        }

        /// <summary>
        /// Sets the Seller Note, Seller Authorization Note for Amazon Order Reference ID / Amazon Billing Agreement ID
        /// </summary>
        /// <param name="charge_note"></param>
        /// <returns>ChargeRequest</returns>
        public ChargeRequest WithChargeNote(string charge_note)
        {
            switch (chargeType)
            {
                case "OrderReference":
                    setOrderReferenceDetails.WithSellerNote(charge_note);
                    authorizeOrderReference.WithSellerAuthorizationNote(charge_note);
                    break;
                case "BillingAgreement":
                    authorizeOnBillingAgreement.WithSellerAuthorizationNote(charge_note);
                    authorizeOnBillingAgreement.WithSellerNote(charge_note);
                    break;
            }
            return this;
        }

        /// <summary>
        /// Sets th Transaction Timeout for the Authorize API call
        /// </summary>
        /// <param name="transaction_timeout"></param>
        /// <returns>ChargeRequest</returns>
        public ChargeRequest WithTransactionTimeout(int? transaction_timeout)
        {
            switch (chargeType)
            {
                case "OrderReference":
                    authorizeOrderReference.WithTransactionTimeout(transaction_timeout);
                    break;
                case "BillingAgreement":
                    authorizeOnBillingAgreement.WithTransactionTimeout(transaction_timeout);
                    break;
            }
            return this;
        }

        /// <summary>
        /// Sets the Capture Now.
        /// The accepted values are true, false and null.
        /// </summary>
        /// <param name="capture_now"></param>
        /// <returns>ChargeRequest</returns>
        public ChargeRequest WithCaptureNow(bool? capture_now)
        {
            switch (chargeType)
            {
                case "OrderReference":
                    authorizeOrderReference.WithCaptureNow(capture_now);
                    break;
                case "BillingAgreement":
                    authorizeOnBillingAgreement.WithCaptureNow(capture_now);
                    break;
            }
            return this;
        }

        /// <summary>
        /// Sets the boolean value of the Inherit Shipping Address
        /// </summary>
        /// <param name="inherit_shipping_address"></param>
        /// <returns>ChargeRequest</returns>
        public ChargeRequest WithInheritShippingAddress(bool inherit_shipping_address = true)
        {
            authorizeOnBillingAgreement.WithInheritShippingAddress(inherit_shipping_address);
            return this;
        }

        /// <summary>
        /// Sets the Seller Order ID
        /// </summary>
        /// <param name="charge_order_id"></param>
        /// <returns>ChargeRequest</returns>
        public ChargeRequest WithChargeOrderId(string charge_order_id)
        {
            switch (chargeType)
            {
                case "OrderReference":
                    setOrderReferenceDetails.WithSellerOrderId(charge_order_id);
                    break;
                case "BillingAgreement":
                    setBillingAgreementDetails.WithSellerBillingAgreementId(charge_order_id);
                    authorizeOnBillingAgreement.WithSellerOrderId(charge_order_id);
                    break;
            }
            return this;
        }

        /// <summary>
        /// Set the Store Name
        /// </summary>
        /// <param name="store_name"></param>
        /// <returns>ChargeRequest</returns>
        public ChargeRequest WithStoreName(string store_name)
        {
            switch (chargeType)
            {
                case "OrderReference":
                    setOrderReferenceDetails.WithStoreName(store_name);
                    break;
                case "BillingAgreement":
                    setBillingAgreementDetails.WithStoreName(store_name);
                    authorizeOnBillingAgreement.WithStoreName(store_name);
                    break;
            }
            return this;
        }

        /// <summary>
        /// Sets the Custom Information
        /// </summary>
        /// <param name="custom_information"></param>
        /// <returns>ChargeRequest</returns>
        public ChargeRequest WithCustomInformation(string custom_information)
        {
            switch (chargeType)
            {
                case "OrderReference":
                    setOrderReferenceDetails.WithCustomInformation(custom_information);
                    break;
                case "BillingAgreement":
                    setBillingAgreementDetails.WithCustomInformation(custom_information);
                    authorizeOnBillingAgreement.WithCustomInformation(custom_information);
                    break;
            }
            return this;
        }

        /// <summary>
        /// Sets the Platform ID
        /// </summary>
        /// <param name="platform_id"></param>
        /// <returns>ChargeRequest</returns>
        public ChargeRequest WithPlatformId(string platform_id)
        {
            switch (chargeType)
            {
                case "OrderReference":
                    setOrderReferenceDetails.WithPlatformId(platform_id);
                    break;
                case "BillingAgreement":
                    setBillingAgreementDetails.WithPlatformId(platform_id);
                    authorizeOnBillingAgreement.WithPlatformId(platform_id);
                    break;
            }
            return this;
        }

        /// <summary>
        /// Sets the Soft Descriptor
        /// </summary>
        /// <param name="soft_descriptor"></param>
        /// <returns>ChargeRequest</returns>
        public ChargeRequest WithSoftDescriptor(string soft_descriptor)
        {
            switch (chargeType)
            {
                case "OrderReference":
                    authorizeOrderReference.WithSoftDescriptor(soft_descriptor);
                    break;
                case "BillingAgreement":
                    authorizeOnBillingAgreement.WithSoftDescriptor(soft_descriptor);
                    break;
            }
            return this;
        }

        /// <summary>
        /// Sets the Provider Credit Details
        /// </summary>
        /// <param name="provider_id"></param>
        /// <param name="amount"></param>
        /// <param name="currency_code"></param>
        /// <returns>ChargeRequest</returns>
        public ChargeRequest WithProviderCreditDetails(string provider_id, decimal amount, string currency_code)
        {
            authorizeOrderReference.WithProviderCreditDetails(provider_id, amount, currency_code);
            return this;
        }

        /// <summary>
        /// Sets the MWS Auth Token 
        /// </summary>
        /// <param name="mws_auth_token"></param>
        /// <returns>ChargeRequest</returns>
        public ChargeRequest WithMWSAuthToken(string mws_auth_token)
        {
            switch (chargeType)
            {
                case "OrderReference":
                    getOrderReferenceDetails.WithMWSAuthToken(mws_auth_token);
                    setOrderReferenceDetails.WithMWSAuthToken(mws_auth_token);
                    confirmOrderReference.WithMWSAuthToken(mws_auth_token);
                    authorizeOrderReference.WithMWSAuthToken(mws_auth_token);
                    break;
                case "BillingAgreement":
                    getBillingAgreementDetails.WithMWSAuthToken(mws_auth_token);
                    setBillingAgreementDetails.WithMWSAuthToken(mws_auth_token);
                    confirmBillingAgreement.WithMWSAuthToken(mws_auth_token);
                    authorizeOnBillingAgreement.WithMWSAuthToken(mws_auth_token);
                    break;
            }
            return this;
        }
    }
}
