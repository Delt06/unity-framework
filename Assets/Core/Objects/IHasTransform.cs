using UnityEngine;

namespace Core.Objects
{
    public interface IHasTransform
    {
        Transform Transform { get; }
    }
}