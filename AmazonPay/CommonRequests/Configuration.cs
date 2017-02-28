using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AmazonPay.CommonRequests
{
    /// <summary>
    /// Configuration setter - sets the configuration values
    /// </summary>
    public class Configuration
    {
        private string merchant_id;
        private string access_key;
        private string secret_key;
        private string region;
        private string currency_code;
        private bool sandbox = false;
        private string platform_id;
        private string cabundle_file;
        private string application_name;
        private string application_version;
        private string proxy_host;
        private int proxy_port;
        private string proxy_password;
        private string proxy_username;
        private string client_id;
        private bool auto_retry_on_throttle = true;

        private Dictionary<string, string> dictionaryFromJson;

        private enum configurationKeys
        {
            merchant_id, access_key, secret_key, region, currency_code, sandbox, platform_id, cabundle_file, application_name,
            application_version, proxy_host, proxy_port, proxy_username, proxy_password, client_id, auto_retry_on_throttle
        }

        public Configuration()
        {
            this.proxy_port = -1;
        }

        public Configuration(string json)
        {
            try
            {
                dictionaryFromJson = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                foreach (KeyValuePair<string, string> pair in dictionaryFromJson)
                {
                    if (Enum.IsDefined(typeof(configurationKeys), pair.Key.ToLower()))
                    {
                        switch ((configurationKeys)Enum.Parse(typeof(configurationKeys), pair.Key.ToLower()))
                        {
                            case configurationKeys.merchant_id: WithMerchantId(pair.Value);
                                break;
                            case configurationKeys.access_key: WithAccessKey(pair.Value);
                                break;
                            case configurationKeys.secret_key: WithSecretKey(pair.Value);
                                break;
                            case configurationKeys.region:
                                // Checking if the value in the json for region is present in the supported region enum of the Regions class
                                if (Enum.IsDefined(typeof(Regions.supportedRegions), pair.Value.ToLower()))
                                {
                                    // If the region is present convert it to an enum type and pass it to the WithRegion method
                                    var region = (Regions.supportedRegions)Enum.Parse(typeof(Regions.supportedRegions), pair.Value.ToLower());
                                    WithRegion((Enum)region);
                                }
                                else
                                {
                                    throw new InvalidDataException("Region :" + pair.Value + " is not supported");
                                }
                                break;
                            case configurationKeys.sandbox: WithSandbox(bool.Parse(pair.Value.ToLower()));
                                break;
                            case configurationKeys.currency_code:
                                // Checking if the value in the json for Currency Code is present in the currencyCode enum of the Regions class
                                if (Enum.IsDefined(typeof(Regions.currencyCode), pair.Value.ToUpper()))
                                {
                                    // If the Currency Code is present convert it to an enum type and pass it to the WithRegion method
                                    var currencyCode = (Regions.currencyCode)Enum.Parse(typeof(Regions.currencyCode), pair.Value.ToUpper());
                                    WithCurrencyCode((Enum)currencyCode);
                                }
                                else
                                {
                                    throw new InvalidDataException("Currency Code :" + pair.Value + " is not supported");
                                }
                                break;
                            case configurationKeys.platform_id: WithPlatformId(pair.Value);
                                break;
                            case configurationKeys.cabundle_file: WithCABundleFile(pair.Value);
                                break;
                            case configurationKeys.application_name: WithApplicationName(pair.Value);
                                break;
                            case configurationKeys.application_version: WithApplicationVersion(pair.Value);
                                break;
                            case configurationKeys.proxy_host: WithProxyHost(pair.Value);
                                break;
                            case configurationKeys.proxy_port: WithProxyPort(int.Parse(pair.Value));
                                break;
                            case configurationKeys.proxy_username: WithProxyUserName(pair.Value);
                                break;
                            case configurationKeys.proxy_password: WithProxyUserPassword(pair.Value);
                                break;
                            case configurationKeys.client_id: WithClientId(pair.Value);
                                break;
                            case configurationKeys.auto_retry_on_throttle: WithAutoRetryOnThrottle(bool.Parse(pair.Value));
                                break;
                        }
                    }
                }
            }
            catch (JsonReaderException e)
            {
                throw new JsonReaderException("Incorrect JSON Format. Check your JSON config file for syntax errors\n" + e);
            }


        }
        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithMerchantId(string merchant_id)
        {
            this.merchant_id = merchant_id;

            return this;
        }
        public string GetMerchantId()
        {
            return this.merchant_id;
        }

        /// <summary>
        /// Sets the Access Key
        /// </summary>
        /// <param name="access_key"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithAccessKey(string access_key)
        {
            this.access_key = access_key;
            return this;
        }
        public string GetAccessKey()
        {
            return this.access_key;
        }

        /// <summary>
        /// Sets the Secret Key
        /// </summary>
        /// <param name="secret_key"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithSecretKey(string secret_key)
        {
            this.secret_key = secret_key;
            return this;
        }
        public string GetSecretKey()
        {
            return this.secret_key;
        }

        /// <summary>
        /// Sets the Region
        /// </summary>
        /// <param name="region"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithRegion(Enum region)
        {
            this.region = region.ToString().ToLower();
            return this;
        }
        public string GetRegion()
        {
            return this.region;
        }

        /// <summary>
        /// Sets the Currency Code
        /// </summary>
        /// <param name="currency_code"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithCurrencyCode(Enum currency_code)
        {
            this.currency_code = currency_code.ToString();
            return this;
        }
        public string GetCurrencyCode()
        {
            return this.currency_code;
        }

        /// <summary>
        /// Sets the Sandbox Boolean value
        /// </summary>
        /// <param name="sandbox"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithSandbox(bool sandbox = false)
        {
            this.sandbox = sandbox;
            return this;
        }
        public string GetSandbox()
        {
            return this.sandbox.ToString().ToLower();
        }

        /// <summary>
        /// Sets the Platform ID
        /// </summary>
        /// <param name="platform_id"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithPlatformId(string platform_id)
        {
            this.platform_id = platform_id;
            return this;
        }
        public string GetPlatformId()
        {
            return this.platform_id;
        }

        /// <summary>
        /// Sets the CA Bundle File 
        /// </summary>
        /// <param name="cabundle_file"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithCABundleFile(string cabundle_file)
        {
            this.cabundle_file = cabundle_file;
            return this;
        }
        public string GetCABundleFile()
        {
            return this.cabundle_file;
        }

        /// <summary>
        /// Sets the custom Application name
        /// </summary>
        /// <param name="application_name"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithApplicationName(string application_name)
        {
            this.application_name = application_name;
            return this;
        }
        public string GetApplicationName()
        {
            return this.application_name;
        }

        /// <summary>
        /// Sets the Application version
        /// </summary>
        /// <param name="application_version"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithApplicationVersion(string application_version)
        {
            this.application_version = application_version;
            return this;
        }
        public string GetApplicationVersion()
        {
            return this.application_version;
        }

        /// <summary>
        /// Sets the Hostname for the Proxy
        /// </summary>
        /// <param name="proxy_host"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithProxyHost(string proxy_host)
        {
            this.proxy_host = proxy_host;
            return this;
        }
        public string GetProxyHost()
        {
            return this.proxy_host;
        }

        /// <summary>
        /// Sets the port for the Proxy
        /// </summary>
        /// <param name="proxy_port"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithProxyPort(int proxy_port)
        {
            this.proxy_port = proxy_port;
            return this;
        }
        public int GetProxyPort()
        {
            return this.proxy_port;
        }

        /// <summary>
        /// Sets the Username for the Proxy
        /// </summary>
        /// <param name="proxy_username"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithProxyUserName(string proxy_username)
        {
            this.proxy_username = proxy_username;
            return this;
        }
        public string GetProxyUserName()
        {
            return this.proxy_username;
        }

        /// <summary>
        /// Sets the Password for the Proxy
        /// </summary>
        /// <param name="proxy_password"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithProxyUserPassword(string proxy_password)
        {
            this.proxy_password = proxy_password;
            return this;
        }
        public string GetProxyUserPassword()
        {
            return this.proxy_password;
        }

        /// <summary>
        /// Sets the Client ID 
        /// </summary>
        /// <param name="client_id"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithClientId(string client_id)
        {
            this.client_id = client_id;
            return this;
        }
        public string GetClientId()
        {
            return this.client_id;
        }

        /// <summary>
        /// Sets the value for the handle throttling to be enabled/disabled 
        /// </summary>
        /// <param name="auto_retry_on_throttle"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithAutoRetryOnThrottle(bool auto_retry_on_throttle)
        {
            this.auto_retry_on_throttle = auto_retry_on_throttle;
            return this;
        }
        public bool GetAutoRetryOnThrottle()
        {
            return this.auto_retry_on_throttle;
        }
    }
}
