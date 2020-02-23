using System;
using System.Reflection;
using JetBrains.Annotations;

namespace Framework.PlayTests
{
    public static class PrivateAccess
    {
        public static object GetPrivateFieldValue<TType>([NotNull] this TType obj, [NotNull] string fieldName)
        {
            if (obj == null) throw new ArgumentNullException(nameof(obj));
            if (fieldName == null) throw new ArgumentNullException(nameof(fieldName));

            var field = typeof(TType).GetField(fieldName, BindingFlags.NonPublic | BindingFlags.Instance);
            if (field == null) throw new InvalidOperationException("Field not found.");

            return field.GetValue(obj);
        }
    }
}