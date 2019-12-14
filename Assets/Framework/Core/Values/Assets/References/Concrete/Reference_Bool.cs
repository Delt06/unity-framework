using System;
using Core.Values.Assets.References;
using Framework.Core.Values.Assets.Variables.Concrete;

namespace Framework.Core.Values.Assets.References.Concrete
{
    [Serializable]
    public sealed class Reference_Bool : Reference<bool, Variable_Bool>
    {
        public static implicit operator Reference_Bool(bool value)
        {
            return new Reference_Bool {Constant = value};
        }
    }
}