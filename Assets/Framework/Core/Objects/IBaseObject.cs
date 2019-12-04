using System;
using JetBrains.Annotations;

namespace Framework.Core.Objects
{
    public interface IBaseObject : IComponentCache, IHasGameObject, IHasTransform
    {
        [NotNull]
        string Name { get; }
        
        void Destroy();

        event EventHandler Destroyed;
    }
}