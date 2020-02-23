using Framework.Core.Objects.Bases;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;

namespace Framework.PlayTests.Core.Objects.Bases
{
    [TestFixture]
    public class BaseComponentTests
    {
        private BaseComponent _baseComponent;

        [SetUp]
        public void SetUp()
        {
            var gameObject = new GameObject();
            _baseComponent = gameObject.AddComponent<OrdinaryBaseComponent>();
        }

        [Test]
        public void Destroy_OnDestroyedUnityEventIsCalledExactlyOnce()
        {
            var onDestroyed = GetOnDestroyedEvent();
            var calls = 0;
            onDestroyed.AddListener(() => calls++);

            for (var i = 0; i < 5; i++)
            {
                _baseComponent.Destroy();
            }

            Assert.That(calls, Is.EqualTo(1));
        }

        [NotNull]
        private UnityEvent GetOnDestroyedEvent()
        {
            return (UnityEvent) _baseComponent.GetPrivateFieldValue("_onDestroyed");
        }

        [TearDown]
        public void TearDown()
        {
            if (_baseComponent != null && _baseComponent.GameObject != null)
                _baseComponent.Destroy();
        }
    }
}