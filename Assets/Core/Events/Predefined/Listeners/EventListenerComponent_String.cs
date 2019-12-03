using Core.Events.Components;
using Core.Events.Predefined.Events;
using Core.Events.Predefined.UnityEvents;
using UnityEngine;

namespace Core.Events.Predefined.Listeners
{
    [AddComponentMenu(BuiltInPath + "String")]
    public class EventListenerComponent_String : EventListenerComponent<string, GameEvent_String, UnityEvent_String>
    {
        
    }
}