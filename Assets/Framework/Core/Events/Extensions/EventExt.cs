using System;
using JetBrains.Annotations;

namespace Framework.Core.Events.Extensions
{
    public static class EventExt
    {
        public static void Raise([NotNull] this IRaiseable<EventArgs> raiseable)
        {
            if (raiseable is null) throw new ArgumentNullException(nameof(raiseable));

            raiseable.Raise(EventArgs.Empty);
        }
    }
}