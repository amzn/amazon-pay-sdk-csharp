using System;
using System.Collections.Generic;
using System.Text;
using OffAmazonPaymentsService.Model;
using NUnit.Framework;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class SetOrderReferenceDetailsRequestTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\SetOrderReferenceDetailsRequest.xml";
        }
        
        protected override System.Type getTypeOfTestClass()
        {
            return typeof(SetOrderReferenceDetailsRequest);
        }
        
        [Test]
        public void SetOrderReferenceDetailsRequestNullOrEmptyTest()
        {
            TestNullorEmpty();
        }
        
        [Test]
        public void SetOrderReferenceDetailsRequestSchemaTest()
        {
            TestSchema();
        }
    }
}

