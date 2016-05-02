using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;


namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class AuthorizeRequestTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\AuthorizeRequest.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(AuthorizeRequest);
        }

        [Test]
        public void AuthorizeRequestNullOrEmptyTest()
        {
            TestNullorEmpty();
        }

        [Test]
        public void AuthrorizeRequestSchemaTest()
        {
            TestSchema();
        }
    }
}
