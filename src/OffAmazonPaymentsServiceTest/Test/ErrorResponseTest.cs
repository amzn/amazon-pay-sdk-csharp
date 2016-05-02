using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class ErrorResponseTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\ErrorResponse.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(ErrorResponse);
        }

        [Test]
        public void ErrorResponseNullOrEmptyTest()
        {
            TestNullorEmpty();
        }

        [Test]
        public void ErrorResponseSchemaTest()
        {
            TestSchema();
        }
    }
}
