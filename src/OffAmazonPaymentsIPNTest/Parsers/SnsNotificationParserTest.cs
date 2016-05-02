using NUnit.Framework;
using OffAmazonPaymentsNotifications;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;

namespace OffAmazonPaymentsNotificationsTest.Parsers
{
    [TestFixture]
    class SnsNotificationParserTest
    {
        [Test]
        public void ShouldCreateMessageForValidSnsJsonString()
        {
            // Given
            string expectedMessage = "value";
            string expectedType = "Notification";
            string snsJson = GetMessageForFields(expectedMessage, expectedType);

            // When
            Message msg = SnsNotificationParser.ParseNotification(Utilities.GetSnsHeaderFields(), snsJson);

            // Then
            Assert.AreEqual(expectedMessage, msg.GetMandatoryField("Message"));
            Assert.AreEqual(expectedType, msg.GetMandatoryField("Type"));
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Error with message - mandatory field Type cannot be found")]
        public void ShouldThrowExceptionIfTypeFieldCannotBeFound()
        {
            // Given
            IDictionary<string, string> fields = GetDefaultFields();
            fields.Remove("Type");
            string jsonString = Utilities.ConvertDictionaryToJsonString(fields);
            
            // When
            SnsNotificationParser.ParseNotification(Utilities.GetSnsHeaderFields(), jsonString);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Error with sns notification - unexpected message with Type of test")]
        public void ShouldThrowExceptionIfTypeIsNotNotification()
        {
            // Given
            string snsJson = GetMessageForFields("test", "test");
            
            // When
            SnsNotificationParser.ParseNotification(Utilities.GetSnsHeaderFields(), snsJson);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Error with message - header does not contain x-amz-sns-message-type")]
        public void ShouldThrowExceptionIfSnsHeaderIsNotPresent()
        {
            // Given
            string snsJson = GetMessageForDefaultFields();
            NameValueCollection headers = Utilities.GetSnsHeaderFields();
            headers.Remove("x-amz-sns-message-type");

            // When
            SnsNotificationParser.ParseNotification(headers, snsJson);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Error with sns message - header x-amz-sns-message-type has value test, expected Notification")]
        public void ShouldThrowExceptionIfSnsHeaderIsNotEqualToNotification()
        {
            // Given
            string snsJson = GetMessageForDefaultFields();
            NameValueCollection headers = Utilities.GetSnsHeaderFields();
            headers.Remove("x-amz-sns-message-type");
            headers.Add("x-amz-sns-message-type", "test");

            // When
            SnsNotificationParser.ParseNotification(headers, snsJson);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Expected headers to be passed, null value received")]
        public void ShouldThrowExceptionIfNoHeadersAreProvided()
        {
            // Given
            string snsJson = GetMessageForDefaultFields();

            // When
            SnsNotificationParser.ParseNotification(null, snsJson);
        }

        [Test]
        public void ShouldAddSnsMetadataToMessage()
        {
            // Given
            string snsJson = GetMessageForDefaultFields();

            // When
            Message msg = SnsNotificationParser.ParseNotification(Utilities.GetSnsHeaderFields(), snsJson);

            // Then
            Assert.NotNull(msg.Metadata);
        }

        private string GetMessageForFields(string expectedMessage, string type)
        {
            return Utilities.ConvertDictionaryToJsonString(GetDictionaryForFields(expectedMessage, type));
        }

        private string GetMessageForDefaultFields()
        {
            return Utilities.ConvertDictionaryToJsonString(GetDefaultFields());
        }

        private IDictionary<string, string> GetDefaultFields()
        {
            return GetDictionaryForFields("test", "Notification");
        }

        private IDictionary<string, string> GetDictionaryForFields(string expectedMessage, string expectedType)
        {
            IDictionary<string, string> fields = new Dictionary<string, string>();
            fields.Add("Message", expectedMessage);
            fields.Add("Type", expectedType);
            fields.Add("Timestamp", "2013-05-03T10:45:27Z");
            fields.Add("TopicArn", "arn:aws:sns:us-east-1:598607868003:A341L3VCFKNMIYA074997131C7YZGL81KKR");
            fields.Add("MessageId", "ad26db82-463d-536f-963c-927c067afb7d");
            return fields;
        }
    }
}