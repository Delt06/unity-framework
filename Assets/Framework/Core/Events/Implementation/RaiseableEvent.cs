using System;
using System.Collections.Generic;
using JetBrains.Annotations;

namespace Framework.Core.Events.Implementation
{
    public class RaiseableEvent<T> : IRaiseableEvent<T>
    {
        [NotNull]
        private readonly IList<Action<T>> _callbacks = new List<Action<T>>();
        
        public void Raise(T args)
        {
            for (var i = _callbacks.Count - 1; i >= 0; i--)
            {
                _callbacks[i](args);
            }
        }

        public event Action<T> Raised
        {
            add
            {
                if (value != null) _callbacks.Add(value);
            }
            remove
            {
                if (value != null) RemoveLastOccurenceOf(value);
            }
        }

        private void RemoveLastOccurenceOf(Action<T> removedCallback)
        {
            for (var i = _callbacks.Count - 1; i >= 0; i--)
            {
                var callback = _callbacks[i];
                if (!Equals(callback, removedCallback)) continue;
                
                _callbacks.RemoveAt(i);
                return;
            }
        }
    }
}