using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Core.Collections
{
    public class ArrayAsset<T> : ScriptableObject, IReadOnlyList<T>
    {
        [SerializeField] private T[] _items = default;

        public IEnumerator<T> GetEnumerator() => (IEnumerator<T>) _items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int Count => _items.Length;

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                    throw new ArgumentOutOfRangeException(nameof(index), index, "Index was out of range.");
                return _items[index];
            }
        }

        internal const string BuiltInPath = CollectionsAssets.Path + "Array/Built-in/";
        internal const string CustomPath = CollectionsAssets.Path + "Array/Custom/";
    }
}