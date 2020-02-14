using System;
using Framework.Core.Values.Assets.Variables.Concrete;
using NUnit.Framework;
using UnityEngine;

namespace Framework.PlayTests.Core.Values.Assets.Variables
{
    [TestFixture]
    public class VariableTests
    {
        [Test]
        [TestCase(0)]
        [TestCase(-3)]
        [TestCase( 15)]
        public void Value_Set_ReturnsNew(int value)
        {
            var variable = ScriptableObject.CreateInstance<Variable_Int>();

            variable.Value = value;

            Assert.AreEqual(value, variable.Value);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-3)]
        [TestCase( 15)]
        public void Operator_Implicit_ReturnsValue(int value)
        {
            var variable = ScriptableObject.CreateInstance<Variable_Int>();

            variable.Value = value;
            int valueFromOperator = variable;

            Assert.AreEqual(variable.Value, valueFromOperator);
        }

        [Test]
        [TestCase(0)]
        [TestCase(-3)]
        [TestCase( 15)]
        public void Operator_Null_ThrowsArgumentNullException(int value)
        {
            Variable_Int variable = null;

            Assert.Throws<ArgumentNullException>(() =>
            {
                var result = (int) variable;
            });
        }

        [Test]
        [TestCase(0)]
        [TestCase(-3)]
        [TestCase( 15)]
        public void CloneAs_SameType_ReturnsClone(int value)
        {
            var variable = ScriptableObject.CreateInstance<Variable_Int>();

            variable.Value = value;
            var clone = variable.CloneAs<Variable_Int>();

            Assert.AreNotSame(variable, clone);
            Assert.AreEqual(variable.Value, clone.Value);
        }
    }
}