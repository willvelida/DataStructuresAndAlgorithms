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
        static void Main(string[] args)
        {
            // List of values to sort
            int[] integerValues = { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
            string[] stringValues = { "Mary", "Marcin", "Ann", "James", "George", "Nicole" };

            // Implement Selection Sort algorithms
            SelectionSort.Sort(integerValues);
            SelectionSort.Sort(stringValues);
            Console.WriteLine("Selection Sort results");
            Console.WriteLine(string.Join(" | ", integerValues));
            Console.WriteLine(string.Join(" | ", stringValues));

            // Implement Insertion Sort algorithms
            InsertionSort.Sort(integerValues);
            Console.WriteLine("Insertion Sort results");
            Console.WriteLine(string.Join(" | ", integerValues));

            // Implement Bubble Sort algorithms
            BubbleSort.Sort(integerValues);
            Console.WriteLine("Bubble Sort results");
            Console.WriteLine(string.Join(" | ", integerValues));
        }
    }
}
