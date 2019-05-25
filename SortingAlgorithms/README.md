# Sorting Algorithms

There are several algorithms that perform various operations on arrays. One of the most common tasks is sorting an array to arrange it elements in the correct order, either descending or ascending.

- Selection Sort
- Insertion Sort
- Bubble Sort
- Quicksort

## Selection Sort

This algorithm divides the array into two parts, namely sorted and unsorted.
In the following iterations, the algorithm finds the smalles element in the unsorted part and exchanges it with the first element in the unsorted part.

The Selection Sort is implemented in the following class:

```csharp
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
```

## Insertion Sort

## Bubble Sort

## Quicksort

## Generic Swap method

Each Sorting Algorithm implements the following Swap() helper method:

```csharp
		private static void Swap<T>(T[] array, int first, int second) where T : IComparable
		{
			T temp = array[first];
			array[first] = array[second];
			array[second] = temp;
		}
```