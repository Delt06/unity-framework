using System;
using System.Runtime.CompilerServices;
using Framework.Core.Values;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;

namespace Core.Values.Assets.References
{
    [Serializable]
    public abstract class ReferenceBase
    {
        [SerializeField] internal bool UseConstant = true;
    }
    
    [Serializable]
    public class Reference<TValue, TProvider> : ReferenceBase, IValueProvider<TValue>
        where TProvider : IValueProvider<TValue>
    {
        [SerializeField] private TValue _constant = default;
        [SerializeField] private TProvider _provider = default;

        public TValue Value => UseConstant ? _constant : _provider.Value;
        
        public static implicit operator TValue([NotNull] Reference<TValue, TProvider> reference)
        {
            if (reference is null) throw new ArgumentNullException(nameof(reference));
            return reference.Value;
        }

        public Reference()
        {
            
        }

        public Reference(TValue constant, TProvider provider, bool useConstant)
        {
            _constant = constant;
            _provider = provider;
            UseConstant = useConstant;
        }
        
        public override string ToString() => $"Reference<{typeof(TValue)}> {Value.ToString()}";

        internal TValue Constant
        {
            get => _constant;
            set => _constant = value;
        }
        
        internal TProvider Provider
        {
            get => _provider;
            set => _provider = value;
        }
    }
}