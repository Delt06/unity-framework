using Framework.Core.Events.Components;
using Framework.Core.Events.Predefined.Events;
using Framework.Core.Events.Predefined.UnityEvents;
using UnityEngine;

namespace Framework.Core.Events.Predefined.Listeners
{
    [AddComponentMenu(BuiltInPath + "Vector2")]
    public class EventListenerComponent_Vector2 : EventListenerComponent<Vector2, GameEvent_Vector2, UnityEvent_Vector2>
    {
        
    }
}