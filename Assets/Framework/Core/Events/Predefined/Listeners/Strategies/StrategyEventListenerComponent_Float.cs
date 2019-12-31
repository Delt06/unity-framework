using Framework.Core.Events.Components;
using Framework.Core.Events.Predefined.Events;
using Framework.Core.Strategies.Concrete;
using UnityEngine;

namespace Framework.Core.Events.Predefined.Listeners.Strategies
{
    [AddComponentMenu(BuiltInPath + "Float")]
    public class StrategyEventListenerComponent_Float : StrategyEventListenerComponent<float, GameEvent_Float, StrategyAsset_Float>
    {
        
    }
}