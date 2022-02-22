using System;
using NUnit.Framework;
using SolarWinds.MSP.Chess.Enums;

namespace SolarWinds.MSP.Chess.Tests
{
    [TestFixture]
    public class PawnTest
    {
        private bool[,] _boardOccupancy;

        [SetUp]
        public void SetUp()
        {
            _boardOccupancy = new bool[8, 8];
        }

        [Test]
        [TestCase(ChessPieceColor.White)]
        [TestCase(ChessPieceColor.Black)]
        public void Should_have_Color(ChessPieceColor color)
        {
            var pawn = new Pawn(color);
            Assert.AreEqual(color, pawn.PieceColor);
        }

        [Test]
        [TestCase(ChessPieceColor.White)]
        [TestCase(ChessPieceColor.Black)]
        public void Should_be_able_to_set_Coordinates(ChessPieceColor color)
        {
            var pawn = new Pawn(color);
            var coordinates = new ChessCoordinates(1, 0);
            pawn.Coordinates = coordinates;
            Assert.AreEqual(coordinates, pawn.Coordinates);
        }

        [Test]
        public void Pawn_be_printed_nicely()
        {
            var pawn = new Pawn(ChessPieceColor.White){Coordinates = new ChessCoordinates(1,2)};
            var expected = string.Format("Piece: Pawn{0}Coordinates: (X: 1, Y: 2){0}Piece Color: White", Environment.NewLine);
            Assert.AreEqual(expected, pawn.ToString());
            TestContext.Out.WriteLine(pawn);
        }

        [Test]
        [TestCaseSource(typeof(AllWhitePawnValidMovesByOne))]
        public void White_Pawn_should_evaluate_valid_moves_by_one_as_Available(ChessCoordinates from, ChessCoordinates to)
        {
            var pawn = new Pawn(ChessPieceColor.White) { Coordinates = from };
            var boardOccupancy = new bool[8, 8];
            var result = pawn.ValidateMove(to, boardOccupancy);
            Assert.AreEqual(MoveResult.Avalilable, result);
        }

        [Test]
        [TestCaseSource(typeof(AllBlackPawnValidMovesByOne))]
        public void Black_Pawn_should_evaluate_valid_moves_by_one_as_Available(ChessCoordinates from, ChessCoordinates to)
        {
            var pawn = new Pawn(ChessPieceColor.Black) { Coordinates = from };
            var boardOccupancy = new bool[8, 8];
            var result = pawn.ValidateMove(to, boardOccupancy);
            Assert.AreEqual(MoveResult.Avalilable, result);
        }

        [Test]
        [TestCaseSource(typeof(AllWhitePawnValidMovesByTwo))]
        public void White_Pawn_should_evaluate_valid_moves_by_two_as_Available(ChessCoordinates from, ChessCoordinates to)
        {
            var pawn = new Pawn(ChessPieceColor.White) { Coordinates = from };
            var boardOccupancy = new bool[8, 8];
            var result = pawn.ValidateMove(to, boardOccupancy);
            Assert.AreEqual(MoveResult.Avalilable, result);
        }

        [Test]
        [TestCaseSource(typeof(AllBlackPawnValidMovesByTwo))]
        public void Black_Pawn_should_evaluate_valid_moves_by_two_as_Available(ChessCoordinates from, ChessCoordinates to)
        {
            var pawn = new Pawn(ChessPieceColor.Black) { Coordinates = from };
            var result = pawn.ValidateMove(to, _boardOccupancy);
            Assert.AreEqual(MoveResult.Avalilable, result);
        }

        [Test]
        [TestCaseSource(typeof(AllWhitePawnInvalidMovesByTwo))]
        public void White_Pawn_should_evaluate_Move_by_two_squares_from_non_starting_Coordinates_as_NotValidMove(ChessCoordinates from, ChessCoordinates to)
        {
            var pawn = new Pawn(ChessPieceColor.White) { Coordinates = from };
            var result = pawn.ValidateMove(to, _boardOccupancy);
            Assert.AreEqual(MoveResult.NotValidMove, result);
        }

        [Test]
        [TestCaseSource(typeof(AllBlackPawnInvalidMovesByTwo))]
        public void Black_Pawn_should_evaluate_Move_by_two_squares_from_non_starting_Coordinates_as_NotValidMove(ChessCoordinates from, ChessCoordinates to)
        {
            var pawn = new Pawn(ChessPieceColor.Black) { Coordinates = from };
            var result = pawn.ValidateMove(to, _boardOccupancy);
            Assert.AreEqual(MoveResult.NotValidMove, result);
        }

        [Test]
        [TestCase(ChessPieceColor.White)]
        [TestCase(ChessPieceColor.Black)]
        public void Should_return_Blocked_if_Pawn_is_blocked(ChessPieceColor color)
        {
            var pawn = new Pawn(color);
            var from = new ChessCoordinates(1, 1);
            var to = new ChessCoordinates(2, 1);
            _boardOccupancy[2, 1] = true;
            if (color is ChessPieceColor.Black)
            {
                from.X = 2;
                to.X = 1;
                _boardOccupancy[1, 1] = true;
                _boardOccupancy[2, 1] = false;
            }
            pawn.Coordinates = from;
            var result = pawn.ValidateMove(to, _boardOccupancy);
            Assert.AreEqual(MoveResult.Blocked, result);
        }

        [Test]
        [TestCase(ChessPieceColor.White)]
        [TestCase(ChessPieceColor.Black)]
        public void Should_return_NotValidMove_for_left_move(ChessPieceColor color)
        {
            var from = new ChessCoordinates(1, 1);
            var to = new ChessCoordinates(1, 0);
            var pawn = new Pawn(color) { Coordinates = from };
            var result = pawn.ValidateMove(to, _boardOccupancy);
            Assert.AreEqual(MoveResult.NotValidMove, result);
        }

        [Test]
        [TestCase(ChessPieceColor.White)]
        [TestCase(ChessPieceColor.Black)]
        public void Should_return_NotValidMove_for_right_move(ChessPieceColor color)
        {
            var from = new ChessCoordinates(1, 1);
            var to = new ChessCoordinates(1, 2);
            var pawn = new Pawn(color) { Coordinates = from };
            var result = pawn.ValidateMove(to, _boardOccupancy);
            Assert.AreEqual(MoveResult.NotValidMove, result);
        }

        [Test]
        [TestCase(ChessPieceColor.White)]
        [TestCase(ChessPieceColor.Black)]
        public void Should_return_NotValidMove_backward_movement(ChessPieceColor color)
        {
            var from = new ChessCoordinates(2, 0);
            var to = new ChessCoordinates(1, 0);
            var pawn = new Pawn(color){Coordinates = from};
            if (color is ChessPieceColor.Black)
            {
                to = from;
            }
            var result = pawn.ValidateMove(to, _boardOccupancy);
            Assert.AreEqual(MoveResult.NotValidMove, result);
        }

        [Test]
        [TestCaseSource(typeof(AllInvalidDiagonalPawnMoves))]
        public void White_Pawn_should_return_NotValidMove_for_diagonal_movement(ChessCoordinates from, ChessCoordinates to)
        {
            var pawn = new Pawn(ChessPieceColor.White){Coordinates = from};
            var result = pawn.ValidateMove(to, _boardOccupancy);
            Assert.AreEqual(MoveResult.NotValidMove, result);
        }

        [Test]
        [TestCaseSource(typeof(AllInvalidDiagonalPawnMoves))]
        public void Black_Pawn_should_return_NotValidMove_for_diagonal_movement(ChessCoordinates from, ChessCoordinates to)
        {
            var pawn = new Pawn(ChessPieceColor.Black) { Coordinates = from };
            var result = pawn.ValidateMove(to, _boardOccupancy);
            Assert.AreEqual(MoveResult.NotValidMove, result);
        }
    }
}
