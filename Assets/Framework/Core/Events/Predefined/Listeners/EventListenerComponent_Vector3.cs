using Framework.Core.Events.Components;
using Framework.Core.Events.Predefined.Events;
using Framework.Core.Events.Predefined.UnityEvents;
using UnityEngine;

namespace Framework.Core.Events.Predefined.Listeners
{
    [AddComponentMenu(BuiltInPath + "Vector3")]
    public class EventListenerComponent_Vector3 : EventListenerComponent<Vector3, GameEvent_Vector3, UnityEvent_Vector3>
    {

    }
}