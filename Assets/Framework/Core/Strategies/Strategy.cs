using System;
using JetBrains.Annotations;

namespace Framework.Core.Strategies
{
    public static class Strategy
    {
        [NotNull]
        public static IStrategy<T> FromAction<T>([NotNull] Action<T> action)
        {
            if (action is null) throw new ArgumentNullException(nameof(action));
            
            return new ActionStrategy<T>(action);
        }
        
        private class ActionStrategy<T> : IStrategy<T>
        {
            [NotNull] private readonly Action<T> _action;

            public ActionStrategy([NotNull] Action<T> action)
            {
                _action = action ?? throw new ArgumentNullException(nameof(action));
            }

            public void Execute(T args) => _action(args);
        }
    }
}