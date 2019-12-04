using System;
using Core.Values.Assets.References;
using Framework.Core.Values.Assets.Variables.Concrete;

namespace Framework.Core.Values.Assets.References.Concrete
{
    [Serializable]
    public class Reference_String : Reference<string, Variable_String>
    {
        public static implicit operator Reference_String(string value)
        {
            return new Reference_String {Constant = value};
        }
    }
}