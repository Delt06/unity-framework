using Framework.Core.Objects.Components;
using UnityEngine;

namespace Framework.Core.Physics
{
    public class TransformComponent : DependentComponent, IHasTransform
    {
        [SerializeField] private Transform _transform = default;

        public Transform Transform => _transform ? _transform : throw new FieldNotSetException(nameof(_transform));
    }
}