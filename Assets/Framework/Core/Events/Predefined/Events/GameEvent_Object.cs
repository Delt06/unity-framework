using Framework.Core.Events.Assets;
using UnityEngine;

namespace Framework.Core.Events.Predefined.Events
{
    [CreateAssetMenu(menuName = BuiltInPath + "Object")]
    public sealed class GameEvent_Object : GameEvent<object>
    {

    }
}