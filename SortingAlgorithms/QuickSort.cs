using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{

    /// <summary>
    /// At the beginning, quicksort picks are value as a PIVOT
    /// Then, it reorders the array in such a way that values lower than or equal to the pivot are placed before it
    /// while values greater than the pivot are placed after it.
    /// This is called PARTITIONING.
    /// Next, the algorithm recursively sorts each of the afore mentioned subarrays.
    /// Each sub array is further divided into the next two subarrays, and so on.
    /// This stops when there are one or zero elements in a subarray.
    /// </summary>

    public static class QuickSort
    {
        /// <summary>
        /// Contains two variants of the Sort method.
        /// This one takes only an array that should be sorted.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public static void Sort<T>(T[] array) where T : IComparable
        {
            Sort(array, 0, array.Length - 1);
        }

        /// <summary>
        /// This sort specifies the lower and upper indices that indicate which part of the array should be sorted.
        /// This checks whether the array has at least two elements by comparing the values of the lower and upper variables.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <param name="lower"></param>
        /// <param name="upper"></param>
        /// <returns></returns>
        private static T[] Sort<T>(T[] array, int lower, int upper) where T : IComparable
        {
            if (lower < upper)
            {
                int p = Partition(array, lower, upper);
                Sort(array, lower, p);
                Sort(array, p + 1, upper);
            }
            return array;
        }

        
        private static int Partition<T>(T[] array, int lower, int upper) where T : IComparable
        {
            int i = lower;
            int j = upper;
            T pivot = array[lower];
            // or: T pivot = array[(lower + upper) / 2];
            do
            {
                while (array[i].CompareTo(pivot) < 0) { i++; }
                while (array[j].CompareTo(pivot) > 0) { j--; }
                if (i >= j) { break; }
                Swap(array, i, j);
            }
            while (i <= j);
            return j;
        }

        private static void Swap<T>(T[] array, int first, int second) where T : IComparable
        {
            T temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}
