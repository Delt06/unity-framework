using System;
using JetBrains.Annotations;

namespace Core.Objects
{
    public interface IBaseObject : IComponentCache, IHasGameObject, IHasTransform
    {
        [NotNull]
        string Name { get; }
        
        void Destroy();

        event EventHandler Destroyed;
    }
}