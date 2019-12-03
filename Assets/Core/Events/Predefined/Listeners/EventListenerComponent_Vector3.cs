using Core.Events.Components;
using Core.Events.Predefined.Events;
using Core.Events.Predefined.UnityEvents;
using UnityEngine;

namespace Core.Events.Predefined.Listeners
{
    [AddComponentMenu(BuiltInPath + "Vector3")]
    public class EventListenerComponent_Vector3 : EventListenerComponent<Vector3, GameEvent_Vector3, UnityEvent_Vector3>
    {
        
    }
}