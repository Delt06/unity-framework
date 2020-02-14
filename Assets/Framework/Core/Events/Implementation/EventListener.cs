using System;
using JetBrains.Annotations;

namespace Framework.Core.Events.Implementation
{
    public class EventListener<T> : IEventListener
    {
        [NotNull] private readonly Action<T> _callback;
        [NotNull] private readonly IEvent<T> _eventToListen;
        private bool _enabled;

        public EventListener([NotNull] Action<T> callback, [NotNull] IEvent<T> eventToListen)
        {
            _callback = callback ?? throw new ArgumentNullException(nameof(callback));
            _eventToListen = eventToListen ?? throw new ArgumentNullException(nameof(eventToListen));
        }

        public void Enable()
        {
            if (_enabled) return;
            
            _eventToListen.Raised += _callback;
            _enabled = true;
        }

        public void Disable()
        {
            if (!_enabled) return;

            _eventToListen.Raised -= _callback;
            _enabled = false;
        }
    }
}