namespace Framework.Core.Strategies
{
    public interface IStrategy<in T>
    {
        void Execute(T args);
    }
}