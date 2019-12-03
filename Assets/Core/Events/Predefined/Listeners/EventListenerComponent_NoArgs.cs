using System;
using Core.Events.Components;
using Core.Events.Predefined.Events;
using Core.Events.Predefined.UnityEvents;
using UnityEngine;

namespace Core.Events.Predefined.Listeners
{
    [AddComponentMenu(BuiltInPath + "No Args")]
    public class EventListenerComponent_NoArgs : EventListenerComponent<EventArgs, GameEvent_NoArgs, UnityEvent_NoArgs>
    {
        
    }
}