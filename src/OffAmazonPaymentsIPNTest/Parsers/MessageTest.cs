using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OffAmazonPaymentsNotifications;
using System;
using System.Collections.Generic;
using System.Text;

namespace OffAmazonPaymentsNotificationsTest
{
    [TestFixture]
    class MessageTest
    {
        [Test]
        public void ShouldCreateNewInstanceOfClassForValidJson()
        {
            // given
            string jsonString = new JObject(new JProperty("Field", "Value")).ToString();

            // when
            Message msg = new Message(jsonString);

            // then
            Assert.IsNotNull(msg);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Error with message - content is not in json format")]
        public void ShouldThrowAnExceptionIfTheStringIsNotJson()
        {
            // given
            string invalidJson = "test:value";

            // when
            new Message(invalidJson);
        }

        [Test]
        public void ShouldReturnDestringifiedFieldValueIfMandatoryFieldExists()
        {
            // given
            string expectedValue = "\"test\'\"\\n";
            string jsonString = new JObject(new JProperty("Field", expectedValue)).ToString();

            // when
            Message msg = new Message(jsonString);
            string actualValue = msg.GetMandatoryField("Field");

            // then
            Assert.AreEqual(expectedValue, actualValue);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Error with message - mandatory field Field cannot be found")]
        public void ShouldThrowExceptionIfMandatoryFieldCannotBeFound()
        {
            // given
            string jsonString = new JObject(new JProperty("Test", "field")).ToString();

            // when
            Message msg = new Message(jsonString);
            msg.GetMandatoryField("Field");
        }

        [Test]
        public void ShouldReturnFieldAsDateTimeObject()
        {
            // given
            string expectedTimestamp = "2013-05-03T10:45:27.342Z";
            string jsonString = new JObject(new JProperty("Timestamp", expectedTimestamp)).ToString();

            // when
            Message msg = new Message(jsonString);
            DateTime val = msg.GetMandatoryFieldAsDateTime("Timestamp");

            // then
            Assert.AreEqual(expectedTimestamp, val.ToString(@"yyyy-MM-ddTHH:mm:ss.fffZ"));
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Error with message - expected field Timestamp to be DateTime object")]
        public void ShouldThrowExceptionIfDateTimeFieldCannotBeCast()
        {
            // given
            string expectedTimestamp = "value";
            string jsonString = new JObject(new JProperty("Timestamp", expectedTimestamp)).ToString();

            // when
            Message msg = new Message(jsonString);
            msg.GetMandatoryFieldAsDateTime("Timestamp");
        }
    }
}
