using System;
using Core.Values.Assets.References;
using Framework.Core.Values.Assets.Variables.Concrete;
using UnityEngine;

namespace Framework.Core.Values.Assets.References.Concrete
{
    [Serializable]
    public sealed class Reference_Vector3 : Reference<Vector3, Variable_Vector3>
    {
        public static implicit operator Reference_Vector3(Vector3 value)
        {
            return new Reference_Vector3 {Constant = value};
        }
    }
}