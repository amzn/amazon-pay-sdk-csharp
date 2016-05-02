using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OffAmazonPaymentsService;
using OffAmazonPaymentsService.Model;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class ServiceURLTest
    {

        [TestCase("us", "sandbox", "https://mws.amazonservices.com/OffAmazonPayments_Sandbox/2013-01-01")]
        [TestCase("us", "live", "https://mws.amazonservices.com/OffAmazonPayments/2013-01-01")]
        [TestCase("na", "sandbox", "https://mws.amazonservices.com/OffAmazonPayments_Sandbox/2013-01-01")]
        [TestCase("na", "live", "https://mws.amazonservices.com/OffAmazonPayments/2013-01-01")]
        [TestCase("de", "sandbox", "https://mws-eu.amazonservices.com/OffAmazonPayments_Sandbox/2013-01-01")]
        [TestCase("de", "live", "https://mws-eu.amazonservices.com/OffAmazonPayments/2013-01-01")]
        [TestCase("uk", "sandbox", "https://mws-eu.amazonservices.com/OffAmazonPayments_Sandbox/2013-01-01")]
        [TestCase("uk", "live", "https://mws-eu.amazonservices.com/OffAmazonPayments/2013-01-01")]
        public void shouldMapRegionAndEnvironmentCorrectly(string region, string environment, string expectedServiceUrl)
        {
            RemoveInternalServiceURL();
            SetupRegionEnvironment(region, environment);

            Assert.AreEqual(expectedServiceUrl, new OffAmazonPaymentsServicePropertyCollection().ServiceURL);
        }

        [Test]
        public void ShouldUseServiceUrlOverrideIfDefined()
        {
            AddInternalServiceURL();

            string url = "https://mws-beta-na-backend.vipinteg.amazon.com/";
            if (ConfigurationManager.AppSettings["environment"] == "sandbox")
                url += "OffAmazonPayments_Sandbox/2013-01-01";
            else
                url += "OffAmazonPayments/2013-01-01";

            Assert.AreEqual(url, new OffAmazonPaymentsServicePropertyCollection().ServiceURL);
        }

        private void AddInternalServiceURL()
        {
            RemoveInternalServiceURL();
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Add("serviceUrl", "https://mws-beta-na-backend.vipinteg.amazon.com");
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void RemoveInternalServiceURL()
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("serviceUrl");
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");
        }

        private void SetupRegionEnvironment(string region, string environment)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("region");
            config.AppSettings.Settings.Remove("environment");
            config.AppSettings.Settings.Add("region", region);
            config.AppSettings.Settings.Add("environment", environment);
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
