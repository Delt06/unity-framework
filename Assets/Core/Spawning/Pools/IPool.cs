namespace Core.Spawning.Pools
{
    public interface IPool<out T> : ISpawner<T>
    {
        int Size { get; }
        
        bool Initialized { get; }

        void Initialize();
    }
}