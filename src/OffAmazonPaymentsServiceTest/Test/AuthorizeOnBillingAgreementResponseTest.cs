using NUnit.Framework;
using OffAmazonPaymentsService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class AuthorizeOnBillingAgreementResponseTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\AuthorizeOnBillingAgreementResponse.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(AuthorizeOnBillingAgreementResponse);
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
