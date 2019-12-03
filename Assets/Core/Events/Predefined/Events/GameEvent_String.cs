using Core.Events.Assets;
using UnityEngine;

namespace Core.Events.Predefined.Events
{
    [CreateAssetMenu(menuName = BuiltInPath + "String")]
    public class GameEvent_String : GameEvent<string>
    {
        
    }
}