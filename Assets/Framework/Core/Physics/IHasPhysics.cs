using JetBrains.Annotations;
using UnityEngine;

namespace Framework.Core.Physics
{
    public interface IHasPhysics<out TRigidbody> where TRigidbody : Component
    {
        [NotNull]
        TRigidbody Rigidbody { get; }
    }
}