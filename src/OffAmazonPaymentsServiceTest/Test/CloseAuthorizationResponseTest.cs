using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class CloseAuthorizationResponseTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\CloseAuthorizationResponse.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(CloseAuthorizationResponse);
        }

        [Test]
        public void CloseAuthorizationResponseNullOrEmptyTest()
        {
            TestNullorEmpty();
        }

        [Test]
        public void CloseAuthorizationResponseSchemaTest()
        {
            TestSchema();
        }

    }
}
