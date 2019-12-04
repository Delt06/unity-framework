using System;
using System.Collections;
using System.Collections.Generic;
using Framework.Core.Objects;
using Framework.Core.Spawning.Pools;
using UnityEngine;

namespace Framework.EditorTests.Core.Spawning.Pools
{
    public class MockPoolBaseObject : IPoolBase
    {
        public IEnumerator<IDependentObject> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count { get; }
        public void Cache(IDependentObject component)
        {
            throw new NotImplementedException();
        }

        public T FindComponent<T>()
        {
            throw new NotImplementedException();
        }

        public bool TryFindComponent<T>(out T component)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindComponents<T>()
        {
            throw new NotImplementedException();
        }

        public GameObject GameObject { get; }
        public Transform Transform { get; }
        public string Name { get; }
        
        public void Destroy()
        {
            Destroyed?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler Destroyed;
        public bool IsActive { get; private set; }
        public void Activate()
        {
            IsActive = true;
            Activated?.Invoke(this, EventArgs.Empty);
        }

        public void Deactivate()
        {
            Deactivated?.Invoke(this, EventArgs.Empty);
        }

        public event EventHandler Activated;
        public event EventHandler Deactivated;
    }
}