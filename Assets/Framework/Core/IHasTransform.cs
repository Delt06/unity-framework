using JetBrains.Annotations;

namespace Framework.Core
{
    public interface IHasTransform
    {
        [NotNull]
        UnityEngine.Transform Transform { get; }
    }
}