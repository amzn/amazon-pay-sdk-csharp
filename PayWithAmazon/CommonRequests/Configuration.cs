using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon.CommonRequests
{
    /// <summary>
    /// Configuration setter - sets the configuration values to the keys as defined in the Hashtable config of Client class
    /// </summary>
    public class Configuration
    {
        public Hashtable config = new Hashtable();

        public Configuration()
        {
            config["proxy_port"] = -1;
        }
        /// <summary>
        /// Sets the Merchant ID
        /// </summary>
        /// <param name="merchant_id"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithMerchantId(string merchant_id)
        {
            config["merchant_id"] = merchant_id;
            return this;
        }

        /// <summary>
        /// Sets the Access Key
        /// </summary>
        /// <param name="access_key"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithAccessKey(string access_key)
        {
            config["access_key"] = access_key;
            return this;
        }

        /// <summary>
        /// Sets the Secret Key
        /// </summary>
        /// <param name="secret_key"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithSecretKey(string secret_key)
        {
            config["secret_key"] = secret_key;
            return this;
        }

        /// <summary>
        /// Sets the Region
        /// </summary>
        /// <param name="region"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithRegion(string region)
        {
            config["region"] = region;
            return this;
        }

        /// <summary>
        /// Sets the Currency Code
        /// </summary>
        /// <param name="currency_code"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithCurrencyCode(string currency_code)
        {
            config["currency_code"] = currency_code;
            return this;
        }

        /// <summary>
        /// Sets the Sandbox Boolean value
        /// </summary>
        /// <param name="sandbox"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithSandbox(Boolean sandbox = false)
        {
            config["sandbox"] = sandbox;
            return this;
        }

        /// <summary>
        /// Sets the Platform ID
        /// </summary>
        /// <param name="platform_id"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithPlatformId(string platform_id)
        {
            config["platform_id"] = platform_id;
            return this;
        }

        /// <summary>
        /// Sets the CA Bundle File 
        /// </summary>
        /// <param name="cabundle_file"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithCABundleFile(string cabundle_file)
        {
            config["cabundle_file"] = cabundle_file;
            return this;
        }

        /// <summary>
        /// Sets the custom Application name
        /// </summary>
        /// <param name="application_name"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithApplicationName(string application_name)
        {
            config["application_name"] = application_name;
            return this;
        }

        /// <summary>
        /// Sets the Application version
        /// </summary>
        /// <param name="application_version"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithApplicationVersion(string application_version)
        {
            config["application_version"] = application_version;
            return this;
        }

        /// <summary>
        /// Sets the Hostname for the Proxy
        /// </summary>
        /// <param name="proxy_host"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithProxyHost(string proxy_host)
        {
            config["proxy_host"] = proxy_host;
            return this;
        }

        /// <summary>
        /// Sets the port for the Proxy
        /// </summary>
        /// <param name="proxy_port"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithProxyPort(int proxy_port)
        {
            config["proxy_port"] = proxy_port;
            return this;
        }

        /// <summary>
        /// Sets the Username for the Proxy
        /// </summary>
        /// <param name="proxy_username"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithProxyUserName(string proxy_username)
        {
            config["proxy_username"] = proxy_username;
            return this;
        }

        /// <summary>
        /// Sets the Password for the Proxy
        /// </summary>
        /// <param name="proxy_password"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithProxyUserPassword(string proxy_password)
        {
            config["proxy_password"] = proxy_password;
            return this;
        }

        /// <summary>
        /// Sets the Client ID 
        /// </summary>
        /// <param name="client_id"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithClientId(string client_id)
        {
            config["client_id"] = client_id;
            return this;
        }

        /// <summary>
        /// Sets the value for the handle throttling to be enabled/disabled 
        /// </summary>
        /// <param name="handle_throttle"></param>
        /// <returns>Configuration Object</returns>
        public Configuration WithHandleThrottle(Boolean handle_throttle = true)
        {
            config["handle_throttle"] = handle_throttle;
            return this;
        }

    }
}
