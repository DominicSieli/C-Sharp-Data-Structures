using System.Collections.Generic;

namespace DataStructures
{
	public class HashTable<T>
	{
		private static uint SIZE = 1000;

		private class Pair
		{
			public T data;
			public string key;

			public Pair(string key, T data)
			{
				this.key = key;
				this.data = data;
			}
		}

		private List<Pair>[] table = new List<Pair>[SIZE];

		public HashTable()
		{
			for(uint i = 0; i < SIZE; i++)
			{
				table[i] = new List<Pair>();
			}
		}

		~HashTable()
		{}

		public void Insert(string key, T data)
		{
			uint hash = HashFunction(key);

			foreach(var pair in table[hash])
			{
				if(pair.key == key) {pair.data = data; return;}
			}

			table[hash].Add(new Pair(key, data));
		}

		public T GetData(string key)
		{
			uint hash = HashFunction(key);

			foreach(var pair in table[hash])
			{
				if(pair.key == key) return pair.data;
			}

			return default(T);
		}

		public void Remove(string key)
		{
			T data = GetData(key);
			uint hash = HashFunction(key);

			table[hash].RemoveAll(pair => pair.key == key && pair.data.Equals(data));
		}

		public bool Empty()
		{
			foreach(var pair in table)
			{
				if(pair.Count > 0) return false;
			}

			return true;
		}

		private uint HashFunction(string key)
		{
			uint hash = 0;

			foreach(var chr in key)
			{
				hash += (uint)chr;
			}

			return hash % SIZE;
		}
	}
}