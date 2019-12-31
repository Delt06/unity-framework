using Framework.Core.Events.Components;
using Framework.Core.Events.Predefined.Events;
using Framework.Core.Strategies.Concrete;
using UnityEngine;

namespace Framework.Core.Events.Predefined.Listeners.Strategies
{
    [AddComponentMenu(BuiltInPath + "Unity Object")]
    public class StrategyEventListenerComponent_UnityObject : StrategyEventListenerComponent<UnityEngine.Object, GameEvent_UnityObject, StrategyAsset_UnityObject>
    {
        
    }
}