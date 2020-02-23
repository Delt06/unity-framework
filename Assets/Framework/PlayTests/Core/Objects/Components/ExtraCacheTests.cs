using Framework.Core.Objects;
using Framework.Core.Objects.Bases;
using NUnit.Framework;
using UnityEngine;

namespace Framework.PlayTests.Core.Objects.Components
{
    [TestFixture]
    public class ExtraCacheTests
    {
        private BaseComponent _baseObject;

        [SetUp]
        public void SetUp()
        {
            var gameObject = new GameObject();
            _baseObject = gameObject.AddComponent<OrdinaryBaseComponent>();
        }

        [Test]
        public void AddExtraObject_CanBeFound()
        {
            var objectToAdd = new SomeObject();
            
            AddExtraObjects(objectToAdd);
            _baseObject.Initialize();
            
            Assert.That(_baseObject.TryFind(out SomeObject foundObject), Is.True);
            Assert.AreSame(objectToAdd, foundObject);
        }

        private void AddExtraObjects(params object[] extraObjects)
        {
            var extraCacheComponent = _baseObject.GameObject.AddComponent<MockExtraCache>();
            extraCacheComponent.Objects = extraObjects;
        }

        [TearDown]
        public void TearDown()
        {
            if (_baseObject != null && _baseObject.GameObject != null)
                Object.Destroy(_baseObject.GameObject);
        }
    }
}