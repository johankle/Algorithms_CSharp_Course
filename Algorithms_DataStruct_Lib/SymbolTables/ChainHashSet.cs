using System;
using System.Collections.Generic;
using Algorithms_DataStruct_Lib.Queues;

namespace Algorithms_DataStruct_Lib.SymbolTables
{
    public class ChainHashSet<TKey, TValue>
    {
        private SequentialSearchST<TKey, TValue>[] _chains;

        private const int DeafultCapacity = 4;

        public int Count { get; private set; }
        public int Capacity { get; set; }

        public ChainHashSet():this(Prime.MinPrime)
        {

        }

        public ChainHashSet(int capacity)
        {
            Capacity = capacity;
            _chains = new SequentialSearchST<TKey, TValue>[capacity];
            for (int i = 0; i < Capacity; i++)
            {
                _chains[i] = new SequentialSearchST<TKey, TValue>();
            }
        }
        private int Hash(TKey key)
        {
            return (key.GetHashCode() & 0x7fffffff) % Capacity;
        }

        public TValue Get(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Key is not allowed to be null.");

            int index = Hash(key);

            if (_chains[index].TryGet(key, out TValue val))
                return val;

            throw new ArgumentException("Key was not found!");
        }

        public bool Contains(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Key is not allowed to be null.");

            int index = Hash(key);

            return _chains[index].TryGet(key, out TValue _);
        }

        public bool Remove(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Key is not allowed to be null.");

            int index = Hash(key);

            if(_chains[index].Contains(key))
            {
                Count--;
                _chains[index].Remove(key);

                if (Capacity > DeafultCapacity && Count <= 2 * Capacity)
                    Resize(Prime.ReducePrime(Capacity));

                return true;
            }

            return false;
        }

        public void Add(TKey key, TValue val)
        {
            if (key == null)
                throw new ArgumentNullException("Key is not allowed to be null.");

            if (val == null)
            {
                Remove(key);
                return;
            }

            if (Count >= 10 * Capacity)
                Resize(Prime.ExpandPrime(Capacity));

            int i = Hash(key);
            if(!_chains[i].Contains(key))
                Count++;

            _chains[i].Add(key, val);
        }

        private void Resize(int chains)
        {
            var tmp = new ChainHashSet<TKey, TValue>(chains);
            for (int i = 0; i < Capacity; i++)
            {
                foreach (TKey key in _chains[i].Keys())
                {
                    if (_chains[i].TryGet(key, out TValue val))
                    {
                        tmp.Add(key, val);
                    }
                }
            }
            Capacity = tmp.Capacity;
            Count = tmp.Count;
            _chains = tmp._chains;
        }

        public IEnumerable<TKey> Keys()
        {
            var queue = new LinkedQueue<TKey>();

            for (int i = 0; i < Capacity; i++)
            {
                foreach (TKey key in _chains[i].Keys()) 
                {
                    queue.Enqueue(key);
                }
            }
            return queue;
        }
    }
}
