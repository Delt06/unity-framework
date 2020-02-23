using System;
using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace Framework.Core.Objects.Bases
{
    [DisallowMultipleComponent]
    public abstract class BaseComponent : MonoBehaviour, IBaseObject
    {
        [SerializeField] private UnityEvent _onDestroyed = new UnityEvent();

        [NotNull] private readonly IComponentCache _cache = new ComponentCache();

        public string Name => name;

        public int Count => _cache.Count;

        public void Clear()
        {
            _cache.Clear();
        }

        public void CacheDependent(IDependentObject obj)
        {
            if (obj is null) throw new ArgumentNullException(nameof(obj));
            _cache.CacheDependent(obj);
        }

        public void Cache(object obj)
        {
            if (obj is null) throw new ArgumentNullException(nameof(obj));
            _cache.Cache(obj);
        }

        public T Find<T>() => _cache.Find<T>();

        public bool TryFind<T>(out T obj) => _cache.TryFind(out obj);

        public IEnumerable<T> FindMany<T>() => _cache.FindMany<T>();

        public void Destroy()
        {
            if (IsDestroyed) return;

            DestroyWhenNotDestroyed();
            OnDestroyed();
        }
        
        public abstract bool IsDestroyed { get; }

        protected abstract void DestroyWhenNotDestroyed();

        public event EventHandler Destroyed;

        protected virtual void OnDestroyed()
        {
            _onDestroyed.Invoke();
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

            Initialize();
        }

        public void Initialize()
        {
            _cache.Clear();
            
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

        public IEnumerator<object> GetEnumerator() => _cache.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public GameObject GameObject { get; private set; }
        public Transform Transform { get; private set; }
    }
}