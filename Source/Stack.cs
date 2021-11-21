namespace DataStructures
{
	public class Stack<T>
	{
		private class Node
		{
			public T data;
			public Node next;

			public Node(T d, Node n = null)
			{
				data = d;
				next = n;
			}
		}

		private long count = 0;
		private Node top = null;

		public Stack()
		{}

		~Stack()
		{
			Delete();
		}

		public void Push(T data)
		{
			count++;
			Node node = new Node(data, top);
			top = node;
		}

		public void Pop()
		{
			if(top == null) return;

			count--;
			Node node = top;
			top = top.next;
			node.next = null;
		}

		public T Top()
		{
			if(top == null) return default(T);

			return top.data;
		}

		public bool Empty()
		{
			return top == null;
		}

		public long Count()
		{
			return count;
		}

		public void Delete()
		{
			while(top != null)
			{
				count--;
				top = top.next;
			}
		}
	}
}