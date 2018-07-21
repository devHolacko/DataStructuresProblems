using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace DataStructures.SinglyLinkedList
{
    public class SinglyLinkedList<T> : ICollection<T>
    {
        public LinkedListNode<T> Head { get; private set; }
        public LinkedListNode<T> Tail { get; private set; }

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        /// <summary>
        /// Solution for this problem : https://www.geeksforgeeks.org/write-a-c-function-to-print-the-middle-of-the-linked-list/
        /// </summary>
        /// <returns></returns>
        public LinkedListNode<T> GetMiddleItem()
        {
            if (Count == 0)
                return null;
            if (Count == 1)
                return Head;
            LinkedListNode<T> current = Head;
            int currentCount = 1;
            int middleItemCount = Count / 2;
            while (current.Next != null)
            {
                current = current.Next;
                if (middleItemCount == currentCount)
                    break;
                currentCount++;
            }
            return current;
        }

        public void Add(T item)
        {
            AddFirst(item);
        }

        public void AddFirst(T value)
        {
            AddFirst(new LinkedListNode<T>(value));
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            LinkedListNode<T> temp = Head;
            Head = node;
            Head.Next = temp;

            Count++;
            if (Count == 1)
            {
                Tail = Head;
            }
        }

        public void AddLast(LinkedListNode<T> node)
        {
            if (Count == 0)
            {
                Head = node;
            }
            else
            {
                LinkedListNode<T> temp = Tail;
                LinkedListNode<T> current = Head;
                while (current != Tail)
                {
                    current = current.Next;
                    if (current.Next == Tail)
                    {
                        current = temp;
                        current.Next = node;
                    }
                }
            }
            Tail = node;
            Count++;
        }

        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }

        public bool Contains(T item)
        {
            if (Count != 0)
            {
                if (Head.Value.Equals(item))
                {
                    return true;
                }
                LinkedListNode<T> current = Head;
                while (current.Next != null)
                {
                    if (current.Next.Value.Equals(item))
                    {
                        return true;
                    }
                    current = current.Next;
                }
            }
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (Count != 0)
            {
                var currentIndex = arrayIndex + 1;
                LinkedListNode<T> current = Head;
                while (current != null && current.Value != null)
                {
                    array[currentIndex] = current.Value;
                    current = current.Next;
                    currentIndex++;
                }
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            var node = Head;
            while (node != null)
            {
                yield return node.Value;
                node = node.Next;
            }
        }

        public bool Remove(T item)
        {
            var isRemoved = false;
            if (Contains(item))
            {
                if (Count > 0)
                {
                    if (Count == 1 && Contains(item))
                    {
                        Head = null;
                        Tail = null;
                        isRemoved = true;
                    }
                    else
                    {
                        var current = Head;
                        if (current.Value.Equals(item))
                        {
                            Head = Head.Next;
                            isRemoved = true;
                        }
                        if (Tail.Value.Equals(item))
                        {
                            while (!current.Value.Equals(Tail.Value))
                            {
                                if (current.Next.Value.Equals(Tail.Value))
                                {
                                    current.Next = null;
                                    Tail = current;
                                    isRemoved = true;
                                    break;
                                }
                                current = current.Next;
                            }
                        }
                        while (!current.Value.Equals(item) && !isRemoved)
                        {
                            if (current.Next != null && current.Next.Value.Equals(item))
                            {
                                current.Next = current.Next.Next;
                                isRemoved = true;
                                break;
                            }
                            current = current.Next;
                        }
                    }

                    Count--;
                }
            }

            return isRemoved;

        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
