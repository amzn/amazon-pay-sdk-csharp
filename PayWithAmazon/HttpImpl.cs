using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using PayWithAmazon.CommonRequests;

namespace PayWithAmazon
{
    /// <summary>
    /// Class HttpImpl - Handles  POST and GET functionality for all requests
    /// </summary>
    class HttpImpl
    {
        private string response;
        private bool header = false;
        private string accessToken = "";
        public Dictionary<string,string> responseDict;
        private Configuration clientConfig;
        private int statusCode;
        

        public HttpImpl(Configuration config)
        {
            responseDict = new Dictionary<string,string>();
            this.clientConfig = config;
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

            if (clientConfig.GetProxyHost() != null && (clientConfig.GetProxyPort()) != -1)
            {
                WebProxy proxy = new WebProxy(clientConfig.GetProxyHost(), clientConfig.GetProxyPort());
                if (!(string.IsNullOrEmpty(clientConfig.GetProxyUserName()) && !(string.IsNullOrEmpty(clientConfig.GetProxyUserPassword()))))
                {
                    proxy.Credentials = new NetworkCredential(clientConfig.GetProxyUserName(), clientConfig.GetProxyUserPassword());
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
            request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
            request.ContentLength = contentLength;

            responseDict.Clear();

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
        /// <returns>Dictionary responseDict</returns>
        public Dictionary<string,string> Post(string url, string userAgent, byte[] requestData)
        {
            HttpWebRequest request = ConfigureWebRequest("POST", url, userAgent, requestData.Length);
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(requestData, 0, requestData.Length);
            }
            execute(request);
            responseDict.Add("response", response);
            responseDict.Add("statusCode", statusCode.ToString());

            return responseDict;
        }

        /// <summary>
        /// Executes the request
        /// </summary>
        /// <param name="request"></param>
        private void execute(HttpWebRequest request)
        {
            try
            {
                using (HttpWebResponse httpResponse = request.GetResponse() as HttpWebResponse)
                {
                    statusCode = (int)httpResponse.StatusCode;
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
                        this.statusCode = (int)httpErrorResponse.StatusCode;
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