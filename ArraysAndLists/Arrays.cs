using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndLists
{
    public static class Arrays
    {
        static void Write()
        {
            // decalre single dimension to hold 12 months in a year
            string[] months = new string[12];

            // Iterate through all the months
            for (int month = 1; month <= 12; month++)
            {
                DateTime firstDay = new DateTime(DateTime.Now.Year, month, 1);
                string name = firstDay.ToString("MMMM", CultureInfo.CreateSpecificCulture("en"));
                months[month - 1] = name;
            }

            foreach (string month in months)
            {
                Console.WriteLine($"-> {month}");
            }

            // Declare two-dimensional array for our multiplication table
            int[,] results = new int[10, 10];

            for (int i = 0; i < results.GetLength(0); i++)
            {
                for (int j = 0; j < results.GetLength(1); j++)
                {
                    results[i, j] = (i + i) * (j + 1);
                    Console.Write("{0,4}", results[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
