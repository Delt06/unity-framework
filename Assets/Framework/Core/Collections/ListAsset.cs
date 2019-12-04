using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Framework.Core.Collections
{
    public class ListAsset<T> : ListAssetBase, IList<T>
    {
        [SerializeField] internal List<T> Items = default;

        public List<T>.Enumerator GetEnumerator() => Items.GetEnumerator();

        IEnumerator<T> IEnumerable<T>.GetEnumerator() => GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable) Items).GetEnumerator();

        public void Add(T item) => Items.Add(item);

        public void Clear() => Items.Clear();

        public bool Contains(T item) => Items.Contains(item);

        public void CopyTo([NotNull] T[] array, int arrayIndex)
        {
            if (array is null) throw new ArgumentNullException(nameof(array));
            Items.CopyTo(array, arrayIndex);
        }

        public bool Remove(T item) => Items.Remove(item);

        public int Count => Items.Count;

        bool ICollection<T>.IsReadOnly => ((ICollection<T>)Items).IsReadOnly;

        public int IndexOf(T item) => Items.IndexOf(item);

        public void Insert(int index, T item)
        {
            if (index < 0 || index > Count) throw new ArgumentOutOfRangeException(nameof(index));
            Items.Insert(index, item);
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index));
            Items.RemoveAt(index);
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index));
                return Items[index];
            }
            set
            {
                if (index < 0 || index >= Count) throw new ArgumentOutOfRangeException(nameof(index));
                Items[index] = value;
            }
        }
    }
}