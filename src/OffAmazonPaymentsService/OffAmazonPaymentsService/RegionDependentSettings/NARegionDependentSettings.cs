using System;
using System.Collections.Generic;
using System.Text;

namespace OffAmazonPaymentsService.OffAmazonPaymentsService.RegionDependentSettings
{
    public abstract class NARegionDependentSettings : RegionDependentSettingsImpl
    {
        private static String MWS_URL = "https://mws.amazonservices.com/";
        private static String WIDGET_URL = "https://static-na.payments-amazon.com/";

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
