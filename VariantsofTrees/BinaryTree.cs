using System;
using System.Collections.Generic;
using System.Text;

namespace BinarySearchTree
{
    public class BinaryTree<T>
    {
        public BinaryTreeNode<T> Root { get; set; }
        public int Count { get; set; }

        private void TraversePreOder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> result)
        {
            if (node != null)
            {
                result.Add(node);
                TraversePreOder(node.Left, result);
                TraversePreOder(node.Right, result);
            }
        }

        private void TraverseInOrder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> result)
        {
            if (node != null)
            {
                TraverseInOrder(node.Left, result);
                result.Add(node);
                TraverseInOrder(node.Right, result);
            }
        }

        private void TraversePostOrder(BinaryTreeNode<T> node, List<BinaryTreeNode<T>> result)
        {
            if (node != null)
            {
                TraversePostOrder(node.Left, result);
                TraversePostOrder(node.Right, result);
                result.Add(node);
            }
        }

        public List<BinaryTreeNode<T>> Traverse(TraversalEnum mode)
        {
            List<BinaryTreeNode<T>> nodes = new List<BinaryTreeNode<T>>();
            switch (mode)
            {
                case TraversalEnum.PREORDER:
                    TraversePreOder(Root, nodes);
                    break;
                case TraversalEnum.INORDER:
                    TraverseInOrder(Root, nodes);
                    break;
                case TraversalEnum.POSTORDER:
                    TraversePostOrder(Root, nodes);
                    break;
                default:
                    break;
            }
            return nodes;
        }

        public enum TraversalEnum
        {
            PREORDER,
            INORDER,
            POSTORDER
        }

        public int GetHeight()
        {
            int height = 0;
            foreach (BinaryTreeNode<T> node in Traverse(TraversalEnum.PREORDER))
            {
                height = Math.Max(height, node.GetHeight());
            }
            return height;
        }
    }
}
