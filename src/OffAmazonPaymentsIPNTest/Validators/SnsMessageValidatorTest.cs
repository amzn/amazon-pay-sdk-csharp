using System;
using System.IO;
using NUnit.Framework;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using System.Configuration;
using OffAmazonPaymentsNotifications;
using System.Net;
using NMock2;

namespace OffAmazonPaymentsNotificationsTest
{
    [TestFixture]
    class SnsMessageValidatorTest
    {
        // class under test
        private SnsMessageValidator _messageValidator;

        private ISnsSignatureVerification _mockValidator;

        private Mockery _mocks;

        [SetUp]
        public void SetUp()
        {
            this._mocks = new Mockery();
            this._mockValidator = this._mocks.NewMock<ISnsSignatureVerification>();
            this._messageValidator = new SnsMessageValidator(this._mockValidator);
        }

        [Test]
        public void ShouldValidateMessageIfSignaturVersionIsOne()
        {
            // Given
            IDictionary<string, string> snsMsgFields = new Dictionary<string, string>();
            snsMsgFields.Add("SignatureVersion", "1");
            Message snsMessage = Utilities.ConvertDictionaryToMessage(snsMsgFields);

            using (this._mocks.Ordered)
            {
                Expect.Once.On(this._mockValidator).Method("VerifyMsgMatchesSignatureV1WithCert").With(snsMessage).Will(Return.Value(true));
            }

            // When
            this._messageValidator.ValidateMessageIsTrusted(snsMessage);

            // Then
            this._mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Error with sns message verification - message is signed with unknown signature specification 2")]
        public void ShouldThrowExceptionIfSignatureVersionIsNotV1()
        {
            // Given
            IDictionary<string, string> snsMsgFields = new Dictionary<string, string>();
            snsMsgFields.Add("SignatureVersion", "2");
            Message snsMessage = Utilities.ConvertDictionaryToMessage(snsMsgFields);

            // When
            this._messageValidator.ValidateMessageIsTrusted(snsMessage);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Error with message - mandatory field SignatureVersion cannot be found")]
        public void ShouldThrowExceptionIfSignatureVersionFieldIsMissing()
        {
            // Given
            IDictionary<string, string> snsMsgFields = new Dictionary<string, string>();
            Message snsMessage = Utilities.ConvertDictionaryToMessage(snsMsgFields);

            // When
            this._messageValidator.ValidateMessageIsTrusted(snsMessage);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Signing certificate url is not from a recognised source.")]
        public void ShouldThrowExceptionIfCertificateURLIsNotValid()
        {
            IDictionary<string, string> snsMsgFields = new Dictionary<string, string>();
            snsMsgFields["SigningCertURL"] = "https://sns.us-east-1.example.com/SimpleNotificationService-bb750dd426d95ee9390147a5624348ee.pem";
            Message snsMessage = Utilities.ConvertDictionaryToMessage(snsMsgFields);
            this._messageValidator.ValidateCertUrl(snsMessage);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Signing certificate url is not from a recognised source.")]
        public void ShouldThrowExceptionIfCertificateURLHasHttp()
        {
            IDictionary<string, string> snsMsgFields = new Dictionary<string, string>();
            snsMsgFields["SigningCertURL"] = "http://sns.us-east-1.amazon.com/SimpleNotificationService-bb750dd426d95ee9390147a5624348ee.pem";
            Message snsMessage = Utilities.ConvertDictionaryToMessage(snsMsgFields);
            this._messageValidator.ValidateCertUrl(snsMessage);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Signing certificate url is not from a recognised source.")]
        public void ShouldThrowExceptionIfCertificateURLHasAtleastThreeChars()
        {
            IDictionary<string, string> snsMsgFields = new Dictionary<string, string>();
            snsMsgFields["SigningCertURL"] = "https://sns.us-east-1.amazonaws.com/SimpleNotificationService-bb750dd426d95ee9390147a5624348ee.exe";
            Message snsMessage = Utilities.ConvertDictionaryToMessage(snsMsgFields);
            this._messageValidator.ValidateCertUrl(snsMessage);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Signing certificate url is not from a recognised source.")]
        public void ShouldThrowExceptionIfCertificateURLHasSni()
        {
            IDictionary<string, string> snsMsgFields = new Dictionary<string, string>();
            snsMsgFields["SigningCertURL"] = "https://sni.us-east-1.amazonaws.com/SimpleNotificationService-bb750dd426d95ee9390147a5624348ee.pem";
            Message snsMessage = Utilities.ConvertDictionaryToMessage(snsMsgFields);
            this._messageValidator.ValidateCertUrl(snsMessage);
        }
        
        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Signing certificate url is not from a recognised source.")]
        public void ShouldThrowExceptionIfCertificateURLHasImproperDomain()
        {
            IDictionary<string, string> snsMsgFields = new Dictionary<string, string>();
            snsMsgFields["SigningCertURL"] = "https://sns.us.amazonaws.com/SimpleNotificationService-bb750dd426d95ee9390147a5624348ee.pem";
            Message snsMessage = Utilities.ConvertDictionaryToMessage(snsMsgFields);
            this._messageValidator.ValidateCertUrl(snsMessage);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Signing certificate url is not from a recognised source.")]
        public void ShouldThrowExceptionIfCertificateURLHasImproperDoubleDotcomInUrl()
        {
            IDictionary<string, string> snsMsgFields = new Dictionary<string, string>();
            snsMsgFields["SigningCertURL"] = "https://sns.us-east-1.amazonaws.com.com/SimpleNotificationService-bb750dd426d95ee9390147a5624348ee.pem";
            Message snsMessage = Utilities.ConvertDictionaryToMessage(snsMsgFields);
            this._messageValidator.ValidateCertUrl(snsMessage);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Error with sns message - signature verification v1 failed for message id test, topicArn 223")]
        public void ShouldThrowExceptionWhenSignatureVerificationVersion1Fails()
        {
            // Given
            IDictionary<string, string> snsMsgFields = new Dictionary<string, string>();
            snsMsgFields.Add("SignatureVersion", "1");
            Message snsMessage = Utilities.ConvertDictionaryToMessage(snsMsgFields);
            snsMessage.Metadata = Utilities.CreateTestSnsNotificationMetadata("test", "223");

            using (this._mocks.Ordered)
            {
                Expect.Once.On(this._mockValidator).Method("VerifyMsgMatchesSignatureV1WithCert").With(snsMessage).Will(Return.Value(false));
            }

            // When
            this._messageValidator.ValidateMessageIsTrusted(snsMessage);

            // Then
            this._mocks.VerifyAllExpectationsHaveBeenMet();
        }
    }
}