using System;

namespace Algorithms_DataStruct_Lib
{
    public class DoublyLinkedList<T>
    {
        public DoublyLinkedNode<T> Head { get; private set; }
        public DoublyLinkedNode<T> Tail { get; private set; }

        public void AddFirst(T value)
        {
            AddFirst(new DoublyLinkedNode<T>(value));
        }

        private void AddFirst(DoublyLinkedNode<T> node)
        {
            // Save off the Head
            DoublyLinkedNode<T> tmp = Head;
            // Point Head to node
            Head = node;

            // Insert rest of the list after Head
            Head.Next = tmp;

            if (IsEmpty)
            {
                Tail = Head;
            }
            else
            {
                // before: 1(head) <-----> 5 <-> 7 -> null
                // after: 3(head) <-----> 1 <-> 5 <-> 7 -> null

                // update Previous ref of former Head
                tmp.Previous = Head;
            }
            Count++;
        }

        public void Addlast(T value)
        {
            AddLast(new DoublyLinkedNode<T>(value));
        }

        private void AddLast(DoublyLinkedNode<T> node)
        {
            if (IsEmpty)
            {
                Head = node;
            }
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }
            Tail = node;
            Count++;
        }

        public void RemoveFirst()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            Head = Head.Next;

            Count--;

            if (IsEmpty)
            {
                Tail = null;
            }
            else
            {
                Head.Previous = null;
            }
        }

        public void RemoveLast()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            if (Count == 1)
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail.Previous.Next = null; // null the last node
                Tail = Tail.Previous; // Shift the Tail to the peniultimate node
            }
            Count--;
        }

        public int Count { get; private set; }
        public bool IsEmpty => Count == 0;
    }
}
