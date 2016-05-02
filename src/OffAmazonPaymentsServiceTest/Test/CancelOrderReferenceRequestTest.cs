using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class CancelOrderReferenceRequestTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\CancelOrderReferenceRequest.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(CancelOrderReferenceRequest);
        }

        [Test]
        public void CancelOrderReferenceRequestNullOrEmptyTest()
        {
            TestNullorEmpty();
        }

        [Test]
        public void CancelOrderReferenceRequestSchemaTest()
        {
            TestSchema();
        }
    }
}
