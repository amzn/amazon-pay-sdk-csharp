using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class GetProviderCreditReversalDetailsRequestTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\GetProviderCreditReversalDetailsRequest.xml";
        }
        
        protected override System.Type getTypeOfTestClass()
        {
            return typeof(GetProviderCreditReversalDetailsRequest);
        }

        [Test]
        public void GetProviderCreditReversalDetailsRequestNullOrEmptyTest()
        {
            TestNullorEmpty();
        }
        
        [Test]
        public void GetProviderCreditReversalDetailsRequestSchemaTest()
        {
            TestSchema();
        }
    }
}

