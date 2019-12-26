using System;
using Core.Values.Assets.References;
using Framework.Core.Values.Assets.Variables.Concrete;
using Object = UnityEngine.Object;

namespace Framework.Core.Values.Assets.References.Concrete
{
    [Serializable]
    public sealed class Reference_UnityObject : Reference<Object, Variable_UnityObject>
    {
        public static implicit operator Reference_UnityObject(Object value)
        {
            return new Reference_UnityObject {Constant = value};
        }
    }
}