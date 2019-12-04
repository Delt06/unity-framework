namespace Framework.Core.Values
{
    public interface IValueManager<T> : IValueProvider<T>
    {
        new T Value { get; set; }
    }
}