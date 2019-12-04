using UnityEngine;

namespace Framework.Core.Objects
{
    public interface IHasTransform
    {
        Transform Transform { get; }
    }
}