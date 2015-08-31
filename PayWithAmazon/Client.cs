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
using PayWithAmazon.StandardPaymentRequests;
using PayWithAmazon.ProviderCreditRequests;
using PayWithAmazon.RecurringPaymentRequests;
using PayWithAmazon.CommonRequests;

namespace PayWithAmazon
{
    /// <summary>
    /// Class Client
    /// Takes configuration information
    /// Makes API calls to MWS for Pay With Amazon
    /// returns ResponseParser Object
    /// </summary>
    public class Client : PayWithAmazon.IClient
    {
        private const string MWS_CLIENT_VERSION = "1.0.0";
        private const string SERVICE_VERSION = "2013-01-01";
        private const int MAX_ERROR_RETRY = 3;

        private string userAgent = null;
        private IDictionary<string, string> parameters = new Dictionary<string, string>();
        private string mwsEndpointPath = null;
        private string mwsEndpointUrl = null;
        private string profileEndpoint = null;
        public string timeStamp = null;

        /// <summary>
        /// Configuration key and value pairs for the Client
        /// 1. These are set via the Configuration class object
        /// or
        /// 2. These can be set in the JSON File and the path to the JSON file input provided to the Client class constructor
        /// </summary>
        public Hashtable config = new Hashtable() {
            {"merchant_id",null},
            {"secret_key",null},
            {"access_key",null},
            {"region",null},
            {"currency_code",null},
            {"sandbox",false},
            {"platform_id",null},
            {"cabundle_file",null},
            {"application_name",null},
            {"application_version",null},
            {"proxy_host",null},
            {"proxy_port",-1},
            {"proxy_username",null},
            {"proxy_password",null},
            {"client_id",null},
            {"handle_throttle",true}
        };

        private string modePath = null;

        // Final URL to where the API parameters POST done,based off the config["region"] and respective mwsServiceUrls
        private string mwsServiceUrl = null;

        // Devo URL 
        private string mwsDevoEndpointUrl = null;

        /// <summary>
        /// Boolean variable to check if the API call was a success
        /// </summary>
        public bool success = false;

        Regions regionProperties = new Regions();

        /// <summary>
        /// Takes the Configuration Object of the Configuration class
        /// Validates the user configuration Hashtable against existing config Hashtable
        /// </summary>
        /// <param name="clientConfig"></param>
        /// <example>
        ///  <code>
        ///  Configuration clientConfig = new Configuration();
        ///  
        ///  // Required
        ///  clientConfig.Add("merchant_id","MERCHANT_ID");
        ///  // Following keys can be found in your seller central account.
        ///  clientConfig.WithSecretKey("MWS_SECRET_KEY"); 
        ///  clientConfig.WithAccessKey("MWS_ACCESS_KEY");
        ///  clientConfig.WithRegion("us");
        ///  
        ///  // Optional
        ///  clientConfig.WithCurrencyCode("USD");
        ///  clientConfig.WithSandbox(false); // true for sandbox , Defaults to false
        ///  clientConfig.WithPlatformId("PLATFORM_ID"); // Solution Provider ID
        ///  clientConfig.WithCABundleFile("CA_BUNDLE_PATH");
        ///  clientConfig.WithApplicationName("CUSTOM_APPLICATION_NAME");
        ///  clientConfig.WithApplicationVersion("CUSTOM_APPLICATION_VERSION");
        ///  clientConfig.WithProxyHost("PROXY_HOST");
        ///  clientConfig.WithProxyPort("PROXY_PORT");
        ///  clientConfig.WithProxyUserName("PROXY_USERNAME");
        ///  clientConfig.WithProxyPassword("PROXY_PASSWORD");
        ///  clientConfig.WithClientId("amzn.oa2.client.xxxx"); 
        ///  clientConfig.WithHandleThrottle(true); // Defaults to true
        ///  </code>
        /// </example>
        public Client(Configuration clientConfig)
        {
            if (clientConfig == null)
            {
                throw new NullReferenceException("config is null");
            }

            CheckConfigKeys(clientConfig.config);
        }

        /// <summary>
        /// Takes user configuration from the JSON file path provided and convert it to Hashtable config
        /// Validates the user configuration Hashtable against existing config Hashtable
        /// </summary>
        /// <param name="jsonFilePath"></param>
        public Client(string jsonFilePath)
        {
            string json;
            Hashtable config = new Hashtable();
            Dictionary<string, string> dict = new Dictionary<string, string>();

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
                    try
                    {
                        dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                    }
                    catch (JsonReaderException e)
                    {
                        throw new JsonReaderException("Incorrect JSON Format. Check your JSON config file for syntax errors\n" + e);
                    }

                    config = DictionaryToHashtable(dict);
                }
            }
            else
            {
                throw new NullReferenceException("Json file path is not provided");
            }

            CheckConfigKeys(config);
        }

        /// <summary>
        ///  Checks if the keys of the input configuration matches the keys in the config Hashtable
        ///  if they match the values are taken else throws KeyNotFoundException
        ///  strict case match is not performed
        /// </summary>
        /// <param name="config"></param>
        private void CheckConfigKeys(Hashtable config)
        {
            config = LowerKeys(config);

            foreach (DictionaryEntry pair in config)
            {
                if (this.config.ContainsKey(pair.Key))
                {
                    this.config[pair.Key] = pair.Value.ToString();
                }
                else
                {
                    throw new KeyNotFoundException("Key " + pair.Key + " is either not part of the configuration or has incorrect Key name." +
                        "check the Client class config Hashtable key names to match your key names of your input Hashtable configuation");
                }
            }
        }

        /// <summary>
        /// Lower the case of the Hashtable keys
        /// </summary>
        /// <param name="table"></param>
        /// <returns>Hashtable</returns>
        private Hashtable LowerKeys(Hashtable table)
        {
            Hashtable lowerKeyTable = new Hashtable();
            object input = null;
            foreach (DictionaryEntry newpair in table)
            {
                input = "";
                string key = newpair.Key.ToString().ToLower().Trim();
                if (newpair.Value != null)
                {
                    input = newpair.Value;
                }
                else
                {
                    input = "";
                }

                lowerKeyTable.Add(key, input);
            }
            return lowerKeyTable;
        }

        /// <summary>
        /// Setter for sandbox
        /// Sets the Boolean value for config["sandbox"] variable
        /// </summary>
        /// <param name="input"></param>
        public void SetSandbox(bool input)
        {
            config["sandbox"] = input;
        }

        /// <summary>
        /// Setter for config["client_id"]
        /// Sets the value for config["client_id"] variable
        /// </summary>
        /// <param name="input"></param>
        public void SetClientId(string input)
        {
            try
            {
                if (!string.IsNullOrEmpty(input))
                {
                    config["client_id"] = input;
                }
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException("Client ID value cannot be empty" + e);
            }
        }

        /// <summary>
        /// Setter for Proxy
        /// </summary>
        /// <param name="proxy"></param>
        /// <example>
        ///  <code>
        ///   string proxy_host = "PROXY_HOST_NAME";
        ///   int proxy_port = 1234;
        ///   string proxy_user_name = "PROXY_USER_NAME";
        ///   string proxy_user_password = "PROXY_USER_PASSWORD";
        ///  </code>
        /// </example>
        public void SetProxy(string proxy_host = "", int proxy_port = -1, string proxy_user_name = "", string proxy_user_password = "")
        {
            if (!string.IsNullOrEmpty(proxy_host))
            {
                config["proxy_host"] = proxy_host;
            }

            if (proxy_port != -1)
            {
                config["proxy_port"] = proxy_port;
            }

            if (!string.IsNullOrEmpty(proxy_user_name))
            {
                config["proxy_username"] = proxy_user_name;
            }

            if (!string.IsNullOrEmpty(proxy_user_password))
            {
                config["proxy_password"] = proxy_user_password;
            }
        }

        /// <summary>
        /// Setter for mwsServiceUrl
        /// Set the URL to which the post request has to be made for unit testing
        /// </summary>
        /// <param name="url"></param>
        public void SetMwsServiceUrl(string url)
        {
            this.mwsServiceUrl = url;
        }

        /// <summary>
        /// Setter for mwsDevoUrl
        /// Set the URL for Devopment testing
        /// </summary>
        /// <param name="url"></param>
        public void SetMwsDevoUrl(string url)
        {
            this.mwsDevoEndpointUrl = url;
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
        /// Gets the value for the key if the key exists in config
        /// </summary>
        /// <param name="name"></param>
        /// <returns>string</returns>
        public string GetConfigValue(string name)
        {
            string input = "";

            if (config.ContainsKey(name))
            {
                input = config[name].ToString().ToLower();
                return input;
            }
            else
            {
                throw new NullReferenceException("Key " + name + " is either not a part of the configuration Hashtable config or the" + name +
                    "does not match the key name in the config Hashtable");
            }
        }

        /// <summary>
        /// Gets the value for the parameters string for unit testing
        /// </summary>
        /// <returns>IDictionary parameters</returns>
        public IDictionary<string, string> GetParameters()
        {
            return this.parameters;
        }

        /// <summary>
        /// SetParametersAndPost - sets the parameters Hashtable with non empty values from the requestParameters Hashtable sent to API calls.
        /// If Provider Credit Details is present, values are set by setProviderCreditDetails
        /// If Provider Credit Reversal Details is present, values are set by setProviderCreditDetails
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="fieldMappings"></param>
        /// <param name="requestParameters"></param>
        /// <returns>ResponseParser Object</returns>
        private ResponseParser SetParametersAndPost(Hashtable parameters, Hashtable fieldMappings, Hashtable requestParameters)
        {
            string input = "";
            List<Hashtable> providerCredit = new List<Hashtable>();
            bool isProviderCredit = false;
            // For loop to take all the non empty parameters in the requestParameters and add it into the parameters Hashtable,
            // if the keys are matched from requestParameters Hashtable with the fieldMappings Hashtable

            foreach (DictionaryEntry pair in requestParameters)
            {
                if (pair.Value != null && !(pair.Value.GetType() == typeof(List<Hashtable>)))
                {
                    input = pair.Value.ToString().Trim();
                    isProviderCredit = false;
                }
                else
                {
                    isProviderCredit = true;
                    providerCredit = pair.Value as List<Hashtable>;
                }

                if (input != "" && input != null)
                {
                    if (isProviderCredit)
                    {
                        // If the parameter is a provider_credit_details or provider_credit_reversal_details, call the respective functions to set the values
                        if (pair.Key.Equals("provider_credit_details"))
                        {
                            parameters = SetProviderCreditDetails(parameters, providerCredit);
                        }
                        else if (pair.Key.Equals("provider_credit_reversal_details"))
                        {
                            parameters = SetProviderCreditReversalDetails(parameters, providerCredit);
                        }

                    }
                    else
                    {
                        // For variables that are boolean values, change their case to lower
                        input = CheckIfBoolAndLowerValue(input);
                        parameters[fieldMappings[pair.Key]] = input;
                    }
                }

            }
            parameters = SetDefaultValues(parameters, fieldMappings, requestParameters);

            ResponseParser responseObject = CalculateSignatureAndPost(parameters);
            return responseObject;
        }

        public static Dictionary<string, string> HashtableToDictionary<K, V>(Hashtable table)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            foreach (DictionaryEntry kvp in table)
                dict.Add(kvp.Key.ToString(), kvp.Value.ToString());
            return dict;
        }

        public static Hashtable DictionaryToHashtable(Dictionary<string, string> dict)
        {
            Hashtable hash = new Hashtable();
            foreach (var pair in dict)
            {
                hash.Add(pair.Key, pair.Value);
            }
            return hash;
        }

        /// <summary>
        ///  CheckIfBoolAndLowerValue - checks if the input string contains is a boolean value
        /// </summary>
        /// <param name="input"></param>
        /// <returns>string input</returns>
        private string CheckIfBoolAndLowerValue(string input)
        {
            string loweredInput = input.ToLower();
            bool result;
            if (bool.TryParse(loweredInput, out result))
            {
                // return boolean value as string
                return loweredInput;
            }
            else
            {
                return input;
            }
        }

        /// <summary>
        /// CalculateSignatureAndPost - convert the Parameters Hashtable to string and POST the parameters to MWS
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>ResponseParser Object</returns>
        public ResponseParser CalculateSignatureAndPost(Hashtable parameters)
        {
            // Call the signature and Post function to perform the actions.
            string parametersString = CalculateSignatureAndParametersToString(HashtableToDictionary<string, string>(parameters));

            // Invokes Http POST method with string converted Parameters as data
            string response = Invoke(parametersString);

            // Send this response as args to ResponseParser class which will return the object of the class.
            ResponseParser responseObject = new ResponseParser(response);
            return responseObject;
        }

        /// <summary>
        /// If merchant_id is not set via the requestParameters Hashtable then it's taken from the config Hashtable
        /// Set the platform_id if set in the config["platform_id"] Hashtable
        /// If currency_code is set in the requestParameters and it exists in the fieldMappings Hashtable,strtoupper it
        /// else take the value from config Hashtable if set
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="fieldMappings"></param>
        /// <param name="requestParameters"></param>
        /// <returns>Hashtable parameters</returns>
        private Hashtable SetDefaultValues(Hashtable parameters, Hashtable fieldMappings, Hashtable requestParameters)
        {
            List<string> defaultParams = new List<string>()
            {
                "merchant_id",
                "platform_id",
                "currency_code"
            };

            string input = "";
            foreach (string param in defaultParams)
            {
                input = "";
                if (fieldMappings.ContainsKey(param))
                {
                    if (requestParameters.ContainsKey(param))
                    {
                        if (requestParameters[param] != null)
                        {
                            input = requestParameters[param].ToString().Trim();
                        }
                    }
                    if (input != null && input != "")
                    {
                        parameters[fieldMappings[param]] = requestParameters[param];
                    }
                    else if (config[param] != null && config[param].ToString().Trim() != "")
                    {
                        parameters[fieldMappings[param]] = config[param];
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
        /// <returns>Hashtable parameters</returns>
        private Hashtable SetProviderCreditDetails(Hashtable parameters, List<Hashtable> providerCreditInfo)
        {
            int providerIndex = 0;
            string providerString = "ProviderCreditList.member.";

            Hashtable fieldMappings = new Hashtable()  
            {
                {"provider_id","ProviderId"},
                {"credit_amount","CreditAmount.Amount"},
                {"currency_code","CreditAmount.CurrencyCode"}
            };

            foreach (Hashtable pair in providerCreditInfo)
            {
                Hashtable innerDictionary = LowerKeys(pair);
                providerIndex = providerIndex + 1;

                foreach (DictionaryEntry keypair in innerDictionary)
                {
                    if (fieldMappings.ContainsKey(keypair.Key) && (keypair.Value.ToString().Trim()) != "")
                    {
                        parameters[providerString + providerIndex + "." + fieldMappings[keypair.Key]] = keypair.Value;
                    }
                }

                // If currency code is not entered take it from the config Hashtable
                if (string.IsNullOrEmpty(parameters[providerString + providerIndex + "." + fieldMappings["currency_code"].ToString()].ToString()))
                {
                    parameters[providerString + providerIndex + "." + fieldMappings["currency_code"]] = config["currency_code"].ToString().ToUpper();
                }
            }

            return parameters;
        }

        /// <summary>
        /// SetProviderCreditReversalDetails - sets the reverse provider credit details sent via the Refund API call.
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="providerCreditInfo"></param>
        /// <returns>Hashtable parameters</returns>
        private Hashtable SetProviderCreditReversalDetails(Hashtable parameters, List<Hashtable> providerCreditInfo)
        {
            int providerIndex = 0;
            string providerString = "ProviderCreditReversalList.member.";

            Hashtable fieldMappings = new Hashtable()  
            {
                {"provider_id","ProviderId"},
                {"credit_reversal_amount","CreditReversalAmount.Amount"},
                {"currency_code","CreditReversalAmount.CurrencyCode"}
            };

            foreach (Hashtable pair in providerCreditInfo)
            {
                Hashtable innerDictionary = LowerKeys(pair);

                foreach (DictionaryEntry keypair in innerDictionary)
                {
                    if (fieldMappings.ContainsKey(keypair.Key) && (keypair.Value.ToString().Trim()) != "")
                    {
                        parameters[providerString + providerIndex + "." + fieldMappings[keypair.Key]] = keypair.Value;
                    }
                }

                // If currency code is not entered take it from the config Hashtable
                if (string.IsNullOrEmpty(parameters[providerString + providerIndex + "." + fieldMappings["currency_code"].ToString()].ToString()))
                {
                    parameters[providerString + providerIndex + "." + fieldMappings["currency_code"]] = config["currency_code"].ToString().ToUpper();
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
            ProfileEndpointUrl(regionProperties);

            if (string.IsNullOrEmpty(accessToken))
            {
                throw new NullReferenceException("Access Token is a required parameter and is not set");
            }
            if (string.IsNullOrEmpty(config["client_id"].ToString()))
            {
                throw new NullReferenceException("client ID is a required parameter and is not set");
            }

            accessToken = System.Web.HttpUtility.UrlDecode(accessToken);
            string url = profileEndpoint + "/auth/o2/tokeninfo?access_token=" + System.Web.HttpUtility.UrlEncode(accessToken);

            HttpImpl httpRequest = new HttpImpl(config);
            response = httpRequest.Get(url);

            Dictionary<string, string> data = JsonConvert.DeserializeObject<Dictionary<string, string>>(response);
            if (!(data["aud"].Equals(config["client_id"].ToString())))
            {
                throw new InvalidDataException("The Access token entered is incorrect");
            }

            url = profileEndpoint + "/user/profile";
            httpRequest = new HttpImpl(config);
            httpRequest.setAccessToken(accessToken);
            httpRequest.setHttpHeader();

            response = httpRequest.Get(url);
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
        public ResponseParser GetOrderReferenceDetails(GetOrderReferenceDetailsRequest requestParameters)
        {
            Hashtable parameters = new Hashtable();

            parameters["Action"] = "GetOrderReferenceDetails";

            Hashtable fieldMappings = new Hashtable()  {
                {"merchant_id","SellerId"},
                {"amazon_order_reference_id","AmazonOrderReferenceId"},
                {"address_consent_token","AddressConsentToken"},
                {"mws_auth_token","MWSAuthToken"}
            };

            ResponseParser responseObject = SetParametersAndPost(parameters, fieldMappings, requestParameters.getOrderReferenceDetailsHashtable);
            return responseObject;
        }

        /// <summary>
        /// SetOrderReferenceDetails API call - Sets order reference details such as the order total and a description for the order.
        /// https://payments.amazon.com/documentation/apireference/201751960
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        ///  <code>
        ///   SetOrderReferenceDetailsRequest requestParameters = new SetOrderReferenceDetailsRequest();
        ///  
        ///   // Required Parameters
        ///   requestParameters.WithAmazonOrderReferenceId("S01/P01-XXXXX-XXXXX");
        ///   requestParameters.WithAmount("100");
        ///   requestParameters.WithCurrencyCode("USD"); // Required if config["currency_code"] is null
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
        public ResponseParser SetOrderReferenceDetails(SetOrderReferenceDetailsRequest requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "SetOrderReferenceDetails";

            Hashtable fieldMappings = new Hashtable()  {
                {"merchant_id","SellerId"},
                {"amazon_order_reference_id","AmazonOrderReferenceId"},
                {"amount","OrderReferenceAttributes.OrderTotal.Amount"},
                {"currency_code","OrderReferenceAttributes.OrderTotal.CurrencyCode"},
                {"platform_id","OrderReferenceAttributes.PlatformId"},
                {"seller_note","OrderReferenceAttributes.SellerNote"},
                {"seller_order_id","OrderReferenceAttributes.SellerOrderAttributes.SellerOrderId"},
                {"store_name","OrderReferenceAttributes.SellerOrderAttributes.StoreName"},
                {"custom_information","OrderReferenceAttributes.SellerOrderAttributes.CustomInformation"},
                {"mws_auth_token","MWSAuthToken"}
            };

            ResponseParser responseObject = SetParametersAndPost(parameters, fieldMappings, requestParameters.setOrderReferenceDetailsHashtable);
            return (responseObject);
        }

        /// <summary>
        /// ConfirmOrderReference API call - Confirms that the order reference is free of constraints and all required information has been set on the order reference.
        /// https://payments.amazon.com/documentation/apireference/201751980
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
        public ResponseParser ConfirmOrderReference(ConfirmOrderReferenceRequest requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "ConfirmOrderReference";

            Hashtable fieldMappings = new Hashtable()  {
                {"merchant_id","SellerId"},
                {"amazon_order_reference_id","AmazonOrderReferenceId"},
                {"mws_auth_token","MWSAuthToken"}
            };

            ResponseParser responseObject = SetParametersAndPost(parameters, fieldMappings, requestParameters.confirmOrderReferenceHashtable);
            return (responseObject);
        }

        /// <summary>
        /// CancelOrderReferenceDetails API call - Cancels a previously confirmed order reference.
        /// https://payments.amazon.com/documentation/apireference/201751990"
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
        public ResponseParser CancelOrderReference(CancelOrderReferenceRequest requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "CancelOrderReference";

            Hashtable fieldMappings = new Hashtable()  {
                {"merchant_id","SellerId"},
                {"amazon_order_reference_id","AmazonOrderReferenceId"},
                {"cancelation_reason","CancelationReason"},
                {"mws_auth_token","MWSAuthToken"}
            };

            ResponseParser responseObject = SetParametersAndPost(parameters, fieldMappings, requestParameters.cancelOrderReferenceHashtable);
            return (responseObject);
        }

        /// <summary>
        /// CloseOrderReference API call - Confirms that an order reference has been fulfilled (fully or partially)
        /// https://payments.amazon.com/documentation/apireference/201752000
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
        public ResponseParser CloseOrderReference(CloseOrderReferenceRequest requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "CloseOrderReference";

            Hashtable fieldMappings = new Hashtable()  {
                {"merchant_id","SellerId"},
                {"amazon_order_reference_id","AmazonOrderReferenceId"},
                {"closure_reason","ClosureReason"},
                {"mws_auth_token","MWSAuthToken"}
            };

            ResponseParser responseObject = SetParametersAndPost(parameters, fieldMappings, requestParameters.closeOrderReferenceHashtable);
            return (responseObject);
        }

        /// <summary>
        /// CloseAuthorization API call - Closes an authorization.
        /// https://payments.amazon.com/documentation/apireference/201752070
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
        public ResponseParser CloseAuthorization(CloseAuthorizationRequest requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "CloseAuthorization";

            Hashtable fieldMappings = new Hashtable {
                {"merchant_id","SellerId"},
                {"amazon_authorization_id","AmazonAuthorizationId"},
                {"closure_reason","ClosureReason"},
                {"mws_auth_token","MWSAuthToken"}
            };
            ResponseParser responseObject = SetParametersAndPost(parameters, fieldMappings, requestParameters.closeAuthorizationHashtable);
            return (responseObject);
        }

        /// <summary>
        /// Authorize API call - Reserves a specified amount against the payment method(s) stored in the order reference.
        /// https://payments.amazon.com/documentation/apireference/201752010
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
        ///   requestParameters.WithCurrencyCode("USD"); // Required if config["currency_code"] is null
        ///   requestParameters.WithAuthorizationReferenceId("UNIQUE_STRING");
        ///   requestParameters.WithCaptureNow(false); // Defaults to false
        ///   requestParameters.WithProviderCreditDetails("list_of_Hashtable"); // [list(Hashtable)]
        ///   requestParameters.WithSellerAuthorizationNote("CUSTOM_NOTE");
        ///   requestParameters.WithTransactionTimeout(5); // Defaults to 1440 minutes
        ///   requestParameters.WithSoftDescriptor("AMZ*CUSTOM");
        ///   requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        ///  </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        public ResponseParser Authorize(AuthorizeRequest requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "Authorize";

            Hashtable fieldMappings = new Hashtable()  {
                {"merchant_id","SellerId"},
                {"amazon_order_reference_id","AmazonOrderReferenceId"},
                {"authorization_amount","AuthorizationAmount.Amount"},
                {"currency_code","AuthorizationAmount.CurrencyCode"},
                {"authorization_reference_id","AuthorizationReferenceId"},
                {"capture_now","CaptureNow"},
                {"provider_credit_details",typeof(List<Hashtable>)},
                {"seller_authorization_note","SellerAuthorizationNote"},
                {"transaction_timeout","TransactionTimeout"},
                {"soft_descriptor","SoftDescriptor"},
                {"mws_auth_token","MWSAuthToken"},
            };
            ResponseParser responseObject = SetParametersAndPost(parameters, fieldMappings, requestParameters.authorizeHashtable);
            return responseObject;
        }

        /// <summary>
        /// GetAuthorizationDetails API call - Returns the status of a particular authorization and the total amount captured on the authorization.
        /// https://payments.amazon.com/documentation/apireference/201752030
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
        public ResponseParser GetAuthorizationDetails(GetAuthorizationDetailsRequest requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "GetAuthorizationDetails";

            Hashtable fieldMappings = new Hashtable()  
            {
                {"merchant_id","SellerId"},
                {"amazon_authorization_id","AmazonAuthorizationId"},
                {"mws_auth_token","MWSAuthToken"},
            };

            ResponseParser responseObject = SetParametersAndPost(parameters, fieldMappings, requestParameters.getAuthorizationDetailsHashtable);
            return (responseObject);
        }

        /// <summary>
        /// Capture API call - Captures funds from an authorized payment instrument
        /// https://payments.amazon.com/documentation/apireference/201752040
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
        ///   requestParameters.WithCurrencyCode("USD"); // Required if config["currency_code"] is null
        ///   requestParameters.WithProviderCreditDetails([list(Hashtable)]); // list of Provider Credit Hashtable(s) details
        ///   requestParameters.WithSellerCaptureNote("CUSTOM_NOTE");
        ///   requestParameters.WithSetSoftDescriptor("AMZ*CUSTOM");
        ///   requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        ///  </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        public ResponseParser Capture(CaptureRequest requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "Capture";

            Hashtable fieldMappings = new Hashtable()  
            {
                {"merchant_id","SellerId"},
                {"amazon_authorization_id","AmazonAuthorizationId"},
                {"capture_amount","CaptureAmount.Amount"},
                {"currency_code","CaptureAmount.CurrencyCode"},
                {"capture_reference_id","CaptureReferenceId"},
                {"provider_credit_details",typeof(List<Hashtable>)},
                {"seller_capture_note","SellerCaptureNote"},
                {"soft_descriptor","SoftDescriptor"},
                {"mws_auth_token","MWSAuthToken"}
            };

            ResponseParser responseObject = SetParametersAndPost(parameters, fieldMappings, requestParameters.captureHashtable);
            return (responseObject);
        }

        /// <summary>
        /// GetCaptureDetails API call - Returns the status of a particular capture and the total amount refunded on the capture.
        /// https://payments.amazon.com/documentation/apireference/201752060
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
        public ResponseParser GetCaptureDetails(GetCaptureDetailsRequest requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "GetCaptureDetails";

            Hashtable fieldMappings = new Hashtable()  
            {
                {"merchant_id","SellerId"},
                {"amazon_capture_id","AmazonCaptureId"},
                {"mws_auth_token","MWSAuthToken"},
            };

            ResponseParser responseObject = SetParametersAndPost(parameters, fieldMappings, requestParameters.getCaptureDetailsHashtable);
            return (responseObject);
        }

        /// <summary>
        /// Refund API call - Refunds a previously captured amount.
        /// https://payments.amazon.com/documentation/apireference/201752080
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
        ///   requestParameters.WithCurrencyCode("USD"); // Required if config["currency_code"] is null
        ///   requestParameters.WithProviderCreditReversalDetails("PROVIDER_ID","10","USD"); // Provider Credit details
        ///   requestParameters.WithSellerRefundNote("CUSTOM_NOTE");
        ///   requestParameters.WithSoftDescriptor("AMZ*CUSTOM");
        ///   requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        ///  </code>
        /// </example>
        /// <param name="requestParameters"></param>
        /// <returns>ResponseParser responseObject</returns>
        public ResponseParser Refund(RefundRequest requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "Refund";

            Hashtable fieldMappings = new Hashtable()  
            {
                {"merchant_id","SellerId"},
                {"amazon_capture_id","AmazonCaptureId"},
                {"refund_reference_id","RefundReferenceId"},
                {"refund_amount","RefundAmount.Amount"},
                {"currency_code","RefundAmount.CurrencyCode"},
                {"provider_credit_reversal_details",typeof(List<Hashtable>)},
                {"seller_refund_note","SellerRefundNote"},
                {"soft_descriptor","SoftDescriptor"},
                {"mws_auth_token","MWSAuthToken"}
            };

            ResponseParser responseObject = SetParametersAndPost(parameters, fieldMappings, requestParameters.refundHashtable);
            return (responseObject);
        }

        /// <summary>
        /// GetRefundDetails API call - Returns the status of a particular refund.
        /// https://payments.amazon.com/documentation/apireference/201752100
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
        public ResponseParser GetRefundDetails(GetRefundDetailsRequest requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "GetRefundDetails";

            Hashtable fieldMappings = new Hashtable()  
            {
                {"merchant_id","SellerId"},
                {"amazon_refund_id","AmazonRefundId"},
                {"mws_auth_token","MWSAuthToken"}
            };

            ResponseParser responseObject = SetParametersAndPost(parameters, fieldMappings, requestParameters.getRefundDetailsHashtable);
            return (responseObject);
        }

        /// <summary>
        /// GetServiceStatus API Call - Returns the operational status of the Off-Amazon Payments API section
        /// section of Amazon Marketplace Web Service (Amazon MWS). Status values are GREEN, GREEN_I, YELLOW, and RED.
        /// https://payments.amazon.com/documentation/apireference/201752110
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
        public ResponseParser GetServiceStatus(GetServiceStatusRequest requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "GetServiceStatus";

            Hashtable fieldMappings = new Hashtable()
            {
                {"merchant_id","SellerId"},
                {"mws_auth_token","MWSAuthToken"}
            };

            ResponseParser responseObject = SetParametersAndPost(parameters, fieldMappings, requestParameters.getServiceStatusRequestHashtable);
            return (responseObject);
        }

        /// <summary>
        /// CreateOrderReferenceForId API Call - Creates an order reference for the given object
        /// https://payments.amazon.com/documentation/apireference/201751670
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
        ///   requestParameters.WithCurrencyCode("USD"); // Required if config["currency_code"] is null
        ///   requestParameters.WithSellerNote("CUSTOM_NOTE");
        ///   requestParameters.WithSellerOrderId("CUSTOM_ORDER_ID");
        ///   requestParameters.WithStoreName("CUSTOM_NAME");
        ///   requestParameters.WithCustomInformation("CUSTOM_INFO");
        ///   requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        ///  </code>
        /// </example>
        /// <param name="requestParameters"></param>
        /// <returns>ResponseParser responseObject</returns>
        public ResponseParser CreateOrderReferenceForId(CreateOrderReferenceForIdRequest requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "CreateOrderReferenceForId";

            Hashtable fieldMappings = new Hashtable()  
            {
                {"merchant_id","SellerId"},
                {"id","Id"},
                {"id_type","IdType"},
                {"inherit_shipping_address","InheritShippingAddress"},
                {"confirm_now","ConfirmNow"},
                {"amount","OrderReferenceAttributes.OrderTotal.Amount"},
                {"currency_code","OrderReferenceAttributes.OrderTotal.CurrencyCode"},
                {"platform_id","OrderReferenceAttributes.PlatformId"},
                {"seller_note","OrderReferenceAttributes.SellerNote"},
                {"seller_order_id","OrderReferenceAttributes.SellerOrderAttributes.SellerOrderId"},
                {"store_name","OrderReferenceAttributes.SellerOrderAttributes.StoreName"},
                {"custom_information","OrderReferenceAttributes.SellerOrderAttributes.CustomInformation"},
                {"mws_auth_token","MWSAuthToken"}
            };

            ResponseParser responseObject = SetParametersAndPost(parameters, fieldMappings, requestParameters.createOrderReferenceForIdHashtable);
            return (responseObject);
        }

        /// <summary>
        /// GetBillingAgreementDetails API Call - Returns details about the billing agreement object and its current state.
        /// https://payments.amazon.com/documentation/apireference/201751690
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
        public ResponseParser GetBillingAgreementDetails(GetBillingAgreementDetailsRequest requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "GetBillingAgreementDetails";

            Hashtable fieldMappings = new Hashtable()  
            {
                 {"merchant_id","SellerId"},
                 {"amazon_billing_agreement_id","AmazonBillingAgreementId"},
                 {"address_consent_token","AddressConsentToken"},
                 {"mws_auth_token","MWSAuthToken"}
            };

            ResponseParser responseObject = SetParametersAndPost(parameters, fieldMappings, requestParameters.getBillingAgreementDetailsHashtable);
            return (responseObject);
        }

        /// <summary>
        /// SetBillingAgreementDetails API call - Sets billing agreement details such as a description of the agreement and other information about the seller.
        /// https://payments.amazon.com/documentation/apireference/201751700
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
        ///   requestParameters.WithCurrencyCode("USD"); // Required if config["currency_code"] is null
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
        public ResponseParser SetBillingAgreementDetails(SetBillingAgreementDetailsRequest requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "SetBillingAgreementDetails";

            Hashtable fieldMappings = new Hashtable()  
            {
                {"merchant_id","SellerId"},
                {"amazon_billing_agreement_id","AmazonBillingAgreementId"},
                {"platform_id","BillingAgreementAttributes.PlatformId"},
                {"seller_note","BillingAgreementAttributes.SellerNote"},
                {"seller_billing_agreement_id","BillingAgreementAttributes.SellerBillingAgreementAttributes.SellerBillingAgreementId"},
                {"custom_information","BillingAgreementAttributes.SellerBillingAgreementAttributes.CustomInformation"},
                {"store_name","BillingAgreementAttributes.SellerBillingAgreementAttributes.StoreName"},
                {"mws_auth_token","MWSAuthToken"}
            };

            ResponseParser responseObject = SetParametersAndPost(parameters, fieldMappings, requestParameters.setBillingAgreementDetailsHashtable);
            return (responseObject);
        }

        /// <summary>
        /// ConfirmBillingAgreement API Call - Confirms that the billing agreement is free of constraints and all required information has been set on the billing agreement.
        /// https://payments.amazon.com/documentation/apireference/201751710
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
        public ResponseParser ConfirmBillingAgreement(ConfirmBillingAgreementRequest requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "ConfirmBillingAgreement";

            Hashtable fieldMappings = new Hashtable()  
            {
                 {"merchant_id","SellerId"},
                 {"amazon_billing_agreement_id","AmazonBillingAgreementId"},
                 {"mws_auth_token","MWSAuthToken"}
            };

            ResponseParser responseObject = SetParametersAndPost(parameters, fieldMappings, requestParameters.confirmBillingAgreementHashtable);
            return (responseObject);
        }

        /// <summary>
        /// ValidateBillignAgreement API Call - Validates the status of the billing agreement object and the payment method associated with it.
        /// https://payments.amazon.com/documentation/apireference/201751720
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
        public ResponseParser ValidateBillingAgreement(ValidateBillingAgreementRequest requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "ValidateBillingAgreement";

            Hashtable fieldMappings = new Hashtable()  
            {
                 {"merchant_id","SellerId"},
                 {"amazon_billing_agreement_id","AmazonBillingAgreementId"},
                 {"mws_auth_token","MWSAuthToken"}
            };

            ResponseParser responseObject = SetParametersAndPost(parameters, fieldMappings, requestParameters.validateBillingAgreementHashtable);
            return (responseObject);
        }

        /// <summary>
        /// AuthorizeOnBillingAgreement API call - Reserves a specified amount against the payment method(s) stored in the billing agreement.
        /// https://payments.amazon.com/documentation/apireference/201751940
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
        ///   requestParameters.WithCurrencyCode("USD"); // Required if config["currency_code"] is null
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
        public ResponseParser AuthorizeOnBillingAgreement(AuthorizeOnBillingAgreementRequest requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "AuthorizeOnBillingAgreement";

            Hashtable fieldMappings = new Hashtable()
            {
                {"merchant_id","SellerId"},
                {"amazon_billing_agreement_id","AmazonBillingAgreementId"},
                {"authorization_reference_id","AuthorizationReferenceId"},
                {"authorization_amount","AuthorizationAmount.Amount"},
                {"currency_code","AuthorizationAmount.CurrencyCode"},
                {"seller_authorization_note","SellerAuthorizationNote"},
                {"transaction_timeout","TransactionTimeout"},
                {"capture_now","CaptureNow"},
                {"soft_descriptor","SoftDescriptor"},
                {"seller_note","SellerNote"},
                {"platform_id","PlatformId"},
                {"custom_information","SellerOrderAttributes.CustomInformation"},
                {"seller_order_id","SellerOrderAttributes.SellerOrderId"},
                {"store_name","SellerOrderAttributes.StoreName"},
                {"inherit_shipping_address","InheritShippingAddress"},
                {"mws_auth_token","MWSAuthToken"}
            };

            ResponseParser responseObject = SetParametersAndPost(parameters, fieldMappings, requestParameters.authorizeOnBillingAgreementHashtable);
            return (responseObject);
        }

        /// <summary>
        /// CloseBillingAgreement API Call - Returns details about the billing agreement object and its current state.
        /// https://payments.amazon.com/documentation/apireference/201751950
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
        public ResponseParser CloseBillingAgreement(CloseBillingAgreementRequest requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "CloseBillingAgreement";

            Hashtable fieldMappings = new Hashtable()  
            {
                {"merchant_id","SellerId"},
                {"amazon_billing_agreement_id","AmazonBillingAgreementId"},
                {"closure_reason","ClosureReason"},
                {"mws_auth_token","MWSAuthToken"}
            };

            ResponseParser responseObject = SetParametersAndPost(parameters, fieldMappings, requestParameters.closeBillingAgreementHashtable);
            return (responseObject);
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
        public ResponseParser GetProviderCreditDetails(GetProviderCreditReversalDetailsRequest requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "GetProviderCreditDetails";

            Hashtable fieldMappings = new Hashtable
            {
                {"merchant_id","SellerId"},
                {"amazon_provider_credit_id","AmazonProviderCreditId"},
                {"mws_auth_token", "MWSAuthToken"}
            };

            ResponseParser responseObject = SetParametersAndPost(parameters, fieldMappings, requestParameters.getProviderCreditReversalDetailsHashtable);
            return (responseObject);
        }

        /// <summary>
        /// GetProviderCreditReversalDetails API Call - Get details of the Provider Credit Reversal.
        /// </summary>
        /// <param name="requestParameters"></param>
        /// <example>
        /// <code>
        ///  GetProviderCreditReversalDetailsRequest requestParameters = new GetProviderCreditReversalDetailsRequest();
        ///  
        ///  // Required
        ///  requestParameters.WithAmazonProviderCreditReversalId("PROVIDER_CREDIT_REVERSAL_ID");
        ///  
        ///  // Optional
        ///  requestParameters.WithMerchantId("MERCHANT_ID"); // Required if config["merchant_id"] is null
        ///  requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        /// </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        public ResponseParser GetProviderCreditReversalDetails(GetProviderCreditReversalDetailsRequest requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "GetProviderCreditReversalDetails";

            Hashtable fieldMappings = new Hashtable{
            {"merchant_id","SellerId"},
            {"amazon_provider_credit_reversal_id","AmazonProviderCreditReversalId"},
            {"mws_auth_token", "MWSAuthToken"}
        };

            ResponseParser responseObject = SetParametersAndPost(parameters, fieldMappings, requestParameters.getProviderCreditReversalDetailsHashtable);

            return (responseObject);
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
        ///  requestParameters.WithCurrencyCode("USD"); // Required if config["currency_code"] is null
        ///  requestParameters.WithCreditReversalNote("CUSTOM_NOTE");
        ///  requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        /// </code>
        /// </example>
        /// <returns>ResponseParser responseObject</returns>
        public ResponseParser ReverseProviderCredit(ReverseProviderCreditRequest requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "ReverseProviderCredit";

            Hashtable fieldMappings = new Hashtable{
            {"merchant_id","SellerId"},
            {"amazon_provider_credit_id","AmazonProviderCreditId"},
            {"credit_reversal_reference_id","CreditReversalReferenceId"},
            {"credit_reversal_amount","CreditReversalAmount.Amount"},
            {"currency_code","CreditReversalAmount.CurrencyCode"},
            {"credit_reversal_note","CreditReversalNote"},
            {"mws_auth_token","MWSAuthToken"}
        };

            ResponseParser responseObject = SetParametersAndPost(parameters, fieldMappings, requestParameters.reverseProviderCreditHashtable);

            return (responseObject);
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
        ///   requestParameters.WithCurrencyCode("USD");
        ///   requestParameters.WithPlatformId("SOLUTION_PROVIDER_MERCHANT_ID");
        ///   requestParameters.WithSoftDescriptor("amz");
        ///   requestParameters.WithStoreName("cool stuff store");
        ///   requestParameters.WithMWSAuthToken("MWS_AUTH_TOKEN");
        ///   requestParameters.WithChargeNote("sample note");
        ///   requestParameters.WithChargeOrderId("1234-1234");
        ///   requestParameters.WithCaptureNow(false);
        ///   requestParameters.WithProviderCreditDetails("PROVIDER_MERCHANT_ID", "10", "USD");
        ///   requestParameters.WithInheritShippingAddress(true);
        ///   requestParameters.WithTransactionTimeout(5);
        ///   requestParameters.WithCustomInformation("custom information");
        ///  </code>
        /// </example>
        /// <returns>ResponseParser response</returns>
        public ResponseParser Charge(ChargeRequest requestParameters)
        {
            ResponseParser response = null;
            ResponseParser statusResponse = null;
            string baStatus, oroStatus = "";
            switch (requestParameters.chargeType)
            {
                case "OrderReference":
                    statusResponse = GetOrderReferenceDetails(requestParameters.getOrderReferenceDetails);
                    // Call the function GetOrderReferenceStatus in ResponseParser.php providing it the XML response
                    // oroStatus - State of the order reference Id
                    oroStatus = statusResponse.GetOrderReferenceStatus(statusResponse.ToXml());
                    if (oroStatus.Equals("Draft"))
                    {
                        response = SetOrderReferenceDetails(requestParameters.setOrderReferenceDetails);

                        if (success)
                        {
                            response = ConfirmOrderReference(requestParameters.confirmOrderReference);
                        }
                    }

                    statusResponse = GetOrderReferenceDetails(requestParameters.getOrderReferenceDetails);
                    oroStatus = statusResponse.GetOrderReferenceStatus(statusResponse.ToXml());

                    if (success && oroStatus.Equals("Open"))
                    {
                        response = Authorize(requestParameters.authorizeOrderReference);
                    }
                    if (!(oroStatus.Equals("Open") || oroStatus.Equals("Draft")))
                    {
                        throw new ArgumentException("The order reference is in the " + oroStatus + " State. It should be in the Draft or Open State" + response.ToXml());
                    }
                    break;
                case "BillingAgreement":
                    // Get the billing agreement details and feed the response object to the ResponseParser
                    statusResponse = GetBillingAgreementDetails(requestParameters.getBillingAgreementDetails);
                    // Call the function GetBillingAgreementDetailsStatus in ResponseParser.php providing it the XML response
                    // baStatus - State of the billing agreement
                    baStatus = statusResponse.GetBillingAgreementStatus(statusResponse.ToXml());
                    if (!baStatus.Equals("Open"))
                    {
                        response = SetBillingAgreementDetails(requestParameters.setBillingAgreementDetails);
                        if (success)
                        {
                            response = ConfirmBillingAgreement(requestParameters.confirmBillingAgreement);
                        }
                    }
                    // Check the billing agreement status again before making the Authorization.
                    statusResponse = GetBillingAgreementDetails(requestParameters.getBillingAgreementDetails);
                    baStatus = statusResponse.GetBillingAgreementStatus(statusResponse.ToXml());

                    if (success && baStatus.Equals("Open"))
                    {
                        response = AuthorizeOnBillingAgreement(requestParameters.authorizeOnBillingAgreement);
                    }
                    if (!(baStatus.Equals("Open")) || !(baStatus.Equals("Draft")))
                    {
                        throw new ArgumentException("The billing agreement is in the " + baStatus + " State. It should be in the Draft or Open State");
                    }
                    break;
            }
            return response;
        }

        /// <summary>
        /// Create an Dictionary of required parameters, sort them
        /// Calculate signature and invoke the POST to the MWS Service URL
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>parametersToString</returns>
        private string CalculateSignatureAndParametersToString(IDictionary<String, String> parameters)
        {
            parameters.Add("AWSAccessKeyId", config["access_key"].ToString());
            if (string.IsNullOrEmpty(this.timeStamp))
            {
                parameters.Add("Timestamp", GetFormattedTimestamp());
            }
            else
            {
                parameters.Add("Timestamp", this.timeStamp);
            }
            parameters.Add("Version", SERVICE_VERSION);
            parameters.Add("SignatureVersion", "2");

            CreateServiceUrl(regionProperties);

            parameters.Add("Signature", SignParameters(parameters, config["secret_key"].ToString()));
            string parametersToString = GetParametersAsString(parameters);

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
            success = false;
            Hashtable responseHash = new Hashtable();

            int statusCode = 200;
            byte[] requestData = new UTF8Encoding().GetBytes(parameters);

            ConfigureUserAgentHeader();
            HttpImpl httpRequest = new HttpImpl(config);

            // Submit the request and read response body 
            bool shouldRetry;
            int retries = 0;
            do
            {
                shouldRetry = true;
                responseHash.Clear();
                responseHash = httpRequest.Post(mwsServiceUrl, userAgent, requestData);

                responseBody = responseHash["response"].ToString();
                statusCode = (int)responseHash["statusCode"];

                if (statusCode == 200)
                {
                    shouldRetry = false;
                    success = true;
                }
                else if (System.Convert.ToBoolean(config["handle_throttle"]) && (statusCode == 500 || statusCode == 503))
                {
                    ++retries;
                    if (shouldRetry && retries < MAX_ERROR_RETRY)
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

            return responseBody;
        }

        /// <summary>
        /// Exponential sleep on failed request
        /// </summary>
        /// <param name="retries"></param>
        /// <param name="status"></param>
        private void PauseOnRetry(int retries, int status)
        {
            if (retries <= MAX_ERROR_RETRY)
            {
                int delay = (int)Math.Pow(4, retries) * 100;
                System.Threading.Thread.Sleep(delay);
            }
            else
            {
                throw new WebException("Maximum number of retry attempts reached : " + (retries - 1) + status);
            }
        }

        /// <summary>
        /// Convert Dictionary of parameters to Url encoded query string
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns>string</returns>
        private string GetParametersAsString(IDictionary<String, String> parameters)
        {
            StringBuilder data = new StringBuilder();
            foreach (String key in (IEnumerable<String>)parameters.Keys)
            {
                String input = parameters[key];
                if (input != null)
                {
                    data.Append(key);
                    data.Append("=");
                    data.Append(UrlEncode(input, false));
                    data.Append("&");
                }
            }
            String result = data.ToString();
            return result.Remove(result.Length - 1);
        }

        /// <summary>
        /// Computes RFC 2104-compliant HMAC signature for request parameters
        /// Implements AWS Signature,as per following spec:
        ///
        /// If Signature Version is 0,it signs concatenated Action and Timestamp
        ///
        /// If Signature Version is 1,it performs the following:
        ///
        /// Sorts all  parameters (including SignatureVersion and excluding Signature,
        /// the value of which is being created),ignoring case.
        ///
        /// Iterate over the sorted list and append the parameter name (in original case)
        /// and then its value. It will not URL-encode the parameter values before
        /// constructing this string. There are no separators.
        ///
        /// If Signature Version is 2,string to sign is based on following:
        ///
        ///    1. The HTTP Request Method followed by an ASCII newline (%0A)
        ///    2. The HTTP Host header in the form of lowercase host,followed by an ASCII newline.
        ///    3. The URL encoded HTTP absolute path component of the URI
        ///       (up to but not including the query string parameters);
        ///       if this is empty use a forward "/". This parameter is followed by an ASCII newline.
        ///    4. The concatenation of all query string components (names and values)
        ///       as UTF-8 characters which are URL encoded as per RFC 3986
        ///       (hex characters MUST be uppercase),sorted using lexicographic byte ordering.
        ///       Parameter names are separated from their values by the "=" character
        ///       (ASCII character 61),even if the value is empty.
        ///       Pairs of parameter and values are separated by the "&" character (ASCII code 38).
        /// </summary>
        /// <param name="parameters"></param>
        /// <param name="key"></param>
        /// <returns>signature string</returns>
        private String SignParameters(IDictionary<String, String> parameters, String key)
        {
            String signatureVersion = parameters["SignatureVersion"];

            KeyedHashAlgorithm algorithm = new HMACSHA1();

            String stringToSign = null;

            if ("2".Equals(signatureVersion))
            {
                String signatureMethod = "HmacSHA256";
                algorithm = KeyedHashAlgorithm.Create(signatureMethod.ToUpper());
                parameters.Add("SignatureMethod", signatureMethod);
                stringToSign = CalculateStringToSignV2(parameters);
            }
            else
            {
                throw new InvalidDataException("Invalid Signature Version specified");
            }

            return Sign(stringToSign, key, algorithm);
        }

        /// <summary>
        /// compute the string signature as per the V2 specifications
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        private String CalculateStringToSignV2(IDictionary<String, String> parameters)
        {
            StringBuilder data = new StringBuilder();
            IDictionary<String, String> sorted =
                  new SortedDictionary<String, String>(parameters, StringComparer.Ordinal);
            data.Append("POST");
            data.Append("\n");
            data.Append(mwsEndpointUrl);
            data.Append("\n");
            data.Append(mwsEndpointPath);
            data.Append("\n");
            foreach (KeyValuePair<String, String> pair in sorted)
            {
                if (pair.Value != null)
                {
                    data.Append(UrlEncode(pair.Key, false));
                    data.Append("=");
                    data.Append(UrlEncode(pair.Value, false));
                    data.Append("&");
                }

            }

            String result = data.ToString();
            return result.Remove(result.Length - 1);
        }

        private String UrlEncode(String data, bool path)
        {
            StringBuilder encoded = new StringBuilder();
            String unreservedChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-_.~" + (path ? "/" : "");

            foreach (char symbol in System.Text.Encoding.UTF8.GetBytes(data))
            {
                if (unreservedChars.IndexOf(symbol) != -1)
                {
                    encoded.Append(symbol);
                }
                else
                {
                    encoded.Append("%" + String.Format("{0:X2}", (int)symbol));
                }
            }

            return encoded.ToString();

        }

        /// <summary>
        /// Computes RFC 2104-compliant HMAC signature.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="key"></param>
        /// <param name="algorithm"></param>
        /// <returns>string signature</returns>
        private String Sign(String data, String key, KeyedHashAlgorithm algorithm)
        {
            Encoding encoding = new UTF8Encoding();
            algorithm.Key = encoding.GetBytes(key);
            return Convert.ToBase64String(algorithm.ComputeHash(
                encoding.GetBytes(data.ToCharArray())));
        }

        /// <summary>
        /// Formats date as ISO 8601 timestamp
        /// </summary>
        /// <returns>DateTime object</returns>
        private String GetFormattedTimestamp()
        {
            DateTime dateTime = DateTime.Now;
            return new DateTime(dateTime.Year, dateTime.Month, dateTime.Day,
                                 dateTime.Hour, dateTime.Minute, dateTime.Second,
                                 dateTime.Millisecond
                                , DateTimeKind.Local
                               ).ToUniversalTime().ToString("yyyy-MM-dd\\THH:mm:ss.fff\\Z",
                                CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Create MWS service URL and the Endpoint path
        /// </summary>
        /// <param name="regionProperties"></param>
        private void CreateServiceUrl(Regions regionProperties)
        {
            string region = "";
            modePath = System.Convert.ToBoolean(config["sandbox"]) ? "OffAmazonPayments_Sandbox" : "OffAmazonPayments";

            if (!string.IsNullOrEmpty(config["region"].ToString()))
            {
                region = config["region"].ToString().ToLower();
                if (regionProperties.regionMappings.ContainsKey(region))
                {
                    // Set the Endpoint for the internal development else get the value from the 
                    if (mwsDevoEndpointUrl != null && mwsDevoEndpointUrl.Trim() != "")
                    {
                        mwsEndpointUrl = mwsDevoEndpointUrl;
                    }
                    else
                    {
                        mwsEndpointUrl = regionProperties.mwsServiceUrls[regionProperties.regionMappings[region]].ToString();
                    }
                    mwsServiceUrl = "https://" + mwsEndpointUrl + "/" + modePath + "/" + SERVICE_VERSION;
                    mwsEndpointPath = "/" + modePath + "/" + SERVICE_VERSION;
                }
                else
                {
                    throw new InvalidDataException(region + " is not a valid region");
                }
            }
            else
            {
                throw new NullReferenceException("config['region'] is a required parameter and is not set");
            }
        }

        /// <summary>
        /// Create Profile Endpoint URL
        /// </summary>
        /// <param name="regionProperties"></param>
        private void ProfileEndpointUrl(Regions regionProperties)
        {
            string region = "";
            string profileEnvt = System.Convert.ToBoolean(config["sandbox"]) ? "api.sandbox" : "api";

            if (!string.IsNullOrEmpty(config["region"].ToString()))
            {
                region = config["region"].ToString().ToLower();
                if (regionProperties.regionMappings.ContainsKey(region))
                {
                    profileEndpoint = "https://" + profileEnvt + "." + regionProperties.ProfileEndpoint[region].ToString();
                }
                else
                {
                    throw new InvalidDataException(region + " is not a valid region");
                }
            }
            else
            {
                throw new NullReferenceException("config['region'] is a required parameter and is not set");
            }
        }
        private void ConfigureUserAgentHeader()
        {
            SetUserAgentHeader(
                "CLI", Environment.Version.ToString(),
                "Platform", Environment.OSVersion.Platform + "/" + Environment.OSVersion.Version,
                "MWSClientVersion", MWS_CLIENT_VERSION,
                "ApplicationLibraryVersion", MWS_CLIENT_VERSION);
        }

        private void SetUserAgentHeader(params string[] additionalNameValuePairs)
        {
            if (additionalNameValuePairs.Length % 2 != 0)
            {
                throw new ArgumentException("additionalNameValuePairs", "Every name must have a corresponding value.");
            }

            StringBuilder sb = new StringBuilder();
            if (config["application_name"] != null)
            {
                sb.Append(QuoteApplicationName(config["application_name"].ToString()));
            }
            sb.Append("/");
            if (config["application_version"] != null)
            {
                sb.Append(QuoteApplicationVersion(config["application_version"].ToString()));
            }
            sb.Append(" (");
            sb.Append("Language=");
            sb.Append(QuoteAttributeValue("C#"));

            int i = 0;
            while (i < additionalNameValuePairs.Length)
            {
                string name = additionalNameValuePairs[i];
                string input = additionalNameValuePairs[++i];
                sb.Append("; ");
                sb.Append(QuoteAttributeName(name));
                sb.Append("=");
                sb.Append(QuoteAttributeValue(input));

                i++;
            }

            sb.Append(")");

            userAgent = sb.ToString();
        }

        /// <summary>
        /// Replace all whitespace characters by a single space
        /// </summary>
        /// <param name="s"></param>
        /// <returns>string s</returns>
        private static string Clean(string s)
        {
            // matched character sequences are passed to a MatchEvaluator
            // delegate. The returned string from the delegate replaces
            // the matched sequence.
            return Regex.Replace(s, @" {2,}|\s", delegate(Match m)
            {
                return " ";
            });
        }

        /// <summary>
        /// Collapse whitespace,and escape the following characters are escaped
        /// </summary>
        /// <param name="s"></param>
        /// <returns>string s</returns>
        private static string QuoteApplicationName(string s)
        {
            return Clean(s).Replace(@"\", @"\\").Replace("@/", @"\/");
        }

        /// <summary>
        /// Collapse whitespace,and escape the following characters are escaped
        /// </summary>
        /// <param name="s"></param>
        /// <returns>string s</returns>
        private static string QuoteApplicationVersion(string s)
        {
            return Clean(s).Replace(@"\", @"\\").Replace(@"(", @"\(");
        }

        /// <summary>
        /// Collapse whitespace,and escape the following characters are escaped
        /// </summary>
        /// <param name="s"></param>
        /// <returns>string s</returns>
        private static string QuoteAttributeName(string s)
        {
            return Clean(s).Replace(@"\", @"\\").Replace(@"=", @"\=");
        }

        /// <summary>
        /// Collapse whitespace,and escape the following characters are escaped 
        /// </summary>
        /// <param name="s"></param>
        /// <returns>string s</returns>
        private static string QuoteAttributeValue(string s)
        {
            return Clean(s).Replace(@"\", @"\\").Replace(@";", @"\;").Replace(@")", @"\)");
        }
    }
}