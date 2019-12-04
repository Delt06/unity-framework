namespace Framework.Core.Values
{
    public class BasicValueManager<T> : IValueManager<T>
    {
        public T Value { get; set; }

        public BasicValueManager(T value)
        {
            Value = value;
        }

        public BasicValueManager()
        {
            
        }
    }
}