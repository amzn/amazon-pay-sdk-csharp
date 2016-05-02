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
    class CaptureNotificationTest : NotificationTest<CaptureNotification>
    {
        public CaptureNotificationTest()
            : base("CaptureNotification")
        {
        }

        [Test]
        public void CaptureNotificationValidTest()
        {
            Parser(@"..\..\Xml\CaptureNotificationValid.xml");
        }

        [Test]
        public void CaptureNotificationWithAdditionalElementsValidTest()
        {
            Parser(@"..\..\Xml\CaptureNotificationWithAdditionalElementsValid.xml");
        }

        [Test]
        public void CaptureNotificationWithMissingMandatoryFieldsTest()
        {
            Parser(@"..\..\Xml\CaptureNotificationWithMissingMandatoryFields.xml");
        }

    }
}
