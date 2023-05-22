using NUnit.Framework;
using MyMath;

namespace MyMath.Tests
{
    [TestFixture]
    public class OperationsTests
    {
        [Test]
        public void Add_WithPositiveNumbers_ReturnsCorrectSum()
        {
            // Arrange
            int a = 5;
            int b = 3;

            // Act
            int result = Operations.Add(a, b);

            // Assert
            Assert.AreEqual(8, result);
        }

        [Test]
        public void Add_WithNegativeNumbers_ReturnsCorrectSum()
        {
            // Arrange
            int a = -10;
            int b = -7;

            // Act
            int result = Operations.Add(a, b);

            // Assert
            Assert.AreEqual(-17, result);
        }

        [Test]
        public void Add_WithZero_ReturnsSameNumber()
        {
            // Arrange
            int a = 15;
            int b = 0;

            // Act
            int result = Operations.Add(a, b);

            // Assert
            Assert.AreEqual(a, result);
        }
    }
}
