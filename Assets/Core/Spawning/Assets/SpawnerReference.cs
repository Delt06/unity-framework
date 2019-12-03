using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Core.Spawning.Assets
{
    public abstract class SpawnerReference<T> : ScriptableObject, ISpawner<T>
    {
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
            Spawned?.Invoke(this, spawnedObject);
        }

        public event EventHandler<T> Spawned;

        internal const string BuiltInPath = "Spawner/Built-in/";
        protected internal string CustomPath = "Spawner/Custom/";
    }
}