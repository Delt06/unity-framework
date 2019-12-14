using System;
using Core.Values.Assets.References;
using Framework.Core.Values.Assets.Variables.Concrete;

namespace Framework.Core.Values.Assets.References.Concrete
{
    [Serializable]
    public sealed class Reference_Int : Reference<int, Variable_Int>
    {
        public static implicit operator Reference_Int(int value)
        {
            return new Reference_Int {Constant = value};
        }
    }
}