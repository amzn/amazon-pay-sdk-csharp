using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace PayWithAmazon
{
    class Regions
    {
        public Hashtable mwsServiceUrls = new Hashtable() {
			{"eu", "mws-eu.amazonservices.com"}, 
            {"na", "mws.amazonservices.com"}, 
            {"jp", "mws.amazonservices.jp"}
		};

        // Production profile end points to get the user information
        public Hashtable ProfileEndpoint = new Hashtable() {
			{"uk", "amazon.co.uk"}, 
            {"us", "amazon.com"}, 
            {"de", "amazon.de"}, 
            {"jp", "amazon.co.jp"}
		};

        public Hashtable regionMappings = new Hashtable() {
			{"de", "eu"}, 
            {"uk", "eu"}, 
            {"us", "na"},
            {"jp", "jp"}
		};
    }
}
