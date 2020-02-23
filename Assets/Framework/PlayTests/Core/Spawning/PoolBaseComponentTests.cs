using Framework.Core.Spawning.Pools;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;

namespace Framework.PlayTests.Core.Spawning
{
    [TestFixture]
    public class PoolBaseComponentTests
    {
        private GameObject _gameObject;
        private PoolBaseComponent _poolBase;

        [SetUp]
        public void SetUp()
        {
            _gameObject = new GameObject();
            _poolBase = _gameObject.AddComponent<PoolBaseComponent>();
            _poolBase.Activate();
            _poolBase.Deactivate();
        }

        [Test]
        public void Deactivate_BecomesNotActive()
        {
            _poolBase.Deactivate();
            
            Assert.That(_poolBase.IsActive, Is.False);
        }

        [Test]
        public void Activate_BecomesActive()
        {
            _poolBase.Activate();
            
            Assert.That(_poolBase.IsActive);
        }

        [Test]
        public void Deactivate_GameObjectBecomesNotActive()
        {
            _poolBase.Deactivate();
            
            Assert.That(_gameObject.activeSelf, Is.False);
        }

        [Test]
        public void Activate_AfterDeactivate_BecomesActive()
        {
            _poolBase.Activate();
            
            Assert.That(_gameObject.activeSelf, Is.True);
        }

        [Test]
        public void Deactivate_SeveralTimes_OnDeactivatedCalledOnce()
        {
            _poolBase.Activate();
            
            var onDeactivated = GetOnDeactivatedUnityEvent();
            var calls = 0;
            onDeactivated.AddListener(() => calls++);

            for (var i = 0; i < 5; i++)
            {
                _poolBase.Deactivate();
            }
            
            Assert.That(calls, Is.EqualTo(1));
        }
        
        [Test]
        public void Activate_SeveralTimes_OnDeactivatedCalledOnce()
        {
            var onActivated = GetOnActivatedUnityEvent();
            var calls = 0;
            onActivated.AddListener(() => calls++);

            for (var i = 0; i < 5; i++)
            {
                _poolBase.Activate();
            }
            
            Assert.That(calls, Is.EqualTo(1));
        }

        [Test]
        public void Destroy_BecomesDeactivated()
        {
            _poolBase.Destroy();
            
            Assert.That(_poolBase.IsActive, Is.False);
        }

        [Test]
        public void Destroyed_GameObjectIsStillAlive()
        {
            _poolBase.Destroy();
            
            Assert.That(GameObjectExists);
        }

        private bool GameObjectExists => _gameObject != null;
        
        [Test]
        public void Deactivate_BecomesDestroyed()
        {
            _poolBase.Deactivate();
            
            Assert.That(_poolBase.IsDestroyed);
        }

        [Test]
        public void Activate_BecomesNotDestroyed()
        {
            _poolBase.Activate();
            
            Assert.That(_poolBase.IsDestroyed, Is.False);
        }

        [NotNull]
        private UnityEvent GetOnActivatedUnityEvent()
        {
            return (UnityEvent) _poolBase.GetPrivateFieldValue("_onActivated");
        }
        
        [NotNull]
        private UnityEvent GetOnDeactivatedUnityEvent()
        {
            return (UnityEvent) _poolBase.GetPrivateFieldValue("_onDeactivated");
        }

        [TearDown]
        public void TearDown()
        {
            if (GameObjectExists)
                Object.Destroy(_gameObject);
        }
    }
}