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
    class SolutionProviderMerchantNotificationTest : NotificationTest<SolutionProviderMerchantNotification>
    {
        public SolutionProviderMerchantNotificationTest()
            : base("SolutionProviderMerchantNotification")
        {
        }

        [Test]
        public void SolutionProviderMerchantNotificationValidTest()
        {
            Parser(@"..\..\Xml\SolutionProviderMerchantNotificationValid.xml");
        }

        [Test]
        public void SolutionProviderMerchantNotificationWithAdditionalElementsValidTest()
        {
            Parser(@"..\..\Xml\SolutionProviderMerchantNotificationWithAdditionalElementsValid.xml");
        }

        [Test]
        public void SolutionProviderMerchantNotificationWithMissingMandatoryFieldsTest()
        {
            Parser(@"..\..\Xml\SolutionProviderMerchantNotificationWithMissingMandatoryFields.xml");
        }

    }
}
