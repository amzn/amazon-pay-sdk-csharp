using Newtonsoft.Json;
using System.Collections.Generic;
using System.Xml;

namespace AmazonPay
{
    /// <summary>
    /// ResponseParser - Methods provided to convert the Response from the POST to XML, Dictionary or JSON
    /// </summary>
    public static class ResponseParser
    {

        /// <summary>
        /// Convert API response to JSON
        /// </summary>
        /// <returns>string json</returns>
        public static string ToJson(string xmlResponse)
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
        public static Dictionary<string, object> ToDict(string xmlResponse)
        {
            string json = ToJson(xmlResponse);
            NestedJsonToDictionary jsonToDict = new NestedJsonToDictionary(json);
            return jsonToDict.GetDictionary();
        }
    }
}