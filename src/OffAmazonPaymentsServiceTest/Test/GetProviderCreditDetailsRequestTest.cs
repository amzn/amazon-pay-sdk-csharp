using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class GetProviderCreditDetailsRequestTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\GetProviderCreditDetailsRequest.xml";
        }
        
        protected override System.Type getTypeOfTestClass()
        {
            return typeof(GetProviderCreditDetailsRequest);
        }

        [Test]
        public void GetProviderCreditDetailsRequestNullOrEmptyTest()
        {
            TestNullorEmpty();
        }
        
        [Test]
        public void GetProviderCreditDetailsRequestSchemaTest()
        {
            TestSchema();
        }
    }
}

