public class SinglyLinkedList<T>
{
    private class Node
    {
        public T Data;
        public Node Next;

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }

    private Node head;
    private Node tail;
    private int count;

    public SinglyLinkedList()
    {
        head = null;
        tail = null;
        count = 0;
    }

    public void Add(T item)
    {
        Node newNode = new Node(item);
        if (head == null)
        {
            head = newNode;
            tail = newNode;
        }
        else
        {
            tail.Next = newNode;
            tail = newNode;
        }
        count++;
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        Node newNode = new Node(item);

        if (index == 0)
        {
            newNode.Next = head;
            head = newNode;
            if (count == 0)
            {
                tail = newNode;
            }
        }
        else
        {
            Node current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            newNode.Next = current.Next;
            current.Next = newNode;

            if (newNode.Next == null)
            {
                tail = newNode;
            }
        }
        count++;
    }

    public bool Remove(T item)
    {
        Node current = head;
        Node previous = null;

        while (current != null)
        {
            if (current.Data.Equals(item))
            {
                if (previous == null)
                {
                    head = head.Next;
                    if (head == null)
                    {
                        tail = null;
                    }
                }
                else
                {
                    previous.Next = current.Next;
                    if (current.Next == null)
                    {
                        tail = previous;
                    }
                }
                count--;
                return true;
            }
            previous = current;
            current = current.Next;
        }
        return false;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        if (index == 0)
        {
            head = head.Next;
            if (head == null)
            {
                tail = null;
            }
        }
        else
        {
            Node current = head;
            for (int i = 0; i < index - 1; i++)
            {
                current = current.Next;
            }
            current.Next = current.Next.Next;
            if (current.Next == null)
            {
                tail = current;
            }
        }
        count--;
    }

    public T Get(int index)
    {
        if (index < 0 || index >= count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        Node current = head;
        for (int i = 0; i < index; i++)
        {
            current = current.Next;
        }
        return current.Data;
    }

    public int Count
    {
        get { return count; }
    }

    public bool Contains(T item)
    {
        Node current = head;
        while (current != null)
        {
            if (current.Data.Equals(item))
            {
                return true;
            }
            current = current.Next;
        }
        return false;
    }

    public void Clear()
    {
        head = null;
        tail = null;
        count = 0;
    }
}


class Program
{
    static void Main()
    {
        var list = new SinglyLinkedList<string>();

        list.Add("Item 1");
        list.Add("Item 2");
        list.Add("Item 3");

        Console.WriteLine($"Count: {list.Count}");
        Console.WriteLine($"Item at index 1: {list.Get(1)}");

        list.Insert(1, "New Item");

        Console.WriteLine($"Item at index 1 after insert: {list.Get(1)}");
        Console.WriteLine($"Item at index 2 after insert: {list.Get(2)}");

        list.Remove("Item 2");

        Console.WriteLine($"Count after remove: {list.Count}");
        Console.WriteLine($"Contains 'Item 2': {list.Contains("Item 2")}");

        list.RemoveAt(1);

        Console.WriteLine($"Count after remove at index 1: {list.Count}");

        list.Clear();

        Console.WriteLine($"Count after clear: {list.Count}");
    }
}
