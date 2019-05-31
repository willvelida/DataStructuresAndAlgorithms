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

SortedList (from Systems.Collections.Generic) is a collection of key-value pairs sorted by keys. Meaning we don't have to sort them on our own.

All keys must be unique and cannot equal null.

You can add an element using the Add method and remove a item using the Remove method.

ContainsKey and ContainsValue exist for checking whether a collection contains an item with a given key or value within the collection.

You also have access to Keys and Values properties. These can be obtained using the index and the [] operator

## Linked List

Wouldn't it be great if we had a list that had some kind of pointer to the next element.

With this approach, we can easily navigate from one element to the next one using the Next property (Single-linked list)

It can be further expanded by adding the Previous property to allow navigating in forward and backward directions (Double-linked list)

The double-linked list contains the First property that indicates the first element in the list. Each item has two properties that point to the previous and next element

If there is no previous element, the Previous property is equal to null. This is the same case for Next.

Double link list also contains Last and First (when there are no items in the list, these are set to null)

## Circular-linked lists

We can expand Linked Lists by creating circular-linked list.

let's look at some code for a explanation

```csharp
public class CircularLinkedList<T> : LinkedList<T>
{

	public new IEnumerator GetEnumerator()
	{
		return new CircularLinkedListEnumerator<T>(this);
	}
}
```

This is a generic class that extends LinkedList. It is worth mentioning the implementation of GetEnumerator method, which uses the CircularLinkedListEnumerator.

By creating it, we will be able to indefinitely iterate through all the elements of the circular linked list, using the foreach loop.

The code of the CircularLinkedListEnumerator class is as follows:

```csharp
public class CircularLinkedListEnumerator<T> : IEnumerator<T>
{
	private LinkedListNode<T> _current;
	public T Current => _current.Value;
	object IEnumerator.Current => Current;

	public CircularLinkedListEnumerator(CircularLinkedList<T> list)
	{
		_current = list.First;
	}

	public void Dispose()
	{
			
	}

	public bool MoveNext()
	{
		if (_current == null)
		{
			return false;
		}

		_current = _current.Next ?? _current.List.First;
		return true;
	}

	public void Reset()
	{
		_current = _current.List.First;
	}
}
```

This class implements the IEnumerator interface. The class declares the private field representing the current node in the iteration over the list.

It also contains two properties, namely Current and IEnumerator.Current, which is required by the IEnumerator interface.

The constructor sets a vlaue of the _current variable, based on an instance of the LinkedList class, passed as the parameter.

MoveNext stops iterating when the _current variable is equal to null (no items in the list).

Otherwise, it changes the current element to the next one or to the first node in the list, if the next node is unavailable.

In the Reset method, you just set a value of the _current field to the first node in the list.

At the end, we create two extension methods that make it possible to navigate to the first element while trying to get the next element from the last item in the list, as well as to navigate to the last element while trying to get the previous element from the first item in the list.

To simplify this, we use Next and Previous methods, instead of properties. See the code below:

```csharp
public static class CircularLinkedListExtensions
{
	public static LinkedListNode<T> Next<T>(this LinkedListNode<T> node)
	{
		if (node != null && node.List != null)
		{
			return node.Next ?? node.List.First;
		}
		return null;
	}

	public static LinkedListNode<T> Previous<T>(this LinkedListNode<T> node)
	{
		if (node != null && node.List != null)
		{
			return node.Previous ?? node.List.Last;
		}
		return null;
	}
}
```

Next, checks whether the node exists and whether the list is available. In this case, it returns a value of the Next property of the node or returns a reference to the first element in the list, using First.