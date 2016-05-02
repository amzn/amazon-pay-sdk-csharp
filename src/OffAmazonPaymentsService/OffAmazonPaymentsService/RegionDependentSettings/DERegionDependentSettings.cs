using System;
using System.Collections.Generic;
using System.Text;

namespace OffAmazonPaymentsService.OffAmazonPaymentsService.RegionDependentSettings
{
    public class DERegionDependentSettings : EURegionDependentSettings
    {
        public override String getLocale()
        {
            return "de";
        }

        public override String getCurrencyCode()
        {
            return "EUR";
        }
    }
}
