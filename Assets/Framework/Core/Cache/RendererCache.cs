using Framework.Core.Graphics;
using Framework.Core.Objects.Components;
using UnityEngine;

namespace Framework.Core.Cache
{
    public abstract class RendererCache<TRenderer> : CacheBase, IHasRenderer<TRenderer>
        where TRenderer : Renderer
    {
        [SerializeField] private TRenderer _renderer = default;

        public TRenderer Renderer => _renderer ? _renderer : throw new FieldNotSetException(nameof(_renderer));
    }
}