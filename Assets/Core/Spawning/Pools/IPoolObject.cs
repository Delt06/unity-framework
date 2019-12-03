using System;

namespace Core.Spawning.Pools
{
    public interface IPoolObject
    {
        bool IsActive { get; }
        
        void Activate();
        void Deactivate();

        event EventHandler Activated;
        event EventHandler Deactivated;
    }
}