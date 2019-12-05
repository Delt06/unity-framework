using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

namespace Framework.Core.Objects.Bases
{
    [DisallowMultipleComponent]
    public abstract class BaseComponent : MonoBehaviour, IBaseObject
    {
        [NotNull] private readonly IComponentCache _cache = new ComponentCache();
        
        public string Name => name;

        public int Count => _cache.Count;

        public void Cache(IDependentObject component)
        {
            if (component is null) throw new ArgumentNullException(nameof(component));
            _cache.Cache(component);
        }

        public T FindComponent<T>() => _cache.FindComponent<T>();

        public bool TryFindComponent<T>(out T component) => _cache.TryFindComponent(out component);

        public IEnumerable<T> FindComponents<T>() => _cache.FindComponents<T>();

        public abstract void Destroy();
        
        public event EventHandler Destroyed;
        
        protected virtual void OnDestroyed()
        {
            Destroyed?.Invoke(this, EventArgs.Empty);
        }

        protected void Awake()
        {
            InitializeIfWasNot();
        }
        
        protected bool Initialized { get; private set; }

        protected void InitializeIfWasNot()
        {
            if (Initialized) return;

            GameObject = gameObject;
            Transform = transform;

            OnBeforeInitializedComponents();
            InitializeComponents();
            OnAfterInitializeComponents();

            Initialized = true;
        }

        protected virtual void OnBeforeInitializedComponents() {}

        private void InitializeComponents()
        {
            foreach (var component in GetAllComponents())
            {
                component.Initialize(this);
            }
        }

        protected virtual IEnumerable<IDependentObject> GetAllComponents() => GetComponentsInChildren<IDependentObject>();

        protected virtual void OnAfterInitializeComponents() {}
        
        public IEnumerator<IDependentObject> GetEnumerator() => _cache.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        
        public GameObject GameObject { get; private set; }
        public Transform Transform { get; private set; }
    }
}