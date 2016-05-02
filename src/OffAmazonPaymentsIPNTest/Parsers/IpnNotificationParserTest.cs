using Newtonsoft.Json.Linq;
using NUnit.Framework;
using OffAmazonPaymentsNotifications;
using System.Collections.Generic;

namespace OffAmazonPaymentsNotificationsTest.Parsers
{
    [TestFixture]
    class IpnNotificationParserTest
    {
        [Test]
        public void ShouldReturnMessgeFromIpnJsonString()
        {
            // given
            string expectedReleaseEnvironmentProperty = "sandbox";
            string expectedTimestamp = "2013-05-03T10:45:27Z";
            string expectedNotificationReferenceId = "dfdfd343434ddsfs";

            Message snsMessage = CreateValidSnsMessage(expectedReleaseEnvironmentProperty, expectedTimestamp, expectedNotificationReferenceId);

            // when
            Message message = IpnNotificationParser.ParseSnsMessage(snsMessage);

            // then
            Assert.AreEqual(expectedReleaseEnvironmentProperty, message.GetMandatoryField("ReleaseEnvironment"));
            Assert.AreEqual(expectedTimestamp, message.GetMandatoryFieldAsDateTime("Timestamp").ToUniversalTime().ToString(@"yyyy-MM-ddTHH:mm:ssZ"));
            Assert.AreEqual(expectedNotificationReferenceId, message.GetMandatoryField("NotificationReferenceId"));
        }

        [Test]
        public void ShouldSetMetadataNotificationParentToSnsMetadataObject()
        {
            // given
            INotificationMetadata expectedMetadata = Utilities.CreateTestSnsNotificationMetadata();
            Message snsMessage = CreateValidSnsMessage("release","2013-05-03T10:45:27Z", "dfsfdsfdsfdfd");
            snsMessage.Metadata = expectedMetadata;
            
            // when
            Message message = IpnNotificationParser.ParseSnsMessage(snsMessage);

            // then
            Assert.AreSame(expectedMetadata, message.Metadata.ParentNotificationMetadata);
        }

        private static Message CreateValidSnsMessage(string expectedReleaseEnvironmentProperty, string expectedTimestamp, string expectedNotificationReferenceId)
        {
            IDictionary<string, string> ipnProperties = new Dictionary<string, string>();
            ipnProperties.Add("ReleaseEnvironment", expectedReleaseEnvironmentProperty);
            ipnProperties.Add("Timestamp", expectedTimestamp);
            ipnProperties.Add("NotificationReferenceId", expectedNotificationReferenceId);
            ipnProperties.Add("NotificationData", "Test");

            IDictionary<string, string> snsProperties = new Dictionary<string, string>();
            snsProperties.Add("Message", Utilities.ConvertDictionaryToJsonString(ipnProperties));
            Message snsMessage = Utilities.ConvertDictionaryToMessage(snsProperties);
            return snsMessage;
        }
    }
}
