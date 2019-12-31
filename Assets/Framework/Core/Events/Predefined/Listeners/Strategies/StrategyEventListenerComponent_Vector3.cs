using Framework.Core.Events.Components;
using Framework.Core.Events.Predefined.Events;
using Framework.Core.Strategies.Concrete;
using UnityEngine;

namespace Framework.Core.Events.Predefined.Listeners.Strategies
{
    [AddComponentMenu(BuiltInPath + "Vector3")]
    public class StrategyEventListenerComponent_Vector3 : StrategyEventListenerComponent<Vector3, GameEvent_Vector3, StrategyAsset_Vector3>
    {
        
    }
}