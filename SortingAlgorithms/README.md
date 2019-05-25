# Sorting Algorithms

There are several algorithms that perform various operations on arrays. One of the most common tasks is sorting an array to arrange it elements in the correct order, either descending or ascending.

- Selection Sort
- Insertion Sort
- Bubble Sort
- Quicksort

## Selection Sort

This algorithm divides the array into two parts, namely sorted and unsorted.
In the following iterations, the algorithm finds the smalles element in the unsorted part and exchanges it with the first element in the unsorted part.

The Selection Sort is implemented in the following method:

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

Insertion sort divides the input array into two parts, namely sorted and unsorted.

However, at the beginning, the first element is includeed in the sorted part.

In each iteration, the algorithm takes the first element from the unsorted part and places it in a suitable location within the sorted part, to leave the sorted part in the correct order.

Such operations are repeated until the unsorted part is empty.

The Insertion Sort is implemented in the following method:

```csharp
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
```

## Bubble Sort

Bubble Sort just iterates through the array and compares adjacent elements.

If they are located in an incorrect order, they are swapped.

Sounds easy, but it's not very effificent and use with large collections could cause performance related problems.

The Bubble Sort is implemented in the following method:

```csharp
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
```

We can optimize Bubble Sort. This method is based on the assumption that comparisons should be stopped when no changes are discovered during one iteration through the array.

This method is implemented as follows:

```csharp
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
```

## Quicksort

Quicksort is one of the popular divide and conquer algorithms, which divides a problem into a set of smaller ones.

At the beginning, the algorithm picks some value as a pivot.

Then, it reorders the array in such a way that values lower or equal to the pivot are placed before it (the lower subarray)
Values greater than the pivot are placed after it (the higher subarray)

This is called partitioning.

Next, the algorithm recursively sorts each of the afore mentioned subarrays. Each subarray is further divided into the next two subarrays and so on.

The recursive calls stop when there are one or zero elements in a subarray, because there is nothing to sort.

This Quicksort implements two Sort() methods. The first one looks like this:

```csharp
public static void Sort<T>(T[] array) where T : IComparable
{
	Sort(array, 0, array.Length - 1);
}
```

This sort only takes the array to be sorted as a parameter. The second sort looks like this:

```csharp
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
```

This sort method takes the lower and upper indices that indicate which part of the array should be sorted.

It checks whether the array or subarray has at least two elements, by comparing the values of the lower and upper variables.

In this case, it will call the Partition() methdod, then calls the Sort() method recursively for two subarrays, namer lower and upper.

The Partition() method is shown here:

```csharp
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
```

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