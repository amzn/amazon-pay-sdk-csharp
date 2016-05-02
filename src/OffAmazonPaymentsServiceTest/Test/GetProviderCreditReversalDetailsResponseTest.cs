using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class GetProviderCreditReversalDetailsResponseTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\GetProviderCreditReversalDetailsResponse.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(GetProviderCreditReversalDetailsResponse);
        }

        [Test]
        public void GetProviderCreditReversalDetailsResponseNullOrEmptyTest()
        {
            TestNullorEmpty();
        }

        [Test]
        public void GetProviderCreditReversalDetailsResponseSchemaTest()
        {
            TestSchema();
        }
    }
}

