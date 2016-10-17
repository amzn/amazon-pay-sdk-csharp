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
    public static class ResponseParser
    {
        public static string xmlResponse = null;

        /*public ResponseParser(string xml)
        {
            xmlResponse = xml.Trim();
        }*/

        /// <summary>
        /// Convert API response to XML
        /// </summary>
        /// <returns>string xml</returns>
        public static void SetXml(string xml)
        {
            xmlResponse = xml;
        }

        /// <summary>
        /// Convert API response to JSON
        /// </summary>
        /// <returns>string json</returns>
        public static string ToJson()
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
        public static Dictionary<string, object> ToDict()
        {
            string json = ToJson();
            NestedJsonToDictionary jsonToDict = new NestedJsonToDictionary(json);
            return jsonToDict.GetDictionary();
        }
    }
}