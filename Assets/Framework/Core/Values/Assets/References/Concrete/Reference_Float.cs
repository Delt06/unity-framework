using System;
using Core.Values.Assets.References;
using Framework.Core.Values.Assets.Variables.Concrete;

namespace Framework.Core.Values.Assets.References.Concrete
{
    [Serializable]
    public class Reference_Float : Reference<float, Variable_Float>
    {
        public static implicit operator Reference_Float(float value)
        {
            return new Reference_Float {Constant = value};
        }
    }
}