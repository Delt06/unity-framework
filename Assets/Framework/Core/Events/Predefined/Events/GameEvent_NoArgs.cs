using System;
using Framework.Core.Events.Assets;
using UnityEngine;

namespace Framework.Core.Events.Predefined.Events
{
    [CreateAssetMenu(menuName = BuiltInPath + "No Args")]
    public sealed class GameEvent_NoArgs : GameEvent<EventArgs>
    {
        
    }
}