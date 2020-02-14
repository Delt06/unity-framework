using System;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace Framework.Core.Spawning.Assets
{
    public abstract class SpawnerReference<T> : ScriptableObject, ISpawner<T>
    {
        [SerializeField] private UnityEvent _onSpawned = default;

        public T Spawn()
        {
            var spawnedObject = SpawnObject();
            OnSpawned(spawnedObject);

            return spawnedObject;
        }

        [NotNull]
        protected abstract T SpawnObject();

        protected virtual void OnSpawned(T spawnedObject)
        {
            _onSpawned.Invoke();
            Spawned?.Invoke(this, spawnedObject);
        }

        public event EventHandler<T> Spawned;

        internal const string BuiltInPath = "Spawner/";
        protected internal string CustomPath = BuiltInPath + "Custom/";
    }
}