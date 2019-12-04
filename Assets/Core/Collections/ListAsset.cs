using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Core.Collections
{
    public class ListAsset<T> : ScriptableObject, IList<T>
    {
        [SerializeField] private List<T> _items = default;

        public IEnumerator<T> GetEnumerator() => _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable) _items).GetEnumerator();

        public void Add(T item) => _items.Add(item);

        public void Clear() => _items.Clear();

        public bool Contains(T item) => _items.Contains(item);

        public void CopyTo([NotNull] T[] array, int arrayIndex)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            _items.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item) => _items.Remove(item);

        public int Count => _items.Count;

        bool ICollection<T>.IsReadOnly => ((ICollection<T>)_items).IsReadOnly;

        public int IndexOf(T item) => _items.IndexOf(item);

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count) throw new ArgumentOutOfRangeException(nameof(index));
            _items.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index));
            _items.RemoveAt(index);
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index));
                return _items[index];
            }
            set
            {
                if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index));
                _items[index] = value;
            }
        }
        
        internal const string BuiltInPath = CollectionsAssets.Path + "List/Built-in/";
        internal const string CustomPath = CollectionsAssets.Path + "Array/Custom/";
    }
}