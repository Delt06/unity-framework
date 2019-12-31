using System;
using Framework.Core.Events.Components;
using Framework.Core.Events.Predefined.Events;
using Framework.Core.Strategies.Concrete;
using UnityEngine;

namespace Framework.Core.Events.Predefined.Listeners.Strategies
{
    [AddComponentMenu(BuiltInPath + "No Args")]
    public class StrategyEventListenerComponent_NoArgs : StrategyEventListenerComponent<EventArgs, GameEvent_NoArgs, StrategyAsset_NoArgs>
    {
        
    }
}