using System;
using Framework.Core.Objects.Bases;
using UnityEngine;
using UnityEngine.Events;

namespace Framework.Core.Spawning.Pools
{
    public class PoolBaseComponent : BaseComponent, IPoolBase
    {
        [SerializeField] private UnityEvent _onActivated = new UnityEvent();
        [SerializeField] private UnityEvent _onDeactivated = new UnityEvent();
        
        protected sealed override void DestroyWhenNotDestroyed()
        {
            Deactivate();
        }

        public sealed override bool IsDestroyed => !IsActive;

        public bool IsActive { get; private set; } = false;

        public void Activate()
        {
            if (IsActive) return;
            
            IsActive = true;
            GameObject.SetActive(true);
            InitializeIfWasNot();
            OnActivated();
        }

        public void Deactivate()
        {
            if (!IsActive) return;

            IsActive = false;
            GameObject.SetActive(false);
            OnDeactivated();
        }

        public event EventHandler Activated;
        public event EventHandler Deactivated;

        protected virtual void OnActivated()
        {
            _onActivated.Invoke();
            Activated?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnDeactivated()
        {
            _onDeactivated.Invoke();
            Deactivated?.Invoke(this, EventArgs.Empty);
        }
    }
}