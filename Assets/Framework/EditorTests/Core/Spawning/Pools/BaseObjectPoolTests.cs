using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Core.Objects;
using Framework.Core.Spawning.Pools;
using NUnit.Framework;

namespace Framework.EditorTests.Core.Spawning.Pools
{
    [TestFixture]
    public class BaseObjectPoolTests
    {
        private IPool<IBaseObject> _pool;

        [SetUp]
        public void SetUp()
        {
            const int size = 10;
            _pool = new BaseObjectPool(size, () => new MockPoolBaseObject());
        }

        [Test]
        [TestCase(-10)]
        [TestCase(-1)]
        [TestCase(0)]
        public void Ctor_InvalidSize_ThrowsArgumentOutOfRangeException(int invalidSize)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
                new BaseObjectPool(invalidSize, () => new MockPoolBaseObject()));
        }
        
        [Test]
        [TestCase(1)]
        [TestCase(10)]
        public void Ctor_ValidSize_NoExceptions(int validSize)
        { 
            new BaseObjectPool(validSize, () => new MockPoolBaseObject());
        }
        
        [Test]
        public void Ctor_NullCreationProcedure_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() =>
                new BaseObjectPool(1, null));
        }
        
        [Test]
        public void Ctor_NotNullCreationProcedure_NoExceptions()
        {
            new BaseObjectPool(1, () => new MockPoolBaseObject());
        }

        [Test]
        public void Initialize_Initialized()
        {
            _pool.Initialize();
            Assert.That(_pool.Initialized);
        }

        [Test]
        public void Spawn_LessThanSize_AllDistinct()
        {
            _pool.Initialize();

            var spawnedCount = _pool.Size / 2;
            var objects = SpawnNObjects(spawnedCount).Distinct().ToArray();
            
            Assert.AreEqual(spawnedCount, objects.Length);
        }
        
        [Test]
        public void Spawn_EqualToSize_AllDistinct()
        {
            _pool.Initialize();

            var spawnedCount = _pool.Size;
            var objects = SpawnNObjects(spawnedCount).Distinct().ToArray();
            
            Assert.AreEqual(spawnedCount, objects.Length);
        }
        
        [Test]
        public void Spawn_GreaterThanSize_NotAllDistinct()
        {
            _pool.Initialize();

            var spawnedCount = _pool.Size * 2;
            var objects = SpawnNObjects(spawnedCount).Distinct().ToArray();
            
            Assert.AreEqual(_pool.Size, objects.Length);
        }

        private IEnumerable<IBaseObject> SpawnNObjects(int count) => Enumerable.Range(0, count).Select(i => _pool.Spawn());
    }
}