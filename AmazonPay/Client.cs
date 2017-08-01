using System;
using System.Reflection;
using System.Web;
using System.Net;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Globalization;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Collections;
using System.Xml;
using Newtonsoft.Json;
using AmazonPay.StandardPaymentRequests;
using AmazonPay.Responses;
using AmazonPay.ProviderCreditRequests;
using AmazonPay.RecurringPaymentRequests;
using AmazonPay.CommonRequests;
using Common.Logging;

namespace AmazonPay
{
    /// <summary>
    /// Class Client
    /// Takes configuration information
    /// Makes API calls to MWS forAmazon Pay
    /// returns Request Object
    /// </summary>
    public class Client : IClient
    {

        private Dictionary<string, string> parameters = new Dictionary<string, string>();
        private string mwsTestUrl = string.Empty;
        private string timeStamp = string.Empty;
        private Signature signatureObject;
        private Configuration clientConfig = null;
        private readonly string aud = "aud";

        /// <summary>
        ///  Common Looger Property
        /// </summary>
        public ILog Logger { private get; set; }

        // Final URL to where the API parameters POST done,based off the config["region"] and respective mwsServiceUrls
        private string mwsServiceUrl = null;
            
        /// <summary>
        /// Takes the Configuration Object of the Configuration class
        /// </summary>
        /// <param name="clientConfig"></param>
        /// <example>
        ///  <code>
        ///  Configuration clientConfig = new Configuration();
        ///  
        ///  // Required
        ///  clientConfig.WithMerchantId("merchant_id","MERCHANT_ID");
        ///  // Following keys can be found in your seller central account.
        ///  clientConfig.WithSecretKey("MWS_SECRET_KEY"); 
        ///  clientConfig.WithAccessKey("MWS_ACCESS_KEY");
        ///  clientConfig.WithRegion(Regions.supportedRegions.us);
        ///  
        ///  // Optional
        ///  clientConfig.WithCurrencyCode(Regions.currencyCode.USD);
        ///  clientConfig.WithSandbox(false); // true for sandbox , Defaults to false
        ///  clientConfig.WithPlatformId("PLATFORM_ID"); // Solution Provider ID
        ///  clientConfig.WithCABundleFile("CA_BUNDLE_PATH");
        ///  clientConfig.WithApplicationName("CUSTOM_APPLICATION_NAME");
        ///  clientConfig.WithApplicationVersion("CUSTOM_APPLICATION_VERSION");
        ///  clientConfig.WithProxyHost("PROXY_HOST");
        ///  clientConfig.WithProxyPort(1234);
        ///  clientConfig.WithProxyUserName("PROXY_USERNAME");
        ///  clientConfig.WithProxyPassword("PROXY_PASSWORD");
        ///  clientConfig.WithClientId("amzn.oa2.client.xxxx"); 
        ///  clientConfig.WithAutoRetryOnThrottle(true); // Defaults to true
        ///  </code>
        /// </example>
        public Client(Configuration clientConfig)
        {
            if (clientConfig == null)
            {
                throw new NullReferenceException("config is null");
            }

            this.clientConfig = clientConfig;
        }

        /// <summary>
        /// Takes user configuration from the JSON file path provided and convert it to Hashtable config
        /// Validates the user configuration Hashtable against existing config Hashtable
        /// </summary>
        /// <param name="jsonFilePath"></param>
        public Client(string jsonFilePath)
        {
            string json;
            if (!string.IsNullOrEmpty(jsonFilePath))
            {
                if (!File.Exists(@jsonFilePath))
                {
                    throw new FileNotFoundException("File not found");
                }
                else
                {
                    using (StreamReader r = new StreamReader(@jsonFilePath))
                    {
                        json = r.ReadToEnd();
                    }
                    this.clientConfig = new Configuration(json);
                }
            }
            else
            {
                throw new NullReferenceException("Json file path is not provided");
            }
        }

        /// <summary>
        /// Setter for MWS Service URL for unit testing
        /// </summary>
        /// <param name="url"></param>
        public void SetMwsTestUrl(string url)
        {
            this.mwsTestUrl = url;
        }

        /// <summary>
        /// Sets the value for the parameters string for unit testing
        /// </summary>
        /// <returns>IDictionary parameters</returns>
        public Dictionary<string, string> GetParameters()
        {
            return this.parameters;

        }

        /// <summary>
        /// Setter for Timestamp
        /// Set the Timestamp for unit testing
        /// </summary>
        /// <param name="timeStamp"></param>
        public void SetTimeStamp(string timeStamp)
        {
            this.timeStamp = timeStamp;
        }

        /// <summary>
        /// SetParametersAndPost - sets the parameters Dictionary that will be used to Post to MWS with non empty values from the requestParameters Dictionary sent to API calls.
        /// If Provider Credit Details is present, values are set by setProviderCreditDetails
        /// If Provider Credit Reversal Details is present, values are set by setProviderCreditDetails
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <returns>string XML response</returns>
        private string SetParametersAndPost(Dictionary<string, string> requestParameters, IList<Dictionary<string, string>> providerDetails = null)
        {
            Dictionary<string, string> parameters = new Dictionary<String, String>();
            // For loop to take all the non empty parameters in the requestParameters and add it into the parameters Dictionary,
            // if the keys are matched from requestParameters Dictionary with the fieldMappings Dictionary

            foreach (KeyValuePair<string, string> pair in requestParameters)
            {
                if (!string.IsNullOrEmpty(pair.Value))
                {
                    parameters[pair.Key] = pair.Value;
                }
            }
            if (providerDetails != null && providerDetails.Count > 0)
            {
                if (requestParameters.ContainsKey(Constants.provider_credit_details))
                {
                    parameters = SetProviderCreditDetails(parameters, providerDetails);
                }
                if (requestParameters.ContainsKey(Constants.provider_credit_reversal_details))
                {
                    parameters = SetProviderCreditReversalDetails(parameters, providerDetails);
                }
            }

            parameters = SetDefaultValues(parameters, requestParameters);
            string response = CalculateSignatureAndPost(parameters);
            return response;
        }

        /// <summary>
        /// CalculateSignatureAndPost - convert the Parameters Dictionary to string and POST the parameters to MWS
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>string response</returns>
        private string CalculateSignatureAndPost(Dictionary<string, string> parameters)
        {
            // Call the signature and Post function to perform the actions.
            string parametersString = CalculateSignatureAndParametersToString(parameters);

            // Invokes Http POST method with string converted Parameters as data
            string response = Invoke(parametersString);

            return response;
        }

        /// <summary>
        /// If Merchant ID is not set via the requestParameters Dictionary then it's taken from the configuration object
        /// Set the Platform ID set in the configuration object and if value is null in the requestParameters
        /// Set the Currency Code if set in the configuration object and if value is null in the requestParameters
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="requestParameters"></param>
        /// <returns>Dictionary parameters</returns>
        private Dictionary<string, string> SetDefaultValues(Dictionary<string, string> parameters, Dictionary<string, string> requestParameters)
        {
            if (requestParameters.ContainsKey(Constants.SellerId))
            {
                if (requestParameters[Constants.SellerId] == null || requestParameters[Constants.SellerId].Trim() == "")
                {
                    if (this.clientConfig.GetMerchantId() != null && this.clientConfig.GetMerchantId().Trim() != "")
                    {
                        parameters[Constants.SellerId] = this.clientConfig.GetMerchantId();
                    }
                }
            }

            foreach (KeyValuePair<string, string> param in requestParameters)
            {
                if (param.Key.Contains("CurrencyCode"))
                {
                    if (string.IsNullOrEmpty(param.Value))
                    {
                        if (this.clientConfig.GetCurrencyCode() != null && this.clientConfig.GetCurrencyCode().Trim() != "")
                        {
                            parameters[param.Key] = this.clientConfig.GetCurrencyCode();
                        }
                    }
                }

                if (param.Key.Contains("PlatformId"))
                {
                    if (string.IsNullOrEmpty(param.Value))
                    {
                        if (this.clientConfig.GetPlatformId() != null && this.clientConfig.GetPlatformId().Trim() != "")
                        {
                            parameters[param.Key] = this.clientConfig.GetPlatformId();
                        }
                    }
                }
            }

            return parameters;
        }

        /// <summary>
        /// SetProviderCreditDetails - sets the provider credit details sent via the Capture or Authorize API calls
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="providerCreditInfo"></param>
        /// <returns>Dictionary parameters</returns>
        private Dictionary<string, string> SetProviderCreditDetails(Dictionary<string, string> parameters, IList<Dictionary<string, string>> providerCreditInfo)
        {
            int providerIndex = 0;
            string providerString = "ProviderCreditList.member.";

            foreach (Dictionary<string, string> innerDictionary in providerCreditInfo)
            {
                providerIndex = providerIndex + 1;

                foreach (KeyValuePair<string, string> keypair in innerDictionary)
                {
                    if (keypair.Value.Trim() != "" && keypair.Value != null)
                    {
                        parameters[providerString + providerIndex + "." + keypair.Key] = keypair.Value;
                    }
                }

                // If currency code is not entered take it from the configuration object
                if (string.IsNullOrEmpty(parameters[providerString + providerIndex + "." + Constants.CreditAmount_CurrencyCode]))
                {
                    parameters[providerString + providerIndex + "." + Constants.CreditAmount_CurrencyCode] = this.clientConfig.GetCurrencyCode();
                }
            }
            return parameters;
        }

        /// <summary>
        /// SetProviderCreditReversalDetails - sets the reverse provider credit details sent via the Refund API call.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="providerCreditInfo"></param>
        /// <returns>Dictionary parameters</returns>
        private Dictionary<string, string> SetProviderCreditReversalDetails(Dictionary<string, string> parameters, IList<Dictionary<string, string>> providerCreditInfo)
        {
            int providerIndex = 0;
            string providerString = "ProviderCreditReversalList.member.";
            
            foreach (Dictionary<string, string> innerDictionary in providerCreditInfo)
            {
                providerIndex = providerIndex + 1;

                foreach (KeyValuePair<string, string> keypair in innerDictionary)
                { 
                    if (keypair.Value.Trim() != "" && keypair.Value != null)
                    {
                        parameters[providerString + providerIndex + "." + keypair.Key] = keypair.Value;
                    }
                }

                // If currency code is not entered take it from the configuration object
                if (string.IsNullOrEmpty(parameters[providerString + providerIndex + "." + Constants.CreditReversalAmount_CurrencyCode]))
                {
                    parameters[providerString + providerIndex + "." + Constants.CreditReversalAmount_CurrencyCode] = this.clientConfig.GetCurrencyCode();
                }
            }
            return parameters;
        }

        /// <summary>
        /// GetUserInfo convenience function - Returns user's profile information from Amazon using the access token returned by the Button widget.
        /// </summary>
        /// <param name="accessToken"></param>
        /// <returns>string response - json output of profile information</returns>
        public string GetUserInfo(string accessToken)
        {
            string response;
            string profileEndpoint = GetProfileEndpointUrl();

            if (string.IsNullOrEmpty(accessToken))
            {
                throw new NullReferenceException("Access Token is a required parameter and is not set");
            }
            if (string.IsNullOrEmpty(this.clientConfig.GetClientId().ToString()))
            {
                throw new NullReferenceException("client ID is a required parameter and is not set");
            }

            accessToken = System.Web.HttpUtility.UrlDecode(accessToken);
            string url = profileEndpoint + "/auth/o2/tokeninfo?access_token=" + System.Web.HttpUtility.UrlEncode(accessToken);

            HttpImpl httpRequest = new HttpImpl(clientConfig);
            response = httpRequest.Get(url);

            Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);

            // aud - The client identifier used to request the access token. The value for aud should math the LWA Client ID - this.clientConfig.GetClientId()
            if (data.ContainsKey(aud))
            {
                if (!(data[aud].Equals(this.clientConfig.GetClientId()))) // describe the aud variable nd add value into a final string
                {
                    throw new InvalidDataException("The Access token entered is incorrect");
                }
                else
                {
                    url = profileEndpoint + "/user/profile";
                    httpRequest = new HttpImpl(this.clientConfig);
                    httpRequest.setAccessToken(accessToken);
                    httpRequest.setHttpHeader();

                    response = httpRequest.Get(url);
                }
            }

            return response;
        }

        /// <summary>
        /// GetOrderReferenceDetails API call - Returns details about the order reference object and its current state.
        /// </summary>
        /// <example>
        ///  <code>
        ///   GetOrderReferenceDetailsRequest requestParameters = new GetOrderReferenceDetailsRequest();
        ///  
        ///   // Required params
        ///   requestParameters.WithAmazonOrderReferenceId("S01/P01-XXXXX-XXXXX");
        ///  
        ///   // Optional params
        ///   requestParameters.WithMerchantId("MERCHANT_ID"); // Required if config["merchant_id"] is null
        ///   requestParameters.WithAddressConsentToken[("ACCESS_TOKEN");
        ///   requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        ///  </code>
        /// </example>
        /// <param name="requestParameters"></param>
        /// <returns>ResponseParser responseObject</returns>
        public OrderReferenceDetailsResponse GetOrderReferenceDetails(GetOrderReferenceDetailsRequest requestParameters)
        {
            Dictionary<string, string> getOrderReferenceDetailsDictionary = new Dictionary<string, string>()
            {
                {Constants.Action,requestParameters.GetAction()},
                {Constants.SellerId,requestParameters.GetMerchantId()},
                {Constants.AmazonOrderReferenceId,requestParameters.GetAmazonOrderReferenceId()},
                {Constants.AddressConsentToken, requestParameters.GetAddressConsentToken()},
                {Constants.AccessToken, requestParameters.GetAccessToken()},
                {Constants.MWSAuthToken,requestParameters.GetMWSAuthToken()},
            };
            string response = SetParametersAndPost(getOrderReferenceDetailsDictionary);
            OrderReferenceDetailsResponse responseObject = new OrderReferenceDetailsResponse(response);
            return responseObject;
        }


        /// <summary>
        /// GetPaymentDetails API call - is a utility function that returns Order Reference, Authorize, Capture and Refund details.
        /// </summary>
        /// <example>
        ///  <code>
        ///  PaymentDetailsResponse pay = client.GetPaymentDetails("S01-1894586-0483625", null);   
        ///   // Required params
        ///   amazonOrderReferenceID
        ///  
        ///   // Optional params
        ///   mwsAuthToken
        ///  </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        public PaymentDetailsResponse GetPaymentDetails(String amazonOrderReferenceID, string mwsAuthToken) 
        {
            PaymentDetailsResponse paymentDetailsResponse = new PaymentDetailsResponse();

            try
            {
                GetOrderReferenceDetailsRequest orderReferenceDetailsRequest = new GetOrderReferenceDetailsRequest()
                    .WithAmazonOrderReferenceId(amazonOrderReferenceID)
                    .WithMWSAuthToken(mwsAuthToken);

                OrderReferenceDetailsResponse orderReferenceDetailsResponse = GetOrderReferenceDetails(orderReferenceDetailsRequest);
                paymentDetailsResponse.PutOrderReferenceDetails(amazonOrderReferenceID, orderReferenceDetailsResponse);

                IList<String> amazon_authorization_id = orderReferenceDetailsResponse.GetAuthorizationIdList();
                
                foreach (String authorizeID in amazon_authorization_id)
                {
                    GetAuthorizationDetailsRequest authorizeDetailsRequest = new GetAuthorizationDetailsRequest()
                        .WithAmazonAuthorizationId(authorizeID)
                        .WithMWSAuthToken(mwsAuthToken);

                    AuthorizeResponse authorizeDetailsResponse = GetAuthorizationDetails(authorizeDetailsRequest);
                    paymentDetailsResponse.PutAuthorizationDetails(authorizeID, authorizeDetailsResponse);

                    IList<String> amazon_capture_id = authorizeDetailsResponse.GetCaptureIdList();
                   
                    foreach (String captureID in amazon_capture_id)
                    {
                        GetCaptureDetailsRequest captureDetailsRequest = new GetCaptureDetailsRequest()
                            .WithAmazonCaptureId(captureID)
                            .WithMWSAuthToken(mwsAuthToken);

                        CaptureResponse captureDetailsResponse = GetCaptureDetails(captureDetailsRequest);
                        paymentDetailsResponse.PutCaptureDetails(captureID, captureDetailsResponse);

                        IList<String> amazon_refund_id = captureDetailsResponse.GetRefundIdList();

                        foreach (String refundID in amazon_refund_id)
                        {
                            GetRefundDetailsRequest refundDetailsRequest = new GetRefundDetailsRequest()
                            .WithAmazonRefundId(refundID)
                            .WithMWSAuthToken(mwsAuthToken);

                            RefundResponse refundDetailsResponse = GetRefundDetails(refundDetailsRequest);
                            paymentDetailsResponse.PutRefundDetails(refundID, refundDetailsResponse);
                        }
                    }
                }                
            }
            catch (Exception ex)
            {
                throw new Exception("Exception occured:", ex);
            }
            return paymentDetailsResponse;
        }


        /// <summary>
        /// SetOrderReferenceDetails API call - Sets order reference details such as the order total and a description for the order.
        /// https://pay.amazon.com/documentation/apireference/201751960
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        ///  <code>
        ///   SetOrderReferenceDetailsRequest requestParameters = new SetOrderReferenceDetailsRequest();
        ///  
        ///   // Required Parameters
        ///   requestParameters.WithAmazonOrderReferenceId("S01/P01-XXXXX-XXXXX");
        ///   requestParameters.WithAmount("100");
        ///   requestParameters.WithCurrencyCode(Regions.currencyCode.USD); // Required if config["currency_code"] is null
        ///   requestParameters.WithMerchantId("MERCHANT_ID"); // Required if config["merchant_id"] is null
        /// 
        ///   // Optional 
        ///   requestParameters.WithPlatformId("SOLUTION_PROVIDER_ID");
        ///   requestParameters.WithSellerNote("CUSTOM_NOTE");
        ///   requestParameters.WithSellerOrderId("CUSTOM_ORDER_ID");
        ///   requestParameters.WithStoreName("CUSTOM_STORE_NAME");
        ///   requestParameters.WithCustomInformation("CUSTOM_INFO");
        ///   requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        ///  </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        public OrderReferenceDetailsResponse SetOrderReferenceDetails(SetOrderReferenceDetailsRequest requestParameters)
        {
            Dictionary<string, string> setOrderReferenceDetailsDictionary = new Dictionary<string, string>()
            {
                {Constants.Action,requestParameters.GetAction()},
                {Constants.SellerId,requestParameters.GetMerchantId()},
                {Constants.AmazonOrderReferenceId,requestParameters.GetAmazonOrderReferenceId()},
                {Constants.OrderReferenceAttributes_OrderTotal_Amount,requestParameters.GetAmount().ToString(Constants.USNumberFormat)},
                {Constants.OrderReferenceAttributes_OrderTotal_CurrencyCode,requestParameters.GetCurrencyCode()},
                {Constants.OrderReferenceAttributes_PlatformId,requestParameters.GetPlatformId()},
                {Constants.OrderReferenceAttributes_SellerNote,requestParameters.GetSellerNote()},
                {Constants.OrderReferenceAttributes_SellerOrderAttributes_SellerOrderId,requestParameters.GetSellerOrderId()},
                {Constants.OrderReferenceAttributes_SellerOrderAttributes_StoreName,requestParameters.GetStoreName()},
                {Constants.OrderReferenceAttributes_SellerOrderAttributes_CustomInformation,requestParameters.GetCustomInformation()},
                {Constants.MWSAuthToken,requestParameters.GetMWSAuthToken()}
            };
            string response = SetParametersAndPost(setOrderReferenceDetailsDictionary);
            OrderReferenceDetailsResponse responseObject = new OrderReferenceDetailsResponse(response);
            return responseObject;
        }

        /// <summary>
        /// ConfirmOrderReference API call - Confirms that the order reference is free of constraints and all required information has been set on the order reference.
        /// https://pay.amazon.com/documentation/apireference/201751980
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        /// <code>
        ///  ConfirmOrderReferenceRequest requestParameters = new ConfirmOrderReferenceRequest();
        ///  
        ///  // Required
        ///  requestParameters.WithAmazonOrderReferenceId("S01/P01-XXXXX-XXXXX");
        /// 
        ///  // Optional
        ///  requestParameters.WithMerchantId("MERCHANT_ID"); // Required if config["merchant_id"] is null
        ///  requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        /// </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        public ConfirmOrderReferenceResponse ConfirmOrderReference(ConfirmOrderReferenceRequest requestParameters)
        {
            Dictionary<string, string> confirmOrderReferenceDetailsDictionary = new Dictionary<string, string>()
            {
                {Constants.Action,requestParameters.GetAction()},
                {Constants.SellerId,requestParameters.GetMerchantId()},
                {Constants.AmazonOrderReferenceId,requestParameters.GetAmazonOrderReferenceId()},
                {Constants.MWSAuthToken,requestParameters.GetMWSAuthToken()},
            };
            string response = SetParametersAndPost(confirmOrderReferenceDetailsDictionary);
            ConfirmOrderReferenceResponse responseObject = new ConfirmOrderReferenceResponse(response);
            return responseObject;
        }

        /// <summary>
        /// CancelOrderReferenceDetails API call - Cancels a previously confirmed order reference.
        /// https://pay.amazon.com/documentation/apireference/201751990"
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        ///  <code>
        ///   CancelOrderReferenceRequest requestParameters = new CancelOrderReferenceRequest();
        ///   
        ///   // Required
        ///   requestParameters.WithAmazonOrderReferenceId("S01/P01-XXXXX-XXXXX");
        ///  
        ///   // Optional
        ///   requestParameters.WithMerchantId("MERCHANT_ID"); // Required if config["merchant_id"] is null
        ///   requestParameters.WithCancelationReason("CUSTOM_CANCEL_REASON");
        ///   requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        /// </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        public CancelOrderReferenceResponse CancelOrderReference(CancelOrderReferenceRequest requestParameters)
        {
            Dictionary<string, string> cancelOrderReferenceDetailsDictionary = new Dictionary<string, string>()
            {
                {Constants.Action,requestParameters.GetAction()},
                {Constants.SellerId,requestParameters.GetMerchantId()},
                {Constants.AmazonOrderReferenceId,requestParameters.GetAmazonOrderReferenceId()},
                {Constants.CancelationReason,requestParameters.GetCancelationReason()},
                {Constants.MWSAuthToken,requestParameters.GetMWSAuthToken()},
            };
            string response = SetParametersAndPost(cancelOrderReferenceDetailsDictionary);
            CancelOrderReferenceResponse responseObject = new CancelOrderReferenceResponse(response);
            return responseObject;
        }

        /// <summary>
        /// CloseOrderReference API call - Confirms that an order reference has been fulfilled (fully or partially)
        /// https://pay.amazon.com/documentation/apireference/201752000
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        ///  <code>
        ///   CloseOrderReferenceRequest requestParameters = new CloseOrderReferenceRequest();
        ///   
        ///   // Required
        ///   requestParameters.WithAmazonOrderReferenceId("S01/P01-XXXXX-XXXXX");
        /// 
        ///   // Optional
        ///   requestParameters.WithMerchantId("MERCHANT_ID"); // Required if config["merchant_id"] is null
        ///   requestParameters.WithClosureReason("CLOSURE_REASON");
        ///   requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        /// </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        public CloseOrderReferenceResponse CloseOrderReference(CloseOrderReferenceRequest requestParameters)
        {
            Dictionary<string, string> closeOrderReferenceDetailsDictionary = new Dictionary<string, string>()
            {
                {Constants.Action,requestParameters.GetAction()},
                {Constants.SellerId,requestParameters.GetMerchantId()},
                {Constants.AmazonOrderReferenceId,requestParameters.GetAmazonOrderReferenceId()},
                {Constants.ClosureReason,requestParameters.GetClosureReason()},
                {Constants.MWSAuthToken,requestParameters.GetMWSAuthToken()},
            };
            string response = SetParametersAndPost(closeOrderReferenceDetailsDictionary);
            CloseOrderReferenceResponse responseObject = new CloseOrderReferenceResponse(response);
            return responseObject;
        }

        /// <summary>
        /// CloseAuthorization API call - Closes an authorization.
        /// https://pay.amazon.com/documentation/apireference/201752070
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        ///  <code>
        ///   CloseAuthorizationRequest requestParameters = new CloseAuthorizationRequest();
        ///   
        ///   // Required
        ///   requestParameters.WithAmazonAuthorizationId("S01/P01-XXXXX-XXXXX-AXXXXX");
        ///   
        ///   // Optional
        ///   requestParameters.WithMerchantId("MERCHANT_ID"); // Required if config["merchant_id"] is null
        ///   requestParameters.WithClosureReason("CLOSURE_REASON");
        ///   requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        ///  </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        public CloseAuthorizationResponse CloseAuthorization(CloseAuthorizationRequest requestParameters)
        {
            Dictionary<string, string> closeAuthorizationDictionary = new Dictionary<string, string>()
            {
                {Constants.Action,requestParameters.GetAction()},
                {Constants.SellerId,requestParameters.GetMerchantId()},
                {Constants.AmazonAuthorizationId,requestParameters.GetAmazonAuthorizationId()},
                {Constants.ClosureReason,requestParameters.GetClosureReason()},
                {Constants.MWSAuthToken,requestParameters.GetMWSAuthToken()},
            };
            string response = SetParametersAndPost(closeAuthorizationDictionary);
            CloseAuthorizationResponse responseObject = new CloseAuthorizationResponse(response);
            return responseObject;
        }

        /// <summary>
        /// Authorize API call - Reserves a specified amount against the payment method(s) stored in the order reference.
        /// https://pay.amazon.com/documentation/apireference/201752010
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        ///  <code>
        ///   AuthorizeRequest requestParameters = new AuthorizeRequest();
        ///    
        ///   // Required
        ///   requestParameters.WithAmazonOrderReferenceId("S01/P01-XXXXX-XXXXX");
        ///   requestParameters.WithAmount("100");
        ///   
        ///   // Optional
        ///   requestParameters.WithMerchantId("MERCHANT_ID"); // Required if config["merchant_id"] is null
        ///   requestParameters.WithCurrencyCode(Regions.currencyCode.USD); // Required if config["currency_code"] is null
        ///   requestParameters.WithAuthorizationReferenceId("UNIQUE_STRING");
        ///   requestParameters.WithCaptureNow(false); // Defaults to false
        ///   requestParameters.WithProviderCreditDetails("PROVIDER_ID",10,"USD"); // If there are multiple providers, call the WithProviderCreditDetails nultiple times for each
        ///   requestParameters.WithSellerAuthorizationNote("CUSTOM_NOTE");
        ///   requestParameters.WithTransactionTimeout(5); // Defaults to 1440 minutes
        ///   requestParameters.WithSoftDescriptor("AMZ*CUSTOM");
        ///   requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        ///  </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        public AuthorizeResponse Authorize(AuthorizeRequest requestParameters)
        {
            Dictionary<string, string> authorizeDictionary = new Dictionary<string, string>()
            {
                {Constants.Action,requestParameters.GetAction()},
                {Constants.SellerId,requestParameters.GetMerchantId()},
                {Constants.AmazonOrderReferenceId,requestParameters.GetAmazonOrderReferenceId()},
                {Constants.AuthorizationAmount_Amount,requestParameters.GetAmount().ToString(Constants.USNumberFormat)},
                {Constants.AuthorizationAmount_CurrencyCode,requestParameters.GetCurrencyCode()},
                {Constants.AuthorizationReferenceId,requestParameters.GetAuthorizationReferenceId()},
                {Constants.SellerAuthorizationNote,requestParameters.GetSellerAuthorizationNote()},
                {Constants.TransactionTimeout,requestParameters.GetTransactionTimeout().ToString()},
                {Constants.SoftDescriptor,requestParameters.GetSoftDescriptor()},
                {Constants.provider_credit_details,""},
                {Constants.CaptureNow,requestParameters.GetCaptureNow()},
                {Constants.MWSAuthToken,requestParameters.GetMWSAuthToken()}
            };

            IList<Dictionary<string, string>> providerCredit = new List<Dictionary<string, string>>();
            providerCredit = requestParameters.GetProviderCreditDetails();

            string response = SetParametersAndPost(authorizeDictionary, providerCredit);
            AuthorizeResponse responseObject = new AuthorizeResponse(response);
            return responseObject;
        }

        /// <summary>
        /// GetAuthorizationDetails API call - Returns the status of a particular authorization and the total amount captured on the authorization.
        /// https://pay.amazon.com/documentation/apireference/201752030
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        ///  <code>
        ///   GetAuthorizationDetailsRequest requestParameters = new GetAuthorizationDetailsRequest();
        ///   
        ///   // Required
        ///   requestParameters.WithAmazonAuthorizationId"("S01/P01-XXXXX-XXXXX-AXXXXX)";
        ///  
        ///   // Optional 
        ///   requestParameters.WithMerchantId("MERCHANT_ID");
        ///   requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        ///  </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        public AuthorizeResponse GetAuthorizationDetails(GetAuthorizationDetailsRequest requestParameters)
        {
            Dictionary<string, string> getAuthorizationDetailsDictionary = new Dictionary<string, string>()
            {
                {Constants.Action,requestParameters.GetAction()},
                {Constants.SellerId,requestParameters.GetMerchantId()},
                {Constants.AmazonAuthorizationId,requestParameters.GetAmazonAuthorizationId()},
                {Constants.MWSAuthToken,requestParameters.GetMWSAuthToken()},
            };
            string response = SetParametersAndPost(getAuthorizationDetailsDictionary);
            AuthorizeResponse responseObject = new AuthorizeResponse(response);
            return responseObject;
        }

        /// <summary>
        /// Capture API call - Captures funds from an authorized payment instrument
        /// https://pay.amazon.com/documentation/apireference/201752040
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        ///  <code>
        ///   CaptureRequest requestParameters = new CaptureRequest();
        ///   // Required
        ///   requestParameters.WithAmazonAuthorizationId("S01/P01-XXXXX-XXXXX-AXXXX");
        ///   requestParameters.WithCaptureAmount("100");
        ///   requestParameters.WithCaptureReferenceId("UNIQUE_STRING");
        ///  
        ///   // Optional 
        ///   requestParameters.WithMerchantId("MERCHANT_ID"); // Required if config["merchant_id"] is null
        ///   requestParameters.WithCurrencyCode(Regions.currencyCode.USD); // Required if config["currency_code"] is null
        ///   requestParameters.WithProviderCreditDetails("PROVIDER_ID",10,"USD"); // If there are multiple providers, call the WithProviderCreditDetails nultiple times for each
        ///   requestParameters.WithSellerCaptureNote("CUSTOM_NOTE");
        ///   requestParameters.WithSetSoftDescriptor("AMZ*CUSTOM");
        ///   requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        ///  </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        public CaptureResponse Capture(CaptureRequest requestParameters)
        {
            Dictionary<string, string> captureDictionary = new Dictionary<string, string>()
            {
                {Constants.Action,requestParameters.GetAction()},
                {Constants.SellerId,requestParameters.GetMerchantId()},
                {Constants.AmazonAuthorizationId,requestParameters.GetAmazonAuthorizationId()},
                {Constants.CaptureAmount_Amount,requestParameters.GetAmount().ToString(Constants.USNumberFormat)},
                {Constants.CaptureAmount_CurrencyCode,requestParameters.GetCurrencyCode()},
                {Constants.CaptureReferenceId,requestParameters.GetCaptureReferenceId()},
                {Constants.SellerCaptureNote,requestParameters.GetSellerCaptureNote()},
                {Constants.SoftDescriptor,requestParameters.GetSoftDescriptor()},
                {Constants.provider_credit_details,""},
                {Constants.MWSAuthToken,requestParameters.GetMWSAuthToken()}
            };

            IList<Dictionary<string, string>> providerCredit = new List<Dictionary<string, string>>();
            providerCredit = requestParameters.GetProviderCreditDetails();

            string response = SetParametersAndPost(captureDictionary, providerCredit);
            CaptureResponse responseObject = new CaptureResponse(response);
            return responseObject;
        }

        /// <summary>
        /// GetCaptureDetails API call - Returns the status of a particular capture and the total amount refunded on the capture.
        /// https://pay.amazon.com/documentation/apireference/201752060
        /// </summary>
        /// <example>
        ///  <code>
        ///   GetCaptureDetailsRequest requestParameters = new GetCaptureDetailsRequest();
        ///   
        ///   // Required
        ///   requestParameters["amazon_capture_id"] = "S01/P01-XXXXX-XXXXX-CXXXXX" ;
        ///  
        ///   // Optional
        ///   requestParameters.WithMerchantId("MERCHANT_ID"); // Required if config["merchant_id"] is null
        ///   requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        ///  </code>
        /// </example>
        /// <param name="requestParameters"></param>
        /// <returns>ResponseParser responseObject</returns>
        public CaptureResponse GetCaptureDetails(GetCaptureDetailsRequest requestParameters)
        {
            Dictionary<string, string> getCaptureDetailsDictionary = new Dictionary<string, string>()
            {
                {Constants.Action,requestParameters.GetAction()},
                {Constants.SellerId,requestParameters.GetMerchantId()},
                {Constants.AmazonCaptureId,requestParameters.GetAmazonCaptureId()},
                {Constants.MWSAuthToken,requestParameters.GetMWSAuthToken()},
            };
            string response = SetParametersAndPost(getCaptureDetailsDictionary);
            CaptureResponse responseObject = new CaptureResponse(response);
            return responseObject;
        }

        /// <summary>
        /// Refund API call - Refunds a previously captured amount.
        /// https://pay.amazon.com/documentation/apireference/201752080
        /// </summary>
        /// <example>
        ///  <code>
        ///   RefundRequest requestParameters = new RefundRequest();
        ///   
        ///   // Required
        ///   requestParameters.WithAmazonCaptureId("S01/P01-XXXXX-XXXXX-CXXXX");
        ///   requestParameters.WithRefundReferenceId("UNIQUE_STRING");
        ///   requestParameters.WithAmount("100");
        ///   
        ///   //Optional
        ///   requestParameters.WithMerchantId("MERCHANT_ID"); // Required if config["merchant_id"] is null
        ///   requestParameters.WithCurrencyCode(Regions.currencyCode.USD); // Required if config["currency_code"] is null
        ///   requestParameters.WithProviderCreditReversalDetails("PROVIDER_ID","10","USD"); // Provider Credit details
        ///   requestParameters.WithSellerRefundNote("CUSTOM_NOTE");
        ///   requestParameters.WithSoftDescriptor("AMZ*CUSTOM");
        ///   requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        ///  </code>
        /// </example>
        /// <param name="requestParameters"></param>
        /// <returns>ResponseParser responseObject</returns>
        public RefundResponse Refund(RefundRequest requestParameters)
        {
            Dictionary<string, string> refundDictionary = new Dictionary<string, string>()
            {
                {Constants.Action,requestParameters.GetAction()},
                {Constants.SellerId,requestParameters.GetMerchantId()},
                {Constants.AmazonCaptureId,requestParameters.GetAmazonCaptureId()},
                {Constants.RefundAmount_Amount,requestParameters.GetAmount().ToString(Constants.USNumberFormat)},
                {Constants.RefundAmount_CurrencyCode,requestParameters.GetCurrencyCode()},
                {Constants.RefundReferenceId,requestParameters.GetRefundReferenceId()},
                {Constants.SellerRefundNote,requestParameters.GetSellerRefundNote()},
                {Constants.SoftDescriptor,requestParameters.GetSoftDescriptor()},
                {Constants.provider_credit_reversal_details,""},
                {Constants.MWSAuthToken,requestParameters.GetMWSAuthToken()}
            };

            IList<Dictionary<string, string>> providerCredit = new List<Dictionary<string, string>>();
            providerCredit = requestParameters.GetProviderReverseCredit();

            string response = SetParametersAndPost(refundDictionary, providerCredit);
            RefundResponse responseObject = new RefundResponse(response);
            return responseObject;
        }

        /// <summary>
        /// GetRefundDetails API call - Returns the status of a particular refund.
        /// https://pay.amazon.com/documentation/apireference/201752100
        /// </summary>
        /// <example>
        ///  <code>
        ///   GetRefundDetailsRequest requestParameters = new GetRefundDetailsRequest();
        ///   
        ///   // Required
        ///   requestParameters.WithAmazonRefundId("S01/P01-XXXXX-XXXXX-RXXXXX");
        ///   
        ///   // Optional
        ///   requestParameters.WithMerchantId("MERCHANT_ID"); // Required if config["merchant_id"] is null
        ///   requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        ///  </code>
        /// </example>
        /// <param name="requestParameters"></param>
        /// <returns>ResponseParser responseObject</returns>
        public RefundResponse GetRefundDetails(GetRefundDetailsRequest requestParameters)
        {
            Dictionary<string, string> getRefundDetailsDictionary = new Dictionary<string, string>()
            {
                {Constants.Action,requestParameters.GetAction()},
                {Constants.SellerId,requestParameters.GetMerchantId()},
                {Constants.AmazonRefundId,requestParameters.GetAmazonRefundId()},
                {Constants.MWSAuthToken,requestParameters.GetMWSAuthToken()},
            };
            string response = SetParametersAndPost(getRefundDetailsDictionary);
            RefundResponse responseObject = new RefundResponse(response);
            return responseObject;
        }

        /// <summary>
        /// GetServiceStatus API Call - Returns the operational status of the Off-Amazon Payments API section
        /// section of Amazon Marketplace Web Service (Amazon MWS). Status values are GREEN, GREEN_I, YELLOW, and RED.
        /// https://pay.amazon.com/documentation/apireference/201752110
        /// </summary>
        /// <example>
        ///  <code>
        ///  GetServiceStatusRequest requestParameters =  new GetServiceStatusRequest();
        ///   
        ///   // Optional
        ///   requestParameters.WithMerchantId("MERCHANT_ID"); // Required if config["merchant_id"] is null
        ///   requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        ///  </code>
        /// </example>
        /// <param name="requestParameters"></param>
        /// <returns></returns>
        public GetServiceStatusResponse GetServiceStatus(GetServiceStatusRequest requestParameters)
        {
            Dictionary<string, string> getServiceStatusDictionary = new Dictionary<string, string>()
            {
                {Constants.Action,requestParameters.GetAction()},
                {Constants.SellerId,requestParameters.GetMerchantId()},
                {Constants.MWSAuthToken,requestParameters.GetMWSAuthToken()}
            };
            string response = SetParametersAndPost(getServiceStatusDictionary);
            GetServiceStatusResponse responseObject = new GetServiceStatusResponse(response);
            return responseObject;
        }

        /// <summary>
        /// CreateOrderReferenceForId API Call - Creates an order reference for the given object
        /// https://pay.amazon.com/documentation/apireference/201751670
        /// </summary>
        /// <example>
        ///  <code>
        ///    CreateOrderReferenceForIdRequest requestParameters = new CreateOrderReferenceForIdRequest();
        ///   
        ///   // Required
        ///   requestParameters.WithId("C01/B01-XXXXX-XXXXX"); // billing agreement ID
        ///   
        ///   // Optional
        ///   requestParameters.WithInheritShippingAddress(true); // Defaults to false
        ///   requestParameters.WithConfirmNow(true); // Defaults to false
        ///   requestParameters.WithAmount("100"); // Required when requestParameters["ConfirmNow"] is set to true
        ///   requestParameters.WithCurrencyCode(Regions.currencyCode.USD); // Required if config["currency_code"] is null
        ///   requestParameters.WithSellerNote("CUSTOM_NOTE");
        ///   requestParameters.WithSellerOrderId("CUSTOM_ORDER_ID");
        ///   requestParameters.WithStoreName("CUSTOM_NAME");
        ///   requestParameters.WithCustomInformation("CUSTOM_INFO");
        ///   requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        ///  </code>
        /// </example>
        /// <param name="requestParameters"></param>
        /// <returns>ResponseParser responseObject</returns>
        public OrderReferenceDetailsResponse CreateOrderReferenceForId(CreateOrderReferenceForIdRequest requestParameters)
        {
            Dictionary<string, string> createOrderReferenceDetailsDictionary = new Dictionary<string, string>()
            {
                {Constants.Action,requestParameters.GetAction()},
                {Constants.SellerId,requestParameters.GetMerchantId()},
                {Constants.Id,requestParameters.GetId()},
                {Constants.IdType,requestParameters.GetIdType()},
                {Constants.ConfirmNow,requestParameters.GetConfirmNow()},
                {Constants.OrderReferenceAttributes_OrderTotal_Amount,requestParameters.GetAmount().ToString(Constants.USNumberFormat)},
                {Constants.OrderReferenceAttributes_OrderTotal_CurrencyCode,requestParameters.GetCurrencyCode()},
                {Constants.OrderReferenceAttributes_PlatformId,requestParameters.GetPlatformId()},
                {Constants.OrderReferenceAttributes_SellerNote,requestParameters.GetSellerNote()},
                {Constants.OrderReferenceAttributes_SellerOrderAttributes_SellerOrderId,requestParameters.GetSellerOrderId()},
                {Constants.OrderReferenceAttributes_SellerOrderAttributes_StoreName,requestParameters.GetStoreName()},
                {Constants.InheritShippingAddress,requestParameters.GetInheritShippingAddress()},
                {Constants.OrderReferenceAttributes_SellerOrderAttributes_CustomInformation,requestParameters.GetCustomInformation()},
                {Constants.MWSAuthToken,requestParameters.GetMWSAuthToken()}
            };
            string response = SetParametersAndPost(createOrderReferenceDetailsDictionary);
            OrderReferenceDetailsResponse responseObject = new OrderReferenceDetailsResponse(response);
            return responseObject;
        }

        /// <summary>
        /// GetBillingAgreementDetails API Call - Returns details about the billing agreement object and its current state.
        /// https://pay.amazon.com/documentation/apireference/201751690
        /// </summary>
        /// <example>
        ///  <code>
        ///    GetBillingAgreementDetailsRequest requestParameters = new GetBillingAgreementDetailsRequest();
        ///    
        ///   // Required
        ///   requestParameters.WithAmazonBillingAgreementId("C01/B01-XXXXX-XXXXX");
        ///   
        ///   // Optional
        ///   requestParameters.WithMerchantId("MERCHANT_ID");
        ///   requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        ///  </code>
        /// </example>
        /// <param name="requestParameters"></param>
        /// <returns>ResponseParser responseObject</returns>
        public BillingAgreementDetailsResponse GetBillingAgreementDetails(GetBillingAgreementDetailsRequest requestParameters)
        {
            Dictionary<string, string> getBillingAgreementDetailsDictionary = new Dictionary<string, string>()
            {
                {Constants.Action,requestParameters.GetAction()},
                {Constants.SellerId,requestParameters.GetMerchantId()},
                {Constants.AmazonBillingAgreementId,requestParameters.GetAmazonBillingAgreementId()},
                {Constants.AddressConsentToken,requestParameters.GetAddressConsentToken()},
                {Constants.MWSAuthToken,requestParameters.GetMWSAuthToken()}
            };
            string response = SetParametersAndPost(getBillingAgreementDetailsDictionary);
            BillingAgreementDetailsResponse responseObject = new BillingAgreementDetailsResponse(response);
            return responseObject;
        }

        /// <summary>
        /// SetBillingAgreementDetails API call - Sets billing agreement details such as a description of the agreement and other information about the seller.
        /// https://pay.amazon.com/documentation/apireference/201751700
        /// </summary>
        /// <example>
        ///  <code>
        ///   SetBillingAgreementDetailsRequest requestParameters = new SetBillingAgreementDetailsRequest();
        ///   
        ///   // Required
        ///   requestParameters.WithAmazonBillingAgreementId("C01/B01-XXXXX-XXXXX");
        ///   requestParameters.WithAmount("100");
        ///   
        ///   // Optional
        ///   requestParameters.WithMerchantId("MERCHANT_ID"); // Required if config["merchant_id"] is null
        ///   requestParameters.WithCurrencyCode(Regions.currencyCode.USD); // Required if config["currency_code"] is null
        ///   requestParameters.WithPlatformId("PLATFORM_ID"); // Solution Provider ID
        ///   requestParameters.WithSellerNote("CUSTOM_NOTE"):
        ///   requestParameters.WithSellerBillingAgreementId("CUSTOM_ID"); 
        ///   requestParameters.WithStoreName("CUSTOM_STORE_NAME");
        ///   requestParameters.WithCustomInformation("CUSTOM_INFO");
        ///   requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        ///  </code>
        /// </example>
        /// <param name="requestParameters"></param>
        /// <returns>ResponseParser responseObject</returns>
        public BillingAgreementDetailsResponse SetBillingAgreementDetails(SetBillingAgreementDetailsRequest requestParameters)
        {
            Dictionary<string, string> setBillingAgreementDetailsDictionary = new Dictionary<string, string>()
            {
                {Constants.Action,requestParameters.GetAction()},
                {Constants.SellerId,requestParameters.GetMerchantId()},
                {Constants.AmazonBillingAgreementId,requestParameters.GetAmazonBillingAgreementId()},
                {Constants.BillingAgreementAttributes_PlatformId,requestParameters.GetPlatformId()},
                {Constants.BillingAgreementAttributes_SellerNote,requestParameters.GetSellerNote()},
                {Constants.BillingAgreementAttributes_SellerBillingAgreementAttributes_SellerBillingAgreementId,requestParameters.GetSellerBillingAgreementId()},
                {Constants.BillingAgreementAttributes_SellerBillingAgreementAttributes_StoreName,requestParameters.GetStoreName()},
                {Constants.BillingAgreementAttributes_SellerBillingAgreementAttributes_CustomInformation,requestParameters.GetCustomInformation()},
                {Constants.MWSAuthToken,requestParameters.GetMWSAuthToken()}
            };
            string response = SetParametersAndPost(setBillingAgreementDetailsDictionary);
            BillingAgreementDetailsResponse responseObject = new BillingAgreementDetailsResponse(response);
            return responseObject;
        }

        /// <summary>
        /// ConfirmBillingAgreement API Call - Confirms that the billing agreement is free of constraints and all required information has been set on the billing agreement.
        /// https://pay.amazon.com/documentation/apireference/201751710
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        ///  <code>
        ///    ConfirmOrderReferenceRequest requestParameters = new ConfirmOrderReferenceRequest();
        ///    
        ///   // Required
        ///   requestParameters.WithAmazonBillingAgreementId("C01/B01-XXXXX-XXXXX");
        ///   
        ///   // Optional
        ///   requestParameters.WithMerchantId("MERCHANT_ID"); // Required if config["merchant_id"] is null
        ///   requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        ///  </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        public ConfirmBillingAgreementResponse ConfirmBillingAgreement(ConfirmBillingAgreementRequest requestParameters)
        {
            Dictionary<string, string> getBillingAgreementDetailsDictionary = new Dictionary<string, string>()
            {
                {Constants.Action,requestParameters.GetAction()},
                {Constants.SellerId,requestParameters.GetMerchantId()},
                {Constants.AmazonBillingAgreementId,requestParameters.GetAmazonBillingAgreementId()},
                {Constants.MWSAuthToken,requestParameters.GetMWSAuthToken()}
            };
            string response = SetParametersAndPost(getBillingAgreementDetailsDictionary);
            ConfirmBillingAgreementResponse responseObject = new ConfirmBillingAgreementResponse(response);
            return responseObject;
        }

        /// <summary>
        /// ValidateBillignAgreement API Call - Validates the status of the billing agreement object and the payment method associated with it.
        /// https://pay.amazon.com/documentation/apireference/201751720
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        ///  <code>
        ///   ValidateBillingAgreementRequest requestParameters = new ValidateBillingAgreementRequest();
        ///    
        ///   // Required
        ///   requestParameters.WithAmazonBillingAgreementId("C01/B01-XXXXX-XXXXX");
        ///   
        ///   // Optional
        ///   requestParameters.WithMerchantId("MERCHANT_ID"); // Required if config["merchant_id"] is null
        ///   requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        ///  </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        public ValidateBillingAgreementResponse ValidateBillingAgreement(ValidateBillingAgreementRequest requestParameters)
        {
            Dictionary<string, string> validateBillingAgreementDictionary = new Dictionary<string, string>()
            {
                {Constants.Action,requestParameters.GetAction()},
                {Constants.SellerId,requestParameters.GetMerchantId()},
                {Constants.AmazonBillingAgreementId,requestParameters.GetAmazonBillingAgreementId()},
                {Constants.MWSAuthToken,requestParameters.GetMWSAuthToken()}
            };
            string response = SetParametersAndPost(validateBillingAgreementDictionary);
            ValidateBillingAgreementResponse responseObject = new ValidateBillingAgreementResponse(response);
            return responseObject;
        }

        /// <summary>
        /// AuthorizeOnBillingAgreement API call - Reserves a specified amount against the payment method(s) stored in the billing agreement.
        /// https://pay.amazon.com/documentation/apireference/201751940
        /// </summary>
        /// <example>
        ///  <code>
        ///   AuthorizeOnBillingAgreementRequest requestParameters = new AuthorizeOnBillingAgreementRequest();
        ///    
        ///   // Required
        ///   requestParameters.WithAmazonBillingAgreementId("C01/B01-XXXXX-XXXXX");
        ///   requestParameters.WithAuthorizationReferenceId("UNIQUE_STRING");
        ///   requestParameters.WithAmount("100");
        ///   
        ///   
        ///   // Optional
        ///   requestParameters.WithMerchantId("MERCHANT_ID"); // Required if config["merchant_id"] is null
        ///   requestParameters.WithCurrencyCode(Regions.currencyCode.USD); // Required if config["currency_code"] is null
        ///   requestParameters.WithSellerAuthorizationNote("CUSTOM_NOTE");
        ///   requestParameters.WithTransactionTimeout(5); // Defaults to 1440 minutes
        ///   requestParameters.WithCaptureNow(false); // Defaults to false
        ///   requestParameters.WithSoftDescriptor("AMZ*CUSTOM");
        ///   requestParameters.WithSellerNote("CUSTOM_NOTE");
        ///   requestParameters.WithPlatformId("PLATFORM_ID") // Solution Provider ID
        ///   requestParameters.WithCustomInformation("CUSTOM_INFO");
        ///   requestParameters.WithSellerOrderId("CUSTOM_ID");
        ///   requestParameters.WithStoreName("CUSTOM_NAME");
        ///   requestParameters.WithInheritShippingAddress(true); // Defaults to true
        ///   requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        ///  </code>
        /// </example>
        /// <param name="requestParameters"></param>
        /// <returns>ResponseParser responseObject</returns>
        public AuthorizeResponse AuthorizeOnBillingAgreement(AuthorizeOnBillingAgreementRequest requestParameters)
        {
            Dictionary<string, string> authorizeDictionary = new Dictionary<string, string>()
            {
                {Constants.Action,requestParameters.GetAction()},
                {Constants.SellerId,requestParameters.GetMerchantId()},
                {Constants.AmazonBillingAgreementId,requestParameters.GetAmazonBillingAgreementId()},
                {Constants.AuthorizationAmount_Amount,requestParameters.GetAmount().ToString(Constants.USNumberFormat)},
                {Constants.AuthorizationAmount_CurrencyCode,requestParameters.GetCurrencyCode()},
                {Constants.PlatformId,requestParameters.GetPlatformId()},
                {Constants.SellerNote,requestParameters.GetSellerNote()},
                {Constants.SellerOrderAttributes_StoreName,requestParameters.GetStoreName()},
                {Constants.SellerOrderAttributes_SellerOrderId,requestParameters.GetSellerOrderId()},
                {Constants.SellerOrderAttributes_CustomInformation,requestParameters.GetCustomInformation()},
                {Constants.AuthorizationReferenceId,requestParameters.GetAuthorizationReferenceId()},
                {Constants.SellerAuthorizationNote,requestParameters.GetSellerAuthorizationNote()},
                {Constants.TransactionTimeout,requestParameters.GetTransactionTimeout().ToString()},
                {Constants.SoftDescriptor,requestParameters.GetSoftDescriptor()},
                {Constants.InheritShippingAddress,requestParameters.GetInheritShippingAddress()},
                {Constants.CaptureNow,requestParameters.GetCaptureNow()},
                {Constants.MWSAuthToken,requestParameters.GetMWSAuthToken()}
            };
            string response = SetParametersAndPost(authorizeDictionary);
            AuthorizeResponse responseObject = new AuthorizeResponse(response);
            return responseObject;
        }

        /// <summary>
        /// CloseBillingAgreement API Call - Returns details about the billing agreement object and its current state.
        /// https://pay.amazon.com/documentation/apireference/201751950
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        /// <code>
        ///  CloseBillingAgreementRequest requestParameters = new CloseBillingAgreementRequest();
        ///   
        ///  // Required
        ///  requestParameters.WithAmazonBillingAgreementId("C01/B01-XXXXX-XXXXX");
        ///   
        ///  // Optional
        ///  requestParameters.WithMerchantId("MERCHANT_ID"); // Required if config["merchant_id"] is null
        ///  requestParameters.WithClosureReason("CLOSURE_REASON");
        ///  requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        /// </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        public CloseBillingAgreementResponse CloseBillingAgreement(CloseBillingAgreementRequest requestParameters)
        {
            Dictionary<string, string> closeBillingAgreementDictionary = new Dictionary<string, string>()
            {
                {Constants.Action,requestParameters.GetAction()},
                {Constants.SellerId,requestParameters.GetMerchantId()},
                {Constants.AmazonBillingAgreementId,requestParameters.GetAmazonBillingAgreementId()},
                {Constants.ClosureReason,requestParameters.GetClosureReason()},
                {Constants.MWSAuthToken,requestParameters.GetMWSAuthToken()}
            };
            string response = SetParametersAndPost(closeBillingAgreementDictionary);
            CloseBillingAgreementResponse responseObject = new CloseBillingAgreementResponse(response);
            return responseObject;
        }

        /// <summary>
        /// GetProviderCreditDetails API Call - Get the details of the Provider Credit.
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        /// <code>
        ///  GetProviderCreditReversalDetailsRequest requestParameters = new GetProviderCreditReversalDetailsRequest();
        ///  
        ///  // Required
        ///  requestParameters.WithAmazonProviderCreditId("PROVIDER_CREDIT_ID");
        ///  
        ///  // Optional
        ///  requestParameters.WithMerchantId("MERCHANT_ID"); // Required if config["merchant_id"] is null
        ///  requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        /// </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        public GetProviderCreditDetailsResponse GetProviderCreditDetails(GetProviderCreditDetailsRequest requestParameters)
        {
            Dictionary<string, string> getProviderCreditDetailsDictionary = new Dictionary<string, string>()
            {
                {Constants.Action,requestParameters.GetAction()},
                {Constants.SellerId,requestParameters.GetMerchantId()},
                {Constants.AmazonProviderCreditId,requestParameters.GetAmazonProviderCreditId()},
                {Constants.MWSAuthToken,requestParameters.GetMWSAuthToken()}
            };
            string response = SetParametersAndPost(getProviderCreditDetailsDictionary);
            GetProviderCreditDetailsResponse responseObject = new GetProviderCreditDetailsResponse(response);
            return responseObject;
        }

        /// <summary>
        /// GetProviderCreditReversalDetails API Call - Get details of the Provider Credit Reversal.
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        /// <code>
        ///  GetProviderCreditReversalDetailsRequest requestParameters = new GetProviderCreditReversalDetailsRequest();
        ///  
        ///  // Requirednew Dictionary
        ///  requestParameters.WithAmazonProviderCreditReversalId("PROVIDER_CREDIT_REVERSAL_ID");
        ///  
        ///  // Optional
        ///  requestParameters.WithMerchantId("MERCHANT_ID"); // Required if config["merchant_id"] is null
        ///  requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        /// </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        public GetProviderCreditReversalDetailsResponse GetProviderCreditReversalDetails(GetProviderCreditReversalDetailsRequest requestParameters)
        {
            Dictionary<string, string> getProviderCreditDetailsDictionary = new Dictionary<string, string>()
            {
                {Constants.Action,requestParameters.GetAction()},
                {Constants.SellerId,requestParameters.GetMerchantId()},
                {Constants.AmazonProviderCreditReversalId,requestParameters.GetAmazonProviderCreditReversalId()},
                {Constants.MWSAuthToken,requestParameters.GetMWSAuthToken()}
            };
            string response = SetParametersAndPost(getProviderCreditDetailsDictionary);
            GetProviderCreditReversalDetailsResponse responseObject = new GetProviderCreditReversalDetailsResponse(response);
            return responseObject;
        }

        /// <summary>
        /// ReverseProviderCredit API Call - Reverse the Provider Credit.
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        /// <code>
        ///  ReverseProviderCreditRequest requestParameters = new ReverseProviderCreditRequest();
        ///  
        ///  // Required
        ///  requestParameters.WithAmazonProviderCreditId("PROVIDER_CREDIT_ID");
        ///  requestParameters.WithCreditReversalReferenceId("UNIQUE_STRING");
        ///  requestParameters.WithAmount("10");
        ///  
        ///  
        ///  // Optional
        ///  requestParameters.WithMerchantId("MERCHANT_ID"); // Required if config["merchant_id"] is null
        ///  requestParameters.WithCurrencyCode(Regions.currencyCode.USD); // Required if config["currency_code"] is null
        ///  requestParameters.WithCreditReversalNote("CUSTOM_NOTE");
        ///  requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        /// </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        public GetProviderCreditReversalDetailsResponse ReverseProviderCredit(ReverseProviderCreditRequest requestParameters)
        {
            Dictionary<string, string> getProviderCreditDetailsDictionary = new Dictionary<string, string>()
            {
                {Constants.Action,requestParameters.GetAction()},
                {Constants.SellerId,requestParameters.GetMerchantId()},
                {Constants.AmazonProviderCreditId,requestParameters.GetAmazonProviderCreditId()},
                {Constants.CreditReversalReferenceId,requestParameters.GetCreditReversalReferenceId()},
                {Constants.CreditReversalAmount_Amount,requestParameters.GetAmount().ToString(Constants.USNumberFormat)},
                {Constants.CreditReversalAmount_CurrencyCode,requestParameters.GetCurrencyCode()},
                {Constants.MWSAuthToken,requestParameters.GetMWSAuthToken()}
            };
            string response = SetParametersAndPost(getProviderCreditDetailsDictionary);
            GetProviderCreditReversalDetailsResponse responseObject = new GetProviderCreditReversalDetailsResponse(response);
            return responseObject;
        }

        /// <summary>
        /// Charge convenience method
        /// Performs the API calls
        /// 1. SetOrderReferenceDetails / SetBillingAgreementDetails
        /// 2. ConfirmOrderReference / ConfirmBillingAgreement
        /// 3. Authorize / AuthorizeOnBillingAgreeemnt
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        ///  <code>
        ///   ChargeRequest requestParameters = new ChargeRequest();
        ///   
        ///   // Required
        ///   requestParameters.WithAmazonReferenceId("(S01/P01-XXXXX-XXXXX) / (C01/B01-XXXXX-XXXXX)");// order reference ID / billing agreement ID
        ///   requestParameters.WithAuthorizationReferenceId("UNIQUE_STRING"); // Any unique string that needs to be passed
        ///   requestParameters.WithAmount = "100";
        ///    
        ///   // Optional
        ///   requestParameters.WithMerchantId("MERCHANT_ID");
        ///   requestParameters.WithCurrencyCode(Regions.currencyCode.USD);
        ///   requestParameters.WithPlatformId("SOLUTION_PROVIDER_MERCHANT_ID");
        ///   requestParameters.WithSoftDescriptor("amz");
        ///   requestParameters.WithStoreName("cool stuff store");
        ///   requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        ///   requestParameters.WithChargeNote("sample note");
        ///   requestParameters.WithChargeOrderId("1234-1234");
        ///   requestParameters.WithCaptureNow(false);
        ///   requestParameters.WithProviderCreditDetails("PROVIDER_MERCHANT_ID", "10", "USD"); // This is only for the Order Reference type
        ///   requestParameters.WithInheritShippingAddress(true);
        ///   requestParameters.WithTransactionTimeout(5);
        ///   requestParameters.WithCustomInformation("custom information");
        ///  </code>
        /// </example>
        /// <returns>Dictionary response</returns>
        public AuthorizeResponse Charge(ChargeRequest requestParameters)
        {
            string xml, baStatus, oroStatus = string.Empty;
            var chargeException = new InvalidDataException();
            AuthorizeResponse authorizeResponseObject = null;
            bool getSuccess = false, setSuccess = false, confirmSuccess = false, authorizeSuccess = false;

            switch (requestParameters.chargeType)
            {
                case "OrderReference":
                    OrderReferenceDetailsResponse getOrderReferenceDetails = GetOrderReferenceDetails(requestParameters.getOrderReferenceDetails);
                    xml = getOrderReferenceDetails.GetXml();
                    getSuccess = getOrderReferenceDetails.GetSuccess();

                    // Call the function GetOrderReferenceStatus in ResponseParser.php providing it the XML response
                    // oroStatus - State of the order reference Id
                    oroStatus = getOrderReferenceDetails.GetOrderReferenceState();
                    if (oroStatus == null)
                    {
                        throw new NullReferenceException("The order reference state value is null" + xml);
                    }
                    if (oroStatus.Equals(Constants.Draft))
                    {
                        OrderReferenceDetailsResponse setorderReferenceDetailsResponseObject = SetOrderReferenceDetails(requestParameters.setOrderReferenceDetails);
                        xml = setorderReferenceDetailsResponseObject.GetXml();
                        setSuccess = setorderReferenceDetailsResponseObject.GetSuccess();
                        if (setSuccess)
                        {
                            ConfirmOrderReferenceResponse confirmOrderResponseObject = ConfirmOrderReference(requestParameters.confirmOrderReference);
                            xml = confirmOrderResponseObject.GetXml();
                            confirmSuccess = confirmOrderResponseObject.GetSuccess();
                            if (!confirmSuccess)
                            {
                                chargeException = new InvalidDataException(Constants.ConfirmOrderReference);
                                chargeException.Data["errorMessage"] = confirmOrderResponseObject.GetErrorMessage();
                                chargeException.Data["errorCode"] = confirmOrderResponseObject.GetErrorCode();
                                throw chargeException;
                            }
                        }
                        else
                        {
                            chargeException = new InvalidDataException(Constants.SetOrderReferenceDetails);
                            chargeException.Data["errorMessage"] = setorderReferenceDetailsResponseObject.GetErrorMessage();
                            chargeException.Data["errorCode"] = setorderReferenceDetailsResponseObject.GetErrorCode();
                            throw chargeException;
                        }
                    }

                    getOrderReferenceDetails = GetOrderReferenceDetails(requestParameters.getOrderReferenceDetails);
                    getSuccess = getOrderReferenceDetails.GetSuccess();

                    oroStatus = getOrderReferenceDetails.GetOrderReferenceState();
                    xml = getOrderReferenceDetails.GetXml();
                    if (getSuccess)
                    {
                        authorizeResponseObject = Authorize(requestParameters.authorizeOrderReference);
                        xml = authorizeResponseObject.GetXml();
                        authorizeSuccess = authorizeResponseObject.GetSuccess();

                    }
                    if (!authorizeSuccess)
                    {
                        chargeException = new InvalidDataException(Constants.Authorize);
                        chargeException.Data["errorMessage"] = authorizeResponseObject.GetErrorMessage();
                        chargeException.Data["errorCode"] = authorizeResponseObject.GetErrorCode();
                        throw chargeException;
                    }
                    if (!(oroStatus.Equals(Constants.Open) || oroStatus.Equals(Constants.Draft)))
                    {
                        throw new ArgumentException("The order reference is in the " + oroStatus + " State. It should be in the Draft or Open State" + xml);
                    }
                    break;

                case "BillingAgreement":
                    // Get the billing agreement details and feed the response object to the ResponseParser
                    BillingAgreementDetailsResponse billingAgreementDetailsResponse = GetBillingAgreementDetails(requestParameters.getBillingAgreementDetails);
                    xml = billingAgreementDetailsResponse.GetXml();
                    getSuccess = billingAgreementDetailsResponse.GetSuccess();

                    // Call the function GetBillingAgreementDetailsStatus in ResponseParser.php providing it the XML response
                    // baStatus - State of the billing agreement
                    baStatus = billingAgreementDetailsResponse.GetBillingAgreementState();
                    if (baStatus == null)
                    {
                        throw new NullReferenceException("The Billing Agreement state value is null" + xml);
                    }
                    if (!baStatus.Equals(Constants.Open))
                    {
                        BillingAgreementDetailsResponse setBillingAgreementDetailsResponse = SetBillingAgreementDetails(requestParameters.setBillingAgreementDetails);
                        xml = setBillingAgreementDetailsResponse.GetXml();

                        setSuccess = billingAgreementDetailsResponse.GetSuccess();

                        if (setSuccess)
                        {
                            ConfirmBillingAgreementResponse confirmBillingAgreementResponse = ConfirmBillingAgreement(requestParameters.confirmBillingAgreement);
                            xml = confirmBillingAgreementResponse.GetXml();
                            confirmSuccess = confirmBillingAgreementResponse.GetSuccess();

                            if (!confirmSuccess)
                            {
                                chargeException = new InvalidDataException(Constants.ConfirmBillingAgreement);
                                chargeException.Data["errorMessage"] = confirmBillingAgreementResponse.GetErrorMessage();
                                chargeException.Data["errorCode"] = confirmBillingAgreementResponse.GetErrorCode();
                                throw chargeException;
                            }
                        }
                        else
                        {
                            chargeException = new InvalidDataException(Constants.SetBillingAgreementDetails);
                            chargeException.Data["errorMessage"] = setBillingAgreementDetailsResponse.GetErrorMessage();
                            chargeException.Data["errorCode"] = setBillingAgreementDetailsResponse.GetErrorCode();
                            throw chargeException;
                        }
                    }
                    // Check the billing agreement status again before making the Authorization.
                    billingAgreementDetailsResponse = GetBillingAgreementDetails(requestParameters.getBillingAgreementDetails);
                    xml = billingAgreementDetailsResponse.GetXml();
                    getSuccess = billingAgreementDetailsResponse.GetSuccess();

                    baStatus = billingAgreementDetailsResponse.GetBillingAgreementState();

                    if (getSuccess)
                    {
                        authorizeResponseObject = AuthorizeOnBillingAgreement(requestParameters.authorizeOnBillingAgreement);
                        xml = authorizeResponseObject.GetXml();
                        authorizeSuccess = authorizeResponseObject.GetSuccess();
                    }
                    if (!authorizeSuccess)
                    {
                        chargeException = new InvalidDataException(Constants.AuthorizeOnBillingAgreement);
                        chargeException.Data["errorMessage"] = authorizeResponseObject.GetErrorMessage();
                        chargeException.Data["errorCode"] = authorizeResponseObject.GetErrorCode();
                        throw chargeException;
                    }
                    if (!(baStatus.Equals(Constants.Open) || (baStatus.Equals(Constants.Draft))))
                    {
                        throw new ArgumentException("The billing agreement is in the " + baStatus + " State. It should be in the Draft or Open State Authorize Response Error XML" + xml);
                    }
                    break;
            }

            return authorizeResponseObject;
        }

        /// <summary>
        /// Create an Dictionary of required parameters, sort them
        /// Calculate signature and invoke the POST to the MWS Service URL
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>parametersToString</returns>
        private string CalculateSignatureAndParametersToString(Dictionary<string, string> parameters)
        {
            signatureObject = new Signature(this.clientConfig, Constants.PaymentsServiceVersion);
            signatureObject.Logger = this.Logger;
            string parametersToString = signatureObject.CalculateSignatureAndReturnParametersAsString(parameters, this.timeStamp, this.mwsTestUrl);
            this.parameters = parameters;

            return parametersToString;
        }

        /// <summary>
        /// Invoke request and return response
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>responseBody</returns>
        private string Invoke(string parameters)
        {
            String responseBody = null;

            /// <summary>
            /// Boolean variable to check if the API call was a success
            /// </summary> 
            bool success = false;

            Dictionary<string, string> responseDict = new Dictionary<string, string>();

            int statusCode = 200;
            byte[] requestData = new UTF8Encoding().GetBytes(parameters);

            ConfigureUserAgentHeader();
            HttpImpl httpRequest = new HttpImpl(this.clientConfig);

            // Submit the request and read response body 
            bool shouldRetry;
            int retries = 0;
            do
            {
                shouldRetry = true;
                responseDict.Clear();
                responseDict = httpRequest.Post(signatureObject.GetMwsServiceUrl(), signatureObject.GetUserAgent(), requestData);

                responseBody = responseDict["response"];
                statusCode = int.Parse(responseDict["statusCode"]);

                if (statusCode == 200)
                {
                    shouldRetry = false;
                    success = true;
                }
                else if (Convert.ToBoolean(this.clientConfig.GetAutoRetryOnThrottle()) && (statusCode == 500 || statusCode == 503))
                {
                    ++retries;
                    if (shouldRetry)
                    {
                        PauseOnRetry(retries, statusCode);
                    }
                    else
                    {
                        shouldRetry = false;
                    }
                }
                else
                {
                    shouldRetry = false;
                }


            } while (shouldRetry);

            LogMessage(responseBody, SanitizeData.DataType.Response);
            return responseBody;
        }

        /// <summary>
        /// Exponential sleep on failed request
        /// </summary>
        /// <param name="retries"></param>
        /// <param name="status"></param>
        private void PauseOnRetry(int retries, int status)
        {
            if (retries <= Constants.MaxErrorRetry)
            {
                int delay = (int)Math.Pow(4, retries) * 100;
                System.Threading.Thread.Sleep(delay);
            }
            else
            {
                throw new WebException("Maximum number of retry attempts reached : " + (retries - 1) + " statusCode: " + status);
            }
        }

        /// <summary>
        /// Create Profile Endpoint URL
        /// </summary>
        /// <param name="regionProperties"></param>
        private string GetProfileEndpointUrl()
        {
            string region = string.Empty;
            string profileEnvt = Convert.ToBoolean(this.clientConfig.GetSandbox()) ? "api.sandbox" : "api";
            string profileEndpoint = string.Empty;

            if (!string.IsNullOrEmpty(this.clientConfig.GetRegion().ToString()))
            {
                region = this.clientConfig.GetRegion();
                if (Regions.regionMappings.ContainsKey(region))
                {
                    profileEndpoint = "https://" + profileEnvt + "." + Regions.ProfileEndpoint[region];
                }
                else
                {
                    throw new InvalidDataException(region + " is not a valid region");
                }
            }
            else
            {
                throw new NullReferenceException("region is a required parameter and is not set");
            }

            return profileEndpoint;
        }

        private void ConfigureUserAgentHeader()
        {
            signatureObject.SetUserAgentHeader(
                Environment.OSVersion.Platform + "/" + Environment.OSVersion.Version,
                ".NET/" + Environment.Version.ToString());
        }

        /// <summary>
        /// Helper method to log data within Client
        /// </summary>
        /// <param name="message"></param>
        private void LogMessage(string message, SanitizeData.DataType type)
        {
            if (this.Logger != null && this.Logger.IsDebugEnabled)
            {
                this.Logger.Debug(SanitizeData.SanitizeGivenData(message, type));
            }
        }
    }
}