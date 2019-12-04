using System;
using Core.Assets;
using JetBrains.Annotations;
using UnityEngine;

namespace Core.Values.Assets.Variables
{
    public class Variable<T> : ScriptableObject, IValueManager<T>, ICloneableAs<Variable<T>>
    {
        [SerializeField] private T _value = default;
        
        public T Value
        {
            get => _value;
            set => _value = value;
        }

        public static implicit operator T([NotNull] Variable<T> variable)
        {
            if (variable is null) throw new ArgumentNullException(nameof(variable));
            return variable.Value;
        }

        public TClone CloneAs<TClone>() where TClone : Variable<T>
        {
            var clone = CreateInstance<TClone>();
            clone.Value = Value;
            return clone;
        }
        
        internal const string BuiltInPath = "Variable/";
        protected internal const string CustomPath = BuiltInPath + "Custom/";
    }
}