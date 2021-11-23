using System;
using System.Collections.Generic;

namespace DataStructures
{
	public class BinarySearchTree<T> where T : IComparable
	{
	private class Node
		{
			public T data;
			public Node left;
			public Node right;

			public Node(T data)
			{
				this.data = data;
			}
		}

		private Node root = null;

		public BinarySearchTree()
		{}

		~BinarySearchTree()
		{}

		public T Min()
		{
			return Min(root).data;
		}

		public T Max()
		{
			return Max(root).data;
		}

		public void Clear()
		{
			Clear(root);
			root = null;
		}

		public bool Empty()
		{
			return (root == null) ? true : false;
		}

		public bool Contains(T data)
		{
			return (NodePointer(root, data) != null) ? true : false;
		}

		public void Insert(T data)
		{
			Insert(root, data);
		}

		public void Delete(T data)
		{
			Node node = NodePointer(root, data);
			Node successor = Successor(NodePointer(root, data));
			Node parent = (node != root) ? ParentPointer(root, data) : null;
			Node successorParent = (successor != null) ? ParentPointer(root, successor.data) : null;

			if(parent != null && node == parent.left) parent.left = successor;
			if(parent != null && node == parent.right) parent.right = successor;
			if(successorParent != null && successorParent.left == successor) successorParent.left = null;
			if(successorParent != null && successorParent.right == successor) successorParent.right = null;
			if(node.left != null && node.left != successor && successor.left == null) successor.left = node.left;
			if(node.right != null && node.right != successor && successor.right == null) successor.right = node.right;
			if(node == root) root = successor;
		}

		public List<T> DepthFirstSearchInOrder()
		{
			List<T> array = new List<T>();

			if(Empty() == false) TraverseInOrder(root, array);

			return array;
		}

		public List<T> DepthFirstSearchPreOrder()
		{
			List<T> array = new List<T>();

			if(Empty() == false) TraversePreOrder(root, array);

			return array;
		}

		public List<T> DepthFirstSearchPostOrder()
		{
			List<T> array = new List<T>();

			if(Empty() == false) TraversePostOrder(root, array);

			return array;
		}

		public List<T> BreadthFirstSearch()
		{
			Node node = root;
			List<T> array = new List<T>();

			if(Empty() == true) return array;

			Queue<Node> queue = new Queue<Node>();
			queue.Enqueue(node);

			while(queue.Count > 0)
			{
				node = queue.Peek();
				queue.Dequeue();
				array.Add(node.data);

				if(node.left != null) queue.Enqueue(node.left);
				if(node.right != null) queue.Enqueue(node.right);
			}

			return array;
		}

		private Node Min(Node node)
		{
			return (node.left != null) ? Min(node.left) : node;
		}

		private Node Max(Node node)
		{
			return (node.right != null) ? Max(node.right) : node;
		}

		private void Clear(Node node)
		{
			if(node == null) return;
			if(node.left != null) Clear(node.left);
			if(node.right != null) Clear(node.right);
		}

		private Node NodePointer(Node node, T data)
		{
			if(node == null) return null;
			if(data.Equals(node.data)) return node;
			if(data.CompareTo(node.data) < 0) return NodePointer(node.left, data);
			if(data.CompareTo(node.data) > 0) return NodePointer(node.right, data);

			return null;
		}

		private Node ParentPointer(Node node, T data)
		{
			if(node == null) return null;
			if(node.left != null && data.Equals(node.left.data)) return node;
			if(node.right != null && data.Equals(node.right.data)) return node;
			if(node.left != null && data.CompareTo(node.data) < 0) return ParentPointer(node.left, data);
			if(node.right != null && data.CompareTo(node.data) > 0) return ParentPointer(node.right, data);

			return null;
		}

		private void Insert(Node node, T data)
		{
			if(root == null) {root = new Node(data); return;}
			if(node.left != null && data.CompareTo(node.data) < 0) Insert(node.left, data);
			if(node.right != null && data.CompareTo(node.data) > 0) Insert(node.right, data);
			if(node.left == null && data.CompareTo(node.data) < 0) {node.left = new Node(data); return;}
			if(node.right == null && data.CompareTo(node.data) > 0) {node.right = new Node(data); return;}
		}

		private Node Successor(Node node)
		{
			if(node == null) return null;
			if(node.left == null && node.right == null) return null;
			if(node.left != null && node.right == null) return node.left;
			if(node.left == null && node.right != null) return node.right;
			if(node.left != null && node.right != null) return Min(node.right);

			return null;
		}

		private void TraversePreOrder(Node node, List<T> array)
		{
			array.Add(node.data);

			if(node.left != null) TraversePreOrder(node.left, array);
			if(node.right != null) TraversePreOrder(node.right, array);
		}

		private void TraverseInOrder(Node node, List<T> array)
		{
			if(node.left != null) TraverseInOrder(node.left, array);

			array.Add(node.data);

			if(node.right != null) TraverseInOrder(node.right, array);
		}

		private void TraversePostOrder(Node node, List<T> array)
		{
			if(node.left != null) TraversePostOrder(node.left, array);
			if(node.right != null) TraversePostOrder(node.right, array);

			array.Add(node.data);
		}
	}
}