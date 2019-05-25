using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SimpleLists
{
    class Program
    {
        
        static void Main(string[] args)
        {
            RunArrayListExample();
            
            ListOfPeopleExample();

            AddressBookExample();

            BookReaderExample();

            SpinTheWheelExample();

            Console.ReadLine();

            AverageValueExample();
        }

        public static void RunArrayListExample()
        {
            ArrayList arrayList = new ArrayList();
            arrayList.Add(5);
            arrayList.AddRange(new int[] { 6, -7, 8 });
            arrayList.AddRange(new object[] { "Marcin", "Mary" });
            arrayList.Insert(5, 7.8);

            object first = arrayList[0];
            int third = (int)arrayList[2];

            int count = arrayList.Count;
            int capacity = arrayList.Capacity;

            bool containsMary = arrayList.Contains("Mary");

            foreach (object element in arrayList)
            {
                Console.WriteLine(element);
            }

            arrayList.Remove(5);

            foreach (object element in arrayList)
            {
                Console.WriteLine(element);
            }
        }

        public static void AverageValueExample()
        {
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
        }

        public static void ListOfPeopleExample()
        {
            List<Person> people = new List<Person>();

            people.Add(new Person() { Name = "Will", Country = CountryEnum.UK, Age = 28 });
            people.Add(new Person() { Name = "Alex", Country = CountryEnum.DE, Age = 45 });
            people.Add(new Person() { Name = "Sarah", Country = CountryEnum.PL, Age = 32 });

            List<Person> results = people.OrderBy(p => p.Name).ToList();

            foreach (Person person in results)
            {
                Console.WriteLine($"{person.Name} ({person.Age} years old from {person.Country}.");
            }
        }

        public static void AddressBookExample()
        {
            SortedList<string, Person> people = new SortedList<string, Person>();

            people.Add("Marcin", new Person() { Name = "Marcin", Country = CountryEnum.PL, Age = 29 });
            people.Add("Sabine", new Person() { Name = "Sabine", Country = CountryEnum.DE, Age = 25 });
            people.Add("Ann", new Person() { Name = "Ann", Country = CountryEnum.PL, Age = 31 });

            foreach (KeyValuePair<string, Person> person in people)
            {
                Console.WriteLine($"{person.Value.Name} ({person.Value.Age} years) from {person.Value.Country}");
            }
        }

        public static void BookReaderExample()
        {
            Page pageFirst = new Page() { Content = "Nowadays...." };
            Page pageSecond = new Page() { Content = "Applications ...." };
            Page pageThird = new Page() { Content = "A lot of ...." };
            Page pageFourth = new Page() { Content = "Do you know ...." };
            Page pageFifth = new Page() { Content = "While it ...." };
            Page pageSixth = new Page() { Content = "Could you please ...." };

            LinkedList<Page> pages = new LinkedList<Page>();
            pages.AddLast(pageSecond);
            LinkedListNode<Page> nodePageFourth = pages.AddLast(pageFourth);
            pages.AddLast(pageSixth);
            pages.AddFirst(pageFirst);
            pages.AddBefore(nodePageFourth, pageThird);
            pages.AddAfter(nodePageFourth, pageFifth);

            LinkedListNode<Page> current = pages.First;
            int number = 1;
            while (current != null)
            {
                Console.Clear();
                string numberString = $"- {number} -";
                int leadingSpaces = (90 - numberString.Length) / 2;
                Console.WriteLine(numberString.PadLeft(leadingSpaces + numberString.Length));
                Console.WriteLine();

                string content = current.Value.Content;
                for (int i = 0; i < content.Length; i += 90)
                {
                    string line = content.Substring(i);
                    line = line.Length > 90 ? line.Substring(0, 90) : line;
                    Console.WriteLine(line);
                }

                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine(current.Previous != null ? "< Previous [P]" : GetSpaces(14));
                Console.WriteLine(current.Next != null ? "[N] Next >".PadLeft(76) : string.Empty);
                Console.WriteLine();

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.N:
                        if (current.Next != null)
                        {
                            current = current.Next;
                            number++;
                        }
                        break;
                    case ConsoleKey.P:
                        if (current.Previous != null)
                        {
                            current = current.Previous;
                            number--;
                        }
                        break;
                    default:
                        return;
                }
            }
        }

        private static string GetSpaces(int number)
        {
            string result = string.Empty;
            for (int i = 0; i < number; i++)
            {
                result += " ";
            }
            return result;
        }

        private static void SpinTheWheelExample()
        {
            CircularLinkedList<string> categories = new CircularLinkedList<string>();
            categories.AddLast("Sport");
            categories.AddLast("Culture");
            categories.AddLast("History");
            categories.AddLast("Geography");
            categories.AddLast("People");
            categories.AddLast("Technology");
            categories.AddLast("Nature");
            categories.AddLast("Science");

            Random random = new Random();
            int totalTime = 0;
            int remainingTime = 0;
            foreach (string category in categories)
            {
                if (remainingTime <= 0)
                {
                    Console.WriteLine("Press [Enter] to start or any other to exit");
                    switch (Console.ReadKey().Key)
                    {
                        case ConsoleKey.Enter:
                            totalTime = random.Next(1000, 5000);
                            remainingTime = totalTime;
                            break;
                        default:
                            return;
                    }
                }

                int categoryTime = (-450 * remainingTime) / (totalTime - 50) + 500 + (22500 / (totalTime - 50));
                remainingTime -= categoryTime;
                Thread.Sleep(categoryTime);

                Console.ForegroundColor = remainingTime <= 0 ? ConsoleColor.Red : ConsoleColor.Gray;
                Console.WriteLine(category);
                Console.ForegroundColor = ConsoleColor.Gray;
            }
        }
    }
}
