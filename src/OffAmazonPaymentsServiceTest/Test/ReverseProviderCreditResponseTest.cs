using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class ReverseProviderCreditResponseTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\ReverseProviderCreditResponse.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(ReverseProviderCreditResponse);
        }
        
        [Test]
        public void ReverseProviderCreditResponseNullOrEmptyTest()
        {
            TestNullorEmpty();
        }

        [Test]
        public void ReverseProviderCreditResponseSchemaTest()
        {
            TestSchema();
        }
    }
}

