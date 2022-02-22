using System.Collections;
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
        public void Should_have_MaxBoardWidth_8()
        {
            Assert.AreEqual(ChessBoard.MaxBoardWidth, 8);
        }

        [Test]
        public void Should_have_MaxBoardHeight_8()
        {
            Assert.AreEqual(ChessBoard.MaxBoardHeight, 8);
        }

        [Test]
        public void Should_have_MaxNumberOfPawns_8()
        {
            Assert.AreEqual(ChessBoard.MaxNumberOfPawns, 8);
        }

        [Test]
        [TestCaseSource(typeof(AllWhitePawnChessBoardCoordinates))]
        public void Should_be_able_to_add_White_Pawn_to_valid_Coordinates_for_White_Pawn(ChessCoordinates coordinates)
        {
            var pawn = new Pawn(ChessPieceColor.White);
            var result = _chessBoard.Add(pawn, coordinates);
            Assert.AreEqual(AddResult.Success, result);
        }

        [Test]
        [TestCaseSource(typeof(AllBlackPawnChessBoardCoordinates))]
        public void Should_be_able_to_add_Black_Pawn_to_valid_Coordinates_for_Black_Pawn(ChessCoordinates coordinates)
        {
            var pawn = new Pawn(ChessPieceColor.Black);
            var result = _chessBoard.Add(pawn, coordinates);
            Assert.AreEqual(AddResult.Success, result);
        }

        [Test]
        [TestCaseSource(typeof(AllInvalidWhitePawnChessBoardCoordinates))]
        public void Should_not_be_able_to_add_White_Pawn_to_invalid_Coordinates_for_White_Pawn(ChessCoordinates coordinates)
        {
            var pawn = new Pawn(ChessPieceColor.White);
            var result = _chessBoard.Add(pawn, coordinates);
            Assert.AreEqual(AddResult.NotValidPositionForThisPiece, result);
        }

        [Test]
        [TestCaseSource(typeof(AllInvalidBlackPawnChessBoardCoordinates))]
        public void Should_not_be_able_to_add_Black_Pawn_to_invalid_Coordinates_for_Black_Pawn(ChessCoordinates coordinates)
        {
            var pawn = new Pawn(ChessPieceColor.Black);
            var result = _chessBoard.Add(pawn, coordinates);
            Assert.AreEqual(AddResult.NotValidPositionForThisPiece, result);
        }

        [Test]
        [TestCase(ChessPieceColor.White)]
        [TestCase(ChessPieceColor.Black)]
        public void ChessBoard_should_not_allow_duplicate_positioning(ChessPieceColor color)
        {
            var firstPawn = new Pawn(color);
            var secondPawn = new Pawn(color);
            var firstResult = _chessBoard.Add(firstPawn, new ChessCoordinates(1, 1));
            var secondResult = _chessBoard.Add(secondPawn, new ChessCoordinates(1, 1));
            Assert.AreEqual(AddResult.CoordinatesOccupied, secondResult);
            Assert.AreEqual(null, secondPawn.Coordinates);
        }

        [Test]
        [TestCase(ChessPieceColor.White)]
        [TestCase(ChessPieceColor.Black)]
        public void Should_be_able_to_check_if_Coordinates_Occupied(ChessPieceColor color)
        {
            var pawn = new Pawn(color);
            var coordinates = new ChessCoordinates(1, 1);
            _chessBoard.Add(pawn, coordinates);
            var occupied = _chessBoard.IsOccupied(coordinates);
            Assert.True(occupied);
        }

        [Test]
        public void Should_be_able_to_check_if_Coordinates_not_Occupied()
        {
            var occupied = _chessBoard.IsOccupied(new ChessCoordinates(0, 0));
            Assert.False(occupied);
        }

        [Test]
        [TestCase(ChessPieceColor.White)]
        [TestCase(ChessPieceColor.Black)]
        public void Should_be_able_to_add_up_to_8_Pawns(ChessPieceColor color)
        {
            var coordinates = new ChessCoordinates(1, 0);
            for (var i = 0; i <= 7; i++)
            {
                var pawn = new Pawn(ChessPieceColor.White);
                coordinates.Y = i;
                var result = _chessBoard.Add(pawn, coordinates);
                Assert.AreEqual(AddResult.Success, result);
            }
            for (var i = 0; i <= 7; i++)
            {
                coordinates.Y = i;
                var result = _chessBoard.IsOccupied(coordinates);
                Assert.AreEqual(true, result);
            }
        }

        [Test]
        public void Should_be_able_to_add_8_White_and_8_Black_Pawns()
        {
            var whiteCoordinates = new ChessCoordinates(1, 0);
            var blackCoordinates = new ChessCoordinates(6, 0);
            for (var i = 0; i <= 7; i++)
            {
                var whitePawn = new Pawn(ChessPieceColor.White);
                var blackPawn = new Pawn(ChessPieceColor.Black);
                whiteCoordinates.Y = i;
                blackCoordinates.Y = i;
                var whiteResult = _chessBoard.Add(whitePawn, whiteCoordinates);
                Assert.AreEqual(AddResult.Success, whiteResult);
                var blackResult = _chessBoard.Add(blackPawn, blackCoordinates);
                Assert.AreEqual(AddResult.Success, blackResult);
            }
            for (var i = 0; i <= 7; i++)
            {
                whiteCoordinates.Y = i;
                blackCoordinates.Y = i;
                var whiteResult = _chessBoard.IsOccupied(whiteCoordinates);
                Assert.AreEqual(true, whiteResult);
                var blackResult = _chessBoard.IsOccupied(blackCoordinates);
                Assert.AreEqual(true, blackResult);
            }
        }

        [Test]
        [TestCase(ChessPieceColor.White)]
        [TestCase(ChessPieceColor.Black)]
        public void Should_not_be_able_to_add_more_than_8_Pawns_of_the_same_color(ChessPieceColor color)
        {
            var coordinates = new ChessCoordinates(1, 0);
            for (var i = 0; i <= 10; i++)
            {
                var pawn = new Pawn(color);
                coordinates.X = 1 + i / ChessBoard.MaxBoardWidth; // starting at row 1 and not 0
                coordinates.Y = i % ChessBoard.MaxBoardWidth;
                var result = _chessBoard.Add(pawn, coordinates);
                if (i <= 7)
                {
                    Assert.AreEqual(AddResult.Success, result);
                }
                else
                {
                    Assert.AreEqual(AddResult.MaxNumberReached, result);
                }
            }
        }
        
        [Test]
        [TestCaseSource(typeof(AllWhitePawnChessBoardCoordinates))]
        public void Should_be_able_to_Remove_White_Pawn_from_valid_Coordinates_for_White_Pawn(ChessCoordinates coordinates)
        {
            var pawn = new Pawn(ChessPieceColor.White);
            _chessBoard.Add(pawn, coordinates);
            _chessBoard.Remove(coordinates);
            var result = _chessBoard.IsOccupied(coordinates);
            Assert.False(result);

        }

        [Test]
        [TestCaseSource(typeof(AllBlackPawnChessBoardCoordinates))]
        public void Should_be_able_to_Remove_Black_Pawn_from_valid_Coordinates_for_Black_Pawn(ChessCoordinates coordinates)
        {
            var pawn = new Pawn(ChessPieceColor.Black);
            _chessBoard.Add(pawn, coordinates);
            _chessBoard.Remove(coordinates);
            var result = _chessBoard.IsOccupied(coordinates);
            Assert.False(result);
        }

        [Test]
        [TestCase(ChessPieceColor.White)]
        [TestCase(ChessPieceColor.Black)]
        public void Should_be_able_to_get_the_same_Pawn_back_when_Removed(ChessPieceColor color)
        {
            var coordinates = new ChessCoordinates(1, 1);
            var pawn = new Pawn(color);
            _chessBoard.Add(pawn, coordinates);
            var result = _chessBoard.Remove(coordinates);
            Assert.AreEqual(pawn, result);
        }

        [Test]
        [TestCaseSource(typeof(AllWhitePawnValidMovesByOne))]
        public void Should_be_able_to_do_valid_move_by_one_square_with_White_Pawn(ChessCoordinates from, ChessCoordinates to)
        {
            var pawn = new Pawn(ChessPieceColor.White);
            _chessBoard.Add(pawn, from);
            var result = _chessBoard.Move(from, to);
            Assert.AreEqual(MoveResult.Moved, result);
        }

        [Test]
        [TestCaseSource(typeof(AllBlackPawnValidMovesByOne))]
        public void Should_be_able_to_do_valid_move_by_one_square_with_Black_Pawn(ChessCoordinates from, ChessCoordinates to)
        {
            var pawn = new Pawn(ChessPieceColor.Black);
            _chessBoard.Add(pawn, from);
            var result = _chessBoard.Move(from, to);
            Assert.AreEqual(MoveResult.Moved, result);
        }

        [Test]
        [TestCaseSource(typeof(AllWhitePawnValidMovesByTwo))]
        public void Should_be_able_to_Move_by_two_squares_from_starting_Coordinates_with_White_Pawn(ChessCoordinates from, ChessCoordinates to)
        {
            var pawn = new Pawn(ChessPieceColor.White);
            _chessBoard.Add(pawn, from);
            var result = _chessBoard.Move(from, to);
            Assert.AreEqual(MoveResult.Moved, result);
        }

        [Test]
        [TestCaseSource(typeof(AllBlackPawnValidMovesByTwo))]
        public void Should_be_able_to_Move_by_two_squares_from_starting_Coordinates_with_Black_Pawn(ChessCoordinates from, ChessCoordinates to)
        {
            var pawn = new Pawn(ChessPieceColor.Black);
            _chessBoard.Add(pawn, from);
            var result = _chessBoard.Move(from, to);
            Assert.AreEqual(MoveResult.Moved, result);
        }

        [Test]
        [TestCaseSource(typeof(AllWhitePawnInvalidMovesByTwo))]
        public void Should_not_be_able_to_Move_by_two_squares_from_non_starting_Coordinates_with_White_Pawn(ChessCoordinates from, ChessCoordinates to)
        {
            var pawn = new Pawn(ChessPieceColor.White);
            _chessBoard.Add(pawn, from);
            var result = _chessBoard.Move(from, to);
            Assert.AreEqual(MoveResult.NotValidMove, result);
        }

        [Test]
        [TestCaseSource(typeof(AllBlackPawnInvalidMovesByTwo))]
        public void Should_not_be_able_to_Move_by_two_squares_from_non_starting_Coordinates_with_Black_Pawn(ChessCoordinates from, ChessCoordinates to)
        {
            var pawn = new Pawn(ChessPieceColor.Black);
            _chessBoard.Add(pawn, from);
            var result = _chessBoard.Move(from, to);
            Assert.AreEqual(MoveResult.NotValidMove, result);
        }

        [Test]
        [TestCase(ChessPieceColor.White)]
        [TestCase(ChessPieceColor.Black)]
        public void Should_not_be_able_to_Move_Pawn_if_Blocked(ChessPieceColor color)
        {
            var backPawn = new Pawn(color);
            var frontPawn = new Pawn(color);
            var backCoordinates = new ChessCoordinates(1, 1);
            var frontCoordinates = new ChessCoordinates(2, 1);
            if (color is ChessPieceColor.Black)
            {
                backCoordinates.X = 2;
                frontCoordinates.X = 1;
            }
            _chessBoard.Add(backPawn, frontCoordinates);
            _chessBoard.Add(frontPawn, backCoordinates);
            var result = _chessBoard.Move(backCoordinates, frontCoordinates);
            Assert.AreEqual(MoveResult.Blocked, result);
        }

        [Test]
        [TestCase(ChessPieceColor.White)]
        [TestCase(ChessPieceColor.Black)]
        public void Should_not_be_able_to_Move_Pawn_left(ChessPieceColor color)
        {
            var pawn = new Pawn(color);
            var from = new ChessCoordinates(1, 1);
            var to = new ChessCoordinates(1, 0);
            _chessBoard.Add(pawn, from);
            var result = _chessBoard.Move(from, to);
            Assert.AreEqual(MoveResult.NotValidMove, result);
        }

        [Test]
        [TestCase(ChessPieceColor.White)]
        [TestCase(ChessPieceColor.Black)]
        public void Should_not_be_able_to_Move_Pawn_right(ChessPieceColor color)
        {
            var pawn = new Pawn(color);
            var from = new ChessCoordinates(1, 0);
            var to = new ChessCoordinates(1, 1);
            _chessBoard.Add(pawn, from);
            var result = _chessBoard.Move(from, to);
            Assert.AreEqual(MoveResult.NotValidMove, result);
        }

        [Test]
        [TestCase(ChessPieceColor.White)]
        [TestCase(ChessPieceColor.Black)]
        public void Should_not_be_able_to_Move_Pawn_backwards(ChessPieceColor color)
        {
            var pawn = new Pawn(color);
            var from = new ChessCoordinates(2, 0);
            var to = new ChessCoordinates(1, 0);
            if (color is ChessPieceColor.Black)
            {
                (from, to) = (to, from);
            }
            _chessBoard.Add(pawn, from);
            var result = _chessBoard.Move(from, to);
            Assert.AreEqual(MoveResult.NotValidMove, result);
        }

        [Test]
        [TestCaseSource(typeof(AllInvalidDiagonalPawnMoves))]
        public void Should_not_be_able_to_Move_White_Pawn_diagonal(ChessCoordinates from, ChessCoordinates to)
        {
            var pawn = new Pawn(ChessPieceColor.White);
            _chessBoard.Add(pawn, from);
            var result = _chessBoard.Move(from, to);
            Assert.AreEqual(MoveResult.NotValidMove, result);
        }

        [Test]
        [TestCaseSource(typeof(AllInvalidDiagonalPawnMoves))]
        public void Should_not_be_able_to_Move_Black_Pawn_diagonal(ChessCoordinates from, ChessCoordinates to)
        {
            var pawn = new Pawn(ChessPieceColor.Black);
            _chessBoard.Add(pawn, from);
            var result = _chessBoard.Move(from, to);
            Assert.AreEqual(MoveResult.NotValidMove, result);
        }

    }
}
