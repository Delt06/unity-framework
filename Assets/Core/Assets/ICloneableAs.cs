using JetBrains.Annotations;

namespace Core.Assets
{
    public interface ICloneableAs<in T>
    {
        [NotNull]
        TClone CloneAs<TClone>() where TClone : T;
    }
}