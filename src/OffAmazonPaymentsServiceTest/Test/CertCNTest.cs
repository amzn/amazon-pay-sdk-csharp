using NUnit.Framework;
using OffAmazonPaymentsService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class CertCN
    {
        [Test]
        public void shouldReturnCertCNIfDefinedInConfig()
        {
            String expectedCertCN = "sns.amazonaws.com";
            defineCertCN(expectedCertCN);

            Assert.AreEqual(expectedCertCN, new OffAmazonPaymentsServicePropertyCollection().CertCN);
        }

        [Test]
        [ExpectedException("System.SystemException")]
        public void shouldThrowExceptionIfCertCNIsNotDefined()
        {
            removeCertCN();
            String test = new OffAmazonPaymentsServicePropertyCollection().CertCN;
        }

        private void removeCertCN()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("certCN");
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void defineCertCN(String expectedCertCN)
        {
            removeCertCN();
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Add("certCN", expectedCertCN);
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");
        }

    }
}
