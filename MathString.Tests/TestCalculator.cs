using MathString.Library;
using NUnit.Framework;

namespace MathString.Tests
{
    [TestFixture]
    internal class TestCalculator
    {
        [Test]
        public void DivisionByZero()
        {
            string expression = "2 / 0";

            Assert.Throws<DivideByZeroException>(() => Calculator.Calculate(expression));
        }

        [Test]
        public void TestOperations()
        {
            string expression = "2+2*(222-125)+32/2*1";
            int result = Calculator.Calculate(expression);

            Assert.That(result, Is.EqualTo(212));
        }
    }
}