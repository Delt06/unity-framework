using System;
using Framework.Core.Events.Components;
using Framework.Core.Events.Predefined.Events;
using Framework.Core.Events.Predefined.UnityEvents;
using UnityEngine;

namespace Framework.Core.Events.Predefined.Listeners
{
    [AddComponentMenu(BuiltInPath + "No Args")]
    public class EventListenerComponent_NoArgs : EventListenerComponent<EventArgs, GameEvent_NoArgs, UnityEvent_NoArgs>
    {
        
    }
}