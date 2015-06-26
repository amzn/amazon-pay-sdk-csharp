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
            json = JsonConvert.SerializeObject(xml,Newtonsoft.Json.Formatting.Indented);
            
            return json;
        }
        public IDictionary<string,object> ToDict()
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
        public string GetBillingAgreementStatus(string xml)
        {
            string baStatus = "";

            xml = RemoveNamespace(xml);

            XmlDocument results = new XmlDocument();
            results.LoadXml(xml);

            baStatus = results.SelectSingleNode("//GetBillingAgreementDetailsResponse/GetBillingAgreementDetailsResult/BillingAgreementDetails/BillingAgreementStatus/State").InnerText;

            return baStatus;
        }
        public string GetOrderReferenceStatus(string xml)
        {
            string OroStatus = "";

            xml = RemoveNamespace(xml);

            XmlDocument results = new XmlDocument();
            results.LoadXml(xml);

            OroStatus = results.SelectSingleNode("//GetOrderReferenceDetailsResponse/GetOrderReferenceDetailsResult/OrderReferenceDetails/OrderReferenceStatus/State").InnerText;

            return OroStatus;
        }
    }
}
