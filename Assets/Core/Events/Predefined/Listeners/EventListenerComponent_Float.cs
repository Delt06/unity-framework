using Core.Events.Components;
using Core.Events.Predefined.Events;
using Core.Events.Predefined.UnityEvents;
using UnityEngine;

namespace Core.Events.Predefined.Listeners
{
    [AddComponentMenu(BuiltInPath + "Float")]
    public class EventListenerComponent_Float : EventListenerComponent<float, GameEvent_Float, UnityEvent_Float>
    {
        
    }
}