using System;
using Core.Objects.Bases;

namespace Core.Spawning.Pools
{
    public class PoolBaseComponent : BaseComponent, IPoolBase
    {
        public sealed override void Destroy()
        {
            if (!IsActive) return;
            
            Deactivate();
            OnDestroyed();
        }

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
            
            GameObject.SetActive(false);
            OnDeactivated();
        }

        public event EventHandler Activated;
        public event EventHandler Deactivated;

        protected virtual void OnActivated()
        {
            Activated?.Invoke(this, EventArgs.Empty);
        }

        protected virtual void OnDeactivated()
        {
            Deactivated?.Invoke(this, EventArgs.Empty);
        }
    }
}