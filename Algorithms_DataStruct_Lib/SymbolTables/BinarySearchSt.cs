using System;
using System.Collections.Generic;
using Algorithms_DataStruct_Lib.Queues;

namespace Algorithms_DataStruct_Lib.SymbolTables
{
    public class BinarySearchSt<TKey, TValue>
    {
        private const int DEFAULT_CAPACITY = 4;

        private TKey[] _keys;
        private TValue[] _values;

        public int Count { get; private set; }
        public int Capacity => _keys.Length;

        public bool IsEmpty => Count == 0;

        private readonly IComparer<TKey> _comparer;

        public BinarySearchSt(int capacity, IComparer<TKey> comparer)
        {
            _keys = new TKey[capacity];
            _values = new TValue[capacity];
            _comparer = comparer ?? throw new ArgumentNullException("Comparer can't be null.");
        }

        public BinarySearchSt(int capacity):this(capacity, Comparer<TKey>.Default)
        {
        }

        public BinarySearchSt():this(DEFAULT_CAPACITY)
        {
        }

        public int Rank(TKey key)
        {
            int low = 0;
            int high = Count - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;
                int cmp = _comparer.Compare(key, _keys[mid]);

                if (cmp < 0)
                    high = mid - 1;
                else if (cmp > 0)
                    low = mid + 1;
                else
                    return mid;
            }
            return low;
        }

        public TValue GetValueOrDefault(TKey key)
        {
            if (IsEmpty)
                return default(TValue);

            int rank = Rank(key);
            if (rank < Count && _comparer.Compare(_keys[rank], key) == 0)
            {
                return _values[rank];
            }

            return default(TValue);
        }

        public void Add(TKey key, TValue val)
        {
            if (key == null)
                throw new ArgumentNullException("Key can't be null.");

            int rank = Rank(key);
            if (rank < Count && _comparer.Compare(_keys[rank], key) == 0)
            {
                _values[rank] = val;
                return;
            }

            if (Count == Capacity)
                Resize(Capacity * 2);

            for (int i = Count; i > rank; i--)
            {
                _keys[i] = _keys[i - 1];
                _values[i] = _values[i - 1];
            }

            _keys[rank] = key;
            _values[rank] = val;
            Count++;
        }

        public void Remove(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("Key can't be null.");

            if (IsEmpty)
                return;

            int r = Rank(key);

            if (r == Count || _comparer.Compare(_keys[r], key) != 0)
                return;

            for (int i = r; i < Count - 1; i++)
            {
                _keys[i] = _keys[i + 1];
                _values[i] = _values[i + 1];
            }

            Count--;
            _keys[Count] = default(TKey);
            _values[Count] = default(TValue);

            // Resize if 1/4 full
            // if (Count > 0 && Count == _keys.Length / 4)
            //  Resize(_keys.Length / 2);
        }

        public bool Contains(TKey key)
        {
            int r = Rank(key);

            if (r < Count && _comparer.Compare(_keys[r], key) == 0)
                return true;
            return false;
        }

        public IEnumerable<TKey> Keys()
        {
            foreach (var key in _keys)
            {
                yield return key;
            }
        }

        private void Resize(int capacity)
        {
            TKey[] keysTmp = new TKey[capacity];
            TValue[] valuesTmp = new TValue[capacity];

            for (int i = 0; i < Count; i++)
            {
                keysTmp[i] = _keys[i];
                valuesTmp[i] = _values[i];
            }

            _keys = keysTmp;
            _values = valuesTmp;
        }

        public TKey Min()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Table is empty.");
            return _keys[0];
        }

        public TKey Max()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Table is empty.");
            return _keys[Count - 1];
        }

        public void RemoveMin()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Table is empty.");
            Remove(Min());
        }

        public void RemoveMax()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Table is empty.");
            Remove(Max());
        }

        public TKey Select(int index)
        {
            if (IsEmpty)
                throw new InvalidOperationException("Table is empty.");
            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException("Index outside the range of the table.");
            return _keys[index];
        }

        public TKey Ceiling(TKey key)
        {
            if (IsEmpty)
                throw new InvalidOperationException("Table is empty.");
            if (key == null)
                throw new ArgumentNullException("Argument to ceiling() is null.");

            int rank = Rank(key);

            if (rank == Count)
                return default(TKey);
            else
                return _keys[rank];

            //if (rank < Count && _comparer.Compare(_keys[rank], key) == 0)
            //    return _keys[rank];
            //else if (_comparer.Compare(Min(), key) > 0)
            //    return Min();

            //return default(TKey);
        }

        public TKey Floor(TKey key)
        {
            if (IsEmpty)
                throw new InvalidOperationException("Table is empty.");
            if (key == null)
                throw new ArgumentNullException("Argument to floor() is null.");

            int rank = Rank(key);

            if (rank < Count && _comparer.Compare(_keys[rank], key) == 0)
                return _keys[rank];
            //else if (_comparer.Compare(Max(), key) < 0)
            //    return Max();

            if (rank == 0)
                return default(TKey);
            else
                return _keys[rank - 1];
            //return default(TKey);
        }

        public IEnumerable<TKey> Range(TKey left, TKey right)
        {
            var q = new LinkedQueue<TKey>();

            int low = Rank(left);
            int high = Rank(right);

            for (int i = low; i < high; i++)
            {
                q.Enqueue(_keys[i]);
            }

            if (Contains(right))
                q.Enqueue(_keys[high]);

            return q;
        }

        //public TKey[] Range(TKey low, TKey high)
        //{
        //    if (IsEmpty)
        //        throw new InvalidOperationException("Table is empty.");

        //    int start = Rank(low);
        //    int stop = Rank(high);

        //    if (_comparer.Compare(Max(), low) < 0)
        //        return default(TKey[]);

        //    if (_comparer.Compare(Min(), low) > 0)
        //        start = 0;

        //    if (_comparer.Compare(Max(), high) < 0)
        //        stop = Count - 1;

        //    Console.WriteLine($"   (low: {start}, high: {stop})");

        //    TKey[] outArray;

        //    int i = 0;
        //    outArray = new TKey[(stop + 1) - start];

        //    for (int j = start; j <= stop; j++)
        //    {
        //        outArray[i++] = _keys[j];
        //    }
        //    return outArray;
            
        //}
    }
}
