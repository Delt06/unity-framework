using Framework.Core.Events.Assets;
using UnityEngine;

namespace Framework.Core.Events.Predefined.Events
{
    [CreateAssetMenu(menuName = BuiltInPath + "Vector2")]
    public sealed class GameEvent_Vector2 : GameEvent<Vector2>
    {
        
    }
}