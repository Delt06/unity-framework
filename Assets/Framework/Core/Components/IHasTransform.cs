using JetBrains.Annotations;

namespace Framework.Core.Components
{
    public interface IHasTransform
    {
        [NotNull]
        UnityEngine.Transform Transform { get; }
    }
}