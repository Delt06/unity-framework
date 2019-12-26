using JetBrains.Annotations;
using UnityEngine;

namespace Framework.Core.Graphics
{
    public interface IHasRenderer<out TRenderer> where TRenderer : Renderer
    {
        [NotNull]
        TRenderer Renderer { get; }
    }
}