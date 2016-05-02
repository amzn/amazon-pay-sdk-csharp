using NUnit.Framework;
using OffAmazonPaymentsService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class ClientIdTest
    {
        [Test]
        public void shouldReturnClientIdIfDefinedInConfig()
        {
            String expectedClientId = "2323-2323";
            defineClientId(expectedClientId);

            Assert.AreEqual(expectedClientId, new OffAmazonPaymentsServicePropertyCollection().ClientId);
        }

        [Test]
        [ExpectedException("System.SystemException")]
        public void shouldThrowExceptionIfClientIdIsNotDefined()
        {
            removeClientId();
            String test = new OffAmazonPaymentsServicePropertyCollection().ClientId;
        }

        private void removeClientId()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("clientId");
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void defineClientId(String expectedClientId)
        {
            removeClientId();
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Add("clientId", expectedClientId);
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");
        }

    }
}
