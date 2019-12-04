using JetBrains.Annotations;

namespace Framework.Core.Spawning
{
    public interface ISpawner<out T>
    {
        [NotNull]
        T Spawn();
    }
}