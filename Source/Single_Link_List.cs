namespace DataStructures
{
	public class SingleLinkList<T>
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

		public SingleLinkList()
		{}

		public SingleLinkList(T[] list)
		{
			foreach(var data in list)
			{
				InsertTail(data);
			}
		}

		~SingleLinkList()
		{
			DeleteList();
		}

		private long count = 0;
		private Node head = null;
		private Node tail = null;

		public bool Empty()
		{
			return head == null;
		}

		public long Count()
		{
			return count;
		}

		public T Head()
		{
			if(head != null) return head.data;

			return default(T);
		}

		public T Tail()
		{
			if(tail != null) return tail.data;

			return default(T);
		}

		public void Print()
		{
			Node node = head;

			while(node != null)
			{
				System.Console.Write("{0}->", node.data);
				node = node.next;
			}

			System.Console.Write("null");
		}

		public void Reverse()
		{
			if(count < 2) return;

			Node current = head;
			Node next = head.next;
			Node previous = null;

			while(current != null)
			{
				next = current.next;
				current.next = previous;
				previous = current;
				current = next;
			}

			Node h = head;
			Node t = tail;
			head = t;
			tail = h;
		}

		public long Contains(T data)
		{
			if(head == null) return 0;

			Node node = head;
			long instances = 0;

			while(node != null)
			{
				if(node.data.Equals(data)) instances++;

				node = node.next;
			}

			return instances;
		}

		public void DeleteList()
		{
			while(head != null)
			{
				DeleteHead();
			}

			head = null;
			tail = null;
		}

		public void InsertHead(T data)
		{
			count++;
			Node node = new Node(data, head);
			head = node;

			if(count == 1) tail = head;
		}

		public void InsertTail(T data)
		{
			if(tail == null) {InsertHead(data); return;}

			count++;
			Node node = new Node(data);
			tail.next = node;
			tail = node;
		}

		public void DeleteHead()
		{
			if(head == null) return;

			count--;
			Node node = head;
			head = head.next;
			node.next = null;

			if(head == null) tail = null;
		}

		public void DeleteTail()
		{
			if(tail == null) return;
			if(tail == head) {DeleteHead(); return;}

			Node node = head;

			while(node.next != tail)
			{
				node = node.next;
			}

			count--;
			tail = node;
			tail.next = null;
		}

		public void Remove(T data)
		{
			Node node = head;

			while(node != null)
			{
				if(node == head && node.data.Equals(data)) {DeleteHead(); node = head;}

				if(node.next != null && node.next.data.Equals(data))
				{
					node.next = node.next.next;
				}

				node = node.next;
			}
		}
	}
}