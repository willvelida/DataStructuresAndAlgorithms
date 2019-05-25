using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public static class InsertionSort
    {
        /// <summary>
        /// Within this method, the for loop is used to iterate through all elements in the unsorted part.
        /// The inital value is set to 1
        /// In each iteration of the for loop, the while loop is executed to move the first element from the unsorted part
        /// of the array to the correct location within the sorted part, using Swap
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public static void Sort<T>(T[] array) where T : IComparable
        {
            for (int i = 1; i < array.Length; i++)
            {
                int j = i;
                while (j > 0 && array[j].CompareTo(array[j - 1]) < 0)
                {
                    Swap(array, j, j - 1);
                    j--;
                }
            }
        }

        private static void Swap<T>(T[] array, int first, int second) where T : IComparable
        {
            T temp = array[first];
            array[first] = array[second];
            array[second] = temp;
        }
    }
}
