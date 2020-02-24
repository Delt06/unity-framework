using System;

namespace Framework.Core.Strategies.Concrete
{
    public abstract class StrategyAsset_NoArgs : StrategyAsset<EventArgs>
    {
        public void Execute() => Execute(EventArgs.Empty);
    }
}