namespace Core.Values
{
    public interface IValueProvider<out T>
    {
        T Value { get; }
    }
}