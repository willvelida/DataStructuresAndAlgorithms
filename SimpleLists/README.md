# Simple Lists

In this project we will discuss

- Array List

## Array List

You can use ArrayList to store big collections of data, to which you can easily add new elements when necessary.

You can also remove them, count items and find a index of a particular value stored within the array list.

For example

```csharp
ArrayList arrayList = new ArrayList();
arrayList.Add(5);
arrayList.AddRange(new int[] { 6, -7, 8 });
arrayList.AddRange(new object[] { "Marcin", "Mary" });
arrayList.Insert(5, 7.8);
```

In the first ine, a new instance of the ArrayList class is created.
Then we ca use Add, AddRange and Insert meethods to add new elements to the array list.

We can also access a element within the array list using the index as follows:

```csharp
object first = arrayList[0];
int third = (int)arrayList[2];
```

And we can iterate through the items as follows:

```csharp
foreach (object element in arrayList)
{
	Console.WriteLine(element);
}
```

To remove elements from an ArrayList, we can use Remove, RemoveAt or RemoveRange.

## Generic List

A drawback of the ArrayList is that it is not a strongly typed list. If we want a strongly typed list, we can use the generic List class representing the collection.

With Generic List, we can use the System.Linq namespace for using a comprehensive set of extension methods.

Let's have a look at some examples:

```csharp
List<double> numbers = new List<double>();

do
{
	Console.WriteLine("Enter the number: ");
	string numberString = Console.ReadLine();
	if (!double.TryParse(numberString, NumberStyles.Float, new NumberFormatInfo(), out double number))
	{
		break;
	}

	numbers.Add(number);
	Console.WriteLine($"The average value: {numbers.Average()}");
} while (true);
```

First, we create a instance of the List class.
Then we create an infinite loop that waits until the user enters the number.
If correct, the entered value is added to the list (by calling Add) and the average value is calcuated and shown.

## Sorted Lists