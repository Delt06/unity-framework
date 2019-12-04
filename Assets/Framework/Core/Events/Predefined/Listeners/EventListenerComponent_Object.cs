using Framework.Core.Events.Components;
using Framework.Core.Events.Predefined.Events;
using Framework.Core.Events.Predefined.UnityEvents;
using UnityEngine;

namespace Framework.Core.Events.Predefined.Listeners
{
    [AddComponentMenu(BuiltInPath + "Object")]
    public class EventListenerComponent_Object : EventListenerComponent<object, GameEvent_Object, UnityEvent_Object>
    {
        
    }
}