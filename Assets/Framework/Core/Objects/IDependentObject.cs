using JetBrains.Annotations;

namespace Framework.Core.Objects
{
    public interface IDependentObject
    {
        bool Initialized { get; }

        [NotNull]
        IBaseObject Base { get; }

        void Initialize([NotNull] IBaseObject baseObject);
    }
}