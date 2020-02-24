using System;
using JetBrains.Annotations;
using UnityEngine;

namespace Framework.Core.Objects
{
    public static class BaseObjectSearch
    {
        public static bool HasBaseObject([NotNull] this Component component, out IBaseObject baseObject)
        {
            if (component == null) throw new ArgumentNullException(nameof(component));

            var gameObject = component.gameObject;

            return CanExtractBaseDirectly(component, out baseObject) ||
                   HasBaseObject(gameObject, out baseObject);
        }

        private static bool CanExtractBaseDirectly([NotNull] Component component, out IBaseObject baseObject)
        {
            if (component is IDependentObject dependentObject) 
                return CanExtractBaseFromDependent(dependentObject, out baseObject);
            
            baseObject = default;
            return false;

        }

        private static bool CanExtractBaseFromDependent([NotNull] IDependentObject dependentObject, out IBaseObject baseObject)
        {
            if (dependentObject.Initialized)
            {
                baseObject = dependentObject.Base;
                return true;
            }

            baseObject = default;
            return false;
        }

        public static bool HasBaseObject([NotNull] this GameObject gameObject, out IBaseObject baseObject)
        {
            if (gameObject == null) throw new ArgumentNullException(nameof(gameObject));
            
            return gameObject.TryGetComponent(out baseObject) || 
                   CanExtractBaseFromSibling(gameObject, out baseObject);
        }

        private static bool CanExtractBaseFromSibling([NotNull] GameObject gameObject, out IBaseObject baseObject)
        {
            baseObject = default;
            
            return gameObject.TryGetComponent(out IDependentObject dependentObject) &&
                CanExtractBaseFromDependent(dependentObject, out baseObject);
        }
    }
}