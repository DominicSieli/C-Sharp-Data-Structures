namespace DataStructures
{
	public class Queue<T>
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
		private Node back = null;
		private Node front = null;

		public Queue()
		{}

		~Queue()
		{
			Delete();
		}

		public void Enqueue(T data)
		{
			count++;
			Node node = new Node(data);

			if(back == null || front == null) {back = node; front = node;}
			else {back.next = node; back = node;}
		}

		public void Dequeue()
		{
			if(front == null) return;

			count--;
			Node node = front;
			front = front.next;
			node.next = null;

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
				count--;
				Node node = front;
				front = front.next;
				node.next = null;
			}

			back = null;
			front = null;
		}
	}
}