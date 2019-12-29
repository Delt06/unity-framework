using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Framework.Core.Objects.Bases.Extensions
{
    public static class GameObjectExt
    {
        public static bool HasCache([NotNull] this GameObject gameObject, 
            out IComponentCache cache)
        {
            if (gameObject == null) throw new ArgumentNullException(nameof(gameObject));
            return gameObject.TryGetComponent(out cache);
        }
    }
}