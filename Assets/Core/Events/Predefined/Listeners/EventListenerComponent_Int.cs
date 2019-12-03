using Core.Events.Components;
using Core.Events.Predefined.Events;
using Core.Events.Predefined.UnityEvents;
using UnityEngine;

namespace Core.Events.Predefined.Listeners
{
    [AddComponentMenu(BuiltInPath + "Integer")]
    public class EventListenerComponent_Int : EventListenerComponent<int, GameEvent_Int, UnityEvent_Int>
    {
        
    }
}