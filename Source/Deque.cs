namespace DataStructures
{
	public class Deque<T>
	{
		private class Node
		{
			public T data;
			public Node next;
			public Node previous = null;

			public Node(T d, Node n = null, Node p = null)
			{
				data = d;
				next = n;
				previous = p;
			}
		}

		private long count = 0;
		private Node back = null;
		private Node front = null;

		public Deque()
		{}

		~Deque()
		{
			Delete();
		}

		public void EnqueueBack(T data)
		{
			count++;
			Node node = new Node(data, null, back);

			if(back == null || front == null)
			{
				back = node;
				front = node;
			}
			else
			{
				back.next = node;
				back = node;
			}
		}

		public void EnqueueFront(T data)
		{
			count++;
			Node node = new Node(data, front, null);

			if(back == null || front == null)
			{
				back = node;
				front = node;
			}
			else
			{
				front.previous = node;
				front = node;
			}
		}

		public void DequeueBack()
		{
			if(back != null)
			{
				count--;
				back = back.previous;
			}

			if(back == null) front = null;
		}

		public void DequeueFront()
		{
			if(front != null)
			{
				count--;
				front = front.next;
			}

			if(front == null) back = null;
		}

		public T Front()
		{
			if(front == null) return default(T);

			return front.data;
		}

		public T Back()
		{
			if(back == null) return default(T);

			return back.data;
		}

		public bool Empty()
		{
			return front == null;
		}

		public long Count()
		{
			return count;
		}

		public void Delete()
		{
			while(front != null)
			{
				DequeueFront();
			}
		}
	}
}