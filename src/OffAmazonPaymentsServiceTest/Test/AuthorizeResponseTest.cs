using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;


namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class AuthorizeResponseTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\AuthorizeResponse.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(AuthorizeResponse);
        }

        [Test]
        public void AuthorizeResponseNullOrEmptyTest()
        {
            TestNullorEmpty();
        }

        [Test]
        public void AuthrorizeResponseSchemaTest()
        {
            TestSchema();
        }
    }
}
