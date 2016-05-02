using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Collections.Specialized;
using OffAmazonPaymentsService;
using OffAmazonPaymentsService.Mock;
using OffAmazonPaymentsService.Model;
using OffAmazonPaymentsService.OffAmazonPaymentsService.RegionDependentSettings;
using System.Web;

namespace OffAmazonPaymentsService
{
    public class OffAmazonPaymentsServicePropertyCollection
    {
        private String merchantID;
        private String accessKey;
        private String secretKey;
        private String applicationName;
        private String applicationVersion;
        private String environment;
        private String region;
        private String widgetUrl;
        private String clientId;
        private String certCN;
        private IDictionary<string, RegionDependentSettings> regionList;
        private OffAmazonPaymentsServiceConfig URLConfig;
        private static OffAmazonPaymentsServicePropertyCollection instance = null;

        public static OffAmazonPaymentsServicePropertyCollection getInstance()
        {
            if (instance == null)
                instance = new OffAmazonPaymentsServicePropertyCollection();
            return instance;
        }

        public String MerchantID
        {
            get { return merchantID; }
        }

        public String AccessKey
        {
            get { return this.accessKey; }
        }

        public String SecretKey
        {
            get { return this.secretKey; }
        }

        public String CurrencyCode
        {
            get 
            {
                if (!regionList.ContainsKey(Region.ToLower()))
                    return null;
                return regionList[Region.ToLower()].getCurrencyCode();
            }
        }

        public String ApplicationName
        {
            get { return this.applicationName; }
        }

        public String ApplicationVersion
        {
            get { return this.applicationVersion; }
        }

        public String Region
        {
            get { return this.region; }
        }

        public String Environment
        {
            get { return this.environment; }
        }

        public String ServiceURL
        {
            get
            {
                string url = null;

                if (ConfigurationManager.AppSettings["serviceUrl"] != null && ConfigurationManager.AppSettings["serviceUrl"] != "")
                {
                    url = ConfigurationManager.AppSettings["serviceUrl"];
                    url = UrlBuilder.buildMwsUrlWithBaseForEnvironment(url, this.environment);
                }
                else
                {
                    if (!regionList.ContainsKey(Region.ToLower()))
                        return null;
                    url = regionList[Region.ToLower()].getMwsUrlForEnvironment(this.environment);
                }

                return url;
            }
        }

        public String WidgetUrl
        {
            get 
            {
                StringBuilder builder = new StringBuilder();
                if (ConfigurationManager.AppSettings["widgetUrl"] != null && ConfigurationManager.AppSettings["widgetUrl"] != "")
                {
                    if (!regionList.ContainsKey(Region.ToLower()))
                        return null;

                    String locale = regionList[Region.ToLower()].getLocale();
                    String customUrl = ConfigurationManager.AppSettings["widgetUrl"];
                    builder.Append(UrlBuilder.buildWidgetUrlWithBaseAndLocaleForEnvironment(customUrl,locale, this.environment));
                }
                else
                {
                    if (!regionList.ContainsKey(Region.ToLower()))
                        return null;
                     builder.Append(regionList[region.ToLower()].getWidgetUrlForEnvironment(this.environment));
                }

                
                return builder.ToString();
            }
        }

        public OffAmazonPaymentsServiceConfig MPSConfig
        {
            get { return URLConfig.WithServiceURL(ServiceURL); }
        }


        public OffAmazonPaymentsServicePropertyCollection()
        {
            regionList = new Dictionary<string, RegionDependentSettings>();
            ConstructRegionList();
            this.merchantID = ConfigurationManager.AppSettings["merchantID"];
            this.accessKey = ConfigurationManager.AppSettings["accessKeyId"];
            this.secretKey = ConfigurationManager.AppSettings["secretAccessKey"];
            this.applicationName = ConfigurationManager.AppSettings["applicationName"];
            this.applicationVersion = ConfigurationManager.AppSettings["applicationVersion"];
            this.environment = ConfigurationManager.AppSettings["environment"].ToLower();
            this.region = ConfigurationManager.AppSettings["region"];
            this.widgetUrl = ConfigurationManager.AppSettings["widgetUrl"];
            this.clientId = ConfigurationManager.AppSettings["clientId"];
            this.certCN = ConfigurationManager.AppSettings["certCN"];

            URLConfig = new OffAmazonPaymentsServiceConfig();
            URLConfig.WithServiceURL(ServiceURL);

            if (!this.environment.Equals("sandbox") && !this.environment.Equals("live"))
                throw new SystemException("The value of environment is not correct!");

            rejectConfigurationIfEURegionIsSelected();
        }

        /// <summary>
        /// Swapped from NA/EU split to region specific to support widget config
        /// throw an error for any eu merchants that have EU in their config - this is prerelese so there
        /// is a chance to fix this, and there isn't a sane default mapping for EU
        /// </summary>
        private void rejectConfigurationIfEURegionIsSelected()
        {
            if (this.region.Equals("eu"))
            {
                throw new OffAmazonPaymentsServiceException("The eu region is deprecated, please enter either de or uk to select the correct region.");
            }
        }

        private void ConstructRegionList()
        {
            regionList.Add("de", new DERegionDependentSettings());
            regionList.Add("uk", new UKRegionDependentSettings());
            regionList.Add("us", new USRegionDependentSettings());
            regionList.Add("na", new USRegionDependentSettings());
        }

        public string ClientId
        {
            get
            {
                if (this.clientId == null)
                {
                    throw new SystemException("client id not defined, check app/web configuration and add a key for clientId");
                }
                return this.clientId;
            }
        }

        public string CertCN
        {
            get
            {
                if (this.certCN == null)
                {
                    throw new SystemException("certCN is not defined, check app/web configuration and add a key for certCN");
                }
                return this.certCN;
            }
        }
    }
}
