using Framework.Core.Components.Cache;
using Framework.Core.Objects.Components;
using UnityEngine;

namespace Framework.Core.Physics.Cache
{
    public abstract class PhysicsCache<TRigidbody> : CacheBase, IHasPhysics<TRigidbody>
        where TRigidbody : Component
    {
        [SerializeField] private TRigidbody _rigidbody = default;

        public TRigidbody Rigidbody => _rigidbody ? _rigidbody : throw new FieldNotSetException(nameof(_rigidbody));
    }
}