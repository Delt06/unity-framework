using JetBrains.Annotations;

namespace Framework.Core.Spawning.Pools
{
    [NotNull]
    public delegate T CreationProcedure<out T>();
}