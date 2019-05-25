using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    /// <summary>
    /// Very simple sorting algorithm
    /// Iterates through the array and compares adjacent elements.
    /// It they are located in an incorrect order, they are swapped.
    /// Not efficient and use with large collections could cause performance related problems.
    /// </summary>

    
    
    public static class BubbleSort
    {
        /// <summary>
        /// Two for loops are used, together with a comparison and a call of the Swap Method.
        /// </summary>
        public static void Sort<T>(T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        Swap(array, j, j + 1);
                    }
                }
            }
        }

        /// <summary>
        /// More optimized version of bubble sort.
        /// Based on the assumption that comparisons should be stopped when no changes are discovered during one iteration
        /// through the array.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        /// <returns></returns>
        public static T[] OptimizedSort<T>(T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length; i++)
            {
                bool isAnyChange = false;
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j].CompareTo(array[j + 1]) > 0)
                    {
                        isAnyChange = true;
                        Swap(array, j, j + 1);
                    }
                }
                if (!isAnyChange)
                {
                    break;
                }
            }
            return array;
        }

        private static void Swap<T>(T[] array, int first, int second) where T : IComparable
        {
            T temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}
