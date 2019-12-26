using System;
using Core.Values.Assets.References;
using Framework.Core.Values.Assets.Variables.Concrete;
using UnityEngine;

namespace Framework.Core.Values.Assets.References.Concrete
{
    [Serializable]
    public class Reference_GameObject : Reference<GameObject, Variable_GameObject>
    {
        public static implicit operator Reference_GameObject(GameObject value)
        {
            return new Reference_GameObject {Constant = value};
        }
    }
}