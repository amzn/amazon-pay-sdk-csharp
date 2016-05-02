using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class CloseOrderReferenceResponseTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\CloseOrderReferenceResponse.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(CloseOrderReferenceResponse);
        }

        [Test]
        public void CloseOrderReferenceResponseNullOrEmptyTest()
        {
            TestNullorEmpty();
        }

        [Test]
        public void CloseOrderReferenceResponseSchemaTest()
        {
            TestSchema();
        }

    }
}
