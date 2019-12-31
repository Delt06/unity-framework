using Framework.Core.Events.Components;
using Framework.Core.Events.Predefined.Events;
using Framework.Core.Strategies.Concrete;
using UnityEngine;

namespace Framework.Core.Events.Predefined.Listeners.Strategies
{
    [AddComponentMenu(BuiltInPath + "Integer")]
    public class StrategyEventListenerComponent_Integer : StrategyEventListenerComponent<int, GameEvent_Int, StrategyAsset_Int>
    {
        
    }
}