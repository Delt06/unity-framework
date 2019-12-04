using System.Collections.Generic;
using JetBrains.Annotations;

namespace Framework.Core.Objects
{
    public interface IComponentCache : IReadOnlyCollection<IDependentObject>
    {
        void Cache([NotNull] IDependentObject component);

        [NotNull]
        T FindComponent<T>();
        
        bool TryFindComponent<T>(out T component);

        [NotNull]
        IEnumerable<T> FindComponents<T>();
    }
}