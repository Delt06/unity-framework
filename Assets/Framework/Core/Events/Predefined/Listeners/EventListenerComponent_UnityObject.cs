using Framework.Core.Events.Components;
using Framework.Core.Events.Predefined.Events;
using Framework.Core.Events.Predefined.UnityEvents;
using UnityEngine;

namespace Framework.Core.Events.Predefined.Listeners
{
    [AddComponentMenu(BuiltInPath + "Unity Object")]
    public class EventListenerComponent_UnityObject : EventListenerComponent
        <Object, GameEvent_UnityObject, UnityEvent_UnityObject>
    {

    }
}