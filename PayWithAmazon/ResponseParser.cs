using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

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
           json, new JsonConverter[] { new RecursiveJsonParser() });
           
            return dict;
        }
    }
}
