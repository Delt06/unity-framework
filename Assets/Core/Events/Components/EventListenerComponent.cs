using Core.Events.Assets;
using Core.Events.Implementation;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Events.Components
{
    public class EventListenerComponent<TArgs, TGameEvent, TUnityEvent> : MonoBehaviour, IEventListener
        where TGameEvent : GameEvent<TArgs>
        where TUnityEvent : UnityEvent<TArgs>
    {
        [SerializeField] private TGameEvent _gameEvent = default;
        [SerializeField] private TUnityEvent _callback = default;

        private IEventListener _innerListener;

        protected void Awake()
        {
            if (_gameEvent == null)
            {
                Debug.LogError("Game event is not set.", gameObject);
                return;
            }

            if (_callback == null)
            {
                Debug.LogError("Callback is not set.", gameObject);
                return;
            }

            _innerListener = new EventListener<TArgs>(
                args => _callback.Invoke(args), 
                _gameEvent);
        }

        protected void OnEnable()
        {
            _innerListener.Enable();
        }

        protected void OnDisable()
        {
            _innerListener.Disable();
        }

        public void Enable()
        {
            enabled = true;
        }

        public void Disable()
        {
            enabled = false;
        }

        internal const string BuiltInPath = "Event Listeners/Listener_";
        protected internal const string CustomPath = "Event Listeners/Custom/Listener_";
    }
}