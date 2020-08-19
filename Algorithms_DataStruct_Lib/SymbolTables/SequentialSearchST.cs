using System;
using System.Collections.Generic;

namespace Algorithms_DataStruct_Lib.SymbolTables
{
    public class SequentialSearchST<TKey, TValue>
    {
        private class Node
        {
            public TKey Key { get; }
            public TValue Value { get; set; }

            public Node Next { get; set; }

            public Node(TKey key, TValue value, Node next)
            {
                Key = key;
                Value = value;
                Next = next;
            }
        }

        private Node _first;
        private readonly EqualityComparer<TKey> _comparer;

        public int Count { get; private set; }

        public SequentialSearchST()
        {
            _comparer = EqualityComparer<TKey>.Default;


        }

        public SequentialSearchST(EqualityComparer<TKey> comparer)
        {
            _comparer = comparer ?? throw new ArgumentNullException();
        }

        public bool TryGet(TKey key, out TValue val)
        {
            for (Node x = _first; x != null; x = x.Next)
            {
                if (_comparer.Equals(key, x.Key))
                {
                    val = x.Value;
                    return true;
                }
            }

            val = default(TValue);
            return false;
        }

        public void Add(TKey key, TValue val)
        {
            if (key == null)
                throw new ArgumentNullException("Key can't be null.");

            for (Node x = _first; x!=null; x = x.Next)
            {
                if (_comparer.Equals(key, x.Key))
                {
                    x.Value = val;
                    return;
                }
            }

            _first = new Node(key, val, _first);

            Count++;
        }

        public bool Contains(TKey key)
        {
            for (Node x = _first; x != null; x = x.Next)
            {
                if (_comparer.Equals(key, x.Key))
                {
                    return true;
                }
            }

            return false;
        }

        public IEnumerable<TKey> Keys()
        {
            for (Node x = _first; x != null; x = x.Next)
            {
                yield return x.Key;
            }
        }

        public bool Remove(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Key can't be null.");

            if (Count == 1 && _comparer.Equals(_first.Key, key))
            {
                _first = null;
                Count--;
                return true;
            }

            Node prev = null;
            Node curr = _first;

            while (curr != null)
            {
                if (_comparer.Equals(curr.Key, key))
                {
                    if (prev == null)
                        _first = curr.Next;
                    else
                        prev.Next = curr.Next;

                    Count--;
                    return true;
                }

                prev = curr;
                curr = curr.Next;
            }

            return false;

            //for (Node x = _first; x != null; x = x.Next)
            //{
            //    if (_comparer.Equals(key, x.Next.Key))
            //    {
            //        x.Next = x.Next.Next;
            //        Count--;
            //        return true;
            //    }
            //}
            //return false;
        }
    }
}
