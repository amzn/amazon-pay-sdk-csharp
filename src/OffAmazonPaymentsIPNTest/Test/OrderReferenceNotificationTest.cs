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
    class OrderReferenceNotificationTest : NotificationTest<OrderReferenceNotification>
    {
        public OrderReferenceNotificationTest()
            : base("OrderReferenceNotification")
        {
        }

        [Test]
        public void ORONotificationValidTest()
        {
            Parser(@"..\..\Xml\ORONotificationValid.xml");
        }

        [Test]
        public void ORONotificationWithAdditionalElementsValidTest()
        {
            Parser(@"..\..\Xml\ORONotificationWithAdditionalElementsValid.xml");
        }

        [Test]
        public void ORONotificationWithMissingMandatoryFieldsTest()
        {
            Parser(@"..\..\Xml\ORONotificationWithMissingMandatoryFields.xml");
        }

    }
}
