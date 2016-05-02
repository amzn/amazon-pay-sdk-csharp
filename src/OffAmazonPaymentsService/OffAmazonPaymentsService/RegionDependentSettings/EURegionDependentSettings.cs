using System;
using System.Collections.Generic;
using System.Text;

namespace OffAmazonPaymentsService.OffAmazonPaymentsService.RegionDependentSettings
{
    public abstract class EURegionDependentSettings : RegionDependentSettingsImpl
    {
        private static String MWS_URL = "https://mws-eu.amazonservices.com/";
        private static String WIDGET_URL = "https://static-eu.payments-amazon.com/";

        protected override String getMwsUrl()
        {
            return MWS_URL;
        }

        protected override String getWidgetUrl()
        {
            return WIDGET_URL;
        }
    }
}
