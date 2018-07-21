using System;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.SinglyLinkedList
{
    public class LinkedListNode<T>
    {
        public LinkedListNode(T value)
        {
            Value = value;
        }
        public T Value { get; set; }

        public LinkedListNode<T> Next { get; set; }
    }
}
