using System;
using JetBrains.Annotations;

namespace Framework.Core.Values
{
    public class FunctionalValueManager<T> : IValueManager<T>
    {
        [NotNull] private readonly Func<T> _getter;
        [NotNull] private readonly Action<T> _setter;

        public FunctionalValueManager([NotNull] Func<T> getter, [NotNull] Action<T> setter)
        {
            _getter = getter ?? throw new ArgumentNullException(nameof(getter));
            _setter = setter ?? throw new ArgumentNullException(nameof(setter));
        }

        public T Value
        {
            get => _getter();
            set => _setter(value);
        }
    }
}