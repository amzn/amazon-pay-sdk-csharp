using System;
using System.IO;
using System.Xml;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using NUnit.Framework;
using OffAmazonPaymentsService.Model;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class GetAuthorizationDetailsResponseTest : ModelTest
    {
        protected override String getXmlTestFile()
        {
            return @"..\..\xml\GetAuthorizationDetailsResponse.xml";
        }

        protected override System.Type getTypeOfTestClass()
        {
            return typeof(GetAuthorizationDetailsResponse);
        }

        [Test]
        public void GetAuthorizationDetailsResponseNullOrEmptyTest()
        {
            TestNullorEmpty();
        }

        [Test]
        public void GetAuthorizationDetailsResponseSchemaTest()
        {
            TestSchema();
        }

    }
}
