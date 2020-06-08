public class SinglyLinkedList<T>
{
    private ListNode<T> _head;
    private int _size;

    public SinglyLinkedList()
    {
        _head = null;
        _size = 0;
    }

    public int Size()
    {
        return _size;
    }

    public bool Empty()
    {
        return _size == 0;
    }

    public void PushFront(T value)
    {
        ListNode<T> newNode = new ListNode<T>
        {
            Value = value,
            Next = _head
        };

        _head = newNode;

        _size++;
    }

    public T PopFront()
    {
        T valueToPop = _head.Value;
        _head = _head.Next;

        _size--;
        return valueToPop;
    }

    public T ValueAt(int index)
    {
        ListNode<T> currentNode = _head;

        for(int i = 0; i < index; i++)
        {
            if(currentNode == null)
            {
                return default(T);
            }

            currentNode = currentNode.Next;
        }

        return currentNode.Value;
    }

}