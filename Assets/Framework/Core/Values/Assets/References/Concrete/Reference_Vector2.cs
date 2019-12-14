using System;
using Core.Values.Assets.References;
using Framework.Core.Values.Assets.Variables.Concrete;
using UnityEngine;

namespace Framework.Core.Values.Assets.References.Concrete
{
    [Serializable]
    public sealed class Reference_Vector2 : Reference<Vector2, Variable_Vector2>
    {
        public static implicit operator Reference_Vector2(Vector2 value)
        {
            return new Reference_Vector2 {Constant = value};
        }
    }
}