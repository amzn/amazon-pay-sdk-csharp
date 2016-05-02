using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class GetRefundDetailsRequestTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\GetRefundDetailsRequest.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(GetRefundDetailsRequest);
        }
        
        [Test]
        public void GetRefundDetailsRequestNullOrEmptyTest()
        {
            TestNullorEmpty();
        }
        
        [Test]
        public void GetRefundDetailsRequestSchemaTest()
        {
            TestSchema();
        }
    }
}

