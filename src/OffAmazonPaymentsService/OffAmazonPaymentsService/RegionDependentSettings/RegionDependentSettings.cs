using System;
using System.Collections.Generic;
using System.Text;

namespace OffAmazonPaymentsService.OffAmazonPaymentsService.RegionDependentSettings
{
    public interface RegionDependentSettings
    {
        String getMwsUrlForEnvironment(string environment);
        String getWidgetUrlForEnvironment(string environment);
        String getCurrencyCode();
        String getLocale();
    }
}
