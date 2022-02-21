using System;
using NUnit.Framework;

namespace SolarWinds.MSP.Chess
{
    [TestFixture]
    public class ChessCoordinatesTest
    {
        private ChessCoordinates _coordinates;

        [SetUp]
        public void SetUp()
        {
            _coordinates = new ChessCoordinates(0,0);
        }

        [Test]
        public void Coordinate_X_negative_number()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new ChessCoordinates(-1, 0));
        }

        [Test]
        public void Coordinate_Y_negative_number()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new ChessCoordinates(0, -1));
        }

        [Test]
        public void Coordinate_XY_negative_number()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new ChessCoordinates(-1, -1));
        }

    }
}
