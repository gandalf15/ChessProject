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
            _pawn = new Pawn(PieceColor.Black);
        }

        [Test]
        public void ChessBoard_Add_Sets_XCoordinate()
        {
            _chessBoard.Add(_pawn, 6, 3, PieceColor.Black);
            Assert.AreEqual(_pawn.XCoordinate, 6);
        }

        [Test]
        public void ChessBoard_Add_Sets_YCoordinate()
        {
            _chessBoard.Add(_pawn, 6, 3, PieceColor.Black);
            Assert.AreEqual(_pawn.YCoordinate, 3);
        }

        [Test]
        public void Pawn_Move_IllegalCoordinates_Right_DoesNotMove()
        {
            _chessBoard.Add(_pawn, 6, 3, PieceColor.Black);
            _pawn.Move(MovementType.Move, 7, 3);
            Assert.AreEqual(_pawn.XCoordinate, 6);
            Assert.AreEqual(_pawn.YCoordinate, 3);
        }

        [Test]
        public void Pawn_Move_IllegalCoordinates_Left_DoesNotMove()
        {
            _chessBoard.Add(_pawn, 6, 3, PieceColor.Black);
            _pawn.Move(MovementType.Move, 4, 3);
            Assert.AreEqual(_pawn.XCoordinate, 6);
            Assert.AreEqual(_pawn.YCoordinate, 3);
        }

        [Test]
        public void Pawn_Move_LegalCoordinates_Forward_UpdatesCoordinates()
        {
            _chessBoard.Add(_pawn, 6, 3, PieceColor.Black);
            _pawn.Move(MovementType.Move, 6, 2);
            Assert.AreEqual(_pawn.XCoordinate, 6);
            Assert.AreEqual(_pawn.YCoordinate, 2);
        }
    }
}
