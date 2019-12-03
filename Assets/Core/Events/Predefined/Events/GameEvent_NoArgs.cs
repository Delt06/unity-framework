using System;
using Core.Events.Assets;
using UnityEngine;

namespace Core.Events.Predefined.Events
{
    [CreateAssetMenu(menuName = BuiltInPath + "No Args")]
    public class GameEvent_NoArgs : GameEvent<EventArgs>
    {
        
    }
}