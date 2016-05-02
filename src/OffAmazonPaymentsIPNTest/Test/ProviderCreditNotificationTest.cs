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
    class ProviderCreditNotificationTest : NotificationTest<ProviderCreditNotification>
    {
        public ProviderCreditNotificationTest()
            : base("ProviderCreditNotification")
        {
        }

        [Test]
        public void ProviderCreditNotificationValidTest()
        {
            Parser(@"..\..\Xml\ProviderCreditNotificationValid.xml");
        }

        [Test]
        public void ProviderCreditNotificationWithAdditionalElementsValidTest()
        {
            Parser(@"..\..\Xml\ProviderCreditNotificationWithAdditionalElementsValid.xml");
        }

        [Test]
        public void ProviderCreditNotificationWithMissingMandatoryFieldsTest()
        {
            Parser(@"..\..\Xml\ProviderCreditNotificationWithMissingMandatoryFields.xml");
        }

    }
}
