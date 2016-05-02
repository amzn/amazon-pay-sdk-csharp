using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class RefundRequestTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\RefundRequest.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(RefundRequest);
        }

        [Test]
        public void RefundRequestNullOrEmptyTest()
        {
            TestNullorEmpty();
        }

        [Test]
        public void RefundRequestSchemaTest()
        {
            TestSchema();
        }
    }
}

