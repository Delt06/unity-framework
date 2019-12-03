namespace Core.Events
{
    public interface IRaiseableEvent<T> : IRaiseable<T>, IEvent<T>
    {
        
    }
}