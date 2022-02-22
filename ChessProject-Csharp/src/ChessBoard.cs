using System;
using SolarWinds.MSP.Chess.Enums;

namespace SolarWinds.MSP.Chess
{
    /// <summary>
    /// Represents a chess board and it is responsible for maintaining its state.
    /// </summary>
    public class ChessBoard
    {
        public const int MaxBoardWidth = 8;
        public const int MaxBoardHeight = 8;
        public const int MaxNumberOfPawns = 8;
        private readonly ChessPiece[,] _pieces;
        private int _numberOfWhitePawns = 0;
        private int _numberOfBlackPawns = 0;

        /// <summary>
        /// Creates ChessBoard.
        /// </summary>
        public ChessBoard()
        {
            _pieces = new ChessPiece[MaxBoardWidth, MaxBoardHeight];
        }

        /// <summary>
        /// Adds a ChessPiece to the ChessBoard at a specific ChessCoordinates.
        /// </summary>
        /// <param name="piece">ChessPiece to be added.</param>
        /// <param name="coordinates">Coordinates where to add a ChessPiece.</param>
        /// <returns>AddResult</returns>
        /// <exception cref="ArgumentException">If unknown ChessPiece is provided.</exception>
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

        /// <summary>
        /// Removes a ChessPiece from the ChessBoard.
        /// </summary>
        /// <param name="coordinates">ChessCoordinates from where to remove a ChessPiece.</param>
        /// <returns>The removed ChessPiece.</returns>
        public ChessPiece Remove(ChessCoordinates coordinates)
        {
            var piece = _pieces[coordinates.X, coordinates.Y];
            _pieces[coordinates.X, coordinates.Y] = null;
            piece.Coordinates = null;
            return piece;
        }

        /// <summary>
        /// Moves a ChessPiece from ChessCoordinates to ChessCoordinates if it is a valid move.
        /// </summary>
        /// <param name="from">ChessCoordinates from where to move a ChessPiece.</param>
        /// <param name="to">Destination ChessCoordinates where to move a ChessPiece.</param>
        /// <returns>MoveResult</returns>
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

        /// <summary>
        /// Checks if a ChessCoordinates on the ChessBoard is occupied.
        /// </summary>
        /// <param name="coordinates">ChessCoordinates to check.</param>
        /// <returns>True if occupied.</returns>
        public bool IsOccupied(ChessCoordinates coordinates) => _pieces[coordinates.X, coordinates.Y] is not null;

        private bool[,] BoardOccupancyState()
        {
            var state = new bool[_pieces.GetLength(0), _pieces.GetLength(1)];
            for (var x = 0; x < _pieces.GetLength(0); x++)
            for (var y = 0; y < _pieces.GetLength(1); y++)
                state[x, y] = _pieces[x, y] is not null; 
            return state;
        }

        /// <summary>
        /// Adds Pawn to a ChessBoard.
        /// </summary>
        /// <param name="pawn">Pawn to be added.</param>
        /// <param name="coordinates">ChessCoordinates where to add the Pawn.</param>
        /// <returns>AddResult</returns>
        /// <exception cref="ArgumentException">If a Pawn of unknown ChessPieceColor is provided.</exception>
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
