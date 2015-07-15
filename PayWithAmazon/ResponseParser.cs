using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.XPath;

/* ResponseParser
 * Methods provided to convert the Response from the POST to XML, Array or JSON
 */

namespace PayWithAmazon
{
    public class ResponseParser
    {
        public string xmlResponse = null;

        public ResponseParser(string xml)
        {
            xmlResponse = xml.Trim();
        }

        public string ToXml()
        {
            return xmlResponse;
        }

        public string ToJson()
        {
            string json = "";
            var xml = new XmlDocument();
            xml.LoadXml(xmlResponse.Trim());
            json = JsonConvert.SerializeObject(xml, Newtonsoft.Json.Formatting.Indented);

            return json;
        }

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

        /* Get the Billing Agreement State for the Charge function */

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
                throw new ArgumentNullException("state not found" + e);
            }
            return baStatus;
        }

        /* Get the Order Reference State for the Charge function */

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
                throw new ArgumentNullException("state not found" + e);
            }
            return OroStatus;
        }
    }
}