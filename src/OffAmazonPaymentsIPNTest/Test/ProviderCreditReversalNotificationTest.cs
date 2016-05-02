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
    class ProviderCreditReversalNotificationTest : NotificationTest<ProviderCreditReversalNotification>
    {
        public ProviderCreditReversalNotificationTest()
            : base("ProviderCreditReversalNotification")
        {
        }

        [Test]
        public void ProviderCreditReversalNotificationValidTest()
        {
            Parser(@"..\..\Xml\ProviderCreditReversalNotificationValid.xml");
        }

        [Test]
        public void ProviderCreditReversalNotificationWithAdditionalElementsValidTest()
        {
            Parser(@"..\..\Xml\ProviderCreditReversalNotificationWithAdditionalElementsValid.xml");
        }

        [Test]
        public void ProviderCreditReversalNotificationWithMissingMandatoryFieldsTest()
        {
            Parser(@"..\..\Xml\ProviderCreditReversalNotificationWithMissingMandatoryFields.xml");
        }

    }
}
