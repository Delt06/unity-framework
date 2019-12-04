using Framework.Core.Events.Assets;
using UnityEngine;

namespace Framework.Core.Events.Predefined.Events
{
    [CreateAssetMenu(menuName = BuiltInPath + "String")]
    public class GameEvent_String : GameEvent<string>
    {
        
    }
}