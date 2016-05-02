using NUnit.Framework;
using OffAmazonPaymentsService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class AuthorizeOnBillingAgreementRequestTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\AuthorizeOnBillingAgreementRequest.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(AuthorizeOnBillingAgreementRequest);
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
