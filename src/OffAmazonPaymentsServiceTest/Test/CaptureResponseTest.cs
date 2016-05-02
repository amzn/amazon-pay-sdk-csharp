using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class CaptureResponseTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\CaptureResponse.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(CaptureResponse);
        }

        [Test]
        public void CaptureResponseNullOrEmptyTest()
        {
            TestNullorEmpty();
        }

        [Test]
        public void CaptureResponseSchemaTest()
        {
            TestSchema();
        }

    }
}
