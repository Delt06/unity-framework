using System;
using Core.Values.Assets.References;
using Framework.Core.Values.Assets.Variables.Concrete;

namespace Framework.Core.Values.Assets.References.Concrete
{
    [Serializable]
    public sealed class Reference_UnityObject : Reference<UnityEngine.Object, Variable_UnityObject>
    {
    }
}