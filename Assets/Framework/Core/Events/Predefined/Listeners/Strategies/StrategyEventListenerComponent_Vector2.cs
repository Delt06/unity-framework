using Framework.Core.Events.Components;
using Framework.Core.Events.Predefined.Events;
using Framework.Core.Strategies.Concrete;
using UnityEngine;

namespace Framework.Core.Events.Predefined.Listeners.Strategies
{
    [AddComponentMenu(BuiltInPath + "Vector2")]
    public class StrategyEventListenerComponent_Vector2 : StrategyEventListenerComponent<Vector2, GameEvent_Vector2, StrategyAsset_Vector2>
    {
        
    }
}