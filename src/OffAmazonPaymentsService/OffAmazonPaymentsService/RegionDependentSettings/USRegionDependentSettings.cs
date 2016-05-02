using System;
using System.Collections.Generic;
using System.Text;

namespace OffAmazonPaymentsService.OffAmazonPaymentsService.RegionDependentSettings
{
    public class USRegionDependentSettings : NARegionDependentSettings
    {
        public override String getLocale()
        {
            return "us";
        }

        public override String getCurrencyCode()
        {
            return "USD";
        }
    }
}
