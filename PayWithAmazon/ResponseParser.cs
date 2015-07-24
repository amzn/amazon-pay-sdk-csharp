using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.XPath;

namespace PayWithAmazon
{
    /// <summary>
    /// ResponseParser - Methods provided to convert the Response from the POST to XML, Dictionary or JSON
    /// </summary>
    public class ResponseParser
    {
        public string xmlResponse = null;

        public ResponseParser(string xml)
        {
            xmlResponse = xml.Trim();
        }

        /// <summary>
        /// Convert API response to XML
        /// </summary>
        /// <returns>string xml</returns>
        public string ToXml()
        {
            return xmlResponse;
        }

        /// <summary>
        /// Convert API response to JSON
        /// </summary>
        /// <returns>string json</returns>
        public string ToJson()
        {
            string json = "";
            var xml = new XmlDocument();
            xml.LoadXml(xmlResponse.Trim());
            json = JsonConvert.SerializeObject(xml, Newtonsoft.Json.Formatting.Indented);

            return json;
        }
        
        /// <summary>
        /// Convert API response to Dictionary
        /// </summary>
        /// <returns>Dictionary(string,object)</returns>
        public Dictionary<string, object> ToDict()
        {
            string json = ToJson();

            Dictionary<string, object> dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(
           json, new JsonConverter[] { new JsonParser() });

            return dict;
        }

        private string RemoveNamespace(string xml)
        {
            string filter = @"xmlns(:\w+)?=""([^""]+)""|xsi(:\w+)?=""([^""]+)""";
            xml = Regex.Replace(xml, filter, "");
            return xml;
        }

        /// <summary>
        /// Get the billing agreement State for the Charge function
        /// </summary>
        /// <param name="xml"></param>
        /// <returns>string baStatus</returns>
        public string GetBillingAgreementStatus(string xml)
        {
            string baStatus = "";
            try
            {
                xml = RemoveNamespace(xml);

                XmlDocument results = new XmlDocument();
                results.LoadXml(xml);

                baStatus = results.SelectSingleNode("//GetBillingAgreementDetailsResponse/GetBillingAgreementDetailsResult/BillingAgreementDetails/BillingAgreementStatus/State").InnerText;
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException("state not found" + e);
            }
            return baStatus;
        }

        /// <summary>
        /// Get the order reference State for the Charge function
        /// </summary>
        /// <param name="xml"></param>
        /// <returns>string OroStatus</returns>
        public string GetOrderReferenceStatus(string xml)
        {
            string OroStatus = "";
            try
            {
                xml = RemoveNamespace(xml);

                XmlDocument results = new XmlDocument();
                results.LoadXml(xml);

                OroStatus = results.SelectSingleNode("//GetOrderReferenceDetailsResponse/GetOrderReferenceDetailsResult/OrderReferenceDetails/OrderReferenceStatus/State").InnerText;
            }
            catch (NullReferenceException e)
            {
                throw new NullReferenceException("state not found" + e);
            }
            return OroStatus;
        }
    }
}