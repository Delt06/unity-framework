using System;
using Core.Events.Implementation;
using JetBrains.Annotations;
using UnityEngine;

namespace Core.Events.Assets
{
    public class GameEvent<T> : ScriptableObject, IRaiseableEvent<T>
    {
        [NotNull]
        private readonly IRaiseableEvent<T> _innerEvent = new RaiseableEvent<T>();
        
        public void Raise(T args) => _innerEvent.Raise(args);

        public event Action<T> Raised
        {
            add => _innerEvent.Raised += value;
            remove => _innerEvent.Raised -= value;
        }

        internal const string BuiltInPath = "Event/";
        protected internal const string CustomPath = BuiltInPath + "Custom/";
    }
}