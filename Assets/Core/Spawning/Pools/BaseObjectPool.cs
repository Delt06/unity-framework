using System;
using System.Collections.Generic;
using Core.Objects;
using JetBrains.Annotations;

namespace Core.Spawning.Pools
{
    public class BaseObjectPool : IPool<IBaseObject>
    {
        [NotNull] private readonly CreationProcedure<IPoolBase> _creationProcedure;

        public BaseObjectPool(int size, [NotNull] CreationProcedure<IPoolBase> creationProcedure)
        {
            if (size <= 0) throw new ArgumentOutOfRangeException(nameof(size));
            
            Size = size;
            _creationProcedure = creationProcedure ?? throw new ArgumentNullException(nameof(creationProcedure));
        }

        public int Size { get; }
        public bool Initialized { get; private set; }

        [NotNull] private readonly IList<IPoolBase> _objects = new List<IPoolBase>();
        private int _nextObject = 0;
        
        public void Initialize()
        {
            if (Initialized) return;

            for (var i = 0; i < Size; i++)
            {
                var createdObject = _creationProcedure() ?? 
                                    throw new InvalidOperationException("Creation procedure returned null.");
                _objects.Add(createdObject);
                
                createdObject.Activate();
                createdObject.Deactivate();
            }

            _nextObject = 0;
            
            Initialized = true;
        }

        IBaseObject ISpawner<IBaseObject>.Spawn() => GetObject();
        
        private IBaseObject GetObject()
        {
            var currentObject = _objects[_nextObject];
            
            if (++_nextObject >= Size)
            {
                _nextObject = 0;
            }

            if (currentObject.IsActive)
            {
                currentObject.Deactivate();
            }
            
            currentObject.Activate();

            return currentObject;
        }
    }
}