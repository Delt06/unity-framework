using System;
using System.Runtime.CompilerServices;
using Core.Values.Assets.Variables;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Assertions;

namespace Core.Values.Assets.References
{
    [Serializable]
    public class Reference<TValue, TProvider> : IValueProvider<TValue>
        where TProvider : IValueProvider<TValue>
    {
        [SerializeField] private TValue _constant = default;
        [SerializeField] private TProvider _provider = default;
        [SerializeField] internal bool UseConstant = true;
        
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
    }
}