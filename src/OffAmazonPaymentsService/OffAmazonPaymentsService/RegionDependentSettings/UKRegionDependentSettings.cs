using System;
using System.Collections.Generic;
using System.Text;

namespace OffAmazonPaymentsService.OffAmazonPaymentsService.RegionDependentSettings
{
    public class UKRegionDependentSettings : EURegionDependentSettings
    {
        public override String getLocale()
        {
            return "uk";
        }

        public override String getCurrencyCode()
        {
            return "GBP";
        }
    }
}
