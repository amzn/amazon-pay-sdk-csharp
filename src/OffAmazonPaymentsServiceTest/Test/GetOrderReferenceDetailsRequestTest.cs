using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using NUnit.Framework;
using OffAmazonPaymentsService.Model;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class GetOrderReferenceDetailsRequestTest : ModelTest
    {

        protected override String getXmlTestFile()
        {
            return @"..\..\xml\GetOrderReferenceDetailsRequest.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(GetOrderReferenceDetailsRequest);
        }

        [Test]
        public void GetOrderReferenceDetailsRequestNullOrEmptyTest()
        {
            TestNullorEmpty();
        }

        [Test]
        public void GetOrderReferenceDetailsRequestSchemaTest()
        {
            TestSchema();
        }

    }
}
