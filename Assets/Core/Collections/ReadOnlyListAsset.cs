using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Collections
{
    public class ReadOnlyListAsset<T> : ReadOnlyListAssetBase, IReadOnlyList<T>
    {
        [SerializeField] internal List<T> Items = default;

        public IEnumerator<T> GetEnumerator() => (IEnumerator<T>) Items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int Count => Items.Count;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException(nameof(index), index, "Index was out of range.");
                return Items[index];
            }
        }
    }
}