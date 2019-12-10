using Core.Values.Assets.References;
using Framework.Core.Values;
using Framework.Core.Values.Assets.References;
using NUnit.Framework;

namespace Framework.EditorTests.Core.Values.Assets.References
{
    [TestFixture]
    public class ReferenceTests
    {
        private Reference<int, IValueProvider<int>> _reference;
        
        [Test]
        public void Value_UseConstant_ReturnsConstant()
        {
            const int constant = 1;
            const int provider = 2;
            _reference = new Reference<int, IValueProvider<int>>(constant, new BasicValueProvider<int>(provider), true);
            
            Assert.AreEqual(_reference.Value, constant);
        }
        
        [Test]
        public void Value_UseProvider_ReturnsProviderValue()
        {
            const int constant = 1;
            const int provider = 2;
            _reference = new Reference<int, IValueProvider<int>>(constant, new BasicValueProvider<int>(provider), false);
            
            Assert.AreEqual(_reference.Value, provider);
        }
        
        [Test]
        public void HasValue_HasAndUseProvider_ReturnsTrue()
        {
            IValueProvider<int> provider = new BasicValueProvider<int>(10);
            var reference = new Reference<int, IValueProvider<int>>(0, provider, false);
            
            Assert.That(reference.HasValue());
        }
        
        [Test]
        public void HasValue_HasAndDontUseProvider_ReturnsTrue()
        {
            IValueProvider<int> provider = new BasicValueProvider<int>(10);
            var reference = new Reference<int, IValueProvider<int>>(0, provider, true);
            
            Assert.That(reference.HasValue());
        }
        
        [Test]
        public void HasValue_DoesNotHaveAndDontUseProvider_ReturnsTrue()
        {
            IValueProvider<int> provider = new BasicValueProvider<int>(10);
            var reference = new Reference<int, IValueProvider<int>>(0, provider, true);
            
            Assert.That(reference.HasValue());
        }
        
        [Test]
        public void HasValue_DoesNotHaveAndUseProvider_ReturnsFalse()
        {
            var reference = new Reference<int, IValueProvider<int>>(0, null, false);
            
            Assert.IsFalse(reference.HasValue());
        }
    }
}