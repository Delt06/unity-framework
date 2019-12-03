using System;

namespace Core.Events
{
    public interface IEvent<out T>
    {
        event Action<T> Raised;
    }
}