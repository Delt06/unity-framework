using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Framework.Core.Objects.Bases
{
    public sealed class ComponentCache : IComponentCache
    {
        [NotNull]
        private readonly ICollection<IDependentObject> _allComponents = new HashSet<IDependentObject>();
        
        [NotNull]
        private readonly IDictionary<Type, ICollection<IDependentObject>> _typedComponentCollections = new Dictionary<Type, ICollection<IDependentObject>>();

        public int Count => _allComponents.Count;

        public void Cache(IDependentObject component)
        {
            if (component is null) throw new ArgumentNullException(nameof(component));
            
            CacheAs(component, component.GetType());
        }

        private void CacheAs<T>([NotNull] IDependentObject component) where T : IDependentObject
        {
            CacheAs(component, typeof(T));
        }

        private void CacheAs([NotNull] IDependentObject component, [NotNull] Type type)
        {
            _allComponents.Add(component);
            
            var collection = GetOrCreateCollectionFor(type);
            collection.Add(component);
        }

        [NotNull]
        private ICollection<IDependentObject> GetOrCreateCollectionFor([NotNull] Type type)
        {
            if (!_typedComponentCollections.TryGetValue(type, out var collection))
            {
                collection = new HashSet<IDependentObject>();
                _typedComponentCollections[type] = collection;
            }

            return collection;
        }

        public T FindComponent<T>() where T : IDependentObject
        {
            if (TryFindComponent<T>(out var component)) return component;
            
            throw new InvalidOperationException("Component not found.");
        }

        public bool TryFindComponent<T>(out T component) where T : IDependentObject
        {
            var type = typeof(T);

            if (TryFindComponentDirectlyAs(type, out var foundComponent))
            {
                component = (T) foundComponent;
                return true;
            }

            if (TryFindComponentIndirectlyAs(type, out foundComponent))
            {
                component = (T) foundComponent;
                CacheAs<T>(foundComponent);
                return true;
            }

            component = default;
            return false;
        }
        
        private bool TryFindComponentDirectlyAs([NotNull] Type searchedType, out IDependentObject component)
        {
            var collection = GetOrCreateCollectionFor(searchedType);
            component = collection.FirstOrDefault();

            return component != null;
        }

        private bool TryFindComponentIndirectlyAs([NotNull] Type searchedType, out IDependentObject component)
        {
            foreach (var currentComponent in _allComponents)
            {
                var typeOfCurrentComponent = currentComponent.GetType();

                if (!searchedType.IsAssignableFrom(typeOfCurrentComponent)) continue;
                
                component = currentComponent;
                return true;
            }

            component = null;
            return false;
        }

        public IEnumerable<T> FindComponents<T>() where T : IDependentObject => this.OfType<T>();

        public IEnumerator<IDependentObject> GetEnumerator() => _allComponents.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}