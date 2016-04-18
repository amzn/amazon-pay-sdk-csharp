using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace OffAmazonPaymentsService.Sample
{
    public class CLIHelper
    {
        public static string getStringFromConsole(string var)
        {
            Console.WriteLine("Please input the " + var + ":");
            return Console.ReadLine();
        }

        public static double getDoubleFromConsole(string var)
        {
            Console.WriteLine("Please input the " + var + ":");
            string numberStr = Console.ReadLine();

            while (!IsNumber(numberStr))
            {
                Console.WriteLine("The " + var + " should be in number format:");
                numberStr = Console.ReadLine();
            }
            return Convert.ToDouble(numberStr);
        }

        public static int getShippingOption()
        {
            int shippingOption;
            do
            {
                Console.WriteLine("Please select shipping option:");
                Console.WriteLine("1. Standard Shipping");
                Console.WriteLine("2. Two Day Shipping");
                Console.WriteLine("3. Next Day Shipping");
                Console.WriteLine("Your Option?");
                shippingOption = Convert.ToInt32(Console.ReadLine().Trim());
            } while (shippingOption < 1 || shippingOption > 3);
            return shippingOption;
        }

        public static int getAuthorizationOption()
        {
            Console.WriteLine("Select the type of Authorization you want to use:");
            Console.WriteLine("1 : Regular Authorization (Asynchronous Response) [Default]");
            Console.WriteLine("2 : Fast Authorization (Synchronous Response)");
            int authorizationOption;
            do
            {
                authorizationOption = Convert.ToInt32(Console.ReadLine().Trim());
            } while (!(authorizationOption == 1 || authorizationOption == 2));
            return authorizationOption;
        }

        //check if the string variable is in number format
        private static Boolean IsNumber(String text)
        {
            Regex regex = new Regex(@"^[0-9]*\.?[0-9]+$");
            return regex.IsMatch(text);
        }

    }
}
