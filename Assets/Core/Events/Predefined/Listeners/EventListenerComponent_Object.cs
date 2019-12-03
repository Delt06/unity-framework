using Core.Events.Components;
using Core.Events.Predefined.Events;
using Core.Events.Predefined.UnityEvents;
using UnityEngine;

namespace Core.Events.Predefined.Listeners
{
    [AddComponentMenu(BuiltInPath + "Object")]
    public class EventListenerComponent_Object : EventListenerComponent<object, GameEvent_Object, UnityEvent_Object>
    {
        
    }
}