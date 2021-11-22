using System;
using System.Collections.Generic;

namespace DataStructures
{
	public class Graph<T>
	{
		public Graph()
		{}

		public Graph(T[] list)
		{
			foreach(var node in list)
			{
				AddNode(node);
			}
		}

		~Graph()
		{}

		private Dictionary<T, List<T>> nodes = new Dictionary<T, List<T>>();

		public void AddNode(T node)
		{
			nodes.TryAdd(node, new List<T>());
		}

		public void DeleteNode(T node)
		{
			foreach(var n in nodes)
			{
				n.Value.Remove(node);
			}

			nodes.Remove(node);
		}

		public void AddOneDirectionalEdge(T node1, T node2)
		{
			AddNode(node1);
			AddNode(node2);
			nodes[node1].Add(node2);
		}

		public void AddTwoDirectionalEdge(T node1, T node2)
		{
			AddNode(node1);
			AddNode(node2);
			nodes[node1].Add(node2);
			nodes[node2].Add(node1);
		}

		public void DeleteOneDirectionalEdge(T node1, T node2)
		{
			nodes[node1].Remove(node2);
		}

		public void DeleteTwoDirectionalEdge(T node1, T node2)
		{
			nodes[node1].Remove(node2);
			nodes[node2].Remove(node1);
		}

		public void Print()
		{
			foreach(var node in nodes)
			{
				Console.Write("{0}: [", node.Key);

				foreach(var n in node.Value)
				{
					Console.Write("{0},", n);
				}

				if(node.Value.Count > 0) Console.Write("\b");
				Console.Write("]\n");
			}
		}
	}
}