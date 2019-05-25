using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingAlgorithms
{
    public class SelectionSort
    {

        /// <summary>
        /// Sort takes one parameter, the array that needs to be sorted.
        /// 
        /// Within the method, the for loop is used to iterate through the elements until only one item is left unsorted
        /// the number of iterations of the loop is equal to the length of the array - 1
        /// 
        /// In each iteration, another for loop is used to find the smallest value in the unsorted part
        /// as well as to store an index of the smallest value.
        /// 
        /// Then, the smallest element in the unsorted part is swapped with the first element of the unsorted part using Swap() 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array"></param>
        public static void Sort<T>(T[] array) where T : IComparable
        {
            for (int i = 0; i < array.Length -1; i++)
            {
                int minIndex = i;
                T minValue = array[i];
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j].CompareTo(minValue) < 0) 
                    {
                        minIndex = j;
                        minValue = array[j];
                    }
                }
                Swap(array, i, minIndex);
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
