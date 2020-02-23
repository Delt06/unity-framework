using System.Collections.Generic;
using JetBrains.Annotations;

namespace Framework.Core.Objects.Components
{
    public abstract class ExtraCache : DependentComponent
    {
        protected sealed override void OnInitialized()
        {
            base.OnInitialized();

            foreach (var obj in GetObjects())
            {
                Base.Cache(obj);
            }
        }

        [NotNull]
        protected abstract IEnumerable<object> GetObjects();
    }
}