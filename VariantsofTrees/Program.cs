using DIBRIS.Hippie;
using System;
using System.Collections.Generic;
using TreeLib;

namespace BinarySearchTree
{
    class Program
    {
        static void Main(string[] args)
        {
            HeapSortSample();
        }

        public static void HierarchyOfIdentifiersSample()
        {
            Tree<int> tree = new Tree<int>();
            tree.Root = new TreeNode<int>() { Data = 100 };
            tree.Root.Children = new List<TreeNode<int>>
            {
                new TreeNode<int>() {Data = 50, Parent = tree.Root},
                new TreeNode<int>() {Data = 1, Parent = tree.Root},
                new TreeNode<int>() {Data = 150, Parent = tree.Root}
            };
            tree.Root.Children[2].Children = new List<TreeNode<int>>()
            {
                new TreeNode<int>()
                {
                    Data = 30, Parent = tree.Root.Children[2]
                }
            };
        }

        public static void CompanyStructureSample()
        {
            Tree<Person> company = new Tree<Person>();

            company.Root = new TreeNode<Person>()
            {
                Data = new Person(100, "Marcin Jamro", "CEO"),
                Parent = null
            };

            company.Root.Children = new List<TreeNode<Person>>()
            {
                new TreeNode<Person>()
                {
                    Data = new Person(1, "John Smith", "Head of Development"),
                    Parent = company.Root
                },
                new TreeNode<Person>()
                {
                    Data = new Person(50, "Mary Fox", "Head of Research"),
                    Parent = company.Root
                },
                new TreeNode<Person>()
                {
                    Data = new Person(150, "Lily Smith", "Head of Sales"),
                    Parent = company.Root
                }
            };

            company.Root.Children[2].Children = new List<TreeNode<Person>>()
            {
                new TreeNode<Person>()
                {
                    Data = new Person(30, "Anthony Black", "Sales Specialist"),
                    Parent = company.Root.Children[2]
                }
            };
        }

        public static void SimpleQuizBinaryTreeSample()
        {
            BinaryTree<QuizItem> tree = GetTree();
            BinaryTreeNode<QuizItem> node = tree.Root;

            while (node != null)
            {
                if (node.Left != null || node.Right != null)
                {
                    Console.Write(node.Data.Text);
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.Y:
                            WriteAnswer(" Yes");
                            node = node.Left;
                            break;
                        case ConsoleKey.N:
                            WriteAnswer(" No");
                            node = node.Right;
                            break;
                    }
                }
                else
                {
                    WriteAnswer(node.Data.Text);
                    node = null;
                }
            }
        }

        private static BinaryTree<QuizItem> GetTree()
        {
            BinaryTree<QuizItem> tree = new BinaryTree<QuizItem>();
            tree.Root = new BinaryTreeNode<QuizItem>()
            {
                Data = new QuizItem("Do you have experience in developing applications?"),
                Children = new List<TreeNode<QuizItem>>()
                {
                    new BinaryTreeNode<QuizItem>()
                    {
                        Data = new QuizItem("Have you worked as a developer for more than 5 years?"),
                        Children = new List<TreeNode<QuizItem>>()
                        {
                            new BinaryTreeNode<QuizItem>()
                            {
                                Data = new QuizItem("Apply as a senior developer!")
                            },
                            new BinaryTreeNode<QuizItem>()
                            {
                                Data = new QuizItem("Apply as a middle developer!")
                            }
                        }
                    },
                    new BinaryTreeNode<QuizItem>()
                    {
                        Data = new QuizItem("Have you completed University?"),
                        Children = new List<TreeNode<QuizItem>>()
                        {
                            new BinaryTreeNode<QuizItem>()
                            {
                                Data = new QuizItem("Apply as a junior developer!")
                            },
                            new BinaryTreeNode<QuizItem>()
                            {
                                Data = new QuizItem("Will you have time during semester?"),
                                Children = new List<TreeNode<QuizItem>>()
                                {
                                    new BinaryTreeNode<QuizItem>()
                                    {
                                        Data = new QuizItem("Apply for our long-term internship program!")
                                    },
                                    new BinaryTreeNode<QuizItem>()
                                    {
                                        Data = new QuizItem("Apply for our summer program!")
                                    }
                            }
                        }
                        }
                    }
                }

            };
            tree.Count = 9;
            return tree;

        }

        private static void WriteAnswer(string text)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public void RBTrelatedFeaturesSample()
        {
            RedBlackTreeList<int> tree = new RedBlackTreeList<int>();

            for (int i = 1; i <= 10; i++)
            {
                tree.Add(i);
            }
            tree.Remove(9);

            bool contains = tree.ContainsKey(5);
            Console.WriteLine("Does value exist? " + (contains ? "yes" : "no"));

            uint count = tree.Count;
            tree.Greatest(out int greatest);
            tree.Least(out int least);
            Console.WriteLine($"{count} elements in the range {least}-{greatest}");
            Console.WriteLine("Values: " + string.Join(", ", tree.GetEnumerable()));

            foreach (EntryList<int> node in tree)
            {
                Console.WriteLine(node + " ");
            }
        }

        public static void HeapSortSample()
        {
            List<int> unsorted = new List<int>() { 50, 33, 78, -23, 90, 41 };
            MultiHeap<int> heap = HeapFactory.NewBinaryHeap<int>();

            unsorted.ForEach(i => heap.Add(i));

            Console.WriteLine("Unsorted: " + string.Join(", ", unsorted));

            List<int> sorted = new List<int>(heap.Count);
            while (heap.Count > 0)
            {
                sorted.Add(heap.RemoveMin());
            }
            Console.WriteLine("Sorted: " + string.Join(", ", sorted));
        }

    }
}
