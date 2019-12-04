namespace Framework.Core.Values
{
    public class BasicValueProvider<T> : IValueProvider<T>
    {
        public BasicValueProvider(T value)
        {
            Value = value;
        }

        public T Value { get; }

        public static implicit operator BasicValueProvider<T>(T value) => new BasicValueProvider<T>(value);
    }
}