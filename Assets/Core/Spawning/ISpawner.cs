using JetBrains.Annotations;

namespace Core.Spawning
{
    public interface ISpawner<out T>
    {
        [NotNull]
        T Spawn();
    }
}