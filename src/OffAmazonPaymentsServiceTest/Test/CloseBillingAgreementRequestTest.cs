using NUnit.Framework;
using OffAmazonPaymentsService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class CloseBillingAgreementRequestTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\CloseBillingAgreementRequest.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(CloseBillingAgreementRequest);
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
