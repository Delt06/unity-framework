using System;
using Core.Values.Assets.References;
using Framework.Core.Values.Assets.Variables.Concrete;
using UnityEngine;

namespace Framework.Core.Values.Assets.References.Concrete
{
    [Serializable]
    public class Reference_Curve : Reference<AnimationCurve, Variable_Curve>
    {
        public static implicit operator Reference_Curve(AnimationCurve value)
        {
            return new Reference_Curve {Constant = value};
        }
    }
}