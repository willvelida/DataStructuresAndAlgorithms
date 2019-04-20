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
            Arrays.Write();

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

            // List of people
            List<Person> people = new List<Person>();
            people.Add(new Person() { Name = "Will", Country = CountryEnum.UK, Age = 28 });
            people.Add(new Person() { Name = "James", Country = CountryEnum.PL, Age = 19 });
            people.Add(new Person() { Name = "Clair", Country = CountryEnum.DE, Age = 48 });

            // Sort the list by names of poeple in ascending order
            List<Person> results = people.OrderBy(p => p.Name).ToList();

            // Iterate through the list
            foreach (Person person in results)
            {
                Console.WriteLine($"{person.Name} ({person.Age} years) from {person.Country}.");
            }

            

            List<double> numbers = new List<double>();
            do
            {
                Console.WriteLine("Enter a number!");
                string numberString = Console.ReadLine();
                if (!double.TryParse(numberString, NumberStyles.Float, new NumberFormatInfo(), out double number))
                {
                    break;
                }
                numbers.Add(number);
                Console.WriteLine($"The average value: {numbers.Average()}");
            } while (true);

            
        }
    }
}
