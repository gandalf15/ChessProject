using System;
using NUnit.Framework;

namespace SolarWinds.MSP.Chess.Tests
{
    [TestFixture]
    public class ChessCoordinatesTest
    {
        private static readonly int[] AllowedCoordinatesRange = { 0, 1, 2, 3, 4, 5, 6, 7 };

        [Test]
        public void Should_not_be_able_to_create_ChessCoordinate_with_negative_X_value()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ChessCoordinates(-1, 0));
        }

        [Test]
        public void Should_not_be_able_to_create_ChessCoordinate_with_negative_Y_value()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ChessCoordinates(0, -1));
        }

        [Test]
        public void Should_not_be_able_to_create_ChessCoordinate_with_negative_X_and_Y_value()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ChessCoordinates(-1, -1));
        }

        [Test]
        public void Should_not_be_able_to_create_ChessCoordinate_with_X_value_greater_than_7()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ChessCoordinates(8, 0));
        }

        [Test]
        public void Should_not_be_able_to_create_ChessCoordinate_with_Y_value_greater_than_7()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ChessCoordinates(0, 8));
        }

        [Test]
        public void Should_not_be_able_to_create_ChessCoordinate_with_X_and_Y_values_greater_than_7()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ChessCoordinates(8, 8));
        }

        [Test]
        [TestCaseSource(nameof(AllowedCoordinatesRange))]
        public void Should_be_able_to_create_ChessCoordinate_with_X_value_in_range_0_up_to_7(int x)
        {
            var coordinates = new ChessCoordinates(x, 0);
            Assert.AreEqual(x, coordinates.X);
        }

        [Test]
        [TestCaseSource(nameof(AllowedCoordinatesRange))]
        public void Should_be_able_to_create_ChessCoordinate_with_Y_value_in_range_0_up_to_7(int y)
        {
            var coordinates = new ChessCoordinates(0, y);
            Assert.AreEqual(y, coordinates.Y);
        }
    }
}
