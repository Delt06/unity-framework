using UnityEngine;

namespace Framework.Core.Physics
{
    public interface IHasTransform
    {
        Transform Transform { get; }
    }
}