using NUnit.Framework;
using OffAmazonPaymentsService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class ConfirmBillingAgreementRequestTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\ConfirmBillingAgreementRequest.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(ConfirmBillingAgreementRequest);
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
