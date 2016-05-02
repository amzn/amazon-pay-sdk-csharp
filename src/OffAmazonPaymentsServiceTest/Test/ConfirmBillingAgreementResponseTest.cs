using NUnit.Framework;
using OffAmazonPaymentsService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class ConfirmBillingAgreementResponseTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\ConfirmBillingAgreementResponse.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(ConfirmBillingAgreementResponse);
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
