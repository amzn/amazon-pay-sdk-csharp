using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class GetCaptureDetailsResponseTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\GetCaptureDetailsResponse.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(GetCaptureDetailsResponse);
        }

        [Test]
        public void GetCaptureDetailsResponseNullOrEmptyTest()
        {
            TestNullorEmpty();
        }

        [Test]
        public void GetCaptureDetailsResponseSchemaTest()
        {
            TestSchema();
        }
    }
}

