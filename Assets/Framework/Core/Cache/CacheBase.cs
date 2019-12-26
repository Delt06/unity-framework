using Framework.Core.Objects.Components;

namespace Framework.Core.Cache
{
    public abstract class CacheBase : DependentComponent
    {
        internal const string BuiltInPath = "Cache/";
        protected internal const string CustomPath = BuiltInPath + "Custom/";
    }
}