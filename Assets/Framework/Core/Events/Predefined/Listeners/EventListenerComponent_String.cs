using Framework.Core.Events.Components;
using Framework.Core.Events.Predefined.Events;
using Framework.Core.Events.Predefined.UnityEvents;
using UnityEngine;

namespace Framework.Core.Events.Predefined.Listeners
{
    [AddComponentMenu(BuiltInPath + "String")]
    public class EventListenerComponent_String : EventListenerComponent<string, GameEvent_String, UnityEvent_String>
    {

    }
}