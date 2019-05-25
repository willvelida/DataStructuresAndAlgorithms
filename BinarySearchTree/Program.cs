using System;
using System.Linq;
using System.Text;

namespace BinarySearchTree
{
    class Program
    {

        private const int COLUMN_WIDTH = 5;

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;

            BinarySearchTree<int> tree = new BinarySearchTree<int>();

            tree.Root = new BinaryTreeNode<int>() { Data = 100 };
            tree.Root.Left = new BinaryTreeNode<int>()
            { Data = 50, Parent = tree.Root };
            tree.Root.Right = new BinaryTreeNode<int>()
            { Data = 150, Parent = tree.Root };
            tree.Count = 3;
            VisualizeTree(tree, "The BST with three nodes (50, 100, 150):");

            tree.Add(75);
            tree.Add(125);
            VisualizeTree(tree, "The BST after adding two nodes (75, 125):");

            tree.Remove(25);
            VisualizeTree(tree, "The BST after removing the node 25:");

            Console.Write("Pre-order traversal:\t");
            Console.Write(string.Join(", ", tree.Traverse(BinaryTree<int>.TraversalEnum.PREORDER).Select(n => n.Data)));
            Console.Write("In-order traversal:\t");
            Console.Write(string.Join(", ", tree.Traverse(BinaryTree<int>.TraversalEnum.INORDER).Select(n => n.Data)));
            Console.Write("Post-order traversal:\t");
            Console.Write(string.Join(", ", tree.Traverse(BinaryTree<int>.TraversalEnum.POSTORDER).Select(n => n.Data)));
        }

        private static void VisualizeTree(BinarySearchTree<int> tree, string caption)
        {
            char[][] console = InitializeVisualization(tree, out int width);
            VisualizeNode(tree.Root, 0, width / 2, console, width);
            Console.WriteLine(caption);
            foreach (char[] row in console)
            {
                Console.WriteLine(row);
            }
        }

        private static char[][] InitializeVisualization(BinarySearchTree<int> tree, out int width)
        {
            int height = tree.GetHeight();
            width = (int)Math.Pow(2, height) - 1;
            char[][] console = new char[height * 2][];
            for (int i = 0; i < height * 2; i++)
            {
                console[i] = new char[COLUMN_WIDTH * width];
            }
            return console;
        }

        private static void VisualizeNode(BinaryTreeNode<int> node, int row, int column, char[][] console, int width)
        {
            if (node != null)
            {
                char[] chars = node.Data.ToString().ToCharArray();
                int margin = (COLUMN_WIDTH - chars.Length) / 2;
                for (int i = 0; i < chars.Length; i++)
                {
                    console[row][COLUMN_WIDTH * column + i + margin] = chars[i];
                }

                int columnDelta = (width + 1) / (int)Math.Pow(2, node.GetHeight() + 1);
                VisualizeNode(node.Left, row + 2, column - columnDelta, console, width);
                VisualizeNode(node.Right, row + 2, column + columnDelta, console, width);
                DrawLineLeft(node, row, column, console, columnDelta);
                DrawLineRight(node, row, column, console, columnDelta);
            }
        }

        private static void DrawLineLeft(BinaryTreeNode<int> node, int row, int column, char[][] console, int columnDelta)
        {
            if (node.Left != null)
            {
                int startColumnIndex = COLUMN_WIDTH * (column - columnDelta) + 2;
                int endColumnIndex = COLUMN_WIDTH * column + 2;
                for (int x = startColumnIndex + 1; x < endColumnIndex; x++)
                {
                    console[row + 1][x] = '-';
                }
                console[row + 1][startColumnIndex] = '\u250c';
                console[row + 1][endColumnIndex] = '+';
            }
        }

        private static void DrawLineRight(BinaryTreeNode<int> node, int row, int column, char[][] console, int columnDelta)
        {
            if (node.Right != null)
            {
                int startColumnIndex = COLUMN_WIDTH * column + 2;
                int endColumnIndex = COLUMN_WIDTH * (column + columnDelta) + 2;
                for (int x = startColumnIndex + 1; x < endColumnIndex; x++)
                {
                    console[row + 1][x] = '-';
                }
                console[row + 1][startColumnIndex] = '+';
                console[row + 1][endColumnIndex] = '\u2510';
            }
        }
    }
}
