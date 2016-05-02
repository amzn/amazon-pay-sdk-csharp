using System;
using System.Collections.Generic;
using System.Text;

namespace OffAmazonPaymentsService.OffAmazonPaymentsService.RegionDependentSettings
{
    public abstract class RegionDependentSettingsImpl : RegionDependentSettings
    {
        public string getMwsUrlForEnvironment(string environment)
        {
            return UrlBuilder.buildMwsUrlWithBaseForEnvironment(getMwsUrl(), environment);
        }

        public string getWidgetUrlForEnvironment(string environment)
        {
            return UrlBuilder.buildWidgetUrlWithBaseAndLocaleForEnvironment(getWidgetUrl(), getLocale(), environment);
        }

        public abstract String getCurrencyCode();
        public abstract String getLocale();

        protected abstract String getMwsUrl();
        protected abstract String getWidgetUrl();
    }
}
