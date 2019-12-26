using Framework.Core.Objects.Components;
using UnityEngine;

namespace Framework.Core.Components.Cache
{
    [AddComponentMenu(BuiltInPath + nameof(UnityEngine.Transform))]
    public class TransformCache : CacheBase, IHasTransform
    {
        [SerializeField] private Transform _transform = default;

        public Transform Transform => _transform ? _transform : throw new FieldNotSetException(nameof(_transform));
    }
}