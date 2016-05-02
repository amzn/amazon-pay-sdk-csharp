using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class GetProviderCreditDetailsResponseTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\GetProviderCreditDetailsResponse.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(GetProviderCreditDetailsResponse);
        }

        [Test]
        public void GetProviderCreditDetailsResponseNullOrEmptyTest()
        {
            TestNullorEmpty();
        }

        [Test]
        public void GetProviderCreditDetailsResponseSchemaTest()
        {
            TestSchema();
        }
    }
}

