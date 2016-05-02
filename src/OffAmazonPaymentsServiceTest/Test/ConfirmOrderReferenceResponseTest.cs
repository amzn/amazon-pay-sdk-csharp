using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class ConfirmOrderReferenceResponseTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\ConfirmOrderReferenceResponse.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(ConfirmOrderReferenceResponse);
        }

        [Test]
        public void ConfirmOrderReferenceResponseNullOrEmptyTest()
        {
            TestNullorEmpty();
        }

        [Test]
        public void ConfirmOrderReferenceResponseSchemaTest()
        {
            TestSchema();
        }

    }
}
