using System;
using Core.Values.Assets.References;
using JetBrains.Annotations;

namespace Framework.Core.Values.Assets.References
{
    public static class ReferenceExtensions
    {
        public static bool HasValue<TValue, TProvider>([NotNull] this Reference<TValue, TProvider> reference)
            where TProvider : IValueProvider<TValue>
        {
            if (reference is null) throw new ArgumentNullException(nameof(reference));

            return reference.UseConstant || reference.Provider != null;
        }
    }
}