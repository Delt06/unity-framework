using Framework.Core.Events.Components;
using Framework.Core.Events.Predefined.Events;
using Framework.Core.Events.Predefined.UnityEvents;
using UnityEngine;

namespace Framework.Core.Events.Predefined.Listeners
{
    [AddComponentMenu(BuiltInPath + "Integer")]
    public class EventListenerComponent_Int : EventListenerComponent<int, GameEvent_Int, UnityEvent_Int>
    {
        
    }
}