using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml.Serialization;

namespace OffAmazonPaymentsNotificationsTest
{
    abstract class NotificationTest <T>
    {
        private string _rootAttribute;

        public NotificationTest (string rootAttribute)
        {
            this._rootAttribute = rootAttribute;
        }

        protected void Parser(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T), NotificationTest<T>.InitiateXmlRootAttribute(reader, this._rootAttribute));
                T orn = (T)serializer.Deserialize(reader);
            }
        }

        private static XmlRootAttribute InitiateXmlRootAttribute(StreamReader reader, String elementName)
        {
            Stream s = reader.BaseStream;
            XmlRootAttribute xRoot = new XmlRootAttribute();
            xRoot.ElementName = elementName;
            Regex regex = new Regex("xmlns=\"(.*)\">");
            Match match = regex.Match(reader.ReadToEnd());

            s.Position = 0;
            reader.DiscardBufferedData();

            if (match.Success)
            {
                xRoot.Namespace = match.Groups[1].Value;
                xRoot.IsNullable = true;
                return xRoot;
            }
            else
                return null;
        }
    }
}
