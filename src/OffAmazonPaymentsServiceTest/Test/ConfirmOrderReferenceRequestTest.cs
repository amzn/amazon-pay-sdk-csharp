using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class ConfirmOrderReferenceRequestTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\ConfirmOrderReferenceRequest.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(ConfirmOrderReferenceRequest);
        }

        [Test]
        public void ConfirmOrderReferenceRequestNullOrEmptyTest()
        {
            TestNullorEmpty();
        }

        [Test]
        public void ConfirmOrderReferenceRequestSchemaTest()
        {
            TestSchema();
        }
    }
}
