using Framework.Core.Events.Assets;
using UnityEngine;

namespace Framework.Core.Events.Predefined.Events
{
    [CreateAssetMenu(menuName = BuiltInPath + "Integer")]
    public sealed class GameEvent_Int : GameEvent<int>
    {
        
    }
}