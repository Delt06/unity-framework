namespace Framework.Core.Events
{
    public interface IRaiseable<in T>
    {
        void Raise(T args);
    }
}