using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using NUnit.Framework;
using OffAmazonPaymentsNotifications;

namespace OffAmazonPaymentsNotificationsTest
{
    [TestFixture]
    class AuthorizationNotificationTest : NotificationTest<AuthorizationNotification>
    {
        public AuthorizationNotificationTest() : base("AuthorizationNotification") { }

        [Test]
        public void AuthorizationNotificationValidTest()
        {
            Parser(@"..\..\Xml\AuthorizationNotificationValid.xml");
        }

        [Test]
        public void AuthorizationNotificationWithAdditionalElementsValidTest()
        {
            Parser(@"..\..\Xml\AuthorizationNotificationWithAdditionalElementsValid.xml");
        }

        [Test]
        public void AuthorizationNotificationWithMissingMandatoryFieldsTest()
        {
            Parser(@"..\..\Xml\AuthorizationNotificationWithMissingMandatoryFields.xml");
        }

       
    }



}
