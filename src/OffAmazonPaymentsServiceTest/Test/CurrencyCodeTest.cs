using NUnit.Framework;
using OffAmazonPaymentsService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class CurrencyCodeTest
    {
        [TestCase("us", "USD")]
        [TestCase("na", "USD")]
        [TestCase("de", "EUR")]
        [TestCase("uk", "GBP")]
        public void shouldMapRegionsToCorrectCurrencyCodes(string region, string expectedCurrencyCode)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("region");
            config.AppSettings.Settings.Add("region", region);
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");

            Assert.AreEqual(expectedCurrencyCode, new OffAmazonPaymentsServicePropertyCollection().CurrencyCode);
        }
    }
}
