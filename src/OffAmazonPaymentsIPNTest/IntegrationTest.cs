using NUnit.Framework;
using OffAmazonPaymentsNotifications;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Configuration;

namespace OffAmazonPaymentsNotificationsTest
{
    [TestFixture]
    class IntegrationTest
    {
        [SetUp]
        public void SetUp()
        {
            Utilities.SetupConfigForTest();
        }

        // NOTE: These integration tests will eventually start failing once the certificate from these notifications becomes expired.
        // To fix, you will need to generate new IPNs of each type.  The IPN Testing Tool in PyOP SC Sandbox is useful for generating the basic IPNs.
        [TestCase("notificationAuthorize", NotificationType.AuthorizationNotification)]
        [TestCase("notificationCapture", NotificationType.CaptureNotification)]
        [TestCase("notificationOrderReference", NotificationType.OrderReferenceNotification)]
        [TestCase("notificationRefund", NotificationType.RefundNotification)]
        [TestCase("notificationBillingAgreement", NotificationType.BillingAgreementNotification)]
        [TestCase("notificationProviderCredit", NotificationType.ProviderCreditNotification)]
        [TestCase("notificationProviderCreditReversal", NotificationType.ProviderCreditReversalNotification)]
        [TestCase("notificationSolutionProviderEvent", NotificationType.SolutionProviderMerchantNotification)]
        public void ShouldHandleTypedNotification(string jsonFileName, NotificationType expectedNotifcationType)
        {
            // given
            string httpPostContent = File.ReadAllText(String.Format("..\\..\\Json\\{0}.json", jsonFileName));
            NameValueCollection headers = new NameValueCollection();
            headers.Add("x-amz-sns-message-type", "Notification");

            // when
            INotification notification = new NotificationsParser().ParseRawMessage(headers, httpPostContent);

            // then
            Assert.IsNotNull(notification);
            Assert.AreEqual(notification.NotificationType, expectedNotifcationType);
        }
    }
}
