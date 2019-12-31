using Framework.Core.Events.Components;
using Framework.Core.Events.Predefined.Events;
using Framework.Core.Strategies.Concrete;
using UnityEngine;

namespace Framework.Core.Events.Predefined.Listeners.Strategies
{
    [AddComponentMenu(BuiltInPath + "Object")]
    public class StrategyEventListenerComponent_Object : StrategyEventListenerComponent<object, GameEvent_Object, StrategyAsset_Object>
    {
        
    }
}