using NUnit.Framework;
using OffAmazonPaymentsNotifications;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace OffAmazonPaymentsNotificationsTest.NotificationMetadata
{
    [TestFixture]
    class SnsNotificationMetadataTest
    {
        [Test]
        public void ShouldCreateSnsNotificationMetadataFromValidSnsMessage()
        {
            // Given
            string expectedTopicArn = "arn:aws:sns:us-east-1:598607868003:A341L3VCFKNMIYA074997131C7YZGL81KKR";
            string expectedMessageId = "ad26db82-463d-536f-963c-927c067afb7d";

            Message msg = GetMessageFromFields(expectedTopicArn, expectedMessageId);

            // When
            SnsNotificationMetadata notificationMetadata = new SnsNotificationMetadata(msg);

            // Then
            Assert.AreEqual(NotificationMetadataType.Sns, notificationMetadata.NotificationMetadataType);
            Assert.AreEqual(expectedTopicArn, notificationMetadata.TopicArn);
            Assert.AreEqual(expectedMessageId, notificationMetadata.MessageId);
        }

        [Test]
        public void ShoulParseTimestampIntoDateTime()
        {
            // Given
            string expectedTimestamp = "2013-05-03T22:45:27.265Z";
            DateTime expectedDtTimestamp = DateTime.ParseExact(expectedTimestamp, @"yyyy-MM-ddTHH:mm:ss.fffZ", CultureInfo.InvariantCulture, DateTimeStyles.AdjustToUniversal);
            Message msg = GetMessageFromFields(expectedTimestamp, "sdfsdf", "dsfdsf");
            
            // When
            SnsNotificationMetadata notificationMetadata = new SnsNotificationMetadata(msg);

            // Then
            Assert.AreEqual(expectedDtTimestamp, notificationMetadata.Timestamp);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Error with message - mandatory field Timestamp cannot be found")]
        public void ShouldThrowExceptionIfIpnMessageDoesNotHaveTimestampField()
        {
            ShouldThrowExceptionWhenMandatoryFieldIsNotPresent("Timestamp");
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Error with message - mandatory field TopicArn cannot be found")]
        public void ShouldThrowExceptionIfIpnMessageDoesNotHaveTopicArnField()
        {
            ShouldThrowExceptionWhenMandatoryFieldIsNotPresent("TopicArn");
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Error with message - mandatory field MessageId cannot be found")]
        public void ShouldThrowExceptionIfIpnMessageDoesNotHaveMessageIdField()
        {
            ShouldThrowExceptionWhenMandatoryFieldIsNotPresent("MessageId");
        }

        private void ShouldThrowExceptionWhenMandatoryFieldIsNotPresent(string field)
        {
            // given
            IDictionary<string, string> fields = GetFixutureFieldsAsDictionary();
            fields.Remove(field);
            Message msg = Utilities.ConvertDictionaryToMessage(fields);

            // when
            new SnsNotificationMetadata(msg);
        }

        private static IDictionary<string, string> GetFixutureFieldsAsDictionary()
        {
            return GetFieldsAsDictionary("2013-05-03T10:45:27Z", "fdsfdsc", "3dfsdf83434-34248390-3423");
        }

        private Message GetMessageFromFields(string expectedTimestamp, string expectedTopicArn, string expectedMessageId)
        {
            IDictionary<string, string> values = GetFieldsAsDictionary(expectedTimestamp, expectedTopicArn, expectedMessageId);
            return Utilities.ConvertDictionaryToMessage(values);
        }

        private static IDictionary<string, string> GetFieldsAsDictionary(string expectedTimestamp, string expectedTopicArn, string expectedMessageId)
        {
            IDictionary<string, string> values = new Dictionary<string, string>();
            values.Add("TopicArn", expectedTopicArn);
            values.Add("MessageId", expectedMessageId);
            values.Add("Timestamp", expectedTimestamp);
            return values;
        }

        private Message GetMessageFromFields(string expectedTopicArn, string expectedMessageId)
        {
            return GetMessageFromFields("2013-05-03T22:45:27.265Z", expectedTopicArn, expectedMessageId);
        }
    }
}
