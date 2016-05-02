using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class GetAuthorizationDetailsRequestTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\GetAuthorizationDetailsRequest.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(GetAuthorizationDetailsRequest);
        }

        [Test]
        public void GetAuthorizationDetailsRequestNullOrEmptyTest()
        {
            TestNullorEmpty();
        }

        [Test]
        public void GetAuthorizationDetailsRequestSchemaTest()
        {
            TestSchema();
        }
    }
}
