using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DictionariesAndSets
{
    class Program
    {
        private static Random random = new Random();

        static void Main(string[] args)
        {
            PhoneBookHashTableSample();
            ProductLocationDictionarySample();
            UserDetailsDictionarySample();
            DefinitionsSortedDictionarySample();
            CouponsHashSetSample();
            SwimmingPoolsHashSetSample();
            RemovingDuplicatesSortedSetsSample();
        }

        public static void PhoneBookHashTableSample()
        {
            Hashtable phoneBook = new Hashtable()
            {
                {"Will Velida", "000-000-000" },
                {"John Smith", "111-111-111" }
            };

            phoneBook["Sarah Sims"] = "333-333-333";

            try
            {
                phoneBook.Add("Mary Fox", "222-222-222");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The entry already exists");
            }

            Console.WriteLine("Phone numbers:");
            if (phoneBook.Count == 0)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                foreach (DictionaryEntry entry in phoneBook)
                {
                    Console.WriteLine($" - {entry.Key}: {entry.Value}");
                }
            }

            Console.WriteLine();
            Console.Write("Search by name: ");
            string name = Console.ReadLine();
            if (phoneBook.Contains(name))
            {
                string number = (string)phoneBook[name];
                Console.WriteLine($"Foud phone number: {number}");
            }
            else
            {
                Console.WriteLine("The entry does not exist!");
            }
        }

        public static void ProductLocationDictionarySample()
        {
            Dictionary<string, string> products = new Dictionary<string, string>
            {
                {"59000000000", "A1" },
                {"59011111111", "B5" },
                {"59022222222", "C9" }
            };
            products["5903333333"] = "D7";

            try
            {
                products.Add("59044444444", "A3");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("The entry already exists");
            }

            Console.WriteLine("All products:");
            if (products.Count == 0)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                foreach (KeyValuePair<string, string> product in products)
                {
                    Console.WriteLine($" - {product.Key}: {product.Value}");
                }
            }

            Console.WriteLine();
            Console.Write("Search by barcode: ");
            string barcode = Console.ReadLine();
            if (products.TryGetValue(barcode, out string location))
            {
                Console.WriteLine($"The product is in the area {location}.");
            }
            else
            {
                Console.WriteLine("The product does not exist");
            }
        }

        public static void UserDetailsDictionarySample()
        {
            Dictionary<int, Employee> employees = new Dictionary<int, Employee>();

            employees.Add(100, new Employee() { FirstName = "Will", LastName = "Velida", PhoneNumber = "000-000-000" });
            employees.Add(210, new Employee() { FirstName = "James", LastName = "Liams", PhoneNumber = "111-111-111" });
            employees.Add(303, new Employee() { FirstName = "Sarah", LastName = "Michaels", PhoneNumber = "222-222-222" });

            bool isCorrect = true;
            do
            {
                Console.Write("Enter the employee identifier: ");
                string idString = Console.ReadLine();
                isCorrect = int.TryParse(idString, out int id);
                if (isCorrect)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    if (employees.TryGetValue(id, out Employee employee))
                    {
                        Console.WriteLine($"First name: {1}{0} Last name: {2}{0}Phone number: {3}",
                        Environment.NewLine,
                        employee.FirstName,
                        employee.LastName,
                        employee.PhoneNumber);
                    }
                    else
                    {
                        Console.WriteLine("The employee with the given identifier does not exist.");
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            } while (isCorrect);
        }

        public static void DefinitionsSortedDictionarySample()
        {
            SortedDictionary<string, string> definitions = new SortedDictionary<string, string>();

            do
            {
                Console.Write("Choose an option ([a] - add. [l] - list): ");
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                Console.WriteLine();
                if (keyInfo.Key == ConsoleKey.A)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write("Enter the name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter the explanation: ");
                    string explanation = Console.ReadLine();
                    definitions[name] = explanation;
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (keyInfo.Key == ConsoleKey.L)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    foreach (KeyValuePair<string, string> definition in definitions)
                    {
                        Console.WriteLine($"{definition.Key}:{definition.Value}");
                    }
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Do you want to exit the program? Press [y] (yes) or [n] (no).");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    if (Console.ReadKey().Key == ConsoleKey.Y)
                    {
                        break;
                    }
                }
            } while (true);
        }

        public static void CouponsHashSetSample()
        {
            HashSet<int> usedCoupons = new HashSet<int>();

            do
            {
                Console.Write("Enter the coupon number: ");
                string couponString = Console.ReadLine();
                if (int.TryParse(couponString, out int coupon))
                {
                    if (usedCoupons.Contains(coupon))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("It has been already used :-(");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        usedCoupons.Add(coupon);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Thank you! :-)");
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                }
                else
                {
                    break;
                }
            } while (true);

            Console.WriteLine();
            Console.WriteLine("A list of used coupons:");
            foreach (int coupon in usedCoupons)
            {
                Console.WriteLine(coupon);
            }
        }

        public static void SwimmingPoolsHashSetSample()
        {
            Dictionary<PoolTypeEnum, HashSet<int>> tickets = new Dictionary<PoolTypeEnum, HashSet<int>>()
            {
                { PoolTypeEnum.RECREATION, new HashSet<int>() },
                { PoolTypeEnum.COMPETITION, new HashSet<int>() },
                { PoolTypeEnum.THERMAL, new HashSet<int>() },
                { PoolTypeEnum.KIDS, new HashSet<int>() }
            };

            for (int i = 1; i < 100; i++)
            {
                foreach (KeyValuePair<PoolTypeEnum, HashSet<int>> type in tickets)
                {
                    if (GetRandomBoolean())
                    {
                        type.Value.Add(i);
                    }
                }
            }

            Console.WriteLine("Number of visitors by a pool type:");
            foreach (KeyValuePair<PoolTypeEnum, HashSet<int>> type in tickets)
            {
                Console.WriteLine($" - {type.Key.ToString().ToLower()}:{type.Value.Count}");
            }

            PoolTypeEnum maxVisitors = tickets
                .OrderByDescending(t => t.Value.Count)
                .Select(t => t.Key)
                .FirstOrDefault();

            Console.WriteLine($"Pool '{maxVisitors.ToString().ToLower()}' was the most popular.");

            HashSet<int> any = new HashSet<int>(tickets[PoolTypeEnum.RECREATION]);

            any.UnionWith(tickets[PoolTypeEnum.COMPETITION]);
            any.UnionWith(tickets[PoolTypeEnum.THERMAL]);
            any.UnionWith(tickets[PoolTypeEnum.KIDS]);

            Console.WriteLine($"{any.Count} people visited at least one pool.");

            HashSet<int> all = new HashSet<int>(tickets[PoolTypeEnum.RECREATION]);

            all.IntersectWith(tickets[PoolTypeEnum.COMPETITION]);
            all.IntersectWith(tickets[PoolTypeEnum.THERMAL]);
            all.IntersectWith(tickets[PoolTypeEnum.KIDS]);

            Console.WriteLine($"{all.Count} people visited all pools.");
        }

        private static bool GetRandomBoolean()
        {
            return random.Next(2) == 1;
        }

        public enum PoolTypeEnum
        {
            RECREATION,
            COMPETITION,
            THERMAL,
            KIDS
        }

        public static void RemovingDuplicatesSortedSetsSample()
        {
            List<string> names = new List<string>()
            {
                "Will",
                "Mary",
                "James",
                "Albert",
                "Lily",
                "Emily",
                "Jane"
            };

            SortedSet<string> sorted = new SortedSet<string>(names, Comparer<string>.Create((a, b) =>
            a.ToLower().CompareTo(b.ToLower())));

            foreach (string name in sorted)
            {
                Console.WriteLine(name);
            }
        }
    }
}
