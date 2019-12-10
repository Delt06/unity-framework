using Framework.Core.Events.Assets;
using UnityEngine;

namespace Framework.Core.Events.Predefined.Events
{
    [CreateAssetMenu(menuName = BuiltInPath + "Unity Object")]
    public sealed class GameEvent_UnityObject : GameEvent<UnityEngine.Object>
    {
        
    }
}