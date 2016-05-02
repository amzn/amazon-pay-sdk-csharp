using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class CancelOrderReferenceResponseTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\CancelOrderReferenceResponse.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(CancelOrderReferenceResponse);
        }

        [Test]
        public void CancelOrderReferenceResponseNullOrEmptyTest()
        {
            TestNullorEmpty();
        }

        [Test]
        public void CancelOrderReferenceResponseSchemaTest()
        {
            TestSchema();
        }
    }
}
