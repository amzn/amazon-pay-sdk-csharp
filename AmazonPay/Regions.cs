using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace AmazonPay
{
    /// <summary>
    /// Define the regions supported
    /// </summary>
    public static class Regions
    {
        /// <summary>
        /// Enum for supported Region values
        /// </summary>
        public enum supportedRegions
        {
            us, uk, de, jp
        }
        public enum currencyCode
        {
            USD, GBP, EUR, JPY
        }

        private enum commonRegions
        {
            eu, na
        }
        /// <summary>
        /// MWS endpoint URL'S
        /// </summary>
        public static readonly Dictionary<string, string> mwsServiceUrls = new Dictionary<string, string>() {
			{commonRegions.eu.ToString(), "mws-eu.amazonservices.com"}, 
            {commonRegions.na.ToString(), "mws.amazonservices.com"}, 
            {supportedRegions.jp.ToString(), "mws.amazonservices.jp"}
		};

        /// <summary>
        /// Production profile end points to get the user information
        /// </summary>
        public static readonly Dictionary<string, string> ProfileEndpoint = new Dictionary<string, string>() {
			{supportedRegions.uk.ToString(), "amazon.co.uk"}, 
            {supportedRegions.us.ToString(), "amazon.com"}, 
            {supportedRegions.de.ToString(), "amazon.de"}, 
            {supportedRegions.jp.ToString(), "amazon.co.jp"}
		};

        /// <summary>
        /// Region Mappings to map the regions to the zones
        /// </summary>
        public static readonly Dictionary<string, string> regionMappings = new Dictionary<string, string>() {
			{supportedRegions.de.ToString(), commonRegions.eu.ToString()}, 
            {supportedRegions.uk.ToString(), commonRegions.eu.ToString()}, 
            {supportedRegions.us.ToString(), commonRegions.na.ToString()},
            {supportedRegions.jp.ToString(), supportedRegions.jp.ToString()}
		};
    }
}
