using NUnit.Framework;
using MyMath;

namespace MyMath.Tests
{
    [TestFixture]
    public class MatrixTests
    {
        [Test]
        public void Divide_MatrixIsNull_ReturnsNull()
        {
            // Arrange
            int[,] matrix = null;
            int num = 5;

            // Act
            int[,] result = Matrix.Divide(matrix, num);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Divide_DivisorIsZero_ReturnsNull()
        {
            // Arrange
            int[,] matrix = new int[,] { { 1, 2 }, { 3, 4 } };
            int num = 0;

            // Act
            int[,] result = Matrix.Divide(matrix, num);

            // Assert
            Assert.IsNull(result);
        }

        [Test]
        public void Divide_DivisorIsPositive_ReturnsCorrectResult()
        {
            // Arrange
            int[,] matrix = new int[,] { { 4, 8 }, { 12, 16 } };
            int num = 2;
            int[,] expected = new int[,] { { 2, 4 }, { 6, 8 } };

            // Act
            int[,] result = Matrix.Divide(matrix, num);

            // Assert
            Assert.AreEqual(expected, result);
        }
    }
}
