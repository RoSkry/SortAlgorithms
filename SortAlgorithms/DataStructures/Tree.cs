using System;
using System.Collections.Generic;
using System.Text;

namespace SortAlgorithms.DataStructures
{
    public class Tree<T> where T : IComparable, IComparable<T>
    {
        public Node<T> Root { get; private set; }
        public int Count { get; private set; }
        public Tree()
        {

        }
        public Tree(IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                Add(item);
            }
        }

        public void Add(T data)
        {
            var node = new Node<T>(data);

            if (Root == null)
            {
                Root = new Node<T>(data);
                Count = 1;
                return;
            }

            Root.Add(data);
            Count++;
        }

        public Node<T> Search(T data)
        {
            var current = Root;
            while (current.Data.CompareTo(data) != 0)
            {
                if (current.Data.CompareTo(data) == 1)
                    current = current.Left;
                else
                    current = current.Right;
                if (current == null)
                    return null;
            }
            return current;
        }

        public bool Remove(T data)
        {
            var current = Root;
            var parent = Root;
            bool isLeftChild = true;

            while (current.Data.CompareTo(data) != 0)
            {
                parent = current;
                if (data.CompareTo(current.Data) == -1)
                {
                    isLeftChild = true;
                    current = current.Left;
                }
                else
                {
                    isLeftChild = false;
                    current = current.Right;
                }
                if (current == null)
                    return false;
            }

            if (current.Left == null && current.Right == null)
            {
                if (current == Root)
                    Root = null;
                else if (isLeftChild)
                    parent.Left = null;
                else
                    parent.Right = null;
            }
            else if (current.Right == null)
            {
                if (current == Root)
                    Root = current.Left;
                else if (isLeftChild)
                    parent.Left = current.Left;
                else
                    parent.Right = current.Left;
            }
            else if (current.Left == null)
            {
                if (current == Root)
                    Root = current.Right;
                else if (isLeftChild)
                    parent.Left = current.Right;
                else
                    parent.Right = current.Right;
            }
            else
            {
                var successor = GetSuccessor(current);
                if (current == Root)
                {
                    Root = successor;
                }
                else if (isLeftChild)
                {
                    parent.Left = successor;
                }
                else
                {
                    parent.Right = successor;
                }
                successor.Left = current.Left;
            }
            return true;
        }

        private Node<T> GetSuccessor(Node<T> delNode)
        {
            var successorParent = delNode;
            var successor = delNode;
            var current = delNode.Right;
            while (current != null)
            {
                successorParent = successor;
                successor = current;
                current = current.Left;
            }
            if (successor != delNode.Right)
            {
                successorParent.Left = successor.Right;
                successor.Right = delNode.Right;
            }
            return successor;
        }

        public Node<T> Min()
        {
            Node<T> min = new Node<T>();
            var current = Root;
            while (current != null)
            {
                min = current;
                current = current.Left;
            }
            return min;

        }

        public Node<T> Max()
        {
            Node<T> max = new Node<T>();
            var current = Root;
            while (current != null)
            {
                max = current;
                current = current.Right;
            }
            return max;
        }



        public List<T> PreOrder()
        {
            if (Root == null)
            {
                return new List<T>();
            }

            return PreOrder(Root);
        }

        public List<T> PostOrder()
        {
            if (Root == null)
            {
                return new List<T>();
            }

            return PostOrder(Root);
        }

        public List<T> InOrder()
        {
            if (Root == null)
            {
                return new List<T>();
            }

            return InOrder(Root);
        }

        private List<T> PreOrder(Node<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                list.Add(node.Data);

                if (node.Left != null)
                {
                    list.AddRange(PreOrder(node.Left));
                }

                if (node.Right != null)
                {
                    list.AddRange(PreOrder(node.Right));
                }
            }
            return list;
        }

        private List<T> PostOrder(Node<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(PostOrder(node.Left));
                }

                if (node.Right != null)
                {
                    list.AddRange(PostOrder(node.Right));
                }

                list.Add(node.Data);
            }
            return list;
        }

        private List<T> InOrder(Node<T> node)
        {
            var list = new List<T>();
            if (node != null)
            {
                if (node.Left != null)
                {
                    list.AddRange(InOrder(node.Left));
                }

                list.Add(node.Data);

                if (node.Right != null)
                {
                    list.AddRange(InOrder(node.Right));
                }
            }
            return list;
        }
    }
}
