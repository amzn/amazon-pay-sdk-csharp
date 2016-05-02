using NUnit.Framework;
using OffAmazonPaymentsService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class GetBillingAgreementDetailsResponseTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\GetBillingAgreementDetailsResponse.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(GetBillingAgreementDetailsResponse);
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
