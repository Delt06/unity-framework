using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Framework.Core.Objects.Components
{
    public class DependentComponent : MonoBehaviour, IDependentObject
    {
        [SerializeField] private bool _cached = true;
        
        public bool Initialized { get; private set; }

        [CanBeNull] private IBaseObject _base;

        public IBaseObject Base
        {
            get => _base ?? throw new InvalidOperationException("Component is not initialized");
            private set => _base = value ?? throw new ArgumentNullException(nameof(value), "Base cannot be null.");
        }
        
        public void Initialize(IBaseObject baseObject)
        {
            if (Initialized) throw new InvalidOperationException("Component is already initialized.");

            Base = baseObject ?? throw new ArgumentNullException(nameof(baseObject));
            if (_cached)
            {
                Base.Cache(this);
            }

            OnInitialized();
            Initialized = true;
        }

        protected virtual void OnInitialized() { }
    }
}