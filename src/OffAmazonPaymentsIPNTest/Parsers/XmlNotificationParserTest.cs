using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OffAmazonPaymentsNotifications;
using System;

namespace OffAmazonPaymentsNotificationsTest.Parsers
{
    [TestFixture]
    class XmlNotificationParserTest
    {
        [TestCase("PaymentRefund", "RefundNotification", typeof(RefundNotification), NotificationType.RefundNotification)]
        [TestCase("PaymentAuthorize", "AuthorizationNotification", typeof(AuthorizationNotification), NotificationType.AuthorizationNotification)]
        [TestCase("PaymentCapture", "CaptureNotification", typeof(CaptureNotification), NotificationType.CaptureNotification)]
        [TestCase("ProviderCredit", "ProviderCreditNotification", typeof(ProviderCreditNotification), NotificationType.ProviderCreditNotification)]
        [TestCase("ProviderCreditReversal", "ProviderCreditReversalNotification", typeof(ProviderCreditReversalNotification), NotificationType.ProviderCreditReversalNotification)]
        [TestCase("OrderReferenceNotification", "OrderReferenceNotification", typeof(OrderReferenceNotification), NotificationType.OrderReferenceNotification)]
        [TestCase("BillingAgreementNotification", "BillingAgreementNotification", typeof(BillingAgreementNotification), NotificationType.BillingAgreementNotification)]
        [TestCase("SolutionProviderEvent", "SolutionProviderMerchantNotification", typeof(SolutionProviderMerchantNotification), NotificationType.SolutionProviderMerchantNotification)]
        public void ShouldMapNotificationTypeToCorrectNotificationObject(string xmlNotificationType, string xmlNodeName,
            Type expectedInstanceClass, NotificationType expectedNotificationType)
        {
            // given
            JObject ipnJson = new JObject(
                                new JProperty("NotificationType", xmlNotificationType),
                                new JProperty("NotificationData", String.Format("<{0}></{0}>", xmlNodeName)));

            Message ipnMessage = new Message(ipnJson.ToString());

            // when
            INotification actualNotification = XmlNotificationParser.ParseIpnMessage(ipnMessage);

            // then
            Assert.IsInstanceOf(expectedInstanceClass, actualNotification);
            Assert.AreEqual(expectedNotificationType, actualNotification.NotificationType);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Error with ipn message - NotificationData field does not contain valid xml, contents: test")]
        public void ShouldThrowExceptionIfNotificationDataFieldIsNotXml()
        {
            // given
            JObject ipnJson = new JObject(
                                new JProperty("NotificationType", "PaymentRefund"),
                                new JProperty("NotificationData", "test"));

            Message ipnMessage = new Message(ipnJson.ToString());

            // when
            XmlNotificationParser.ParseIpnMessage(ipnMessage);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Error with message - mandatory field NotificationData cannot be found")]
        public void ShouldThrowExceptionIfNotificationDataFieldIsNotPresentInIpnMessage()
        {
            // given
            JObject ipnJson = new JObject(
                                new JProperty("NotificationType", "PaymentRefund"));

            Message ipnMessage = new Message(ipnJson.ToString());

            // when
            XmlNotificationParser.ParseIpnMessage(ipnMessage);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Error with message - mandatory field NotificationType cannot be found")]
        public void ShouldThrowExceptionIfNotificationTypeFieldIsNotPresentInIpnMessage()
        {
            // given
            JObject ipnJson = new JObject(
                                new JProperty("NotificationData", "<test></test>"));

            Message ipnMessage = new Message(ipnJson.ToString());

            // when
            XmlNotificationParser.ParseIpnMessage(ipnMessage);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Error with ipn notification - unknown notification type: Sample")]
        public void ShouldThrowExceptionIfNotificationTypeFieldIsNotKnownInIpnMessage()
        {
            // given
            JObject ipnJson = new JObject(
                                new JProperty("NotificationType", "Sample"),
                                new JProperty("NotificationData", "test"));

            Message ipnMessage = new Message(ipnJson.ToString());

            // when
            XmlNotificationParser.ParseIpnMessage(ipnMessage);
        }
    }
}
