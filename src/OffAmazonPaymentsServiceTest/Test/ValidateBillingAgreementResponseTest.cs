using NUnit.Framework;
using OffAmazonPaymentsService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class ValidateBillingAgreementResponseTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\ValidateBillingAgreementResponse.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(ValidateBillingAgreementResponse);
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
