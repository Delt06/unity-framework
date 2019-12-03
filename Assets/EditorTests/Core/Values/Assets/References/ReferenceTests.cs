using Core.Values;
using Core.Values.Assets.References;
using NUnit.Framework;

namespace EditorTests.Core.Values.Assets.References
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
    }
}