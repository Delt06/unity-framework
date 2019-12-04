using System.Collections.Generic;
using Framework.Core.Events;
using Framework.Core.Events.Implementation;
using NUnit.Framework;

namespace Framework.EditorTests.Core.Events
{
    [TestFixture]
    public class RaiseableEventTests
    {
        private IRaiseableEvent<int> _event;

        [SetUp]
        public void SetUp()
        {
            _event = new RaiseableEvent<int>();
        }
        
        
        [Test]
        public void Raise_AfterSubscription_CallbackIsInvoked()
        {
            var invoked = false;
            
            _event.Raised += i => invoked = true;
            _event.Raise(0);
            
            Assert.That(invoked);
        }

        [Test]
        [TestCase(0), TestCase(1), TestCase(-1), TestCase(123), TestCase(-123)]
        public void Raise_AfterSubscription_ProperArgumentIsPassed(int passedArgument)
        {
            int? receivedArgument = null;
            
            _event.Raised += i => receivedArgument = i;
            _event.Raise(passedArgument);
            
            Assert.AreEqual(passedArgument, receivedArgument);
        }

        [Test]
        [TestCase(1, 2, 3), TestCase(0), TestCase(-1, 5, 10), TestCase(1, 3, 3)]
        public void Raise_AfterSeveralSubscriptions_AllCallbacksAreInvoked(params int[] addedItems)
        {
            var receivedItems = new List<int>();

            foreach (var item in addedItems)
            {
                var addedItem = item;
                _event.Raised += i => receivedItems.Add(addedItem);
            }

            _event.Raise(0);

            Assert.That(receivedItems.HasSameElementsAs(addedItems));
        }

        [Test]
        public void Raise_SubscribeAndThenUnsubscribe_NothingIsInvoked()
        {
            var invoked = false;
            void Callback(int i) => invoked = true;
            
            _event.Raised += Callback;
            _event.Raised -= Callback;
            _event.Raise(0);
            
            Assert.IsFalse(invoked);
        }
        
        [Test]
        public void Raise_TwoSubscribeAndOneUnsubscribe_RemainingInvoked()
        {
            var invoked1 = false;
            var invoked2 = false;
            void Callback1(int i) => invoked1 = true;
            void Callback2(int i) => invoked2 = true;
            
            _event.Raised += Callback1;
            _event.Raised += Callback2;
            _event.Raised -= Callback1;
            _event.Raise(0);
            
            Assert.IsFalse(invoked1);
            Assert.IsTrue(invoked2);
        }
        
        [Test]
        public void Raise_UnsubscribeInsideCallback_UnsubscribedNotInvoked()
        {
            var invoked1 = false;
            var invoked2 = false;
            void Callback1(int i) => invoked1 = true;
            void Callback2(int i)
            {
                _event.Raised -= Callback1;
                invoked2 = true;
            }

            _event.Raised += Callback1;
            _event.Raised += Callback2;
            _event.Raise(0);
            
            Assert.IsFalse(invoked1);
            Assert.IsTrue(invoked2);
        }
    }
}