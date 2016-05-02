using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class CaptureRequestTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\CaptureRequest.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(CaptureRequest);
        }

        [Test]
        public void CaptureRequestNullOrEmptyTest()
        {
            TestNullorEmpty();
        }

        [Test]
        public void CaptureRequestSchemaTest()
        {
            TestSchema();
        }
    }
}
