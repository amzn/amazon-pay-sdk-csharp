using System;
using System.Collections.Generic;
using System.Text;

namespace OffAmazonPaymentsService.OffAmazonPaymentsService.RegionDependentSettings
{
    public static class UrlBuilder
    {
        public static String buildMwsUrlWithBaseForEnvironment(string urlBase, string environment)
        {
            StringBuilder builder = createStringBuilderWithUrlBase(urlBase);

            builder.Append("OffAmazonPayments");
            if (isSandbox(environment))
            {
                builder.Append("_Sandbox");
            }

            builder.Append("/2013-01-01");
            return builder.ToString();
        }

        public static string buildWidgetUrlWithBaseAndLocaleForEnvironment(string urlBase, string locale, string environment)
        {
            StringBuilder builder = createStringBuilderWithUrlBase(urlBase);
            builder.Append("OffAmazonPayments/");
            builder.Append(locale);
            if (isSandbox(environment))
            {
                builder.Append("/sandbox");
            }
            if (locale.Equals("us") || locale.Equals("na"))
            {
                builder.Append("/js/Widgets.js");
            }
            else
            {
                builder.Append("/lpa/js/Widgets.js");
            }
            return builder.ToString();
        }

        private static StringBuilder createStringBuilderWithUrlBase(string urlBase)
        {
            StringBuilder builder = new StringBuilder(urlBase);
            if (!urlBase.EndsWith("/"))
            {
                builder.Append("/");
            }
            return builder;
        }
        
        private static bool isSandbox(string environment)
        {
            return environment.Equals("sandbox");
        }
    }
}
