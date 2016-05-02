using NUnit.Framework;
using OffAmazonPaymentsService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class CloseBillingAgreementResponseTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\CloseBillingAgreementResponse.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(CloseBillingAgreementResponse);
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
