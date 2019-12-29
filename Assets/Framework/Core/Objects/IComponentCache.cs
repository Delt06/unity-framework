using System.Collections.Generic;
using JetBrains.Annotations;

namespace Framework.Core.Objects
{
    public interface IComponentCache : IReadOnlyCollection<object>
    {
        void CacheDependent([NotNull] IDependentObject obj);
        void Cache([NotNull] object obj);

        [NotNull]
        T Find<T>();
        
        bool TryFind<T>(out T obj);

        [NotNull]
        IEnumerable<T> FindMany<T>();
    }
}