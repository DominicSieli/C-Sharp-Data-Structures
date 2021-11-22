using System;
using System.Collections.Generic;

namespace DataStructures
{
	public class DynamicArray<T> where T : IComparable
	{
		private long size = 0;
		private long count = 0;
		private T[] array = null;

		public DynamicArray()
		{}

		public DynamicArray(T[] list)
		{
			size = list.Length;
			count = list.Length;
			array = new T[list.Length];

			for(int i = 0; i < list.Length; i++)
			{
				array[i] = list[i];
			}
		}

		public DynamicArray(long startSize = 0, T data = default(T))
		{
			size = startSize;
			array = new T[startSize];
			Fill(data);
		}

		~DynamicArray()
		{
			Delete();
		}

		public T this[long i]
		{
			get { return array[i]; }
			set { array[i] = value; }
		}

		public long Size()
		{
			return size;
		}

		public long Count()
		{
			return count;
		}

		public void Fill(T data)
		{
			count = size;

			for(long index = 0; index < size; index++)
			{
				array[index] = data;
			}
		}

		public void Clear()
		{
			count = 0;

			for(long index = 0; index < size; index++)
			{
				array[index] = default(T);
			}
		}

		public void Delete()
		{
			size = 0;
			count = 0;
			array = null;
		}

		public void Trim()
		{
			size = count;

			var newVector = new T[size];

			for(long index = 0; index < count; index++)
			{
				newVector[index] = array[index];
			}

			array = newVector;
		}

		public void Add(T data, long expansion = 1)
		{
			count++;

			if(count > size)
			{
				size += expansion;
				var newVector = new T[size];

				for(long index = 0; index < count; index++)
				{
					newVector[index] = array[index];
				}

				array = newVector;
			}

			array[count - 1] = data;
		}

		public void Remove(long index)
		{
			if(index >= 0 && index < count)
			{
				count--;
				array[index] = default(T);
				T data1 = array[index];
				T data2 = array[count];
				array[count] = data1;
				array[index] = data2;
			}
		}

		public void Reverse()
		{
			for(long index = 0; index < count / 2; index++)
			{
				T data1 = array[index];
				T data2 = array[(count - 1) - index];
				array[(count - 1) - index] = data1;
				array[index] = data2;
			}
		}

		public void Sort()
		{
			if(count < 2) return;

			long l = 0;
			long r = 0;
			long left = 0;
			long right = count - 1;

			while(left < right)
			{
				if(array[left].CompareTo(array[right]) > 0)
				{
					T data1 = array[left];
					T data2 = array[right];
					array[right] = data1;
					array[left] = data2;
				}

				l = left;
				r = right;

				while(l < right)
				{
					if(array[l].CompareTo(array[l + 1]) > 0)
					{
						T data1 = array[l];
						T data2 = array[l + 1];
						array[l + 1] = data1;
						array[l] = data2;
					}

					if(array[r].CompareTo(array[r - 1]) < 0)
					{
						T data1 = array[r];
						T data2 = array[r - 1];
						array[r - 1] = data1;
						array[r] = data2;
					}

					l++;
					r--;
				}

				left++;
				right--;
			}
		}
	}
}