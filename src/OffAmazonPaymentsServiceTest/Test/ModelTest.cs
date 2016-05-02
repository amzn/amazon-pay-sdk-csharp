using System;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    abstract class ModelTest
    {
        protected abstract String getXmlTestFile();
        protected abstract Type getTypeOfTestClass();
        protected Object request = null;

        public void TestNullorEmpty()
        {
            using (StreamReader reader = new StreamReader(getXmlTestFile()))
            {
                XmlSerializer serializer = new XmlSerializer(getTypeOfTestClass());
                request = serializer.Deserialize(reader);
                PropertyInfo[] info = request.GetType().GetProperties();
                TestAllLevels(info, request);
            }
        }

        public void TestSchema()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(getXmlTestFile());
            XmlElement root = doc.DocumentElement;
            if (!root.Name.Equals(request.GetType().Name))
                TestSchemaRecursive(root, request);
        }

        private void TestSchemaRecursive(XmlNode root, Object obj)
        {
            if (isValueOrStringType(obj.GetType()))
                return;

            Dictionary<string, XmlNode> xmlNodes = new Dictionary<string, XmlNode>();
            Dictionary<string, Object> objNodes = new Dictionary<string, Object>();
            foreach (XmlNode node in root.ChildNodes)
            {
                xmlNodes.Add(node.Name, node);
            }

            foreach (PropertyInfo info in obj.GetType().GetProperties())
            {
                objNodes.Add(info.Name, info.GetValue(obj, null));
            }

            Assert.IsTrue(CompareNodes(xmlNodes, objNodes));

            foreach (string node in xmlNodes.Keys)
            {
                TestSchemaRecursive(xmlNodes[node], objNodes[node]);
            }
        }

        private bool CompareNodes(Dictionary<string, XmlNode> xmlNodes, Dictionary<string, Object> objNodes)
        {
            if (xmlNodes.Count != objNodes.Count)
                return false;
            foreach (string node in xmlNodes.Keys)
            {
                if (!objNodes.ContainsKey(node))
                    return false;
            }
            return true;
        }

        private void TestAllLevels(PropertyInfo[] info, Object obj)
        {
            foreach (PropertyInfo i in info)
            {
                Assert.IsNotNull(i.GetValue(obj, null));
                if (!isValueOrStringType(i.PropertyType))
                {
                    TestAllLevels(i.PropertyType.GetProperties(), i.GetValue(obj, null));
                }
            }
        }

        private bool isValueOrStringType(Type t)
        {
            return (t.IsValueType || (t.Equals(typeof(String))) || t.Name == "List`1");
        }
    }
}

