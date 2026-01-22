using CalculatorLibrary;
using NUnit.Framework;
namespace CalculatorNUnit
{
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator _calculator = null!;

        [SetUp]
        public void Setup()
        {
            _calculator = new Calculator();
        }

        [Test]
        public void Add_5And3_Returns8()
        {
            int result = _calculator.Add(5, 3);
            Assert.That(result, Is.EqualTo(8));
        }

        [Test]
        public void Subtract_10Minus5_Returns5()
        {
            int result = _calculator.Subtract(10, 5);
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Multiply_6Times7_Returns42()
        {
            int result = _calculator.Multiply(6, 7);
            Assert.That(result, Is.EqualTo(42));
        }

        [Test]
        public void Divide_10By2_Returns5()
        {
            int result = _calculator.Divide(10, 2);
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Divide_ByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => _calculator.Divide(10, 0));
        }

        // Data-driven test example 
        [TestCase(2, 3, 5)]
        [TestCase(10, 20, 30)]
        [TestCase(-5, 5, 0)]
        public void Add_DataDrivenTests(int a, int b, int expected)
        {
            int result = _calculator.Add(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }
    }
}