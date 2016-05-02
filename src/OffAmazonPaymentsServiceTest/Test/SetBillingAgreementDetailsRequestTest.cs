using NUnit.Framework;
using OffAmazonPaymentsService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class SetBillingAgreementDetailsRequestTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\SetBillingAgreementDetailsRequest.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(SetBillingAgreementDetailsRequest);
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
