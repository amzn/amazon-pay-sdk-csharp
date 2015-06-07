using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace PayWithAmazon
{

    class HttpImpl
    {
        public string mwsServiceUrl;
        public string userAgent;
        public string response;
        public Hashtable responseHash;
        public HttpStatusCode statusCode;

        public HttpImpl(string mwsServiceUrl, string userAgent)
        {
            this.mwsServiceUrl = mwsServiceUrl;
            this.userAgent = userAgent;
            responseHash = new Hashtable();
            
        }
        
       /**
       * Configure HttpClient with set of defaults as well as configuration
       * from OffAmazonPaymentsServiceConfig instance
       */
        private HttpWebRequest ConfigureWebRequest(int contentLength,string method)
        {
            HttpWebRequest request = WebRequest.Create(this.mwsServiceUrl) as HttpWebRequest;
            /*
            if (config.IsSetProxyHost())
            {
                request.Proxy = new WebProxy(config.ProxyHost, config.ProxyPort);
            }*/
            request.UserAgent = this.userAgent;
            request.Method = method;
            request.Timeout = 50000;
            request.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
            request.ContentLength = contentLength;
            responseHash.Clear();

            return request;
        }
        public string Get()
        {
            string response = "";
            return response;
        }
        public Hashtable Post(byte[] requestData)
        {
            /*   try
               {
                   HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                   HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                   Stream stream = response.GetResponseStream();
                   StreamReader reader = new StreamReader(stream);

                   string data = reader.ReadToEnd();

                   reader.Close();
                   stream.Close();

                   return data;
               }
               catch (Exception e)
               {
                   Console.WriteLine(e.toString());
               }*/

            HttpWebRequest request = ConfigureWebRequest(requestData.Length,"POST");
            using (Stream requestStream = request.GetRequestStream())
            {
                requestStream.Write(requestData, 0, requestData.Length);

            }
            execute(request);
            responseHash.Add("response", response);
            responseHash.Add("statusCode", statusCode);

            return responseHash;
        }

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
                        System.Console.WriteLine("the error is that response IS EMPTYYYYY");
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
