using UnityEngine;

namespace Framework.Core.Physics
{
    public interface IHasPhysics<out TRigidbody> where TRigidbody : Component
    {
        TRigidbody Rigidbody { get; }
    }
}