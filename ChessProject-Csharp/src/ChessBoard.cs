using System;
using SolarWinds.MSP.Chess.Enums;

namespace SolarWinds.MSP.Chess
{
    public class ChessBoard
    {
        public const int MaxBoardWidth = 8;
        public const int MaxBoardHeight = 8;
        public const int MaxNumberOfPawns = 8;
        private readonly ChessPiece[,] _pieces;
        private int _numberOfWhitePawns = 0;
        private int _numberOfBlackPawns = 0;

        public ChessBoard()
        {
            // It needs 8 squares in each direction. From index 0 up to 7.
            _pieces = new ChessPiece[MaxBoardWidth, MaxBoardHeight];
        }

        public AddResult Add(ChessPiece piece, ChessCoordinates coordinates)
        {
            if (_pieces[coordinates.X, coordinates.Y] is not null) return AddResult.CoordinatesOccupied;
            switch (piece)
            {
                case Pawn pawn:
                    return AddPawn(pawn, coordinates);
                default:
                    throw new ArgumentException("The piece is of an unknown type.", nameof(piece));
            }
        }
        public ChessPiece Remove(ChessCoordinates coordinates)
        {
            var piece = _pieces[coordinates.X, coordinates.Y];
            _pieces[coordinates.X, coordinates.Y] = null;
            piece.Coordinates = null;
            return piece;
        }

        public MoveResult Move(ChessCoordinates from, ChessCoordinates to)
        {
            var piece = _pieces[from.X, from.Y];
            if (piece is null) return MoveResult.NotValidMove;
            var boardOccupancy = BoardOccupancyState();
            var result = piece.ValidateMove(to,boardOccupancy);
            if (result is not MoveResult.Avalilable) return result;
            _pieces[from.X, from.Y] = null;
            _pieces[to.X, to.Y] = piece;
            piece.Coordinates.X = to.X;
            piece.Coordinates.Y = to.Y;
            return MoveResult.Moved;
        }

        public bool IsOccupied(ChessCoordinates coordinates) => _pieces[coordinates.X, coordinates.Y] is not null;

        private bool[,] BoardOccupancyState()
        {
            var state = new bool[_pieces.GetLength(0), _pieces.GetLength(1)];
            for (var x = 0; x < _pieces.GetLength(0); x++)
            for (var y = 0; y < _pieces.GetLength(1); y++)
                state[x, y] = _pieces[x, y] is not null; 
            return state;
        }

        private AddResult AddPawn(Pawn pawn, ChessCoordinates coordinates)
        {
            switch (pawn.PieceColor)
            {
                case ChessPieceColor.White:
                    if (_numberOfWhitePawns >= MaxNumberOfPawns) return AddResult.MaxNumberReached;
                    if (coordinates.X == 0) return AddResult.NotValidPositionForThisPiece;
                    _numberOfWhitePawns++;
                    pawn.Coordinates = new ChessCoordinates(coordinates.X, coordinates.Y);
                    _pieces[coordinates.X, coordinates.Y] = pawn;
                    return AddResult.Success;

                case ChessPieceColor.Black:
                    if (_numberOfBlackPawns >= MaxNumberOfPawns) return AddResult.MaxNumberReached;
                    if (coordinates.X == 7) return AddResult.NotValidPositionForThisPiece;
                    _numberOfBlackPawns++;
                    pawn.Coordinates = new ChessCoordinates(coordinates.X, coordinates.Y); 
                    _pieces[coordinates.X, coordinates.Y] = pawn;
                    return AddResult.Success;
                default:
                    throw new ArgumentException("The pawn is of an unknown color.", nameof(pawn));
            }
        }
    }
}
