using NUnit.Framework;
using OffAmazonPaymentsService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class ValidateBillingAgreementRequestTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\ValidateBillingAgreementRequest.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(ValidateBillingAgreementRequest);
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
