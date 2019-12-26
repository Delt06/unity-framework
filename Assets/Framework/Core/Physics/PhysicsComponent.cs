using Framework.Core.Objects.Components;
using UnityEngine;

namespace Framework.Core.Physics
{
    public class PhysicsComponent<TRigidbody> : DependentComponent, IHasPhysics<TRigidbody>
        where TRigidbody : Component
    {
        [SerializeField] private TRigidbody _rigidbody = default;

        public TRigidbody Rigidbody => _rigidbody ? _rigidbody : throw new FieldNotSetException(nameof(_rigidbody));
    }
}