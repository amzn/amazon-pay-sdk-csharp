using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class RefundResponseTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\RefundResponse.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(RefundResponse);
        }
        
        [Test]
        public void RefundResponseNullOrEmptyTest()
        {
            TestNullorEmpty();
        }

        [Test]
        public void RefundResponseSchemaTest()
        {
            TestSchema();
        }
    }
}

