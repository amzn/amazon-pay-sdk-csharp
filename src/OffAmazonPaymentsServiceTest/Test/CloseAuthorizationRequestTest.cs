using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class CloseAuthorizationRequestTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\CloseAuthorizationRequest.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(CloseAuthorizationRequest);
        }

        [Test]
        public void CloseAuthorizationRequestNullOrEmptyTest()
        {
            TestNullorEmpty();
        }

        [Test]
        public void CloseAuthorizationRequestSchemaTest()
        {
            TestSchema();
        }
    }
}
