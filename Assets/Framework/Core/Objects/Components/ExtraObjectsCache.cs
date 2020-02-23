using System.Collections.Generic;
using UnityEngine;

namespace Framework.Core.Objects.Components
{
    [AddComponentMenu("Extra Objects Cache")]
    public sealed class ExtraObjectsCache : ExtraCache
    {
        [SerializeField] private Object[] _objects = new Object[1];
        
        protected override IEnumerable<object> GetObjects()
        {
            foreach (var obj in _objects)
            {
                if (obj != null)
                    yield return obj;
            }
        }
    }
}