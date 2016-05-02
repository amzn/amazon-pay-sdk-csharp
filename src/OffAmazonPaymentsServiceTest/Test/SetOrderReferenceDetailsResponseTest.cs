using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class SetOrderReferenceDetailsResponseTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\SetOrderReferenceDetailsResponse.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(SetOrderReferenceDetailsResponse);
        }

        [Test]
        public void SetOrderReferenceDetailsResponseNullOrEmptyTest()
        {
            TestNullorEmpty();
        }

        [Test]
        public void SetOrderReferenceDetailsResponseSchemaTest()
        {
            TestSchema();
        }
    }
}

