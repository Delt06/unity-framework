using Framework.Core.Events.Assets;
using UnityEngine;

namespace Framework.Core.Events.Predefined.Events
{
    [CreateAssetMenu(menuName = BuiltInPath + "Float")]
    public sealed class GameEvent_Float : GameEvent<float>
    {
        
    }
}