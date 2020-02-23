using System;
using JetBrains.Annotations;

namespace Framework.Core.Objects
{
    public interface IBaseObject : IComponentCache, IHasGameObject, IHasTransform
    {
        void Initialize();
        
        [NotNull]
        string Name { get; }

        void Destroy();
        
        bool IsDestroyed { get; }

        event EventHandler Destroyed;
    }
}