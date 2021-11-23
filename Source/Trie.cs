using System;
using System.Collections.Generic;

namespace DataStructures
{
	public class Trie
	{
		private class Node
		{
			public bool terminal;
			public Node[] children = new Node[256];
		}

		private Node root = null;

		public Trie()
		{}

		public Trie(List<string> list)
		{
			foreach(var text in list)
			{
				Insert(text);
			}
		}

		~Trie()
		{}

		public void Insert(string text)
		{
			if(root == null) root = new Node();

			Node node = root;

			for(int i = 0; i < text.Length; i++)
			{
				byte index = (byte)text[i];

				if(node.children[index] == null)
				{
					node.children[index] = new Node();
				}

				node = node.children[index];
				node.terminal = true;
			}
		}

		public bool Contains(string text)
		{
			if(root == null) return false;

			Node node = root;

			for(int i = 0; i < text.Length; i++)
			{
				byte index = (byte)text[i];

				if(node.children[index] == null) return false;

				node = node.children[index];
			}

			return (node.terminal);
		}
	}
}