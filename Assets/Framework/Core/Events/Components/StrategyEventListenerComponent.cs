using Framework.Core.Events.Assets;
using Framework.Core.Events.Implementation;
using Framework.Core.Strategies;
using UnityEngine;

namespace Framework.Core.Events.Components
{
    public class StrategyEventListenerComponent<TArgs, TGameEvent, TStrategy>: MonoBehaviour, IEventListener
        where TGameEvent : GameEvent<TArgs>
        where TStrategy : StrategyAsset<TArgs>
    {
        [SerializeField] private TGameEvent _gameEvent = default;
        [SerializeField] private TStrategy _strategy = default;

        private IEventListener _innerListener;

        protected void Awake()
        {
            if (_gameEvent == null)
            {
                Debug.LogError("Game event is not set.", gameObject);
                return;
            }

            if (_strategy == null)
            {
                Debug.LogError("Strategy is not set.", gameObject);
                return;
            }

            _innerListener = new EventListener<TArgs>(
                args => _strategy.Execute(args), 
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

        internal const string BuiltInPath = "Event Listeners/Strategy Listener ";
        protected internal const string CustomPath = "Event Listeners/Custom/Strategy Listener ";
    }
}