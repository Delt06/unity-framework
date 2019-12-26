using System;
using Core.Values.Assets.References;
using Framework.Core.Values.Assets.Variables.Concrete;
using UnityEngine;

namespace Framework.Core.Values.Assets.References.Concrete
{
    [Serializable]
    public class Reference_Transform : Reference<Transform, Variable_Transform>
    {
        public static implicit operator Reference_Transform(Transform value)
        {
            return new Reference_Transform {Constant = value};
        }
    }
}