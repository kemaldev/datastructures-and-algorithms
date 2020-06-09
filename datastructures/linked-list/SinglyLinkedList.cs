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

    public void Insert(int index, T value)
    {
        ListNode<T> nodeAtIndex = NodeAt(index);

        ListNode<T> newNode = new ListNode<T>
        {
            Value = value,
            Next = nodeAtIndex.Next
        };

        nodeAtIndex.Next = newNode;

        _size++;
    }

    public void Erase(int index)
    {
        if(index == 0 && _size > 1)
        {
            _head = NodeAt(index + 1);
        }
        else if(index == 0 && _size < 2)
        {
            _head = null;
        }
        else
        {
            ListNode<T> nodeBeforeIndex = NodeAt(index - 1);
            ListNode<T> nodeAtIndex = nodeBeforeIndex.Next;

            nodeBeforeIndex.Next = nodeAtIndex.Next;
        }
        
        _size--;
    }

    public void PushBack(T value)
    {
        ListNode<T> newNode = new ListNode<T>
        {
            Value = value,
            Next = null
        };

        ListNode<T> lastNode = NodeAt(_size - 1);
        lastNode.Next = newNode;

        _size++;
    }

    public T PopBack()
    {
        ListNode<T> nodeBeforeLastNode = NodeAt(_size - 2);
        ListNode<T> lastNode = nodeBeforeLastNode.Next;

        nodeBeforeLastNode.Next = null;

        _size--;

        return lastNode.Value;
    }

    public void RemoveValue(T value)
    {
        ListNode<T> node = _head;

        for(int i = 0; i < _size; i++)
        {
            if(node.Value.Equals(value))
            {
                Erase(i);
                _size--;

                return;
            }

            node = node.Next;
        }
    }

    public void Reverse()
    {
        ListNode<T> newHeadNode = null;

        for(int i = _size - 1; i >= 0; i--)
        {
            if(i == 0)
            {
                ListNode<T> newLastNode = NodeAt(i);
                newLastNode.Next = null;
            }
            else
            {
                ListNode<T> firstNode = NodeAt(i - 1);
                ListNode<T> secondNode = firstNode.Next;

                secondNode.Next = firstNode;

                if(i == _size - 1)
                {
                    newHeadNode = secondNode;
                }
            }
            
        }
        
        _head = newHeadNode;
    }

    public T ValueNFromEnd(int n)
    {
        int lastElementIndex = _size - 1;
        if(_size - n < 0)
        {
            return default(T);
        }
        
        ListNode<T> nthNodeFromEnd = NodeAt(_size - n);
        return nthNodeFromEnd.Value;
    }

    public T Front()
    {
        return _head.Value;
    }

    public T Back()
    {
        ListNode<T> lastNode = NodeAt(_size - 1);
        return lastNode.Value;
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
        ListNode<T> node = NodeAt(index);

        return node.Value;
    }

    private ListNode<T> NodeAt(int index)
    {
        ListNode<T> currentNode = _head;

        for(int i = 0; i < index; i++)
        {
            if(currentNode == null)
            {
                return null;
            }

            currentNode = currentNode.Next;
        }

        return currentNode;
    }
}

public class ListNode<T> 
{
    public T Value { get; set; }
    public ListNode<T> Next { get; set; }
}