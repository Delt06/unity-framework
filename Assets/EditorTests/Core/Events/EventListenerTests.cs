using System;
using Core.Events;
using Core.Events.Implementation;
using NUnit.Framework;

namespace EditorTests.Core.Events
{
    [TestFixture]
    public class EventListenerTests
    {
        private IRaiseableEvent<EventArgs> _event;
        private IEventListener _listener;
        private Action<EventArgs> _callback;

        private bool CallbackInvoked { get; set; }

        [SetUp]
        public void SetUp()
        {
            _event = new RaiseableEvent<EventArgs>();
            
            CallbackInvoked = false;
            _callback = i => CallbackInvoked = true;
            
            _listener = new EventListener<EventArgs>(_callback, _event);
        }

        [Test]
        public void Ctor_NullEvent_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new EventListener<EventArgs>(_callback, null));
        }
        
        [Test]
        public void Ctor_NullCallback_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new EventListener<EventArgs>(null, _event));
        }
        
        [Test]
        public void Ctor_NotNullArguments_DoesNotThrowExceptions()
        {
            var listener = new EventListener<EventArgs>(_callback, _event);
        }

        [Test]
        public void Raise_Enable_CallbackInvoked()
        {
            _listener.Enable();

            _event.Raise(EventArgs.Empty);
            
            Assert.That(CallbackInvoked);
        }
        
        [Test]
        public void Raise_Disable_CallbackNotInvoked()
        {
            _listener.Disable();

            _event.Raise(EventArgs.Empty);
            
            Assert.IsFalse(CallbackInvoked);
        }
        
        [Test]
        public void Raise_EnableAfterDisable_CallbackInvoked()
        {
            _listener.Disable();
            _listener.Enable();

            _event.Raise(EventArgs.Empty);
            
            Assert.That(CallbackInvoked);
        }
        
        [Test]
        public void Raise_DisableAfterEnable_CallbackNotInvoked()
        {
            _listener.Enable();
            _listener.Disable();

            _event.Raise(EventArgs.Empty);
            
            Assert.IsFalse(CallbackInvoked);
        }
    }
}