using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class GetOrderReferenceDetailsResponseTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\GetOrderReferenceDetailsResponse.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(GetOrderReferenceDetailsResponse);
        }
        
        [Test]
        public void GetOrderReferenceDetailsResponseNullOrEmptyTest()
        {
            TestNullorEmpty();
        }
        
        [Test]
        public void GetOrderReferenceDetailsResponseSchemaTest()
        {
            TestSchema();
        }
    }
}

