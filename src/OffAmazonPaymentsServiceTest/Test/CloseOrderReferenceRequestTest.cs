using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class CloseOrderReferenceRequestTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\CloseOrderReferenceRequest.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(CloseOrderReferenceRequest);
        }

        [Test]
        public void CloseOrderReferenceRequestNullOrEmptyTest()
        {
            TestNullorEmpty();
        }

        [Test]
        public void CloseOrderReferenceRequestSchemaTest()
        {
            TestSchema();
        }

    }
}
