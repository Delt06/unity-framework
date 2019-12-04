using Framework.Core.Events.Components;
using Framework.Core.Events.Predefined.Events;
using Framework.Core.Events.Predefined.UnityEvents;
using UnityEngine;

namespace Framework.Core.Events.Predefined.Listeners
{
    [AddComponentMenu(BuiltInPath + "Float")]
    public class EventListenerComponent_Float : EventListenerComponent<float, GameEvent_Float, UnityEvent_Float>
    {
        
    }
}