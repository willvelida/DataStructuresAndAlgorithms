using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraysAndLists
{
    class Program
    {
        public static void Main(string[] args)
        {
            SingleDimensionArrays();
            MultiDimensionArrays();
            Console.ReadLine();
        }

        public static void SingleDimensionArrays()
        {
            string[] months = new string[12];

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
        }

        public static void MultiDimensionArrays()
        {
            int[,] results = new int[10, 10];

            for (int i = 0; i < results.GetLength(0); i++)
            {
                for (int j = 0; j < results.GetLength(1); j++)
                {
                    results[i, j] = (i + 1) * (j + 1);
                }
            }

            for (int i = 0; i < results.GetLength(0); i++)
            {
                for (int j = 0; j < results.GetLength(1); j++)
                {
                    Console.Write("{0,4}", results[i, j]);
                }
                Console.WriteLine();
            }
        }

    }
}
