using System.Collections.Generic;
using JetBrains.Annotations;

namespace Core.Objects
{
    public interface IComponentCache : IReadOnlyCollection<IDependentObject>
    {
        void Cache([NotNull] IDependentObject component);

        [NotNull]
        T FindComponent<T>() where T : IDependentObject;
        
        bool TryFindComponent<T>(out T component) where T : IDependentObject;

        [NotNull]
        IEnumerable<T> FindComponents<T>() where T : IDependentObject;
    }
}