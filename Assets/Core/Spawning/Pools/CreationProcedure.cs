using JetBrains.Annotations;

namespace Core.Spawning.Pools
{
    [NotNull]
    public delegate T CreationProcedure<out T>();
}