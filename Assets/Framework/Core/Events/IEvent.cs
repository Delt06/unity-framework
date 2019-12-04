using System;

namespace Framework.Core.Events
{
    public interface IEvent<out T>
    {
        event Action<T> Raised;
    }
}