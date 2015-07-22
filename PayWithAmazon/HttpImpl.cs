using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace PayWithAmazon
{
    /// <summary>
    /// Class HttpImpl - Handles  POST and GET functionality for all requests
    /// </summary>
    class HttpImpl
    {
        public string response;
        public bool header = false;
        public string accessToken = "";
        public Hashtable responseHash;
        public HttpStatusCode statusCode;

        Hashtable config = new Hashtable();

        public HttpImpl(Hashtable config)
        {
            this.config = config;
            responseHash = new Hashtable();
        }

        /// <summary>
        /// Setter for boolean header to get the user info
        /// </summary>
        public void setHttpHeader()
        {
            header = true;
        }

        /// <summary>
        /// Setter for Access token to get the user info
        /// </summary>
        /// <param name="accesstoken"></param>
        public void setAccessToken(string accesstoken)
        {
            this.accessToken = accesstoken;
        }

        /// <summary>
        /// Add the common POST Parameters
        /// </summary>
        /// <param name="method"></param>
        /// <param name="url"></param>
        /// <param name="userAgent"></param>
        /// <param name="contentLength"></param>
        /// <returns>HttpWebRequest request</returns>
        private HttpWebRequest ConfigureWebRequest(string method, string url, string userAgent = null, int contentLength = 0)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

            if (config["proxy_host"] != null && (System.Convert.ToInt32(config["proxy_port"])) != -1)
            {
                WebProxy proxy = new WebProxy(config["proxy_host"].ToString(), System.Convert.ToInt32(config["proxy_port"]));
                if (!(string.IsNullOrEmpty(config["proxy_username"].ToString()) && !(string.IsNullOrEmpty(config["proxy_password"].ToString()))))
                {
                    proxy.Credentials = new NetworkCredential(config["proxy_username"].ToString(), config["proxy_password"].ToString());
                }

                request.Proxy = proxy;
            }
            if (!string.IsNullOrEmpty(userAgent))
            {
                request.UserAgent = userAgent;
            }
            if (header)
            {
                request.Headers.Add("Authorization: bearer " + accessToken);
            }
            request.Method = method;
            request.Timeout = 50000;
            request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
            request.ContentLength = contentLength;

            responseHash.Clear();

            return request;
        }

        /// <summary>
        /// GET Method
        /// </summary>
        /// <param name="url"></param>
        /// <returns>string response</returns>
        public string Get(string url)
        {
            HttpWebRequest request = ConfigureWebRequest("GET", url);
            execute(request);
            return response;
        }

        /// <summary>
        /// POST Method
        /// </summary>
        /// <param name="url"></param>
        /// <param name="userAgent"></param>
        /// <param name="requestData"></param>
        /// <returns>Hashtable responseHash</returns>
        public Hashtable Post(string url, string userAgent, byte[] requestData)
        {
            HttpWebRequest request = ConfigureWebRequest("POST", url, userAgent, requestData.Length);
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(requestData, 0, requestData.Length);
            }
            execute(request);
            responseHash.Add("response", response);
            responseHash.Add("statusCode", statusCode);

            return responseHash;
        }
        
        /// <summary>
        /// Executes the request
        /// </summary>
        /// <param name="request"></param>
        private void execute(HttpWebRequest request)
        {
            statusCode = default(HttpStatusCode);
            try
            {
                using (HttpWebResponse httpResponse = request.GetResponse() as HttpWebResponse)
                {
                    statusCode = httpResponse.StatusCode;
                    StreamReader reader = new StreamReader(httpResponse.GetResponseStream(), Encoding.UTF8);
                    this.response = reader.ReadToEnd();
                }

            }
            catch (WebException we)
            {
                using (HttpWebResponse httpErrorResponse = (HttpWebResponse)we.Response as HttpWebResponse)
                {
                    if (httpErrorResponse == null)
                    {
                        throw new NullReferenceException("Http Response is empty " + we);
                    }
                    if (httpErrorResponse != null)
                    {
                        statusCode = httpErrorResponse.StatusCode;
                        using (StreamReader reader = new StreamReader(httpErrorResponse.GetResponseStream(), Encoding.UTF8))
                        {
                            this.response = reader.ReadToEnd();
                        }
                    }
                }
            }
        }
    }
}