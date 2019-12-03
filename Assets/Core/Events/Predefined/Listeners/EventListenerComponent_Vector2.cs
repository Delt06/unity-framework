using Core.Events.Components;
using Core.Events.Predefined.Events;
using Core.Events.Predefined.UnityEvents;
using UnityEngine;

namespace Core.Events.Predefined.Listeners
{
    [AddComponentMenu(BuiltInPath + "Vector2")]
    public class EventListenerComponent_Vector2 : EventListenerComponent<Vector2, GameEvent_Vector2, UnityEvent_Vector2>
    {
        
    }
}