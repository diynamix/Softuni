using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomLinkedList
{
    internal class LinkedList<T> : IEnumerable
    {
        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        public int Count { get; set; }

        // Methods
        public void AddFirst(Node<T> node)
        {
            Count++;

            if (Tail == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            Head.Previous = node;
            node.Next = Head;
            Head = node;
        }

        public void AddFirst(T value)
        {
            AddFirst(new Node<T>(value));
        }

        public void AddLast(Node<T> node)
        {
            Count++;

            if (Head == null)
            {
                Head = node;
                Tail = node;
                return;
            }

            Tail.Next = node;
            node.Previous = Tail;
            Tail = node;
        }

        public void AddLast(T value)
        {
            AddLast(new Node<T>(value));
        }

        public T RemoveFirst()
        {
            Node<T> oldHead = Head;
            Head = Head.Next;
            Head.Previous = null;
            oldHead.Next = null;

            return oldHead.Value;
        }

        public T RemoveLast()
        {
            Node<T> oldTail = Tail;
            Tail = Tail.Previous;
            Tail.Next = null;
            oldTail.Previous = null;

            return oldTail.Value;
        }

        public void ForEach(Action<T> callback)
        {
            Node<T> node = Head;
            while (node != null)
            {
                callback(node.Value);
                node = node.Next;
            }
        }

        public T[] ToArray()
        {
            T[] array = new T[Count];
            int index = 0;
            ForEach(n =>
            {
                array[index++] = n;
            });

            return array;
        }

        public IEnumerator GetEnumerator()
        {
            var current = Head;
            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
