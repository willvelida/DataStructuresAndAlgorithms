using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    class Program
    {
        static void Main(string[] args)
        {
            // Arrays to sort
            int[] integerValues = { -11, 12, -42, 0, 1, 90, 68, 6, -9 };
            string[] stringValues = { "Mary", "Marcin", "Ann", "James", "George", "Nicole" };

            // Apply methods here
            SelectionSort.Sort(integerValues);
            SelectionSort.Sort(stringValues);
            InsertionSort.Sort(integerValues);
            BubbleSort.Sort(integerValues);
            QuickSort.Sort(integerValues);

            // Read output here
            Console.WriteLine(string.Join(" | ", integerValues));
            Console.WriteLine(string.Join(" | ", stringValues));
            Console.ReadLine();
        }
    }
}
