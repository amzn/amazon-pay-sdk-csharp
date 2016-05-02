using System;
using System.IO;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OffAmazonPaymentsNotifications;

namespace OffAmazonPaymentsNotificationsTest
{
    [TestFixture]
    class RefundNotificationTest : NotificationTest<RefundNotification>
    {
        public RefundNotificationTest() : base ("RefundNotification")
        {
        }

        [Test]
        public void RefundNotificationValidTest()
        {
            Parser(@"..\..\Xml\RefundNotificationValid.xml");
        }

        [Test]
        public void RefundNotificationWithAdditionalElementsValidTest()
        {
            Parser(@"..\..\Xml\RefundNotificationWithAdditionalElementsValid.xml");
        }

        [Test]
        public void RefundNotificationWithMissingMandatoryFieldsTest()
        {
            Parser(@"..\..\Xml\RefundNotificationWithMissingMandatoryFields.xml");
        }

    }
}
