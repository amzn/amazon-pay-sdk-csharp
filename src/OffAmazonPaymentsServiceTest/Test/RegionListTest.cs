using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using OffAmazonPaymentsService;

namespace OffAmazonPaymentsServiceTest.Test
{
    [TestFixture]
    class RegionListTest
    {

        [Test]
        public void TestIfRegionNaCorrect()
        {
            ChangeTestRegion("na");
            string url = ConstructUrl();
            
            Assert.AreEqual(url, OffAmazonPaymentsServicePropertyCollection.getInstance().ServiceURL);
        }

        [Test]
        public void TestIfRegionEuCorrect()
        {
            ChangeTestRegion("eu");
            string url = ConstructUrl();

            Assert.AreEqual(url, OffAmazonPaymentsServicePropertyCollection.getInstance().ServiceURL);

        }

        private void ChangeTestRegion(string region)
        {
            if(ConfigurationManager.AppSettings["region"].ToLower() == region)
                return;

            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings.Remove("region");
            config.AppSettings.Settings.Add("region", region);
            config.Save();
            ConfigurationManager.RefreshSection("appSettings");
        }

        private string ConstructUrl()
        {
            string url = "";
            if (ConfigurationManager.AppSettings["region"].ToLower() == "na")
            {
                url += "https://mws.amazonservices.com/";
            }
            else if (ConfigurationManager.AppSettings["region"].ToLower() == "eu")
            {
                url += "https://mws-eu.amazonservices.com/";
            }

            if (ConfigurationManager.AppSettings["environment"] == "sandbox")
                url += "OffAmazonPayments_Sandbox/2013-01-01";
            else
                url += "OffAmazonPayments/2013-01-01";

            return url;
        }
    }
}
