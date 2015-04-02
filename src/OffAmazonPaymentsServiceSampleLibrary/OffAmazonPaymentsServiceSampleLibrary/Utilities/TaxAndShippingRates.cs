using OffAmazonPaymentsService;
using OffAmazonPaymentsService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace OffAmazonPaymentsServiceSampleLibrary.OffAmazonPaymentsServiceSampleLibrary.Utilities
{
    /***************************************************************************
     * Helper class for setting state specific tax rates
     * and type of shipping and its rate
     ***************************************************************************/
    public class TaxAndShippingRates
    {
        private string stateCode;
        private string countryCode;
        private double taxRate;
        private double standardShipping;
        private double twoDayShipping;
        private double nextDayShipping;

        public TaxAndShippingRates(Destination destination)
        {
            if (destination != null)
            {
                Address address = destination.PhysicalDestination;
                if (address != null)
                {
                    setRatesForCountryAndState(address.CountryCode, address.StateOrRegion);
                }
                else
                {
                    throw new OffAmazonPaymentsServiceException("No Physical Address is set");
                }
            }
            else
            {
                throw new OffAmazonPaymentsServiceException("No Destination is set");
            }
        }

        public void setRatesForCountryAndState(string countryCode, string stateCode)
        {
            if (countryCode.Equals("US"))
            {
                if (stateCode.Equals("WA"))
                {
                    setRates(countryCode, "WA", 8.6, 10.00, 25.00, 50.00);
                }
                else if (stateCode.Equals("NY"))
                {
                    setRates(countryCode, "NY", 7.3, 15.00, 25.00, 75.00);
                }
                else if (stateCode.Equals("CT"))
                {
                    setRates(countryCode, "CT", 4.3, 5.00, 15.00, 55.00);
                }
                else
                {
                    setRates(countryCode, "UNKNOWN", 0.0, 5.00, 10.00, 20.00);
                }
            }
            else if (countryCode.Equals("CA"))
            {
                if (stateCode.Equals("BC"))
                {
                    setRates(countryCode, "BC", 7.6, 11.00, 35.00, 55.00);
                }
                else if (stateCode.Equals("QC"))
                {
                    setRates(countryCode, "QC", 8.3, 10.00, 20.00, 70.00);
                }
                else if (stateCode.Equals("ON"))
                {
                    setRates(countryCode, "ON", 5.3, 15.00, 25.00, 75.00);
                }
                else
                {
                    setRates(countryCode, "UNKNOWN", 0.0, 5.00, 10.00, 20.00);
                }
            }
            else
            {
                setRates(countryCode, "UNKNOWN", 0.0, 5.00, 10.00, 20.00);
            }
        }

        public void setRates(string countryCode, string stateCode, double taxRate,
            double standardShipping, double twoDayShipping, double nextDayShipping)
        {
            this.countryCode = countryCode;
            this.stateCode = stateCode;
            this.taxRate = taxRate;
            this.standardShipping = standardShipping;
            this.twoDayShipping = twoDayShipping;
            this.nextDayShipping = nextDayShipping;
        }

        public double getShippingRate(String shippingType)
        {
            if (shippingType.Equals("standardShipping"))
            {
                return this.standardShipping;
            }
            else if (shippingType.Equals("twoDayShipping"))
            {
                return this.twoDayShipping;
            }
            else if (shippingType.Equals("nextDayShipping"))
            {
                return this.nextDayShipping;
            }
            else
            {
                return -1.00;
            }
        }

        public double calculateTax(double subTotal)
        {
            double orderTotalWithTax = subTotal * (1 + (taxRate / 100));
            return Math.Round(orderTotalWithTax, 2);
        }

        public double calculateShipping(double subTotal, string shippingType)
        {
            double shippingRate = getShippingRate(shippingType);
            if (shippingRate < 0)
            {
                throw new OffAmazonPaymentsServiceException(shippingType +
                    ": Is unknown Shipping Type. " +
                    "Only Following types are allowed:" +
                    "\n1.standardShipping\n2.twoDayShipping" +
                    "\n3.nextDayShipping\n");
            }
            else
            {
                double orderTotalWithShipping = subTotal + shippingRate;
                return Math.Round(orderTotalWithShipping, 2);
            }
        }

        public double getTotalAmountWithTaxAndShipping(double subTotal, int shippingOption)
        {
            double withTax = calculateTax(subTotal);
            /*
             * This sample uses 3 options for shipping type:
             * 1. Standard Shipping
             * 2. Two Day Shipping
             * 3. Next Day Shipping
             */
            string shippingType = null;
            switch (shippingOption)
            {
                case 1:
                    shippingType = "standardShipping";
                    break;
                case 2:
                    shippingType = "twoDayShipping";
                    break;
                case 3:
                    shippingType = "nextDayShipping";
                    break;
            }
            double orderTotal = calculateShipping(withTax, shippingType);
            return orderTotal;
        }
    }
}
