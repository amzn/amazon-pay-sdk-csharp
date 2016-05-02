using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class GetCaptureDetailsRequestTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\GetCaptureDetailsRequest.xml";
        }
        
        protected override System.Type getTypeOfTestClass()
        {
            return typeof(GetCaptureDetailsRequest);
        }

        [Test]
        public void GetCaptureDetailsRequestNullOrEmptyTest()
        {
            TestNullorEmpty();
        }
        
        [Test]
        public void GetCaptureDetailsRequestSchemaTest()
        {
            TestSchema();
        }
    }
}

