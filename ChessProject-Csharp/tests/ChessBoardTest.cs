using NUnit.Framework;

namespace SolarWinds.MSP.Chess
{
    [TestFixture]
    public class ChessBoardTest
    {
        private ChessBoard _chessBoard;

        [SetUp]
        public void SetUp()
        {
            _chessBoard = new ChessBoard();
        }

        [Test]
        public void Has_MaxBoardWidth_of_7()
        {
            Assert.AreEqual(ChessBoard.MaxBoardWidth, 7);
        }

        [Test]
        public void Has_MaxBoardHeight_of_7()
        {
            Assert.AreEqual(ChessBoard.MaxBoardHeight, 7);
        }

        [Test]
        public void Avoids_Duplicate_Positioning()
        {
            var firstPawn = new Pawn(ChessPieceColor.Black);
            var secondPawn = new Pawn(ChessPieceColor.Black);
            var firstResult = _chessBoard.Add(firstPawn, new ChessCoordinates(6,3));
            Assert.AreEqual(firstResult, AddResult.Success);
            var secondResult = _chessBoard.Add(secondPawn, new ChessCoordinates(6, 3));
            Assert.AreEqual(secondResult, AddResult.CoordinatesOccupied);
            Assert.AreEqual(firstPawn.Coordinates.X, 6);
            Assert.AreEqual(firstPawn.Coordinates.Y, 3);
            Assert.AreEqual(secondPawn.Coordinates, null);
        }

        [Test]
        public void Check_If_Coordinates_Occupied()
        {
            var occupied = _chessBoard.IsOccupied(new ChessCoordinates(6,3));
            Assert.False(occupied);
            var pawn = new Pawn(ChessPieceColor.Black);
            _chessBoard.Add(pawn, new ChessCoordinates(6, 3));
            occupied = _chessBoard.IsOccupied(new ChessCoordinates(6, 3));
            Assert.True(occupied);
        }

        //[Test]
        //public void Limits_The_Number_Of_Pawns()
        //{
        //    for (var i = 0; i < 10; i++)
        //    {
        //        var pawn = new Pawn(ChessPieceColor.Black);
        //        var row = i / ChessBoard.MaxBoardWidth;
        //        _chessBoard.Add(pawn, 6 + row, i % ChessBoard.MaxBoardWidth, ChessPieceColor.Black);
        //        if (row < 1)
        //        {
        //            Assert.AreEqual(pawn.XCoordinate, (6 + row));
        //            Assert.AreEqual(pawn.YCoordinate, (i % ChessBoard.MaxBoardWidth));
        //        }
        //        else
        //        {
        //            Assert.AreEqual(pawn.XCoordinate, -1);
        //            Assert.AreEqual(pawn.YCoordinate, -1);
        //        }
        //    }
        //}
    }
}
