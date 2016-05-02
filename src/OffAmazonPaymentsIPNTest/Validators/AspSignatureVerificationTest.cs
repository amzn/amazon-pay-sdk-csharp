using NMock2;
using NUnit.Framework;
using OffAmazonPaymentsNotifications;
using OffAmazonPaymentsNotifications.Certificate;
using System;
using System.Collections.Generic;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Configuration;

namespace OffAmazonPaymentsNotificationsTest.Validators
{
    [TestFixture]
    class AspSignatureVerificationTest
    {
        private VerifyDataAspImpl _verifyDataAspImpl;
        private Mockery _mocks;
        private ICertificate _mockCertificate;

        enum SubjectType { ValidSubject1, ValidSubject2, NonAmazon, DuplicateKeys };
        private const string ValidSubject1 = "CN=sns.amazonaws.com, O=Amazon.com Inc., L=Seattle, S=Washington, C=US";
        private const string ValidSubject2 = "CN=sns.amazonaws.com, O=\"Amazon.com, Inc.\", L=Seattle, S=Washington, C=US";
        private const string InvalidSubjectNonAmazon = "CN=FAKECN=sns.amazonaws.com, O=Amazon.com Inc., L=Seattle, S=Washington, C=US";
        private const string InvalidSubjectDuplicateKeys = "CN=sns.amazonaws.com, CN=sns.amazonaws.com, O=Amazon.com Inc., L=Seattle, S=Washington, C=US";

        [SetUp]
        public void SetUp()
        {
            _verifyDataAspImpl = new VerifyDataAspImpl();
            _mocks = new Mockery();
            _mockCertificate = this._mocks.NewMock<ICertificate>();
            Utilities.SetupConfigForTest();          
        }

        [Test]
        public void ValidSubject1CertificateTest()
        {
            mockVerifyCertIsIssuedToAmazon(true, SubjectType.ValidSubject1);

            bool isValid = _verifyDataAspImpl.VerifyCertIsIssuedByAmazon(_mockCertificate);

            Assert.True(isValid);
            this._mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void ValidSubject2CertificateTest()
        {
            mockVerifyCertIsIssuedToAmazon(true, SubjectType.ValidSubject2);

            bool isValid = _verifyDataAspImpl.VerifyCertIsIssuedByAmazon(_mockCertificate);

            Assert.True(isValid);
            this._mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void InvalidCertificateChainTest()
        {
            mockVerifyCertIsIssuedToAmazon(false, SubjectType.ValidSubject1);

            bool isValid = _verifyDataAspImpl.VerifyCertIsIssuedByAmazon(_mockCertificate);

            Assert.False(isValid);
            this._mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void NonAmazonCertificateTest()
        {
            mockVerifyCertIsIssuedToAmazon(true, SubjectType.NonAmazon);

            bool isValid = _verifyDataAspImpl.VerifyCertIsIssuedByAmazon(_mockCertificate);

            Assert.False(isValid);
            this._mocks.VerifyAllExpectationsHaveBeenMet();
        }

        [Test]
        public void DuplicateSubjectKeysCertificateTest()
        {
            mockVerifyCertIsIssuedToAmazon(true, SubjectType.DuplicateKeys);

            bool isValid = _verifyDataAspImpl.VerifyCertIsIssuedByAmazon(_mockCertificate);

            Assert.False(isValid);
            this._mocks.VerifyAllExpectationsHaveBeenMet();
        }

        private void mockVerifyCertIsIssuedToAmazon(bool isCertificateChainValid, SubjectType subjectType)
        {
            using (_mocks.Ordered)
            {
                Expect.Once.On(_mockCertificate)
                        .Method("VerifyCertificateChain")
                        .Will(Return.Value(isCertificateChainValid));

                if (!isCertificateChainValid) return;

                String subject = "";
                if (SubjectType.ValidSubject1.Equals(subjectType)) {
                    subject = ValidSubject1;
                } else if (SubjectType.ValidSubject2.Equals(subjectType)) {
                    subject = ValidSubject2;
                } else if (SubjectType.NonAmazon.Equals(subjectType)) {
                    subject = InvalidSubjectNonAmazon;
                }
                else if (SubjectType.DuplicateKeys.Equals(subjectType))
                {
                    subject = InvalidSubjectDuplicateKeys;
                }

                Expect.Once.On(_mockCertificate)
                        .Method("GetSubject")
                        .Will(Return.Value(subject));
            }
        }
    }
}
