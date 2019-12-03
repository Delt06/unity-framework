using JetBrains.Annotations;

namespace Core.Objects
{
    public interface IDependentObject
    {
        bool Initialized { get; }
        
        [NotNull]
        IBaseObject Base { get; }
        
        void Initialize([NotNull] IBaseObject baseObject);
    }
}