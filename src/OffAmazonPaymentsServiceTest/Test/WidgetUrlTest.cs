using NUnit.Framework;
using OffAmazonPaymentsService;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Web;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class WidgetUrlTest
    {
        private const string SELLER_ID = "A2131353443343";

        [TestCase("de", "sandbox", "https://static-eu.payments-amazon.com/OffAmazonPayments/de/sandbox/lpa/js/Widgets.js")]
        [TestCase("de", "live", "https://static-eu.payments-amazon.com/OffAmazonPayments/de/lpa/js/Widgets.js")]
        [TestCase("uk", "sandbox", "https://static-eu.payments-amazon.com/OffAmazonPayments/uk/sandbox/lpa/js/Widgets.js")]
        [TestCase("uk", "live", "https://static-eu.payments-amazon.com/OffAmazonPayments/uk/lpa/js/Widgets.js")]
        [TestCase("us", "sandbox", "https://static-na.payments-amazon.com/OffAmazonPayments/us/sandbox/js/Widgets.js")]
        [TestCase("us", "live", "https://static-na.payments-amazon.com/OffAmazonPayments/us/js/Widgets.js")]
        // NA and EU are deprecated, howver since it was included in one public release we need to maintain a mapping
        // NA map to US widget
        [TestCase("na", "sandbox", "https://static-na.payments-amazon.com/OffAmazonPayments/us/sandbox/js/Widgets.js")]
        [TestCase("us", "live", "https://static-na.payments-amazon.com/OffAmazonPayments/us/js/Widgets.js")]
        // EU will throw an exception when selected
        [TestCase("eu", "sandbox", null, ExpectedException = typeof(OffAmazonPaymentsServiceException))]
        [TestCase("eu", "live", null, ExpectedException = typeof(OffAmazonPaymentsServiceException))]
        public void shouldUseCorrectMappingIfOverrideIsNotPresent(string region, string environment, string expectedWidgetUrl)
        {
            runTest(region, environment, SELLER_ID, expectedWidgetUrl);
        }


        [Test]
        public void shouldUseWidgetUrlOverrideIfDefined()
        {
            String expectedWidgetUrl = "https://ostatic-payments-na.integ.amazon.com/OffAmazonPayments/us/sandbox/js/Widgets.js";

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("environment");
            config.AppSettings.Settings.Remove("region");
            config.AppSettings.Settings.Remove("widgetUrl");
            config.AppSettings.Settings.Remove("merchantID");
            config.AppSettings.Settings.Add("environment", "sandbox");
            config.AppSettings.Settings.Add("region", "us");
            config.AppSettings.Settings.Add("widgetUrl", "https://ostatic-payments-na.integ.amazon.com");
            config.AppSettings.Settings.Add("merchantID", SELLER_ID);
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");

            Assert.AreEqual(expectedWidgetUrl, new OffAmazonPaymentsServicePropertyCollection().WidgetUrl);
        }

        private void runTest(string region, string environment, string merchantId, string expectedWidgetUrl)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("environment");
            config.AppSettings.Settings.Remove("region");
            config.AppSettings.Settings.Remove("widgetUrl");
            config.AppSettings.Settings.Remove("merchantID");
            config.AppSettings.Settings.Add("environment", environment);
            config.AppSettings.Settings.Add("region", region);
            config.AppSettings.Settings.Add("merchantID", merchantId);
            config.Save(ConfigurationSaveMode.Modified, true);
            ConfigurationManager.RefreshSection("appSettings");

            Assert.AreEqual(expectedWidgetUrl, new OffAmazonPaymentsServicePropertyCollection().WidgetUrl);
        }
    }
}
