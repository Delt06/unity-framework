using System.Collections.Generic;
using System.Linq;
using Framework.Core.Objects.Components;
using JetBrains.Annotations;

namespace Framework.PlayTests.Core.Objects.Components
{
    public class MockExtraCache : ExtraCache
    {
        [CanBeNull]
        public object[] Objects;
        
        protected override IEnumerable<object> GetObjects()
        {
            return Objects ?? Enumerable.Empty<object>();
        }
    }
}