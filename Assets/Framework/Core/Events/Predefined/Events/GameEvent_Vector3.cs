using Framework.Core.Events.Assets;
using UnityEngine;

namespace Framework.Core.Events.Predefined.Events
{
    [CreateAssetMenu(menuName = BuiltInPath + "Vector3")]
    public sealed class GameEvent_Vector3 : GameEvent<Vector3>
    {

    }
}