using System;
using JetBrains.Annotations;

namespace Framework.Core.Values
{
    public class FunctionalValueProvider<T> : IValueProvider<T>
    {
        [NotNull] private readonly Func<T> _getter;

        public FunctionalValueProvider([NotNull] Func<T> function)
        {
            _getter = function ?? throw new ArgumentNullException(nameof(function));
        }

        public static implicit operator FunctionalValueProvider<T>([NotNull] Func<T> function)
        {
            if (function is null) throw new ArgumentNullException(nameof(function));
            return new FunctionalValueProvider<T>(function);
        }

        public T Value => _getter();
    }
}