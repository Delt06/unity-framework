using Framework.Core.Objects;
using Framework.Core.Objects.Bases;
using Framework.Core.Objects.Components;
using JetBrains.Annotations;
using NUnit.Framework;
using UnityEngine;

namespace Framework.PlayTests.Core.Objects
{
    [TestFixture]
    public class BaseObjectSearchTests
    {
        private GameObject _childWithReference;
        private GameObject _root;
        private Component _simpleComponentWithReference;
        private DependentComponent _dependentComponentInitialized;
        private IBaseObject _baseObject;

        private Component _simpleComponentWithoutReference;
        private DependentComponent _dependentComponentNotInitialized;
        private GameObject _childWithoutReference;

        [SetUp]
        public void SetUp()
        {
            _root = new GameObject();
            _baseObject = _root.AddComponent<OrdinaryBaseComponent>();

            _childWithReference = CreateChild();

            _simpleComponentWithReference = _childWithReference.AddComponent<FakeComponent>();
            _dependentComponentInitialized = _childWithReference.AddComponent<DependentComponent>();
            
            _childWithoutReference = CreateChild();
            _simpleComponentWithoutReference = _childWithoutReference.AddComponent<FakeComponent>();
            
            _baseObject.Initialize();

            _dependentComponentNotInitialized = _childWithoutReference.AddComponent<DependentComponent>();
        }

        [NotNull]
        private GameObject CreateChild()
        {
            var child = new GameObject();
            child.transform.SetParent(_root.transform);
            return child;
        }

        [Test]
        public void HasBaseObject_Root_Finds()
        {
            var found = _root.HasBaseObject(out var foundBaseObject);
            
            Assert.That(found);
            Assert.That(foundBaseObject, Is.EqualTo(_baseObject));
        }

        [Test]
        public void HasBaseObject_SimpleComponentWithReference_Finds()
        {
            var found = _simpleComponentWithReference.HasBaseObject(out var foundBaseObject);
            
            Assert.That(found);
            Assert.That(foundBaseObject, Is.EqualTo(_baseObject));
        }
        
        [Test]
        public void HasBaseObject_ChildWithReference_Finds()
        {
            var found = _childWithReference.HasBaseObject(out var foundBaseObject);
            
            Assert.That(found);
            Assert.That(foundBaseObject, Is.EqualTo(_baseObject));
        }
        
        [Test]
        public void HasBaseObject_DependentComponentInitialized_Finds()
        {
            var found = _dependentComponentInitialized.HasBaseObject(out var foundBaseObject);
            
            Assert.That(found);
            Assert.That(foundBaseObject, Is.EqualTo(_baseObject));
        }
        
        [Test]
        public void HasBaseObject_ChildWithoutReference_DoesNotFind()
        {
            Assert.That(_childWithoutReference.HasBaseObject(out _), Is.False);
        }
        
        [Test]
        public void HasBaseObject_SimpleComponentWithoutReference_DoesNotFind()
        {
            Assert.That(_simpleComponentWithoutReference.HasBaseObject(out _), Is.False);
        }
        
        [Test]
        public void HasBaseObject_DependentComponentNotInitialized_DoesNotFind()
        {
            Assert.That(_dependentComponentNotInitialized.HasBaseObject(out _), Is.False);
        }

        [TearDown]
        public void TearDown()
        {
            if (_root != null) 
                Object.Destroy(_root);
        }
    }
}