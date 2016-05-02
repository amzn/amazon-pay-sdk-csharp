using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class GetRefundDetailsResponseTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\GetRefundDetailsResponse.xml";
        }
        
        protected override System.Type getTypeOfTestClass()
        {
            return typeof(GetRefundDetailsResponse);
        }
        
        [Test]
        public void GetRefundDetailsResponseNullOrEmptyTest()
        {
            TestNullorEmpty();
        }
        
        [Test]
        public void GetRefundDetailsResponseSchemaTest()
        {
            TestSchema();
        }
    }
}

