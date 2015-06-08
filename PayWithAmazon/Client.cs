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

namespace PayWithAmazon
{
    public class Client
    {
        private const string MWS_CLIENT_VERSION = "1.0.0";
        private const string SERVICE_VERSION = "2013-01-01";
        private const int MAX_ERROR_RETRY = 3;

        // Construct User agent string based off of the application_name, application_version, PHP platform
        private string userAgent = null;
        private string parameters = null;
        private string mwsEndpointPath = null;
        private string mwsEndpointUrl = null;
        private string profileEndpoint = null;
        public Hashtable config = new Hashtable() {
			{"merchant_id", null}, 
            {"secret_key", null}, 
            {"access_key", null}, 
            {"region", null}, 
            {"currency_code", null}, 
            {"sandbox", false}, 
            {"platform_id", null}, 
            {"cabundle_file", null}, {
				"application_name", null
			}, {
				"application_version", null
			}, {
				"proxy_host", null
			}, {
				"proxy_port", "-1"
			}, {
				"proxy_username", null
			}, {
				"proxy_password", null
			}, {
				"client_id", null
			}, {
				"handle_throttle", "true"
			}
		};

        private string modePath = null;

        // Final URL to where the API parameters POST done, based off the config["region"] and respective $mwsServiceUrls
        private string mwsServiceUrl = null;

        // Boolean variable to check if the API call was a success
        public bool success = false;

        /* Takes user configuration Dictionary from the user as input
         * Validates the user configuration array against existing config array
         */
        public Client(Hashtable config)
        {

            if (config == null)
            {
                Console.WriteLine("config is empty");
            }
            checkConfigKeys(config);
        }

        public Client(string jsonFilePath)
        {
            string json;
            Hashtable config = new Hashtable();
            Dictionary<string, string> dict = new Dictionary<string, string>();
            try
            {
                if (!string.IsNullOrEmpty(jsonFilePath))
                {
                    try
                    {
                        if (File.Exists(jsonFilePath))
                        {
                            using (StreamReader r = new StreamReader(@jsonFilePath))
                            {
                                json = r.ReadToEnd();
                            }
                            dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

                            config = DictionaryToHashtable(dict);

                            foreach (DictionaryEntry kvp in config)
                            {
                                Console.WriteLine(kvp.Key + ":" + kvp.Value);
                            }
                        }
                    }
                    catch (FileNotFoundException e)
                    {
                        // Console.WriteLine(e.Message);
                        throw new Exception(e.Message);
                    }
                }
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.Message);
                throw new Exception(e.Message);
            }
            checkConfigKeys(config);
        }
        /* checkIfFileExists -  check if the JSON file exists in the path provided */

        /* Checks if the keys of the input configuration matches the keys in the config array
         * if they match the values are taken else throws exception
         * strict case match is not performed
         */

        private void checkConfigKeys(Hashtable config)
        {
            config = lowerKeys(config);

            foreach (DictionaryEntry pair in config)
            {
                if (this.config.ContainsKey(pair.Key))
                {
                    this.config[pair.Key] = pair.Value.ToString().Trim();
                }
                else
                {
                    throw new Exception("Key " + pair.Key + " is either not part of the configuration or has incorrect Key name." +
                        "check the config array key names to match your key names of your config array");
                }
            }
        }

        private Hashtable lowerKeys(Hashtable table)
        {
            Hashtable lowerKeyTable = new Hashtable();
            string value = "";
            foreach (DictionaryEntry newpair in table)
            {
                value = "";
                string key = newpair.Key.ToString().ToLower();
                if (newpair.Value != null)
                {
                    value = newpair.Value.ToString();
                }
                else
                {
                    value = "";
                }

                lowerKeyTable.Add(key, value);
            }
            return lowerKeyTable;
        }

        /* setParametersAndPost - sets the parameters array with non empty values from the requestParameters array sent to API calls.
         * If Provider Credit Details is present, values are set by setProviderCreditDetails
         * If Provider Credit Reversal Details is present, values are set by setProviderCreditDetails
         */

        private ResponseParser setParametersAndPost(Hashtable parameters, Hashtable fieldMappings, Hashtable requestParameters)
        {
            string value = "";
            List<Hashtable> providerCredit = new List<Hashtable>();
            bool isDict = false;
            /* For loop to take all the non empty parameters in the $requestParameters and add it into the $parameters array,
             * if the keys are matched from $requestParameters array with the $fieldMappings array
             */
            foreach (DictionaryEntry pair in requestParameters)
            {
                // Console.WriteLine(pair.Value.GetType().GetGenericTypeDefinition());
                // Console.ReadLine();
                if (!(pair.Value.GetType() == typeof(List<Hashtable>)))
                {
                    value = pair.Value.ToString().Trim();
                    isDict = false;
                }
                else
                {
                    isDict = true;
                    providerCredit = pair.Value as List<Hashtable>;
                }

                if (fieldMappings.ContainsKey(pair.Key) == true && value != "")
                {
                    // config.Add(pair.Key, pair.Value.ToString().Trim());
                    if (isDict)
                    {
                        // If the parameter is a provider_credit_details or provider_credit_reversal_details, call the respective functions to set the values
                        if (pair.Key.Equals("provider_credit_details"))
                        {
                            parameters = setProviderCreditDetails(parameters, providerCredit);
                        }
                        else if (pair.Key.Equals("provider_credit_reversal_details"))
                        {
                            // parameters = setProviderCreditReversalDetails(parameters, providerCredit);
                        }

                    }
                    else
                    {
                        // For variables that are boolean values, strtolower them
                        if (checkIfBool(value))
                            value = value.ToLower();

                        parameters[fieldMappings[pair.Key]] = value;
                    }
                }

            }

            parameters = setDefaultValues(parameters, fieldMappings, requestParameters);
            foreach (DictionaryEntry keypair in parameters)
            {
                Console.WriteLine(keypair.Value);
            }
            ResponseParser responseObject = calculateSignatureAndPost(parameters);
            return responseObject;
        }

        public static Dictionary<K, V> HashtableToDictionary<K, V>(Hashtable table)
        {
            Dictionary<K, V> dict = new Dictionary<K, V>();
            foreach (DictionaryEntry kvp in table)
                dict.Add((K)kvp.Key, (V)kvp.Value);
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

        /* checkIfBool - checks if the input is a boolean */

        private bool checkIfBool(string value)
        {
            value = value.ToLower();
            bool isBool = false;
            if (value.Equals("true") || value.Equals("false"))// return boolean right from here
            {
                isBool = true;
            }
            return isBool;
        }

        /* calculateSignatureAndPost - convert the Parameters array to string and curl POST the parameters to MWS */

        private ResponseParser calculateSignatureAndPost(Hashtable parameters)
        {
            // Call the signature and Post function to perform the actions. Returns XML in array format
            string parametersString = calculateSignatureAndParametersToString(HashtableToDictionary<string, string>(parameters));

            // POST using curl the String converted Parameters
            string response = Invoke(parametersString);

            // Send this response as args to ResponseParser class which will return the object of the class.
            ResponseParser responseObject = new ResponseParser(response);
            return responseObject;
        }

        /* If merchant_id is not set via the requestParameters array then it"s taken from the config array
         *
         * Set the platform_id if set in the config["platform_id"] array
         *
         * If currency_code is set in the $requestParameters and it exists in the $fieldMappings array, strtoupper it
         * else take the value from config array if set
         */

        private Hashtable setDefaultValues(Hashtable parameters, Hashtable fieldMappings, Hashtable requestParameters)
        {

            if (fieldMappings.ContainsKey("merchant_id"))
            {
                try
                {
                    if (string.IsNullOrEmpty(requestParameters["merchant_id"].ToString()))
                    {
                        parameters["SellerId"] = config["merchant_id"];
                    }
                }
                catch (NullReferenceException)
                {
                    parameters["SellerId"] = config["merchant_id"];
                }
            }


            if (fieldMappings.ContainsKey("platform_id"))
            {
                try
                {
                    if (string.IsNullOrEmpty(requestParameters["platform_id"].ToString()))
                    {
                        parameters[fieldMappings["platform_id"]] = config["platform_id"];
                    }
                }
                catch (NullReferenceException)
                {
                    parameters[fieldMappings["platform_id"]] = config["platform_id"];
                }
            }

            if (fieldMappings.ContainsKey("currency_code"))
            {
                if (!string.IsNullOrEmpty(requestParameters["currency_code"].ToString()))
                {
                    parameters[fieldMappings["currency_code"]] = requestParameters["currency_code"].ToString().ToUpper();
                }
                else
                {
                    parameters[fieldMappings["currency_code"]] = config["currency_code"].ToString().ToUpper();
                }
            }

            return parameters;
        }

        /* setProviderCreditDetails - sets the provider credit details sent via the Capture or Authorize API calls
         * @param provider_id - [String]
         * @param credit_amount - [String]
         * @optional currency_code - [String]
         */

        private Hashtable setProviderCreditDetails(Hashtable parameters, List<Hashtable> providerCreditInfo)
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

                Hashtable innerDictionary = lowerKeys(pair);
                providerIndex = providerIndex + 1;

                foreach (DictionaryEntry keypair in innerDictionary)
                {
                    if (fieldMappings.ContainsKey(keypair.Key) && (keypair.Value.ToString().Trim()) != "")
                    {
                        parameters[providerString + providerIndex + "." + fieldMappings[keypair.Key]] = keypair.Value;
                    }
                }

                // If currency code is not entered take it from the config array
                if (string.IsNullOrEmpty(parameters[providerString + providerIndex + "." + fieldMappings["currency_code"].ToString()].ToString()))
                {
                    parameters[providerString + providerIndex + "." + fieldMappings["currency_code"]] = config["currency_code"].ToString().ToUpper();
                }
            }

            return parameters;
        }

        /* setProviderCreditReversalDetails - sets the reverse provider credit details sent via the Refund API call.
         * @param provider_id - [String]
         * @param credit_amount - [String]
         * @optional currency_code - [String]
         */

        private Hashtable setProviderCreditReversalDetails(Hashtable parameters, List<Hashtable> providerCreditInfo)
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
                Hashtable innerDictionary = lowerKeys(pair);

                foreach (DictionaryEntry keypair in innerDictionary)
                {
                    if (fieldMappings.ContainsKey(keypair.Key) && (keypair.Value.ToString().Trim()) != "")
                    {
                        parameters[providerString + providerIndex + "." + fieldMappings[keypair.Key]] = keypair.Value;
                    }
                }

                // If currency code is not entered take it from the config array
                if (string.IsNullOrEmpty(parameters[providerString + providerIndex + "." + fieldMappings["currency_code"].ToString()].ToString()))
                {
                    parameters[providerString + providerIndex + "." + fieldMappings["currency_code"]] = config["currency_code"].ToString().ToUpper();
                }
            }

            return parameters;
        }

        /* GetOrderReferenceDetails API call - Returns details about the Order Reference object and its current state.
         * @see https://payments.amazon.com/documentation/apireference/201751970
         *
         * @param requestParameters["merchant_id"] - [String]
         * @param requestParameters["amazon_order_reference_id"] - [String]
         * @optional requestParameters["address_consent_token"] - [String]
         * @optional requestParameters["mws_auth_token"] - [String]
         */

        public ResponseParser getOrderReferenceDetails(Hashtable requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "GetOrderReferenceDetails";
            requestParameters = lowerKeys(requestParameters);

            Hashtable fieldMappings = new Hashtable()  {
            {"merchant_id", "SellerId"},
            {"amazon_order_reference_id", "AmazonOrderReferenceId"},
            {"address_consent_token", "AddressConsentToken"},
            {"mws_auth_token", "MWSAuthToken"}
        };

            ResponseParser responseObject = setParametersAndPost(parameters, fieldMappings, requestParameters);
            return (responseObject);
        }

        /* SetOrderReferenceDetails API call - Sets order reference details such as the order total and a description for the order.
         * @see https://payments.amazon.com/documentation/apireference/201751960
         *
         * @param requestParameters['merchant_id'] - [String]
         * @param requestParameters['amazon_order_reference_id'] - [String]
         * @param requestParameters['amount'] - [String]
         * @param requestParameters['currency_code'] - [String]
         * @optional requestParameters['platform_id'] - [String]
         * @optional requestParameters['seller_note'] - [String]
         * @optional requestParameters['seller_order_id'] - [String]
         * @optional requestParameters['store_name'] - [String]
         * @optional requestParameters['custom_information'] - [String]
         * @optional requestParameters['mws_auth_token'] - [String]
         */

        public ResponseParser setOrderReferenceDetails(Hashtable requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "SetOrderReferenceDetails";
            requestParameters = lowerKeys(requestParameters);

            Hashtable fieldMappings = new Hashtable()  {
            {"merchant_id", "SellerId"},
            {"amazon_order_reference_id", "AmazonOrderReferenceId"},
            {"amount" , "OrderReferenceAttributes.OrderTotal.Amount"},
            {"currency_code", "OrderReferenceAttributes.OrderTotal.CurrencyCode"},
            {"platform_id", "OrderReferenceAttributes.PlatformId"},
            {"seller_note", "OrderReferenceAttributes.SellerNote"},
            {"seller_order_id", "OrderReferenceAttributes.SellerOrderAttributes.SellerOrderId"},
            {"store_name", "OrderReferenceAttributes.SellerOrderAttributes.StoreName"},
            {"custom_information", "OrderReferenceAttributes.SellerOrderAttributes.CustomInformation"},
            {"mws_auth_token", "MWSAuthToken"}
        };

            ResponseParser responseObject = setParametersAndPost(parameters, fieldMappings, requestParameters);
            return (responseObject);
        }

        /* ConfirmOrderReferenceDetails API call - Confirms that the order reference is free of constraints and all required information has been set on the order reference.
         * @see https://payments.amazon.com/documentation/apireference/201751980
         * @param requestParameters['merchant_id'] - [String]
         * @param requestParameters['amazon_order_reference_id'] - [String]
         * @optional requestParameters['mws_auth_token'] - [String]
         */

        public ResponseParser ConfirmOrderReference(Hashtable requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "ConfirmOrderReference";
            requestParameters = lowerKeys(requestParameters);

            Hashtable fieldMappings = new Hashtable()  {
            {"merchant_id", "SellerId"},
            {"amazon_order_reference_id", "AmazonOrderReferenceId"},
            {"mws_auth_token", "MWSAuthToken"}
            };

            ResponseParser responseObject = setParametersAndPost(parameters, fieldMappings, requestParameters);
            return (responseObject);
        }

        /* CancelOrderReferenceDetails API call - Cancels a previously confirmed order reference.
         * @see https://payments.amazon.com/documentation/apireference/201751990
         *
         * @param requestParameters['merchant_id'] - [String]
         * @param requestParameters['amazon_order_reference_id'] - [String]
         * @optional requestParameters['cancelation_reason'] [String]
         * @optional requestParameters['mws_auth_token'] - [String]
         */

        public ResponseParser CancelOrderReference(Hashtable requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "CancelOrderReference";
            requestParameters = lowerKeys(requestParameters);

            Hashtable fieldMappings = new Hashtable()  {
            {"merchant_id", "SellerId"},
            {"amazon_order_reference_id", "AmazonOrderReferenceId"},
            {"cancelation_reason", "CancelationReason"},
            {"mws_auth_token", "MWSAuthToken"}
            };

            ResponseParser responseObject = setParametersAndPost(parameters, fieldMappings, requestParameters);
            return (responseObject);
        }

        /* CloseOrderReferenceDetails API call - Confirms that an order reference has been fulfilled (fully or partially)
         * and that you do not expect to create any new authorizations on this order reference.
         * @see https://payments.amazon.com/documentation/apireference/201752000
         *
         * @param requestParameters['merchant_id'] - [String]
         * @param requestParameters['amazon_order_reference_id'] - [String]
         * @optional requestParameters['closure_reason'] [String]
         * @optional requestParameters['mws_auth_token'] - [String]
         */

        public ResponseParser CloseOrderReference(Hashtable requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "CloseOrderReference";
            requestParameters = lowerKeys(requestParameters);

            Hashtable fieldMappings = new Hashtable()  {
            {"merchant_id", "SellerId"},
            {"amazon_order_reference_id", "AmazonOrderReferenceId"},
            {"closure_reason", "ClosureReason"},
            {"mws_auth_token", "MWSAuthToken"}
            };

            ResponseParser responseObject = setParametersAndPost(parameters, fieldMappings, requestParameters);
            return (responseObject);
        }

        /* Authorize API call - Reserves a specified amount against the payment method(s) stored in the order reference.
         * @see https://payments.amazon.com/documentation/apireference/201752010
         *
         * @param requestParameters['merchant_id'] - [String]
         * @param requestParameters['amazon_order_reference_id'] - [String]
         * @param requestParameters['authorization_amount'] [String]
         * @param requestParameters['currency_code'] - [String]
         * @param requestParameters['authorization_reference_id'] [String]
         * @optional requestParameters['capture_now'] [String]
         * @optional requestParameters['provider_credit_details'] - [array (array())]
         * @optional requestParameters['seller_authorization_note'] [String]
         * @optional requestParameters['transaction_timeout'] [String] - Defaults to 1440 minutes
         * @optional requestParameters['soft_descriptor'] - [String]
         * @optional requestParameters['mws_auth_token'] - [String]
         */

        public ResponseParser Authorize(Hashtable requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "Authorize";
            requestParameters = lowerKeys(requestParameters);

            Hashtable fieldMappings = new Hashtable()  {
            {"merchant_id", "SellerId"},
            {"amazon_order_reference_id", "AmazonOrderReferenceId"},
            {"authorization_amount" , "AuthorizationAmount.Amount"},
            {"currency_code", "AuthorizationAmount.CurrencyCode"},
            {"authorization_reference_id" , "AuthorizationReferenceId"},
            {"capture_now" , "CaptureNow"},
	        {"provider_credit_details", typeof(List<Hashtable>)},
            {"seller_authorization_note", "SellerAuthorizationNote"},
            {"transaction_timeout", "TransactionTimeout"},
            {"soft_descriptor", "SoftDescriptor"},
            {"mws_auth_token", "MWSAuthToken"},
            };

            ResponseParser responseObject = setParametersAndPost(parameters, fieldMappings, requestParameters);
            return (responseObject);
        }

        /* GetAuthorizationDetails API call - Returns the status of a particular authorization and the total amount captured on the authorization.
         * @see https://payments.amazon.com/documentation/apireference/201752030
         *
         * @param requestParameters['merchant_id'] - [String]
         * @param requestParameters['amazon_authorization_id'] [String]
         * @optional requestParameters['mws_auth_token'] - [String]
         */

        public ResponseParser GetAuthorizationDetails(Hashtable requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "GetAuthorizationDetails";
            requestParameters = new Hashtable(requestParameters, StringComparer.InvariantCultureIgnoreCase);

            Hashtable fieldMappings = new Hashtable()  
            {
                {"merchant_id", "SellerId"},
                {"amazon_authorization_reference_id", "AmazonAuthorizeReferenceId"},
                {"mws_auth_token", "MWSAuthToken"},
            };

            ResponseParser responseObject = setParametersAndPost(parameters, fieldMappings, requestParameters);
            return (responseObject);
        }

        /* Capture API call - Captures funds from an authorized payment instrument.
         * @see https://payments.amazon.com/documentation/apireference/201752040
         *
         * @param requestParameters['merchant_id'] - [String]
         * @param requestParameters['amazon_authorization_id'] - [String]
         * @param requestParameters['capture_amount'] - [String]
         * @param requestParameters['currency_code'] - [String]
         * @param requestParameters['capture_reference_id'] - [String]
         * @optional requestParameters['provider_credit_details'] - [array (array())]
         * @optional requestParameters['seller_capture_note'] - [String]
         * @optional requestParameters['soft_descriptor'] - [String]
         * @optional requestParameters['mws_auth_token'] - [String]
         */

        public ResponseParser Capture(Hashtable requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "Capture";
            requestParameters = lowerKeys(requestParameters);

            Hashtable fieldMappings = new Hashtable()  
            {
                { "merchant_id" , "SellerId"},
                { "amazon_authorization_id" 	, "AmazonAuthorizationId"},
                { "capture_amount" 		, "CaptureAmount.Amount"},
                { "currency_code" 		, "CaptureAmount.CurrencyCode"},
                { "capture_reference_id" 	, "CaptureReferenceId"},
	            { "provider_credit_details"	, typeof(List<Hashtable>)},
                {"seller_capture_note" 	, "SellerCaptureNote"},
                { "soft_descriptor" 		, "SoftDescriptor"},
                { "mws_auth_token" 		, "MWSAuthToken"}
            };

            ResponseParser responseObject = setParametersAndPost(parameters, fieldMappings, requestParameters);
            return (responseObject);
        }

        /* GetCaptureDetails API call - Returns the status of a particular capture and the total amount refunded on the capture.
         * @see https://payments.amazon.com/documentation/apireference/201752060
         *
         * @param requestParameters['merchant_id'] - [String]
         * @param requestParameters['amazon_capture_id'] - [String]
         * @optional requestParameters['mws_auth_token'] - [String]
         */
        public ResponseParser GetCaptureDetails(Hashtable requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "GetCaptureDetails";
            requestParameters = new Hashtable(requestParameters, StringComparer.InvariantCultureIgnoreCase);

            Hashtable fieldMappings = new Hashtable()  
            {
                {"merchant_id", "SellerId"},
                {"amazon_capture_id", "AmazonCaptureId"},
                {"mws_auth_token", "MWSAuthToken"},
            };

            ResponseParser responseObject = setParametersAndPost(parameters, fieldMappings, requestParameters);
            return (responseObject);
        }

        /* Refund API call - Refunds a previously captured amount.
         * @see https://payments.amazon.com/documentation/apireference/201752080
         *
         * @param requestParameters['merchant_id'] - [String]
         * @param requestParameters['amazon_capture_id'] - [String]
         * @param requestParameters['refund_reference_id'] - [String]
         * @param requestParameters['refund_amount'] - [String]
         * @param requestParameters['currency_code'] - [String]
         * @optional requestParameters['provider_credit_reversal_details'] - [array(array())]
         * @optional requestParameters['seller_refund_note'] [String]
         * @optional requestParameters['soft_descriptor'] - [String]
         * @optional requestParameters['mws_auth_token'] - [String]
         */
        public ResponseParser Refund(Hashtable requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "Refund";
            requestParameters = lowerKeys(requestParameters);

            Hashtable fieldMappings = new Hashtable()  
            {
                { "merchant_id" , "SellerId"},
                { "amazon_capture_id" 	, "AmazonCaptureId"},
                { "refund_reference_id" 		, "RefundReferenceId"},
                { "refund_amount" 		, "RefundAmount.Amount"},
                { "currency_code" 	, "RefundAmount.CurrencyCode"},
	            { "provider_credit_reversal_details"	, typeof(List<Hashtable>)},
                {"seller_refund_note" 	, "SellerRefundNote"},
                { "soft_descriptor" 		, "SoftDescriptor"},
                { "mws_auth_token" 		, "MWSAuthToken"}
            };

            ResponseParser responseObject = setParametersAndPost(parameters, fieldMappings, requestParameters);
            return (responseObject);
        }

        /* GetRefundDetails API call - Returns the status of a particular refund.
         * @see https://payments.amazon.com/documentation/apireference/201752100
         *
         * @param requestParameters['merchant_id'] - [String]
         * @param requestParameters['amazon_refund_id'] - [String]
         * @optional requestParameters['mws_auth_token'] - [String]
         */
        public ResponseParser GetRefundDetails(Hashtable requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "GetRefundDetails";
            requestParameters = lowerKeys(requestParameters);

            Hashtable fieldMappings = new Hashtable()  
            {
                { "merchant_id" , "SellerId"},
                { "amazon_refund_id" 	, "AmazonRefundId"},
                { "mws_auth_token" 		, "MWSAuthToken"}
            };

            ResponseParser responseObject = setParametersAndPost(parameters, fieldMappings, requestParameters);
            return (responseObject);
        }

        /* CreateOrderReferenceForId API Call - Creates an order reference for the given object
     * @see http://docs.developer.amazonservices.com/en_US/off_amazon_payments/OffAmazonPayments_CreateOrderReferenceForId.html
     *
     * @param requestParameters['merchant_id'] - [String]
     * @param requestParameters['Id'] - [String]
     * @optional requestParameters['inherit_shipping_address'] [Boolean]
     * @optional requestParameters['ConfirmNow'] - [Boolean]
     * @optional Amount (required when confirm_now is set to true) [String]
     * @optional requestParameters['currency_code'] - [String]
     * @optional requestParameters['seller_note'] - [String]
     * @optional requestParameters['seller_order_id'] - [String]
     * @optional requestParameters['store_name'] - [String]
     * @optional requestParameters['custom_information'] - [String]
     * @optional requestParameters['mws_auth_token'] - [String]
     */
        public ResponseParser createOrderReferenceForId(Hashtable requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "CreateOrderReferenceForId";
            requestParameters = lowerKeys(requestParameters);

            Hashtable fieldMappings = new Hashtable()  
            {
                { "merchant_id" , "SellerId"},
                { "id" 	, "Id"},
                { "id_type", "IdType"},
                { "inherit_shipping_address" , "InheritShippingAddress"},
                { "confirm_now", "ConfirmNow"},
                {"amount","OrderReferenceAttributes.OrderTotal.Amount"},
                {"currency_code" , "OrderReferenceAttributes.OrderTotal.CurrencyCode"},
                {"platform_id", "OrderReferenceAttributes.PlatformId"},
                {"seller_note", "OrderReferenceAttributes.SellerNote"},
                {"seller_order_id", "OrderReferenceAttributes.SellerOrderAttributes.SellerOrderId"},
                {"store_name" , "OrderReferenceAttributes.SellerOrderAttributes.StoreName"},
                {"custom_information", "OrderReferenceAttributes.SellerOrderAttributes.CustomInformation"},
                {"mws_auth_token", "MWSAuthToken"}
            };

            ResponseParser responseObject = setParametersAndPost(parameters, fieldMappings, requestParameters);
            return (responseObject);
        }

        /* GetBillingAgreementDetails API Call - Returns details about the Billing Agreement object and its current state.
     * @see http://docs.developer.amazonservices.com/en_US/off_amazon_payments/OffAmazonPayments_GetBillingAgreementDetails.html
     *
     * @param requestParameters['merchant_id'] - [String]
     * @param requestParameters['amazon_billing_agreement_id'] - [String]
     * @optional requestParameters['mws_auth_token'] - [String]
     */
        public ResponseParser GetBillingAgreementDetails(Hashtable requestParameters)
        {
            Hashtable parameters = new Hashtable();
            parameters["Action"] = "GetBillingAgreementDetails";
            requestParameters = lowerKeys(requestParameters);

            Hashtable fieldMappings = new Hashtable()  
            {
                 {"merchant_id" 		  , "SellerId"},
                 {"amazon_billing_agreement_id" , "AmazonBillingAgreementId"},
                 {"address_consent_token" 	  , "AddressConsentToken"},
                 {"mws_auth_token", "MWSAuthToken"}
            };

            ResponseParser responseObject = setParametersAndPost(parameters, fieldMappings, requestParameters);
            return (responseObject);
        }
        /**
         * Add authentication related and version parameters
         */
        private string calculateSignatureAndParametersToString(IDictionary<String, String> parameters)
        {
            parameters.Add("AWSAccessKeyId", config["access_key"].ToString());
            parameters.Add("Timestamp", GetFormattedTimestamp());
            parameters.Add("Version", SERVICE_VERSION);
            parameters.Add("SignatureVersion", "2");

            RegionSpecificProperties regionProperties = new RegionSpecificProperties();
            createServiceUrl(regionProperties);

            parameters.Add("Signature", SignParameters(parameters, config["secret_key"].ToString()));
            string parametersToString = GetParametersAsString(parameters);

            this.parameters = parametersToString;

            return parametersToString;
        }
        /**
         * Invoke request and return response
         */
        private string Invoke(string parameters)
        {
            String responseBody = null;
            Hashtable responseHash = new Hashtable();

            int statusCode = 200;
            byte[] requestData = new UTF8Encoding().GetBytes(parameters);

            ConfigureUserAgentHeader();
            HttpImpl httpRequest = new HttpImpl(mwsServiceUrl, userAgent);

            /* Submit the request and read response body */
            bool shouldRetry = true;
            int retries = 0;
            do
            {
                responseHash.Clear();
                responseHash = httpRequest.Post(requestData);

                responseBody = responseHash["response"].ToString();
                statusCode = (int)responseHash["statusCode"];

                if (statusCode == 200)
                {
                    shouldRetry = false;
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

        int indentLevel = 0;
        private bool DisplayDictionary(IDictionary dict)
        {
            bool bSuccess = false;
            indentLevel++;

            foreach (string strKey in dict.Keys)
            {
                string strOutput = strKey;
                System.Console.WriteLine("\r\n" + strKey);

                object o = dict[strKey];
                try
                {
                    if (strOutput.Equals("AmazonOrderReferenceId"))
                    {
                        Console.WriteLine("AmazonOro:" + o.ToString());
                        break;
                    }
                }
                catch (Exception e)
                {

                }
                if (o is IDictionary)
                {
                    DisplayDictionary((IDictionary)o);
                }
                /* else if (o is ArrayList)
                 {
                     foreach (object oChild in ((ArrayList)o))
                     {
                         if (oChild is string)
                         {
                             strOutput = ((string)oChild);
                             System.Console.WriteLine(strOutput + ",");
                         }
                         else if (oChild is IDictionary)
                         {
                             DisplayDictionary((IDictionary)oChild);
                             System.Console.WriteLine("\r\n");
                         }
                     }
                 }*/
                else
                {
                    try
                    {
                        strOutput = o.ToString();
                        System.Console.WriteLine(strOutput);
                    }
                    catch (Exception e)
                    {


                    }
                }
            }

            indentLevel--;

            return bSuccess;
        }

        /**
        * Exponential sleep on failed request
        */
        private void PauseOnRetry(int retries, int status)
        {
            if (retries <= MAX_ERROR_RETRY)
            {
                int delay = (int)Math.Pow(4, retries) * 100;
                System.Threading.Thread.Sleep(delay);
            }
            else
            {
                throw new Exception("Maximum number of retry attempts reached : " + (retries - 1) + status);
            }
        }



        /**
         * Convert Dictionary of paremeters to Url encoded query string
         */
        private string GetParametersAsString(IDictionary<String, String> parameters)
        {
            StringBuilder data = new StringBuilder();
            foreach (String key in (IEnumerable<String>)parameters.Keys)
            {
                String value = parameters[key];
                if (value != null)
                {
                    data.Append(key);
                    data.Append('=');
                    data.Append(UrlEncode(value, false));
                    data.Append('&');
                }
            }
            String result = data.ToString();
            return result.Remove(result.Length - 1);
        }

        /**
         * Computes RFC 2104-compliant HMAC signature for request parameters
         * Implements AWS Signature, as per following spec:
         *
         * If Signature Version is 0, it signs concatenated Action and Timestamp
         *
         * If Signature Version is 1, it performs the following:
         *
         * Sorts all  parameters (including SignatureVersion and excluding Signature,
         * the value of which is being created), ignoring case.
         *
         * Iterate over the sorted list and append the parameter name (in original case)
         * and then its value. It will not URL-encode the parameter values before
         * constructing this string. There are no separators.
         *
         * If Signature Version is 2, string to sign is based on following:
         *
         *    1. The HTTP Request Method followed by an ASCII newline (%0A)
         *    2. The HTTP Host header in the form of lowercase host, followed by an ASCII newline.
         *    3. The URL encoded HTTP absolute path component of the URI
         *       (up to but not including the query string parameters);
         *       if this is empty use a forward '/'. This parameter is followed by an ASCII newline.
         *    4. The concatenation of all query string components (names and values)
         *       as UTF-8 characters which are URL encoded as per RFC 3986
         *       (hex characters MUST be uppercase), sorted using lexicographic byte ordering.
         *       Parameter names are separated from their values by the '=' character
         *       (ASCII character 61), even if the value is empty.
         *       Pairs of parameter and values are separated by the '&' character (ASCII code 38).
         *
         */
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
                throw new Exception("Invalid Signature Version specified");
            }

            return Sign(stringToSign, key, algorithm);
        }


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

        /**
         * Computes RFC 2104-compliant HMAC signature.
         */
        private String Sign(String data, String key, KeyedHashAlgorithm algorithm)
        {
            Encoding encoding = new UTF8Encoding();
            algorithm.Key = encoding.GetBytes(key);
            return Convert.ToBase64String(algorithm.ComputeHash(
                encoding.GetBytes(data.ToCharArray())));
        }


        /**
         * Formats date as ISO 8601 timestamp
         */
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

        /* Create MWS service URL and the Endpoint path */

        private void createServiceUrl(RegionSpecificProperties regionProperties)
        {
            string region = "";
            modePath = System.Convert.ToBoolean(config["sandbox"]) ? "OffAmazonPayments_Sandbox" : "OffAmazonPayments";

            if (!string.IsNullOrEmpty(config["region"].ToString()))
            {
                region = config["region"].ToString().ToLower();
                if (regionProperties.regionMappings.ContainsKey(region))
                {
                    mwsEndpointUrl = regionProperties.mwsServiceUrls[regionProperties.regionMappings[region]].ToString();
                    mwsServiceUrl = "https://" + mwsEndpointUrl + "/" + modePath + "/" + SERVICE_VERSION;
                    mwsEndpointPath = "/" + modePath + "/" + SERVICE_VERSION;
                }
                else
                {
                    throw new Exception(region + " is not a valid region");
                }
            }
            else
            {
                throw new Exception("config['region'] is a required parameter and is not set");
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

            sb.Append(QuoteApplicationName(config["application_name"].ToString()));
            sb.Append("/");
            sb.Append(QuoteApplicationVersion(config["application_version"].ToString()));
            sb.Append(" (");
            sb.Append("Language=");
            sb.Append(QuoteAttributeValue("C#"));

            int i = 0;
            while (i < additionalNameValuePairs.Length)
            {
                string name = additionalNameValuePairs[i];
                string value = additionalNameValuePairs[++i];
                sb.Append("; ");
                sb.Append(QuoteAttributeName(name));
                sb.Append("=");
                sb.Append(QuoteAttributeValue(value));

                i++;
            }

            sb.Append(")");

            userAgent = sb.ToString();
        }

        /// <summary>
        /// Replace all whitespace characters by a single space.
        /// </summary>
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
        /// Collapse whitespace, and escape the following characters are escaped:
        /// '\', and '/'.
        /// </summary>
        private static string QuoteApplicationName(string s)
        {
            return Clean(s).Replace(@"\", @"\\").Replace("@/", @"\/");
        }

        /// <summary>
        /// Collapse whitespace, and escape the following characters are escaped:
        /// '\', and '('.
        /// </summary>
        private static string QuoteApplicationVersion(string s)
        {
            return Clean(s).Replace(@"\", @"\\").Replace(@"(", @"\(");
        }

        /// <summary>
        /// Collapse whitespace, and escape the following characters are escaped:
        /// '\', and '='.
        /// </summary>
        private static string QuoteAttributeName(string s)
        {
            return Clean(s).Replace(@"\", @"\\").Replace(@"=", @"\=");
        }

        /// <summary>
        /// Collapse whitespace, and escape the following characters are escaped:
        /// ')', '\', and ';'.
        /// </summary>
        private static string QuoteAttributeValue(string s)
        {
            return Clean(s).Replace(@"\", @"\\").Replace(@";", @"\;").Replace(@")", @"\)");
        }

    } //class

}//namespace