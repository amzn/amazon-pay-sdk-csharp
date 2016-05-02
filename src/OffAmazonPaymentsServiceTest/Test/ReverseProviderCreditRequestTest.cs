using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class ReverseProviderCreditRequestTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\ReverseProviderCreditRequest.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(ReverseProviderCreditRequest);
        }

        [Test]
        public void ReverseProviderCreditRequestNullOrEmptyTest()
        {
            TestNullorEmpty();
        }

        [Test]
        public void ReverseProviderCreditRequestSchemaTest()
        {
            TestSchema();
        }
    }
}

