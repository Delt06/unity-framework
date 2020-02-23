using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Framework.Core.Objects.Bases
{
    public sealed class ComponentCache : IComponentCache
    {
        public void Clear()
        {
            _allCached.Clear();
            _typedComponentCollections.Clear();
        }
        
        [NotNull]
        private readonly ICollection<object> _allCached = new HashSet<object>();

        [NotNull]
        private readonly IDictionary<Type, ICollection<object>> _typedComponentCollections = new Dictionary<Type, ICollection<object>>();

        public int Count => _allCached.Count;

        public void CacheDependent(IDependentObject component)
        {
            if (component is null) throw new ArgumentNullException(nameof(component));

            CacheAs(component, component.GetType());
        }

        public void Cache(object obj)
        {
            if (obj is null) throw new ArgumentNullException(nameof(obj));

            CacheAs(obj, obj.GetType());
        }

        private void CacheAs<T>([NotNull] object obj)
        {
            CacheAs(obj, typeof(T));
        }

        private void CacheAs([NotNull] object obj, [NotNull] Type type)
        {
            _allCached.Add(obj);

            var collection = GetOrCreateCollectionFor(type);
            collection.Add(obj);
        }

        [NotNull]
        private ICollection<object> GetOrCreateCollectionFor([NotNull] Type type)
        {
            if (!_typedComponentCollections.TryGetValue(type, out var collection))
            {
                collection = new HashSet<object>();
                _typedComponentCollections[type] = collection;
            }

            return collection;
        }

        public T Find<T>()
        {
            if (TryFind<T>(out var component)) return component;

            throw new InvalidOperationException("Component not found.");
        }

        public bool TryFind<T>(out T obj)
        {
            var type = typeof(T);

            if (TryFindDirectlyAs(type, out var foundComponent))
            {
                obj = (T) foundComponent;
                return true;
            }

            if (TryFindIndirectlyAs(type, out foundComponent))
            {
                obj = (T) foundComponent;
                CacheAs<T>(foundComponent);
                return true;
            }

            obj = default;
            return false;
        }

        private bool TryFindDirectlyAs([NotNull] Type searchedType, out object obj)
        {
            var collection = GetOrCreateCollectionFor(searchedType);
            obj = collection.FirstOrDefault();

            return obj != null;
        }

        private bool TryFindIndirectlyAs([NotNull] Type searchedType, out object obj)
        {
            foreach (var currentComponent in _allCached)
            {
                var typeOfCurrentComponent = currentComponent.GetType();

                if (!searchedType.IsAssignableFrom(typeOfCurrentComponent)) continue;

                obj = currentComponent;
                return true;
            }

            obj = null;
            return false;
        }

        public IEnumerable<T> FindMany<T>() => this.OfType<T>();

        public IEnumerator<object> GetEnumerator() => _allCached.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}