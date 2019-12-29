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
        public IEnumerator<object> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count { get; }
        public void CacheDependent(IDependentObject obj)
        {
            throw new NotImplementedException();
        }

        public void Cache(object component)
        {
            throw new NotImplementedException();
        }

        public T Find<T>()
        {
            throw new NotImplementedException();
        }

        public bool TryFind<T>(out T obj)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> FindMany<T>()
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