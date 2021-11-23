using System;
using System.Collections.Generic;

namespace DataStructures
{
	public class BinaryHeap<T> where T : IComparable
	{
		private List<T> array = new List<T>();

		public BinaryHeap()
		{}

		public BinaryHeap(List<T> list)
		{
			foreach(var data in list)
			{
				Insert(data);
			}
		}

		~BinaryHeap()
		{}

		public T Min()
		{
			return array[0];
		}

		public T Max()
		{
			return array[array.Count - 1];
		}

		public bool Empty()
		{
			return array.Count == 0;
		}

		public void Insert(T data)
		{
			array.Add(data);

			for(int i = array.Count - 1; i > 0; i--)
			{
				if(array[i].CompareTo(array[i - 1]) < 0)
				{
					T i1 = array[i];
					T i2 = array[i - 1];
					array[i] = i2;
					array[i - 1] = i1;
				}
			}
		}

		public void RemoveMin()
		{
			array.RemoveAt(0);
		}

		public void RemoveMax()
		{
			array.RemoveAt(array.Count - 1);
		}
	}
}