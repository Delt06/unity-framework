using System;
using Core.Objects;
using Core.Spawning.Pools;
using JetBrains.Annotations;
using UnityEngine;

namespace Core.Spawning.Assets
{
    [CreateAssetMenu(menuName = BuiltInPath + "Base Object Pool")]
    public class PoolReference : SpawnerReference_IBaseObject
    {
        [CanBeNull] private PoolComponent _innerPool;

        [NotNull]
        public PoolComponent Pool
        {
            get => _innerPool != null ? _innerPool : throw NewPoolNotSetException();
            set => _innerPool = value != null ? 
                value : throw new ArgumentNullException(nameof(value), "Inner pool is cannot be null.");
        }
        
        protected sealed override IBaseObject SpawnObject()
        {
            if (_innerPool == null) throw NewPoolNotSetException();

            return _innerPool.Spawn();
        }

        [NotNull]
        private static Exception NewPoolNotSetException()
        {
            return new InvalidOperationException("Inner pool is not set");
        }
    }
}