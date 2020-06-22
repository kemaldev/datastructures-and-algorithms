class ListNode {
    public int value;
    public ListNode next;
    public ListNode prev;
    
    public ListNode(int value, ListNode next, ListNode prev) {
        this.value = value;
        this.next = next;
        this.prev = prev;
    }
}

class DoublyLinkedList {
    private ListNode head;
    private ListNode tail;
    private int size;
    
    /** Initialize your data structure here. */
    public DoublyLinkedList() {
        this.head = null;
        this.tail = null;
    }
    
    /** Get the value of the index-th node in the linked list. If the index is invalid, return -1. */
    public int get(int index) {
        ListNode current = head;
        
        if(index < 0 || index >= size)
        {
            return -1;
        }
        
        for(int i = 0; i < index; i++)
        {
            current = current.next;
            
            if(current == null)
            {
                return -1;
            }
        }
        
        return current.value;
    }
    
    /** Add a node of value val before the first element of the linked list. After the insertion, the new node will be the first node of the linked list. */
    public void addAtHead(int val) {
        if(head == null)
        {
            ListNode firstNode = new ListNode(val, null, null);
            head = firstNode;
            tail = firstNode;
        }
        else
        {
            ListNode newNode = new ListNode(val, head, null);
            head.prev = newNode;
            head = newNode;
        }
        
        size++;
    }
    
    /** Append a node of value val to the last element of the linked list. */
    public void addAtTail(int val) {
        if(tail == null)
        {
            ListNode firstNode = new ListNode(val, null, null);
            head = firstNode;
            tail = firstNode;
        }
        else
        {
            ListNode oldTail = tail;
            ListNode newNode = new ListNode(val, null, oldTail);
            oldTail.next = newNode;
            tail = newNode;
        }
        
        size++;
    }
    
    /** Add a node of value val before the index-th node in the linked list. If index equals to the length of linked list, the node will be appended to the end of linked list. If index is greater than the length, the node will not be inserted. */
    public void addAtIndex(int index, int val) {
        
        if(index == size)
        {
            addAtTail(val);
            
            return;
        }
        
        ListNode current = head;
        
        for(int i = 0; i < index; i++)
        {
            current = current.next;
            
            if(current == null)
            {
                return;
            }
        }
        
        if(current.prev == null)
        {
            addAtHead(val);
        }
        else
        {
            
            ListNode newNode = new ListNode(val, current, current.prev);
            current.prev.next = newNode;
            current.prev = newNode;    
        }
        
        size++;
    }
    
    /** Delete the index-th node in the linked list, if the index is valid. */
    public void deleteAtIndex(int index) {
        ListNode current = head;
        
        for(int i = 0; i < index; i++)
        {
            current = current.next;
            
            if(current == null)
            {
                return;
            }
        }
        
        if(current.prev == null)
        {
            head = current.next;
        }
        else if(current.next == null)
        {
            ListNode prevNode = current.prev;
            prevNode.next = null;
            tail = prevNode;
        }
        else
        {
            System.out.println("tail value" + tail.value);
            System.out.println("tail prev" + tail.prev.value);
            current.prev.next = current.next;
            current.next.prev = current.prev;
        }
        
        size--;
    }
}

/**
 * Your MyLinkedList object will be instantiated and called as such:
 * MyLinkedList obj = new MyLinkedList();
 * int param_1 = obj.get(index);
 * obj.addAtHead(val);
 * obj.addAtTail(val);
 * obj.addAtIndex(index,val);
 * obj.deleteAtIndex(index);
 */