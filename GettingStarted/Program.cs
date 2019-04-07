using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GettingStarted
{
    class Program
    {
        static void Main(string[] args)
        {
            // Reading from input
            string fullName = Console.ReadLine();

            // parsing string input to int
            string numberString = Console.ReadLine();
            int.TryParse(numberString, out int number);

            string dateTimeString = Console.ReadLine();

            if (!DateTime.TryParseExact(dateTimeString,
                "M/d/yyyy HH:mm",
                new CultureInfo("en-US"),
                DateTimeStyles.None,
                out DateTime dateTime))
            {
                dateTime = DateTime.Now;
            }

            // Writing to ouput
            Console.WriteLine(fullName);
            Console.WriteLine(numberString.ToString());
            Console.WriteLine(dateTimeString);

            string name = "Will";
            Console.WriteLine("Hello, {0}!", name);

        }
    }
}
