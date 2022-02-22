using System.Collections;

namespace SolarWinds.MSP.Chess.Tests
{
    internal class AllWhitePawnChessBoardCoordinates : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            for (var i = 8; i <= 63; i++)
            {
                var x = i / ChessBoard.MaxBoardWidth; // implicit floor
                var y = i % ChessBoard.MaxBoardWidth;
                yield return new ChessCoordinates(x, y);
            }
        }
    }
    internal class AllInvalidWhitePawnChessBoardCoordinates : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            for (var y = 0; y <= 7; y++)
            {
                yield return new ChessCoordinates(0, y);
            }
        }
    }

    internal class AllBlackPawnChessBoardCoordinates : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            for (var i = 0; i <= 55; i++)
            {
                var x = i / ChessBoard.MaxBoardWidth; // implicit floor
                var y = i % ChessBoard.MaxBoardWidth;
                yield return new ChessCoordinates(x, y);
            }
        }
    }

    internal class AllInvalidBlackPawnChessBoardCoordinates : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            for (var y = 0; y <= 7; y++)
            {
                yield return new ChessCoordinates(7, y);
            }
        }
    }

    internal class AllWhitePawnValidMovesByOne : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            for (var i = 8; i <= 55; i++)
            {
                var x = i / ChessBoard.MaxBoardWidth; // implicit floor
                var y = i % ChessBoard.MaxBoardWidth;
                var from = new ChessCoordinates(x, y);
                var to = new ChessCoordinates(x + 1, y);
                var coordinates = new ChessCoordinates[] { from, to };
                yield return coordinates;
            }
        }
    }

    internal class AllWhitePawnValidMovesByTwo : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            for (var i = 8; i <= 15; i++)
            {
                var x = i / ChessBoard.MaxBoardWidth; // implicit floor
                var y = i % ChessBoard.MaxBoardWidth;
                var from = new ChessCoordinates(x, y);
                var to = new ChessCoordinates(x + 2, y);
                var coordinates = new ChessCoordinates[] { from, to };
                yield return coordinates;
            }
        }
    }

    internal class AllWhitePawnInvalidMovesByTwo : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            for (var i = 16; i <= 47; i++)
            {
                var x = i / ChessBoard.MaxBoardWidth; // implicit floor
                var y = i % ChessBoard.MaxBoardWidth;
                var from = new ChessCoordinates(x, y);
                var to = new ChessCoordinates(x + 2, y);
                var coordinates = new ChessCoordinates[] { from, to };
                yield return coordinates;
            }
        }
    }

    internal class AllBlackPawnValidMovesByOne : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            for (var i = 55; i >= 8; i--)
            {
                var x = i / ChessBoard.MaxBoardWidth; // implicit floor
                var y = i % ChessBoard.MaxBoardWidth;
                var from = new ChessCoordinates(x, y);
                var to = new ChessCoordinates(x - 1, y);
                var coordinates = new ChessCoordinates[] { from, to };
                yield return coordinates;
            }
        }
    }

    internal class AllBlackPawnValidMovesByTwo : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            for (var i = 55; i >= 48; i--)
            {
                var x = i / ChessBoard.MaxBoardWidth; // implicit floor
                var y = i % ChessBoard.MaxBoardWidth;
                var from = new ChessCoordinates(x, y);
                var to = new ChessCoordinates(x - 2, y);
                var coordinates = new ChessCoordinates[] { from, to };
                yield return coordinates;
            }
        }
    }

    internal class AllBlackPawnInvalidMovesByTwo : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            for (var i = 47; i >= 16; i--)
            {
                var x = i / ChessBoard.MaxBoardWidth; // implicit floor
                var y = i % ChessBoard.MaxBoardWidth;
                var from = new ChessCoordinates(x, y);
                var to = new ChessCoordinates(x - 2, y);
                var coordinates = new ChessCoordinates[] { from, to };
                yield return coordinates;
            }
        }
    }

    internal class AllInvalidDiagonalPawnMoves : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            var diagonalMoves = new int[,] { { 2, 0 }, { 2, 2 }, { 1, 0 }, { 1, 2 } };
            var from = new ChessCoordinates(2, 1);
            for (int i = 0; i < diagonalMoves.GetLength(0); i++)
            {
                var to = new ChessCoordinates(diagonalMoves[i, 0], diagonalMoves[i, 1]);
                var coordinates = new ChessCoordinates[] { from, to };
                yield return coordinates;
            }
        }
    }
}
