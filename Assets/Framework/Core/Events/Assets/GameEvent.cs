using System;
using Framework.Core.Events.Implementation;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Events;

namespace Framework.Core.Events.Assets
{
    public class GameEvent<T> : ScriptableObject, IRaiseableEvent<T>
    {
        [SerializeField] private UnityEvent _onRaised = default;

        [NotNull]
        private readonly IRaiseableEvent<T> _innerEvent = new RaiseableEvent<T>();

        public void Raise(T args)
        {
            _onRaised.Invoke();
            _innerEvent.Raise(args);
        }

        public event Action<T> Raised
        {
            add => _innerEvent.Raised += value;
            remove => _innerEvent.Raised -= value;
        }

        internal const string BuiltInPath = "Event/";
        protected internal const string CustomPath = BuiltInPath + "Custom/";
    }
}