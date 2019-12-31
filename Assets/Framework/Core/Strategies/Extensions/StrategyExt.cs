using System;
using JetBrains.Annotations;

namespace Framework.Core.Strategies.Extensions
{
    public static class StrategyExt
    {
        public static void Execute([NotNull] this IStrategy<EventArgs> strategy)
        {
            if (strategy is null) throw new ArgumentNullException(nameof(strategy));
            
            strategy.Execute(EventArgs.Empty);
        }
    }
}