using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace Framework.EditorTests
{
    public static class CollectionUtils
    {
        public static bool HasSameElementsAs<T>([NotNull] this IEnumerable<T> first, [NotNull] IEnumerable<T> second)
        {
            if (first is null) throw new ArgumentNullException(nameof(first));
            if (second is null) throw new ArgumentNullException(nameof(second));

            var firstArray = first.ToArray();
            var secondArray = second.ToArray();

            return firstArray.All(i => NumberIsTheSame(firstArray, secondArray, i))
                   && secondArray.All(i => NumberIsTheSame(firstArray, secondArray, i));

        }

        private static bool NumberIsTheSame<T>(
            [NotNull] IEnumerable<T> first,
            [NotNull] IEnumerable<T> second,
            T item)
        {
            if (first is null) throw new ArgumentNullException(nameof(first));
            if (second is null) throw new ArgumentNullException(nameof(second));

            var firstNumber = first.Count(i => Equals(i, item));
            var secondNumber = second.Count(i => Equals(i, item));

            return firstNumber == secondNumber;
        }
    }
}