using NMock2;
using NUnit.Framework;
using OffAmazonPaymentsNotifications;
using OffAmazonPaymentsNotifications.Certificate;
using System;
using System.Collections.Generic;
using System.Text;

namespace OffAmazonPaymentsNotificationsTest.Validators
{
    [TestFixture]
    class SnsSignatureVerificationTest
    {
        private Mockery _mocks;
        private IVerifyData _mockVerifyData;
        private ICertificateFactory _mockCertificateFactory;
        private ICertificate _mockCertificate;
        private SnsSignatureVerification _snsSignatureVerificaton;

        [SetUp]
        public void SetUp()
        {
            this._mocks = new Mockery();
            this._mockVerifyData = this._mocks.NewMock<IVerifyData>();
            this._mockCertificateFactory = this._mocks.NewMock<ICertificateFactory>();
            this._mockCertificate = this._mocks.NewMock<ICertificate>();
            this._snsSignatureVerificaton = new SnsSignatureVerification(this._mockVerifyData, this._mockCertificateFactory);
        }

        [Test]
        public void ShouldCreateUnhashedSignatureByteArrayFromSnsMessageDataWithDecodeSignatureString()
        {
            // given
            string expectedSignature = "WPvufNGD0meAuOf+zNdU+2KOoZE0H005/XCGobaUTgcEZ+q6ojeKrDPZ7i7EwLS9GTPGZK3Qjk9VPvsLs49svxSIhzLoebKFBTDOurZzQsxoi2Qr5rvebpNkPe4YZpDsCk+0Z2I6xXQWGgc0QRa6umhiecC7AMVnMA8wlvtX6ko=";

            IDictionary<string, string> snsFields = GetDefaultSnsSignatureVerificationFields(expectedSignature, @"https://testcert", null);
            Message msg = Utilities.ConvertDictionaryToMessage(snsFields);

            byte[] expectedSignatureBytes = GetExpectedSignatureBytesFromOrderedDictionary(snsFields);

            setUpMocks(true, true, expectedSignatureBytes);

            // when
            bool result = this._snsSignatureVerificaton.VerifyMsgMatchesSignatureV1WithCert(msg);

            // then
            Assert.True(result);
            this._mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldCreateUnhashedSignatureByteArrayFromSnsMessageDataThatContainsOptionalSubjectField()
        {
            // given
            string expectedSignature = "WPvufNGD0meAuOf+zNdU+2KOoZE0H005/XCGobaUTgcEZ+q6ojeKrDPZ7i7EwLS9GTPGZK3Qjk9VPvsLs49svxSIhzLoebKFBTDOurZzQsxoi2Qr5rvebpNkPe4YZpDsCk+0Z2I6xXQWGgc0QRa6umhiecC7AMVnMA8wlvtX6ko=";

            IDictionary<string, string> snsFields = GetDefaultSnsSignatureVerificationFields(expectedSignature, @"https://testcert", "Value");
            Message msg = Utilities.ConvertDictionaryToMessage(snsFields);

            byte[] expectedSignatureBytes = GetExpectedSignatureBytesFromOrderedDictionary(snsFields);
            setUpMocks(true, true, expectedSignatureBytes);

            // when
            bool result = this._snsSignatureVerificaton.VerifyMsgMatchesSignatureV1WithCert(msg);

            // then
            Assert.True(result);
            this._mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldDecodeBase64SignatureString()
        {
            // given
            string expectedSignatureValue = "WPvufNGD0meAuOf+zNdU+2KOoZE0H005/XCGobaUTgcEZ+q6ojeKrDPZ7i7EwLS9GTPGZK3Qjk9VPvsLs49svxSIhzLoebKFBTDOurZzQsxoi2Qr5rvebpNkPe4YZpDsCk+0Z2I6xXQWGgc0QRa6umhiecC7AMVnMA8wlvtX6ko=";
            byte[] expectedByteArray = Convert.FromBase64String(expectedSignatureValue);

            IDictionary<string, string> snsFields = GetDefaultSnsSignatureVerificationFields(expectedSignatureValue, @"https://testcert", "Value");
            Message msg = Utilities.ConvertDictionaryToMessage(snsFields);

            setUpMocks(true, true);

            // when
            bool result = this._snsSignatureVerificaton.VerifyMsgMatchesSignatureV1WithCert(msg);

            // then
            Assert.True(result);
            this._mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldExtractAndPassThroughSignCertUrlProperty()
        {
            // given
            string expectedSignatureValue = "WPvufNGD0meAuOf+zNdU+2KOoZE0H005/XCGobaUTgcEZ+q6ojeKrDPZ7i7EwLS9GTPGZK3Qjk9VPvsLs49svxSIhzLoebKFBTDOurZzQsxoi2Qr5rvebpNkPe4YZpDsCk+0Z2I6xXQWGgc0QRa6umhiecC7AMVnMA8wlvtX6ko=";
            string expectedSignCertUrl = @"https://testcert";

            IDictionary<string, string> snsFields = GetDefaultSnsSignatureVerificationFields(expectedSignatureValue, expectedSignCertUrl, "Value");
            Message msg = Utilities.ConvertDictionaryToMessage(snsFields);

            setUpMocks(true, true);

            // when
            bool result = this._snsSignatureVerificaton.VerifyMsgMatchesSignatureV1WithCert(msg);

            // then
            Assert.True(result);
            this._mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ShouldReturnFalseWhenSignatureVerificationFails()
        {
            // given
            string expectedSignatureValue = "WPvufNGD0meAuOf+zNdU+2KOoZE0H005/XCGobaUTgcEZ+q6ojeKrDPZ7i7EwLS9GTPGZK3Qjk9VPvsLs49svxSIhzLoebKFBTDOurZzQsxoi2Qr5rvebpNkPe4YZpDsCk+0Z2I6xXQWGgc0QRa6umhiecC7AMVnMA8wlvtX6ko=";

            IDictionary<string, string> snsFields = GetDefaultSnsSignatureVerificationFields(expectedSignatureValue, @"https://testcert", "Value");
            Message msg = Utilities.ConvertDictionaryToMessage(snsFields);

            setUpMocks(true, false);

            // when
            bool result = this._snsSignatureVerificaton.VerifyMsgMatchesSignatureV1WithCert(msg);

            // then
            Assert.False(result);
            this._mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Error with sns message verification - message is not of type Notification, no implementation of signing algorithm is present for other notification types")]
        public void ShouldThrowExceptionTypeIsNotNotification()
        {
            // Given
            IDictionary<string, string> snsFields = GetDefaultSnsSignatureVerificationFields("dfsdf", @"https://testcert", "Value");
            snsFields.Remove("Type");
            snsFields.Add("Type", "SubscriptionConfirmation");
            Message msg = Utilities.ConvertDictionaryToMessage(snsFields);

            // When
            this._snsSignatureVerificaton.VerifyMsgMatchesSignatureV1WithCert(msg);
        }

        [Test]
        [ExpectedException(ExpectedException = typeof(NotificationsException), ExpectedMessage = "Error with sns message verification - certificate in Notification is not a valid certificate issued to Amazon")]
        public void ShouldThrowExceptionWhenCertIsNotFromAmazon()
        {
            // given
            string expectedSignatureValue = "WPvufNGD0meAuOf+zNdU+2KOoZE0H005/XCGobaUTgcEZ+q6ojeKrDPZ7i7EwLS9GTPGZK3Qjk9VPvsLs49svxSIhzLoebKFBTDOurZzQsxoi2Qr5rvebpNkPe4YZpDsCk+0Z2I6xXQWGgc0QRa6umhiecC7AMVnMA8wlvtX6ko=";

            IDictionary<string, string> snsFields = GetDefaultSnsSignatureVerificationFields(expectedSignatureValue, @"https://testcert", "Value");
            Message msg = Utilities.ConvertDictionaryToMessage(snsFields);

            setUpMocks(false, true);

            // when
            this._snsSignatureVerificaton.VerifyMsgMatchesSignatureV1WithCert(msg);
        }

        private static IDictionary<string,string> GetDefaultSnsSignatureVerificationFields(string signature, string signCertUrl, string subject)
        {
            IDictionary<string, string> snsFields = new Dictionary<string, string>();
            snsFields.Add("Message", "{\"NotificationReferenceId\":\"32d195c3-a829-4222-b1e2-14ab28909513\",\"NotificationType\":\"OrderReferenceNotification\",\"SellerId\":\"A08439021T39K6DTX4JS9\",\"ReleaseEnvironment\":\"Sandbox\",\"Version\":\"2012-12-25\",\"NotificationData\":\"<?xml version=\\\"1.0\\\" encoding=\\\"UTF-8\\\"?><OrderReferenceNotification xmlns=\\\"http://payments.amazon.com/ipn/2012-12-25/\\\">\\n    <OrderReference>\\n        <AmazonOrderReferenceId>P0R-T9jl5tI-qryuG17<\\/AmazonOrderReferenceId>\\n        <OrderTotal>\\n            <Amount>5.00<\\/Amount>\\n            <CurrencyCode>USD<\\/CurrencyCode>\\n        <\\/OrderTotal>\\n        <SellerNote>APPROVE HEAVY APPROVE LITE<\\/SellerNote>\\n        <OrderReferenceStatus>\\n            <State>CLOSED<\\/State>\\n            <ReasonCode>SellerClosed<\\/ReasonCode>\\n            <LastUpdateTimestamp>2013-04-01T10:49:59.532Z<\\/LastUpdateTimestamp>\\n        <\\/OrderReferenceStatus>\\n        <CreationTimestamp>2013-03-30T09:58:51.234Z<\\/CreationTimestamp>\\n        <ExpirationTimestamp>2013-04-06T09:58:51.234Z<\\/ExpirationTimestamp>\\n    <\\/OrderReference>\\n<\\/OrderReferenceNotification>\",\"Timestamp\":\"2013-04-01T10:49:59Z\"}");
            snsFields.Add("MessageId", "432f33bf-9f84-5004-815f-7a6cf72595bf");
            if (subject != null)
            {
                snsFields.Add("Subject", subject);
            }
            snsFields.Add("Timestamp", "2013-04-01T10:50:09.831Z");
            snsFields.Add("TopicArn", "arn:aws:sns:us-east-1:598607868003:TestTopic");
            snsFields.Add("Type", "Notification");
            snsFields.Add("Signature", signature);
            snsFields.Add("SigningCertURL", signCertUrl);
            return snsFields;
        }

        private byte[] GetExpectedSignatureBytesFromOrderedDictionary(IDictionary<string, string> snsFields)
        {
            StringBuilder expectedString = new StringBuilder();
            foreach (KeyValuePair<string, string> pair in snsFields)
            {
                if (("Signature".CompareTo(pair.Key.ToString()) != 0) && ("SigningCertURL".CompareTo(pair.Key.ToString()) != 0)) {
                    expectedString.AppendFormat("{0}\n{1}\n", pair.Key, pair.Value);
                }
            }

            return System.Text.Encoding.UTF8.GetBytes(expectedString.ToString());
        }

        private void setUpMocks(bool certIsIssuedToAmazon, bool msgMatchesSignatureWithPublicCert)
        {
            setUpMocks(certIsIssuedToAmazon, msgMatchesSignatureWithPublicCert, null);
        }

        private void setUpMocks(bool certIsIssuedToAmazon, bool msgMatchesSignatureWithPublicCert, byte[] expectedSignatureBytes)
        {
            using (this._mocks.Ordered)
            {
                Expect.Once.On(this._mockCertificateFactory)
                    .Method("GetCertificate").With(NMock2.Is.TypeOf(typeof(string)))
                    .Will(Return.Value(_mockCertificate));

                Expect.Once.On(this._mockVerifyData)
                    .Method("VerifyCertIsIssuedByAmazon").With(_mockCertificate)
                    .Will(Return.Value(certIsIssuedToAmazon));

                if (expectedSignatureBytes == null) {
                    Expect.Once.On(this._mockVerifyData)
                        .Method("VerifyMsgMatchesSignatureWithPublicCert").With(NMock2.Is.TypeOf(typeof(byte[])), NMock2.Is.TypeOf(typeof(byte[])), _mockCertificate)
                        .Will(Return.Value(msgMatchesSignatureWithPublicCert));
                } else {
                    Expect.Once.On(this._mockVerifyData)
                        .Method("VerifyMsgMatchesSignatureWithPublicCert").With(expectedSignatureBytes, NMock2.Is.TypeOf(typeof(byte[])), _mockCertificate)
                        .Will(Return.Value(true));
                }
                
            }
        }

    }
}
