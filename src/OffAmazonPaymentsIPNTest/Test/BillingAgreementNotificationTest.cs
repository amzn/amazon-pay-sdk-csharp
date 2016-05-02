using NUnit.Framework;
using OffAmazonPaymentsNotifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace OffAmazonPaymentsNotificationsTest
{
    [TestFixture]
    class BillingAgreementNotificationTest : NotificationTest<BillingAgreementNotification>
    {
        public BillingAgreementNotificationTest()
            : base("BillingAgreementNotification")
        {
        }

        [Test]
        public void BillingAgreementNotificationValidTest()
        {
            Parser(@"..\..\Xml\BillingAgreementNotificationValid.xml");
        }

        [Test]
        public void BillingAgreementNotificationWithAdditionalElementsValidTest()
        {
            Parser(@"..\..\Xml\BillingAgreementNotificationWithAdditionalElementsValid.xml");
        }

        [Test]
        public void BillingAgreementNotificationWithMissingMandatoryFieldsTest()
        {
            Parser(@"..\..\Xml\BillingAgreementNotificationWithMissingMandatoryFields.xml");
        }
    }
}
