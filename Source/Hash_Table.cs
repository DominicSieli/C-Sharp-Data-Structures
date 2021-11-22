using System;
using System.Collections.Generic;

namespace DataStructures
{
	public class HashTable<T>
	{
		private static int S = 10;

		private class Pair
		{
			public T data;
			public string key;

			public Pair(string k, T d)
			{
				key = k;
				data = d;
			}
		}

		private List<Pair>[] table = new List<Pair>[10];

		public HashTable()
		{}

		~HashTable()
		{}

		public void Insert(string key, T data)
		{
			int hash = HashFunction(key);

			foreach(var pair in table[hash])
			{
				if(pair.key == key) {pair.data = data; return;}
			}

			table[hash].Add(new Pair(key, data));
		}

		public T GetData(string key)
		{
			int hash = HashFunction(key);

			foreach(var pair in table[hash])
			{
				if(pair.key == key) return pair.data;
			}

			return default(T);
		}

		public void Remove(string key)
		{
			int hash = HashFunction(key);

			foreach(var pair in table[hash])
			{
				if(pair.key == key) {table[hash].Remove(pair); return;}
			}
		}

		public bool Empty()
		{
			for(int i = 0; i < S; i++)
			{
				if(table[i].Count > 0) return false;
			}

			return true;
		}

		private int HashFunction(string key)
		{
			int hash = 0;

			foreach(var chr in key)
			{
				hash += (int)chr;
			}

			return hash % S;
		}
	}
}