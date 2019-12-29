using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Core.Objects;
using Framework.Core.Objects.Bases;
using Framework.EditorTests.Core.Objects.Components;
using JetBrains.Annotations;
using NUnit.Framework;

namespace Framework.EditorTests.Core.Objects.Bases
{
    [TestFixture]
    public class ComponentCacheTests
    {
        private IComponentCache _cache;
        
        [SetUp]
        public void SetUp()
        {
            _cache = new ComponentCache();
        }

        [Test]
        public void Cache_One_CanBeFound()
        {
            var cachedComponent = new DependentComponentAlone();
            _cache.CacheDependent(cachedComponent);
            
            Assert.IsTrue(_cache.TryFind<DependentComponentAlone>(out var retrievedComponent));
            Assert.AreEqual(cachedComponent, retrievedComponent);
        }

        [Test]
        public void Cache_Two_CanBeFound()
        {
            var cachedComponent = new DependentComponentAlone();
            _cache.CacheDependent(cachedComponent);
            _cache.CacheDependent(new DependentComponentParent());
            
            Assert.IsTrue(_cache.TryFind<DependentComponentAlone>(out var retrievedComponent));
            Assert.AreEqual(cachedComponent, retrievedComponent);
        }
        
        [Test]
        public void Cache_TwoReversed_CanBeFound()
        {
            var cachedComponent = new DependentComponentAlone();
            
            _cache.CacheDependent(new DependentComponentParent());
            _cache.CacheDependent(cachedComponent);

            Assert.IsTrue(_cache.TryFind<DependentComponentAlone>(out var retrievedComponent));
            Assert.AreEqual(cachedComponent, retrievedComponent);
        }
        
        [Test]
        public void Cache_Zero_CantBeFound()
        {
            Assert.IsFalse(_cache.TryFind<DependentComponentAlone>(out _));
        }

        [Test]
        [TestCase(10, 4)]
        [TestCase(30, 2)]
        [TestCase(40, 1)]
        public void Count_EqualsToNumberOfDistinctObjects(int expectedCount, int numberOfDuplicates)
        {
            for (var distinctObjectIndex = 0; distinctObjectIndex < expectedCount; distinctObjectIndex++)
            {
                var distinctObject = new DependentComponentAlone();
                
                for (var duplicateIndex = 0; duplicateIndex < numberOfDuplicates; duplicateIndex++)
                {
                    _cache.CacheDependent(distinctObject);
                }
            }
            
            Assert.AreEqual(expectedCount, _cache.Count);
        }

        [Test]
        public void TryFindComponent_ActualType_Found()
        {
            var cachedComponent = new DependentComponentChild();
            
            _cache.CacheDependent(cachedComponent);
            
            Assert.IsTrue(_cache.TryFind(out DependentComponentChild foundComponent));
            Assert.AreEqual(cachedComponent, foundComponent);
        }

        [Test]
        public void TryFindComponent_ParentType_Found()
        {
            var cachedComponent = new DependentComponentChild();
            
            _cache.CacheDependent(cachedComponent);
            
            Assert.IsTrue(_cache.TryFind(out DependentComponentParent foundComponent));
            Assert.AreEqual(cachedComponent, foundComponent);
        }

        [Test]
        public void TryFindComponent_ChildType_NotFound()
        {
            var cachedComponent = new DependentComponentParent();
            
            _cache.CacheDependent(cachedComponent);
            
            Assert.IsFalse(_cache.TryFind<DependentComponentChild>(out _));
        }
        
        [Test]
        public void TryFindComponent_OtherType_NotFound()
        {
            var cachedComponent = new DependentComponentAlone();
            
            _cache.CacheDependent(cachedComponent);
            
            Assert.IsFalse(_cache.TryFind<DependentComponentChild>(out _));
        }

        [Test]
        public void FindComponents_SameAsOfType()
        {
            var cachedComponents = new HashSet<IDependentObject>();
            Populate(cachedComponents);
            
            foreach (var cachedComponent in cachedComponents)
            {
                _cache.CacheDependent(cachedComponent);
            }
            
            var cachedComponentsTyped = cachedComponents.OfType<DependentComponentParent>().ToArray();
            var retrievedComponents = _cache.FindMany<DependentComponentParent>().ToArray();

            Assert.IsTrue(CollectionsAreDeepEqual(cachedComponentsTyped, retrievedComponents));
        }

        private static void Populate([NotNull] ICollection<IDependentObject> componentCollection)
        {
            if (componentCollection is null) throw new ArgumentNullException(nameof(componentCollection));
            
            const int numberOfEachType = 10;

            for (var i = 0; i < numberOfEachType; i++)
            {
                componentCollection.Add(new DependentComponentAlone());
                componentCollection.Add(new DependentComponentChild());
                componentCollection.Add(new DependentComponentParent());
            }
        }

        private bool CollectionsAreDeepEqual<T>([NotNull] IReadOnlyCollection<T> first, 
            [NotNull] IReadOnlyCollection<T> second)
        {
            if (first is null) throw new ArgumentNullException(nameof(first));
            if (second is null) throw new ArgumentNullException(nameof(second));

            return first.Count == second.Count && first.All(second.Contains) && second.All(first.Contains);
        }

        [Test]
        public void GetEnumerator_ReturnsAllComponents()
        {
            var cachedComponents = new HashSet<IDependentObject>();
            Populate(cachedComponents);
            
            foreach (var cachedComponent in cachedComponents)
            {
                _cache.CacheDependent(cachedComponent);
            }

            var allEnumeratedComponents = _cache.ToArray();
            var retrievedComponents = _cache.FindMany<IDependentObject>().ToArray();

            Assert.IsTrue(CollectionsAreDeepEqual(allEnumeratedComponents, retrievedComponents));
        }
    }
}