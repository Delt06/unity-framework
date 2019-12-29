using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Framework.Core.Objects.Bases.Extensions
{
    public static class ComponentExt
    {
        public static bool HasCache([NotNull] this Component component, 
            out IComponentCache cache)
        {
            if (component == null) throw new ArgumentNullException(nameof(component));
            return component.TryGetComponent(out cache);
        }
    }
}