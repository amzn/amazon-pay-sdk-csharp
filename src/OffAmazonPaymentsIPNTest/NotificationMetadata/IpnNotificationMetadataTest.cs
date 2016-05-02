using NUnit.Framework;
using OffAmazonPaymentsNotifications;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace OffAmazonPaymentsNotificationsTest.NotificationMetadata
{
    [TestFixture]
    class IpnNotificationMetadataTest
    {
        [Test]
        public void ShouldCreateIpnNotificationMetadataForValidIpnMessage()
        {
            // given
            string expectedReleaseEnvironment = "sandbox";
            string expectedNotificationReferenceId = "33dsfsdf343-3434-3434";

            Message ipnMsg = _CreateNotificationReferenceMessage(expectedReleaseEnvironment, expectedNotificationReferenceId);

            // when
            IpnNotificationMetadata ipnNotificationMetadata = new IpnNotificationMetadata(ipnMsg, null);

            // then
            Assert.AreEqual(expectedReleaseEnvironment, ipnNotificationMetadata.ReleaseEnvironment);
            Assert.AreEqual(expectedNotificationReferenceId, ipnNotificationMetadata.NotificationReferenceId);
            Assert.AreEqual(NotificationMetadataType.Ipn, ipnNotificationMetadata.NotificationMetadataType);
        }

        [Test]
        public void ShouldCreateParseTimestampIntoDateTime()
        {
            // given
            string timestamp = "2013-05-03T10:45:27Z";
            DateTime expectedTimestamp = DateTime.ParseExact(timestamp,  @"yyyy-MM-ddTHH:mm:ssZ", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);

            Message ipnMsg = CreateNotificationReferenceMessage("sandbox", "33dsfsdf343-3434-3434", timestamp);

            // when
            IpnNotificationMetadata ipnNotificationMetadata = new IpnNotificationMetadata(ipnMsg, null);

            // then
            Assert.AreEqual(expectedTimestamp, ipnNotificationMetadata.Timestamp);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Error with message - mandatory field Timestamp cannot be found")]
        public void ShouldThrowExceptionIfIpnMessageDoesNotHaveTimestampField()
        {
            ShouldThrowExceptionWhenMandatoryFieldIsNotPresent("Timestamp");
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Error with message - mandatory field ReleaseEnvironment cannot be found")]
        public void ShouldThrowExceptionIfIpnMessageDoesNotHaveReleaseEnvironmentField()
        {
            ShouldThrowExceptionWhenMandatoryFieldIsNotPresent("ReleaseEnvironment");
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Error with message - mandatory field NotificationReferenceId cannot be found")]
        public void ShouldThrowExceptionIfIpnMessageDoesNotHaveNotificationReferenceIdField()
        {
            ShouldThrowExceptionWhenMandatoryFieldIsNotPresent("NotificationReferenceId");
        }

        private void ShouldThrowExceptionWhenMandatoryFieldIsNotPresent(string field)
        {
            // given
            IDictionary<string, string> fields = GetFixutureFieldsAsDictionary();
            fields.Remove(field);
            Message msg = Utilities.ConvertDictionaryToMessage(fields);

            // when
            new IpnNotificationMetadata(msg, null);
        }

        private static Message _CreateNotificationReferenceMessage(string expectedReleaseEnvironment, string expectedNotificationReferenceId)
        {
            return CreateNotificationReferenceMessage(expectedReleaseEnvironment, expectedNotificationReferenceId, "2013-05-03T10:45:27Z");
        }

        private static Message CreateNotificationReferenceMessage(string expectedReleaseEnvironment, string expectedNotificationReferenceId, string expectedTimestamp)
        {
            IDictionary<string, string> values = GetFieldsAsDictionary(expectedReleaseEnvironment, expectedNotificationReferenceId, expectedTimestamp);
            return Utilities.ConvertDictionaryToMessage(values);
        }

        private static IDictionary<string, string> GetFixutureFieldsAsDictionary()
        {
            return GetFieldsAsDictionary("sandbox", "3dfsdf83434-34248390-3423", "2013-05-03T10:45:27Z");
        }

        private static IDictionary<string, string> GetFieldsAsDictionary(string expectedReleaseEnvironment, string expectedNotificationReferenceId, string expectedTimestamp)
        {
            IDictionary<string, string> values = new Dictionary<string, string>();
            values.Add("Timestamp", expectedTimestamp);
            values.Add("ReleaseEnvironment", expectedReleaseEnvironment);
            values.Add("NotificationReferenceId", expectedNotificationReferenceId);
            return values;
        }
    }
}
