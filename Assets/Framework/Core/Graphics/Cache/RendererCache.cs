using Framework.Core.Components.Cache;
using Framework.Core.Objects.Components;
using UnityEngine;

namespace Framework.Core.Graphics.Cache
{
    public abstract class RendererCache<TRenderer> : CacheBase, IHasRenderer<TRenderer>
        where TRenderer : Renderer
    {
        [SerializeField] private TRenderer _renderer = default;

        public TRenderer Renderer => _renderer ? _renderer : throw new FieldNotSetException(nameof(_renderer));
    }
}