using System;
using NUnit.Framework;

namespace SolarWinds.MSP.Chess
{
    [TestFixture]
    public class PawnTest
    {
        private ChessBoard _chessBoard;
        private Pawn _pawn;

        [SetUp]
        public void SetUp()
        {
            _chessBoard = new ChessBoard();
            _pawn = new Pawn(ChessPieceColor.Black);
        }

        [Test]
        public void Pawn_Prints_nicely()
        {
            var pawn = new Pawn(ChessPieceColor.White);
            Assert.AreEqual(null, pawn.Coordinates);
            pawn.Coordinates = new ChessCoordinates(1, 2);
            Assert.AreEqual(1, pawn.Coordinates.X);
            TestContext.Out.WriteLine(pawn);
        }
    }
}
