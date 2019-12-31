using Framework.Core.Events.Components;
using Framework.Core.Events.Predefined.Events;
using Framework.Core.Strategies.Concrete;
using UnityEngine;

namespace Framework.Core.Events.Predefined.Listeners.Strategies
{
    [AddComponentMenu(BuiltInPath + "String")]
    public class StrategyEventListenerComponent_String : StrategyEventListenerComponent<string, GameEvent_String, StrategyAsset_String>
    {
        
    }
}